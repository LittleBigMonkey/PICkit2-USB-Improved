using System;
using System.IO;
using System.Text;

namespace PICkit2V2
{
	public class PICkitFunctions
	{
		private struct scriptRedirect
		{
			public byte redirectToScriptLocation;

			public int deviceFileScriptNumber;
		}

		public static string FirmwareVersion = "NA";

		public static string DeviceFileVersion = "NA";

		public static DeviceFile DevFile = new DeviceFile();

		public static DeviceData DeviceBuffers;

		public static byte[] Usb_write_array = new byte[65];

		public static byte[] Usb_read_array = new byte[65];

		public static int ActivePart = 0;

		public static uint LastDeviceID = 0u;

		public static int LastDeviceRev = 0;

		public static bool LearnMode = false;

		public static byte LastICSPSpeed = 0;

		private static IntPtr usbReadHandle = IntPtr.Zero;

		private static IntPtr usbWriteHandle = IntPtr.Zero;

		private static ushort lastPk2number = 255;

		private static int[] familySearchTable;

		private static bool vddOn = false;

		private static float vddLastSet = 3.3f;

		private static bool targetSelfPowered = false;

		private static bool fastProgramming = true;

		private static bool assertMCLR = false;

		private static bool vppFirstEnabled = false;

		private static bool lvpEnabled = false;

		private static uint scriptBufferChecksum = 0u;

		private static int lastFoundPart = 0;

		private static scriptRedirect[] scriptRedirectTable = new scriptRedirect[32];

		public static void TestingMethod()
		{
		}

