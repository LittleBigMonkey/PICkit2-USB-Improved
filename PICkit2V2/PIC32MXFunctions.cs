using System;
using System.Threading;

namespace PICkit2V2
{
	public class PIC32MXFunctions
	{
		private const int pic32_PE_Version = 265;

		public static DelegateStatusWin UpdateStatusWinText;

		public static DelegateResetStatusBar ResetStatusBar;

		public static DelegateStepStatusBar StepStatusBar;

		private static uint[] pe_Loader = new uint[42]
		{
			15367u,
			57005u,
			15366u,
			65312u,
			15365u,
			65312u,
			36036u,
			0u,
			36035u,
			0u,
			4199u,
			11u,
			0u,
			0u,
			4192u,
			65531u,
			0u,
			0u,
			36002u,
			0u,
			9315u,
			65535u,
			44162u,
			0u,
			9348u,
			4u,
			5216u,
			65531u,
			0u,
			0u,
			4096u,
			65523u,
			0u,
			0u,
			15362u,
			40960u,
			13378u,
			2304u,
			64u,
			8u,
			0u,
			0u
		};

		private static uint[] PIC32_PE = new uint[1231]
		{
			1008508928u,
			664567792u,
			1008574464u,
			935135484u,
			1007198208u,
			621285532u,
			16777224u,
			0u,
			1007075208u,
			2429051232u,
			1007009672u,
			889651264u,
			2697421152u,
			2426691904u,
			604176319u,
			8525860u,
			2695061824u,
			65011720u,
			0u,
			1007075208u,
			2429051232u,
			604372927u,
			17119268u,
			2697421152u,
			1006878600u,
			2422497600u,
			8720420u,
			2690801984u,
			65011720u,
			0u,
			1007075208u,
			2429051233u,
			1007009672u,
			889651201u,
			2697421153u,
			2426691905u,
			604176382u,
			8525860u,
			2695061825u,
			65011720u,
			0u,
			1007075208u,
			2429051233u,
			604372990u,
			17119268u,
			2697421153u,
			1006878600u,
			2422497601u,
			8720420u,
			2690801985u,
			65011720u,
			0u,
			338050u,
			278921243u,
			14369u,
			1007034304u,
			1006878656u,
			1006796799u,
			885600252u,
			879243260u,
			877395967u,
			268435462u,
			604700671u,
			2358837248u,
			388694030u,
			0u,
			281018382u,
			612630532u,
			9027622u,
			8943654u,
			789381121u,
			770572289u,
			619118593u,
			28205093u,
			360775668u,
			15020075u,
			2357329920u,
			273350644u,
			0u,
			65011720u,
			604110849u,
			65011720u,
			4129u,
			1006960416u,
			2357395456u,
			744620034u,
			272629763u,
			604241921u,
			2944630804u,
			8225u,
			65011720u,
			8392737u,
			278921223u,
			1006829344u,
			876806156u,
			2357592064u,
			614858751u,
			2892365824u,
			346095612u,
			612630532u,
			65011720u,
			0u,
			134219008u,
			0u,
			666763216u,
			2947874852u,
			2947809312u,
			2947678232u,
			2948530220u,
			2947940392u,
			2947743772u,
			2947612692u,
			2947547152u,
			10526753u,
			8425505u,
			278921252u,
			1008074528u,
			1006772223u,
			878116863u,
			713228417u,
			605225088u,
			42178571u,
			1255466u,
			278921224u,
			1007067136u,
			616825360u,
			39852065u,
			2393309184u,
			610533375u,
			2894528512u,
			341901308u,
			612630532u,
			604242048u,
			1382285341u,
			1007001600u,
			278921229u,
			34849u,
			1007263744u,
			623903248u,
			2382692352u,
			37756961u,
			201327872u,
			640745473u,
			638582788u,
			36902954u,
			339738631u,
			642908164u,
			1415643128u,
			2382692352u,
			43229219u,
			377552865u,
			713228417u,
			4129u,
			2411659308u,
			2411069480u,
			2411003940u,
			2410938400u,
			2410872860u,
			2410807320u,
			2410741780u,
			2410676240u,
			65011720u,
			666697776u,
			614662672u,
			73400323u,
			46344228u,
			1007173632u,
			6826017u,
			201327880u,
			37756961u,
			339804142u,
			43229219u,
			377552842u,
			642908672u,
			268500970u,
			4129u,
			1006804992u,
			608633360u,
			1007091488u,
			14690337u,
			604176511u,
			2361917440u,
			610533375u,
			2896691200u,
			73531388u,
			614793220u,
			1007042560u,
			14686241u,
			81854468u,
			15083553u,
			1006968831u,
			883425279u,
			6760484u,
			134219016u,
			0u,
			666763232u,
			2947678232u,
			2947612692u,
			2947547152u,
			2948530204u,
			10522657u,
			8421409u,
			346030087u,
			34849u,
			2411659292u,
			2410807320u,
			2410741780u,
			2410676240u,
			65011720u,
			666697760u,
			33562657u,
			201327888u,
			640745473u,
			638586880u,
			272695285u,
			36837419u,
			341901306u,
			33562657u,
			2411659292u,
			2410807320u,
			2410741780u,
			2410676240u,
			65011720u,
			666697760u,
			134219030u,
			0u,
			2407694356u,
			666763192u,
			2948005948u,
			2947940408u,
			2947547168u,
			2948530240u,
			2947874868u,
			2947809328u,
			2947743788u,
			2947678248u,
			2947612708u,
			8421409u,
			10532897u,
			12628001u,
			2745171992u,
			272629825u,
			2745171993u,
			363010u,
			1006960641u,
			604638976u,
			1007402888u,
			1007271816u,
			872973519u,
			1007075208u,
			883167265u,
			1006878600u,
			2909417524u,
			2905223224u,
			2898800704u,
			2892247120u,
			438304790u,
			853934335u,
			1007108095u,
			888537087u,
			1007984640u,
			1007927296u,
			605159427u,
			45115435u,
			34889765u,
			34809889u,
			604438530u,
			26028042u,
			46145569u,
			604373248u,
			201328002u,
			2947678224u,
			4208673u,
			640811007u,
			339738683u,
			638583040u,
			505479155u,
			45115435u,
			853934335u,
			281018382u,
			1007828991u,
			911343615u,
			1007656960u,
			36728875u,
			297795587u,
			34547749u,
			1007927296u,
			34809889u,
			604438530u,
			46145569u,
			605028355u,
			201328002u,
			2947547152u,
			4208673u,
			283115571u,
			604110849u,
			2411659328u,
			2411135036u,
			2411069496u,
			2411003956u,
			2410938416u,
			2410872876u,
			2410807336u,
			2410741796u,
			2410676256u,
			65011720u,
			666697800u,
			201327956u,
			872742911u,
			1008680959u,
			939130879u,
			1008246784u,
			53520427u,
			312475651u,
			35135525u,
			1006813184u,
			33693729u,
			201327979u,
			48244769u,
			201328000u,
			0u,
			2931949568u,
			2411659328u,
			2411135036u,
			2411069496u,
			2411003956u,
			2410938416u,
			2410872876u,
			2410807336u,
			2410741796u,
			2410676256u,
			4129u,
			65011720u,
			666697800u,
			2411659328u,
			2411135036u,
			2411069496u,
			2411003956u,
			2410938416u,
			2410872876u,
			2410807336u,
			2410741796u,
			2410676256u,
			604110849u,
			65011720u,
			666697800u,
			46145569u,
			665124888u,
			605290499u,
			604372994u,
			604438530u,
			201328002u,
			2947809296u,
			2411659328u,
			2411135036u,
			2411069496u,
			2411003956u,
			2410938416u,
			2410872876u,
			2410807336u,
			2410741796u,
			2410676256u,
			135211u,
			65011720u,
			666697800u,
			666763208u,
			2948005932u,
			2947874852u,
			2947743772u,
			2947678232u,
			2947612692u,
			2947547152u,
			2948530228u,
			2948464688u,
			2947940392u,
			2947809312u,
			10520609u,
			8425505u,
			43041u,
			605487105u,
			1007746848u,
			278921273u,
			38945u,
			1006804992u,
			1006837759u,
			609616400u,
			880738303u,
			46145569u,
			604176511u,
			2382692352u,
			610533375u,
			2894397440u,
			73531388u,
			612630532u,
			316670022u,
			0u,
			47137u,
			642055680u,
			9803787u,
			1449132041u,
			640810880u,
			1007173632u,
			64368676u,
			18229281u,
			717684736u,
			13051915u,
			201327896u,
			37756961u,
			640810880u,
			707330176u,
			354418714u,
			642908672u,
			1007394816u,
			627711032u,
			2371092480u,
			604176511u,
			41951265u,
			2383151104u,
			610533375u,
			2894856192u,
			73531388u,
			612630532u,
			201327916u,
			0u,
			642645504u,
			27432971u,
			375390216u,
			4237345u,
			1008222208u,
			714014720u,
			64253988u,
			51652641u,
			30353419u,
			201327896u,
			37756961u,
			640810880u,
			642908672u,
			371261390u,
			46145569u,
			201327916u,
			1286187u,
			165931u,
			36995109u,
			301989913u,
			1008205600u,
			1008140064u,
			918814732u,
			605356034u,
			2895446016u,
			1382023202u,
			643038720u,
			2895314944u,
			2411659316u,
			2411593776u,
			2411135020u,
			2411069480u,
			2411003940u,
			2410938400u,
			2410872860u,
			2410807320u,
			2410741780u,
			2410676240u,
			4129u,
			65011720u,
			666697784u,
			201327916u,
			0u,
			268500921u,
			4237345u,
			921829388u,
			2923429888u,
			2411659316u,
			2411593776u,
			2411135020u,
			2411069480u,
			2411003940u,
			2410938400u,
			2410872860u,
			2410807320u,
			2410741780u,
			2410676240u,
			4129u,
			65011720u,
			666697784u,
			2895314944u,
			268500959u,
			2411659316u,
			666763200u,
			1006813064u,
			604245955u,
			2948530232u,
			2947612724u,
			2947547184u,
			2890149936u,
			2353213488u,
			274989232u,
			604307457u,
			2944434196u,
			1007271808u,
			891875872u,
			2366046208u,
			1007067136u,
			2096184064u,
			617618420u,
			1007550240u,
			2376859648u,
			604700673u,
			799746u,
			830865407u,
			751435792u,
			2945155088u,
			2946891792u,
			289406982u,
			2946826260u,
			442496u,
			51410977u,
			2381185024u,
			29360136u,
			0u,
			604307459u,
			606011407u,
			816119807u,
			283050017u,
			1006829583u,
			604176391u,
			281215102u,
			604438538u,
			281477252u,
			604700674u,
			281804774u,
			424960u,
			905510914u,
			1008271136u,
			52787211u,
			923140108u,
			2899247104u,
			2409824272u,
			748945409u,
			946733057u,
			768409601u,
			27549732u,
			360710269u,
			945946632u,
			742588417u,
			6617124u,
			1407254487u,
			1007550240u,
			2409889832u,
			2898526208u,
			268500947u,
			1007550240u,
			2407890964u,
			606011407u,
			816119807u,
			350224353u,
			1006829583u,
			1006829344u,
			8593445u,
			877002764u,
			2898526208u,
			268500936u,
			1007550240u,
			201327251u,
			0u,
			2410020880u,
			268500946u,
			4204577u,
			268500944u,
			10273u,
			1007550240u,
			2376335360u,
			2946760728u,
			2376859648u,
			809090u,
			23078945u,
			201327272u,
			2947219476u,
			2410020880u,
			268500933u,
			4204577u,
			2946498600u,
			1008336672u,
			2401501184u,
			665190440u,
			2946760728u,
			2402811904u,
			50341921u,
			201327394u,
			2948071444u,
			2410020880u,
			268500921u,
			4204577u,
			268500919u,
			604307721u,
			1007681312u,
			2380529664u,
			2946760728u,
			2381185024u,
			29370401u,
			201327220u,
			2947416084u,
			2410020880u,
			268500909u,
			4204577u,
			1006829344u,
			2353397760u,
			12591137u,
			201327363u,
			2946891800u,
			2410020880u,
			268500901u,
			4204577u,
			201327392u,
			0u,
			2410020880u,
			268500896u,
			4204577u,
			1008729888u,
			2414084096u,
			2946760728u,
			2415460352u,
			52439073u,
			201327270u,
			2948136988u,
			2410020880u,
			268500886u,
			4204577u,
			1007353632u,
			2370043904u,
			2946760728u,
			2370371584u,
			606338u,
			16787489u,
			201327533u,
			2947022868u,
			2410020880u,
			268500875u,
			4204577u,
			1007025952u,
			2359754752u,
			604307458u,
			469003u,
			268500869u,
			2946957336u,
			1006960416u,
			2357395456u,
			6299681u,
			201327344u,
			2946695192u,
			2410020880u,
			268500861u,
			4204577u,
			816119807u,
			1006829575u,
			1006829344u,
			8593445u,
			877002764u,
			2898526208u,
			268500838u,
			1007550240u,
			1007288330u,
			1007288096u,
			36323365u,
			891617292u,
			2896691200u,
			268500831u,
			1007550240u,
			2409889816u,
			201327260u,
			2409955348u,
			268500826u,
			1007550240u,
			268500817u,
			2944761876u,
			65011720u,
			4129u,
			881082368u,
			1007009665u,
			2896491520u,
			1007206272u,
			889779200u,
			1007266457u,
			891905621u,
			1007310182u,
			894081450u,
			1007353856u,
			896237568u,
			2903048208u,
			2903113744u,
			2903179272u,
			2359555072u,
			811761664u,
			339804157u,
			0u,
			0u,
			0u,
			0u,
			0u,
			604520448u,
			1007140737u,
			2900947972u,
			2359751680u,
			65011720u,
			818028544u,
			8400929u,
			1006813057u,
			1006878593u,
			604241921u,
			2890331168u,
			2892362800u,
			134218980u,
			0u,
			8400929u,
			1006813057u,
			1006878593u,
			604241923u,
			2890331168u,
			2892362816u,
			134218980u,
			0u,
			8394785u,
			1006813057u,
			604241924u,
			2890134560u,
			134218980u,
			0u,
			134218980u,
			604241934u,
			1007075201u,
			2898588704u,
			1006878593u,
			604258307u,
			1006813057u,
			2892362816u,
			2890200064u,
			1007206272u,
			889779200u,
			1007266457u,
			891905621u,
			1007310182u,
			894081450u,
			1007353856u,
			896237568u,
			2903048208u,
			2903113744u,
			2903179272u,
			65011720u,
			4129u,
			1006944129u,
			2357457920u,
			811761664u,
			339804157u,
			0u,
			0u,
			0u,
			0u,
			0u,
			604454912u,
			1007075201u,
			2898785284u,
			2357588992u,
			65011720u,
			815931392u,
			1006804992u,
			608764432u,
			16417u,
			532992u,
			813957119u,
			10273u,
			604372999u,
			352320u,
			10704934u,
			965152801u,
			2081117728u,
			88080386u,
			820379647u,
			830865407u,
			223296u,
			617021439u,
			79822838u,
			832831487u,
			621281281u,
			688062720u,
			2904883200u,
			341901293u,
			623443972u,
			65011720u,
			0u,
			666763240u,
			2948530192u,
			2810478620u,
			201327931u,
			2944434200u,
			2411659280u,
			604110849u,
			666697752u,
			65011720u,
			2944565272u,
			2542174236u,
			814416127u,
			2093758976u,
			23875622u,
			1007263744u,
			669824u,
			623378960u,
			15212577u,
			2357526528u,
			397824u,
			4528166u,
			65011720u,
			2810413084u,
			666763232u,
			2947612692u,
			2947547152u,
			2948530204u,
			2947678232u,
			8423457u,
			278921224u,
			615579647u,
			605224959u,
			2451832832u,
			638648319u,
			201327966u,
			640745473u,
			1444085756u,
			2451832832u,
			2411659292u,
			2410807320u,
			2410741780u,
			2410676240u,
			65011720u,
			666697760u,
			65011720u,
			2541912092u,
			604504256u,
			1894303746u,
			666763240u,
			2948530192u,
			1008705536u,
			2414418996u,
			1007468424u,
			604635264u,
			2911514676u,
			53035041u,
			2434269184u,
			14702625u,
			2131689920u,
			604569664u,
			604901376u,
			1007533960u,
			872644608u,
			1006813064u,
			770113537u,
			2903048216u,
			2913873924u,
			2890084360u,
			283115523u,
			0u,
			2903113736u,
			2903048216u,
			2433155072u,
			2095710656u,
			356581373u,
			2411200552u,
			604962872u,
			604962815u,
			604831747u,
			2904031232u,
			1006813064u,
			2903441428u,
			895680704u,
			2903375908u,
			2911711284u,
			1007435776u,
			2890084408u,
			77660164u,
			11276321u,
			1008279551u,
			925499391u,
			11079716u,
			1006977024u,
			2902589488u,
			75563012u,
			8720417u,
			1007296511u,
			895483903u,
			10424356u,
			2902589504u,
			2902851728u,
			2366046352u,
			23076897u,
			2902917216u,
			2365980768u,
			604307458u,
			2902851664u,
			201328068u,
			12321u,
			2411659280u,
			65011720u,
			666697752u,
			604569792u,
			1888040962u,
			1007329280u,
			2370313268u,
			604176512u,
			15212577u,
			604111103u,
			2894200868u,
			20513u,
			2894266376u,
			423979u,
			2894266392u,
			278921273u,
			0u,
			604700673u,
			279642134u,
			604176385u,
			2357985360u,
			293601282u,
			604504320u,
			2357723216u,
			2358050912u,
			295698434u,
			604438784u,
			2357657696u,
			2358116496u,
			297795588u,
			604176640u,
			2357395600u,
			268435458u,
			17240107u,
			17240107u,
			16922634u,
			14927905u,
			658046975u,
			50528283u,
			6291956u,
			6162u,
			610861055u,
			604897281u,
			604831748u,
			604766336u,
			604766207u,
			2357395488u,
			813170691u,
			2087256192u,
			318767110u,
			2087125184u,
			2086928384u,
			276824084u,
			604635138u,
			268435474u,
			604635137u,
			350224400u,
			0u,
			287309832u,
			0u,
			279838732u,
			0u,
			1358954506u,
			604635139u,
			621346815u,
			2894921764u,
			2894856216u,
			299958250u,
			0u,
			617021439u,
			348913639u,
			0u,
			604635141u,
			65011720u,
			20975649u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			0u,
			17419691u,
			2684359440u,
			2684359416u,
			2684359372u,
			2684359332u,
			2684359312u,
			2684359280u,
			2684359240u,
			2684359232u,
			2684359184u,
			2684359140u,
			2684359132u,
			2684359112u,
			2684358940u,
			2684358940u,
			2684358940u,
			2684359068u,
			3213373536u,
			2684354576u
		};

