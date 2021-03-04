using System;
using System.Threading;

namespace PICkit2V2
{
	public class dsPIC33_PE
	{
		private const int dsPIC33_PE_Version = 38;

		private const int dsPIC33_PE_ID = 203;

		public static DelegateStatusWin UpdateStatusWinText;

		public static DelegateResetStatusBar ResetStatusBar;

		public static DelegateStepStatusBar StepStatusBar;

		private static byte ICSPSpeedRestore = 0;

		private static uint[] dsPIC33_PE_Code = new uint[1024]
		{
			262272u,
			128u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			8388896u,
			16384000u,
			2141647u,
			2260864u,
			8913152u,
			0u,
			458754u,
			16416768u,
			393216u,
			16384000u,
			15400960u,
			8927776u,
			459360u,
			459302u,
			459182u,
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
			16384004u,
			8409184u,
			14549068u,
			16482304u,
			12124513u,
			12488450u,
			2097376u,
			2097153u,
			12452126u,
			5312384u,
			5869441u,
			4063279u,
			12451870u,
			90112u,
			3604494u,
			3604493u,
			3604492u,
			3604521u,
			3604496u,
			3604499u,
			3604518u,
			3604499u,
			3604516u,
			3604499u,
			3604500u,
			3604503u,
			3604504u,
			3604489u,
			3604498u,
			11045587u,
			11119315u,
			11127507u,
			11135699u,
			458784u,
			3604509u,
			458926u,
			3604507u,
			458958u,
			3604505u,
			459015u,
			3604503u,
			458850u,
			3604501u,
			458871u,
			3604499u,
			459076u,
			3604497u,
			459077u,
			3604495u,
			459111u,
			3604493u,
			459251u,
			8935104u,
			11045587u,
			11119315u,
			11127507u,
			11135699u,
			458760u,
			3604485u,
			11045587u,
			11053779u,
			11127507u,
			11135699u,
			458754u,
			16416768u,
			393216u,
			16384000u,
			8410769u,
			3080192u,
			6324352u,
			2162688u,
			5279616u,
			3276806u,
			8410769u,
			3080192u,
			6324352u,
			2293760u,
			5279616u,
			3801091u,
			15417344u,
			12053202u,
			3604482u,
			11780112u,
			12053202u,
			8409184u,
			14549068u,
			16482304u,
			6291567u,
			14483784u,
			8410769u,
			3084272u,
			6324224u,
			7340034u,
			8935056u,
			8410769u,
			2158592u,
			6324352u,
			2101248u,
			5279616u,
			3801093u,
			12569103u,
			16482304u,
			15237120u,
			8935072u,
			3604512u,
			8410769u,
			2158592u,
			6324352u,
			2105344u,
			5279616u,
			3801101u,
			8409200u,
			13697024u,
			12124259u,
			15237120u,
			8935072u,
			8409200u,
			6291553u,
			14681088u,
			3276817u,
			8410784u,
			15237120u,
			8935072u,
			3604493u,
			8410769u,
			2158592u,
			6324352u,
			2146304u,
			5279616u,
			3801093u,
			2097200u,
			8935072u,
			8410816u,
			8935088u,
			3604482u,
			2097184u,
			8935072u,
			459050u,
			16416768u,
			393216u,
			16384000u,
			2360560u,
			8928000u,
			11061089u,
			2098519u,
			8928055u,
			2099879u,
			8928055u,
			11069281u,
			0u,
			0u,
			12568417u,
			11782145u,
			6307841u,
			14681088u,
			3866619u,
			11045587u,
			11119315u,
			11127507u,
			11135699u,
			524193u,
			16416768u,
			393216u,
			16384006u,
			2360352u,
			8928000u,
			12569102u,
			16482304u,
			2097153u,
			14483904u,
			2097154u,
			8409216u,
			2097153u,
			4267776u,
			4822785u,
			15400960u,
			9963296u,
			3604500u,
			11061089u,
			2098519u,
			8928055u,
			2099879u,
			8928055u,
			11069281u,
			0u,
			0u,
			12568417u,
			11782145u,
			6307841u,
			14681088u,
			3866619u,
			2098176u,
			2097153u,
			4198174u,
			4757342u,
			9437230u,
			15204352u,
			9963296u,
			12569103u,
			16482432u,
			9437230u,
			5279616u,
			4128743u,
			11045587u,
			11119315u,
			11127507u,
			11135699u,
			524146u,
			16416768u,
			393216u,
			16384004u,
			12569102u,
			16482304u,
			8913296u,
			2359296u,
			8928000u,
			8409232u,
			9963280u,
			8409216u,
			7868160u,
			9437342u,
			7864350u,
			12257281u,
			11061089u,
			2098512u,
			8928048u,
			2099872u,
			8928048u,
			11069281u,
			0u,
			0u,
			9963280u,
			12568417u,
			11782145u,
			6307841u,
			14681088u,
			3866619u,
			11045587u,
			11119315u,
			11127507u,
			11135699u,
			524112u,
			16416768u,
			393216u,
			16384004u,
			12569102u,
			16482304u,
			8913296u,
			2359344u,
			8928000u,
			8409232u,
			9963280u,
			8409216u,
			7868160u,
			9437342u,
			7864350u,
			12257281u,
			12569103u,
			16482304u,
			9963280u,
			9437342u,
			7864350u,
			12306433u,
			11061089u,
			2098512u,
			8928048u,
			2099872u,
			8928048u,
			11069281u,
			0u,
			0u,
			9963280u,
			12568417u,
			11782145u,
			6307841u,
			14681088u,
			3866619u,
			7864350u,
			12189712u,
			9963280u,
			11111123u,
			11053779u,
			11127507u,
			11135699u,
			8409233u,
			9437214u,
			5279616u,
			3801100u,
			7864350u,
			12238864u,
			9963280u,
			9437214u,
			7880832u,
			12569103u,
			5296000u,
			3801092u,
			11045587u,
			11119315u,
			11127507u,
			11135699u,
			524053u,
			16416768u,
			393216u,
			2359312u,
			8928000u,
			2138309u,
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
			2141473u,
			7866496u,
			524010u,
			393216u,
			2138304u,
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
			3604485u,
			2138304u,
			9437616u,
			8913299u,
			9437632u,
			5342178u,
			15434240u,
			3145702u,
			2138304u,
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
			2141475u,
			7870848u,
			2097184u,
			7866752u,
			458780u,
			393216u,
			2097761u,
			2207744u,
			7340033u,
			2141473u,
			7870592u,
			2097184u,
			7866496u,
			458771u,
			393216u,
			458855u,
			2138311u,
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
			2141479u,
			7864375u,
			8917568u,
			7864375u,
			458831u,
			2141472u,
			9437840u,
			15303301u,
			3276856u,
			9453584u,
			11682032u,
			11780113u,
			14746625u,
			3801098u,
			2138304u,
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
			2138304u,
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
			16384012u,
			12058720u,
			9963296u,
			9963313u,
			12058720u,
			9963328u,
			9963345u,
			12569103u,
			7884544u,
			4653156u,
			15237248u,
			12569102u,
			7882880u,
			8409216u,
			12058977u,
			9437230u,
			9437374u,
			7405568u,
			7438465u,
			9963296u,
			9963313u,
			4653160u,
			15237248u,
			8409232u,
			7866496u,
			8409248u,
			12058977u,
			9437262u,
			9437406u,
			7405568u,
			7438465u,
			9963328u,
			9963345u,
			9437518u,
			9437662u,
			9437230u,
			9437374u,
			7881246u,
			458797u,
			9963280u,
			9437214u,
			16416768u,
			393216u,
			16384006u,
			15400960u,
			9963280u,
			3604511u,
			9437214u,
			14483528u,
			9963296u,
			11780224u,
			7884544u,
			3604494u,
			9437230u,
			14680064u,
			3997703u,
			9437230u,
			4194304u,
			7864448u,
			2163216u,
			6848512u,
			9963296u,
			3604483u,
			9437230u,
			4194304u,
			9963296u,
			15290142u,
			14681118u,
			3866608u,
			9437214u,
			4194432u,
			2130112u,
			4227072u,
			9437358u,
			7866369u,
			9437214u,
			15204352u,
			9963280u,
			9437342u,
			2101232u,
			5279616u,
			3473373u,
			16416768u,
			393216u,
			16384026u,
			9963360u,
			9963377u,
			9965314u,
			9965331u,
			9983812u,
			15433728u,
			9963328u,
			9437550u,
			9437694u,
			2097152u,
			2097169u,
			4194306u,
			4751491u,
			2097154u,
			3145715u,
			7864832u,
			7864961u,
			7864322u,
			7864451u,
			6422784u,
			6455297u,
			12059233u,
			9965364u,
			9965381u,
			9439294u,
			9439438u,
			14483648u,
			2097152u,
			9965360u,
			9965377u,
			9439294u,
			9439438u,
			12063329u,
			9965364u,
			9965381u,
			9439550u,
			9439694u,
			7340034u,
			7372931u,
			9963280u,
			9963297u,
			3604540u,
			9439246u,
			9439390u,
			4194560u,
			4751745u,
			9437294u,
			9437438u,
			4194562u,
			4751747u,
			9437214u,
			9437358u,
			5312384u,
			5869441u,
			3735578u,
			9437470u,
			9437614u,
			9437294u,
			9437438u,
			5308416u,
			5865601u,
			13697153u,
			13860864u,
			9963312u,
			9437470u,
			9437614u,
			2097152u,
			2097169u,
			4194306u,
			4751491u,
			9963280u,
			9963297u,
			9437246u,
			12058977u,
			9439246u,
			9439390u,
			5242882u,
			5800067u,
			9965312u,
			9965329u,
			3604485u,
			9439630u,
			9963315u,
			12058720u,
			9965312u,
			9965329u,
			9437646u,
			9437502u,
			9437294u,
			9437438u,
			458802u,
			9963328u,
			9437246u,
			2097153u,
			4194560u,
			4751745u,
			9437294u,
			9437438u,
			4259840u,
			4817025u,
			9963360u,
			9963377u,
			9439246u,
			9439390u,
			5246944u,
			5804000u,
			3866559u,
			9437262u,
			2097153u,
			16416768u,
			393216u,
			2097958u,
			7867137u,
			7865216u,
			2130086u,
			7867138u,
			13969418u,
			2130120u,
			2129926u,
			12196631u,
			12245815u,
			12245847u,
			12196663u,
			2129924u,
			2097253u,
			16613379u,
			7880707u,
			7880884u,
			6864896u,
			15687681u,
			13762560u,
			4194312u,
			7864336u,
			15417728u,
			6914432u,
			15540234u,
			3866612u,
			15542282u,
			3866603u,
			7864323u,
			393216u,
			2097958u,
			7867137u,
			7865216u,
			2130086u,
			7867138u,
			13969418u,
			2130120u,
			2097250u,
			2129926u,
			12196631u,
			12245815u,
			12245847u,
			12196663u,
			2129924u,
			2097205u,
			15401088u,
			16613379u,
			7880707u,
			6834356u,
			15687681u,
			13762560u,
			4194312u,
			15417728u,
			6916368u,
			16613379u,
			7880707u,
			6834356u,
			15687681u,
			13762560u,
			4194312u,
			15417728u,
			6916368u,
			15540234u,
			3866606u,
			15542282u,
			3866596u,
			7864323u,
			393216u,
			2778u,
			2u,
			0u,
			2572u,
			206u,
			0u,
			2060u,
			512u,
			0u,
			2048u,
			12u,
			0u,
			0u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			16777215u,
			203u,
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

		private static ushort[] CRC_LUT_Array = new ushort[256]
		{
			0,
			4129,
			8258,
			12387,
			16516,
			20645,
			24774,
			28903,
			33032,
			37161,
			41290,
			45419,
			49548,
			53677,
			57806,
			61935,
			4657,
			528,
			12915,
			8786,
			21173,
			17044,
			29431,
			25302,
			37689,
			33560,
			45947,
			41818,
			54205,
			50076,
			62463,
			58334,
			9314,
			13379,
			1056,
			5121,
			25830,
			29895,
			17572,
			21637,
			42346,
			46411,
			34088,
			38153,
			58862,
			62927,
			50604,
			54669,
			13907,
			9842,
			5649,
			1584,
			30423,
			26358,
			22165,
			18100,
			46939,
			42874,
			38681,
			34616,
			63455,
			59390,
			55197,
			51132,
			18628,
			22757,
			26758,
			30887,
			2112,
			6241,
			10242,
			14371,
			51660,
			55789,
			59790,
			63919,
			35144,
			39273,
			43274,
			47403,
			23285,
			19156,
			31415,
			27286,
			6769,
			2640,
			14899,
			10770,
			56317,
			52188,
			64447,
			60318,
			39801,
			35672,
			47931,
			43802,
			27814,
			31879,
			19684,
			23749,
			11298,
			15363,
			3168,
			7233,
			60846,
			64911,
			52716,
			56781,
			44330,
			48395,
			36200,
			40265,
			32407,
			28342,
			24277,
			20212,
			15891,
			11826,
			7761,
			3696,
			65439,
			61374,
			57309,
			53244,
			48923,
			44858,
			40793,
			36728,
			37256,
			33193,
			45514,
			41451,
			53516,
			49453,
			61774,
			57711,
			4224,
			161,
			12482,
			8419,
			20484,
			16421,
			28742,
			24679,
			33721,
			37784,
			41979,
			46042,
			49981,
			54044,
			58239,
			62302,
			689,
			4752,
			8947,
			13010,
			16949,
			21012,
			25207,
			29270,
			46570,
			42443,
			38312,
			34185,
			62830,
			58703,
			54572,
			50445,
			13538,
			9411,
			5280,
			1153,
			29798,
			25671,
			21540,
			17413,
			42971,
			47098,
			34713,
			38840,
			59231,
			63358,
			50973,
			55100,
			9939,
			14066,
			1681,
			5808,
			26199,
			30326,
			17941,
			22068,
			55628,
			51565,
			63758,
			59695,
			39368,
			35305,
			47498,
			43435,
			22596,
			18533,
			30726,
			26663,
			6336,
			2273,
			14466,
			10403,
			52093,
			56156,
			60223,
			64286,
			35833,
			39896,
			43963,
			48026,
			19061,
			23124,
			27191,
			31254,
			2801,
			6864,
			10931,
			14994,
			64814,
			60687,
			56684,
			52557,
			48554,
			44427,
			40424,
			36297,
			31782,
			27655,
			23652,
			19525,
			15522,
			11395,
			7392,
			3265,
			61215,
			65342,
			53085,
			57212,
			44955,
			49082,
			36825,
			40952,
			28183,
			32310,
			20053,
			24180,
			11923,
			16050,
			3793,
			7920
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
			uint num2 = 0u;
			int num3 = 0;
			byte[] array = new byte[64];
			for (int i = 0; i < 16; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					num3 = 0;
					if (j == 0)
					{
						array[num3++] = 167;
					}
					array[num3++] = 168;
					array[num3++] = 48;
					for (int k = 0; k < 16; k++)
					{
						array[num3++] = (byte)(dsPIC33_PE_Code[num] & 0xFF);
						array[num3++] = (byte)((dsPIC33_PE_Code[num] >> 8) & 0xFF);
						array[num3++] = (byte)((dsPIC33_PE_Code[num] >> 16) & 0xFF);
						num++;
					}
					num2 = dsPIC33_PE_Code[num - 4];
					for (; num3 < 64; num3++)
					{
						array[num3] = 173;
					}
					PICkitFunctions.writeUSB(array);
				}
				num3 = 0;
				array[num3++] = 166;
				array[num3++] = 0;
				array[num3++] = 212;
				array[num3++] = 0;
				array[num3++] = 211;
				array[num3++] = 1;
				array[num3++] = 212;
				array[num3++] = 3;
				array[num3++] = 211;
				array[num3++] = 2;
				array[num3++] = 217;
				array[num3++] = 128;
				array[num3++] = 11;
				array[num3++] = 187;
				array[num3++] = 216;
				array[num3++] = 216;
				array[num3++] = 217;
				array[num3++] = 129;
				array[num3++] = 155;
				array[num3++] = 187;
				array[num3++] = 216;
				array[num3++] = 216;
				array[num3++] = 217;
				array[num3++] = 130;
				array[num3++] = 139;
				array[num3++] = 187;
				array[num3++] = 216;
				array[num3++] = 216;
				array[num3++] = 217;
				array[num3++] = 131;
				array[num3++] = 27;
				array[num3++] = 187;
				array[num3++] = 216;
				array[num3++] = 216;
				array[num3++] = 233;
				array[num3++] = 32;
				array[num3++] = 31;
				array[num3++] = 217;
				array[num3++] = 136;
				array[num3++] = 0;
				array[num3++] = 32;
				array[num3++] = 217;
				array[num3++] = 7;
				array[num3++] = 4;
				array[num3++] = 20;
				array[1] = (byte)(num3 - 2);
				for (; num3 < 64; num3++)
				{
					array[num3] = 173;
				}
				PICkitFunctions.writeUSB(array);
				num3 = 0;
				array[num3++] = 166;
				array[num3++] = 0;
				array[num3++] = 217;
				array[num3++] = (byte)(num2 << 4);
				array[num3++] = (byte)(num2 >> 4);
				array[num3++] = (byte)(0x20 | (0xF & (num2 >> 12)));
				array[num3++] = 217;
				num2 >>= 16;
				array[num3++] = (byte)(1 | (num2 << 4));
				array[num3++] = (byte)(num2 >> 4);
				array[num3++] = 32;
				array[num3++] = 217;
				array[num3++] = 0;
				array[num3++] = 12;
				array[num3++] = 187;
				array[num3++] = 216;
				array[num3++] = 216;
				array[num3++] = 217;
				array[num3++] = 1;
				array[num3++] = 140;
				array[num3++] = 187;
				array[num3++] = 216;
				array[num3++] = 216;
				array[num3++] = 217;
				array[num3++] = 97;
				array[num3++] = 231;
				array[num3++] = 168;
				array[num3++] = 216;
				array[num3++] = 217;
				array[num3++] = 0;
				array[num3++] = 2;
				array[num3++] = 4;
				array[num3++] = 216;
				array[num3++] = 233;
				array[num3++] = 1;
				array[num3++] = 3;
				array[num3++] = 231;
				array[num3++] = 72;
				array[1] = (byte)(num3 - 2);
				for (; num3 < 64; num3++)
				{
					array[num3] = 173;
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
			for (int l = 0; l < 32; l++)
			{
				PICkitFunctions.RunScriptUploadNoLen(3, 1);
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array2, 0L, 64L);
				PICkitFunctions.UploadDataNoLen();
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array2, 64L, 64L);
				int num4 = 0;
				for (int m = 0; m < 32; m++)
				{
					uint num5 = array2[num4++];
					num5 = (uint)((int)num5 | (array2[num4++] << 8));
					num5 = (uint)((int)num5 | (array2[num4++] << 16));
					if (num5 != dsPIC33_PE_Code[num++])
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
				PICkitFunctions.DownloadAddress3(8390592);
				PICkitFunctions.RunScript(5, 1);
			}
			byte[] array = new byte[128];
			PICkitFunctions.RunScriptUploadNoLen(3, 1);
			Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
			PICkitFunctions.UploadDataNoLen();
			Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
			int num = array[72];
			num |= array[73] << 8;
			if (num != 203)
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

		public static bool PEBlankCheck(uint lengthWords)
		{
			int i = 0;
			byte[] array = new byte[64];
			lengthWords++;
			array[i++] = 166;
			array[i++] = 0;
			array[i++] = 243;
			array[i++] = 0;
			array[i++] = 242;
			array[i++] = 5;
			array[i++] = 242;
			array[i++] = 192;
			array[i++] = 242;
			array[i++] = 0;
			array[i++] = 242;
			array[i++] = BitReverseTable[(lengthWords >> 16) & 0xFF];
			array[i++] = 242;
			array[i++] = BitReverseTable[(lengthWords >> 8) & 0xFF];
			array[i++] = 242;
			array[i++] = BitReverseTable[lengthWords & 0xFF];
			array[i++] = 243;
			array[i++] = 2;
			array[1] = (byte)(i - 2);
			for (; i < 64; i++)
			{
				array[i] = 173;
			}
			PICkitFunctions.writeUSB(array);
			Thread.Sleep(2000);
			i = 0;
			array[i++] = 166;
			array[i++] = 4;
			array[i++] = 240;
			array[i++] = 240;
			array[i++] = 240;
			array[i++] = 240;
			array[i++] = 170;
			for (; i < 64; i++)
			{
				array[i] = 173;
			}
			PICkitFunctions.writeUSB(array);
			if (!PICkitFunctions.readUSB())
			{
				return false;
			}
			if (PICkitFunctions.Usb_read_array[1] != 4 || PICkitFunctions.Usb_read_array[2] != BitReverseTable[26] || PICkitFunctions.Usb_read_array[3] != BitReverseTable[240] || PICkitFunctions.Usb_read_array[4] != 0 || PICkitFunctions.Usb_read_array[5] != BitReverseTable[2])
			{
				return false;
			}
			return true;
		}

		public static bool PE33BlankCheck(string saveText)
		{
			if (!PE_DownloadAndConnect())
			{
				return false;
			}
			UpdateStatusWinText(saveText);
			if (!PEBlankCheck(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem))
			{
				PICkitFunctions.RunScript(1, 1);
				restoreICSPSpeed();
				return false;
			}
			PICkitFunctions.RunScript(1, 1);
			restoreICSPSpeed();
			return true;
		}

		public static bool PE33Read(string saveText)
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

		public static bool PE33Write(int endOfBuffer, string saveText)
		{
			if (!PE_DownloadAndConnect())
			{
				return false;
			}
			UpdateStatusWinText(saveText);
			byte[] array = new byte[256];
			int num = 64;
			int num2 = 0;
			ResetStatusBar(endOfBuffer / num);
			do
			{
				int num3 = 0;
				for (int i = 0; i < num; i += 2)
				{
					uint num4 = PICkitFunctions.DeviceBuffers.ProgramMemory[num2++];
					array[num3 + 1] = BitReverseTable[num4 & 0xFF];
					num4 >>= 8;
					array[num3] = BitReverseTable[num4 & 0xFF];
					num4 >>= 8;
					array[num3 + 3] = BitReverseTable[num4 & 0xFF];
					num4 = PICkitFunctions.DeviceBuffers.ProgramMemory[num2++];
					array[num3 + 5] = BitReverseTable[num4 & 0xFF];
					num4 >>= 8;
					array[num3 + 4] = BitReverseTable[num4 & 0xFF];
					num4 >>= 8;
					array[num3 + 2] = BitReverseTable[num4 & 0xFF];
					num3 += 6;
				}
				for (int num5 = PICkitFunctions.DataClrAndDownload(array, 0); num5 < num3; num5 = PICkitFunctions.DataDownload(array, num5, num3))
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
				array2[j++] = BitReverseTable[(num2 - 64 >> 15) & 0xFF];
				array2[j++] = 242;
				array2[j++] = BitReverseTable[(num2 - 64 >> 7) & 0xFF];
				array2[j++] = 242;
				array2[j++] = BitReverseTable[(num2 - 64 << 1) & 0xFF];
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
			while (num2 < endOfBuffer);
			PICkitFunctions.RunScript(1, 1);
			restoreICSPSpeed();
			return true;
		}

		public static bool PE33VerifyCRC(string saveText)
		{
			if (!PE_DownloadAndConnect())
			{
				return false;
			}
			UpdateStatusWinText(saveText);
			int i = 0;
			byte[] array = new byte[64];
			ushort num = CalcCRCProgMem();
			uint programMem = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem;
			array[i++] = 166;
			array[i++] = 0;
			array[i++] = 243;
			array[i++] = 0;
			array[i++] = 242;
			array[i++] = 3;
			array[i++] = 242;
			array[i++] = 160;
			array[i++] = 242;
			array[i++] = 128;
			array[i++] = 242;
			array[i++] = 0;
			array[i++] = 242;
			array[i++] = 0;
			array[i++] = 242;
			array[i++] = 0;
			array[i++] = 242;
			array[i++] = 0;
			array[i++] = 242;
			array[i++] = BitReverseTable[(programMem >> 16) & 0xFF];
			array[i++] = 242;
			array[i++] = BitReverseTable[(programMem >> 8) & 0xFF];
			array[i++] = 242;
			array[i++] = BitReverseTable[programMem & 0xFF];
			array[i++] = 243;
			array[i++] = 2;
			array[1] = (byte)(i - 2);
			for (; i < 64; i++)
			{
				array[i] = 173;
			}
			PICkitFunctions.writeUSB(array);
			float num2 = (float)(double)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem * 0.0340661332f;
			Thread.Sleep((int)num2);
			i = 0;
			array[i++] = 166;
			array[i++] = 6;
			array[i++] = 240;
			array[i++] = 240;
			array[i++] = 240;
			array[i++] = 240;
			array[i++] = 240;
			array[i++] = 240;
			array[i++] = 170;
			for (; i < 64; i++)
			{
				array[i] = 173;
			}
			PICkitFunctions.writeUSB(array);
			if (!PICkitFunctions.readUSB())
			{
				PICkitFunctions.RunScript(1, 1);
				restoreICSPSpeed();
				return false;
			}
			if (PICkitFunctions.Usb_read_array[1] != 6)
			{
				PICkitFunctions.RunScript(1, 1);
				restoreICSPSpeed();
				return false;
			}
			PICkitFunctions.RunScript(1, 1);
			restoreICSPSpeed();
			ushort num3 = BitReverseTable[PICkitFunctions.Usb_read_array[7]];
			num3 = (ushort)(num3 + (ushort)(BitReverseTable[PICkitFunctions.Usb_read_array[6]] << 8));
			if (num3 == num)
			{
				return true;
			}
			return false;
		}

		private static ushort CalcCRCProgMem()
		{
			uint CRC_Value = 65535u;
			for (int i = 0; i < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem; i += 2)
			{
				uint num = PICkitFunctions.DeviceBuffers.ProgramMemory[i];
				CRC_Calculate((byte)(num & 0xFF), ref CRC_Value);
				CRC_Calculate((byte)((num >> 8) & 0xFF), ref CRC_Value);
				CRC_Calculate((byte)((num >> 16) & 0xFF), ref CRC_Value);
				num = PICkitFunctions.DeviceBuffers.ProgramMemory[i + 1];
				CRC_Calculate((byte)((num >> 16) & 0xFF), ref CRC_Value);
				CRC_Calculate((byte)(num & 0xFF), ref CRC_Value);
				CRC_Calculate((byte)((num >> 8) & 0xFF), ref CRC_Value);
			}
			return (ushort)(CRC_Value & 0xFFFF);
		}

		private static void CRC_Calculate(byte ByteValue, ref uint CRC_Value)
		{
			byte b = (byte)((CRC_Value >> 8) ^ ByteValue);
			CRC_Value = (CRC_LUT_Array[b] ^ (CRC_Value << 8));
		}
	}
}
