using System;
using System.Runtime.InteropServices;
using System.Text;

namespace PICkit2V2
{
	public class USB
	{
		public struct SP_DEVICE_INTERFACE_DATA
		{
			public int cbSize;

			public Guid InterfaceClassGuid;

			public int Flags;

			public int Reserved;
		}

		public struct SP_DEVICE_INTERFACE_DETAIL_DATA
		{
			public int cbSize;

			public string DevicePath;
		}

		public struct SP_DEVINFO_DATA
		{
			public int cbSize;

			public Guid ClassGuid;

			public int DevInst;

			public int Reserved;
		}

		public struct HIDD_ATTRIBUTES
		{
			public int Size;

			public ushort VendorID;

			public ushort ProductID;

			public ushort VersionNumber;
		}

		public struct SECURITY_ATTRIBUTES
		{
			public int nLength;

			public int lpSecurityDescriptor;

			public int bInheritHandle;
		}

		public struct HIDP_CAPS
		{
			public short Usage;

			public short UsagePage;

			public short InputReportByteLength;

			public short OutputReportByteLength;

			public short FeatureReportByteLength;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
			public short[] Reserved;

			public short NumberLinkCollectionNodes;

			public short NumberInputButtonCaps;

			public short NumberInputValueCaps;

			public short NumberInputDataIndices;

			public short NumberOutputButtonCaps;

			public short NumberOutputValueCaps;

			public short NumberOutputDataIndices;

			public short NumberFeatureButtonCaps;

			public short NumberFeatureValueCaps;

			public short NumberFeatureDataIndices;
		}

		private const uint GENERIC_READ = 2147483648u;

		private const uint GENERIC_WRITE = 1073741824u;

		private const uint FILE_SHARE_READ = 1u;

		private const uint FILE_SHARE_WRITE = 2u;

		private const uint FILE_FLAG_OVERLAPPED = 1073741824u;

		private const int INVALID_HANDLE_VALUE = -1;

		private const short OPEN_EXISTING = 3;

		private const short DIGCF_PRESENT = 2;

		private const short DIGCF_DEVICEINTERFACE = 16;

		public static string UnitID = "";

		[DllImport("hid.dll")]
		public static extern void HidD_GetHidGuid(ref Guid HidGuid);