		public static void EnterSerialExecution()
		{
			int num = 0;
			byte[] array = new byte[29];
			array[num++] = 166;
			array[num++] = 27;
			array[num++] = 187;
			array[num++] = 4;
			array[num++] = 187;
			array[num++] = 7;
			array[num++] = 186;
			array[num++] = 0;
			array[num++] = 187;
			array[num++] = 4;
			array[num++] = 187;
			array[num++] = 7;
			array[num++] = 186;
			array[num++] = 209;
			array[num++] = 187;
			array[num++] = 5;
			array[num++] = 188;
			array[num++] = 6;
			array[num++] = 31;
			array[num++] = 187;
			array[num++] = 12;
			array[num++] = 187;
			array[num++] = 4;
			array[num++] = 187;
			array[num++] = 7;
			array[num++] = 186;
			array[num++] = 208;
			array[num++] = 186;
			array[num++] = 254;
			PICkitFunctions.writeUSB(array);
		}

		public static bool DownloadPE()
		{
			int offset = 0;
			byte[] array = new byte[64];
			array[offset++] = 167;
			array[offset++] = 168;
			array[offset++] = 28;
			offset = addInstruction(array, 1006944136u, offset);
			offset = addInstruction(array, 881074176u, offset);
			offset = addInstruction(array, 1006960671u, offset);
			offset = addInstruction(array, 883228736u, offset);
			offset = addInstruction(array, 2894397440u, offset);
			offset = addInstruction(array, 872744960u, offset);
			offset = addInstruction(array, 2894397456u, offset);
			array[offset++] = 166;
			array[offset++] = 12;
			array[offset++] = 187;
			array[offset++] = 5;
			array[offset++] = 188;
			array[offset++] = 6;
			array[offset++] = 31;
			array[offset++] = 182;
			array[offset++] = 182;
			array[offset++] = 182;
			array[offset++] = 182;
			array[offset++] = 182;
			array[offset++] = 182;
			array[offset++] = 182;
			for (; offset < 64; offset++)
			{
				array[offset] = 173;
			}
			PICkitFunctions.writeUSB(array);
			if (PICkitFunctions.BusErrorCheck())
			{
				return false;
			}
			offset = 0;
			array[offset++] = 167;
			array[offset++] = 168;
			array[offset++] = 20;
			offset = addInstruction(array, 872775680u, offset);
			offset = addInstruction(array, 2894397472u, offset);
			offset = addInstruction(array, 2894397488u, offset);
			offset = addInstruction(array, 1006936064u, offset);
			offset = addInstruction(array, 881068032u, offset);
			array[offset++] = 166;
			array[offset++] = 5;
			array[offset++] = 182;
			array[offset++] = 182;
			array[offset++] = 182;
			array[offset++] = 182;
			array[offset++] = 182;
			for (; offset < 64; offset++)
			{
				array[offset] = 173;
			}
			PICkitFunctions.writeUSB(array);
			if (PICkitFunctions.BusErrorCheck())
			{
				return false;
			}
			for (int i = 0; i < pe_Loader.Length; i += 2)
			{
				offset = 0;
				array[offset++] = 167;
				array[offset++] = 168;
				array[offset++] = 16;
				offset = addInstruction(array, 0x3C060000 | pe_Loader[i], offset);
				offset = addInstruction(array, 0x34C60000 | pe_Loader[i + 1], offset);
				offset = addInstruction(array, 2894462976u, offset);
				offset = addInstruction(array, 612630532u, offset);
				array[offset++] = 166;
				array[offset++] = 4;
				array[offset++] = 182;
				array[offset++] = 182;
				array[offset++] = 182;
				array[offset++] = 182;
				for (; offset < 64; offset++)
				{
					array[offset] = 173;
				}
				PICkitFunctions.writeUSB(array);
				if (PICkitFunctions.BusErrorCheck())
				{
					return false;
				}
			}
			offset = 0;
			array[offset++] = 167;
			array[offset++] = 168;
			array[offset++] = 16;
			offset = addInstruction(array, 1008312320u, offset);
			offset = addInstruction(array, 926484480u, offset);
			offset = addInstruction(array, 52428808u, offset);
			offset = addInstruction(array, 0u, offset);
			array[offset++] = 166;
			array[offset++] = 21;
			array[offset++] = 182;
			array[offset++] = 182;
			array[offset++] = 182;
			array[offset++] = 182;
			array[offset++] = 187;
			array[offset++] = 5;
			array[offset++] = 188;
			array[offset++] = 6;
			array[offset++] = 31;
			array[offset++] = 187;
			array[offset++] = 14;
			array[offset++] = 184;
			array[offset++] = 0;
			array[offset++] = 9;
			array[offset++] = 0;
			array[offset++] = 160;
			array[offset++] = 184;
			array[offset++] = (byte)(PIC32_PE.Length & 0xFF);
			array[offset++] = (byte)((PIC32_PE.Length >> 8) & 0xFF);
			array[offset++] = 0;
			array[offset++] = 0;
			for (; offset < 64; offset++)
			{
				array[offset] = 173;
			}
			PICkitFunctions.writeUSB(array);
			if (PICkitFunctions.BusErrorCheck())
			{
				return false;
			}
			int num = PIC32_PE.Length / 10;
			int j = 0;
			int num2 = 0;
			for (; j < num; j++)
			{
				offset = 0;
				array[offset++] = 167;
				array[offset++] = 168;
				array[offset++] = 40;
				num2 = j * 10;
				offset = addInstruction(array, PIC32_PE[num2], offset);
				offset = addInstruction(array, PIC32_PE[num2 + 1], offset);
				offset = addInstruction(array, PIC32_PE[num2 + 2], offset);
				offset = addInstruction(array, PIC32_PE[num2 + 3], offset);
				offset = addInstruction(array, PIC32_PE[num2 + 4], offset);
				offset = addInstruction(array, PIC32_PE[num2 + 5], offset);
				offset = addInstruction(array, PIC32_PE[num2 + 6], offset);
				offset = addInstruction(array, PIC32_PE[num2 + 7], offset);
				offset = addInstruction(array, PIC32_PE[num2 + 8], offset);
				offset = addInstruction(array, PIC32_PE[num2 + 9], offset);
				array[offset++] = 166;
				array[offset++] = 10;
				array[offset++] = 183;
				array[offset++] = 183;
				array[offset++] = 183;
				array[offset++] = 183;
				array[offset++] = 183;
				array[offset++] = 183;
				array[offset++] = 183;
				array[offset++] = 183;
				array[offset++] = 183;
				array[offset++] = 183;
				for (; offset < 64; offset++)
				{
					array[offset] = 173;
				}
				PICkitFunctions.writeUSB(array);
				if (PICkitFunctions.BusErrorCheck())
				{
					return false;
				}
			}
			Thread.Sleep(100);
			int num3 = num * 10;
			num = PIC32_PE.Length % 10;
			if (num > 0)
			{
				offset = 0;
				array[offset++] = 167;
				array[offset++] = 168;
				array[offset++] = (byte)(4 * num);
				for (int k = 0; k < num; k++)
				{
					offset = addInstruction(array, PIC32_PE[k + num3], offset);
				}
				array[offset++] = 166;
				array[offset++] = (byte)num;
				for (int l = 0; l < num; l++)
				{
					array[offset++] = 183;
				}
				for (; offset < 64; offset++)
				{
					array[offset] = 173;
				}
				PICkitFunctions.writeUSB(array);
				if (PICkitFunctions.BusErrorCheck())
				{
					return false;
				}
			}
			offset = 0;
			array[offset++] = 167;
			array[offset++] = 168;
			array[offset++] = 8;
			offset = addInstruction(array, 0u, offset);
			offset = addInstruction(array, 3735879680u, offset);
			array[offset++] = 166;
			array[offset++] = 2;
			array[offset++] = 183;
			array[offset++] = 183;
			for (; offset < 64; offset++)
			{
				array[offset] = 173;
			}
			PICkitFunctions.writeUSB(array);
			if (PICkitFunctions.BusErrorCheck())
			{
				return false;
			}
			Thread.Sleep(100);
			return true;
		}

