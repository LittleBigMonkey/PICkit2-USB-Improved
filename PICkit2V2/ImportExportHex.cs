using System;
using System.Globalization;
using System.IO;

namespace PICkit2V2
{
	internal class ImportExportHex
	{
		public static DateTime LastWriteTime = default(DateTime);

		public static Constants.FileRead ImportHexFile(string filePath, bool progMem, bool eeMem)
		{
			if (filePath.Length > 4 && filePath.Substring(filePath.Length - 4).ToUpper() == ".BIN" && PICkitFunctions.FamilyIsEEPROM())
			{
				return ImportBINFile(filePath);
			}
			try
			{
				FileInfo fileInfo = new FileInfo(filePath);
				LastWriteTime = fileInfo.LastWriteTime;
				TextReader textReader = fileInfo.OpenText();
				int progMemHexBytes = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemHexBytes;
				int eEMemHexBytes = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemHexBytes;
				uint eEAddr = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEAddr;
				int num = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem * progMemHexBytes;
				int num2 = 0;
				bool flag = false;
				bool flag2 = true;
				bool flag3 = false;
				int userIDWords = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords;
				uint num3 = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDAddr;
				if (num3 == 0)
				{
					num3 = uint.MaxValue;
				}
				int userIDHexBytes = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].UserIDHexBytes;
				int configWords = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords;
				bool[] array = new bool[configWords];
				for (int i = 0; i < configWords; i++)
				{
					PICkitFunctions.DeviceBuffers.ConfigWords[i] = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue;
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[i] == 0)
					{
						array[i] = true;
					}
					else
					{
						array[i] = false;
					}
				}
				int num4 = progMemHexBytes;
				uint num5 = 0u;
				uint num6 = 0u;
				uint bootFlash = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BootFlash;
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 16777215)
				{
					num5 = 486539264u;
					num6 = 532676608u;
					num -= (int)bootFlash * progMemHexBytes;
					num += (int)num5;
					num4 = 2;
				}
				uint num7 = (uint)((int)num6 + (int)bootFlash * progMemHexBytes);
				int num8 = (int)(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem - bootFlash);
				for (string text = textReader.ReadLine(); text != null; text = textReader.ReadLine())
				{
					if (text[0] == ':' && text.Length >= 11)
					{
						int num9 = int.Parse(text.Substring(1, 2), NumberStyles.HexNumber);
						int num10 = num2 + int.Parse(text.Substring(3, 4), NumberStyles.HexNumber);
						int num11 = int.Parse(text.Substring(7, 2), NumberStyles.HexNumber);
						if (num11 == 0)
						{
							if (text.Length >= 11 + 2 * num9)
							{
								for (int j = 0; j < num9; j++)
								{
									int num12 = num10 + j;
									int num13 = (num12 - (int)num5) / progMemHexBytes;
									int num14 = num12 % progMemHexBytes;
									uint num15 = (uint)(-256 | (int)uint.Parse(text.Substring(9 + 2 * j, 2), NumberStyles.HexNumber));
									for (int k = 0; k < num14; k++)
									{
										num15 <<= 8;
										num15 |= 0xFF;
									}
									flag2 = true;
									if (num12 >= num5 && num12 < num)
									{
										if (progMem)
										{
											PICkitFunctions.DeviceBuffers.ProgramMemory[num13] &= num15;
										}
										flag2 = false;
									}
									if (bootFlash != 0 && num12 >= num6 && num12 < num7)
									{
										num13 = (int)(num8 + (num12 - num6) / progMemHexBytes);
										if (progMem)
										{
											PICkitFunctions.DeviceBuffers.ProgramMemory[num13] &= num15;
										}
										flag2 = false;
									}
									if (num12 >= eEAddr && eEAddr != 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0)
									{
										int num16 = (int)(num12 - eEAddr) / eEMemHexBytes;
										if (num16 < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem)
										{
											flag2 = false;
											if (eeMem)
											{
												if (eEMemHexBytes == progMemHexBytes)
												{
													PICkitFunctions.DeviceBuffers.EEPromMemory[num16] &= num15;
												}
												else
												{
													int num17 = num14 / eEMemHexBytes * eEMemHexBytes;
													for (int l = 0; l < num17; l++)
													{
														num15 >>= 8;
													}
													PICkitFunctions.DeviceBuffers.EEPromMemory[num16] &= num15;
												}
											}
										}
									}
									else if (num12 >= eEAddr && eEAddr != 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem == 0)
									{
										flag2 = false;
									}
									if (num12 >= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr && configWords > 0)
									{
										int num18 = (num12 - (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr) / num4;
										if (num4 != progMemHexBytes && num14 > 1)
										{
											num15 = ((num15 >> 16) & PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
										}
										if (num18 < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords)
										{
											flag2 = false;
											flag = true;
											array[num18] = true;
											if (progMem)
											{
												PICkitFunctions.DeviceBuffers.ConfigWords[num18] &= num15;
												if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue == 4095)
												{
													PICkitFunctions.DeviceBuffers.ConfigWords[num18] |= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[5];
												}
												if (num12 < num)
												{
													uint num19 = 0u;
													num19 = (uint)((PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue != 65535) ? (0xFF0000 | (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[num18] & ~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[num18])) : 61440);
													PICkitFunctions.DeviceBuffers.ProgramMemory[num13] &= (num15 & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[num18]);
													PICkitFunctions.DeviceBuffers.ProgramMemory[num13] |= num19;
												}
											}
										}
									}
									if (userIDWords > 0 && num12 >= num3)
									{
										int num20 = (int)(num12 - num3) / userIDHexBytes;
										if (num20 < userIDWords)
										{
											flag2 = false;
											if (progMem)
											{
												if (userIDHexBytes == progMemHexBytes)
												{
													PICkitFunctions.DeviceBuffers.UserIDs[num20] &= num15;
												}
												else
												{
													int num21 = num14 / userIDHexBytes * userIDHexBytes;
													for (int m = 0; m < num21; m++)
													{
														num15 >>= 8;
													}
													PICkitFunctions.DeviceBuffers.UserIDs[num20] &= num15;
												}
											}
										}
									}
									if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].IgnoreBytes > 0 && num12 >= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].IgnoreAddress && num12 < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].IgnoreAddress + PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].IgnoreBytes)
									{
										flag2 = false;
									}
									if (FormPICkit2.TestMemoryEnabled && FormPICkit2.TestMemoryOpen && FormPICkit2.formTestMem.HexImportExportTM() && num12 >= PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart && PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart != 0 && FormPICkit2.TestMemoryWords > 0)
									{
										int num22 = (int)(num12 - PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart) / progMemHexBytes;
										if (num22 < FormPICkit2.TestMemoryWords)
										{
											flag2 = false;
											FormTestMemory.TestMemory[num22] &= num15;
										}
									}
								}
							}
							if (flag2)
							{
								flag3 = true;
							}
						}
						if (num11 == 2 || num11 == 4)
						{
							if (text.Length >= 11 + 2 * num9)
							{
								num2 = int.Parse(text.Substring(9, 4), NumberStyles.HexNumber);
							}
							num2 = ((num11 != 2) ? (num2 << 16) : (num2 << 4));
						}
						if (num11 == 1 || fileInfo.Extension.ToUpper() == ".NUM")
						{
							break;
						}
					}
				}
				textReader.Close();
				if (configWords > 0)
				{
					if (!flag)
					{
						return Constants.FileRead.noconfig;
					}
					for (int n = 0; n < configWords; n++)
					{
						if (!array[n])
						{
							if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue == 16777215 && configWords > 7)
							{
								PICkitFunctions.DeviceBuffers.ConfigWords[7] &= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[7];
							}
							return Constants.FileRead.partialcfg;
						}
					}
				}
				if (flag3)
				{
					return Constants.FileRead.largemem;
				}
				return Constants.FileRead.success;
			}
			catch
			{
				return Constants.FileRead.failed;
			}
		}

		public static Constants.FileRead ImportBINFile(string filePath)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(filePath);
				LastWriteTime = fileInfo.LastWriteTime;
				FileStream fileStream = File.OpenRead(filePath);
				int progMemHexBytes = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemHexBytes;
				int num = 0;
				int num2 = 0;
				byte[] array = new byte[1];
				while (fileStream.Read(array, 0, 1) > 0)
				{
					if (num >= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem)
					{
						return Constants.FileRead.largemem;
					}
					uint num3 = (uint)(-256 | array[0]);
					for (int i = 0; i < num2; i++)
					{
						num3 <<= 8;
						num3 |= 0xFF;
					}
					PICkitFunctions.DeviceBuffers.ProgramMemory[num] &= num3;
					if (++num2 >= progMemHexBytes)
					{
						num++;
						num2 = 0;
					}
				}
				fileStream.Close();
			}
			catch
			{
				return Constants.FileRead.failed;
			}
			return Constants.FileRead.success;
		}

		public static bool ExportHexFile(string filePath, bool progMem, bool eeMem)
		{
			if (filePath.Length > 4 && filePath.Substring(filePath.Length - 4).ToUpper() == ".BIN" && PICkitFunctions.FamilyIsEEPROM())
			{
				return ExportBINFile(filePath);
			}
			StreamWriter streamWriter = new StreamWriter(filePath);
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 16777215)
			{
				streamWriter.WriteLine(":020000041D00DD");
			}
			else
			{
				streamWriter.WriteLine(":020000040000FA");
			}
			int num = 0;
			int num2 = 0;
			int num3 = PICkitFunctions.DeviceBuffers.ProgramMemory.Length;
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 16777215)
			{
				num = 7424;
				num2 = 0;
				num3 -= (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BootFlash;
			}
			int num4 = 0;
			int progMemHexBytes = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemHexBytes;
			int num5 = 16 / progMemHexBytes;
			if (progMem)
			{
				do
				{
					string text = $":10{num2:X4}00";
					for (int i = 0; i < num5; i++)
					{
						string text2 = "00000000";
						if (num4 + i < PICkitFunctions.DeviceBuffers.ProgramMemory.Length)
						{
							text2 = $"{PICkitFunctions.DeviceBuffers.ProgramMemory[num4 + i]:X8}";
						}
						for (int j = 0; j < progMemHexBytes; j++)
						{
							text += text2.Substring(6 - 2 * j, 2);
						}
					}
					text += $"{computeChecksum(text):X2}";
					streamWriter.WriteLine(text);
					num2 += 16;
					num4 += num5;
					if (num2 > 65535 && num4 < PICkitFunctions.DeviceBuffers.ProgramMemory.Length)
					{
						num += num2 >> 16;
						num2 &= 0xFFFF;
						string text3 = $":02000004{num:X4}";
						text3 += $"{computeChecksum(text3):X2}";
						streamWriter.WriteLine(text3);
					}
				}
				while (num4 < num3);
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BootFlash != 0 && PICkitFunctions.FamilyIsPIC32())
			{
				streamWriter.WriteLine(":020000041FC01B");
				num4 = num3;
				num3 = PICkitFunctions.DeviceBuffers.ProgramMemory.Length;
				num = 8128;
				num2 = 0;
				if (progMem)
				{
					do
					{
						string text4 = $":10{num2:X4}00";
						for (int k = 0; k < num5; k++)
						{
							string text5 = $"{PICkitFunctions.DeviceBuffers.ProgramMemory[num4 + k]:X8}";
							for (int l = 0; l < progMemHexBytes; l++)
							{
								text4 += text5.Substring(6 - 2 * l, 2);
							}
						}
						text4 += $"{computeChecksum(text4):X2}";
						streamWriter.WriteLine(text4);
						num2 += 16;
						num4 += num5;
						if (num2 > 65535 && num4 < PICkitFunctions.DeviceBuffers.ProgramMemory.Length)
						{
							num += num2 >> 16;
							num2 &= 0xFFFF;
							string text6 = $":02000004{num:X4}";
							text6 += $"{computeChecksum(text6):X2}";
							streamWriter.WriteLine(text6);
						}
					}
					while (num4 < num3);
				}
			}
			if (eeMem)
			{
				int eEMem = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem;
				num4 = 0;
				if (eEMem > 0)
				{
					uint eEAddr = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEAddr;
					if (((int)eEAddr & -65536) != 0)
					{
						string text7 = $":02000004{eEAddr >> 16:X4}";
						text7 += $"{computeChecksum(text7):X2}";
						streamWriter.WriteLine(text7);
					}
					num2 = (int)(eEAddr & 0xFFFF);
					int eEMemHexBytes = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemHexBytes;
					num5 = 16 / eEMemHexBytes;
					do
					{
						string text8 = $":10{num2:X4}00";
						for (int m = 0; m < num5; m++)
						{
							string text9 = $"{PICkitFunctions.DeviceBuffers.EEPromMemory[num4 + m]:X8}";
							for (int n = 0; n < eEMemHexBytes; n++)
							{
								text8 += text9.Substring(6 - 2 * n, 2);
							}
						}
						text8 += $"{computeChecksum(text8):X2}";
						streamWriter.WriteLine(text8);
						num2 += 16;
						num4 += num5;
					}
					while (num4 < PICkitFunctions.DeviceBuffers.EEPromMemory.Length);
				}
			}
			if (progMem)
			{
				int num6 = progMemHexBytes;
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 16777215)
				{
					num6 = 2;
				}
				int configWords = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords;
				if (configWords > 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr > PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem * progMemHexBytes)
				{
					uint configAddr = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr;
					if (((int)configAddr & -65536) != 0)
					{
						string text10 = $":02000004{configAddr >> 16:X4}";
						text10 += $"{computeChecksum(text10):X2}";
						streamWriter.WriteLine(text10);
					}
					num2 = (int)(configAddr & 0xFFFF);
					int num7 = 0;
					for (int num8 = 0; num8 < (configWords * num6 - 1) / 16 + 1; num8++)
					{
						int num9 = configWords - num7;
						if (num9 >= 16 / num6)
						{
							num9 = 16 / num6;
						}
						string text11 = $":{num9 * num6:X2}{num2:X4}00";
						num2 += num9 * num6;
						for (int num10 = 0; num10 < num9; num10++)
						{
							uint num11 = PICkitFunctions.DeviceBuffers.ConfigWords[num7 + num10];
							if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 16777215)
							{
								num11 = (uint)((int)num11 | ~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[num7 + num10]);
								num11 &= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[num7 + num10];
							}
							string text12 = $"{num11:X8}";
							for (int num12 = 0; num12 < num6; num12++)
							{
								text11 += text12.Substring(8 - (num12 + 1) * 2, 2);
							}
						}
						text11 += $"{computeChecksum(text11):X2}";
						streamWriter.WriteLine(text11);
						num7 += num9;
					}
				}
			}
			if (progMem)
			{
				int userIDWords = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords;
				num4 = 0;
				if (userIDWords > 0)
				{
					uint userIDAddr = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDAddr;
					if (((int)userIDAddr & -65536) != 0)
					{
						string text13 = $":02000004{userIDAddr >> 16:X4}";
						text13 += $"{computeChecksum(text13):X2}";
						streamWriter.WriteLine(text13);
					}
					num2 = (int)(userIDAddr & 0xFFFF);
					int userIDHexBytes = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].UserIDHexBytes;
					num5 = 16 / userIDHexBytes;
					do
					{
						int num13 = (userIDWords - num4) * userIDHexBytes;
						string text14;
						if (num13 < 16)
						{
							text14 = $":{num13:X2}{num2:X4}00";
							num5 = userIDWords - num4;
						}
						else
						{
							text14 = $":10{num2:X4}00";
						}
						for (int num14 = 0; num14 < num5; num14++)
						{
							string text15 = $"{PICkitFunctions.DeviceBuffers.UserIDs[num4 + num14]:X8}";
							for (int num15 = 0; num15 < userIDHexBytes; num15++)
							{
								text14 += text15.Substring(6 - 2 * num15, 2);
							}
						}
						text14 += $"{computeChecksum(text14):X2}";
						streamWriter.WriteLine(text14);
						num2 += 16;
						num4 += num5;
					}
					while (num4 < PICkitFunctions.DeviceBuffers.UserIDs.Length);
				}
			}
			if (FormPICkit2.TestMemoryEnabled && FormPICkit2.TestMemoryOpen && FormPICkit2.formTestMem.HexImportExportTM())
			{
				int testMemoryWords = FormPICkit2.TestMemoryWords;
				num4 = 0;
				if (testMemoryWords > 0)
				{
					uint testMemoryStart = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart;
					if (((int)testMemoryStart & -65536) != 0)
					{
						string text16 = $":02000004{testMemoryStart >> 16:X4}";
						text16 += $"{computeChecksum(text16):X2}";
						streamWriter.WriteLine(text16);
					}
					num2 = (int)(testMemoryStart & 0xFFFF);
					int progMemHexBytes2 = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemHexBytes;
					num5 = 16 / progMemHexBytes2;
					do
					{
						string text17 = $":10{num2:X4}00";
						for (int num16 = 0; num16 < num5; num16++)
						{
							string text18 = $"{FormTestMemory.TestMemory[num4 + num16]:X8}";
							for (int num17 = 0; num17 < progMemHexBytes2; num17++)
							{
								text17 += text18.Substring(6 - 2 * num17, 2);
							}
						}
						text17 += $"{computeChecksum(text17):X2}";
						if (num2 != (int)(testMemoryStart & 0xFFFF) || PICkitFunctions.GetActiveFamily() != 3)
						{
							streamWriter.WriteLine(text17);
						}
						num2 += 16;
						num4 += num5;
					}
					while (num4 < FormPICkit2.TestMemoryWords);
				}
			}
			streamWriter.WriteLine(":00000001FF");
			streamWriter.Close();
			return true;
		}

		public static bool ExportBINFile(string filePath)
		{
			try
			{
				FileStream fileStream = File.Open(filePath, FileMode.Create);
				int progMemHexBytes = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemHexBytes;
				for (int i = 0; i < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem; i++)
				{
					for (int j = 0; j < progMemHexBytes; j++)
					{
						byte value = (byte)((PICkitFunctions.DeviceBuffers.ProgramMemory[i] >> 8 * j) & 0xFF);
						fileStream.WriteByte(value);
					}
				}
				fileStream.Close();
			}
			catch
			{
				return false;
			}
			return true;
		}

		private static byte computeChecksum(string fileLine)
		{
			int num = int.Parse(fileLine.Substring(1, 2), NumberStyles.HexNumber);
			if (fileLine.Length >= 9 + 2 * num)
			{
				int num2 = num;
				for (int i = 0; i < 3 + num; i++)
				{
					num2 += int.Parse(fileLine.Substring(3 + 2 * i, 2), NumberStyles.HexNumber);
				}
				num2 = -num2;
				return (byte)(num2 & 0xFF);
			}
			return 0;
		}
	}
}
