using System;

namespace PICkit2V2
{
	public class PIC24F_PE
	{
		private const int PIC24_PE_Version = 38;

		private const int PIC24_PE_ID = 155;

		public static DelegateStatusWin UpdateStatusWinText;

		public static DelegateResetStatusBar ResetStatusBar;

		public static DelegateStepStatusBar StepStatusBar;

		private static byte ICSPSpeedRestore = 0;

		private static bool PEGoodOnWrite = false;

		private static uint[] PIC24_PE_Code = new uint[512]
		{
			262272u,
			128u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			8388894u,
			16384000u,
			2133231u,
			2260864u,
			8913152u,
			0u,
			458754u,
			16416768u,
			393216u,
			16384000u,
			15400960u,
			8927776u,
			459088u,
			458968u,
			458763u,
			3670013u,
			16252980u,
			7872392u,
			11780104u,
			8913320u,
			7865423u,
			16384000u,
			16646144u,
			16416768u,
			16318516u,
			409600u,
			16384002u,
			8404992u,
			14549068u,
			16482304u,
			7868160u,
			7864350u,
			5246949u,
			3276821u,
			7864478u,
			5279717u,
			3932165u,
			7864478u,
			4227168u,
			5246946u,
			4063252u,
			3604487u,
			7864350u,
			5246954u,
			3276812u,
			7864478u,
			5279723u,
			3276811u,
			3604492u,
			11045063u,
			11118791u,
			11126983u,
			11135175u,
			458766u,
			3604491u,
			458816u,
			3604489u,
			458881u,
			3604487u,
			458913u,
			3604485u,
			11045063u,
			11053255u,
			11126983u,
			11135175u,
			458754u,
			16416768u,
			393216u,
			16384000u,
			8406577u,
			3080192u,
			6324352u,
			2162688u,
			5279616u,
			3276806u,
			8406577u,
			3080192u,
			6324352u,
			2293760u,
			5279616u,
			3801091u,
			15417344u,
			12052678u,
			3604482u,
			11780112u,
			12052678u,
			8404992u,
			14549068u,
			16482304u,
			6291567u,
			14483784u,
			8406577u,
			3084272u,
			6324224u,
			7340034u,
			8930864u,
			8406577u,
			2158592u,
			6324352u,
			2105344u,
			5279616u,
			3801101u,
			8405008u,
			13697024u,
			12124259u,
			15237120u,
			8930880u,
			8405008u,
			6291553u,
			14681088u,
			3276806u,
			8406592u,
			15237120u,
			8930880u,
			3604482u,
			2097184u,
			8930880u,
			458882u,
			16416768u,
			393216u,
			2359312u,
			8928000u,
			2129925u,
			15400960u,
			9454629u,
			9438373u,
			4359014u,
			8913304u,
			7865225u,
			2097408u,
			12258230u,
			12311478u,
			12315574u,
			12262326u,
			12258230u,
			12311478u,
			12315574u,
			12262326u,
			15269888u,
			3866614u,
			589829u,
			7867206u,
			2097280u,
			5473152u,
			12258230u,
			11061089u,
			2098519u,
			8928055u,
			2099879u,
			8928055u,
			11069281u,
			0u,
			0u,
			8403712u,
			10743808u,
			3276797u,
			458757u,
			14483532u,
			2133089u,
			7866496u,
			524195u,
			393216u,
			2129920u,
			15401088u,
			9454624u,
			9438368u,
			2097351u,
			4194790u,
			8913304u,
			7864969u,
			2097652u,
			12190485u,
			14757939u,
			3801099u,
			12245941u,
			12243925u,
			14757939u,
			3801095u,
			12190517u,
			14757939u,
			3801092u,
			15270404u,
			3932148u,
			2097168u,
			3604481u,
			2097184u,
			393216u,
			15671346u,
			3145703u,
			3604480u,
			15434240u,
			3145702u,
			2129920u,
			9437584u,
			9437472u,
			11599890u,
			11632643u,
			3276814u,
			12189783u,
			15171588u,
			3604489u,
			12238871u,
			15172612u,
			3604486u,
			14757895u,
			3866613u,
			8389008u,
			15204352u,
			8913296u,
			3670001u,
			2097393u,
			3604481u,
			2100993u,
			2203648u,
			7340033u,
			2133091u,
			7870848u,
			2097184u,
			7866752u,
			458780u,
			393216u,
			2097761u,
			2207744u,
			7340033u,
			2133089u,
			7870592u,
			2097184u,
			7866496u,
			458771u,
			393216u,
			458855u,
			2129927u,
			7871360u,
			2162675u,
			6291843u,
			15270275u,
			3276804u,
			458848u,
			7871360u,
			15270275u,
			3866620u,
			11133505u,
			2117632u,
			8917520u,
			15704648u,
			11067969u,
			15704648u,
			393216u,
			15671872u,
			589853u,
			0u,
			2113536u,
			8917520u,
			11092101u,
			11067969u,
			2133095u,
			7864375u,
			8917568u,
			7864375u,
			458831u,
			2133088u,
			9437840u,
			15303301u,
			3276856u,
			9453584u,
			11682032u,
			11780113u,
			14746625u,
			3801098u,
			2129920u,
			9453728u,
			16482433u,
			8913297u,
			9438112u,
			12189751u,
			458815u,
			15270533u,
			3866620u,
			3604521u,
			11780129u,
			14746625u,
			3801134u,
			2129920u,
			9437840u,
			13697797u,
			11534400u,
			7880848u,
			7865345u,
			7864528u,
			7865217u,
			15269893u,
			3276821u,
			2097153u,
			8913304u,
			0u,
			12191895u,
			458794u,
			12245143u,
			11534375u,
			11567112u,
			8913304u,
			0u,
			12243095u,
			458787u,
			12189719u,
			458785u,
			11534375u,
			11567112u,
			8913304u,
			15270662u,
			3866606u,
			10878981u,
			3604487u,
			8913304u,
			0u,
			12189719u,
			458774u,
			12238871u,
			16482304u,
			458771u,
			11419781u,
			3670014u,
			11092101u,
			11133505u,
			11035203u,
			11067969u,
			8393281u,
			393216u,
			11780289u,
			14746625u,
			3866613u,
			7864375u,
			458758u,
			3670002u,
			11419781u,
			3670014u,
			11092101u,
			8393280u,
			393216u,
			7872385u,
			11419781u,
			3670014u,
			11419781u,
			3670012u,
			11092101u,
			8393281u,
			8917568u,
			7864527u,
			393216u,
			8389136u,
			11733504u,
			8913424u,
			2146304u,
			8917520u,
			11092101u,
			15671464u,
			11010217u,
			11026581u,
			2621440u,
			8917504u,
			15673186u,
			15673188u,
			393216u,
			2252u,
			2u,
			0u,
			2048u,
			204u,
			0u,
			0u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			155u,
			38u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u
		};