		public static int ReadPEVersion()
		{
			byte[] array = new byte[11];
			int num = 0;
			array[num++] = 169;
			array[num++] = 166;
			array[num++] = 8;
			array[num++] = 187;
			array[num++] = 14;
			array[num++] = 184;
			array[num++] = 0;
			array[num++] = 0;
			array[num++] = 7;
			array[num++] = 0;
			array[num++] = 181;
			PICkitFunctions.writeUSB(array);
			if (PICkitFunctions.BusErrorCheck())
			{
				return 0;
			}
			if (!PICkitFunctions.UploadData())
			{
				return 0;
			}
			int num2 = PICkitFunctions.Usb_read_array[4] + PICkitFunctions.Usb_read_array[5] * 256;
			if (num2 != 7)
			{
				return 0;
			}
			return PICkitFunctions.Usb_read_array[2] + PICkitFunctions.Usb_read_array[3] * 256;
		}

		public static bool PEBlankCheck(uint startAddress, uint lengthBytes)
		{
			byte[] array = new byte[21];
			int num = 0;
			array[num++] = 169;
			array[num++] = 166;
			array[num++] = 18;
			array[num++] = 187;
			array[num++] = 14;
			array[num++] = 184;
			array[num++] = 0;
			array[num++] = 0;
			array[num++] = 6;
			array[num++] = 0;
			array[num++] = 184;
			array[num++] = (byte)(startAddress & 0xFF);
			array[num++] = (byte)((startAddress >> 8) & 0xFF);
			array[num++] = (byte)((startAddress >> 16) & 0xFF);
			array[num++] = (byte)((startAddress >> 24) & 0xFF);
			array[num++] = 184;
			array[num++] = (byte)(lengthBytes & 0xFF);
			array[num++] = (byte)((lengthBytes >> 8) & 0xFF);
			array[num++] = (byte)((lengthBytes >> 16) & 0xFF);
			array[num++] = (byte)((lengthBytes >> 24) & 0xFF);
			array[num++] = 181;
			PICkitFunctions.writeUSB(array);
			if (PICkitFunctions.BusErrorCheck())
			{
				return false;
			}
			if (!PICkitFunctions.UploadData())
			{
				return false;
			}
			if (PICkitFunctions.Usb_read_array[4] != 6 || PICkitFunctions.Usb_read_array[2] != 0)
			{
				return false;
			}
			return true;
		}