		[DllImport("setupapi.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, string Enumerator, int hwndParent, int Flags);

		[DllImport("setupapi.dll")]
		public static extern int SetupDiEnumDeviceInterfaces(IntPtr DeviceInfoSet, int DeviceInfoData, ref Guid InterfaceClassGuid, int MemberIndex, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);

		[DllImport("setupapi.dll", CharSet = CharSet.Auto)]
		public static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData, IntPtr DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, ref SECURITY_ATTRIBUTES lpSecurityAttributes, int dwCreationDisposition, uint dwFlagsAndAttributes, int hTemplateFile);

		[DllImport("hid.dll")]
		public static extern int HidD_GetAttributes(IntPtr HidDeviceObject, ref HIDD_ATTRIBUTES Attributes);

		[DllImport("hid.dll")]
		public static extern bool HidD_GetPreparsedData(IntPtr HidDeviceObject, ref IntPtr PreparsedData);

		[DllImport("hid.dll")]
		public static extern bool HidD_GetSerialNumberString(IntPtr HidDeviceObject, byte[] Buffer, ulong BufferLength);

		[DllImport("hid.dll")]
		public static extern int HidP_GetCaps(IntPtr PreparsedData, ref HIDP_CAPS Capabilities);

		[DllImport("setupapi.dll")]
		public static extern int SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

		[DllImport("hid.dll")]
		public static extern bool HidD_FreePreparsedData(ref IntPtr PreparsedData);

		[DllImport("kernel32.dll")]
		public static extern int CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteFile(IntPtr hFile, byte[] Buffer, int numBytesToWrite, ref int numBytesWritten, int Overlapped);

		[DllImport("kernel32", SetLastError = true)]
		public static extern bool ReadFile(IntPtr hFile, byte[] Buffer, int NumberOfBytesToRead, ref int pNumberOfBytesRead, int Overlapped);

		public static bool Find_This_Device(ushort p_VendorID, ushort p_PoductID, ushort p_index, ref IntPtr p_ReadHandle, ref IntPtr p_WriteHandle)
		{
			IntPtr zero = IntPtr.Zero;
			IntPtr PreparsedData = IntPtr.Zero;
			HIDP_CAPS Capabilities = default(HIDP_CAPS);
			ushort num = 0;
			IntPtr zero2 = IntPtr.Zero;
			int RequiredSize = 0;
			SECURITY_ATTRIBUTES lpSecurityAttributes = default(SECURITY_ATTRIBUTES);
			IntPtr value = new IntPtr(-1);
			byte[] array = new byte[64];
			lpSecurityAttributes.lpSecurityDescriptor = 0;
			lpSecurityAttributes.bInheritHandle = Convert.ToInt32(value: true);
			lpSecurityAttributes.nLength = Marshal.SizeOf(lpSecurityAttributes);
			Guid HidGuid = Guid.Empty;
			SP_DEVICE_INTERFACE_DATA DeviceInterfaceData = default(SP_DEVICE_INTERFACE_DATA);
			DeviceInterfaceData.cbSize = 0;
			DeviceInterfaceData.Flags = 0;
			DeviceInterfaceData.InterfaceClassGuid = Guid.Empty;
			DeviceInterfaceData.Reserved = 0;
			SP_DEVICE_INTERFACE_DETAIL_DATA sP_DEVICE_INTERFACE_DETAIL_DATA = default(SP_DEVICE_INTERFACE_DETAIL_DATA);
			sP_DEVICE_INTERFACE_DETAIL_DATA.cbSize = 0;
			sP_DEVICE_INTERFACE_DETAIL_DATA.DevicePath = "";
			HIDD_ATTRIBUTES Attributes = default(HIDD_ATTRIBUTES);
			Attributes.ProductID = 0;
			Attributes.Size = 0;
			Attributes.VendorID = 0;
			Attributes.VersionNumber = 0;
			bool result = false;
			lpSecurityAttributes.lpSecurityDescriptor = 0;
			lpSecurityAttributes.bInheritHandle = Convert.ToInt32(value: true);
			lpSecurityAttributes.nLength = Marshal.SizeOf(lpSecurityAttributes);
			HidD_GetHidGuid(ref HidGuid);
			zero = SetupDiGetClassDevs(ref HidGuid, null, 0, 18);
			DeviceInterfaceData.cbSize = Marshal.SizeOf(DeviceInterfaceData);
			for (int i = 0; i < 20; i++)
			{
				if (SetupDiEnumDeviceInterfaces(zero, 0, ref HidGuid, i, ref DeviceInterfaceData) == 0)
				{
					continue;
				}
				SetupDiGetDeviceInterfaceDetail(zero, ref DeviceInterfaceData, IntPtr.Zero, 0, ref RequiredSize, IntPtr.Zero);
				sP_DEVICE_INTERFACE_DETAIL_DATA.cbSize = Marshal.SizeOf(sP_DEVICE_INTERFACE_DETAIL_DATA);
				IntPtr intPtr = Marshal.AllocHGlobal(RequiredSize);
				Marshal.WriteInt32(intPtr, 4 + Marshal.SystemDefaultCharSize);
				SetupDiGetDeviceInterfaceDetail(zero, ref DeviceInterfaceData, intPtr, RequiredSize, ref RequiredSize, IntPtr.Zero);
				IntPtr ptr = new IntPtr(intPtr.ToInt32() + 4);
				string lpFileName = Marshal.PtrToStringAuto(ptr);
				zero2 = CreateFile(lpFileName, 3221225472u, 3u, ref lpSecurityAttributes, 3, 0u, 0);
				if (!(zero2 != value))
				{
					continue;
				}
				Attributes.Size = Marshal.SizeOf(Attributes);
				if (HidD_GetAttributes(zero2, ref Attributes) != 0)
				{
					if (Attributes.VendorID == p_VendorID && Attributes.ProductID == p_PoductID)
					{
						if (num == p_index)
						{
							result = true;
							HidD_GetSerialNumberString(zero2, array, 64uL);
							if (array[0] == 9 || array[0] == 0)
							{
								UnitID = "-";
							}
							else
							{
								int j;
								for (j = 2; j < 28; j += 2)
								{
									array[j / 2] = array[j];
									if (array[j] == 0 || array[j] == 224)
									{
										break;
									}
									array[j] = 0;
									array[j + 1] = 0;
								}
								j /= 2;
								char[] array2 = new char[Encoding.ASCII.GetCharCount(array, 0, j)];
								Encoding.ASCII.GetChars(array, 0, j, array2, 0);
								string text = UnitID = new string(array2);
							}
							p_WriteHandle = zero2;
							HidD_GetPreparsedData(zero2, ref PreparsedData);
							HidP_GetCaps(PreparsedData, ref Capabilities);
							p_ReadHandle = CreateFile(lpFileName, 3221225472u, 3u, ref lpSecurityAttributes, 3, 0u, 0);
							HidD_FreePreparsedData(ref PreparsedData);
							break;
						}
						CloseHandle(zero2);
						num = (ushort)(num + 1);
					}
					else
					{
						result = false;
						CloseHandle(zero2);
					}
				}
				else
				{
					result = false;
					CloseHandle(zero2);
				}
			}
			SetupDiDestroyDeviceInfoList(zero);
			return result;
		}
	}
}