		private static byte[] BitReverseTable = new byte[256]
		{
			0,
			128,
			64,
			192,
			32,
			160,
			96,
			224,
			16,
			144,
			80,
			208,
			48,
			176,
			112,
			240,
			8,
			136,
			72,
			200,
			40,
			168,
			104,
			232,
			24,
			152,
			88,
			216,
			56,
			184,
			120,
			248,
			4,
			132,
			68,
			196,
			36,
			164,
			100,
			228,
			20,
			148,
			84,
			212,
			52,
			180,
			116,
			244,
			12,
			140,
			76,
			204,
			44,
			172,
			108,
			236,
			28,
			156,
			92,
			220,
			60,
			188,
			124,
			252,
			2,
			130,
			66,
			194,
			34,
			162,
			98,
			226,
			18,
			146,
			82,
			210,
			50,
			178,
			114,
			242,
			10,
			138,
			74,
			202,
			42,
			170,
			106,
			234,
			26,
			154,
			90,
			218,
			58,
			186,
			122,
			250,
			6,
			134,
			70,
			198,
			38,
			166,
			102,
			230,
			22,
			150,
			86,
			214,
			54,
			182,
			118,
			246,
			14,
			142,
			78,
			206,
			46,
			174,
			110,
			238,
			30,
			158,
			94,
			222,
			62,
			190,
			126,
			254,
			1,
			129,
			65,
			193,
			33,
			161,
			97,
			225,
			17,
			145,
			81,
			209,
			49,
			177,
			113,
			241,
			9,
			137,
			73,
			201,
			41,
			169,
			105,
			233,
			25,
			153,
			89,
			217,
			57,
			185,
			121,
			249,
			5,
			133,
			69,
			197,
			37,
			165,
			101,
			229,
			21,
			149,
			85,
			213,
			53,
			181,
			117,
			245,
			13,
			141,
			77,
			205,
			45,
			173,
			109,
			237,
			29,
			157,
			93,
			221,
			61,
			189,
			125,
			253,
			3,
			131,
			67,
			195,
			35,
			163,
			99,
			227,
			19,
			147,
			83,
			211,
			51,
			179,
			115,
			243,
			11,
			139,
			75,
			203,
			43,
			171,
			107,
			235,
			27,
			155,
			91,
			219,
			59,
			187,
			123,
			251,
			7,
			135,
			71,
			199,
			39,
			167,
			103,
			231,
			23,
			151,
			87,
			215,
			55,
			183,
			119,
			247,
			15,
			143,
			79,
			207,
			47,
			175,
			111,
			239,
			31,
			159,
			95,
			223,
			63,
			191,
			127,
			255
		};