		public static int PEGetCRC(uint startAddress, uint lengthBytes)
		{
			byte[] array = new byte[20];
			int num = 0;
			array[num++] = 169;
			array[num++] = 166;
			array[num++] = 17;
			array[num++] = 187;
			array[num++] = 14;
			array[num++] = 184;
			array[num++] = 0;
			array[num++] = 0;
			array[num++] = 8;
			array[num++] = 0;
			array[num++] = 184;
			array[num++] = (byte)(startAddress & 0xFF);
			array[num++] = (byte)((startAddress >> 8) & 0xFF);
			array[num++] = (byte)((startAddress >> 16) & 0xFF);
			array[num++] = (byte)((startAddress >> 24) & 0xFF);
			array[num++] = 184;
			array[num++] = (byte)(lengthBytes & 0xFF);
			array[num++] = (byte)((lengthBytes >> 8) & 0xFF);
			array[num++] = (byte)((lengthBytes >> 16) & 0xFF);
			array[num++] = (byte)((lengthBytes >> 24) & 0xFF);
			PICkitFunctions.writeUSB(array);
			byte[] array2 = new byte[5];
			num = 0;
			array2[num++] = 169;
			array2[num++] = 166;
			array2[num++] = 2;
			array2[num++] = 181;
			array2[num++] = 181;
			PICkitFunctions.writeUSB(array2);
			if (PICkitFunctions.BusErrorCheck())
			{
				return 0;
			}
			if (!PICkitFunctions.UploadData())
			{
				return 0;
			}
			if (PICkitFunctions.Usb_read_array[4] != 8 || PICkitFunctions.Usb_read_array[2] != 0)
			{
				return 0;
			}
			return PICkitFunctions.Usb_read_array[6] + (PICkitFunctions.Usb_read_array[7] << 8);
		}

