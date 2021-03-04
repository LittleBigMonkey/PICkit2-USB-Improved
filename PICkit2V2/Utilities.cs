using System.Text;

namespace PICkit2V2
{
	public class Utilities
	{
		public static int Convert_Value_To_Int(string p_value)
		{
			uint[] array = new uint[34]
			{
				0u,
				0u,
				2147483648u,
				1073741824u,
				536870912u,
				268435456u,
				134217728u,
				67108864u,
				33554432u,
				16777216u,
				8388608u,
				4194304u,
				2097152u,
				1048576u,
				524288u,
				262144u,
				131072u,
				65536u,
				32768u,
				16384u,
				8192u,
				4096u,
				2048u,
				1024u,
				512u,
				256u,
				128u,
				64u,
				32u,
				16u,
				8u,
				4u,
				2u,
				1u
			};
			uint[] array2 = new uint[10]
			{
				0u,
				0u,
				268435456u,
				16777216u,
				1048576u,
				65536u,
				4096u,
				256u,
				16u,
				1u
			};
			int result = 0;
			if (p_value[0] == '\0')
			{
				result = 0;
			}
			else if (p_value[0] == 'Y' || p_value[0] == 'y')
			{
				result = 1;
			}
			else if (p_value[0] == 'N' || p_value[0] == 'n')
			{
				result = 0;
			}
			else if (p_value.Length > 1)
			{
				if ((p_value[0] == '0' && (p_value[1] == 'b' || p_value[1] == 'B')) || p_value[0] == 'b' || p_value[0] == 'B')
				{
					int num = p_value.Length - 1;
					int num2 = (p_value[0] != '0') ? 1 : 2;
					for (int i = num2; i <= num; i++)
					{
						int num3 = (p_value[i] == '1') ? 1 : 0;
						result += (int)array[i + 34 - p_value.Length] * num3;
					}
				}
				else if (p_value[0] == '0' && (p_value[1] == 'x' || p_value[1] == 'X'))
				{
					int num = p_value.Length - 1;
					for (int i = 2; i <= num; i++)
					{
						int num3;
						switch (p_value[i])
						{
						case 'A':
						case 'a':
							num3 = 10;
							break;
						case 'B':
						case 'b':
							num3 = 11;
							break;
						case 'C':
						case 'c':
							num3 = 12;
							break;
						case 'D':
						case 'd':
							num3 = 13;
							break;
						case 'E':
						case 'e':
							num3 = 14;
							break;
						case 'F':
						case 'f':
							num3 = 15;
							break;
						default:
						{
							string s = p_value[i].ToString();
							if (!int.TryParse(s, out num3))
							{
								num3 = 0;
							}
							break;
						}
						}
						result += (int)array2[i + 10 - p_value.Length] * num3;
					}
				}
				else if (!int.TryParse(p_value, out result))
				{
					result = 0;
				}
			}
			else if (!int.TryParse(p_value, out result))
			{
				result = 0;
			}
			return result;
		}

		public static string ConvertIntASCII(int toConvert, int numBytes)
		{
			byte[] array = new byte[numBytes];
			for (int num = numBytes; num > 0; num--)
			{
				array[num - 1] = (byte)toConvert;
				if (array[num - 1] < 32 || array[num - 1] > 126)
				{
					array[num - 1] = 46;
				}
				toConvert >>= 8;
			}
			return Encoding.ASCII.GetString(array);
		}

		public static string ConvertIntASCIIReverse(int toConvert, int numBytes)
		{
			numBytes += numBytes - 1;
			byte[] array = new byte[numBytes];
			for (int i = 0; i < numBytes; i++)
			{
				if (i % 2 == 1)
				{
					array[i] = 32;
					continue;
				}
				array[i] = (byte)toConvert;
				if (array[i] < 32 || array[i] > 126)
				{
					array[i] = 46;
				}
				toConvert >>= 8;
			}
			return Encoding.ASCII.GetString(array);
		}
	}
}