		public static bool DownloadPE()
		{
			PICkitFunctions.RunScript(0, 1);
			PICkitFunctions.ExecuteScript(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DebugWriteVectorScript);
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemWrPrepScript != 0)
			{
				PICkitFunctions.DownloadAddress3(8388608);
				PICkitFunctions.RunScript(6, 1);
			}
			int num = 0;
			int num2 = 0;
			byte[] array = new byte[64];
			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					num2 = 0;
					if (j == 0)
					{
						array[num2++] = 167;
					}
					array[num2++] = 168;
					array[num2++] = 48;
					for (int k = 0; k < 16; k++)
					{
						array[num2++] = (byte)(PIC24_PE_Code[num] & 0xFF);
						array[num2++] = (byte)((PIC24_PE_Code[num] >> 8) & 0xFF);
						array[num2++] = (byte)((PIC24_PE_Code[num] >> 16) & 0xFF);
						num++;
					}
					for (; num2 < 64; num2++)
					{
						array[num2] = 173;
					}
					PICkitFunctions.writeUSB(array);
				}
				num2 = 0;
				array[num2++] = 166;
				array[num2++] = 0;
				array[num2++] = 212;
				array[num2++] = 0;
				array[num2++] = 211;
				array[num2++] = 1;
				array[num2++] = 212;
				array[num2++] = 3;
				array[num2++] = 211;
				array[num2++] = 2;
				array[num2++] = 217;
				array[num2++] = 128;
				array[num2++] = 11;
				array[num2++] = 187;
				array[num2++] = 216;
				array[num2++] = 216;
				array[num2++] = 217;
				array[num2++] = 129;
				array[num2++] = 155;
				array[num2++] = 187;
				array[num2++] = 216;
				array[num2++] = 216;
				array[num2++] = 217;
				array[num2++] = 130;
				array[num2++] = 139;
				array[num2++] = 187;
				array[num2++] = 216;
				array[num2++] = 216;
				array[num2++] = 217;
				array[num2++] = 131;
				array[num2++] = 27;
				array[num2++] = 187;
				array[num2++] = 216;
				array[num2++] = 216;
				array[num2++] = 233;
				array[num2++] = 32;
				array[num2++] = 31;
				array[num2++] = 217;
				array[num2++] = 97;
				array[num2++] = 231;
				array[num2++] = 168;
				array[num2++] = 216;
				array[num2++] = 217;
				array[num2++] = 0;
				array[num2++] = 2;
				array[num2++] = 4;
				array[num2++] = 216;
				array[num2++] = 233;
				array[num2++] = 1;
				array[num2++] = 3;
				array[num2++] = 231;
				array[num2++] = 72;
				array[1] = (byte)(num2 - 2);
				for (; num2 < 64; num2++)
				{
					array[num2] = 173;
				}
				PICkitFunctions.writeUSB(array);
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemWrPrepScript != 0)
			{
				PICkitFunctions.DownloadAddress3(8388608);
				PICkitFunctions.RunScript(5, 1);
			}
			byte[] array2 = new byte[128];
			num = 0;
			for (int l = 0; l < 16; l++)
			{
				PICkitFunctions.RunScriptUploadNoLen(3, 1);
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array2, 0L, 64L);
				PICkitFunctions.UploadDataNoLen();
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array2, 64L, 64L);
				int num3 = 0;
				for (int m = 0; m < 32; m++)
				{
					uint num4 = array2[num3++];
					num4 = (uint)((int)num4 | (array2[num3++] << 8));
					num4 = (uint)((int)num4 | (array2[num3++] << 16));
					if (num4 != PIC24_PE_Code[num++])
					{
						PICkitFunctions.RunScript(1, 1);
						return false;
					}
				}
			}
			PICkitFunctions.RunScript(1, 1);
			return true;
		}

		public static bool PE_Connect()
		{
			PICkitFunctions.RunScript(0, 1);
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemWrPrepScript != 0)
			{
				PICkitFunctions.DownloadAddress3(8389568);
				PICkitFunctions.RunScript(5, 1);
			}
			byte[] array = new byte[128];
			PICkitFunctions.RunScriptUploadNoLen(3, 1);
			Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
			PICkitFunctions.UploadDataNoLen();
			Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
			int num = array[72];
			num |= array[73] << 8;
			if (num != 155)
			{
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			num = array[75];
			num |= array[76] << 8;
			if (num != 38)
			{
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			PICkitFunctions.RunScript(1, 1);
			int i = 0;
			byte[] array2 = new byte[64];
			array2[i++] = 166;
			array2[i++] = 0;
			array2[i++] = 250;
			array2[i++] = 247;
			array2[i++] = 249;
			array2[i++] = 245;
			array2[i++] = 243;
			array2[i++] = 0;
			array2[i++] = 232;
			array2[i++] = 20;
			array2[i++] = 246;
			array2[i++] = 251;
			array2[i++] = 231;
			array2[i++] = 23;
			array2[i++] = 250;
			array2[i++] = 247;
			array2[i++] = 231;
			array2[i++] = 47;
			array2[i++] = 242;
			array2[i++] = 178;
			array2[i++] = 242;
			array2[i++] = 194;
			array2[i++] = 242;
			array2[i++] = 18;
			array2[i++] = 242;
			array2[i++] = 10;
			array2[i++] = 246;
			array2[i++] = 251;
			array2[i++] = 232;
			array2[i++] = 6;
			array2[1] = (byte)(i - 2);
			for (; i < 64; i++)
			{
				array2[i] = 173;
			}
			PICkitFunctions.writeUSB(array2);
			i = 0;
			array2[i++] = 166;
			array2[i++] = 12;
			array2[i++] = 242;
			array2[i++] = 0;
			array2[i++] = 242;
			array2[i++] = 128;
			array2[i++] = 243;
			array2[i++] = 2;
			array2[i++] = 231;
			array2[i++] = 5;
			array2[i++] = 240;
			array2[i++] = 240;
			array2[i++] = 240;
			array2[i++] = 240;
			array2[i++] = 170;
			for (; i < 64; i++)
			{
				array2[i] = 173;
			}
			PICkitFunctions.writeUSB(array2);
			if (!PICkitFunctions.readUSB())
			{
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			if (PICkitFunctions.Usb_read_array[1] != 4)
			{
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			if (PICkitFunctions.Usb_read_array[2] != 8 || PICkitFunctions.Usb_read_array[3] != 0 || PICkitFunctions.Usb_read_array[4] != 0 || PICkitFunctions.Usb_read_array[5] != 64)
			{
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			i = 0;
			array2[i++] = 166;
			array2[i++] = 14;
			array2[i++] = 243;
			array2[i++] = 0;
			array2[i++] = 242;
			array2[i++] = 13;
			array2[i++] = 242;
			array2[i++] = 128;
			array2[i++] = 243;
			array2[i++] = 2;
			array2[i++] = 231;
			array2[i++] = 5;
			array2[i++] = 240;
			array2[i++] = 240;
			array2[i++] = 240;
			array2[i++] = 240;
			array2[i++] = 170;
			for (; i < 64; i++)
			{
				array2[i] = 173;
			}
			PICkitFunctions.writeUSB(array2);
			if (!PICkitFunctions.readUSB())
			{
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			if (PICkitFunctions.Usb_read_array[1] != 4)
			{
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			if (PICkitFunctions.Usb_read_array[2] != 216 || BitReverseTable[PICkitFunctions.Usb_read_array[3]] != 38 || PICkitFunctions.Usb_read_array[4] != 0 || PICkitFunctions.Usb_read_array[5] != 64)
			{
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			return true;
		}

		public static bool PE_DownloadAndConnect()
		{
			ICSPSpeedRestore = PICkitFunctions.LastICSPSpeed;
			if (PICkitFunctions.LastICSPSpeed < 2)
			{
				PICkitFunctions.SetProgrammingSpeed(2);
			}
			if (!PE_Connect())
			{
				UpdateStatusWinText("Downloading Programming Executive...");
				if (!DownloadPE())
				{
					UpdateStatusWinText("Downloading Programming Executive...FAILED!");
					restoreICSPSpeed();
					return false;
				}
				if (!PE_Connect())
				{
					UpdateStatusWinText("Downloading Programming Executive...FAILED!");
					restoreICSPSpeed();
					return false;
				}
			}
			return true;
		}

		private static void restoreICSPSpeed()
		{
			if (ICSPSpeedRestore != PICkitFunctions.LastICSPSpeed)
			{
				PICkitFunctions.SetProgrammingSpeed(ICSPSpeedRestore);
			}
		}

		public static bool PE24FBlankCheck(string saveText)
		{
			if (!PE_DownloadAndConnect())
			{
				return false;
			}
			UpdateStatusWinText(saveText);
			int num = (int)(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem - PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords);
			byte[] array = new byte[128];
			_ = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
			int num2 = 32;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			byte[] array2 = new byte[64];
			ResetStatusBar((int)((long)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem / (long)num2));
			uint num6 = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue;
			do
			{
				num5 = 0;
				array2[num5++] = 166;
				array2[num5++] = 0;
				array2[num5++] = 243;
				array2[num5++] = 0;
				array2[num5++] = 242;
				array2[num5++] = 4;
				array2[num5++] = 242;
				array2[num5++] = 32;
				array2[num5++] = 242;
				array2[num5++] = 0;
				array2[num5++] = 242;
				array2[num5++] = BitReverseTable[num2];
				array2[num5++] = 242;
				array2[num5++] = 0;
				array2[num5++] = 242;
				array2[num5++] = BitReverseTable[(num3 >> 15) & 0xFF];
				array2[num5++] = 242;
				array2[num5++] = BitReverseTable[(num3 >> 7) & 0xFF];
				array2[num5++] = 242;
				array2[num5++] = BitReverseTable[(num3 << 1) & 0xFF];
				array2[num5++] = 243;
				array2[num5++] = 2;
				array2[num5++] = 231;
				array2[num5++] = 5;
				array2[num5++] = 239;
				array2[num5++] = 239;
				array2[num5++] = 239;
				array2[num5++] = 239;
				array2[num5++] = 240;
				array2[num5++] = 240;
				array2[num5++] = 240;
				array2[num5++] = 233;
				array2[num5++] = 3;
				array2[num5++] = 31;
				array2[num5++] = 172;
				array2[num5++] = 172;
				array2[1] = (byte)(num5 - 4);
				for (; num5 < 64; num5++)
				{
					array2[num5] = 173;
				}
				PICkitFunctions.writeUSB(array2);
				PICkitFunctions.GetUpload();
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
				PICkitFunctions.GetUpload();
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
				num4 = 0;
				for (int i = 0; i < num2; i += 2)
				{
					uint num7 = (uint)(BitReverseTable[array[num4++]] << 8);
					num7 |= BitReverseTable[array[num4++]];
					uint num8 = (uint)(BitReverseTable[array[num4++]] << 16);
					num7 = (uint)((int)num7 | (BitReverseTable[array[num4++]] << 16));
					num8 = (uint)((int)num8 | (BitReverseTable[array[num4++]] << 8));
					num8 |= BitReverseTable[array[num4++]];
					if (num3 >= num)
					{
						num6 = (uint)(0xFF0000 | PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[num3 - num]);
					}
					if (num6 != num7)
					{
						string str = "Program Memory is not blank starting at address\n";
						str += $"0x{num3 * PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].AddressIncrement:X6}";
						UpdateStatusWinText(str);
						PICkitFunctions.RunScript(1, 1);
						restoreICSPSpeed();
						return false;
					}
					num3++;
					if (num3 >= num)
					{
						num6 = (uint)(0xFF0000 | PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[num3 - num]);
					}
					if (num6 != num8)
					{
						string str2 = "Program Memory is not blank starting at address\n";
						str2 += $"0x{num3 * PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].AddressIncrement:X6}";
						UpdateStatusWinText(str2);
						PICkitFunctions.RunScript(1, 1);
						restoreICSPSpeed();
						return false;
					}
					num3++;
					if (num3 >= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem)
					{
						break;
					}
				}
				StepStatusBar();
			}
			while (num3 < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem);
			PICkitFunctions.RunScript(1, 1);
			restoreICSPSpeed();
			return true;
		}

		public static bool PE24FRead(string saveText)
		{
			if (!PE_DownloadAndConnect())
			{
				return false;
			}
			UpdateStatusWinText(saveText);
			byte[] array = new byte[128];
			_ = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
			int num = 32;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			byte[] array2 = new byte[64];
			ResetStatusBar((int)((long)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem / (long)num));
			do
			{
				num4 = 0;
				array2[num4++] = 166;
				array2[num4++] = 0;
				array2[num4++] = 243;
				array2[num4++] = 0;
				array2[num4++] = 242;
				array2[num4++] = 4;
				array2[num4++] = 242;
				array2[num4++] = 32;
				array2[num4++] = 242;
				array2[num4++] = 0;
				array2[num4++] = 242;
				array2[num4++] = BitReverseTable[num];
				array2[num4++] = 242;
				array2[num4++] = 0;
				array2[num4++] = 242;
				array2[num4++] = BitReverseTable[(num2 >> 15) & 0xFF];
				array2[num4++] = 242;
				array2[num4++] = BitReverseTable[(num2 >> 7) & 0xFF];
				array2[num4++] = 242;
				array2[num4++] = BitReverseTable[(num2 << 1) & 0xFF];
				array2[num4++] = 243;
				array2[num4++] = 2;
				array2[num4++] = 231;
				array2[num4++] = 5;
				array2[num4++] = 239;
				array2[num4++] = 239;
				array2[num4++] = 239;
				array2[num4++] = 239;
				array2[num4++] = 240;
				array2[num4++] = 240;
				array2[num4++] = 240;
				array2[num4++] = 233;
				array2[num4++] = 3;
				array2[num4++] = 31;
				array2[num4++] = 172;
				array2[num4++] = 172;
				array2[1] = (byte)(num4 - 4);
				for (; num4 < 64; num4++)
				{
					array2[num4] = 173;
				}
				PICkitFunctions.writeUSB(array2);
				PICkitFunctions.GetUpload();
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
				PICkitFunctions.GetUpload();
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
				num3 = 0;
				for (int i = 0; i < num; i += 2)
				{
					uint num5 = (uint)(BitReverseTable[array[num3++]] << 8);
					num5 |= BitReverseTable[array[num3++]];
					uint num6 = (uint)(BitReverseTable[array[num3++]] << 16);
					num5 = (uint)((int)num5 | (BitReverseTable[array[num3++]] << 16));
					num6 = (uint)((int)num6 | (BitReverseTable[array[num3++]] << 8));
					num6 |= BitReverseTable[array[num3++]];
					PICkitFunctions.DeviceBuffers.ProgramMemory[num2++] = num5;
					PICkitFunctions.DeviceBuffers.ProgramMemory[num2++] = num6;
					if (num2 >= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem)
					{
						break;
					}
				}
				StepStatusBar();
			}
			while (num2 < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem);
			PICkitFunctions.RunScript(1, 1);
			restoreICSPSpeed();
			return true;
		}

		public static bool PE24FWrite(int endOfBuffer, string saveText, bool writeVerify)
		{
			if (!PE_DownloadAndConnect())
			{
				PEGoodOnWrite = false;
				return false;
			}
			PEGoodOnWrite = true;
			UpdateStatusWinText(saveText);
			if (endOfBuffer == PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem)
			{
				for (int num = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords; num > 0; num--)
				{
					PICkitFunctions.DeviceBuffers.ProgramMemory[endOfBuffer - num] &= (uint)(0xFF0000 | PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords - num]);
				}
			}
			byte[] array = new byte[256];
			int num2 = 64;
			int num3 = 0;
			ResetStatusBar(endOfBuffer / num2);
			do
			{
				int num4 = 0;
				for (int i = 0; i < num2; i += 2)
				{
					uint num5 = PICkitFunctions.DeviceBuffers.ProgramMemory[num3++];
					array[num4 + 1] = BitReverseTable[num5 & 0xFF];
					num5 >>= 8;
					array[num4] = BitReverseTable[num5 & 0xFF];
					num5 >>= 8;
					array[num4 + 3] = BitReverseTable[num5 & 0xFF];
					num5 = PICkitFunctions.DeviceBuffers.ProgramMemory[num3++];
					array[num4 + 5] = BitReverseTable[num5 & 0xFF];
					num5 >>= 8;
					array[num4 + 4] = BitReverseTable[num5 & 0xFF];
					num5 >>= 8;
					array[num4 + 2] = BitReverseTable[num5 & 0xFF];
					num4 += 6;
				}
				for (int num6 = PICkitFunctions.DataClrAndDownload(array, 0); num6 < num4; num6 = PICkitFunctions.DataDownload(array, num6, num4))
				{
				}
				int j = 0;
				byte[] array2 = new byte[64];
				array2[j++] = 166;
				array2[j++] = 0;
				array2[j++] = 243;
				array2[j++] = 0;
				array2[j++] = 242;
				array2[j++] = 10;
				array2[j++] = 242;
				array2[j++] = 198;
				array2[j++] = 242;
				array2[j++] = 0;
				array2[j++] = 242;
				array2[j++] = BitReverseTable[(num3 - 64 >> 15) & 0xFF];
				array2[j++] = 242;
				array2[j++] = BitReverseTable[(num3 - 64 >> 7) & 0xFF];
				array2[j++] = 242;
				array2[j++] = BitReverseTable[(num3 - 64 << 1) & 0xFF];
				array2[j++] = 241;
				array2[j++] = 241;
				array2[j++] = 241;
				array2[j++] = 233;
				array2[j++] = 3;
				array2[j++] = 63;
				array2[j++] = 243;
				array2[j++] = 2;
				array2[j++] = 231;
				array2[j++] = 118;
				array2[j++] = 240;
				array2[j++] = 240;
				array2[j++] = 240;
				array2[j++] = 240;
				array2[j++] = 170;
				array2[1] = (byte)(j - 3);
				for (; j < 64; j++)
				{
					array2[j] = 173;
				}
				PICkitFunctions.writeUSB(array2);
				if (!PICkitFunctions.readUSB())
				{
					UpdateStatusWinText("Programming Executive Error during Write.");
					PICkitFunctions.RunScript(1, 1);
					restoreICSPSpeed();
					return false;
				}
				if (PICkitFunctions.Usb_read_array[1] != 4)
				{
					UpdateStatusWinText("Programming Executive Error during Write.");
					PICkitFunctions.RunScript(1, 1);
					restoreICSPSpeed();
					return false;
				}
				if (BitReverseTable[PICkitFunctions.Usb_read_array[2]] != 21 || PICkitFunctions.Usb_read_array[3] != 0 || PICkitFunctions.Usb_read_array[4] != 0 || BitReverseTable[PICkitFunctions.Usb_read_array[5]] != 2)
				{
					UpdateStatusWinText("Programming Executive Error during Write.");
					PICkitFunctions.RunScript(1, 1);
					restoreICSPSpeed();
					return false;
				}
				StepStatusBar();
			}
			while (num3 < endOfBuffer);
			if (!writeVerify)
			{
				PICkitFunctions.RunScript(1, 1);
				restoreICSPSpeed();
			}
			return true;
		}

		public static bool PE24FVerify(string saveText, bool writeVerify, int lastLocation)
		{
			if ((!writeVerify || !PEGoodOnWrite) && !PE_DownloadAndConnect())
			{
				return false;
			}
			PEGoodOnWrite = false;
			if (!writeVerify)
			{
				lastLocation = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem;
			}
			UpdateStatusWinText(saveText);
			byte[] array = new byte[128];
			_ = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
			int num = 32;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			byte[] array2 = new byte[64];
			ResetStatusBar(lastLocation / num);
			do
			{
				num4 = 0;
				array2[num4++] = 166;
				array2[num4++] = 0;
				array2[num4++] = 243;
				array2[num4++] = 0;
				array2[num4++] = 242;
				array2[num4++] = 4;
				array2[num4++] = 242;
				array2[num4++] = 32;
				array2[num4++] = 242;
				array2[num4++] = 0;
				array2[num4++] = 242;
				array2[num4++] = BitReverseTable[num];
				array2[num4++] = 242;
				array2[num4++] = 0;
				array2[num4++] = 242;
				array2[num4++] = BitReverseTable[(num2 >> 15) & 0xFF];
				array2[num4++] = 242;
				array2[num4++] = BitReverseTable[(num2 >> 7) & 0xFF];
				array2[num4++] = 242;
				array2[num4++] = BitReverseTable[(num2 << 1) & 0xFF];
				array2[num4++] = 243;
				array2[num4++] = 2;
				array2[num4++] = 231;
				array2[num4++] = 5;
				array2[num4++] = 239;
				array2[num4++] = 239;
				array2[num4++] = 239;
				array2[num4++] = 239;
				array2[num4++] = 240;
				array2[num4++] = 240;
				array2[num4++] = 240;
				array2[num4++] = 233;
				array2[num4++] = 3;
				array2[num4++] = 31;
				array2[num4++] = 172;
				array2[num4++] = 172;
				array2[1] = (byte)(num4 - 4);
				for (; num4 < 64; num4++)
				{
					array2[num4] = 173;
				}
				PICkitFunctions.writeUSB(array2);
				PICkitFunctions.GetUpload();
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
				PICkitFunctions.GetUpload();
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
				num3 = 0;
				for (int i = 0; i < num; i += 2)
				{
					uint num5 = (uint)(BitReverseTable[array[num3++]] << 8);
					num5 |= BitReverseTable[array[num3++]];
					uint num6 = (uint)(BitReverseTable[array[num3++]] << 16);
					num5 = (uint)((int)num5 | (BitReverseTable[array[num3++]] << 16));
					num6 = (uint)((int)num6 | (BitReverseTable[array[num3++]] << 8));
					num6 |= BitReverseTable[array[num3++]];
					if (PICkitFunctions.DeviceBuffers.ProgramMemory[num2++] != num5)
					{
						string text = "";
						text = (writeVerify ? "Programming failed at Program Memory address\n" : "Verification of Program Memory failed at address\n");
						text += $"0x{--num2 * PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].AddressIncrement:X6}";
						UpdateStatusWinText(text);
						PICkitFunctions.RunScript(1, 1);
						restoreICSPSpeed();
						return false;
					}
					if (PICkitFunctions.DeviceBuffers.ProgramMemory[num2++] != num6)
					{
						string text2 = "";
						text2 = (writeVerify ? "Programming failed at Program Memory address\n" : "Verification of Program Memory failed at address\n");
						text2 += $"0x{--num2 * PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].AddressIncrement:X6}";
						UpdateStatusWinText(text2);
						PICkitFunctions.RunScript(1, 1);
						restoreICSPSpeed();
						return false;
					}
					if (num2 >= lastLocation)
					{
						break;
					}
				}
				StepStatusBar();
			}
			while (num2 < lastLocation);
			PICkitFunctions.RunScript(1, 1);
			restoreICSPSpeed();
			return true;
		}
	}
}
