namespace PICkit2V2
{
	public class DeviceData
	{
		public uint[] ProgramMemory;

		public uint[] EEPromMemory;

		public uint[] ConfigWords;

		public uint[] UserIDs;

		public uint OSCCAL;

		public uint BandGap;

		public DeviceData(uint progMemSize, ushort eeMemSize, byte numConfigs, byte numIDs, uint memBlankVal, int eeBytes, int idBytes, ushort[] configBlank, uint OSCCALInit)
		{
			ProgramMemory = new uint[progMemSize];
			EEPromMemory = new uint[eeMemSize];
			ConfigWords = new uint[numConfigs];
			UserIDs = new uint[numIDs];
			ClearProgramMemory(memBlankVal);
			ClearEEPromMemory(eeBytes, memBlankVal);
			ClearConfigWords(configBlank);
			ClearUserIDs(idBytes, memBlankVal);
			OSCCAL = (OSCCALInit | 0xFF);
			BandGap = memBlankVal;
		}

		public void ClearProgramMemory(uint memBlankVal)
		{
			if (ProgramMemory.Length > 0)
			{
				for (int i = 0; i < ProgramMemory.Length; i++)
				{
					ProgramMemory[i] = memBlankVal;
				}
			}
		}

		public void ClearConfigWords(ushort[] configBlank)
		{
			if (ConfigWords.Length > 0)
			{
				for (int i = 0; i < ConfigWords.Length; i++)
				{
					ConfigWords[i] = configBlank[i];
				}
			}
		}

		public void ClearUserIDs(int idBytes, uint memBlankVal)
		{
			if (UserIDs.Length > 0)
			{
				uint num = memBlankVal;
				if (idBytes == 1)
				{
					num = 255u;
				}
				for (int i = 0; i < UserIDs.Length; i++)
				{
					UserIDs[i] = num;
				}
			}
		}

		public void ClearEEPromMemory(int eeBytes, uint memBlankVal)
		{
			if (EEPromMemory.Length > 0)
			{
				uint num = 255u;
				if (eeBytes == 2)
				{
					num = 65535u;
				}
				if (memBlankVal == 4095)
				{
					num = 4095u;
				}
				for (int i = 0; i < EEPromMemory.Length; i++)
				{
					EEPromMemory[i] = num;
				}
			}
		}
	}
}