		private static int addInstruction(byte[] commandarray, uint instruction, int offset)
		{
			commandarray[offset++] = (byte)(instruction & 0xFF);
			commandarray[offset++] = (byte)((instruction >> 8) & 0xFF);
			commandarray[offset++] = (byte)((instruction >> 16) & 0xFF);
			commandarray[offset++] = (byte)((instruction >> 24) & 0xFF);
			return offset;
		}

		public static bool PE_DownloadAndConnect()
		{
			UpdateStatusWinText("Downloading Programming Executive...");
			PICkitFunctions.RunScript(0, 1);
			PICkitFunctions.UploadData();
			if ((PICkitFunctions.Usb_read_array[2] & 0x80) == 0)
			{
				UpdateStatusWinText("Device is Code Protected and must be Erased first.");
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			EnterSerialExecution();
			DownloadPE();
			int num = ReadPEVersion();
			if (num != 265)
			{
				UpdateStatusWinText("Downloading Programming Executive...FAILED!");
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			return true;
		}

		public static bool PIC32Read()
		{
			PICkitFunctions.SetMCLRTemp(nMCLR: true);
			PICkitFunctions.VddOn();
			if (!PE_DownloadAndConnect())
			{
				return false;
			}
			string text = "Reading device:\n";
			UpdateStatusWinText(text);
			byte[] array = new byte[128];
			int programMem = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem;
			int bootFlash = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BootFlash;
			programMem -= bootFlash;
			text += "Program Flash... ";
			UpdateStatusWinText(text);
			int bytesPerLocation = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
			int num = 128 / (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemRdWords * bytesPerLocation);
			int num2 = num * PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemRdWords;
			int num3 = 0;
			ResetStatusBar(programMem / num2);
			int num4 = 0;
			do
			{
				int num5 = (programMem - num3) / num2;
				if (num5 > 15)
				{
					num5 = 15;
				}
				uint num6 = (uint)(num3 * bytesPerLocation + 486539264);
				byte[] array2 = new byte[3 + num5 * 4];
				int offset = 0;
				array2[offset++] = 167;
				array2[offset++] = 168;
				array2[offset++] = (byte)(num5 * 4);
				for (int i = 0; i < num5; i++)
				{
					offset = addInstruction(array2, (uint)((int)num6 + i * PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemRdWords * bytesPerLocation), offset);
				}
				PICkitFunctions.writeUSB(array2);
				for (int j = 0; j < num5; j++)
				{
					PICkitFunctions.RunScriptUploadNoLen(3, num);
					Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
					PICkitFunctions.UploadDataNoLen();
					Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
					num4 = 0;
					for (int k = 0; k < num2; k++)
					{
						int num7 = 0;
						uint num8 = array[num4 + num7++];
						if (num7 < bytesPerLocation)
						{
							num8 = (uint)((int)num8 | (array[num4 + num7++] << 8));
						}
						if (num7 < bytesPerLocation)
						{
							num8 = (uint)((int)num8 | (array[num4 + num7++] << 16));
						}
						if (num7 < bytesPerLocation)
						{
							num8 = (uint)((int)num8 | (array[num4 + num7++] << 24));
						}
						num4 += num7;
						PICkitFunctions.DeviceBuffers.ProgramMemory[num3++] = num8;
						if (num3 == programMem)
						{
							j = num5;
							break;
						}
					}
					StepStatusBar();
				}
			}
			while (num3 < programMem);
			text += "Boot... ";
			UpdateStatusWinText(text);
			num3 = 0;
			ResetStatusBar(bootFlash / num2);
			do
			{
				uint instruction = (uint)(num3 * bytesPerLocation + 532676608);
				byte[] array3 = new byte[3 + num * 4];
				int offset2 = 0;
				array3[offset2++] = 167;
				array3[offset2++] = 168;
				array3[offset2++] = (byte)(num * 4);
				for (int l = 0; l < num; l++)
				{
					offset2 = addInstruction(array3, instruction, offset2);
				}
				PICkitFunctions.writeUSB(array3);
				PICkitFunctions.RunScriptUploadNoLen(3, num);
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
				PICkitFunctions.UploadDataNoLen();
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
				num4 = 0;
				for (int m = 0; m < num2; m++)
				{
					int num9 = 0;
					uint num10 = array[num4 + num9++];
					if (num9 < bytesPerLocation)
					{
						num10 = (uint)((int)num10 | (array[num4 + num9++] << 8));
					}
					if (num9 < bytesPerLocation)
					{
						num10 = (uint)((int)num10 | (array[num4 + num9++] << 16));
					}
					if (num9 < bytesPerLocation)
					{
						num10 = (uint)((int)num10 | (array[num4 + num9++] << 24));
					}
					num4 += num9;
					PICkitFunctions.DeviceBuffers.ProgramMemory[programMem + num3++] = num10;
					if (num3 == bootFlash)
					{
						break;
					}
				}
				StepStatusBar();
			}
			while (num3 < bootFlash);
			text += "UserIDs... ";
			UpdateStatusWinText(text);
			PICkitFunctions.DeviceBuffers.UserIDs[0] = array[num4];
			PICkitFunctions.DeviceBuffers.UserIDs[1] = array[num4 + 1];
			num4 += bytesPerLocation;
			text += "Config... ";
			UpdateStatusWinText(text);
			for (int n = 0; n < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords; n++)
			{
				PICkitFunctions.DeviceBuffers.ConfigWords[n] = array[num4++];
				PICkitFunctions.DeviceBuffers.ConfigWords[n] |= (uint)(array[num4++] << 8);
			}
			text += "Done.";
			UpdateStatusWinText(text);
			PICkitFunctions.RunScript(1, 1);
			return true;
		}

		public static bool PIC32BlankCheck()
		{
			PICkitFunctions.SetMCLRTemp(nMCLR: true);
			PICkitFunctions.VddOn();
			if (!PE_DownloadAndConnect())
			{
				return false;
			}
			string text = "Checking if Device is blank:\n";
			UpdateStatusWinText(text);
			int programMem = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem;
			int bootFlash = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BootFlash;
			programMem -= bootFlash;
			int bytesPerLocation = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
			text += "Program Flash... ";
			UpdateStatusWinText(text);
			if (!PEBlankCheck(486539264u, (uint)(programMem * bytesPerLocation)))
			{
				text = "Program Flash is not blank";
				UpdateStatusWinText(text);
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			text += "Boot Flash... ";
			UpdateStatusWinText(text);
			if (!PEBlankCheck(532676608u, (uint)(bootFlash * bytesPerLocation)))
			{
				text = "Boot Flash is not blank";
				UpdateStatusWinText(text);
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			text += "UserID & Config... ";
			UpdateStatusWinText(text);
			if (!PEBlankCheck((uint)(532676608 + bootFlash * bytesPerLocation), 16u))
			{
				text = "ID / Config Memory is not blank";
				UpdateStatusWinText(text);
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			PICkitFunctions.RunScript(1, 1);
			text = "Device is Blank.";
			UpdateStatusWinText(text);
			return true;
		}

		public static bool P32Write(bool verifyWrite, bool codeProtect)
		{
			PICkitFunctions.SetMCLRTemp(nMCLR: true);
			PICkitFunctions.VddOn();
			PICkitFunctions.RunScript(0, 1);
			PICkitFunctions.RunScript(22, 1);
			if (!PE_DownloadAndConnect())
			{
				return false;
			}
			PICkitFunctions.RunScript(22, 1);
			string text = "Writing device:\n";
			UpdateStatusWinText(text);
			text += "Program Flash... ";
			UpdateStatusWinText(text);
			int programMem = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem;
			int bootFlash = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BootFlash;
			programMem -= bootFlash;
			int num = 128;
			int num2 = PICkitFunctions.FindLastUsedInBuffer(PICkitFunctions.DeviceBuffers.ProgramMemory, PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue, programMem - 1);
			int num3 = (num2 + 1) / num;
			if ((num2 + 1) % num > 0)
			{
				num3++;
			}
			if (num3 < 2)
			{
				num3 = 2;
			}
			ResetStatusBar(num2 / num);
			PEProgramHeader(486539264u, (uint)(num3 * 512));
			int num4 = 0;
			PEProgramSendBlock(num4, peResp: false);
			num3--;
			StepStatusBar();
			do
			{
				num4 += num;
				PEProgramSendBlock(num4, peResp: true);
				StepStatusBar();
			}
			while (--num3 > 0);
			byte[] array = new byte[4];
			int num5 = 0;
			array[num5++] = 169;
			array[num5++] = 166;
			array[num5++] = 1;
			array[num5++] = 181;
			PICkitFunctions.writeUSB(array);
			text += "Boot Flash... ";
			UpdateStatusWinText(text);
			num = 128;
			num2 = PICkitFunctions.FindLastUsedInBuffer(PICkitFunctions.DeviceBuffers.ProgramMemory, PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue, PICkitFunctions.DeviceBuffers.ProgramMemory.Length - 1);
			num2 = ((num2 < programMem) ? 1 : (num2 - programMem));
			num3 = (num2 + 1) / num;
			if ((num2 + 1) % num > 0)
			{
				num3++;
			}
			if (num3 < 2)
			{
				num3 = 2;
			}
			ResetStatusBar(num2 / num);
			PEProgramHeader(532676608u, (uint)(num3 * 512));
			num4 = programMem;
			PEProgramSendBlock(num4, peResp: false);
			num3--;
			StepStatusBar();
			do
			{
				num4 += num;
				PEProgramSendBlock(num4, peResp: true);
				StepStatusBar();
			}
			while (--num3 > 0);
			PICkitFunctions.writeUSB(array);
			text += "UserID & Config... ";
			UpdateStatusWinText(text);
			uint[] array2 = new uint[4]
			{
				PICkitFunctions.DeviceBuffers.UserIDs[0] & 0xFF,
				0u,
				0u,
				0u
			};
			array2[0] |= (PICkitFunctions.DeviceBuffers.UserIDs[1] & 0xFF) << 8;
			array2[0] |= 4294901760u;
			array2[1] = ((PICkitFunctions.DeviceBuffers.ConfigWords[0] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0]) | ((PICkitFunctions.DeviceBuffers.ConfigWords[1] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[1]) << 16));
			array2[1] |= (uint)((~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[0]) | ((~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[1] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[1]) << 16));
			array2[2] = ((PICkitFunctions.DeviceBuffers.ConfigWords[2] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[2]) | ((PICkitFunctions.DeviceBuffers.ConfigWords[3] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[3]) << 16));
			array2[2] |= (uint)((~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[2] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[2]) | ((~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[3] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[3]) << 16));
			array2[3] = ((PICkitFunctions.DeviceBuffers.ConfigWords[4] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[4]) | ((PICkitFunctions.DeviceBuffers.ConfigWords[5] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[5]) << 16));
			array2[3] |= (uint)((~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[4] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[4]) | ((~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[5] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[5]) << 16));
			if (codeProtect)
			{
				array2[3] &= (uint)(~(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPMask << 16));
			}
			uint num6 = (uint)(532676608 + bootFlash * 4);
			byte[] array3 = new byte[39];
			num5 = 0;
			array3[num5++] = 169;
			array3[num5++] = 166;
			array3[num5++] = 36;
			array3[num5++] = 187;
			array3[num5++] = 14;
			array3[num5++] = 184;
			array3[num5++] = 0;
			array3[num5++] = 0;
			array3[num5++] = 3;
			array3[num5++] = 0;
			array3[num5++] = 184;
			array3[num5++] = (byte)(num6 & 0xFF);
			array3[num5++] = (byte)((num6 >> 8) & 0xFF);
			array3[num5++] = (byte)((num6 >> 16) & 0xFF);
			array3[num5++] = (byte)((num6 >> 24) & 0xFF);
			array3[num5++] = 184;
			array3[num5++] = (byte)(array2[0] & 0xFF);
			array3[num5++] = (byte)((array2[0] >> 8) & 0xFF);
			array3[num5++] = (byte)((array2[0] >> 16) & 0xFF);
			array3[num5++] = (byte)((array2[0] >> 24) & 0xFF);
			array3[num5++] = 180;
			num6 += 4;
			array3[num5++] = 187;
			array3[num5++] = 14;
			array3[num5++] = 184;
			array3[num5++] = 0;
			array3[num5++] = 0;
			array3[num5++] = 3;
			array3[num5++] = 0;
			array3[num5++] = 184;
			array3[num5++] = (byte)(num6 & 0xFF);
			array3[num5++] = (byte)((num6 >> 8) & 0xFF);
			array3[num5++] = (byte)((num6 >> 16) & 0xFF);
			array3[num5++] = (byte)((num6 >> 24) & 0xFF);
			array3[num5++] = 184;
			array3[num5++] = (byte)(array2[1] & 0xFF);
			array3[num5++] = (byte)((array2[1] >> 8) & 0xFF);
			array3[num5++] = (byte)((array2[1] >> 16) & 0xFF);
			array3[num5++] = (byte)((array2[1] >> 24) & 0xFF);
			array3[num5++] = 180;
			num6 += 4;
			PICkitFunctions.writeUSB(array3);
			num5 = 0;
			array3[num5++] = 169;
			array3[num5++] = 166;
			array3[num5++] = 36;
			array3[num5++] = 187;
			array3[num5++] = 14;
			array3[num5++] = 184;
			array3[num5++] = 0;
			array3[num5++] = 0;
			array3[num5++] = 3;
			array3[num5++] = 0;
			array3[num5++] = 184;
			array3[num5++] = (byte)(num6 & 0xFF);
			array3[num5++] = (byte)((num6 >> 8) & 0xFF);
			array3[num5++] = (byte)((num6 >> 16) & 0xFF);
			array3[num5++] = (byte)((num6 >> 24) & 0xFF);
			array3[num5++] = 184;
			array3[num5++] = (byte)(array2[2] & 0xFF);
			array3[num5++] = (byte)((array2[2] >> 8) & 0xFF);
			array3[num5++] = (byte)((array2[2] >> 16) & 0xFF);
			array3[num5++] = (byte)((array2[2] >> 24) & 0xFF);
			array3[num5++] = 180;
			num6 += 4;
			array3[num5++] = 187;
			array3[num5++] = 14;
			array3[num5++] = 184;
			array3[num5++] = 0;
			array3[num5++] = 0;
			array3[num5++] = 3;
			array3[num5++] = 0;
			array3[num5++] = 184;
			array3[num5++] = (byte)(num6 & 0xFF);
			array3[num5++] = (byte)((num6 >> 8) & 0xFF);
			array3[num5++] = (byte)((num6 >> 16) & 0xFF);
			array3[num5++] = (byte)((num6 >> 24) & 0xFF);
			array3[num5++] = 184;
			array3[num5++] = (byte)(array2[3] & 0xFF);
			array3[num5++] = (byte)((array2[3] >> 8) & 0xFF);
			array3[num5++] = (byte)((array2[3] >> 16) & 0xFF);
			array3[num5++] = (byte)((array2[3] >> 24) & 0xFF);
			array3[num5++] = 180;
			num6 += 4;
			PICkitFunctions.writeUSB(array3);
			if (verifyWrite)
			{
				return P32Verify(writeVerify: true, codeProtect);
			}
			PICkitFunctions.RunScript(1, 1);
			return true;
		}

		private static void PEProgramHeader(uint startAddress, uint lengthBytes)
		{
			byte[] array = new byte[20];
			int num = 0;
			array[num++] = 169;
			array[num++] = 166;
			array[num++] = 17;
			array[num++] = 187;
			array[num++] = 14;
			array[num++] = 184;
			array[num++] = 0;
			array[num++] = 0;
			array[num++] = 2;
			array[num++] = 0;
			array[num++] = 184;
			array[num++] = (byte)(startAddress & 0xFF);
			array[num++] = (byte)((startAddress >> 8) & 0xFF);
			array[num++] = (byte)((startAddress >> 16) & 0xFF);
			array[num++] = (byte)((startAddress >> 24) & 0xFF);
			array[num++] = 184;
			array[num++] = (byte)(lengthBytes & 0xFF);
			array[num++] = (byte)((lengthBytes >> 8) & 0xFF);
			array[num++] = (byte)((lengthBytes >> 16) & 0xFF);
			array[num++] = (byte)((lengthBytes >> 24) & 0xFF);
			PICkitFunctions.writeUSB(array);
		}

		private static void PEProgramSendBlock(int index, bool peResp)
		{
			byte[] array = new byte[256];
			uint num = 0u;
			int num2 = 0;
			int num3 = PICkitFunctions.DeviceBuffers.ProgramMemory.Length;
			for (int i = 0; i < 64; i++)
			{
				num = ((index >= num3) ? uint.MaxValue : PICkitFunctions.DeviceBuffers.ProgramMemory[index++]);
				array[num2++] = (byte)(num & 0xFF);
				array[num2++] = (byte)((num >> 8) & 0xFF);
				array[num2++] = (byte)((num >> 16) & 0xFF);
				array[num2++] = (byte)((num >> 24) & 0xFF);
			}
			int num4 = PICkitFunctions.DataClrAndDownload(array, 0);
			while (num2 - num4 > 62)
			{
				num4 = PICkitFunctions.DataDownload(array, num4, array.Length);
			}
			int num5 = num2 - num4;
			byte[] array2 = new byte[5 + num5];
			int num6 = 0;
			array2[num6++] = 168;
			array2[num6++] = (byte)(num5 & 0xFF);
			for (int j = 0; j < num5; j++)
			{
				array2[num6++] = array[num4 + j];
			}
			array2[num6++] = 165;
			array2[num6++] = 6;
			array2[num6++] = 1;
			PICkitFunctions.writeUSB(array2);
			num2 = 0;
			for (int k = 0; k < 64; k++)
			{
				num = ((index >= num3) ? uint.MaxValue : PICkitFunctions.DeviceBuffers.ProgramMemory[index++]);
				array[num2++] = (byte)(num & 0xFF);
				array[num2++] = (byte)((num >> 8) & 0xFF);
				array[num2++] = (byte)((num >> 16) & 0xFF);
				array[num2++] = (byte)((num >> 24) & 0xFF);
			}
			num4 = PICkitFunctions.DataClrAndDownload(array, 0);
			while (num2 - num4 > 62)
			{
				num4 = PICkitFunctions.DataDownload(array, num4, array.Length);
			}
			num5 = num2 - num4;
			num6 = 0;
			array2[num6++] = 168;
			array2[num6++] = (byte)(num5 & 0xFF);
			for (int l = 0; l < num5; l++)
			{
				array2[num6++] = array[num4 + l];
			}
			array2[num6++] = 165;
			if (peResp)
			{
				array2[num6++] = 7;
			}
			else
			{
				array2[num6++] = 6;
			}
			array2[num6++] = 1;
			PICkitFunctions.writeUSB(array2);
		}

		public static bool P32Verify(bool writeVerify, bool codeProtect)
		{
			if (!writeVerify)
			{
				PICkitFunctions.SetMCLRTemp(nMCLR: true);
				PICkitFunctions.VddOn();
				if (!PE_DownloadAndConnect())
				{
					return false;
				}
			}
			string text = "Verifying Device:\n";
			UpdateStatusWinText(text);
			int programMem = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem;
			int bootFlash = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BootFlash;
			programMem -= bootFlash;
			int bytesPerLocation = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
			text += "Program Flash... ";
			UpdateStatusWinText(text);
			int num = p32CRC_buf(PICkitFunctions.DeviceBuffers.ProgramMemory, 0u, (uint)programMem);
			int num2 = PEGetCRC(486539264u, (uint)(programMem * bytesPerLocation));
			if (num != num2)
			{
				if (writeVerify)
				{
					text = "Programming Program Flash Failed.";
					UpdateStatusWinText(text);
				}
				else
				{
					text = "Verify of Program Flash Failed.";
					UpdateStatusWinText(text);
				}
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			text += "Boot Flash... ";
			UpdateStatusWinText(text);
			num = p32CRC_buf(PICkitFunctions.DeviceBuffers.ProgramMemory, (uint)programMem, (uint)bootFlash);
			num2 = PEGetCRC(532676608u, (uint)(bootFlash * bytesPerLocation));
			if (num != num2)
			{
				if (writeVerify)
				{
					text = "Programming Boot Flash Failed.";
					UpdateStatusWinText(text);
				}
				else
				{
					text = "Verify of Boot Flash Failed.";
					UpdateStatusWinText(text);
				}
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			text += "ID/Config Flash... ";
			UpdateStatusWinText(text);
			uint[] array = new uint[4]
			{
				PICkitFunctions.DeviceBuffers.UserIDs[0] & 0xFF,
				0u,
				0u,
				0u
			};
			array[0] |= (PICkitFunctions.DeviceBuffers.UserIDs[1] & 0xFF) << 8;
			array[0] |= 4294901760u;
			array[1] = ((PICkitFunctions.DeviceBuffers.ConfigWords[0] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0]) | ((PICkitFunctions.DeviceBuffers.ConfigWords[1] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[1]) << 16));
			array[1] |= (uint)((~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[0]) | ((~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[1] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[1]) << 16));
			array[2] = ((PICkitFunctions.DeviceBuffers.ConfigWords[2] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[2]) | ((PICkitFunctions.DeviceBuffers.ConfigWords[3] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[3]) << 16));
			array[2] |= (uint)((~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[2] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[2]) | ((~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[3] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[3]) << 16));
			array[3] = ((PICkitFunctions.DeviceBuffers.ConfigWords[4] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[4]) | ((PICkitFunctions.DeviceBuffers.ConfigWords[5] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[5]) << 16));
			array[3] |= (uint)((~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[4] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[4]) | ((~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[5] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[5]) << 16));
			if (codeProtect)
			{
				array[3] &= (uint)(~(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPMask << 16));
			}
			num = p32CRC_buf(array, 0u, 4u);
			num2 = PEGetCRC((uint)(532676608 + bootFlash * bytesPerLocation), (uint)(4 * bytesPerLocation));
			if (num != num2)
			{
				if (writeVerify)
				{
					text = "Programming ID/Config Flash Failed.";
					UpdateStatusWinText(text);
				}
				else
				{
					text = "Verify of ID/Config Flash Failed.";
					UpdateStatusWinText(text);
				}
				PICkitFunctions.RunScript(1, 1);
				return false;
			}
			if (!writeVerify)
			{
				text = "Verification Successful.\n";
				UpdateStatusWinText(text);
			}
			else
			{
				text = "Programming Successful.\n";
				UpdateStatusWinText(text);
			}
			PICkitFunctions.RunScript(1, 1);
			return true;
		}

		private static int p32CRC_buf(uint[] buffer, uint startIdx, uint len)
		{
			uint num = 69665u;
			uint num2 = 65535u;
			uint num3 = num2;
			uint bytesPerLocation = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
			_ = buffer.Length;
			for (uint num4 = startIdx; num4 < startIdx + len; num4++)
			{
				uint num5 = buffer[num4];
				for (uint num6 = 0u; num6 < bytesPerLocation; num6++)
				{
					uint num7 = (num5 & 0xFF) << 8;
					num5 >>= 8;
					for (uint num8 = 0u; num8 < 8; num8++)
					{
						uint num9 = (num3 ^ num7) & 0x8000;
						num3 <<= 1;
						num7 <<= 1;
						if (num9 != 0)
						{
							num3 ^= num;
						}
					}
				}
			}
			return (int)(num3 & 0xFFFF);
		}
	}
}