		public static bool CheckComm()
		{
			if (writeUSB(new byte[17]
			{
				167,
				168,
				8,
				1,
				2,
				3,
				4,
				5,
				6,
				7,
				8,
				185,
				0,
				1,
				170,
				167,
				169
			}) && readUSB() && Usb_read_array[1] == 63)
			{
				for (int i = 1; i < 9; i++)
				{
					if (Usb_read_array[1 + i] != i)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		public static bool EnterLearnMode(byte memsize)
		{
			if (writeUSB(new byte[5]
			{
				181,
				80,
				75,
				50,
				memsize
			}))
			{
				LearnMode = true;
				float vpp = DevFile.Families[GetActiveFamily()].Vpp;
				if (vpp < 1f || (lvpEnabled && DevFile.PartsList[ActivePart].LVPScript > 0))
				{
					if (lvpEnabled && DevFile.PartsList[ActivePart].LVPScript > 0)
					{
						string scriptName = DevFile.Scripts[DevFile.PartsList[ActivePart].LVPScript - 1].ScriptName;
						scriptName = scriptName.Substring(scriptName.Length - 2);
						if (scriptName == "HV")
						{
							vpp = (float)(int)DevFile.Scripts[DevFile.PartsList[ActivePart].LVPScript - 1].Script[1] / 10f;
							SetVppVoltage(vpp, 0.7f);
						}
						else
						{
							SetVppVoltage(vddLastSet, 0.7f);
						}
					}
					else
					{
						SetVppVoltage(vddLastSet, 0.7f);
					}
				}
				else
				{
					SetVppVoltage(vpp, 0.7f);
				}
				downloadPartScripts(GetActiveFamily());
				return true;
			}
			return false;
		}

		public static bool ExitLearnMode()
		{
			LearnMode = false;
			return writeUSB(new byte[1]
			{
				182
			});
		}

		public static bool EnablePK2GoMode(byte memsize)
		{
			LearnMode = false;
			return writeUSB(new byte[5]
			{
				183,
				80,
				75,
				50,
				memsize
			});
		}

		public static bool MetaCmd_CHECK_DEVICE_ID()
		{
			int num = (int)DevFile.Families[GetActiveFamily()].DeviceIDMask;
			int num2 = (int)DevFile.PartsList[ActivePart].DeviceID;
			if (DevFile.Families[GetActiveFamily()].ProgMemShift != 0)
			{
				num <<= 1;
				num2 <<= 1;
			}
			return writeUSB(new byte[5]
			{
				132,
				(byte)(num & 0xFF),
				(byte)((num >> 8) & 0xFF),
				(byte)(num2 & 0xFF),
				(byte)((num2 >> 8) & 0xFF)
			});
		}

		public static bool MetaCmd_READ_BANDGAP()
		{
			return writeUSB(new byte[1]
			{
				133
			});
		}

		public static bool MetaCmd_WRITE_CFG_BANDGAP()
		{
			return writeUSB(new byte[1]
			{
				134
			});
		}

		public static bool MetaCmd_READ_OSCCAL()
		{
			int num = (int)(DevFile.PartsList[ActivePart].ProgramMem - 1);
			return writeUSB(new byte[3]
			{
				128,
				(byte)(num & 0xFF),
				(byte)((num >> 8) & 0xFF)
			});
		}

		public static bool MetaCmd_WRITE_OSCCAL()
		{
			int num = (int)(DevFile.PartsList[ActivePart].ProgramMem - 1);
			return writeUSB(new byte[3]
			{
				129,
				(byte)(num & 0xFF),
				(byte)((num >> 8) & 0xFF)
			});
		}

		public static bool MetaCmd_START_CHECKSUM()
		{
			return writeUSB(new byte[3]
			{
				130,
				DevFile.Families[GetActiveFamily()].ProgMemShift,
				0
			});
		}

		public static bool MetaCmd_CHANGE_CHKSM_FRMT(byte format)
		{
			return writeUSB(new byte[3]
			{
				135,
				format,
				0
			});
		}

		public static bool MetaCmd_VERIFY_CHECKSUM(uint checksum)
		{
			checksum = ~checksum;
			return writeUSB(new byte[3]
			{
				131,
				(byte)(checksum & 0xFF),
				(byte)((checksum >> 8) & 0xFF)
			});
		}

		public static void ResetPk2Number()
		{
			lastPk2number = 255;
		}

		public static float MeasurePGDPulse()
		{
			if (writeUSB(new byte[13]
			{
				169,
				166,
				9,
				243,
				2,
				232,
				20,
				243,
				6,
				191,
				243,
				3,
				170
			}) && readUSB() && Usb_read_array[1] == 2)
			{
				float num = Usb_read_array[2] + Usb_read_array[3] * 256;
				return num * 0.021333f;
			}
			return 0f;
		}

		public static bool EnterUARTMode(uint baudValue)
		{
			return writeUSB(new byte[5]
			{
				167,
				169,
				179,
				(byte)(baudValue & 0xFF),
				(byte)((baudValue >> 8) & 0xFF)
			});
		}

		public static bool ExitUARTMode()
		{
			return writeUSB(new byte[3]
			{
				180,
				167,
				169
			});
		}

		public static bool ValidateOSSCAL()
		{
			uint oSCCAL = DeviceBuffers.OSCCAL;
			oSCCAL &= 0xFF00;
			if (oSCCAL != 0 && oSCCAL == DevFile.PartsList[ActivePart].ConfigMasks[7])
			{
				return true;
			}
			return false;
		}

		public static bool isCalibrated()
		{
			if (writeUSB(new byte[3]
			{
				178,
				0,
				4
			}) && readUSB())
			{
				int num = Usb_read_array[1] + Usb_read_array[2] * 256;
				if (num <= 320 && num >= 192)
				{
					if (Usb_read_array[1] == 0 && Usb_read_array[2] == 1 && Usb_read_array[3] == 0 && Usb_read_array[4] == 128)
					{
						return false;
					}
					return true;
				}
			}
			return false;
		}

		public static string UnitIDRead()
		{
			string result = "";
			if (writeUSB(new byte[3]
			{
				178,
				240,
				16
			}) && readUSB() && Usb_read_array[1] == 35)
			{
				int i;
				for (i = 0; i < 15 && Usb_read_array[2 + i] != 0; i++)
				{
				}
				byte[] array = new byte[i];
				Array.Copy(Usb_read_array, 2, array, 0, i);
				char[] array2 = new char[Encoding.ASCII.GetCharCount(array, 0, array.Length)];
				Encoding.ASCII.GetChars(array, 0, array.Length, array2, 0);
				string text = new string(array2);
				result = text;
			}
			return result;
		}

		public static bool UnitIDWrite(string unitID)
		{
			int num = unitID.Length;
			if (num > 15)
			{
				num = 15;
			}
			byte[] array = new byte[19]
			{
				177,
				240,
				16,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			byte[] bytes = Encoding.Unicode.GetBytes(unitID);
			byte[] array2 = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, bytes);
			if (num > 0)
			{
				array[3] = 35;
			}
			else
			{
				array[3] = byte.MaxValue;
			}
			for (int i = 0; i < 15; i++)
			{
				if (i < num)
				{
					array[4 + i] = array2[i];
				}
				else
				{
					array[4 + i] = 0;
				}
			}
			return writeUSB(array);
		}

		public static bool SetVoltageCals(ushort adcCal, byte vddOffset, byte VddCal)
		{
			return writeUSB(new byte[5]
			{
				176,
				(byte)adcCal,
				(byte)(adcCal >> 8),
				vddOffset,
				VddCal
			});
		}

		public static bool HCS360_361_VppSpecial()
		{
			if (DevFile.PartsList[ActivePart].DeviceID != 4294967094u)
			{
				return true;
			}
			byte[] array = new byte[12]
			{
				166,
				10,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			};
			if ((DeviceBuffers.ProgramMemory[0] & 1) == 0)
			{
				array[2] = 243;
				array[3] = 4;
				array[4] = 247;
				array[5] = 250;
				array[6] = 232;
				array[7] = 5;
				array[8] = 243;
				array[9] = 4;
				array[10] = 243;
				array[11] = 0;
			}
			else
			{
				array[2] = 243;
				array[3] = 4;
				array[4] = 246;
				array[5] = 251;
				array[6] = 232;
				array[7] = 5;
				array[8] = 243;
				array[9] = 12;
				array[10] = 243;
				array[11] = 8;
			}
			return writeUSB(array);
		}

		public static bool FamilyIsEEPROM()
		{
			int num = DevFile.Families[GetActiveFamily()].FamilyName.Length;
			if (num > 6)
			{
				num = 6;
			}
			return DevFile.Families[GetActiveFamily()].FamilyName.Substring(0, num) == "EEPROM";
		}

		public static bool FamilyIsKeeloq()
		{
			return DevFile.Families[GetActiveFamily()].FamilyName == "KEELOQ® HCS";
		}

		public static bool FamilyIsMCP()
		{
			int num = DevFile.Families[GetActiveFamily()].FamilyName.Length;
			if (num > 3)
			{
				num = 3;
			}
			return DevFile.Families[GetActiveFamily()].FamilyName.Substring(0, num) == "MCP";
		}

		public static bool FamilyIsPIC32()
		{
			int num = DevFile.Families[GetActiveFamily()].FamilyName.Length;
			if (num > 5)
			{
				num = 5;
			}
			return DevFile.Families[GetActiveFamily()].FamilyName.Substring(0, num) == "PIC32";
		}

		public static bool FamilyIsdsPIC30()
		{
			int num = DevFile.Families[GetActiveFamily()].FamilyName.Length;
			if (num > 7)
			{
				num = 7;
			}
			return DevFile.Families[GetActiveFamily()].FamilyName.Substring(0, num) == "dsPIC30";
		}

		public static bool FamilyIsdsPIC30SMPS()
		{
			int num = DevFile.Families[GetActiveFamily()].FamilyName.Length;
			if (num > 9)
			{
				num = 9;
			}
			return DevFile.Families[GetActiveFamily()].FamilyName.Substring(0, num) == "dsPIC30 S";
		}

		public static bool FamilyIsPIC18J()
		{
			int num = DevFile.Families[GetActiveFamily()].FamilyName.Length;
			if (num > 9)
			{
				num = 9;
			}
			return DevFile.Families[GetActiveFamily()].FamilyName.Substring(0, num) == "PIC18F_J_";
		}

		public static bool FamilyIsPIC24FJ()
		{
			int num = DevFile.PartsList[ActivePart].PartName.Length;
			if (num > 7)
			{
				num = 7;
			}
			return DevFile.PartsList[ActivePart].PartName.Substring(0, num) == "PIC24FJ";
		}

		public static bool FamilyIsPIC24H()
		{
			int num = DevFile.PartsList[ActivePart].PartName.Length;
			if (num > 6)
			{
				num = 6;
			}
			return DevFile.PartsList[ActivePart].PartName.Substring(0, num) == "PIC24H";
		}

		public static bool FamilyIsdsPIC33F()
		{
			int num = DevFile.PartsList[ActivePart].PartName.Length;
			if (num > 8)
			{
				num = 8;
			}
			return DevFile.PartsList[ActivePart].PartName.Substring(0, num) == "dsPIC33F";
		}

		public static void SetVPPFirstProgramEntry()
		{
			vppFirstEnabled = true;
			scriptBufferChecksum = ~scriptBufferChecksum;
		}

		public static void ClearVppFirstProgramEntry()
		{
			vppFirstEnabled = false;
			scriptBufferChecksum = ~scriptBufferChecksum;
		}

		public static void SetLVPProgramEntry()
		{
			lvpEnabled = true;
			scriptBufferChecksum = ~scriptBufferChecksum;
		}

		public static void ClearLVPProgramEntry()
		{
			lvpEnabled = false;
			scriptBufferChecksum = ~scriptBufferChecksum;
		}

		public static void RowEraseDevice()
		{
			int num = (int)DevFile.PartsList[ActivePart].ProgramMem / (int)DevFile.PartsList[ActivePart].DebugRowEraseSize;
			RunScript(0, 1);
			if (DevFile.PartsList[ActivePart].ProgMemWrPrepScript != 0)
			{
				DownloadAddress3(0);
				RunScript(6, 1);
			}
			do
			{
				if (num >= 256)
				{
					RunScript(26, 0);
					num -= 256;
				}
				else
				{
					RunScript(26, num);
					num = 0;
				}
			}
			while (num > 0);
			RunScript(1, 1);
			if (DevFile.PartsList[ActivePart].EERowEraseScript > 0)
			{
				int num2 = (int)DevFile.PartsList[ActivePart].EEMem / (int)DevFile.PartsList[ActivePart].EERowEraseWords;
				RunScript(0, 1);
				if (DevFile.PartsList[ActivePart].EERdPrepScript != 0)
				{
					DownloadAddress3((int)DevFile.PartsList[ActivePart].EEAddr / (int)DevFile.Families[GetActiveFamily()].EEMemBytesPerWord);
					RunScript(8, 1);
				}
				do
				{
					if (num2 >= 256)
					{
						RunScript(28, 0);
						num2 -= 256;
					}
					else
					{
						RunScript(28, num2);
						num2 = 0;
					}
				}
				while (num2 > 0);
				RunScript(1, 1);
			}
			if (DevFile.PartsList[ActivePart].ConfigMemEraseScript > 0)
			{
				RunScript(0, 1);
				if (DevFile.PartsList[ActivePart].ProgMemWrPrepScript != 0)
				{
					DownloadAddress3((int)DevFile.PartsList[ActivePart].UserIDAddr);
					RunScript(6, 1);
				}
				ExecuteScript(DevFile.PartsList[ActivePart].ConfigMemEraseScript);
				RunScript(1, 1);
			}
		}

		public static bool ExecuteScript(int scriptArrayIndex)
		{
			if (scriptArrayIndex == 0)
			{
				return false;
			}
			int scriptLength = DevFile.Scripts[--scriptArrayIndex].ScriptLength;
			byte[] array = new byte[3 + scriptLength];
			array[0] = 169;
			array[1] = 166;
			array[2] = (byte)scriptLength;
			for (int i = 0; i < scriptLength; i++)
			{
				array[3 + i] = (byte)DevFile.Scripts[scriptArrayIndex].Script[i];
			}
			return writeUSB(array);
		}

		public static bool GetVDDState()
		{
			return vddOn;
		}

		public static bool SetMCLRTemp(bool nMCLR)
		{
			byte[] array = new byte[1];
			if (nMCLR)
			{
				array[0] = 247;
			}
			else
			{
				array[0] = 246;
			}
			return SendScript(array);
		}

		public static bool HoldMCLR(bool nMCLR)
		{
			assertMCLR = nMCLR;
			byte[] array = new byte[1];
			if (nMCLR)
			{
				array[0] = 247;
			}
			else
			{
				array[0] = 246;
			}
			return SendScript(array);
		}

		public static void SetFastProgramming(bool fast)
		{
			fastProgramming = fast;
			scriptBufferChecksum = ~scriptBufferChecksum;
		}

		public static void ForcePICkitPowered()
		{
			targetSelfPowered = false;
		}

		public static void ForceTargetPowered()
		{
			targetSelfPowered = true;
		}

		public static void ReadConfigOutsideProgMem()
		{
			RunScript(0, 1);
			RunScript(13, 1);
			UploadData();
			RunScript(1, 1);
			int configWords = DevFile.PartsList[ActivePart].ConfigWords;
			int num = 2;
			for (int i = 0; i < configWords; i++)
			{
				uint num2 = Usb_read_array[num++];
				num2 = (uint)((int)num2 | (Usb_read_array[num++] << 8));
				if (DevFile.Families[GetActiveFamily()].ProgMemShift > 0)
				{
					num2 = ((num2 >> 1) & DevFile.Families[GetActiveFamily()].BlankValue);
				}
				DeviceBuffers.ConfigWords[i] = num2;
			}
		}

		public static void ReadBandGap()
		{
			RunScript(0, 1);
			RunScript(13, 1);
			UploadData();
			RunScript(1, 1);
			_ = DevFile.PartsList[ActivePart].ConfigWords;
			uint num = Usb_read_array[2];
			num = (uint)((int)num | (Usb_read_array[3] << 8));
			if (DevFile.Families[GetActiveFamily()].ProgMemShift > 0)
			{
				num = ((num >> 1) & DevFile.Families[GetActiveFamily()].BlankValue);
			}
			DeviceBuffers.BandGap = (num & DevFile.PartsList[ActivePart].BandGapMask);
		}

		public static uint WriteConfigOutsideProgMem(bool codeProtect, bool dataProtect)
		{
			int configWords = DevFile.PartsList[ActivePart].ConfigWords;
			uint num = 0u;
			byte[] array = new byte[configWords * 2];
			if (DevFile.PartsList[ActivePart].BandGapMask != 0)
			{
				DeviceBuffers.ConfigWords[0] &= ~DevFile.PartsList[ActivePart].BandGapMask;
				if (!LearnMode)
				{
					DeviceBuffers.ConfigWords[0] |= DeviceBuffers.BandGap;
				}
			}
			if (FamilyIsMCP())
			{
				DeviceBuffers.ConfigWords[0] |= 16376u;
			}
			RunScript(0, 1);
			if (DevFile.PartsList[ActivePart].ConfigWrPrepScript > 0)
			{
				DownloadAddress3(0);
				RunScript(14, 1);
			}
			int i = 0;
			int num2 = 0;
			for (; i < configWords; i++)
			{
				uint num3 = DeviceBuffers.ConfigWords[i] & DevFile.PartsList[ActivePart].ConfigMasks[i];
				if (i == DevFile.PartsList[ActivePart].CPConfig - 1)
				{
					if (codeProtect)
					{
						num3 = (uint)((int)num3 & ~DevFile.PartsList[ActivePart].CPMask);
					}
					if (dataProtect)
					{
						num3 = (uint)((int)num3 & ~DevFile.PartsList[ActivePart].DPMask);
					}
				}
				if (DevFile.Families[GetActiveFamily()].ProgMemShift > 0)
				{
					num3 = (uint)((int)num3 | (~DevFile.PartsList[ActivePart].ConfigMasks[i] & (int)(~DevFile.PartsList[ActivePart].BandGapMask)));
					if (!FamilyIsMCP())
					{
						num3 &= DevFile.Families[GetActiveFamily()].BlankValue;
					}
					num3 <<= 1;
				}
				array[num2++] = (byte)(num3 & 0xFF);
				array[num2++] = (byte)((num3 >> 8) & 0xFF);
				num += (byte)(num3 & 0xFF);
				num += (byte)((num3 >> 8) & 0xFF);
			}
			DataClrAndDownload(array, 0);
			if (LearnMode && DevFile.PartsList[ActivePart].BandGapMask != 0)
			{
				MetaCmd_WRITE_CFG_BANDGAP();
			}
			else
			{
				RunScript(15, 1);
			}
			RunScript(1, 1);
			return num;
		}

		public static bool ReadOSSCAL()
		{
			if (RunScript(0, 1) && DownloadAddress3((int)(DevFile.PartsList[ActivePart].ProgramMem - 1)) && RunScript(20, 1) && UploadData() && RunScript(1, 1))
			{
				DeviceBuffers.OSCCAL = (uint)(Usb_read_array[2] + Usb_read_array[3] * 256);
				if (DevFile.Families[GetActiveFamily()].ProgMemShift > 0)
				{
					DeviceBuffers.OSCCAL >>= 1;
				}
				DeviceBuffers.OSCCAL &= DevFile.Families[GetActiveFamily()].BlankValue;
				return true;
			}
			return false;
		}

		public static bool WriteOSSCAL()
		{
			if (RunScript(0, 1))
			{
				uint num = DeviceBuffers.OSCCAL;
				uint num2 = DevFile.PartsList[ActivePart].ProgramMem - 1;
				if (DevFile.Families[GetActiveFamily()].ProgMemShift > 0)
				{
					num <<= 1;
				}
				DataClrAndDownload(new byte[5]
				{
					(byte)(num2 & 0xFF),
					(byte)((num2 >> 8) & 0xFF),
					(byte)((num2 >> 16) & 0xFF),
					(byte)(num & 0xFF),
					(byte)((num >> 8) & 0xFF)
				}, 0);
				if (RunScript(21, 1) && RunScript(1, 1))
				{
					return true;
				}
			}
			return false;
		}

		public static Constants.PICkit2PWR CheckTargetPower(ref float vdd, ref float vpp)
		{
			if (vddOn)
			{
				return Constants.PICkit2PWR.vdd_on;
			}
			if (ReadPICkitVoltages(ref vdd, ref vpp))
			{
				if (vdd > 2.3f)
				{
					targetSelfPowered = true;
					SetVDDVoltage(vdd, 0.85f);
					return Constants.PICkit2PWR.selfpowered;
				}
				targetSelfPowered = false;
				return Constants.PICkit2PWR.unpowered;
			}
			targetSelfPowered = false;
			return Constants.PICkit2PWR.no_response;
		}

		public static int GetActiveFamily()
		{
			return DevFile.PartsList[ActivePart].Family;
		}

		public static void SetActiveFamily(int family)
		{
			ActivePart = 0;
			lastFoundPart = 0;
			DevFile.PartsList[ActivePart].Family = (ushort)family;
			ResetBuffers();
		}

		public static bool SetVDDVoltage(float voltage, float threshold)
		{
			if (voltage < 2.5f)
			{
				voltage = 2.5f;
			}
			vddLastSet = voltage;
			ushort num = CalculateVddCPP(voltage);
			byte b = (byte)(threshold * voltage / 5f * 255f);
			if (b > 210)
			{
				b = 210;
			}
			return writeUSB(new byte[4]
			{
				160,
				(byte)(num & 0xFF),
				(byte)((int)num / 256),
				b
			});
		}

		public static ushort CalculateVddCPP(float voltage)
		{
			ushort num = (ushort)(voltage * 32f + 10.5f);
			return (ushort)(num << 6);
		}

		public static bool VddOn()
		{
			byte[] array = new byte[4]
			{
				166,
				2,
				252,
				0
			};
			if (targetSelfPowered)
			{
				array[3] = 254;
			}
			else
			{
				array[3] = byte.MaxValue;
			}
			bool flag = writeUSB(array);
			if (flag)
			{
				vddOn = true;
				return true;
			}
			return flag;
		}

		public static bool VddOff()
		{
			byte[] array = new byte[4]
			{
				166,
				2,
				254,
				0
			};
			if (targetSelfPowered)
			{
				array[3] = 252;
			}
			else
			{
				array[3] = 253;
			}
			bool flag = writeUSB(array);
			if (flag)
			{
				vddOn = false;
				return true;
			}
			return flag;
		}

		public static bool SetProgrammingSpeed(byte speed)
		{
			LastICSPSpeed = speed;
			return writeUSB(new byte[4]
			{
				166,
				2,
				234,
				speed
			});
		}

		public static bool ResetPICkit2()
		{
			return writeUSB(new byte[1]
			{
				174
			});
		}

		public static bool EnterBootloader()
		{
			return writeUSB(new byte[1]
			{
				66
			});
		}

		public static bool VerifyBootloaderMode()
		{
			if (writeUSB(new byte[1]
			{
				118
			}))
			{
				if (readUSB())
				{
					if (Usb_read_array[1] == 118)
					{
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		public static bool BL_EraseFlash()
		{
			byte[] array = new byte[5]
			{
				3,
				192,
				0,
				32,
				0
			};
			if (writeUSB(array))
			{
				array[3] = 80;
				return writeUSB(array);
			}
			return false;
		}

		public static bool BL_WriteFlash(byte[] payload)
		{
			byte[] array = new byte[37];
			array[0] = 2;
			array[1] = 32;
			for (int i = 0; i < 35; i++)
			{
				array[2 + i] = payload[i];
			}
			return writeUSB(array);
		}

		public static bool BL_WriteFWLoadedKey()
		{
			byte[] array = new byte[35];
			array[0] = 224;
			array[1] = 127;
			array[2] = 0;
			for (int i = 3; i < array.Length; i++)
			{
				array[i] = byte.MaxValue;
			}
			array[array.Length - 2] = 85;
			array[array.Length - 1] = 85;
			return BL_WriteFlash(array);
		}

		public static bool BL_ReadFlash16(int address)
		{
			if (writeUSB(new byte[5]
			{
				1,
				16,
				(byte)(address & 0xFF),
				(byte)((address >> 8) & 0xFF),
				0
			}))
			{
				return readUSB();
			}
			return false;
		}

		public static bool BL_Reset()
		{
			return writeUSB(new byte[1]
			{
				255
			});
		}

		public static bool ButtonPressed()
		{
			ushort num = readPkStatus();
			if ((num & 0x40) == 64)
			{
				return true;
			}
			return false;
		}

		public static bool BusErrorCheck()
		{
			ushort num = readPkStatus();
			if ((num & 0x400) == 1024)
			{
				return true;
			}
			writeUSB(new byte[3]
			{
				166,
				1,
				245
			});
			return false;
		}

		public static Constants.PICkit2PWR PowerStatus()
		{
			ushort num = readPkStatus();
			if (num == ushort.MaxValue)
			{
				return Constants.PICkit2PWR.no_response;
			}
			if ((num & 0x30) == 48)
			{
				vddOn = false;
				return Constants.PICkit2PWR.vddvpperrors;
			}
			if ((num & 0x20) == 32)
			{
				vddOn = false;
				return Constants.PICkit2PWR.vpperror;
			}
			if ((num & 0x10) == 16)
			{
				vddOn = false;
				return Constants.PICkit2PWR.vdderror;
			}
			if ((num & 2) == 2)
			{
				vddOn = true;
				return Constants.PICkit2PWR.vdd_on;
			}
			vddOn = false;
			return Constants.PICkit2PWR.vdd_off;
		}

		public static void DisconnectPICkit2Unit()
		{
			if (usbWriteHandle != IntPtr.Zero)
			{
				USB.CloseHandle(usbWriteHandle);
			}
			if (usbReadHandle != IntPtr.Zero)
			{
				USB.CloseHandle(usbReadHandle);
			}
			usbReadHandle = IntPtr.Zero;
			usbWriteHandle = IntPtr.Zero;
		}

		public static string GetSerialUnitID()
		{
			return USB.UnitID;
		}

		public static Constants.PICkit2USB DetectPICkit2Device(ushort pk2ID, bool readFW)
		{
			IntPtr p_ReadHandle = IntPtr.Zero;
			IntPtr p_WriteHandle = IntPtr.Zero;
			DisconnectPICkit2Unit();
			bool flag = USB.Find_This_Device(1240, 51, pk2ID, ref p_ReadHandle, ref p_WriteHandle);
			lastPk2number = pk2ID;
			usbReadHandle = p_ReadHandle;
			usbWriteHandle = p_WriteHandle;
			if (flag && !readFW)
			{
				return Constants.PICkit2USB.found;
			}
			if (flag)
			{
				if (writeUSB(new byte[1]
				{
					118
				}))
				{
					if (readUSB())
					{
						FirmwareVersion = $"{Usb_read_array[1]:D1}.{Usb_read_array[2]:D2}.{Usb_read_array[3]:D2}";
						if (Usb_read_array[1] == 2 && ((Usb_read_array[2] == 32 && Usb_read_array[3] >= 0) || Usb_read_array[2] > 32))
						{
							return Constants.PICkit2USB.found;
						}
						if (Usb_read_array[1] == 118)
						{
							FirmwareVersion = $"BL {Usb_read_array[7]:D1}.{Usb_read_array[8]:D1}";
							return Constants.PICkit2USB.bootloader;
						}
						return Constants.PICkit2USB.firmwareInvalid;
					}
					return Constants.PICkit2USB.readError;
				}
				return Constants.PICkit2USB.writeError;
			}
			return Constants.PICkit2USB.notFound;
		}

		public static bool ReadDeviceFile(string DeviceFileName)
		{
			if (File.Exists(DeviceFileName))
			{
				try
				{
					FileStream fileStream = File.OpenRead(DeviceFileName);
					using (BinaryReader binaryReader = new BinaryReader(fileStream))
					{
						DevFile.Info.VersionMajor = binaryReader.ReadInt32();
						DevFile.Info.VersionMinor = binaryReader.ReadInt32();
						DevFile.Info.VersionDot = binaryReader.ReadInt32();
						DevFile.Info.VersionNotes = binaryReader.ReadString();
						DevFile.Info.NumberFamilies = binaryReader.ReadInt32();
						DevFile.Info.NumberParts = binaryReader.ReadInt32();
						DevFile.Info.NumberScripts = binaryReader.ReadInt32();
						DevFile.Info.Compatibility = binaryReader.ReadByte();
						DevFile.Info.UNUSED1A = binaryReader.ReadByte();
						DevFile.Info.UNUSED1B = binaryReader.ReadUInt16();
						DevFile.Info.UNUSED2 = binaryReader.ReadUInt32();
						DeviceFileVersion = $"{DevFile.Info.VersionMajor:D1}.{DevFile.Info.VersionMinor:D2}.{DevFile.Info.VersionDot:D2}";
						DevFile.Families = new DeviceFile.DeviceFamilyParams[DevFile.Info.NumberFamilies];
						DevFile.PartsList = new DeviceFile.DevicePartParams[DevFile.Info.NumberParts];
						DevFile.Scripts = new DeviceFile.DeviceScripts[DevFile.Info.NumberScripts];
						for (int i = 0; i < DevFile.Info.NumberFamilies; i++)
						{
							DevFile.Families[i].FamilyID = binaryReader.ReadUInt16();
							DevFile.Families[i].FamilyType = binaryReader.ReadUInt16();
							DevFile.Families[i].SearchPriority = binaryReader.ReadUInt16();
							DevFile.Families[i].FamilyName = binaryReader.ReadString();
							DevFile.Families[i].ProgEntryScript = binaryReader.ReadUInt16();
							DevFile.Families[i].ProgExitScript = binaryReader.ReadUInt16();
							DevFile.Families[i].ReadDevIDScript = binaryReader.ReadUInt16();
							DevFile.Families[i].DeviceIDMask = binaryReader.ReadUInt32();
							DevFile.Families[i].BlankValue = binaryReader.ReadUInt32();
							DevFile.Families[i].BytesPerLocation = binaryReader.ReadByte();
							DevFile.Families[i].AddressIncrement = binaryReader.ReadByte();
							DevFile.Families[i].PartDetect = binaryReader.ReadBoolean();
							DevFile.Families[i].ProgEntryVPPScript = binaryReader.ReadUInt16();
							DevFile.Families[i].UNUSED1 = binaryReader.ReadUInt16();
							DevFile.Families[i].EEMemBytesPerWord = binaryReader.ReadByte();
							DevFile.Families[i].EEMemAddressIncrement = binaryReader.ReadByte();
							DevFile.Families[i].UserIDHexBytes = binaryReader.ReadByte();
							DevFile.Families[i].UserIDBytes = binaryReader.ReadByte();
							DevFile.Families[i].ProgMemHexBytes = binaryReader.ReadByte();
							DevFile.Families[i].EEMemHexBytes = binaryReader.ReadByte();
							DevFile.Families[i].ProgMemShift = binaryReader.ReadByte();
							DevFile.Families[i].TestMemoryStart = binaryReader.ReadUInt32();
							DevFile.Families[i].TestMemoryLength = binaryReader.ReadUInt16();
							DevFile.Families[i].Vpp = binaryReader.ReadSingle();
						}
						familySearchTable = new int[DevFile.Info.NumberFamilies];
						for (int j = 0; j < DevFile.Info.NumberFamilies; j++)
						{
							familySearchTable[DevFile.Families[j].SearchPriority] = j;
						}
						for (int k = 0; k < DevFile.Info.NumberParts; k++)
						{
							DevFile.PartsList[k].PartName = binaryReader.ReadString();
							DevFile.PartsList[k].Family = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DeviceID = binaryReader.ReadUInt32();
							DevFile.PartsList[k].ProgramMem = binaryReader.ReadUInt32();
							DevFile.PartsList[k].EEMem = binaryReader.ReadUInt16();
							DevFile.PartsList[k].EEAddr = binaryReader.ReadUInt32();
							DevFile.PartsList[k].ConfigWords = binaryReader.ReadByte();
							DevFile.PartsList[k].ConfigAddr = binaryReader.ReadUInt32();
							DevFile.PartsList[k].UserIDWords = binaryReader.ReadByte();
							DevFile.PartsList[k].UserIDAddr = binaryReader.ReadUInt32();
							DevFile.PartsList[k].BandGapMask = binaryReader.ReadUInt32();
							DevFile.PartsList[k].ConfigMasks = new ushort[9];
							DevFile.PartsList[k].ConfigBlank = new ushort[9];
							for (int l = 0; l < 8; l++)
							{
								DevFile.PartsList[k].ConfigMasks[l] = binaryReader.ReadUInt16();
							}
							for (int m = 0; m < 8; m++)
							{
								DevFile.PartsList[k].ConfigBlank[m] = binaryReader.ReadUInt16();
							}
							DevFile.PartsList[k].CPMask = binaryReader.ReadUInt16();
							DevFile.PartsList[k].CPConfig = binaryReader.ReadByte();
							DevFile.PartsList[k].OSSCALSave = binaryReader.ReadBoolean();
							DevFile.PartsList[k].IgnoreAddress = binaryReader.ReadUInt32();
							DevFile.PartsList[k].VddMin = binaryReader.ReadSingle();
							DevFile.PartsList[k].VddMax = binaryReader.ReadSingle();
							DevFile.PartsList[k].VddErase = binaryReader.ReadSingle();
							DevFile.PartsList[k].CalibrationWords = binaryReader.ReadByte();
							DevFile.PartsList[k].ChipEraseScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ProgMemAddrSetScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ProgMemAddrBytes = binaryReader.ReadByte();
							DevFile.PartsList[k].ProgMemRdScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ProgMemRdWords = binaryReader.ReadUInt16();
							DevFile.PartsList[k].EERdPrepScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].EERdScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].EERdLocations = binaryReader.ReadUInt16();
							DevFile.PartsList[k].UserIDRdPrepScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].UserIDRdScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ConfigRdPrepScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ConfigRdScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ProgMemWrPrepScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ProgMemWrScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ProgMemWrWords = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ProgMemPanelBufs = binaryReader.ReadByte();
							DevFile.PartsList[k].ProgMemPanelOffset = binaryReader.ReadUInt32();
							DevFile.PartsList[k].EEWrPrepScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].EEWrScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].EEWrLocations = binaryReader.ReadUInt16();
							DevFile.PartsList[k].UserIDWrPrepScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].UserIDWrScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ConfigWrPrepScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ConfigWrScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].OSCCALRdScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].OSCCALWrScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DPMask = binaryReader.ReadUInt16();
							DevFile.PartsList[k].WriteCfgOnErase = binaryReader.ReadBoolean();
							DevFile.PartsList[k].BlankCheckSkipUsrIDs = binaryReader.ReadBoolean();
							DevFile.PartsList[k].IgnoreBytes = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ChipErasePrepScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].BootFlash = binaryReader.ReadUInt32();
							DevFile.PartsList[k].Config9Mask = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ConfigMasks[8] = DevFile.PartsList[k].Config9Mask;
							DevFile.PartsList[k].Config9Blank = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ConfigBlank[8] = DevFile.PartsList[k].Config9Blank;
							DevFile.PartsList[k].ProgMemEraseScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].EEMemEraseScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ConfigMemEraseScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].reserved1EraseScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].reserved2EraseScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].TestMemoryRdScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].TestMemoryRdWords = binaryReader.ReadUInt16();
							DevFile.PartsList[k].EERowEraseScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].EERowEraseWords = binaryReader.ReadUInt16();
							DevFile.PartsList[k].ExportToMPLAB = binaryReader.ReadBoolean();
							DevFile.PartsList[k].DebugHaltScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DebugRunScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DebugStatusScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DebugReadExecVerScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DebugSingleStepScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DebugBulkWrDataScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DebugBulkRdDataScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DebugWriteVectorScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DebugReadVectorScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DebugRowEraseScript = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DebugRowEraseSize = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DebugReserved5Script = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DebugReserved6Script = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DebugReserved7Script = binaryReader.ReadUInt16();
							DevFile.PartsList[k].DebugReserved8Script = binaryReader.ReadUInt16();
							DevFile.PartsList[k].LVPScript = binaryReader.ReadUInt16();
						}
						for (int n = 0; n < DevFile.Info.NumberScripts; n++)
						{
							DevFile.Scripts[n].ScriptNumber = binaryReader.ReadUInt16();
							DevFile.Scripts[n].ScriptName = binaryReader.ReadString();
							DevFile.Scripts[n].ScriptVersion = binaryReader.ReadUInt16();
							DevFile.Scripts[n].UNUSED1 = binaryReader.ReadUInt32();
							DevFile.Scripts[n].ScriptLength = binaryReader.ReadUInt16();
							DevFile.Scripts[n].Script = new ushort[DevFile.Scripts[n].ScriptLength];
							for (int num = 0; num < DevFile.Scripts[n].ScriptLength; num++)
							{
								DevFile.Scripts[n].Script[num] = binaryReader.ReadUInt16();
							}
							DevFile.Scripts[n].Comment = binaryReader.ReadString();
						}
						binaryReader.Close();
					}
					fileStream.Close();
				}
				catch
				{
					return false;
				}
				return true;
			}
			return false;
		}

		public static bool DetectDevice(int familyIndex, bool resetOnNotFound, bool keepVddOn)
		{
			if (familyIndex == 16777215)
			{
				if (!targetSelfPowered)
				{
					SetVDDVoltage(3.3f, 0.85f);
				}
				for (int i = 0; i < DevFile.Families.Length; i++)
				{
					if (DevFile.Families[familySearchTable[i]].PartDetect && searchDevice(familySearchTable[i], resetOnNoDevice: true, keepVddOn))
					{
						return true;
					}
				}
				return false;
			}
			SetVDDVoltage(vddLastSet, 0.85f);
			if (DevFile.Families[familyIndex].PartDetect)
			{
				if (searchDevice(familyIndex, resetOnNotFound, keepVddOn))
				{
					return true;
				}
				return false;
			}
			return true;
		}

		public static int FindLastUsedInBuffer(uint[] bufferToSearch, uint blankValue, int startIndex)
		{
			if (DevFile.Families[GetActiveFamily()].FamilyName != "KEELOQ® HCS")
			{
				for (int num = startIndex; num > 0; num--)
				{
					if (bufferToSearch[num] != blankValue)
					{
						return num;
					}
				}
				return 0;
			}
			return bufferToSearch.Length - 1;
		}

		public static bool RunScriptUploadNoLen(int script, int repetitions)
		{
			bool flag = writeUSB(new byte[5]
			{
				169,
				165,
				scriptRedirectTable[script].redirectToScriptLocation,
				(byte)repetitions,
				172
			});
			if (flag)
			{
				flag = readUSB();
			}
			return flag;
		}

		public static bool GetUpload()
		{
			return readUSB();
		}

		public static bool UploadData()
		{
			bool flag = writeUSB(new byte[1]
			{
				170
			});
			if (flag)
			{
				flag = readUSB();
			}
			return flag;
		}

		public static bool UploadDataNoLen()
		{
			bool flag = writeUSB(new byte[1]
			{
				172
			});
			if (flag)
			{
				flag = readUSB();
			}
			return flag;
		}

		public static bool RunScript(int script, int repetitions)
		{
			if (writeUSB(new byte[4]
			{
				169,
				165,
				scriptRedirectTable[script].redirectToScriptLocation,
				(byte)repetitions
			}))
			{
				if (script == 1 && !assertMCLR)
				{
					return HoldMCLR(nMCLR: false);
				}
				return true;
			}
			return false;
		}

		public static int DataClrAndDownload(byte[] dataArray, int startIndex)
		{
			if (startIndex >= dataArray.Length)
			{
				return 0;
			}
			int num = dataArray.Length - startIndex;
			if (num > 61)
			{
				num = 61;
			}
			byte[] array = new byte[3 + num];
			array[0] = 167;
			array[1] = 168;
			array[2] = (byte)(num & 0xFF);
			for (int i = 0; i < num; i++)
			{
				array[3 + i] = dataArray[startIndex + i];
			}
			if (writeUSB(array))
			{
				return startIndex + num;
			}
			return 0;
		}

		public static int DataDownload(byte[] dataArray, int startIndex, int lastIndex)
		{
			if (startIndex >= lastIndex)
			{
				return 0;
			}
			int num = lastIndex - startIndex;
			if (num > 62)
			{
				num = 62;
			}
			byte[] array = new byte[2 + num];
			array[0] = 168;
			array[1] = (byte)(num & 0xFF);
			for (int i = 0; i < num; i++)
			{
				array[2 + i] = dataArray[startIndex + i];
			}
			if (writeUSB(array))
			{
				return startIndex + num;
			}
			return 0;
		}

		public static bool DownloadAddress3(int address)
		{
			return writeUSB(new byte[6]
			{
				167,
				168,
				3,
				(byte)(address & 0xFF),
				(byte)(0xFF & (address >> 8)),
				(byte)(0xFF & (address >> 16))
			});
		}

		public static bool DownloadAddress3MSBFirst(int address)
		{
			return writeUSB(new byte[6]
			{
				167,
				168,
				3,
				(byte)(0xFF & (address >> 16)),
				(byte)(0xFF & (address >> 8)),
				(byte)(address & 0xFF)
			});
		}

		public static bool Download3Multiples(int downloadBytes, int multiples, int increment)
		{
			byte b = 167;
			do
			{
				int num = multiples;
				if (multiples > 20)
				{
					num = 20;
					multiples -= 20;
				}
				else
				{
					multiples = 0;
				}
				byte[] array = new byte[3 * num + 3];
				array[0] = b;
				array[1] = 168;
				array[2] = (byte)(3 * num);
				for (int i = 0; i < num; i++)
				{
					array[3 + 3 * i] = (byte)(downloadBytes >> 16);
					array[4 + 3 * i] = (byte)(downloadBytes >> 8);
					array[5 + 3 * i] = (byte)downloadBytes;
					downloadBytes += increment;
				}
				if (!writeUSB(array))
				{
					return false;
				}
				b = 90;
			}
			while (multiples > 0);
			return true;
		}

		public static uint ComputeChecksum(bool codeProtectOn, bool dataProtectOn)
		{
			uint num = 0u;
			if (DevFile.Families[GetActiveFamily()].BlankValue < 65535)
			{
				int num2 = (int)DevFile.PartsList[ActivePart].ProgramMem;
				if (DevFile.PartsList[ActivePart].OSSCALSave)
				{
					num2--;
				}
				if (DevFile.PartsList[ActivePart].ConfigWords > 0 && ((DevFile.PartsList[ActivePart].CPMask & DeviceBuffers.ConfigWords[DevFile.PartsList[ActivePart].CPConfig - 1]) != DevFile.PartsList[ActivePart].CPMask || codeProtectOn))
				{
					num2 = ((DevFile.Families[GetActiveFamily()].BlankValue < 16383) ? 64 : 0);
				}
				for (int i = 0; i < num2; i++)
				{
					num += DeviceBuffers.ProgramMemory[i];
				}
				if (DevFile.PartsList[ActivePart].ConfigWords > 0)
				{
					if ((DevFile.PartsList[ActivePart].CPMask & DeviceBuffers.ConfigWords[DevFile.PartsList[ActivePart].CPConfig - 1]) != DevFile.PartsList[ActivePart].CPMask || codeProtectOn)
					{
						for (int j = 0; j < DevFile.PartsList[ActivePart].UserIDWords; j++)
						{
							int num3 = 1;
							for (int k = 0; k < j; k++)
							{
								num3 <<= 4;
							}
							num = (uint)((int)num + (int)((0xF & DeviceBuffers.UserIDs[DevFile.PartsList[ActivePart].UserIDWords - j - 1]) * num3));
						}
					}
					uint num4 = 0u;
					for (int l = 0; l < DevFile.PartsList[ActivePart].ConfigWords; l++)
					{
						if (l == DevFile.PartsList[ActivePart].CPConfig - 1)
						{
							num4 = (DeviceBuffers.ConfigWords[l] & DevFile.PartsList[ActivePart].ConfigMasks[l]);
							if (codeProtectOn)
							{
								num4 = (uint)((int)num4 & ~DevFile.PartsList[ActivePart].CPMask);
							}
							if (dataProtectOn)
							{
								num4 = (uint)((int)num4 & ~DevFile.PartsList[ActivePart].DPMask);
							}
							num += num4;
						}
						else
						{
							num += (DeviceBuffers.ConfigWords[l] & DevFile.PartsList[ActivePart].ConfigMasks[l]);
						}
					}
				}
				return num & 0xFFFF;
			}
			int num5 = (int)DevFile.PartsList[ActivePart].ConfigAddr / (int)DevFile.Families[GetActiveFamily()].ProgMemHexBytes;
			if (num5 > DevFile.PartsList[ActivePart].ProgramMem)
			{
				num5 = (int)DevFile.PartsList[ActivePart].ProgramMem;
			}
			for (int m = 0; m < num5; m++)
			{
				uint num6 = DeviceBuffers.ProgramMemory[m];
				num += (num6 & 0xFF);
				for (int n = 1; n < DevFile.Families[GetActiveFamily()].BytesPerLocation; n++)
				{
					num6 >>= 8;
					num += (num6 & 0xFF);
				}
			}
			if (DevFile.PartsList[ActivePart].ConfigWords > 0)
			{
				if ((DevFile.PartsList[ActivePart].CPMask & DeviceBuffers.ConfigWords[DevFile.PartsList[ActivePart].CPConfig - 1]) != DevFile.PartsList[ActivePart].CPMask || codeProtectOn)
				{
					num = 0u;
					for (int num7 = 0; num7 < DevFile.PartsList[ActivePart].UserIDWords; num7++)
					{
						uint num8 = DeviceBuffers.UserIDs[num7];
						num += (num8 & 0xFF);
						num += ((num8 >> 8) & 0xFF);
					}
				}
				for (int num9 = 0; num9 < DevFile.PartsList[ActivePart].ConfigWords; num9++)
				{
					uint num10 = DeviceBuffers.ConfigWords[num9] & DevFile.PartsList[ActivePart].ConfigMasks[num9];
					num += (num10 & 0xFF);
					num += ((num10 >> 8) & 0xFF);
				}
			}
			return num & 0xFFFF;
		}

		public static void ResetBuffers()
		{
			DeviceBuffers = new DeviceData(DevFile.PartsList[ActivePart].ProgramMem, DevFile.PartsList[ActivePart].EEMem, DevFile.PartsList[ActivePart].ConfigWords, DevFile.PartsList[ActivePart].UserIDWords, DevFile.Families[GetActiveFamily()].BlankValue, DevFile.Families[GetActiveFamily()].EEMemAddressIncrement, DevFile.Families[GetActiveFamily()].UserIDBytes, DevFile.PartsList[ActivePart].ConfigBlank, DevFile.PartsList[ActivePart].ConfigMasks[7]);
		}

		public static DeviceData CloneBuffers(DeviceData copyFrom)
		{
			DeviceData deviceData = new DeviceData(DevFile.PartsList[ActivePart].ProgramMem, DevFile.PartsList[ActivePart].EEMem, DevFile.PartsList[ActivePart].ConfigWords, DevFile.PartsList[ActivePart].UserIDWords, DevFile.Families[GetActiveFamily()].BlankValue, DevFile.Families[GetActiveFamily()].EEMemAddressIncrement, DevFile.Families[GetActiveFamily()].UserIDBytes, DevFile.PartsList[ActivePart].ConfigBlank, DevFile.PartsList[ActivePart].ConfigMasks[7]);
			for (int i = 0; i < copyFrom.ProgramMemory.Length; i++)
			{
				deviceData.ProgramMemory[i] = copyFrom.ProgramMemory[i];
			}
			for (int j = 0; j < copyFrom.EEPromMemory.Length; j++)
			{
				deviceData.EEPromMemory[j] = copyFrom.EEPromMemory[j];
			}
			for (int k = 0; k < copyFrom.ConfigWords.Length; k++)
			{
				deviceData.ConfigWords[k] = copyFrom.ConfigWords[k];
			}
			for (int l = 0; l < copyFrom.UserIDs.Length; l++)
			{
				deviceData.UserIDs[l] = copyFrom.UserIDs[l];
			}
			deviceData.OSCCAL = copyFrom.OSCCAL;
			deviceData.OSCCAL = copyFrom.BandGap;
			return deviceData;
		}

		public static void PrepNewPart(bool resetBuffers)
		{
			if (resetBuffers)
			{
				ResetBuffers();
			}
			float vpp = DevFile.Families[GetActiveFamily()].Vpp;
			if (vpp < 1f || (lvpEnabled && DevFile.PartsList[ActivePart].LVPScript > 0))
			{
				if (lvpEnabled && DevFile.PartsList[ActivePart].LVPScript > 0)
				{
					string scriptName = DevFile.Scripts[DevFile.PartsList[ActivePart].LVPScript - 1].ScriptName;
					scriptName = scriptName.Substring(scriptName.Length - 2);
					if (scriptName == "HV")
					{
						vpp = (float)(int)DevFile.Scripts[DevFile.PartsList[ActivePart].LVPScript - 1].Script[1] / 10f;
						SetVppVoltage(vpp, 0.7f);
					}
					else
					{
						SetVppVoltage(vddLastSet, 0.7f);
					}
				}
				else
				{
					SetVppVoltage(vddLastSet, 0.7f);
				}
			}
			else
			{
				SetVppVoltage(vpp, 0.7f);
			}
			downloadPartScripts(GetActiveFamily());
		}

		public static uint ReadDebugVector()
		{
			RunScript(0, 1);
			ExecuteScript(DevFile.PartsList[ActivePart].DebugReadVectorScript);
			UploadData();
			RunScript(1, 1);
			int num = 2;
			int num2 = 2;
			uint num3 = 0u;
			for (int i = 0; i < num; i++)
			{
				uint num4 = Usb_read_array[num2++];
				num4 = (uint)((int)num4 | (Usb_read_array[num2++] << 8));
				if (DevFile.Families[GetActiveFamily()].ProgMemShift > 0)
				{
					num4 = ((num4 >> 1) & DevFile.Families[GetActiveFamily()].BlankValue);
				}
				num3 = ((i != 0) ? (num3 + (num4 << 16)) : num4);
			}
			return num3;
		}

		public static void WriteDebugVector(uint debugWords)
		{
			int num = 2;
			byte[] array = new byte[4];
			RunScript(0, 1);
			int i = 0;
			int num2 = 0;
			for (; i < num; i++)
			{
				uint num3 = 0u;
				num3 = ((i != 0) ? (debugWords >> 16) : (debugWords & 0xFFFF));
				if (DevFile.Families[GetActiveFamily()].ProgMemShift > 0)
				{
					num3 <<= 1;
				}
				array[num2++] = (byte)(num3 & 0xFF);
				array[num2++] = (byte)((num3 >> 8) & 0xFF);
			}
			DataClrAndDownload(array, 0);
			ExecuteScript(DevFile.PartsList[ActivePart].DebugWriteVectorScript);
			RunScript(1, 1);
		}

		public static bool ReadPICkitVoltages(ref float vdd, ref float vpp)
		{
			if (writeUSB(new byte[1]
			{
				163
			}) && readUSB())
			{
				float num = Usb_read_array[2] * 256 + Usb_read_array[1];
				vdd = num / 65536f * 5f;
				num = Usb_read_array[4] * 256 + Usb_read_array[3];
				vpp = num / 65536f * 13.7f;
				return true;
			}
			return false;
		}

		public static bool SetVppVoltage(float voltage, float threshold)
		{
			byte b = 64;
			byte b2 = (byte)(voltage * 18.61f);
			byte b3 = (byte)(threshold * voltage * 18.61f);
			return writeUSB(new byte[4]
			{
				161,
				b,
				b2,
				b3
			});
		}

		public static bool SendScript(byte[] script)
		{
			int num = script.Length;
			byte[] array = new byte[2 + num];
			array[0] = 166;
			array[1] = (byte)num;
			for (int i = 0; i < num; i++)
			{
				array[2 + i] = script[i];
			}
			return writeUSB(array);
		}

		private static ushort readPkStatus()
		{
			if (writeUSB(new byte[1]
			{
				162
			}))
			{
				if (readUSB())
				{
					return (ushort)(Usb_read_array[2] * 256 + Usb_read_array[1]);
				}
				return ushort.MaxValue;
			}
			return ushort.MaxValue;
		}

		public static bool writeUSB(byte[] commandList)
		{
			int numBytesWritten = 0;
			Usb_write_array[0] = 0;
			for (int i = 1; i < Usb_write_array.Length; i++)
			{
				Usb_write_array[i] = 173;
			}
			Array.Copy(commandList, 0, Usb_write_array, 1, commandList.Length);
			bool result = USB.WriteFile(usbWriteHandle, Usb_write_array, Usb_write_array.Length, ref numBytesWritten, 0);
			if (numBytesWritten != Usb_write_array.Length)
			{
				return false;
			}
			return result;
		}

		public static bool readUSB()
		{
			int pNumberOfBytesRead = 0;
			if (LearnMode)
			{
				return true;
			}
			bool result = USB.ReadFile(usbReadHandle, Usb_read_array, Usb_read_array.Length, ref pNumberOfBytesRead, 0);
			if (pNumberOfBytesRead != Usb_read_array.Length)
			{
				return false;
			}
			return result;
		}

		public static bool VerifyDeviceID(bool resetOnNoDevice, bool keepVddOn)
		{
			float vpp = DevFile.Families[GetActiveFamily()].Vpp;
			if (vpp < 1f || (lvpEnabled && DevFile.PartsList[ActivePart].LVPScript > 0))
			{
				if (lvpEnabled && DevFile.PartsList[ActivePart].LVPScript > 0)
				{
					string scriptName = DevFile.Scripts[DevFile.PartsList[ActivePart].LVPScript - 1].ScriptName;
					scriptName = scriptName.Substring(scriptName.Length - 2);
					if (scriptName == "HV")
					{
						vpp = (float)(int)DevFile.Scripts[DevFile.PartsList[ActivePart].LVPScript - 1].Script[1] / 10f;
						SetVppVoltage(vpp, 0.7f);
					}
					else
					{
						SetVppVoltage(vddLastSet, 0.7f);
					}
				}
				else
				{
					SetVppVoltage(vddLastSet, 0.7f);
				}
			}
			else
			{
				SetVppVoltage(vpp, 0.7f);
			}
			SetMCLRTemp(nMCLR: true);
			VddOn();
			if (lvpEnabled && DevFile.PartsList[ActivePart].LVPScript > 0)
			{
				ExecuteScript(DevFile.PartsList[ActivePart].LVPScript);
			}
			else if (vppFirstEnabled && DevFile.Families[GetActiveFamily()].ProgEntryVPPScript > 0)
			{
				ExecuteScript(DevFile.Families[GetActiveFamily()].ProgEntryVPPScript);
			}
			else
			{
				ExecuteScript(DevFile.Families[GetActiveFamily()].ProgEntryScript);
			}
			ExecuteScript(DevFile.Families[GetActiveFamily()].ReadDevIDScript);
			UploadData();
			ExecuteScript(DevFile.Families[GetActiveFamily()].ProgExitScript);
			if (!keepVddOn)
			{
				VddOff();
			}
			if (!assertMCLR)
			{
				HoldMCLR(nMCLR: false);
			}
			uint num = (uint)(Usb_read_array[5] * 16777216 + Usb_read_array[4] * 65536 + Usb_read_array[3] * 256 + Usb_read_array[2]);
			for (int i = 0; i < DevFile.Families[GetActiveFamily()].ProgMemShift; i++)
			{
				num >>= 1;
			}
			if (Usb_read_array[1] == 4)
			{
				LastDeviceRev = Usb_read_array[5] * 256 + Usb_read_array[4];
				if (DevFile.Families[GetActiveFamily()].BlankValue == uint.MaxValue)
				{
					LastDeviceRev >>= 4;
				}
			}
			else
			{
				LastDeviceRev = (int)(num & ~DevFile.Families[GetActiveFamily()].DeviceIDMask);
			}
			LastDeviceRev &= 65535;
			LastDeviceRev &= (int)DevFile.Families[GetActiveFamily()].BlankValue;
			if ((LastDeviceID = (num & DevFile.Families[GetActiveFamily()].DeviceIDMask)) != DevFile.PartsList[ActivePart].DeviceID)
			{
				return false;
			}
			if (DevFile.PartsList[ActivePart].OSSCALSave)
			{
				VddOn();
				ReadOSSCAL();
			}
			if (DevFile.PartsList[ActivePart].BandGapMask != 0)
			{
				VddOn();
				ReadBandGap();
			}
			if (!keepVddOn)
			{
				VddOff();
			}
			return true;
		}

		private static bool searchDevice(int familyIndex, bool resetOnNoDevice, bool keepVddOn)
		{
			int activePart = ActivePart;
			if (ActivePart != 0)
			{
				lastFoundPart = ActivePart;
			}
			float vpp = DevFile.Families[familyIndex].Vpp;
			if (vpp < 1f || (lvpEnabled && DevFile.PartsList[ActivePart].LVPScript > 0))
			{
				if (lvpEnabled && DevFile.PartsList[ActivePart].LVPScript > 0)
				{
					string scriptName = DevFile.Scripts[DevFile.PartsList[ActivePart].LVPScript - 1].ScriptName;
					scriptName = scriptName.Substring(scriptName.Length - 2);
					if (scriptName == "HV")
					{
						vpp = (float)(int)DevFile.Scripts[DevFile.PartsList[ActivePart].LVPScript - 1].Script[1] / 10f;
						SetVppVoltage(vpp, 0.7f);
					}
					else
					{
						SetVppVoltage(vddLastSet, 0.7f);
					}
				}
				else
				{
					SetVppVoltage(vddLastSet, 0.7f);
				}
			}
			else
			{
				SetVppVoltage(vpp, 0.7f);
			}
			SetMCLRTemp(nMCLR: true);
			VddOn();
			if (lvpEnabled && DevFile.PartsList[ActivePart].LVPScript > 0)
			{
				ExecuteScript(DevFile.PartsList[ActivePart].LVPScript);
			}
			else if (vppFirstEnabled && DevFile.Families[familyIndex].ProgEntryVPPScript > 0)
			{
				ExecuteScript(DevFile.Families[familyIndex].ProgEntryVPPScript);
			}
			else
			{
				ExecuteScript(DevFile.Families[familyIndex].ProgEntryScript);
			}
			ExecuteScript(DevFile.Families[familyIndex].ReadDevIDScript);
			UploadData();
			ExecuteScript(DevFile.Families[familyIndex].ProgExitScript);
			if (!keepVddOn)
			{
				VddOff();
			}
			if (!assertMCLR)
			{
				HoldMCLR(nMCLR: false);
			}
			uint num = (uint)(Usb_read_array[5] * 16777216 + Usb_read_array[4] * 65536 + Usb_read_array[3] * 256 + Usb_read_array[2]);
			for (int i = 0; i < DevFile.Families[familyIndex].ProgMemShift; i++)
			{
				num >>= 1;
			}
			if (Usb_read_array[1] == 4)
			{
				LastDeviceRev = Usb_read_array[5] * 256 + Usb_read_array[4];
				if (DevFile.Families[familyIndex].BlankValue == uint.MaxValue)
				{
					LastDeviceRev >>= 4;
				}
			}
			else
			{
				LastDeviceRev = (int)(num & ~DevFile.Families[familyIndex].DeviceIDMask);
			}
			LastDeviceRev &= 65535;
			LastDeviceRev &= (int)DevFile.Families[familyIndex].BlankValue;
			num = (LastDeviceID = (num & DevFile.Families[familyIndex].DeviceIDMask));
			ActivePart = 0;
			for (int j = 0; j < DevFile.PartsList.Length; j++)
			{
				if (DevFile.PartsList[j].Family == familyIndex && DevFile.PartsList[j].DeviceID == num)
				{
					ActivePart = j;
					break;
				}
			}
			if (ActivePart == 0)
			{
				if (activePart != 0)
				{
					DevFile.PartsList[ActivePart] = DevFile.PartsList[activePart];
					DevFile.PartsList[ActivePart].DeviceID = 0u;
					DevFile.PartsList[ActivePart].PartName = "Unsupported Part";
				}
				if (resetOnNoDevice)
				{
					ResetBuffers();
				}
				return false;
			}
			if (ActivePart == lastFoundPart && scriptBufferChecksum != 0 && scriptBufferChecksum == getScriptBufferChecksum())
			{
				return true;
			}
			downloadPartScripts(familyIndex);
			if (ActivePart != lastFoundPart)
			{
				ResetBuffers();
			}
			if (DevFile.PartsList[ActivePart].OSSCALSave)
			{
				VddOn();
				ReadOSSCAL();
			}
			if (DevFile.PartsList[ActivePart].BandGapMask != 0)
			{
				VddOn();
				ReadBandGap();
			}
			if (!keepVddOn)
			{
				VddOff();
			}
			return true;
		}

		private static void downloadPartScripts(int familyIndex)
		{
			writeUSB(new byte[1]
			{
				171
			});
			for (int i = 0; i < scriptRedirectTable.Length; i++)
			{
				scriptRedirectTable[i].redirectToScriptLocation = 0;
				scriptRedirectTable[i].deviceFileScriptNumber = 0;
			}
			if (DevFile.Families[familyIndex].ProgEntryScript != 0)
			{
				if (lvpEnabled && DevFile.PartsList[ActivePart].LVPScript > 0)
				{
					downloadScript(0, DevFile.PartsList[ActivePart].LVPScript);
				}
				else if (vppFirstEnabled && DevFile.Families[familyIndex].ProgEntryVPPScript != 0)
				{
					downloadScript(0, DevFile.Families[familyIndex].ProgEntryVPPScript);
				}
				else
				{
					downloadScript(0, DevFile.Families[familyIndex].ProgEntryScript);
				}
			}
			if (DevFile.Families[familyIndex].ProgExitScript != 0)
			{
				downloadScript(1, DevFile.Families[familyIndex].ProgExitScript);
			}
			if (DevFile.Families[familyIndex].ReadDevIDScript != 0)
			{
				downloadScript(2, DevFile.Families[familyIndex].ReadDevIDScript);
			}
			if (DevFile.PartsList[ActivePart].ProgMemRdScript != 0)
			{
				downloadScript(3, DevFile.PartsList[ActivePart].ProgMemRdScript);
			}
			if (DevFile.PartsList[ActivePart].ChipErasePrepScript != 0)
			{
				downloadScript(4, DevFile.PartsList[ActivePart].ChipErasePrepScript);
			}
			if (DevFile.PartsList[ActivePart].ProgMemAddrSetScript != 0)
			{
				downloadScript(5, DevFile.PartsList[ActivePart].ProgMemAddrSetScript);
			}
			if (DevFile.PartsList[ActivePart].ProgMemWrPrepScript != 0)
			{
				downloadScript(6, DevFile.PartsList[ActivePart].ProgMemWrPrepScript);
			}
			if (DevFile.PartsList[ActivePart].ProgMemWrScript != 0)
			{
				downloadScript(7, DevFile.PartsList[ActivePart].ProgMemWrScript);
			}
			if (DevFile.PartsList[ActivePart].EERdPrepScript != 0)
			{
				downloadScript(8, DevFile.PartsList[ActivePart].EERdPrepScript);
			}
			if (DevFile.PartsList[ActivePart].EERdScript != 0)
			{
				downloadScript(9, DevFile.PartsList[ActivePart].EERdScript);
			}
			if (DevFile.PartsList[ActivePart].EEWrPrepScript != 0)
			{
				downloadScript(10, DevFile.PartsList[ActivePart].EEWrPrepScript);
			}
			if (DevFile.PartsList[ActivePart].EEWrScript != 0)
			{
				downloadScript(11, DevFile.PartsList[ActivePart].EEWrScript);
			}
			if (DevFile.PartsList[ActivePart].ConfigRdPrepScript != 0)
			{
				downloadScript(12, DevFile.PartsList[ActivePart].ConfigRdPrepScript);
			}
			if (DevFile.PartsList[ActivePart].ConfigRdScript != 0)
			{
				downloadScript(13, DevFile.PartsList[ActivePart].ConfigRdScript);
			}
			if (DevFile.PartsList[ActivePart].ConfigWrPrepScript != 0)
			{
				downloadScript(14, DevFile.PartsList[ActivePart].ConfigWrPrepScript);
			}
			if (DevFile.PartsList[ActivePart].ConfigWrScript != 0)
			{
				downloadScript(15, DevFile.PartsList[ActivePart].ConfigWrScript);
			}
			if (DevFile.PartsList[ActivePart].UserIDRdPrepScript != 0)
			{
				downloadScript(16, DevFile.PartsList[ActivePart].UserIDRdPrepScript);
			}
			if (DevFile.PartsList[ActivePart].UserIDRdScript != 0)
			{
				downloadScript(17, DevFile.PartsList[ActivePart].UserIDRdScript);
			}
			if (DevFile.PartsList[ActivePart].UserIDWrPrepScript != 0)
			{
				downloadScript(18, DevFile.PartsList[ActivePart].UserIDWrPrepScript);
			}
			if (DevFile.PartsList[ActivePart].UserIDWrScript != 0)
			{
				downloadScript(19, DevFile.PartsList[ActivePart].UserIDWrScript);
			}
			if (DevFile.PartsList[ActivePart].OSCCALRdScript != 0)
			{
				downloadScript(20, DevFile.PartsList[ActivePart].OSCCALRdScript);
			}
			if (DevFile.PartsList[ActivePart].OSCCALWrScript != 0)
			{
				downloadScript(21, DevFile.PartsList[ActivePart].OSCCALWrScript);
			}
			if (DevFile.PartsList[ActivePart].ChipEraseScript != 0)
			{
				downloadScript(22, DevFile.PartsList[ActivePart].ChipEraseScript);
			}
			if (DevFile.PartsList[ActivePart].ProgMemEraseScript != 0)
			{
				downloadScript(23, DevFile.PartsList[ActivePart].ProgMemEraseScript);
			}
			if (DevFile.PartsList[ActivePart].EEMemEraseScript != 0)
			{
				downloadScript(24, DevFile.PartsList[ActivePart].EEMemEraseScript);
			}
			if (DevFile.PartsList[ActivePart].DebugRowEraseScript != 0)
			{
				downloadScript(26, DevFile.PartsList[ActivePart].DebugRowEraseScript);
			}
			if (DevFile.PartsList[ActivePart].TestMemoryRdScript != 0)
			{
				downloadScript(27, DevFile.PartsList[ActivePart].TestMemoryRdScript);
			}
			if (DevFile.PartsList[ActivePart].EERowEraseScript != 0)
			{
				downloadScript(28, DevFile.PartsList[ActivePart].EERowEraseScript);
			}
			scriptBufferChecksum = getScriptBufferChecksum();
		}

		private static uint getScriptBufferChecksum()
		{
			if (LearnMode)
			{
				return 0u;
			}
			if (writeUSB(new byte[1]
			{
				175
			}))
			{
				if (readUSB())
				{
					uint num = Usb_read_array[4];
					num = (uint)((int)num + (Usb_read_array[3] << 8));
					num = (uint)((int)num + (Usb_read_array[2] << 16));
					return (uint)((int)num + (Usb_read_array[1] << 24));
				}
				return 0u;
			}
			return 0u;
		}

		private static bool downloadScript(byte scriptBufferLocation, int scriptArrayIndex)
		{
			byte b = scriptBufferLocation;
			for (byte b2 = 0; b2 < scriptRedirectTable.Length; b2 = (byte)(b2 + 1))
			{
				if (scriptArrayIndex == scriptRedirectTable[b2].deviceFileScriptNumber)
				{
					b = b2;
					break;
				}
			}
			scriptRedirectTable[scriptBufferLocation].redirectToScriptLocation = b;
			scriptRedirectTable[scriptBufferLocation].deviceFileScriptNumber = scriptArrayIndex;
			if (scriptBufferLocation != b)
			{
				return true;
			}
			int scriptLength = DevFile.Scripts[--scriptArrayIndex].ScriptLength;
			byte[] array = new byte[3 + scriptLength];
			array[0] = 164;
			array[1] = scriptBufferLocation;
			array[2] = (byte)scriptLength;
			for (int i = 0; i < scriptLength; i++)
			{
				ushort num = DevFile.Scripts[scriptArrayIndex].Script[i];
				if (fastProgramming)
				{
					array[3 + i] = (byte)num;
					continue;
				}
				switch (num)
				{
				case 43751:
				{
					ushort num3 = (ushort)(DevFile.Scripts[scriptArrayIndex].Script[i + 1] & 0xFF);
					if (num3 < 170 && num3 != 0)
					{
						array[3 + i++] = (byte)num;
						byte b4 = (byte)DevFile.Scripts[scriptArrayIndex].Script[i];
						array[3 + i] = (byte)(b4 + (int)b4 / 2);
					}
					else
					{
						array[3 + i++] = 232;
						array[3 + i] = 2;
					}
					break;
				}
				case 43752:
				{
					ushort num2 = (ushort)(DevFile.Scripts[scriptArrayIndex].Script[i + 1] & 0xFF);
					if (num2 < 171 && num2 != 0)
					{
						array[3 + i++] = (byte)num;
						byte b3 = (byte)DevFile.Scripts[scriptArrayIndex].Script[i];
						array[3 + i] = (byte)(b3 + (int)b3 / 2);
					}
					else
					{
						array[3 + i++] = 232;
						array[3 + i] = 0;
					}
					break;
				}
				default:
					array[3 + i] = (byte)num;
					break;
				}
			}
			return writeUSB(array);
		}
	}
}
