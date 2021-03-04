using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using TST;

namespace PICkit2V2
{
	public class FormPICkit2 : Form
	{
		public struct FLASHWINFO
		{
			public ushort cbSize;

			public IntPtr hwnd;

			public uint dwFlags;

			public ushort uCount;

			public uint dwTimeout;
		}

		private IContainer components;

		private MenuStrip menuStrip1;

		private ToolStripMenuItem fileToolStripMenuItem;

		private ToolStripMenuItem importFileToolStripMenuItem;

		private ToolStripMenuItem exportFileToolStripMenuItem;

		private ToolStripSeparator toolStripMenuItem1;

		private ToolStripMenuItem deviceToolStripMenuItem;

		private ToolStripMenuItem programmerToolStripMenuItem;

		private ToolStripMenuItem readDeviceToolStripMenuItem;

		private ToolStripMenuItem writeDeviceToolStripMenuItem;

		private ToolStripMenuItem verifyToolStripMenuItem;

		private ToolStripMenuItem eraseToolStripMenuItem;

		private ToolStripMenuItem blankCheckToolStripMenuItem;

		private ToolStripMenuItem toolsToolStripMenuItem;

		private ToolStripMenuItem enableCodeProtectToolStripMenuItem;

		private ToolStripMenuItem targetPowerToolStripMenuItem;

		private ToolStripMenuItem fastProgrammingToolStripMenuItem;

		private ToolStripMenuItem checkCommunicationToolStripMenuItem;

		private ToolStripSeparator toolStripMenuItem2;

		private ToolStripMenuItem downloadPICkit2FirmwareToolStripMenuItem;

		private ToolStripMenuItem helpToolStripMenuItem;

		private ToolStripMenuItem usersGuideToolStripMenuItem;

		private ToolStripMenuItem readMeToolStripMenuItem;

		private ToolStripSeparator toolStripMenuItem3;

		private ToolStripMenuItem aboutToolStripMenuItem;

		private GroupBox statusGroupBox;

		private PictureBox pictureBoxLogo;

		private Label labelDevice;

		private Label labelChecksum;

		private Label labelUserIDs;

		private DataGridView dataGridConfigWords;

		private Label displayUserIDs;

		private Label displayDevice;

		private Label displayChecksum;

		private Label labelOSCCAL;

		private Label displayBandGap;

		private Label labelBandGap;

		private Label displayOSCCAL;

		private Label displayStatusWindow;

		private Button buttonRead;

		private ProgressBar progressBar1;

		private Button buttonWrite;

		private Button buttonVerify;

		private Button buttonErase;

		private Button buttonBlankCheck;

		private CheckBox chkBoxVddOn;

		private NumericUpDown numUpDnVDD;

		private GroupBox groupBoxVDD;

		private GroupBox groupBoxProgMem;

		private CheckBox checkBoxProgMemEnabled;

		private ComboBox comboBoxProgMemView;

		private Label labelDataSource;

		private Label displayDataSource;

		private DataGridView dataGridProgramMemory;

		private OpenFileDialog openHexFileDialog;

		private SaveFileDialog saveHexFileDialog;

		private ToolStripSeparator toolStripMenuItem4;

		private ToolStripMenuItem verifyOnWriteToolStripMenuItem;

		private OpenFileDialog openFWFile;

		private ToolStripMenuItem writeOnPICkitButtonToolStripMenuItem;

		private System.Windows.Forms.Timer timerButton;

		private GroupBox groupBoxEEMem;

		private Button buttonExportHex;

		private ComboBox comboBoxEE;

		private CheckBox checkBoxEEMem;

		private DataGridView dataGridViewEEPROM;

		private ToolStripMenuItem autoDetectToolStripMenuItem;

		private ToolStripMenuItem forcePICkit2ToolStripMenuItem;

		private ToolStripMenuItem forceTargetToolStripMenuItem;

		private PictureBox pictureBox1;

		private ComboBox comboBoxSelectPart;

		private Label labelCodeProtect;

		private System.Windows.Forms.Timer timerDLFW;

		private ToolStripMenuItem hex1ToolStripMenuItem;

		private ToolStripMenuItem hex2ToolStripMenuItem;

		private ToolStripMenuItem hex3ToolStripMenuItem;

		private ToolStripMenuItem hex4ToolStripMenuItem;

		private ToolStripSeparator toolStripMenuItem5;

		private ToolStripMenuItem exitToolStripMenuItem;

		private ToolStripMenuItem enableDataProtectStripMenuItem;

		private ToolStripMenuItem lpcUsersGuideToolStripMenuItem;

		private Label displayEEProgInfo;

		private ToolStripMenuItem setOSCCALToolStripMenuItem;

		private ToolStripMenuItem webPk2ToolStripMenuItem;

		private ToolStripSeparator toolStripMenuItem6;

		private ToolStripMenuItem troubleshhotToolStripMenuItem;

		private CheckBox checkBoxMCLR;

		private ToolStripMenuItem MCLRtoolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItemTestMemory;

		private CheckBox checkBoxAutoImportWrite;

		private System.Windows.Forms.Timer timerAutoImportWrite;

		private ToolStripMenuItem testToolStripMenuItem;

		private Label displayRev;

		private ToolStripMenuItem uG44pinToolStripMenuItem;

		private Button buttonShowIDMem;

		private ToolStripMenuItem VppFirstToolStripMenuItem;

		private CheckBox checkBoxA1CS;

		private CheckBox checkBoxA0CS;

		private CheckBox checkBoxA2CS;

		private ToolStripMenuItem calibrateToolStripMenuItem;

		private Label labelOSSCALInvalid;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripMenuItem UARTtoolStripMenuItem;

		private CheckBox checkBoxProgMemEnabledAlt;

		private CheckBox checkBoxEEDATAMemoryEnabledAlt;

		private ToolStripMenuItem toolStripMenuItemView;

		private ToolStripMenuItem toolStripMenuItemSingleWindow;

		private ToolStripMenuItem toolStripMenuItemMultiWindow;

		private ToolStripSeparator toolStripMenuItem7;

		private ToolStripMenuItem toolStripMenuItemShowProgramMemory;

		private ToolStripMenuItem toolStripMenuItemShowEEPROMData;

		private ToolStripSeparator toolStripMenuItem8;

		private ToolStripMenuItem pICkit2GoToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItemManualSelect;

		private ToolStripMenuItem toolStripMenuItemProgToGo;

		private ToolStripMenuItem toolStripMenuItemLogicTool;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem toolStripMenuItemContextSelectAll;

		private ToolStripMenuItem toolStripMenuItemContextCopy;

		private ToolStripMenuItem toolStripMenuItemLogicToolUG;

		private ToolStripMenuItem calSetManuallyToolStripMenuItem;

		private ToolStripMenuItem calAutoRegenerateToolStripMenuItem;

		private System.Windows.Forms.Timer timerInitalUpdate;

		private ToolStripSeparator toolStripMenuItem9;

		private ToolStripMenuItem mainWindowAlwaysInFrontToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItemClearBuffersErase;

		private ToolStripMenuItem toolStripMenuItemSounds;

		private ToolStripMenuItem toolStripMenuItemDisplayUnimplConfigAs;

		private ToolStripMenuItem as0BitValueToolStripMenuItem;

		private ToolStripMenuItem as1BitValueToolStripMenuItem;

		private ToolStripMenuItem asReadOrImportedToolStripMenuItem;

		private Label labelConfig;

		private ToolStripMenuItem toolStripMenuItemLVPEnabled;

		private Label labelLVP;

		private Label labelConfig9;

		public static bool ShowWriteEraseVDDDialog = true;

		public static bool ContinueWriteErase = false;

		public static bool setOSCCALValue = false;

		public static bool ConfigsEdited = false;

		public static bool TestMemoryOpen = false;

		public static bool TestMemoryEnabled = false;

		public static int TestMemoryWords = 64;

		public static ushort pk2number = 0;

		public static bool TestMemoryImportExport = false;

		public static FormTestMemory formTestMem;

		public static string DeviceFileName = "PK2DeviceFile.dat";

		public static float ScalefactW = 1f;

		public static float ScalefactH = 1f;

		public static string HomeDirectory;

		public static byte slowSpeedICSP = 4;

		public static bool PlaySuccessWav = false;

		public static string SuccessWavFile = "\\Sounds\\success.wav";

		public static bool PlayWarningWav = false;

		public static string WarningWavFile = "\\Sounds\\warning.wav";

		public static bool PlayErrorWav = false;

		public static string ErrorWavFile = "\\Sounds\\error.wav";

		private static bool selfPoweredTarget;

		private static Constants.StatusColor statusWindowColor = Constants.StatusColor.normal;

		private DialogVDDErase dialogVddErase = new DialogVDDErase();

		private DialogUserIDs dialogIDMemory;

		private Constants.VddTargetSelect VddTargetSave;

		private DialogUART uartWindow = new DialogUART();

		private DialogLogic logicWindow = new DialogLogic();

		private FormMultiWinProgMem programMemMultiWin = new FormMultiWinProgMem();

		private FormMultiWinEEData eepromDataMultiWin = new FormMultiWinEEData();

		private Point lastLoc = new Point(0, 0);

		private bool buttonLast = true;

		private bool checkImportFile;

		private bool oldFirmware;

		private bool bootLoad;

		private bool importGo;

		private bool allowDataEdits = true;

		private bool progMemJustEdited;

		private bool eeMemJustEdited;

		private bool testConnected;

		private bool searchOnStartup = true;

		private bool autoDetectInINI = true;

		private bool selectDeviceFile;

		private bool viewChanged;

		private bool multiWindow;

		private bool multiWinPMemOpen = true;

		private bool multiWinEEMemOpen = true;

		private bool saveMultWinPMemOpen = true;

		private bool saveMultiWinEEMemOpen = true;

		private bool verifyOSCCALValue = true;

		private bool mainWinOwnsMem = true;

		private bool usePE33 = true;

		private bool usePE24 = true;

		private bool useLVP;

		private bool deviceVerification = true;

		private byte ptgMemory;

		private string lastFamily = "Midrange";

		private string hex1 = "";

		private string hex2 = "";

		private string hex3 = "";

		private string hex4 = "";

		private SoundPlayer wavPlayer = new SoundPlayer();

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PICkit2V2.FormPICkit2));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			menuStrip1 = new System.Windows.Forms.MenuStrip();
			fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			importFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			exportFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			hex1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			hex2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			hex3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			hex4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			deviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			programmerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			readDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			writeDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			verifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			eraseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			blankCheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			verifyOnWriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItemClearBuffersErase = new System.Windows.Forms.ToolStripMenuItem();
			MCLRtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItemSounds = new System.Windows.Forms.ToolStripMenuItem();
			writeOnPICkitButtonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItemManualSelect = new System.Windows.Forms.ToolStripMenuItem();
			pICkit2GoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			enableCodeProtectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			enableDataProtectStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			setOSCCALToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			calSetManuallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			calAutoRegenerateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			targetPowerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			autoDetectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			forcePICkit2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			forceTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItemDisplayUnimplConfigAs = new System.Windows.Forms.ToolStripMenuItem();
			as0BitValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			as1BitValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			asReadOrImportedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			calibrateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			VppFirstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItemLVPEnabled = new System.Windows.Forms.ToolStripMenuItem();
			fastProgrammingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			UARTtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItemLogicTool = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			checkCommunicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			troubleshhotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItemTestMemory = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			downloadPICkit2FirmwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItemView = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItemSingleWindow = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItemMultiWindow = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItemShowProgramMemory = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItemShowEEPROMData = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
			mainWindowAlwaysInFrontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			usersGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItemProgToGo = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItemLogicToolUG = new System.Windows.Forms.ToolStripMenuItem();
			uG44pinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			lpcUsersGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			webPk2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			readMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			statusGroupBox = new System.Windows.Forms.GroupBox();
			labelOSSCALInvalid = new System.Windows.Forms.Label();
			checkBoxA2CS = new System.Windows.Forms.CheckBox();
			checkBoxA1CS = new System.Windows.Forms.CheckBox();
			checkBoxA0CS = new System.Windows.Forms.CheckBox();
			buttonShowIDMem = new System.Windows.Forms.Button();
			displayRev = new System.Windows.Forms.Label();
			labelCodeProtect = new System.Windows.Forms.Label();
			comboBoxSelectPart = new System.Windows.Forms.ComboBox();
			displayBandGap = new System.Windows.Forms.Label();
			labelBandGap = new System.Windows.Forms.Label();
			displayOSCCAL = new System.Windows.Forms.Label();
			labelOSCCAL = new System.Windows.Forms.Label();
			displayChecksum = new System.Windows.Forms.Label();
			displayUserIDs = new System.Windows.Forms.Label();
			displayDevice = new System.Windows.Forms.Label();
			labelConfig = new System.Windows.Forms.Label();
			dataGridConfigWords = new System.Windows.Forms.DataGridView();
			labelChecksum = new System.Windows.Forms.Label();
			labelUserIDs = new System.Windows.Forms.Label();
			labelDevice = new System.Windows.Forms.Label();
			pictureBoxLogo = new System.Windows.Forms.PictureBox();
			displayStatusWindow = new System.Windows.Forms.Label();
			buttonRead = new System.Windows.Forms.Button();
			progressBar1 = new System.Windows.Forms.ProgressBar();
			buttonWrite = new System.Windows.Forms.Button();
			buttonVerify = new System.Windows.Forms.Button();
			buttonErase = new System.Windows.Forms.Button();
			buttonBlankCheck = new System.Windows.Forms.Button();
			chkBoxVddOn = new System.Windows.Forms.CheckBox();
			numUpDnVDD = new System.Windows.Forms.NumericUpDown();
			groupBoxVDD = new System.Windows.Forms.GroupBox();
			checkBoxMCLR = new System.Windows.Forms.CheckBox();
			groupBoxProgMem = new System.Windows.Forms.GroupBox();
			dataGridProgramMemory = new System.Windows.Forms.DataGridView();
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripMenuItemContextSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItemContextCopy = new System.Windows.Forms.ToolStripMenuItem();
			displayDataSource = new System.Windows.Forms.Label();
			labelDataSource = new System.Windows.Forms.Label();
			comboBoxProgMemView = new System.Windows.Forms.ComboBox();
			checkBoxProgMemEnabled = new System.Windows.Forms.CheckBox();
			openHexFileDialog = new System.Windows.Forms.OpenFileDialog();
			saveHexFileDialog = new System.Windows.Forms.SaveFileDialog();
			openFWFile = new System.Windows.Forms.OpenFileDialog();
			timerButton = new System.Windows.Forms.Timer(components);
			groupBoxEEMem = new System.Windows.Forms.GroupBox();
			displayEEProgInfo = new System.Windows.Forms.Label();
			dataGridViewEEPROM = new System.Windows.Forms.DataGridView();
			comboBoxEE = new System.Windows.Forms.ComboBox();
			checkBoxEEMem = new System.Windows.Forms.CheckBox();
			buttonExportHex = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			timerDLFW = new System.Windows.Forms.Timer(components);
			checkBoxAutoImportWrite = new System.Windows.Forms.CheckBox();
			timerAutoImportWrite = new System.Windows.Forms.Timer(components);
			checkBoxProgMemEnabledAlt = new System.Windows.Forms.CheckBox();
			checkBoxEEDATAMemoryEnabledAlt = new System.Windows.Forms.CheckBox();
			timerInitalUpdate = new System.Windows.Forms.Timer(components);
			labelLVP = new System.Windows.Forms.Label();
			labelConfig9 = new System.Windows.Forms.Label();
			menuStrip1.SuspendLayout();
			statusGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridConfigWords).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
			((System.ComponentModel.ISupportInitialize)numUpDnVDD).BeginInit();
			groupBoxVDD.SuspendLayout();
			groupBoxProgMem.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridProgramMemory).BeginInit();
			contextMenuStrip1.SuspendLayout();
			groupBoxEEMem.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridViewEEPROM).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[7]
			{
				fileToolStripMenuItem,
				deviceToolStripMenuItem,
				programmerToolStripMenuItem,
				toolsToolStripMenuItem,
				toolStripMenuItemView,
				helpToolStripMenuItem,
				testToolStripMenuItem
			});
			menuStrip1.Location = new System.Drawing.Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
			menuStrip1.Size = new System.Drawing.Size(538, 24);
			menuStrip1.TabIndex = 0;
			menuStrip1.Text = "menuStrip1";
			fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[9]
			{
				importFileToolStripMenuItem,
				exportFileToolStripMenuItem,
				toolStripMenuItem1,
				hex1ToolStripMenuItem,
				hex2ToolStripMenuItem,
				hex3ToolStripMenuItem,
				hex4ToolStripMenuItem,
				toolStripMenuItem5,
				exitToolStripMenuItem
			});
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			fileToolStripMenuItem.Text = "&File";
			importFileToolStripMenuItem.Enabled = false;
			importFileToolStripMenuItem.Name = "importFileToolStripMenuItem";
			importFileToolStripMenuItem.ShortcutKeys = (System.Windows.Forms.Keys)131145;
			importFileToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			importFileToolStripMenuItem.Text = "&Import Hex";
			importFileToolStripMenuItem.Click += new System.EventHandler(menuFileImportHex);
			exportFileToolStripMenuItem.Enabled = false;
			exportFileToolStripMenuItem.Name = "exportFileToolStripMenuItem";
			exportFileToolStripMenuItem.ShortcutKeys = (System.Windows.Forms.Keys)131141;
			exportFileToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			exportFileToolStripMenuItem.Text = "&Export Hex";
			exportFileToolStripMenuItem.Click += new System.EventHandler(menuFileExportHex);
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new System.Drawing.Size(174, 6);
			hex1ToolStripMenuItem.Name = "hex1ToolStripMenuItem";
			hex1ToolStripMenuItem.ShortcutKeys = (System.Windows.Forms.Keys.LButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space | System.Windows.Forms.Keys.Control);
			hex1ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			hex1ToolStripMenuItem.Text = "&1 ";
			hex1ToolStripMenuItem.Visible = false;
			hex1ToolStripMenuItem.Click += new System.EventHandler(hex1Click);
			hex2ToolStripMenuItem.Name = "hex2ToolStripMenuItem";
			hex2ToolStripMenuItem.ShortcutKeys = (System.Windows.Forms.Keys.RButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space | System.Windows.Forms.Keys.Control);
			hex2ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			hex2ToolStripMenuItem.Text = "&2 ";
			hex2ToolStripMenuItem.Visible = false;
			hex2ToolStripMenuItem.Click += new System.EventHandler(hex2Click);
			hex3ToolStripMenuItem.Name = "hex3ToolStripMenuItem";
			hex3ToolStripMenuItem.ShortcutKeys = (System.Windows.Forms.Keys.LButton | System.Windows.Forms.Keys.RButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space | System.Windows.Forms.Keys.Control);
			hex3ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			hex3ToolStripMenuItem.Text = "&3";
			hex3ToolStripMenuItem.Visible = false;
			hex3ToolStripMenuItem.Click += new System.EventHandler(hex3Click);
			hex4ToolStripMenuItem.Name = "hex4ToolStripMenuItem";
			hex4ToolStripMenuItem.ShortcutKeys = (System.Windows.Forms.Keys.MButton | System.Windows.Forms.Keys.ShiftKey | System.Windows.Forms.Keys.Space | System.Windows.Forms.Keys.Control);
			hex4ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			hex4ToolStripMenuItem.Text = "&4";
			hex4ToolStripMenuItem.Visible = false;
			hex4ToolStripMenuItem.Click += new System.EventHandler(hex4Click);
			toolStripMenuItem5.Name = "toolStripMenuItem5";
			toolStripMenuItem5.Size = new System.Drawing.Size(174, 6);
			toolStripMenuItem5.Visible = false;
			exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			exitToolStripMenuItem.ShortcutKeys = (System.Windows.Forms.Keys)131153;
			exitToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			exitToolStripMenuItem.Text = "E&xit";
			exitToolStripMenuItem.Click += new System.EventHandler(fileMenuExit);
			deviceToolStripMenuItem.Enabled = false;
			deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
			deviceToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
			deviceToolStripMenuItem.Text = "&Device Family";
			deviceToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(deviceFamilyClick);
			programmerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				readDeviceToolStripMenuItem,
				writeDeviceToolStripMenuItem,
				verifyToolStripMenuItem,
				eraseToolStripMenuItem,
				blankCheckToolStripMenuItem,
				toolStripMenuItem4,
				verifyOnWriteToolStripMenuItem,
				toolStripMenuItemClearBuffersErase,
				MCLRtoolStripMenuItem,
				toolStripMenuItemSounds,
				writeOnPICkitButtonToolStripMenuItem,
				toolStripMenuItem8,
				toolStripMenuItemManualSelect,
				pICkit2GoToolStripMenuItem
			});
			programmerToolStripMenuItem.Name = "programmerToolStripMenuItem";
			programmerToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
			programmerToolStripMenuItem.Text = "&Programmer";
			readDeviceToolStripMenuItem.Enabled = false;
			readDeviceToolStripMenuItem.Name = "readDeviceToolStripMenuItem";
			readDeviceToolStripMenuItem.ShortcutKeys = (System.Windows.Forms.Keys)131154;
			readDeviceToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			readDeviceToolStripMenuItem.Text = "&Read Device";
			readDeviceToolStripMenuItem.Click += new System.EventHandler(readDevice);
			writeDeviceToolStripMenuItem.Enabled = false;
			writeDeviceToolStripMenuItem.Name = "writeDeviceToolStripMenuItem";
			writeDeviceToolStripMenuItem.ShortcutKeys = (System.Windows.Forms.Keys)131159;
			writeDeviceToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			writeDeviceToolStripMenuItem.Text = "&Write Device";
			writeDeviceToolStripMenuItem.Click += new System.EventHandler(writeDevice);
			verifyToolStripMenuItem.Enabled = false;
			verifyToolStripMenuItem.Name = "verifyToolStripMenuItem";
			verifyToolStripMenuItem.ShortcutKeys = (System.Windows.Forms.Keys)131161;
			verifyToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			verifyToolStripMenuItem.Text = "&Verify";
			verifyToolStripMenuItem.Click += new System.EventHandler(verifyDevice);
			eraseToolStripMenuItem.Enabled = false;
			eraseToolStripMenuItem.Name = "eraseToolStripMenuItem";
			eraseToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			eraseToolStripMenuItem.Text = "&Erase";
			eraseToolStripMenuItem.Click += new System.EventHandler(eraseDevice);
			blankCheckToolStripMenuItem.Enabled = false;
			blankCheckToolStripMenuItem.Name = "blankCheckToolStripMenuItem";
			blankCheckToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			blankCheckToolStripMenuItem.Text = "&Blank Check";
			blankCheckToolStripMenuItem.Click += new System.EventHandler(blankCheck);
			toolStripMenuItem4.Name = "toolStripMenuItem4";
			toolStripMenuItem4.Size = new System.Drawing.Size(231, 6);
			verifyOnWriteToolStripMenuItem.Checked = true;
			verifyOnWriteToolStripMenuItem.CheckOnClick = true;
			verifyOnWriteToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			verifyOnWriteToolStripMenuItem.Name = "verifyOnWriteToolStripMenuItem";
			verifyOnWriteToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			verifyOnWriteToolStripMenuItem.Text = "Verify on Write";
			toolStripMenuItemClearBuffersErase.Checked = true;
			toolStripMenuItemClearBuffersErase.CheckOnClick = true;
			toolStripMenuItemClearBuffersErase.CheckState = System.Windows.Forms.CheckState.Checked;
			toolStripMenuItemClearBuffersErase.Name = "toolStripMenuItemClearBuffersErase";
			toolStripMenuItemClearBuffersErase.Size = new System.Drawing.Size(234, 22);
			toolStripMenuItemClearBuffersErase.Text = "Clear Memory Buffers on Erase";
			MCLRtoolStripMenuItem.Enabled = false;
			MCLRtoolStripMenuItem.Name = "MCLRtoolStripMenuItem";
			MCLRtoolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			MCLRtoolStripMenuItem.Text = "Hold Device in Reset";
			MCLRtoolStripMenuItem.Click += new System.EventHandler(MCLRtoolStripMenuItem_Click);
			toolStripMenuItemSounds.Name = "toolStripMenuItemSounds";
			toolStripMenuItemSounds.Size = new System.Drawing.Size(234, 22);
			toolStripMenuItemSounds.Text = "Alert Sounds...";
			toolStripMenuItemSounds.Click += new System.EventHandler(toolStripMenuItemSounds_Click);
			writeOnPICkitButtonToolStripMenuItem.CheckOnClick = true;
			writeOnPICkitButtonToolStripMenuItem.Enabled = false;
			writeOnPICkitButtonToolStripMenuItem.Name = "writeOnPICkitButtonToolStripMenuItem";
			writeOnPICkitButtonToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			writeOnPICkitButtonToolStripMenuItem.Text = "Write on PICkit Button";
			writeOnPICkitButtonToolStripMenuItem.Click += new System.EventHandler(writeOnButton);
			toolStripMenuItem8.Name = "toolStripMenuItem8";
			toolStripMenuItem8.Size = new System.Drawing.Size(231, 6);
			toolStripMenuItemManualSelect.CheckOnClick = true;
			toolStripMenuItemManualSelect.Name = "toolStripMenuItemManualSelect";
			toolStripMenuItemManualSelect.Size = new System.Drawing.Size(234, 22);
			toolStripMenuItemManualSelect.Text = "Manual Device Select";
			toolStripMenuItemManualSelect.Click += new System.EventHandler(toolStripMenuItemManualSelect_Click);
			pICkit2GoToolStripMenuItem.Enabled = false;
			pICkit2GoToolStripMenuItem.Name = "pICkit2GoToolStripMenuItem";
			pICkit2GoToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
			pICkit2GoToolStripMenuItem.Text = "PICkit 2 Programmer-To-Go...";
			pICkit2GoToolStripMenuItem.Click += new System.EventHandler(pICkit2GoToolStripMenuItem_Click);
			toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[18]
			{
				enableCodeProtectToolStripMenuItem,
				enableDataProtectStripMenuItem,
				setOSCCALToolStripMenuItem,
				targetPowerToolStripMenuItem,
				toolStripMenuItemDisplayUnimplConfigAs,
				calibrateToolStripMenuItem,
				VppFirstToolStripMenuItem,
				toolStripMenuItemLVPEnabled,
				fastProgrammingToolStripMenuItem,
				toolStripSeparator1,
				UARTtoolStripMenuItem,
				toolStripMenuItemLogicTool,
				toolStripMenuItem6,
				checkCommunicationToolStripMenuItem,
				troubleshhotToolStripMenuItem,
				toolStripMenuItemTestMemory,
				toolStripMenuItem2,
				downloadPICkit2FirmwareToolStripMenuItem
			});
			toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			toolsToolStripMenuItem.Text = "&Tools";
			enableCodeProtectToolStripMenuItem.CheckOnClick = true;
			enableCodeProtectToolStripMenuItem.Name = "enableCodeProtectToolStripMenuItem";
			enableCodeProtectToolStripMenuItem.ShortcutKeys = (System.Windows.Forms.Keys)131152;
			enableCodeProtectToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
			enableCodeProtectToolStripMenuItem.Text = "Enable &Code Protect";
			enableCodeProtectToolStripMenuItem.Click += new System.EventHandler(codeProtect);
			enableDataProtectStripMenuItem.CheckOnClick = true;
			enableDataProtectStripMenuItem.Enabled = false;
			enableDataProtectStripMenuItem.Name = "enableDataProtectStripMenuItem";
			enableDataProtectStripMenuItem.ShortcutKeys = (System.Windows.Forms.Keys)131140;
			enableDataProtectStripMenuItem.Size = new System.Drawing.Size(261, 22);
			enableDataProtectStripMenuItem.Text = "Enable &Data Protect";
			enableDataProtectStripMenuItem.Click += new System.EventHandler(dataProtect);
			setOSCCALToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2]
			{
				calSetManuallyToolStripMenuItem,
				calAutoRegenerateToolStripMenuItem
			});
			setOSCCALToolStripMenuItem.Name = "setOSCCALToolStripMenuItem";
			setOSCCALToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
			setOSCCALToolStripMenuItem.Text = "&OSCCAL";
			calSetManuallyToolStripMenuItem.Name = "calSetManuallyToolStripMenuItem";
			calSetManuallyToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			calSetManuallyToolStripMenuItem.Text = "Set Manually";
			calSetManuallyToolStripMenuItem.Click += new System.EventHandler(setOSCCAL);
			calAutoRegenerateToolStripMenuItem.Name = "calAutoRegenerateToolStripMenuItem";
			calAutoRegenerateToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			calAutoRegenerateToolStripMenuItem.Text = "Auto Regenerate";
			calAutoRegenerateToolStripMenuItem.Click += new System.EventHandler(calAutoRegenerateToolStripMenuItem_Click);
			targetPowerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3]
			{
				autoDetectToolStripMenuItem,
				forcePICkit2ToolStripMenuItem,
				forceTargetToolStripMenuItem
			});
			targetPowerToolStripMenuItem.Name = "targetPowerToolStripMenuItem";
			targetPowerToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
			targetPowerToolStripMenuItem.Text = "Target &VDD Source";
			autoDetectToolStripMenuItem.Checked = true;
			autoDetectToolStripMenuItem.CheckOnClick = true;
			autoDetectToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			autoDetectToolStripMenuItem.Name = "autoDetectToolStripMenuItem";
			autoDetectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			autoDetectToolStripMenuItem.Text = "&Auto-Detect";
			autoDetectToolStripMenuItem.Click += new System.EventHandler(menuVDDAuto);
			forcePICkit2ToolStripMenuItem.CheckOnClick = true;
			forcePICkit2ToolStripMenuItem.Name = "forcePICkit2ToolStripMenuItem";
			forcePICkit2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			forcePICkit2ToolStripMenuItem.Text = "Force &PICkit 2";
			forcePICkit2ToolStripMenuItem.Click += new System.EventHandler(menuVDDPk2);
			forceTargetToolStripMenuItem.CheckOnClick = true;
			forceTargetToolStripMenuItem.Name = "forceTargetToolStripMenuItem";
			forceTargetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			forceTargetToolStripMenuItem.Text = "Force &Target";
			forceTargetToolStripMenuItem.Click += new System.EventHandler(menuVDDTarget);
			toolStripMenuItemDisplayUnimplConfigAs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3]
			{
				as0BitValueToolStripMenuItem,
				as1BitValueToolStripMenuItem,
				asReadOrImportedToolStripMenuItem
			});
			toolStripMenuItemDisplayUnimplConfigAs.Name = "toolStripMenuItemDisplayUnimplConfigAs";
			toolStripMenuItemDisplayUnimplConfigAs.Size = new System.Drawing.Size(261, 22);
			toolStripMenuItemDisplayUnimplConfigAs.Text = "Display Unimplemented Config Bits";
			as0BitValueToolStripMenuItem.Checked = true;
			as0BitValueToolStripMenuItem.CheckOnClick = true;
			as0BitValueToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			as0BitValueToolStripMenuItem.Name = "as0BitValueToolStripMenuItem";
			as0BitValueToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			as0BitValueToolStripMenuItem.Text = "As '0' bit value";
			as0BitValueToolStripMenuItem.Click += new System.EventHandler(as0BitValueToolStripMenuItem_Click);
			as1BitValueToolStripMenuItem.CheckOnClick = true;
			as1BitValueToolStripMenuItem.Name = "as1BitValueToolStripMenuItem";
			as1BitValueToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			as1BitValueToolStripMenuItem.Text = "As '1' bit value";
			as1BitValueToolStripMenuItem.Click += new System.EventHandler(as1BitValueToolStripMenuItem_Click);
			asReadOrImportedToolStripMenuItem.CheckOnClick = true;
			asReadOrImportedToolStripMenuItem.Name = "asReadOrImportedToolStripMenuItem";
			asReadOrImportedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			asReadOrImportedToolStripMenuItem.Text = "As read or imported";
			asReadOrImportedToolStripMenuItem.Click += new System.EventHandler(asReadOrImportedToolStripMenuItem_Click);
			calibrateToolStripMenuItem.Name = "calibrateToolStripMenuItem";
			calibrateToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
			calibrateToolStripMenuItem.Text = "Calibrate VDD && Set Unit ID...";
			calibrateToolStripMenuItem.Click += new System.EventHandler(calibrateToolStripMenuItem_Click);
			VppFirstToolStripMenuItem.CheckOnClick = true;
			VppFirstToolStripMenuItem.Enabled = false;
			VppFirstToolStripMenuItem.Name = "VppFirstToolStripMenuItem";
			VppFirstToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
			VppFirstToolStripMenuItem.Text = "&Use VPP First Program Entry";
			VppFirstToolStripMenuItem.CheckedChanged += new System.EventHandler(VppFirstToolStripMenuItem_Click);
			toolStripMenuItemLVPEnabled.CheckOnClick = true;
			toolStripMenuItemLVPEnabled.Enabled = false;
			toolStripMenuItemLVPEnabled.Name = "toolStripMenuItemLVPEnabled";
			toolStripMenuItemLVPEnabled.Size = new System.Drawing.Size(261, 22);
			toolStripMenuItemLVPEnabled.Text = "Use &LVP Program Entry";
			toolStripMenuItemLVPEnabled.CheckedChanged += new System.EventHandler(toolStripMenuItemLVPEnabled_CheckedChanged);
			fastProgrammingToolStripMenuItem.Checked = true;
			fastProgrammingToolStripMenuItem.CheckOnClick = true;
			fastProgrammingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			fastProgrammingToolStripMenuItem.Name = "fastProgrammingToolStripMenuItem";
			fastProgrammingToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
			fastProgrammingToolStripMenuItem.Text = "&Fast Programming";
			fastProgrammingToolStripMenuItem.Click += new System.EventHandler(programmingSpeed);
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(258, 6);
			UARTtoolStripMenuItem.Name = "UARTtoolStripMenuItem";
			UARTtoolStripMenuItem.Size = new System.Drawing.Size(261, 22);
			UARTtoolStripMenuItem.Text = "UART Tool...";
			UARTtoolStripMenuItem.Click += new System.EventHandler(UARTtoolStripMenuItem_Click);
			toolStripMenuItemLogicTool.Name = "toolStripMenuItemLogicTool";
			toolStripMenuItemLogicTool.Size = new System.Drawing.Size(261, 22);
			toolStripMenuItemLogicTool.Text = "Logic Tool...";
			toolStripMenuItemLogicTool.Click += new System.EventHandler(toolStripMenuItemLogicTool_Click);
			toolStripMenuItem6.Name = "toolStripMenuItem6";
			toolStripMenuItem6.Size = new System.Drawing.Size(258, 6);
			checkCommunicationToolStripMenuItem.Name = "checkCommunicationToolStripMenuItem";
			checkCommunicationToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
			checkCommunicationToolStripMenuItem.Text = "&Check Communication";
			checkCommunicationToolStripMenuItem.Click += new System.EventHandler(checkCommunication);
			troubleshhotToolStripMenuItem.Name = "troubleshhotToolStripMenuItem";
			troubleshhotToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
			troubleshhotToolStripMenuItem.Text = "Troubleshoot...";
			troubleshhotToolStripMenuItem.Click += new System.EventHandler(troubleshhotToolStripMenuItem_Click);
			toolStripMenuItemTestMemory.Name = "toolStripMenuItemTestMemory";
			toolStripMenuItemTestMemory.ShortcutKeys = (System.Windows.Forms.Keys)131156;
			toolStripMenuItemTestMemory.Size = new System.Drawing.Size(261, 22);
			toolStripMenuItemTestMemory.Text = "Test Memory";
			toolStripMenuItemTestMemory.Visible = false;
			toolStripMenuItemTestMemory.Click += new System.EventHandler(toolStripMenuItemTestMemory_Click);
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new System.Drawing.Size(258, 6);
			downloadPICkit2FirmwareToolStripMenuItem.Enabled = false;
			downloadPICkit2FirmwareToolStripMenuItem.Name = "downloadPICkit2FirmwareToolStripMenuItem";
			downloadPICkit2FirmwareToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
			downloadPICkit2FirmwareToolStripMenuItem.Text = "Download PICkit 2 Operating System";
			downloadPICkit2FirmwareToolStripMenuItem.Click += new System.EventHandler(downloadPk2Firmware);
			toolStripMenuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[7]
			{
				toolStripMenuItemSingleWindow,
				toolStripMenuItemMultiWindow,
				toolStripMenuItem7,
				toolStripMenuItemShowProgramMemory,
				toolStripMenuItemShowEEPROMData,
				toolStripMenuItem9,
				mainWindowAlwaysInFrontToolStripMenuItem
			});
			toolStripMenuItemView.Name = "toolStripMenuItemView";
			toolStripMenuItemView.Size = new System.Drawing.Size(41, 20);
			toolStripMenuItemView.Text = "View";
			toolStripMenuItemSingleWindow.Checked = true;
			toolStripMenuItemSingleWindow.CheckState = System.Windows.Forms.CheckState.Checked;
			toolStripMenuItemSingleWindow.Name = "toolStripMenuItemSingleWindow";
			toolStripMenuItemSingleWindow.Size = new System.Drawing.Size(261, 22);
			toolStripMenuItemSingleWindow.Text = "Single Window";
			toolStripMenuItemSingleWindow.Click += new System.EventHandler(toolStripMenuItemSingleWindow_Click);
			toolStripMenuItemMultiWindow.Name = "toolStripMenuItemMultiWindow";
			toolStripMenuItemMultiWindow.Size = new System.Drawing.Size(261, 22);
			toolStripMenuItemMultiWindow.Text = "Multi-Window";
			toolStripMenuItemMultiWindow.Click += new System.EventHandler(toolStripMenuItemMultiWindow_Click);
			toolStripMenuItem7.Name = "toolStripMenuItem7";
			toolStripMenuItem7.Size = new System.Drawing.Size(258, 6);
			toolStripMenuItemShowProgramMemory.Enabled = false;
			toolStripMenuItemShowProgramMemory.Name = "toolStripMenuItemShowProgramMemory";
			toolStripMenuItemShowProgramMemory.Size = new System.Drawing.Size(261, 22);
			toolStripMenuItemShowProgramMemory.Text = "Show Program Memory";
			toolStripMenuItemShowProgramMemory.Click += new System.EventHandler(toolStripMenuItemShowProgramMemory_Click);
			toolStripMenuItemShowEEPROMData.Enabled = false;
			toolStripMenuItemShowEEPROMData.Name = "toolStripMenuItemShowEEPROMData";
			toolStripMenuItemShowEEPROMData.Size = new System.Drawing.Size(261, 22);
			toolStripMenuItemShowEEPROMData.Text = "Show EEPROM Data";
			toolStripMenuItemShowEEPROMData.Click += new System.EventHandler(toolStripMenuItemShowEEPROMData_Click);
			toolStripMenuItem9.Name = "toolStripMenuItem9";
			toolStripMenuItem9.Size = new System.Drawing.Size(258, 6);
			mainWindowAlwaysInFrontToolStripMenuItem.CheckOnClick = true;
			mainWindowAlwaysInFrontToolStripMenuItem.Enabled = false;
			mainWindowAlwaysInFrontToolStripMenuItem.Name = "mainWindowAlwaysInFrontToolStripMenuItem";
			mainWindowAlwaysInFrontToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
			mainWindowAlwaysInFrontToolStripMenuItem.Text = "Associate / Memory Displays in Front";
			mainWindowAlwaysInFrontToolStripMenuItem.Click += new System.EventHandler(mainWindowAlwaysInFrontToolStripMenuItem_Click);
			helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[9]
			{
				usersGuideToolStripMenuItem,
				toolStripMenuItemProgToGo,
				toolStripMenuItemLogicToolUG,
				uG44pinToolStripMenuItem,
				lpcUsersGuideToolStripMenuItem,
				webPk2ToolStripMenuItem,
				readMeToolStripMenuItem,
				toolStripMenuItem3,
				aboutToolStripMenuItem
			});
			helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			helpToolStripMenuItem.Text = "&Help";
			usersGuideToolStripMenuItem.Name = "usersGuideToolStripMenuItem";
			usersGuideToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			usersGuideToolStripMenuItem.Text = "PICkit 2 &User's Guide";
			usersGuideToolStripMenuItem.Click += new System.EventHandler(launchUsersGuide);
			toolStripMenuItemProgToGo.Name = "toolStripMenuItemProgToGo";
			toolStripMenuItemProgToGo.Size = new System.Drawing.Size(206, 22);
			toolStripMenuItemProgToGo.Text = "Programmer-To-Go Guide";
			toolStripMenuItemProgToGo.Click += new System.EventHandler(toolStripMenuItemProgToGo_Click);
			toolStripMenuItemLogicToolUG.Name = "toolStripMenuItemLogicToolUG";
			toolStripMenuItemLogicToolUG.Size = new System.Drawing.Size(206, 22);
			toolStripMenuItemLogicToolUG.Text = "Logic Tool User Guide";
			toolStripMenuItemLogicToolUG.Click += new System.EventHandler(toolStripMenuItemLogicToolUG_Click);
			uG44pinToolStripMenuItem.Name = "uG44pinToolStripMenuItem";
			uG44pinToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			uG44pinToolStripMenuItem.Text = "44-Pin Demo Board Guide";
			uG44pinToolStripMenuItem.Click += new System.EventHandler(uG44pinToolStripMenuItem_Click);
			lpcUsersGuideToolStripMenuItem.Name = "lpcUsersGuideToolStripMenuItem";
			lpcUsersGuideToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			lpcUsersGuideToolStripMenuItem.Text = "LPC Demo Board Guide";
			lpcUsersGuideToolStripMenuItem.Click += new System.EventHandler(launchLPCDemoGuide);
			webPk2ToolStripMenuItem.Name = "webPk2ToolStripMenuItem";
			webPk2ToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			webPk2ToolStripMenuItem.Text = "PICkit 2 on the web";
			webPk2ToolStripMenuItem.Click += new System.EventHandler(pickit2OnTheWeb);
			readMeToolStripMenuItem.Name = "readMeToolStripMenuItem";
			readMeToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			readMeToolStripMenuItem.Text = "&ReadMe";
			readMeToolStripMenuItem.Click += new System.EventHandler(launchReadMe);
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			toolStripMenuItem3.Size = new System.Drawing.Size(203, 6);
			aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			aboutToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
			aboutToolStripMenuItem.Text = "&About";
			aboutToolStripMenuItem.Click += new System.EventHandler(clickAbout);
			testToolStripMenuItem.Name = "testToolStripMenuItem";
			testToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			testToolStripMenuItem.Text = "Test";
			testToolStripMenuItem.Visible = false;
			testToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(testMenuDropDownItemClicked);
			statusGroupBox.Controls.Add(labelConfig9);
			statusGroupBox.Controls.Add(labelLVP);
			statusGroupBox.Controls.Add(labelOSSCALInvalid);
			statusGroupBox.Controls.Add(checkBoxA2CS);
			statusGroupBox.Controls.Add(checkBoxA1CS);
			statusGroupBox.Controls.Add(checkBoxA0CS);
			statusGroupBox.Controls.Add(buttonShowIDMem);
			statusGroupBox.Controls.Add(displayRev);
			statusGroupBox.Controls.Add(labelCodeProtect);
			statusGroupBox.Controls.Add(comboBoxSelectPart);
			statusGroupBox.Controls.Add(displayBandGap);
			statusGroupBox.Controls.Add(labelBandGap);
			statusGroupBox.Controls.Add(displayOSCCAL);
			statusGroupBox.Controls.Add(labelOSCCAL);
			statusGroupBox.Controls.Add(displayChecksum);
			statusGroupBox.Controls.Add(displayUserIDs);
			statusGroupBox.Controls.Add(displayDevice);
			statusGroupBox.Controls.Add(labelConfig);
			statusGroupBox.Controls.Add(dataGridConfigWords);
			statusGroupBox.Controls.Add(labelChecksum);
			statusGroupBox.Controls.Add(labelUserIDs);
			statusGroupBox.Controls.Add(labelDevice);
			statusGroupBox.Cursor = System.Windows.Forms.Cursors.Default;
			statusGroupBox.ForeColor = System.Drawing.SystemColors.ControlText;
			statusGroupBox.Location = new System.Drawing.Point(12, 27);
			statusGroupBox.Margin = new System.Windows.Forms.Padding(2);
			statusGroupBox.Name = "statusGroupBox";
			statusGroupBox.Padding = new System.Windows.Forms.Padding(2);
			statusGroupBox.Size = new System.Drawing.Size(514, 102);
			statusGroupBox.TabIndex = 1;
			statusGroupBox.TabStop = false;
			statusGroupBox.Text = "Device Configuration";
			labelOSSCALInvalid.AutoSize = true;
			labelOSSCALInvalid.ForeColor = System.Drawing.Color.Red;
			labelOSSCALInvalid.Location = new System.Drawing.Point(284, 61);
			labelOSSCALInvalid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			labelOSSCALInvalid.Name = "labelOSSCALInvalid";
			labelOSSCALInvalid.Size = new System.Drawing.Size(68, 13);
			labelOSSCALInvalid.TabIndex = 22;
			labelOSSCALInvalid.Text = "Invalid Value";
			labelOSSCALInvalid.Visible = false;
			checkBoxA2CS.AutoSize = true;
			checkBoxA2CS.Enabled = false;
			checkBoxA2CS.Location = new System.Drawing.Point(411, 47);
			checkBoxA2CS.Margin = new System.Windows.Forms.Padding(2);
			checkBoxA2CS.Name = "checkBoxA2CS";
			checkBoxA2CS.Size = new System.Drawing.Size(96, 17);
			checkBoxA2CS.TabIndex = 21;
			checkBoxA2CS.Text = "A2 Chip Select";
			checkBoxA2CS.UseVisualStyleBackColor = true;
			checkBoxA2CS.Visible = false;
			checkBoxA1CS.AutoSize = true;
			checkBoxA1CS.Enabled = false;
			checkBoxA1CS.Location = new System.Drawing.Point(411, 31);
			checkBoxA1CS.Margin = new System.Windows.Forms.Padding(2);
			checkBoxA1CS.Name = "checkBoxA1CS";
			checkBoxA1CS.Size = new System.Drawing.Size(96, 17);
			checkBoxA1CS.TabIndex = 20;
			checkBoxA1CS.Text = "A1 Chip Select";
			checkBoxA1CS.UseVisualStyleBackColor = true;
			checkBoxA1CS.Visible = false;
			checkBoxA0CS.AutoSize = true;
			checkBoxA0CS.Enabled = false;
			checkBoxA0CS.Location = new System.Drawing.Point(411, 15);
			checkBoxA0CS.Margin = new System.Windows.Forms.Padding(2);
			checkBoxA0CS.Name = "checkBoxA0CS";
			checkBoxA0CS.Size = new System.Drawing.Size(96, 17);
			checkBoxA0CS.TabIndex = 19;
			checkBoxA0CS.Text = "A0 Chip Select";
			checkBoxA0CS.UseVisualStyleBackColor = true;
			checkBoxA0CS.Visible = false;
			buttonShowIDMem.Location = new System.Drawing.Point(79, 46);
			buttonShowIDMem.Margin = new System.Windows.Forms.Padding(2);
			buttonShowIDMem.Name = "buttonShowIDMem";
			buttonShowIDMem.Size = new System.Drawing.Size(65, 22);
			buttonShowIDMem.TabIndex = 15;
			buttonShowIDMem.Text = "Display";
			buttonShowIDMem.UseVisualStyleBackColor = true;
			buttonShowIDMem.Visible = false;
			buttonShowIDMem.Click += new System.EventHandler(buttonShowIDMem_Click);
			displayRev.AutoSize = true;
			displayRev.Location = new System.Drawing.Point(135, 75);
			displayRev.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			displayRev.Name = "displayRev";
			displayRev.Size = new System.Drawing.Size(27, 13);
			displayRev.TabIndex = 14;
			displayRev.Text = "Rev";
			displayRev.Visible = false;
			labelCodeProtect.AutoSize = true;
			labelCodeProtect.ForeColor = System.Drawing.Color.Red;
			labelCodeProtect.Location = new System.Drawing.Point(242, 41);
			labelCodeProtect.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			labelCodeProtect.Name = "labelCodeProtect";
			labelCodeProtect.Size = new System.Drawing.Size(69, 13);
			labelCodeProtect.TabIndex = 13;
			labelCodeProtect.Text = "Code Protect";
			labelCodeProtect.Visible = false;
			comboBoxSelectPart.BackColor = System.Drawing.SystemColors.Info;
			comboBoxSelectPart.DropDownHeight = 212;
			comboBoxSelectPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBoxSelectPart.FormattingEnabled = true;
			comboBoxSelectPart.IntegralHeight = false;
			comboBoxSelectPart.Items.AddRange(new object[1]
			{
				"-Select Device-"
			});
			comboBoxSelectPart.Location = new System.Drawing.Point(79, 22);
			comboBoxSelectPart.Margin = new System.Windows.Forms.Padding(2);
			comboBoxSelectPart.Name = "comboBoxSelectPart";
			comboBoxSelectPart.Size = new System.Drawing.Size(148, 21);
			comboBoxSelectPart.Sorted = true;
			comboBoxSelectPart.TabIndex = 12;
			comboBoxSelectPart.Visible = false;
			comboBoxSelectPart.SelectionChangeCommitted += new System.EventHandler(selectPart);
			displayBandGap.AutoSize = true;
			displayBandGap.Location = new System.Drawing.Point(439, 75);
			displayBandGap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			displayBandGap.Name = "displayBandGap";
			displayBandGap.Size = new System.Drawing.Size(31, 13);
			displayBandGap.TabIndex = 11;
			displayBandGap.Text = "0000";
			labelBandGap.AutoSize = true;
			labelBandGap.Location = new System.Drawing.Point(379, 75);
			labelBandGap.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			labelBandGap.Name = "labelBandGap";
			labelBandGap.Size = new System.Drawing.Size(55, 13);
			labelBandGap.TabIndex = 10;
			labelBandGap.Text = "BandGap:";
			displayOSCCAL.AutoSize = true;
			displayOSCCAL.Location = new System.Drawing.Point(300, 75);
			displayOSCCAL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			displayOSCCAL.Name = "displayOSCCAL";
			displayOSCCAL.Size = new System.Drawing.Size(31, 13);
			displayOSCCAL.TabIndex = 9;
			displayOSCCAL.Text = "0000";
			labelOSCCAL.AutoSize = true;
			labelOSCCAL.Location = new System.Drawing.Point(242, 75);
			labelOSCCAL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			labelOSCCAL.Name = "labelOSCCAL";
			labelOSCCAL.Size = new System.Drawing.Size(52, 13);
			labelOSCCAL.TabIndex = 8;
			labelOSCCAL.Text = "OSCCAL:";
			displayChecksum.AutoSize = true;
			displayChecksum.Location = new System.Drawing.Point(76, 75);
			displayChecksum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			displayChecksum.Name = "displayChecksum";
			displayChecksum.Size = new System.Drawing.Size(31, 13);
			displayChecksum.TabIndex = 7;
			displayChecksum.Text = "0000";
			displayUserIDs.AutoSize = true;
			displayUserIDs.Location = new System.Drawing.Point(76, 50);
			displayUserIDs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			displayUserIDs.Name = "displayUserIDs";
			displayUserIDs.Size = new System.Drawing.Size(64, 13);
			displayUserIDs.TabIndex = 6;
			displayUserIDs.Text = "00 00 00 00";
			displayDevice.AutoSize = true;
			displayDevice.Location = new System.Drawing.Point(79, 25);
			displayDevice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			displayDevice.Name = "displayDevice";
			displayDevice.Size = new System.Drawing.Size(63, 13);
			displayDevice.TabIndex = 5;
			displayDevice.Text = "Not Present";
			labelConfig.AutoSize = true;
			labelConfig.Cursor = System.Windows.Forms.Cursors.Hand;
			labelConfig.Enabled = false;
			labelConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
			labelConfig.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			labelConfig.Location = new System.Drawing.Point(242, 25);
			labelConfig.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			labelConfig.Name = "labelConfig";
			labelConfig.Size = new System.Drawing.Size(72, 13);
			labelConfig.TabIndex = 4;
			labelConfig.Text = "Configuration:";
			labelConfig.Click += new System.EventHandler(labelConfig_Click);
			dataGridConfigWords.AllowUserToAddRows = false;
			dataGridConfigWords.AllowUserToDeleteRows = false;
			dataGridConfigWords.AllowUserToResizeColumns = false;
			dataGridConfigWords.AllowUserToResizeRows = false;
			dataGridConfigWords.BackgroundColor = System.Drawing.SystemColors.ControlDark;
			dataGridConfigWords.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridConfigWords.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dataGridConfigWords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dataGridConfigWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridConfigWords.ColumnHeadersVisible = false;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			dataGridConfigWords.DefaultCellStyle = dataGridViewCellStyle2;
			dataGridConfigWords.Enabled = false;
			dataGridConfigWords.GridColor = System.Drawing.SystemColors.Control;
			dataGridConfigWords.Location = new System.Drawing.Point(320, 24);
			dataGridConfigWords.Margin = new System.Windows.Forms.Padding(2);
			dataGridConfigWords.MultiSelect = false;
			dataGridConfigWords.Name = "dataGridConfigWords";
			dataGridConfigWords.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dataGridConfigWords.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dataGridConfigWords.RowHeadersVisible = false;
			dataGridConfigWords.ScrollBars = System.Windows.Forms.ScrollBars.None;
			dataGridConfigWords.Size = new System.Drawing.Size(160, 34);
			dataGridConfigWords.TabIndex = 3;
			labelChecksum.AutoSize = true;
			labelChecksum.Location = new System.Drawing.Point(6, 75);
			labelChecksum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			labelChecksum.Name = "labelChecksum";
			labelChecksum.Size = new System.Drawing.Size(60, 13);
			labelChecksum.TabIndex = 2;
			labelChecksum.Text = "Checksum:";
			labelUserIDs.AutoSize = true;
			labelUserIDs.Location = new System.Drawing.Point(6, 50);
			labelUserIDs.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			labelUserIDs.Name = "labelUserIDs";
			labelUserIDs.Size = new System.Drawing.Size(51, 13);
			labelUserIDs.TabIndex = 1;
			labelUserIDs.Text = "User IDs:";
			labelDevice.AutoSize = true;
			labelDevice.Location = new System.Drawing.Point(6, 25);
			labelDevice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			labelDevice.Name = "labelDevice";
			labelDevice.Size = new System.Drawing.Size(44, 13);
			labelDevice.TabIndex = 0;
			labelDevice.Text = "Device:";
			pictureBoxLogo.Image = (System.Drawing.Image)resources.GetObject("pictureBoxLogo.Image");
			pictureBoxLogo.InitialImage = (System.Drawing.Image)resources.GetObject("pictureBoxLogo.InitialImage");
			pictureBoxLogo.Location = new System.Drawing.Point(370, 134);
			pictureBoxLogo.Margin = new System.Windows.Forms.Padding(2);
			pictureBoxLogo.Name = "pictureBoxLogo";
			pictureBoxLogo.Size = new System.Drawing.Size(152, 42);
			pictureBoxLogo.TabIndex = 2;
			pictureBoxLogo.TabStop = false;
			displayStatusWindow.BackColor = System.Drawing.SystemColors.Info;
			displayStatusWindow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			displayStatusWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			displayStatusWindow.Location = new System.Drawing.Point(12, 137);
			displayStatusWindow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			displayStatusWindow.Name = "displayStatusWindow";
			displayStatusWindow.Size = new System.Drawing.Size(342, 36);
			displayStatusWindow.TabIndex = 4;
			displayStatusWindow.Text = "Status\r\nWindow";
			buttonRead.Enabled = false;
			buttonRead.Location = new System.Drawing.Point(12, 204);
			buttonRead.Margin = new System.Windows.Forms.Padding(2);
			buttonRead.Name = "buttonRead";
			buttonRead.Size = new System.Drawing.Size(57, 26);
			buttonRead.TabIndex = 5;
			buttonRead.Text = "Read";
			buttonRead.UseVisualStyleBackColor = true;
			buttonRead.Click += new System.EventHandler(readDevice);
			progressBar1.BackColor = System.Drawing.SystemColors.Control;
			progressBar1.Location = new System.Drawing.Point(12, 182);
			progressBar1.Margin = new System.Windows.Forms.Padding(2);
			progressBar1.MarqueeAnimationSpeed = 50;
			progressBar1.Name = "progressBar1";
			progressBar1.Size = new System.Drawing.Size(342, 15);
			progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			progressBar1.TabIndex = 6;
			buttonWrite.Enabled = false;
			buttonWrite.Location = new System.Drawing.Point(75, 204);
			buttonWrite.Margin = new System.Windows.Forms.Padding(2);
			buttonWrite.Name = "buttonWrite";
			buttonWrite.Size = new System.Drawing.Size(57, 26);
			buttonWrite.TabIndex = 7;
			buttonWrite.Text = "Write";
			buttonWrite.UseVisualStyleBackColor = true;
			buttonWrite.Click += new System.EventHandler(writeDevice);
			buttonVerify.Enabled = false;
			buttonVerify.Location = new System.Drawing.Point(138, 204);
			buttonVerify.Margin = new System.Windows.Forms.Padding(2);
			buttonVerify.Name = "buttonVerify";
			buttonVerify.Size = new System.Drawing.Size(57, 26);
			buttonVerify.TabIndex = 8;
			buttonVerify.Text = "Verify";
			buttonVerify.UseVisualStyleBackColor = true;
			buttonVerify.Click += new System.EventHandler(verifyDevice);
			buttonErase.Enabled = false;
			buttonErase.Location = new System.Drawing.Point(201, 204);
			buttonErase.Margin = new System.Windows.Forms.Padding(2);
			buttonErase.Name = "buttonErase";
			buttonErase.Size = new System.Drawing.Size(57, 26);
			buttonErase.TabIndex = 9;
			buttonErase.Text = "Erase";
			buttonErase.UseVisualStyleBackColor = true;
			buttonErase.Click += new System.EventHandler(eraseDevice);
			buttonBlankCheck.Enabled = false;
			buttonBlankCheck.Location = new System.Drawing.Point(264, 204);
			buttonBlankCheck.Margin = new System.Windows.Forms.Padding(2);
			buttonBlankCheck.Name = "buttonBlankCheck";
			buttonBlankCheck.Size = new System.Drawing.Size(91, 26);
			buttonBlankCheck.TabIndex = 10;
			buttonBlankCheck.Text = "Blank Check";
			buttonBlankCheck.UseVisualStyleBackColor = true;
			buttonBlankCheck.Click += new System.EventHandler(blankCheck);
			chkBoxVddOn.AutoSize = true;
			chkBoxVddOn.Enabled = false;
			chkBoxVddOn.Location = new System.Drawing.Point(15, 15);
			chkBoxVddOn.Margin = new System.Windows.Forms.Padding(2);
			chkBoxVddOn.Name = "chkBoxVddOn";
			chkBoxVddOn.Size = new System.Drawing.Size(40, 17);
			chkBoxVddOn.TabIndex = 11;
			chkBoxVddOn.Text = "On";
			chkBoxVddOn.UseVisualStyleBackColor = true;
			chkBoxVddOn.Click += new System.EventHandler(guiVddControl);
			numUpDnVDD.DecimalPlaces = 1;
			numUpDnVDD.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			numUpDnVDD.Increment = new decimal(new int[4]
			{
				1,
				0,
				0,
				65536
			});
			numUpDnVDD.Location = new System.Drawing.Point(97, 15);
			numUpDnVDD.Margin = new System.Windows.Forms.Padding(2);
			numUpDnVDD.Maximum = new decimal(new int[4]
			{
				50,
				0,
				0,
				65536
			});
			numUpDnVDD.Minimum = new decimal(new int[4]
			{
				25,
				0,
				0,
				65536
			});
			numUpDnVDD.Name = "numUpDnVDD";
			numUpDnVDD.Size = new System.Drawing.Size(53, 26);
			numUpDnVDD.TabIndex = 14;
			numUpDnVDD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			numUpDnVDD.Value = new decimal(new int[4]
			{
				25,
				0,
				0,
				65536
			});
			numUpDnVDD.ValueChanged += new System.EventHandler(guiChangeVDD);
			groupBoxVDD.Controls.Add(checkBoxMCLR);
			groupBoxVDD.Controls.Add(numUpDnVDD);
			groupBoxVDD.Controls.Add(chkBoxVddOn);
			groupBoxVDD.ForeColor = System.Drawing.SystemColors.ControlText;
			groupBoxVDD.Location = new System.Drawing.Point(370, 179);
			groupBoxVDD.Margin = new System.Windows.Forms.Padding(2);
			groupBoxVDD.Name = "groupBoxVDD";
			groupBoxVDD.Padding = new System.Windows.Forms.Padding(2);
			groupBoxVDD.Size = new System.Drawing.Size(156, 51);
			groupBoxVDD.TabIndex = 17;
			groupBoxVDD.TabStop = false;
			groupBoxVDD.Text = "VDD PICkit 2";
			checkBoxMCLR.AutoSize = true;
			checkBoxMCLR.Enabled = false;
			checkBoxMCLR.Location = new System.Drawing.Point(15, 32);
			checkBoxMCLR.Margin = new System.Windows.Forms.Padding(2);
			checkBoxMCLR.Name = "checkBoxMCLR";
			checkBoxMCLR.Size = new System.Drawing.Size(61, 17);
			checkBoxMCLR.TabIndex = 15;
			checkBoxMCLR.Text = "/MCLR";
			checkBoxMCLR.UseVisualStyleBackColor = true;
			checkBoxMCLR.Click += new System.EventHandler(MCLRtoolStripMenuItem_Click);
			groupBoxProgMem.Controls.Add(dataGridProgramMemory);
			groupBoxProgMem.Controls.Add(displayDataSource);
			groupBoxProgMem.Controls.Add(labelDataSource);
			groupBoxProgMem.Controls.Add(comboBoxProgMemView);
			groupBoxProgMem.Controls.Add(checkBoxProgMemEnabled);
			groupBoxProgMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			groupBoxProgMem.ForeColor = System.Drawing.SystemColors.InfoText;
			groupBoxProgMem.Location = new System.Drawing.Point(12, 236);
			groupBoxProgMem.Margin = new System.Windows.Forms.Padding(2);
			groupBoxProgMem.Name = "groupBoxProgMem";
			groupBoxProgMem.Padding = new System.Windows.Forms.Padding(2);
			groupBoxProgMem.Size = new System.Drawing.Size(514, 259);
			groupBoxProgMem.TabIndex = 18;
			groupBoxProgMem.TabStop = false;
			groupBoxProgMem.Text = "Program Memory";
			dataGridProgramMemory.AllowUserToAddRows = false;
			dataGridProgramMemory.AllowUserToDeleteRows = false;
			dataGridProgramMemory.AllowUserToResizeColumns = false;
			dataGridProgramMemory.AllowUserToResizeRows = false;
			dataGridProgramMemory.BackgroundColor = System.Drawing.SystemColors.Window;
			dataGridProgramMemory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			dataGridProgramMemory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridProgramMemory.ColumnHeadersVisible = false;
			dataGridProgramMemory.ContextMenuStrip = contextMenuStrip1;
			dataGridProgramMemory.Enabled = false;
			dataGridProgramMemory.Location = new System.Drawing.Point(6, 44);
			dataGridProgramMemory.Margin = new System.Windows.Forms.Padding(2);
			dataGridProgramMemory.Name = "dataGridProgramMemory";
			dataGridProgramMemory.RowHeadersVisible = false;
			dataGridProgramMemory.RowHeadersWidth = 75;
			dataGridProgramMemory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridProgramMemory.RowsDefaultCellStyle = dataGridViewCellStyle4;
			dataGridProgramMemory.RowTemplate.Height = 17;
			dataGridProgramMemory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			dataGridProgramMemory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			dataGridProgramMemory.Size = new System.Drawing.Size(502, 208);
			dataGridProgramMemory.TabIndex = 4;
			dataGridProgramMemory.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridProgramMemory_CellMouseDown);
			dataGridProgramMemory.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(progMemEdit);
			contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
			{
				toolStripMenuItemContextSelectAll,
				toolStripMenuItemContextCopy
			});
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new System.Drawing.Size(164, 48);
			contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(contextMenuStrip1_ItemClicked);
			toolStripMenuItemContextSelectAll.Name = "toolStripMenuItemContextSelectAll";
			toolStripMenuItemContextSelectAll.ShortcutKeyDisplayString = "Ctrl-A";
			toolStripMenuItemContextSelectAll.Size = new System.Drawing.Size(163, 22);
			toolStripMenuItemContextSelectAll.Text = "Select All";
			toolStripMenuItemContextCopy.Name = "toolStripMenuItemContextCopy";
			toolStripMenuItemContextCopy.ShortcutKeyDisplayString = "Ctrl-C";
			toolStripMenuItemContextCopy.Size = new System.Drawing.Size(163, 22);
			toolStripMenuItemContextCopy.Text = "Copy";
			displayDataSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			displayDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			displayDataSource.Location = new System.Drawing.Point(229, 19);
			displayDataSource.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			displayDataSource.Name = "displayDataSource";
			displayDataSource.Size = new System.Drawing.Size(279, 16);
			displayDataSource.TabIndex = 3;
			displayDataSource.Text = "None (Empty/Erased)";
			displayDataSource.UseCompatibleTextRendering = true;
			labelDataSource.AutoSize = true;
			labelDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelDataSource.Location = new System.Drawing.Point(176, 20);
			labelDataSource.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			labelDataSource.Name = "labelDataSource";
			labelDataSource.Size = new System.Drawing.Size(51, 13);
			labelDataSource.TabIndex = 2;
			labelDataSource.Text = "Source:";
			comboBoxProgMemView.BackColor = System.Drawing.SystemColors.Info;
			comboBoxProgMemView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBoxProgMemView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			comboBoxProgMemView.FormattingEnabled = true;
			comboBoxProgMemView.Items.AddRange(new object[3]
			{
				"Hex Only",
				"Word ASCII",
				"Byte ASCII"
			});
			comboBoxProgMemView.Location = new System.Drawing.Point(79, 17);
			comboBoxProgMemView.Margin = new System.Windows.Forms.Padding(2);
			comboBoxProgMemView.Name = "comboBoxProgMemView";
			comboBoxProgMemView.Size = new System.Drawing.Size(91, 21);
			comboBoxProgMemView.TabIndex = 1;
			comboBoxProgMemView.SelectionChangeCommitted += new System.EventHandler(progMemViewChanged);
			checkBoxProgMemEnabled.AutoSize = true;
			checkBoxProgMemEnabled.Checked = true;
			checkBoxProgMemEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBoxProgMemEnabled.Enabled = false;
			checkBoxProgMemEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			checkBoxProgMemEnabled.Location = new System.Drawing.Point(6, 19);
			checkBoxProgMemEnabled.Margin = new System.Windows.Forms.Padding(2);
			checkBoxProgMemEnabled.Name = "checkBoxProgMemEnabled";
			checkBoxProgMemEnabled.Size = new System.Drawing.Size(65, 17);
			checkBoxProgMemEnabled.TabIndex = 0;
			checkBoxProgMemEnabled.Text = "Enabled";
			checkBoxProgMemEnabled.UseVisualStyleBackColor = true;
			checkBoxProgMemEnabled.Click += new System.EventHandler(memorySelectVerify);
			openHexFileDialog.DefaultExt = "hex";
			openHexFileDialog.Filter = "HEX files|*.hex|All files|*.*";
			openHexFileDialog.Title = "Import Hex File";
			openHexFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(importHexFile);
			saveHexFileDialog.DefaultExt = "hex";
			saveHexFileDialog.Filter = "Hex files|*.hex|All files|*.*";
			saveHexFileDialog.Title = "Export Hex File";
			saveHexFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(exportHexFile);
			openFWFile.DefaultExt = "hex";
			openFWFile.Filter = "PICkit 2 OS|pk*.hex|All files|*.*";
			openFWFile.InitialDirectory = "c:\\Program Files\\Microchip\\PICkit 2 v2";
			openFWFile.Title = "Open PICkit 2 Operating System File";
			timerButton.Interval = 250;
			timerButton.Tick += new System.EventHandler(timerGoesOff);
			groupBoxEEMem.Controls.Add(displayEEProgInfo);
			groupBoxEEMem.Controls.Add(dataGridViewEEPROM);
			groupBoxEEMem.Controls.Add(comboBoxEE);
			groupBoxEEMem.Controls.Add(checkBoxEEMem);
			groupBoxEEMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			groupBoxEEMem.ForeColor = System.Drawing.SystemColors.InfoText;
			groupBoxEEMem.Location = new System.Drawing.Point(12, 501);
			groupBoxEEMem.Margin = new System.Windows.Forms.Padding(2);
			groupBoxEEMem.Name = "groupBoxEEMem";
			groupBoxEEMem.Padding = new System.Windows.Forms.Padding(2);
			groupBoxEEMem.Size = new System.Drawing.Size(399, 123);
			groupBoxEEMem.TabIndex = 19;
			groupBoxEEMem.TabStop = false;
			groupBoxEEMem.Text = "EEPROM Data";
			displayEEProgInfo.AutoSize = true;
			displayEEProgInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			displayEEProgInfo.ForeColor = System.Drawing.Color.Red;
			displayEEProgInfo.Location = new System.Drawing.Point(186, 20);
			displayEEProgInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			displayEEProgInfo.Name = "displayEEProgInfo";
			displayEEProgInfo.Size = new System.Drawing.Size(206, 13);
			displayEEProgInfo.TabIndex = 7;
			displayEEProgInfo.Text = "Preserve EEPROM and User IDs on write.";
			displayEEProgInfo.Visible = false;
			dataGridViewEEPROM.AllowUserToAddRows = false;
			dataGridViewEEPROM.AllowUserToDeleteRows = false;
			dataGridViewEEPROM.AllowUserToResizeColumns = false;
			dataGridViewEEPROM.AllowUserToResizeRows = false;
			dataGridViewEEPROM.BackgroundColor = System.Drawing.SystemColors.Window;
			dataGridViewEEPROM.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			dataGridViewEEPROM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewEEPROM.ColumnHeadersVisible = false;
			dataGridViewEEPROM.ContextMenuStrip = contextMenuStrip1;
			dataGridViewEEPROM.Location = new System.Drawing.Point(6, 44);
			dataGridViewEEPROM.Margin = new System.Windows.Forms.Padding(2);
			dataGridViewEEPROM.Name = "dataGridViewEEPROM";
			dataGridViewEEPROM.RowHeadersVisible = false;
			dataGridViewEEPROM.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewEEPROM.RowsDefaultCellStyle = dataGridViewCellStyle5;
			dataGridViewEEPROM.RowTemplate.Height = 17;
			dataGridViewEEPROM.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			dataGridViewEEPROM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			dataGridViewEEPROM.Size = new System.Drawing.Size(387, 72);
			dataGridViewEEPROM.TabIndex = 6;
			dataGridViewEEPROM.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridViewEEPROM_CellMouseDown);
			dataGridViewEEPROM.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(eEpromEdit);
			comboBoxEE.BackColor = System.Drawing.SystemColors.Info;
			comboBoxEE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBoxEE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			comboBoxEE.FormattingEnabled = true;
			comboBoxEE.Items.AddRange(new object[3]
			{
				"Hex Only",
				"Word ASCII",
				"Byte ASCII"
			});
			comboBoxEE.Location = new System.Drawing.Point(79, 17);
			comboBoxEE.Margin = new System.Windows.Forms.Padding(2);
			comboBoxEE.Name = "comboBoxEE";
			comboBoxEE.Size = new System.Drawing.Size(91, 21);
			comboBoxEE.TabIndex = 5;
			comboBoxEE.SelectionChangeCommitted += new System.EventHandler(progMemViewChanged);
			checkBoxEEMem.AutoSize = true;
			checkBoxEEMem.Checked = true;
			checkBoxEEMem.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBoxEEMem.Enabled = false;
			checkBoxEEMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			checkBoxEEMem.Location = new System.Drawing.Point(6, 19);
			checkBoxEEMem.Margin = new System.Windows.Forms.Padding(2);
			checkBoxEEMem.Name = "checkBoxEEMem";
			checkBoxEEMem.Size = new System.Drawing.Size(65, 17);
			checkBoxEEMem.TabIndex = 0;
			checkBoxEEMem.Text = "Enabled";
			checkBoxEEMem.UseVisualStyleBackColor = true;
			checkBoxEEMem.Click += new System.EventHandler(memorySelectVerify);
			buttonExportHex.Location = new System.Drawing.Point(423, 545);
			buttonExportHex.Margin = new System.Windows.Forms.Padding(2);
			buttonExportHex.Name = "buttonExportHex";
			buttonExportHex.Size = new System.Drawing.Size(103, 35);
			buttonExportHex.TabIndex = 21;
			buttonExportHex.Text = "Read Device +\r\nExport Hex File";
			buttonExportHex.UseVisualStyleBackColor = true;
			buttonExportHex.Click += new System.EventHandler(buttonReadExport);
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(423, 586);
			pictureBox1.Margin = new System.Windows.Forms.Padding(2);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(103, 38);
			pictureBox1.TabIndex = 22;
			pictureBox1.TabStop = false;
			timerDLFW.Tick += new System.EventHandler(autoDownloadFW);
			checkBoxAutoImportWrite.Appearance = System.Windows.Forms.Appearance.Button;
			checkBoxAutoImportWrite.Location = new System.Drawing.Point(423, 505);
			checkBoxAutoImportWrite.Margin = new System.Windows.Forms.Padding(2);
			checkBoxAutoImportWrite.Name = "checkBoxAutoImportWrite";
			checkBoxAutoImportWrite.Size = new System.Drawing.Size(103, 35);
			checkBoxAutoImportWrite.TabIndex = 23;
			checkBoxAutoImportWrite.Text = "Auto Import Hex\r\n+ Write Device";
			checkBoxAutoImportWrite.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			checkBoxAutoImportWrite.UseVisualStyleBackColor = true;
			checkBoxAutoImportWrite.Click += new System.EventHandler(checkBoxAutoImportWrite_Click);
			checkBoxAutoImportWrite.CheckedChanged += new System.EventHandler(checkBoxAutoImportWrite_Changed);
			timerAutoImportWrite.Interval = 250;
			timerAutoImportWrite.Tick += new System.EventHandler(timerAutoImportWrite_Tick);
			checkBoxProgMemEnabledAlt.AutoSize = true;
			checkBoxProgMemEnabledAlt.Checked = true;
			checkBoxProgMemEnabledAlt.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBoxProgMemEnabledAlt.Location = new System.Drawing.Point(16, 240);
			checkBoxProgMemEnabledAlt.Margin = new System.Windows.Forms.Padding(2);
			checkBoxProgMemEnabledAlt.Name = "checkBoxProgMemEnabledAlt";
			checkBoxProgMemEnabledAlt.Size = new System.Drawing.Size(147, 17);
			checkBoxProgMemEnabledAlt.TabIndex = 24;
			checkBoxProgMemEnabledAlt.Text = "Program Memory Enabled";
			checkBoxProgMemEnabledAlt.UseVisualStyleBackColor = true;
			checkBoxProgMemEnabledAlt.Visible = false;
			checkBoxProgMemEnabledAlt.Click += new System.EventHandler(memorySelectVerify);
			checkBoxEEDATAMemoryEnabledAlt.AutoSize = true;
			checkBoxEEDATAMemoryEnabledAlt.Checked = true;
			checkBoxEEDATAMemoryEnabledAlt.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBoxEEDATAMemoryEnabledAlt.Location = new System.Drawing.Point(16, 259);
			checkBoxEEDATAMemoryEnabledAlt.Margin = new System.Windows.Forms.Padding(2);
			checkBoxEEDATAMemoryEnabledAlt.Name = "checkBoxEEDATAMemoryEnabledAlt";
			checkBoxEEDATAMemoryEnabledAlt.Size = new System.Drawing.Size(140, 17);
			checkBoxEEDATAMemoryEnabledAlt.TabIndex = 25;
			checkBoxEEDATAMemoryEnabledAlt.Text = "EEPROM Data Enabled";
			checkBoxEEDATAMemoryEnabledAlt.UseVisualStyleBackColor = true;
			checkBoxEEDATAMemoryEnabledAlt.Visible = false;
			checkBoxEEDATAMemoryEnabledAlt.Click += new System.EventHandler(memorySelectVerify);
			timerInitalUpdate.Interval = 1;
			timerInitalUpdate.Tick += new System.EventHandler(timerInitalUpdate_Tick);
			labelLVP.AutoSize = true;
			labelLVP.ForeColor = System.Drawing.Color.Red;
			labelLVP.Location = new System.Drawing.Point(200, 7);
			labelLVP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			labelLVP.Name = "labelLVP";
			labelLVP.Size = new System.Drawing.Size(27, 13);
			labelLVP.TabIndex = 23;
			labelLVP.Text = "LVP";
			labelLVP.Visible = false;
			labelConfig9.AutoSize = true;
			labelConfig9.Location = new System.Drawing.Point(478, 43);
			labelConfig9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			labelConfig9.Name = "labelConfig9";
			labelConfig9.Size = new System.Drawing.Size(31, 13);
			labelConfig9.TabIndex = 24;
			labelConfig9.Text = "FFFF";
			labelConfig9.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(538, 636);
			base.Controls.Add(checkBoxEEDATAMemoryEnabledAlt);
			base.Controls.Add(checkBoxProgMemEnabledAlt);
			base.Controls.Add(checkBoxAutoImportWrite);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(buttonExportHex);
			base.Controls.Add(groupBoxEEMem);
			base.Controls.Add(groupBoxProgMem);
			base.Controls.Add(groupBoxVDD);
			base.Controls.Add(buttonBlankCheck);
			base.Controls.Add(buttonErase);
			base.Controls.Add(buttonVerify);
			base.Controls.Add(buttonWrite);
			base.Controls.Add(progressBar1);
			base.Controls.Add(buttonRead);
			base.Controls.Add(displayStatusWindow);
			base.Controls.Add(pictureBoxLogo);
			base.Controls.Add(statusGroupBox);
			base.Controls.Add(menuStrip1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MainMenuStrip = menuStrip1;
			base.Margin = new System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			MaximumSize = new System.Drawing.Size(544, 670);
			MinimumSize = new System.Drawing.Size(544, 320);
			base.Name = "FormPICkit2";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "PICkit 2 Programmer";
			base.Move += new System.EventHandler(FormPICkit2_Move);
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(pickitFormClosing);
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			statusGroupBox.ResumeLayout(false);
			statusGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridConfigWords).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
			((System.ComponentModel.ISupportInitialize)numUpDnVDD).EndInit();
			groupBoxVDD.ResumeLayout(false);
			groupBoxVDD.PerformLayout();
			groupBoxProgMem.ResumeLayout(false);
			groupBoxProgMem.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridProgramMemory).EndInit();
			contextMenuStrip1.ResumeLayout(false);
			groupBoxEEMem.ResumeLayout(false);
			groupBoxEEMem.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridViewEEPROM).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		[DllImport("user32.dll")]
		private static extern short FlashWindowEx(ref FLASHWINFO pwfi);

		public FormPICkit2()
		{
			InitializeComponent();
			float num = loadINI();
			if (mainWinOwnsMem)
			{
				AddOwnedForm(programMemMultiWin);
				AddOwnedForm(eepromDataMultiWin);
			}
			initializeGUI();
			if (!loadDeviceFile())
			{
				return;
			}
			if (toolStripMenuItemManualSelect.Checked)
			{
				ManualAutoSelectToggle(updateGUI_OK: false);
			}
			buildDeviceMenu();
			if (!allowDataEdits)
			{
				dataGridProgramMemory.ReadOnly = true;
				dataGridViewEEPROM.ReadOnly = true;
			}
			PICkitFunctions.ResetBuffers();
			testConnected = checkForTest();
			if (testConnected)
			{
				testConnected = testMenuBuild();
			}
			PIC32MXFunctions.UpdateStatusWinText = StatusWinWr;
			PIC32MXFunctions.ResetStatusBar = ResetStatusBar;
			PIC32MXFunctions.StepStatusBar = StepStatusBar;
			dsPIC33_PE.UpdateStatusWinText = StatusWinWr;
			dsPIC33_PE.ResetStatusBar = ResetStatusBar;
			dsPIC33_PE.StepStatusBar = StepStatusBar;
			PIC24F_PE.UpdateStatusWinText = StatusWinWr;
			PIC24F_PE.ResetStatusBar = ResetStatusBar;
			PIC24F_PE.StepStatusBar = StepStatusBar;
			uartWindow.VddCallback = SetVddState;
			logicWindow.VddCallback = SetVddState;
			if (!detectPICkit2(showFound: true, detectMult: true))
			{
				if (bootLoad)
				{
					return;
				}
				if (oldFirmware)
				{
					TestMemoryOpen = false;
					timerDLFW.Enabled = true;
					return;
				}
				Thread.Sleep(3000);
				if (!detectPICkit2(showFound: true, detectMult: true))
				{
					return;
				}
			}
			partialEnableGUIControls();
			PICkitFunctions.ExitUARTMode();
			PICkitFunctions.VddOff();
			PICkitFunctions.SetVDDVoltage(3.3f, 0.85f);
			if (autoDetectToolStripMenuItem.Checked)
			{
				lookForPoweredTarget(showMessageBox: false);
			}
			if (searchOnStartup && PICkitFunctions.DetectDevice(16777215, resetOnNotFound: true, chkBoxVddOn.Checked))
			{
				setGUIVoltageLimits(setValue: true);
				PICkitFunctions.SetVDDVoltage((float)numUpDnVDD.Value, 0.85f);
				displayStatusWindow.Text += "\nPIC Device Found.";
				fullEnableGUIControls();
			}
			else
			{
				for (int i = 0; i < PICkitFunctions.DevFile.Info.NumberFamilies; i++)
				{
					if (PICkitFunctions.DevFile.Families[i].FamilyName == lastFamily)
					{
						PICkitFunctions.SetActiveFamily(i);
						if (!PICkitFunctions.DevFile.Families[i].PartDetect)
						{
							buildDeviceSelectDropDown(i);
							comboBoxSelectPart.Visible = true;
							comboBoxSelectPart.SelectedIndex = 0;
							displayDevice.Visible = true;
						}
					}
				}
				for (int j = 1; j < PICkitFunctions.DevFile.Info.NumberParts; j++)
				{
					if (PICkitFunctions.DevFile.PartsList[j].Family == PICkitFunctions.GetActiveFamily())
					{
						PICkitFunctions.DevFile.PartsList[0].VddMax = PICkitFunctions.DevFile.PartsList[j].VddMax;
						PICkitFunctions.DevFile.PartsList[0].VddMin = PICkitFunctions.DevFile.PartsList[j].VddMin;
						break;
					}
				}
				setGUIVoltageLimits(setValue: true);
			}
			if (num != 0f && PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].FamilyName == lastFamily && !selfPoweredTarget)
			{
				if (num > (float)numUpDnVDD.Maximum)
				{
					num = (float)numUpDnVDD.Maximum;
				}
				if (num < (float)numUpDnVDD.Minimum)
				{
					num = (float)numUpDnVDD.Minimum;
				}
				numUpDnVDD.Value = (decimal)num;
				PICkitFunctions.SetVDDVoltage((float)numUpDnVDD.Value, 0.85f);
			}
			checkForPowerErrors();
			if (TestMemoryEnabled)
			{
				toolStripMenuItemTestMemory.Visible = true;
				if (TestMemoryOpen)
				{
					openTestMemory();
				}
			}
			if (!PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].PartDetect)
			{
				disableGUIControls();
			}
			if (multiWindow)
			{
				saveMultWinPMemOpen = multiWinPMemOpen;
				toolStripMenuItemShowProgramMemory.Checked = false;
				multiWinPMemOpen = false;
				saveMultiWinEEMemOpen = multiWinEEMemOpen;
				toolStripMenuItemShowEEPROMData.Checked = false;
				multiWinEEMemOpen = false;
			}
			updateGUI(updateMemories: true);
			if (multiWindow)
			{
				timerInitalUpdate.Enabled = true;
			}
		}

		public void ExtCallUpdateGUI()
		{
			updateGUI(updateMemories: true);
		}

		public bool ExtCallVerify()
		{
			return deviceVerify(writeVerify: false, 0, forceEEVerify: false);
		}

		public bool ExtCallWrite(bool verify)
		{
			bool @checked = verifyOnWriteToolStripMenuItem.Checked;
			if (verify)
			{
				verifyOnWriteToolStripMenuItem.Checked = true;
			}
			else
			{
				verifyOnWriteToolStripMenuItem.Checked = false;
			}
			bool result = deviceWrite();
			verifyOnWriteToolStripMenuItem.Checked = @checked;
			return result;
		}

		public void ExtCallRead()
		{
			deviceRead();
		}

		public void ExtCallErase(bool writeOSCCAL)
		{
			eraseDeviceAll(writeOSCCAL, new uint[0]);
		}

		public void ExtCallCalEraseWrite(uint[] calwords)
		{
			eraseDeviceAll(forceOSSCAL: false, calwords);
		}

		public bool ExtCallBlank()
		{
			return blankCheckDevice();
		}

		public void MultiWinProgMemClosed()
		{
			multiWinPMemOpen = false;
			toolStripMenuItemShowProgramMemory.Checked = false;
		}

		public void MultiWinEEMemClosed()
		{
			multiWinEEMemOpen = false;
			toolStripMenuItemShowEEPROMData.Checked = false;
		}

		public void ShowMemEdited()
		{
			displayDataSource.Text = "Edited.";
			checkImportFile = false;
		}

		public void StatusWinWr(string dispText)
		{
			displayStatusWindow.Text = dispText;
			Update();
		}

		public void ResetStatusBar(int maxValue)
		{
			progressBar1.Value = 0;
			progressBar1.Maximum = maxValue;
			Update();
		}

		public void StepStatusBar()
		{
			progressBar1.PerformStep();
		}

		public void SetVddState(bool force, bool forceState)
		{
			vddControl(force, forceState);
			uartWindow.SetVddBox(numUpDnVDD.Enabled, chkBoxVddOn.Checked);
			logicWindow.SetVddBox(numUpDnVDD.Enabled, chkBoxVddOn.Checked);
		}

		private bool checkForPowerErrors()
		{
			Thread.Sleep(100);
			switch (PICkitFunctions.PowerStatus())
			{
			case Constants.PICkit2PWR.vdderror:
				if (!timerAutoImportWrite.Enabled)
				{
					MessageBox.Show("PICkit 2 VDD voltage level error.\nCheck target & retry operation.", "PICkit 2 Error");
				}
				break;
			case Constants.PICkit2PWR.vpperror:
				if (!timerAutoImportWrite.Enabled)
				{
					MessageBox.Show("PICkit 2 VPP voltage level error.\nCheck target & retry operation.", "PICkit 2 Error");
				}
				break;
			case Constants.PICkit2PWR.vddvpperrors:
				if (!timerAutoImportWrite.Enabled)
				{
					MessageBox.Show("PICkit 2 VDD and VPP voltage level errors.\nCheck target & retry operation.", "PICkit 2 Error");
				}
				break;
			case Constants.PICkit2PWR.vdd_on:
				chkBoxVddOn.Checked = true;
				return false;
			case Constants.PICkit2PWR.vdd_off:
				chkBoxVddOn.Checked = false;
				return false;
			}
			chkBoxVddOn.Checked = false;
			return true;
		}

		private bool lookForPoweredTarget(bool showMessageBox)
		{
			float vdd = 0f;
			float vpp = 0f;
			if (fastProgrammingToolStripMenuItem.Checked)
			{
				PICkitFunctions.SetProgrammingSpeed(0);
			}
			else
			{
				PICkitFunctions.SetProgrammingSpeed(slowSpeedICSP);
			}
			if (autoDetectToolStripMenuItem.Checked)
			{
				if (PICkitFunctions.CheckTargetPower(ref vdd, ref vpp) == Constants.PICkit2PWR.selfpowered)
				{
					chkBoxVddOn.Checked = false;
					if (!selfPoweredTarget)
					{
						selfPoweredTarget = true;
						chkBoxVddOn.Enabled = true;
						chkBoxVddOn.Text = "Check";
						numUpDnVDD.Enabled = false;
						groupBoxVDD.Text = "VDD Target";
						if (showMessageBox)
						{
							MessageBox.Show("Powered target detected.\n VDD source set to target.", "Target VDD");
						}
					}
					numUpDnVDD.Maximum = (decimal)vdd;
					numUpDnVDD.Value = (decimal)vdd;
					numUpDnVDD.Update();
					return true;
				}
				if (selfPoweredTarget)
				{
					selfPoweredTarget = false;
					chkBoxVddOn.Enabled = true;
					chkBoxVddOn.Text = "On";
					numUpDnVDD.Enabled = true;
					setGUIVoltageLimits(setValue: true);
					groupBoxVDD.Text = "VDD PICkit 2";
					if (showMessageBox)
					{
						MessageBox.Show("Unpowered target detected.\n VDD source set to PICkit 2.", "Target VDD");
					}
				}
				return false;
			}
			if (forcePICkit2ToolStripMenuItem.Checked)
			{
				if (selfPoweredTarget)
				{
					PICkitFunctions.ForcePICkitPowered();
					selfPoweredTarget = false;
					chkBoxVddOn.Enabled = true;
					chkBoxVddOn.Text = "On";
					numUpDnVDD.Enabled = true;
					setGUIVoltageLimits(setValue: true);
					groupBoxVDD.Text = "VDD PICkit 2";
				}
				return false;
			}
			PICkitFunctions.CheckTargetPower(ref vdd, ref vpp);
			PICkitFunctions.ForceTargetPowered();
			chkBoxVddOn.Checked = false;
			if (!selfPoweredTarget)
			{
				selfPoweredTarget = true;
				chkBoxVddOn.Enabled = true;
				chkBoxVddOn.Text = "Check";
				numUpDnVDD.Enabled = false;
				groupBoxVDD.Text = "VDD Target";
			}
			numUpDnVDD.Maximum = (decimal)vdd;
			numUpDnVDD.Value = (decimal)vdd;
			numUpDnVDD.Update();
			return true;
		}

		private void setGUIVoltageLimits(bool setValue)
		{
			if (!numUpDnVDD.Enabled)
			{
				return;
			}
			numUpDnVDD.Maximum = (decimal)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddMax;
			numUpDnVDD.Minimum = (decimal)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddMin;
			if (PICkitFunctions.ActivePart != 0)
			{
				PICkitFunctions.DevFile.PartsList[0].VddMax = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddMax;
				PICkitFunctions.DevFile.PartsList[0].VddMin = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddMin;
			}
			if (setValue)
			{
				if ((double)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddMax <= 4.0 && (double)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddMax >= 3.3)
				{
					numUpDnVDD.Value = 3.3m;
				}
				else if ((double)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddMax == 5.0)
				{
					numUpDnVDD.Value = 5.0m;
				}
				else
				{
					numUpDnVDD.Value = (decimal)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddMax;
				}
			}
		}

		private void initializeGUI()
		{
			ScalefactW = (float)dataGridProgramMemory.Size.Width / 502f;
			ScalefactH = (float)dataGridProgramMemory.Size.Height / 208f;
			dataGridConfigWords.BackgroundColor = SystemColors.Control;
			dataGridConfigWords.ColumnCount = 4;
			dataGridConfigWords.RowCount = 2;
			dataGridConfigWords.DefaultCellStyle.BackColor = SystemColors.Control;
			dataGridConfigWords[0, 0].Selected = true;
			dataGridConfigWords[0, 0].Selected = false;
			int width = (int)(40f * ScalefactW);
			for (int i = 0; i < 4; i++)
			{
				dataGridConfigWords.Columns[i].Width = width;
			}
			dataGridConfigWords.Rows[0].Height = (int)(17f * ScalefactH);
			dataGridConfigWords.Rows[1].Height = (int)(17f * ScalefactH);
			progressBar1.Step = 1;
			if (comboBoxProgMemView.SelectedIndex < 0)
			{
				comboBoxProgMemView.SelectedIndex = 0;
			}
			dataGridProgramMemory.DefaultCellStyle.Font = new Font("Courier New", 9f);
			dataGridProgramMemory.ColumnCount = 9;
			dataGridProgramMemory.RowCount = 512;
			dataGridProgramMemory[0, 0].Selected = true;
			dataGridProgramMemory[0, 0].Selected = false;
			width = (int)(59f * ScalefactW);
			dataGridProgramMemory.Columns[0].Width = width;
			dataGridProgramMemory.Columns[0].ReadOnly = true;
			width = (int)(53f * ScalefactW);
			for (int j = 1; j < 9; j++)
			{
				dataGridProgramMemory.Columns[j].Width = width;
			}
			for (int k = 0; k < 32; k++)
			{
				dataGridProgramMemory[0, k].Style.BackColor = SystemColors.ControlLight;
				dataGridProgramMemory[0, k].Value = $"{k * 8:X5}";
			}
			if (comboBoxEE.SelectedIndex < 0)
			{
				comboBoxEE.SelectedIndex = 0;
			}
			dataGridViewEEPROM.DefaultCellStyle.Font = new Font("Courier New", 9f);
			dataGridViewEEPROM.ColumnCount = 9;
			dataGridViewEEPROM.RowCount = 16;
			width = (int)(40f * ScalefactW);
			dataGridViewEEPROM.Columns[0].Width = width;
			dataGridViewEEPROM.Columns[0].ReadOnly = true;
			width = (int)(41f * ScalefactW);
			for (int l = 1; l < 9; l++)
			{
				dataGridViewEEPROM.Columns[l].Width = width;
			}
			dataGridViewEEPROM[0, 0].Selected = true;
			dataGridViewEEPROM[0, 0].Selected = false;
			dataGridViewEEPROM.Visible = false;
			updateAlertSoundCheck();
			programMemMultiWin.TellMainFormProgMemClosed = MultiWinProgMemClosed;
			programMemMultiWin.TellMainFormProgMemEdited = ShowMemEdited;
			programMemMultiWin.TellMainFormUpdateGUI = ExtCallUpdateGUI;
			eepromDataMultiWin.TellMainFormEEMemClosed = MultiWinEEMemClosed;
			eepromDataMultiWin.TellMainFormProgMemEdited = ShowMemEdited;
			eepromDataMultiWin.TellMainFormUpdateGUI = ExtCallUpdateGUI;
		}

		private bool loadDeviceFile()
		{
			if (selectDeviceFile)
			{
				DialogDevFile dialogDevFile = new DialogDevFile();
				dialogDevFile.ShowDialog();
			}
			if (PICkitFunctions.ReadDeviceFile(DeviceFileName))
			{
				if (PICkitFunctions.DevFile.Info.Compatibility < 0)
				{
					displayStatusWindow.Text = "Older device file is not compatible with this PICkit 2\nversion.  Visit www.microchip.com for updates.";
					checkCommunicationToolStripMenuItem.Enabled = false;
					return false;
				}
				if (PICkitFunctions.DevFile.Info.Compatibility > 6)
				{
					displayStatusWindow.Text = "The device file requires a newer version of PICkit 2.\nVisit www.microchip.com for updates.";
					checkCommunicationToolStripMenuItem.Enabled = false;
					return false;
				}
				return true;
			}
			displayStatusWindow.Text = "Device file " + DeviceFileName + " not found.\nMust be in same directory as executable.";
			checkCommunicationToolStripMenuItem.Enabled = false;
			return false;
		}

		private bool detectPICkit2(bool showFound, bool detectMult)
		{
			Constants.PICkit2USB pICkit2USB;
			if (detectMult)
			{
				pk2number = 0;
				pICkit2USB = PICkitFunctions.DetectPICkit2Device(0, readFW: false);
				if (pICkit2USB != Constants.PICkit2USB.notFound)
				{
					Constants.PICkit2USB pICkit2USB2 = PICkitFunctions.DetectPICkit2Device(1, readFW: false);
					if (pICkit2USB2 != Constants.PICkit2USB.notFound)
					{
						DialogUnitSelect dialogUnitSelect = new DialogUnitSelect();
						dialogUnitSelect.ShowDialog();
					}
				}
			}
			pICkit2USB = PICkitFunctions.DetectPICkit2Device(pk2number, readFW: true);
			if (pICkit2USB == Constants.PICkit2USB.found)
			{
				downloadPICkit2FirmwareToolStripMenuItem.Enabled = true;
				chkBoxVddOn.Enabled = true;
				if (!selfPoweredTarget)
				{
					numUpDnVDD.Enabled = true;
				}
				deviceToolStripMenuItem.Enabled = true;
				if (showFound)
				{
					string serialUnitID = PICkitFunctions.GetSerialUnitID();
					if (serialUnitID[0] == '-')
					{
						displayStatusWindow.Text = "PICkit 2 found and connected.";
						Text = "PICkit 2 Programmer";
					}
					else
					{
						displayStatusWindow.Text = "PICkit 2 connected.  ID = " + serialUnitID;
						Text = "PICkit 2 Programmer - " + serialUnitID;
					}
				}
				return true;
			}
			downloadPICkit2FirmwareToolStripMenuItem.Enabled = false;
			chkBoxVddOn.Enabled = false;
			numUpDnVDD.Enabled = false;
			deviceToolStripMenuItem.Enabled = false;
			disableGUIControls();
			switch (pICkit2USB)
			{
			case Constants.PICkit2USB.firmwareInvalid:
				displayStatusWindow.BackColor = Color.Yellow;
				downloadPICkit2FirmwareToolStripMenuItem.Enabled = true;
				displayStatusWindow.Text = "The PICkit 2 OS v" + PICkitFunctions.FirmwareVersion + " must be updated.\nUse the Tools menu to download a new OS.";
				oldFirmware = true;
				return false;
			case Constants.PICkit2USB.bootloader:
				displayStatusWindow.BackColor = Color.Yellow;
				downloadPICkit2FirmwareToolStripMenuItem.Enabled = true;
				displayStatusWindow.Text = "The PICkit 2 has no Operating System.\nUse the Tools menu to download an OS.";
				bootLoad = true;
				return false;
			default:
				displayStatusWindow.BackColor = Color.Salmon;
				displayStatusWindow.Text = "PICkit 2 not found.  Check USB connections and \nuse Tools->Check Communication to retry.";
				return false;
			}
		}

		private void disableGUIControls()
		{
			importFileToolStripMenuItem.Enabled = false;
			exportFileToolStripMenuItem.Enabled = false;
			readDeviceToolStripMenuItem.Enabled = false;
			writeDeviceToolStripMenuItem.Enabled = false;
			verifyToolStripMenuItem.Enabled = false;
			eraseToolStripMenuItem.Enabled = false;
			blankCheckToolStripMenuItem.Enabled = false;
			writeOnPICkitButtonToolStripMenuItem.Enabled = false;
			pICkit2GoToolStripMenuItem.Enabled = false;
			setOSCCALToolStripMenuItem.Enabled = false;
			buttonRead.Enabled = false;
			buttonWrite.Enabled = false;
			buttonVerify.Enabled = false;
			buttonErase.Enabled = false;
			buttonBlankCheck.Enabled = false;
			checkBoxProgMemEnabled.Enabled = false;
			checkBoxProgMemEnabledAlt.Enabled = false;
			comboBoxProgMemView.Enabled = false;
			dataGridProgramMemory.ForeColor = SystemColors.GrayText;
			dataGridProgramMemory.Enabled = false;
			dataGridViewEEPROM.Visible = false;
			comboBoxEE.Enabled = false;
			checkBoxEEMem.Enabled = false;
			checkBoxEEDATAMemoryEnabledAlt.Enabled = false;
			buttonExportHex.Enabled = false;
			checkBoxAutoImportWrite.Enabled = false;
			troubleshhotToolStripMenuItem.Enabled = false;
			calibrateToolStripMenuItem.Enabled = false;
			programMemMultiWin.DisplayDisable();
			eepromDataMultiWin.DisplayDisable();
			UARTtoolStripMenuItem.Enabled = false;
			toolStripMenuItemLogicTool.Enabled = false;
		}

		private void partialEnableGUIControls()
		{
			importFileToolStripMenuItem.Enabled = true;
			exportFileToolStripMenuItem.Enabled = false;
			readDeviceToolStripMenuItem.Enabled = true;
			writeDeviceToolStripMenuItem.Enabled = true;
			verifyToolStripMenuItem.Enabled = true;
			eraseToolStripMenuItem.Enabled = true;
			blankCheckToolStripMenuItem.Enabled = true;
			writeOnPICkitButtonToolStripMenuItem.Enabled = true;
			pICkit2GoToolStripMenuItem.Enabled = true;
			setOSCCALToolStripMenuItem.Enabled = false;
			writeDeviceToolStripMenuItem.Enabled = false;
			verifyToolStripMenuItem.Enabled = false;
			buttonRead.Enabled = true;
			buttonWrite.Enabled = false;
			buttonVerify.Enabled = false;
			buttonErase.Enabled = true;
			buttonBlankCheck.Enabled = true;
			checkBoxProgMemEnabled.Enabled = false;
			checkBoxProgMemEnabledAlt.Enabled = false;
			comboBoxProgMemView.Enabled = false;
			dataGridProgramMemory.ForeColor = SystemColors.GrayText;
			dataGridProgramMemory.Enabled = false;
			dataGridViewEEPROM.Visible = false;
			comboBoxEE.Enabled = false;
			checkBoxEEMem.Enabled = false;
			checkBoxEEDATAMemoryEnabledAlt.Enabled = false;
			buttonExportHex.Enabled = false;
			checkBoxAutoImportWrite.Enabled = false;
			troubleshhotToolStripMenuItem.Enabled = true;
			calibrateToolStripMenuItem.Enabled = true;
			programMemMultiWin.DisplayDisable();
			eepromDataMultiWin.DisplayDisable();
			UARTtoolStripMenuItem.Enabled = true;
			toolStripMenuItemLogicTool.Enabled = true;
		}

		private void semiEnableGUIControls()
		{
			importFileToolStripMenuItem.Enabled = true;
			exportFileToolStripMenuItem.Enabled = false;
			readDeviceToolStripMenuItem.Enabled = true;
			writeDeviceToolStripMenuItem.Enabled = true;
			verifyToolStripMenuItem.Enabled = true;
			eraseToolStripMenuItem.Enabled = true;
			blankCheckToolStripMenuItem.Enabled = true;
			writeOnPICkitButtonToolStripMenuItem.Enabled = true;
			pICkit2GoToolStripMenuItem.Enabled = true;
			writeDeviceToolStripMenuItem.Enabled = true;
			verifyToolStripMenuItem.Enabled = true;
			setOSCCALToolStripMenuItem.Enabled = false;
			buttonRead.Enabled = true;
			buttonWrite.Enabled = true;
			buttonVerify.Enabled = true;
			buttonErase.Enabled = true;
			buttonBlankCheck.Enabled = true;
			checkBoxProgMemEnabled.Enabled = false;
			checkBoxProgMemEnabledAlt.Enabled = false;
			comboBoxProgMemView.Enabled = false;
			dataGridProgramMemory.ForeColor = SystemColors.GrayText;
			dataGridProgramMemory.Enabled = false;
			dataGridViewEEPROM.Visible = true;
			dataGridViewEEPROM.ForeColor = SystemColors.GrayText;
			comboBoxEE.Enabled = false;
			checkBoxEEMem.Enabled = false;
			checkBoxEEDATAMemoryEnabledAlt.Enabled = false;
			buttonExportHex.Enabled = false;
			checkBoxAutoImportWrite.Enabled = true;
			troubleshhotToolStripMenuItem.Enabled = true;
			calibrateToolStripMenuItem.Enabled = true;
			UARTtoolStripMenuItem.Enabled = true;
			toolStripMenuItemLogicTool.Enabled = true;
		}

		private void fullEnableGUIControls()
		{
			importFileToolStripMenuItem.Enabled = true;
			exportFileToolStripMenuItem.Enabled = true;
			readDeviceToolStripMenuItem.Enabled = true;
			writeDeviceToolStripMenuItem.Enabled = true;
			verifyToolStripMenuItem.Enabled = true;
			eraseToolStripMenuItem.Enabled = true;
			blankCheckToolStripMenuItem.Enabled = true;
			writeOnPICkitButtonToolStripMenuItem.Enabled = true;
			pICkit2GoToolStripMenuItem.Enabled = true;
			writeDeviceToolStripMenuItem.Enabled = true;
			verifyToolStripMenuItem.Enabled = true;
			buttonRead.Enabled = true;
			buttonWrite.Enabled = true;
			buttonVerify.Enabled = true;
			buttonErase.Enabled = true;
			buttonBlankCheck.Enabled = true;
			checkBoxProgMemEnabled.Enabled = true;
			checkBoxProgMemEnabledAlt.Enabled = true;
			comboBoxProgMemView.Enabled = true;
			dataGridProgramMemory.Enabled = true;
			dataGridProgramMemory.ForeColor = SystemColors.WindowText;
			dataGridViewEEPROM.ForeColor = SystemColors.WindowText;
			buttonExportHex.Enabled = true;
			checkBoxAutoImportWrite.Enabled = true;
			troubleshhotToolStripMenuItem.Enabled = true;
			calibrateToolStripMenuItem.Enabled = true;
			programMemMultiWin.DisplayEnable();
			eepromDataMultiWin.DisplayEnable();
			UARTtoolStripMenuItem.Enabled = true;
			toolStripMenuItemLogicTool.Enabled = true;
		}

		private void updateGUIView()
		{
			if (multiWindow)
			{
				toolStripMenuItemSingleWindow.Checked = false;
				toolStripMenuItemMultiWindow.Checked = true;
				groupBoxProgMem.Location = new Point((int)(12f * ScalefactW), (int)(300f * ScalefactH));
				base.Size = new Size((int)(544f * ScalefactW), (int)(320f * ScalefactH));
				pictureBox1.Location = new Point((int)(423f * ScalefactW), (int)(238f * ScalefactH));
				buttonExportHex.Location = new Point((int)(311f * ScalefactW), (int)(240f * ScalefactH));
				checkBoxAutoImportWrite.Location = new Point((int)(201f * ScalefactW), (int)(240f * ScalefactH));
				checkBoxProgMemEnabledAlt.Visible = true;
				checkBoxEEDATAMemoryEnabledAlt.Visible = true;
				toolStripMenuItemShowProgramMemory.Enabled = true;
				toolStripMenuItemShowEEPROMData.Enabled = true;
				mainWindowAlwaysInFrontToolStripMenuItem.Enabled = true;
				if (mainWinOwnsMem)
				{
					mainWindowAlwaysInFrontToolStripMenuItem.Checked = true;
				}
				Point right = new Point(0, 0);
				if (programMemMultiWin.Location == right && eepromDataMultiWin.Location == right)
				{
					programMemMultiWin.Location = new Point(base.Location.X, base.Location.Y + (int)(321f * ScalefactH));
					eepromDataMultiWin.Location = new Point(base.Location.X, base.Location.Y + (int)(530f * ScalefactH));
				}
				if (multiWinPMemOpen)
				{
					programMemMultiWin.Show();
					toolStripMenuItemShowProgramMemory.Checked = true;
				}
				if (multiWinEEMemOpen)
				{
					toolStripMenuItemShowEEPROMData.Checked = true;
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0)
					{
						toolStripMenuItemShowEEPROMData.Enabled = true;
						eepromDataMultiWin.Show();
					}
					else
					{
						toolStripMenuItemShowEEPROMData.Enabled = false;
					}
				}
			}
			else
			{
				programMemMultiWin.Hide();
				eepromDataMultiWin.Hide();
				toolStripMenuItemSingleWindow.Checked = true;
				toolStripMenuItemMultiWindow.Checked = false;
				groupBoxProgMem.Location = new Point((int)(12f * ScalefactW), (int)(236f * ScalefactH));
				base.Size = new Size((int)(544f * ScalefactW), (int)(670f * ScalefactH));
				pictureBox1.Location = new Point((int)(423f * ScalefactW), (int)(586f * ScalefactH));
				buttonExportHex.Location = new Point((int)(423f * ScalefactW), (int)(545f * ScalefactH));
				checkBoxAutoImportWrite.Location = new Point((int)(423f * ScalefactW), (int)(505f * ScalefactH));
				checkBoxProgMemEnabledAlt.Visible = false;
				checkBoxEEDATAMemoryEnabledAlt.Visible = false;
				toolStripMenuItemShowProgramMemory.Enabled = false;
				toolStripMenuItemShowEEPROMData.Enabled = false;
				mainWindowAlwaysInFrontToolStripMenuItem.Enabled = false;
				toolStripMenuItemShowProgramMemory.Checked = false;
				toolStripMenuItemShowEEPROMData.Checked = false;
				mainWindowAlwaysInFrontToolStripMenuItem.Checked = false;
			}
			Focus();
		}

		private void updateGUI(bool updateMemories)
		{
			if (viewChanged)
			{
				updateGUIView();
				viewChanged = false;
			}
			statusGroupBox.Text = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].FamilyName + " Configuration";
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgEntryVPPScript > 0)
			{
				VppFirstToolStripMenuItem.Enabled = true;
			}
			else
			{
				VppFirstToolStripMenuItem.Checked = false;
				VppFirstToolStripMenuItem.Enabled = false;
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].LVPScript > 0)
			{
				string scriptName = PICkitFunctions.DevFile.Scripts[PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].LVPScript - 1].ScriptName;
				scriptName = scriptName.Substring(scriptName.Length - 2);
				if (scriptName == "HV")
				{
					toolStripMenuItemLVPEnabled.Text = "Use &High Voltage Program Entry";
					labelLVP.Text = "HVP";
				}
				else
				{
					toolStripMenuItemLVPEnabled.Text = "Use &LVP Program Entry";
					labelLVP.Text = "LVP";
				}
				toolStripMenuItemLVPEnabled.Enabled = true;
				if (toolStripMenuItemLVPEnabled.Checked)
				{
					labelLVP.Visible = true;
				}
				else
				{
					labelLVP.Visible = false;
				}
			}
			else
			{
				toolStripMenuItemLVPEnabled.Text = "Use &LVP Program Entry";
				toolStripMenuItemLVPEnabled.Checked = false;
				toolStripMenuItemLVPEnabled.Enabled = false;
				labelLVP.Text = "LVP";
				labelLVP.Visible = false;
			}
			if (PICkitFunctions.FamilyIsEEPROM())
			{
				importFileToolStripMenuItem.Text = "&Import Hex/Bin";
				exportFileToolStripMenuItem.Text = "&Export Hex/Bin";
				toolStripMenuItemDisplayUnimplConfigAs.Enabled = false;
			}
			else
			{
				importFileToolStripMenuItem.Text = "&Import Hex";
				exportFileToolStripMenuItem.Text = "&Export Hex";
				toolStripMenuItemDisplayUnimplConfigAs.Enabled = true;
			}
			displayDevice.Text = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].PartName;
			if (PICkitFunctions.ActivePart == 0)
			{
				if (PICkitFunctions.LastDeviceID == 0)
				{
					displayDevice.Text = "No Device Found";
				}
				else
				{
					Label label = displayDevice;
					label.Text = label.Text + " (ID=" + $"{PICkitFunctions.LastDeviceID:X4}" + ")";
				}
			}
			displayDevice.Update();
			displayRev.Text = " <" + $"{PICkitFunctions.LastDeviceRev:X2}" + ">";
			if (updateMemories)
			{
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords > 0)
				{
					labelUserIDs.Enabled = true;
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords < 9)
					{
						displayUserIDs.Visible = true;
						buttonShowIDMem.Visible = false;
						string text = "";
						for (int i = 0; i < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords; i++)
						{
							text += $"{0xFF & PICkitFunctions.DeviceBuffers.UserIDs[i]:X2} ";
						}
						displayUserIDs.Text = text;
					}
					else
					{
						displayUserIDs.Visible = false;
						buttonShowIDMem.Visible = true;
						if (DialogUserIDs.IDMemOpen)
						{
							dialogIDMemory.UpdateIDMemoryGrid();
						}
					}
				}
				else
				{
					labelUserIDs.Enabled = false;
					displayUserIDs.Text = "";
					displayUserIDs.Visible = false;
					buttonShowIDMem.Visible = false;
				}
			}
			if (checkBoxProgMemEnabled.Checked)
			{
				displayUserIDs.ForeColor = SystemColors.WindowText;
			}
			else
			{
				displayUserIDs.ForeColor = SystemColors.GrayText;
			}
			if (updateMemories)
			{
				displayChecksum.Text = $"{PICkitFunctions.ComputeChecksum(enableCodeProtectToolStripMenuItem.Checked, enableDataProtectStripMenuItem.Checked):X4}";
			}
			if (updateMemories)
			{
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords == 0 || PICkitFunctions.ActivePart == 0 || !allowDataEdits)
				{
					labelConfig.Enabled = false;
				}
				else
				{
					labelConfig.Enabled = true;
				}
				int num = 0;
				for (int j = 0; j < 2; j++)
				{
					for (int k = 0; k < 4; k++)
					{
						if (num < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords)
						{
							uint num2 = PICkitFunctions.DeviceBuffers.ConfigWords[num];
							if (as0BitValueToolStripMenuItem.Checked)
							{
								num2 &= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[num];
							}
							else if (as1BitValueToolStripMenuItem.Checked)
							{
								num2 = (uint)((int)num2 | ~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[num]);
							}
							num2 &= (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue & 0xFFFF);
							if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPConfig - 1 == num)
							{
								if (enableCodeProtectToolStripMenuItem.Checked && (PICkitFunctions.DeviceBuffers.ConfigWords[PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPConfig - 1] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPMask) == PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPMask)
								{
									num2 = (uint)((int)num2 & ~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPMask);
								}
								if (enableDataProtectStripMenuItem.Checked && (PICkitFunctions.DeviceBuffers.ConfigWords[PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPConfig - 1] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DPMask) == PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DPMask)
								{
									num2 = (uint)((int)num2 & ~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DPMask);
								}
							}
							dataGridConfigWords[k, j].Value = $"{num2:X4}";
							num++;
						}
						else
						{
							dataGridConfigWords[k, j].Value = " ";
						}
						if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords == 9)
						{
							uint num3 = PICkitFunctions.DeviceBuffers.ConfigWords[8];
							if (as0BitValueToolStripMenuItem.Checked)
							{
								num3 &= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[8];
							}
							else if (as1BitValueToolStripMenuItem.Checked)
							{
								num3 = (uint)((int)num3 | ~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[8]);
							}
							num3 &= (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue & 0xFFFF);
							labelConfig9.Text = $"{num3:X4}";
							labelConfig9.Visible = true;
						}
						else
						{
							labelConfig9.Visible = false;
						}
					}
				}
			}
			if (checkBoxProgMemEnabled.Checked)
			{
				dataGridConfigWords.ForeColor = SystemColors.WindowText;
			}
			else
			{
				dataGridConfigWords.ForeColor = SystemColors.GrayText;
			}
			if (PICkitFunctions.FamilyIsEEPROM() && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 1)
			{
				checkBoxA0CS.Visible = true;
				checkBoxA1CS.Visible = true;
				checkBoxA2CS.Visible = true;
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[3] == 1)
				{
					checkBoxA0CS.Enabled = true;
					checkBoxA1CS.Enabled = false;
					checkBoxA1CS.Checked = false;
					checkBoxA2CS.Enabled = false;
					checkBoxA2CS.Checked = false;
				}
				else if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[3] == 2)
				{
					checkBoxA0CS.Enabled = true;
					checkBoxA1CS.Enabled = true;
					checkBoxA2CS.Enabled = false;
					checkBoxA2CS.Checked = false;
				}
				else if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[3] == 3)
				{
					checkBoxA0CS.Enabled = true;
					checkBoxA1CS.Enabled = true;
					checkBoxA2CS.Enabled = true;
				}
				else
				{
					checkBoxA0CS.Enabled = false;
					checkBoxA0CS.Checked = false;
					checkBoxA1CS.Enabled = false;
					checkBoxA1CS.Checked = false;
					checkBoxA2CS.Enabled = false;
					checkBoxA2CS.Checked = false;
				}
			}
			else
			{
				checkBoxA0CS.Visible = false;
				checkBoxA1CS.Visible = false;
				checkBoxA2CS.Visible = false;
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].OSSCALSave)
			{
				setOSCCALToolStripMenuItem.Enabled = true;
				labelOSCCAL.Enabled = true;
				displayOSCCAL.Text = $"{PICkitFunctions.DeviceBuffers.OSCCAL:X4}";
				if (PICkitFunctions.ValidateOSSCAL())
				{
					labelOSSCALInvalid.Visible = false;
					displayOSCCAL.ForeColor = SystemColors.ControlText;
				}
				else
				{
					labelOSSCALInvalid.Visible = true;
					displayOSCCAL.ForeColor = Color.Red;
				}
			}
			else
			{
				labelOSSCALInvalid.Visible = false;
				setOSCCALToolStripMenuItem.Enabled = false;
				labelOSCCAL.Enabled = false;
				displayOSCCAL.Text = "";
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BandGapMask != 0)
			{
				labelBandGap.Enabled = true;
				if (PICkitFunctions.DeviceBuffers.BandGap == PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue)
				{
					displayBandGap.Text = "";
				}
				else
				{
					displayBandGap.Text = $"{PICkitFunctions.DeviceBuffers.BandGap:X4}";
				}
			}
			else
			{
				labelBandGap.Enabled = false;
				displayBandGap.Text = "";
			}
			switch (statusWindowColor)
			{
			case Constants.StatusColor.green:
				displayStatusWindow.BackColor = Color.LimeGreen;
				if (PlaySuccessWav)
				{
					wavPlayer.SoundLocation = SuccessWavFile;
					wavPlayer.Play();
				}
				break;
			case Constants.StatusColor.yellow:
				displayStatusWindow.BackColor = Color.Yellow;
				if (PlayWarningWav)
				{
					wavPlayer.SoundLocation = WarningWavFile;
					wavPlayer.Play();
				}
				break;
			case Constants.StatusColor.red:
				displayStatusWindow.BackColor = Color.Salmon;
				if (PlayErrorWav)
				{
					wavPlayer.SoundLocation = ErrorWavFile;
					wavPlayer.Play();
				}
				break;
			default:
				displayStatusWindow.BackColor = SystemColors.Info;
				break;
			}
			statusWindowColor = Constants.StatusColor.normal;
			if (PICkitFunctions.FamilyIsEEPROM())
			{
				checkBoxMCLR.Checked = false;
				checkBoxMCLR.Enabled = false;
				MCLRtoolStripMenuItem.Checked = false;
				MCLRtoolStripMenuItem.Enabled = false;
				PICkitFunctions.HoldMCLR(nMCLR: false);
			}
			else
			{
				checkBoxMCLR.Enabled = true;
				MCLRtoolStripMenuItem.Enabled = true;
			}
			if (PICkitFunctions.FamilyIsPIC32())
			{
				fastProgrammingToolStripMenuItem.Checked = true;
				fastProgrammingToolStripMenuItem.Enabled = false;
			}
			else
			{
				fastProgrammingToolStripMenuItem.Enabled = true;
			}
			if (updateMemories)
			{
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPMask == 0)
				{
					enableCodeProtectToolStripMenuItem.Checked = false;
					enableCodeProtectToolStripMenuItem.Enabled = false;
				}
				else
				{
					enableCodeProtectToolStripMenuItem.Enabled = true;
				}
			}
			if (updateMemories && multiWindow)
			{
				if (!programMemMultiWin.InitDone)
				{
					programMemMultiWin.InitProgMemDisplay(comboBoxProgMemView.SelectedIndex);
				}
				programMemMultiWin.UpdateMultiWinProgMem(displayDataSource.Text);
			}
			if (updateMemories && !multiWindow)
			{
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 16777215)
				{
					comboBoxProgMemView.SelectedIndex = 0;
					comboBoxProgMemView.Enabled = false;
				}
				else
				{
					comboBoxProgMemView.Enabled = true;
				}
				int num4;
				int num5;
				int width;
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue <= 4095)
				{
					if (PICkitFunctions.FamilyIsEEPROM())
					{
						num4 = 17;
						dataGridProgramMemory.Columns[0].Width = (int)(51f * ScalefactW);
						num5 = 16;
						width = (int)(27f * ScalefactW);
					}
					else
					{
						num4 = 17;
						dataGridProgramMemory.Columns[0].Width = (int)(35f * ScalefactW);
						num5 = 16;
						width = (int)(28f * ScalefactW);
					}
				}
				else if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 16777215)
				{
					num4 = 5;
					dataGridProgramMemory.Columns[0].Width = (int)(99f * ScalefactW);
					num5 = 4;
					width = (int)(96f * ScalefactW);
				}
				else
				{
					num4 = 9;
					dataGridProgramMemory.Columns[0].Width = (int)(59f * ScalefactW);
					num5 = 8;
					width = (int)(53f * ScalefactW);
				}
				if (dataGridProgramMemory.ColumnCount != num4)
				{
					dataGridProgramMemory.Rows.Clear();
					dataGridProgramMemory.ColumnCount = num4;
				}
				for (int l = 1; l < dataGridProgramMemory.ColumnCount; l++)
				{
					dataGridProgramMemory.Columns[l].Width = width;
				}
				int addressIncrement = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].AddressIncrement;
				int num6;
				int num7;
				int num8;
				if (comboBoxProgMemView.SelectedIndex == 0)
				{
					num6 = num5;
					num7 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem / num6;
					if ((long)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem % (long)num6 > 0)
					{
						num7++;
					}
					num8 = addressIncrement * num5;
				}
				else
				{
					num6 = num5 / 2;
					num7 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem / num6;
					if ((long)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem % (long)num6 > 0)
					{
						num7++;
					}
					num8 = addressIncrement * (num5 / 2);
				}
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 16777215)
				{
					num7 += 2;
				}
				if (dataGridProgramMemory.RowCount != num7)
				{
					dataGridProgramMemory.Rows.Clear();
					dataGridProgramMemory.RowCount = num7;
				}
				for (int m = 0; m < num6; m++)
				{
					dataGridProgramMemory.Columns[m + 1].ReadOnly = false;
				}
				int num9 = dataGridProgramMemory.RowCount * num8 - 1;
				string format = "{0:X3}";
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 16777215)
				{
					format = "{0:X8}";
				}
				else if (num9 > 65535)
				{
					format = "{0:X5}";
				}
				else if (num9 > 4095)
				{
					format = "{0:X4}";
				}
				int programMem = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem;
				int bootFlash = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BootFlash;
				programMem -= bootFlash;
				programMem /= num6;
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 16777215)
				{
					dataGridProgramMemory.ShowCellToolTips = false;
					dataGridProgramMemory[0, 0].Value = "Program Flash";
					for (int n = 0; n < dataGridProgramMemory.ColumnCount; n++)
					{
						dataGridProgramMemory[n, 0].Style.BackColor = SystemColors.ControlDark;
						dataGridProgramMemory[n, 0].ReadOnly = true;
					}
					int num10 = 1;
					int num11 = 486539264;
					for (; num10 <= programMem; num10++)
					{
						dataGridProgramMemory[0, num10].Value = string.Format(format, num11);
						dataGridProgramMemory[0, num10].Style.BackColor = SystemColors.ControlLight;
						num11 += num8;
					}
					dataGridProgramMemory[0, programMem + 1].Value = "Boot Flash";
					for (int num12 = 0; num12 < dataGridProgramMemory.ColumnCount; num12++)
					{
						dataGridProgramMemory[num12, programMem + 1].Style.BackColor = SystemColors.ControlDark;
						dataGridProgramMemory[num12, programMem + 1].ReadOnly = true;
					}
					int num13 = programMem + 2;
					int num14 = 532676608;
					for (; num13 < dataGridProgramMemory.RowCount; num13++)
					{
						dataGridProgramMemory[0, num13].Value = string.Format(format, num14);
						dataGridProgramMemory[0, num13].Style.BackColor = SystemColors.ControlLight;
						num14 += num8;
					}
				}
				else
				{
					dataGridProgramMemory.ShowCellToolTips = true;
					int num15 = 0;
					int num16 = 0;
					for (; num15 < dataGridProgramMemory.RowCount; num15++)
					{
						dataGridProgramMemory[0, num15].Value = string.Format(format, num16);
						dataGridProgramMemory[0, num15].Style.BackColor = SystemColors.ControlLight;
						num16 += num8;
					}
				}
				string format2 = "{0:X2}";
				int numBytes = 1;
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 255)
				{
					format2 = "{0:X3}";
					numBytes = 2;
				}
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 4095)
				{
					format2 = "{0:X4}";
					numBytes = 2;
				}
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 65535)
				{
					format2 = "{0:X6}";
					numBytes = 3;
				}
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 16777215)
				{
					format2 = "{0:X8}";
					numBytes = 4;
				}
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 16777215)
				{
					int num17 = 0;
					for (int num18 = 1; num18 <= programMem; num18++)
					{
						for (int num19 = 0; num19 < num6; num19++)
						{
							dataGridProgramMemory[num19 + 1, num18].Value = string.Format(format2, PICkitFunctions.DeviceBuffers.ProgramMemory[num17++]);
						}
					}
					for (int num20 = programMem + 2; num20 < dataGridProgramMemory.RowCount; num20++)
					{
						for (int num21 = 0; num21 < num6; num21++)
						{
							dataGridProgramMemory[num21 + 1, num20].Value = string.Format(format2, PICkitFunctions.DeviceBuffers.ProgramMemory[num17++]);
						}
					}
				}
				else
				{
					int num22 = 0;
					int num23 = 0;
					for (; num22 < dataGridProgramMemory.RowCount - 1; num22++)
					{
						for (int num24 = 0; num24 < num6; num24++)
						{
							dataGridProgramMemory[num24 + 1, num22].ToolTipText = string.Format(format, num23 * addressIncrement);
							dataGridProgramMemory[num24 + 1, num22].Value = string.Format(format2, PICkitFunctions.DeviceBuffers.ProgramMemory[num23++]);
						}
					}
				}
				int num25 = dataGridProgramMemory.RowCount - 1;
				int num26 = num25 * num6;
				int num27 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem % num6;
				if (num27 == 0)
				{
					num27 = num6;
				}
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue <= 16777215)
				{
					for (int num28 = 0; num28 < num6; num28++)
					{
						if (num28 < num27)
						{
							dataGridProgramMemory[num28 + 1, num25].ToolTipText = string.Format(format, num26 * addressIncrement);
							dataGridProgramMemory[num28 + 1, num25].Value = string.Format(format2, PICkitFunctions.DeviceBuffers.ProgramMemory[num26++]);
						}
						else
						{
							dataGridProgramMemory[num28 + 1, num25].ReadOnly = true;
						}
					}
				}
				if (comboBoxProgMemView.SelectedIndex >= 1)
				{
					for (int num29 = 0; num29 < num6; num29++)
					{
						dataGridProgramMemory.Columns[num29 + num6 + 1].ReadOnly = true;
					}
					if (comboBoxProgMemView.SelectedIndex == 1)
					{
						int num30 = 0;
						int num31 = 0;
						for (; num30 < dataGridProgramMemory.RowCount; num30++)
						{
							for (int num32 = 0; num32 < num6; num32++)
							{
								dataGridProgramMemory[num32 + num6 + 1, num30].ToolTipText = string.Format(format, num31 * addressIncrement);
								dataGridProgramMemory[num32 + num6 + 1, num30].Value = Utilities.ConvertIntASCII((int)PICkitFunctions.DeviceBuffers.ProgramMemory[num31++], numBytes);
							}
						}
					}
					else
					{
						int num33 = 0;
						int num34 = 0;
						for (; num33 < dataGridProgramMemory.RowCount; num33++)
						{
							for (int num35 = 0; num35 < num6; num35++)
							{
								dataGridProgramMemory[num35 + num6 + 1, num33].ToolTipText = string.Format(format, num34 * addressIncrement);
								dataGridProgramMemory[num35 + num6 + 1, num33].Value = Utilities.ConvertIntASCIIReverse((int)PICkitFunctions.DeviceBuffers.ProgramMemory[num34++], numBytes);
							}
						}
					}
				}
				if (dataGridProgramMemory.FirstDisplayedCell != null && !progMemJustEdited)
				{
					int rowIndex = dataGridProgramMemory.FirstDisplayedCell.RowIndex;
					dataGridProgramMemory.MultiSelect = false;
					dataGridProgramMemory[0, rowIndex].Selected = true;
					dataGridProgramMemory[0, rowIndex].Selected = false;
					dataGridProgramMemory.MultiSelect = true;
				}
				else if (dataGridProgramMemory.FirstDisplayedCell == null)
				{
					dataGridProgramMemory.MultiSelect = false;
					dataGridProgramMemory[0, 0].Selected = true;
					dataGridProgramMemory[0, 0].Selected = false;
					dataGridProgramMemory.MultiSelect = true;
				}
				progMemJustEdited = false;
			}
			if (updateMemories && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0)
			{
				checkBoxProgMemEnabled.Enabled = true;
				comboBoxEE.Enabled = true;
				if (!checkBoxEEMem.Enabled)
				{
					checkBoxEEMem.Checked = true;
					checkBoxEEDATAMemoryEnabledAlt.Checked = true;
				}
				checkBoxEEMem.Enabled = true;
				enableDataProtectStripMenuItem.Enabled = true;
				checkBoxEEDATAMemoryEnabledAlt.Enabled = true;
				checkBoxProgMemEnabledAlt.Enabled = true;
				if (multiWindow)
				{
					if (!eepromDataMultiWin.InitDone)
					{
						eepromDataMultiWin.InitMemDisplay(comboBoxEE.SelectedIndex);
					}
					if (!toolStripMenuItemShowEEPROMData.Enabled)
					{
						toolStripMenuItemShowEEPROMData.Enabled = true;
						if (multiWinEEMemOpen)
						{
							eepromDataMultiWin.Show();
							Focus();
						}
					}
					eepromDataMultiWin.UpdateMultiWinMem();
				}
				else
				{
					dataGridViewEEPROM.Visible = true;
					int eEMemAddressIncrement = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemAddressIncrement;
					int num36 = eEMemAddressIncrement;
					int num37;
					int num38;
					int width2;
					if (eEMemAddressIncrement == 1 && PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue != 4095)
					{
						num37 = 17;
						dataGridViewEEPROM.Columns[0].Width = (int)(32f * ScalefactW);
						num38 = 16;
						width2 = (int)(21f * ScalefactW);
					}
					else
					{
						num37 = 9;
						dataGridViewEEPROM.Columns[0].Width = (int)(40f * ScalefactW);
						num38 = 8;
						width2 = (int)(41f * ScalefactW);
					}
					if (dataGridViewEEPROM.ColumnCount != num37)
					{
						dataGridViewEEPROM.Rows.Clear();
						dataGridViewEEPROM.ColumnCount = num37;
					}
					dataGridViewEEPROM.Columns[0].ReadOnly = true;
					for (int num39 = 1; num39 < dataGridViewEEPROM.ColumnCount; num39++)
					{
						dataGridViewEEPROM.Columns[num39].Width = width2;
					}
					int num41;
					int num40;
					if (comboBoxEE.SelectedIndex == 0)
					{
						num40 = num38;
						num41 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem / num40;
						eEMemAddressIncrement *= num38;
						num40 = num38;
					}
					else
					{
						num40 = num38 / 2;
						num41 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem / num40;
						eEMemAddressIncrement *= num38 / 2;
					}
					if (dataGridViewEEPROM.RowCount != num41)
					{
						dataGridViewEEPROM.Rows.Clear();
						dataGridViewEEPROM.RowCount = num41;
					}
					int num42 = dataGridViewEEPROM.RowCount * eEMemAddressIncrement - 1;
					string format3 = "{0:X2}";
					if (num42 > 255)
					{
						format3 = "{0:X3}";
					}
					else if (num42 > 4095)
					{
						format3 = "{0:X4}";
					}
					int num43 = 0;
					int num44 = 0;
					for (; num43 < dataGridViewEEPROM.RowCount; num43++)
					{
						dataGridViewEEPROM[0, num43].Value = string.Format(format3, num44);
						dataGridViewEEPROM[0, num43].Style.BackColor = SystemColors.ControlLight;
						num44 += eEMemAddressIncrement;
					}
					string format4 = "{0:X2}";
					int numBytes2 = 1;
					if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemAddressIncrement > 1)
					{
						format4 = "{0:X4}";
						numBytes2 = 2;
					}
					if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue == 4095)
					{
						format4 = "{0:X3}";
						numBytes2 = 2;
					}
					for (int num45 = 0; num45 < num40; num45++)
					{
						dataGridViewEEPROM.Columns[num45 + 1].ReadOnly = false;
					}
					int num46 = 0;
					int num47 = 0;
					for (; num46 < dataGridViewEEPROM.RowCount; num46++)
					{
						for (int num48 = 0; num48 < num40; num48++)
						{
							dataGridViewEEPROM[num48 + 1, num46].ToolTipText = string.Format(format3, num47 * num36);
							dataGridViewEEPROM[num48 + 1, num46].Value = string.Format(format4, PICkitFunctions.DeviceBuffers.EEPromMemory[num47++]);
						}
					}
					if (comboBoxEE.SelectedIndex >= 1)
					{
						for (int num49 = 0; num49 < num40; num49++)
						{
							dataGridViewEEPROM.Columns[num49 + num40 + 1].ReadOnly = true;
						}
						if (comboBoxEE.SelectedIndex == 1)
						{
							int num50 = 0;
							int num51 = 0;
							for (; num50 < dataGridViewEEPROM.RowCount; num50++)
							{
								for (int num52 = 0; num52 < num40; num52++)
								{
									dataGridViewEEPROM[num52 + num40 + 1, num50].ToolTipText = string.Format(format3, num51 * num36);
									dataGridViewEEPROM[num52 + num40 + 1, num50].Value = Utilities.ConvertIntASCII((int)PICkitFunctions.DeviceBuffers.EEPromMemory[num51++], numBytes2);
								}
							}
						}
						else
						{
							int num53 = 0;
							int num54 = 0;
							for (; num53 < dataGridViewEEPROM.RowCount; num53++)
							{
								for (int num55 = 0; num55 < num40; num55++)
								{
									dataGridViewEEPROM[num55 + num40 + 1, num53].ToolTipText = string.Format(format3, num54 * num36);
									dataGridViewEEPROM[num55 + num40 + 1, num53].Value = Utilities.ConvertIntASCIIReverse((int)PICkitFunctions.DeviceBuffers.EEPromMemory[num54++], numBytes2);
								}
							}
						}
					}
					if (dataGridViewEEPROM.FirstDisplayedCell != null && !eeMemJustEdited)
					{
						int rowIndex2 = dataGridViewEEPROM.FirstDisplayedCell.RowIndex;
						dataGridViewEEPROM.MultiSelect = false;
						dataGridViewEEPROM[0, rowIndex2].Selected = true;
						dataGridViewEEPROM[0, rowIndex2].Selected = false;
						dataGridViewEEPROM.MultiSelect = true;
					}
					else if (dataGridViewEEPROM.FirstDisplayedCell == null)
					{
						dataGridViewEEPROM.MultiSelect = false;
						dataGridViewEEPROM[0, 0].Selected = true;
						dataGridViewEEPROM[0, 0].Selected = false;
						dataGridViewEEPROM.MultiSelect = true;
					}
					eeMemJustEdited = false;
				}
			}
			else if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem == 0)
			{
				dataGridViewEEPROM.Visible = false;
				comboBoxEE.Enabled = false;
				checkBoxEEMem.Checked = false;
				checkBoxEEDATAMemoryEnabledAlt.Checked = false;
				checkBoxEEMem.Enabled = false;
				checkBoxEEDATAMemoryEnabledAlt.Enabled = false;
				enableDataProtectStripMenuItem.Enabled = false;
				enableDataProtectStripMenuItem.Checked = false;
				checkBoxProgMemEnabled.Checked = true;
				checkBoxProgMemEnabledAlt.Checked = true;
				checkBoxProgMemEnabled.Enabled = false;
				checkBoxProgMemEnabledAlt.Enabled = false;
				eepromDataMultiWin.Hide();
				toolStripMenuItemShowEEPROMData.Enabled = false;
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPMask != 0 && (PICkitFunctions.DeviceBuffers.ConfigWords[PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPConfig - 1] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPMask) != PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPMask)
			{
				enableCodeProtectToolStripMenuItem.Checked = true;
				enableCodeProtectToolStripMenuItem.Enabled = false;
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DPMask == 0)
				{
					enableDataProtectStripMenuItem.Checked = true;
					enableDataProtectStripMenuItem.Enabled = false;
				}
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0 && (PICkitFunctions.DeviceBuffers.ConfigWords[PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPConfig - 1] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DPMask) != PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DPMask)
			{
				enableDataProtectStripMenuItem.Checked = true;
				enableDataProtectStripMenuItem.Enabled = false;
			}
			if (enableCodeProtectToolStripMenuItem.Checked || enableDataProtectStripMenuItem.Checked)
			{
				labelCodeProtect.Visible = true;
				if (enableCodeProtectToolStripMenuItem.Checked && enableDataProtectStripMenuItem.Checked)
				{
					labelCodeProtect.Text = "All Protect";
				}
				else if (enableCodeProtectToolStripMenuItem.Checked)
				{
					labelCodeProtect.Text = "Code Protect";
				}
				else
				{
					labelCodeProtect.Text = "Data Protect";
				}
			}
			else
			{
				labelCodeProtect.Visible = false;
			}
			if (!checkBoxProgMemEnabled.Checked)
			{
				displayEEProgInfo.Text = "Write and Read EEPROM data only.";
				displayEEProgInfo.Visible = true;
				eepromDataMultiWin.DisplayEETextOn("Write and Read EEPROM data only.");
			}
			else if (!checkBoxEEMem.Checked && checkBoxEEMem.Enabled)
			{
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemEraseScript != 0)
				{
					displayEEProgInfo.Text = "Preserve device EEPROM data on write.";
					eepromDataMultiWin.DisplayEETextOn("Preserve device EEPROM data on write.");
				}
				else
				{
					displayEEProgInfo.Text = "Read/Restore device EEPROM on write.";
					eepromDataMultiWin.DisplayEETextOn("Read/Restore device EEPROM on write.");
				}
				displayEEProgInfo.Visible = true;
			}
			else
			{
				displayEEProgInfo.Visible = false;
				eepromDataMultiWin.DisplayEETextOff();
			}
			if (TestMemoryEnabled && TestMemoryOpen)
			{
				formTestMem.UpdateTestMemForm();
				if (updateMemories)
				{
					formTestMem.UpdateTestMemoryGrid();
				}
			}
			if (testConnected)
			{
				updateTestGUI();
			}
		}

		private void updateTestGUI()
		{
			try
			{
				MAN.UpdateTestGUI();
			}
			catch
			{
				MessageBox.Show("Error Connecting to\nPk2Test.dll 003", "PICkit 2 Error");
			}
		}

		private void progMemViewChanged(object sender, EventArgs e)
		{
			updateGUI(updateMemories: true);
		}

		private void buildDeviceMenu()
		{
			for (int i = 0; i < PICkitFunctions.DevFile.Families.Length; i++)
			{
				for (int j = 0; j < PICkitFunctions.DevFile.Families.Length; j++)
				{
					if (PICkitFunctions.DevFile.Families[j].FamilyType != i)
					{
						continue;
					}
					string familyName = PICkitFunctions.DevFile.Families[j].FamilyName;
					int num = familyName.IndexOf("/");
					if (familyName[0] == '#')
					{
						continue;
					}
					if (num < 0)
					{
						deviceToolStripMenuItem.DropDown.Items.Add(familyName);
						continue;
					}
					int count = deviceToolStripMenuItem.DropDownItems.Count;
					for (int k = 0; k < count; k++)
					{
						if (familyName.Substring(0, num) == deviceToolStripMenuItem.DropDown.Items[k].ToString())
						{
							ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)deviceToolStripMenuItem.DropDownItems[k];
							toolStripMenuItem.DropDown.Items.Add(familyName.Substring(num + 1));
						}
						else if (k == count - 1)
						{
							deviceToolStripMenuItem.DropDown.Items.Add(familyName.Substring(0, num));
							ToolStripMenuItem toolStripMenuItem2 = (ToolStripMenuItem)deviceToolStripMenuItem.DropDownItems[k + 1];
							toolStripMenuItem2.DropDown.Items.Add(familyName.Substring(num + 1));
							toolStripMenuItem2.DropDownItemClicked += deviceFamilyClick;
						}
					}
				}
			}
			deviceToolStripMenuItem.Enabled = true;
		}

		private void guiVddControl(object sender, EventArgs e)
		{
			vddControl(force: false, forceState: false);
		}

		private void vddControl(bool force, bool forceState)
		{
			if (force)
			{
				chkBoxVddOn.Checked = forceState;
			}
			bool @checked = chkBoxVddOn.Checked;
			if (!detectPICkit2(showFound: false, detectMult: false))
			{
				return;
			}
			if (@checked)
			{
				if (!lookForPoweredTarget(showMessageBox: true))
				{
					chkBoxVddOn.Checked = true;
					PICkitFunctions.SetVDDVoltage((float)numUpDnVDD.Value, 0.85f);
					PICkitFunctions.VddOn();
					if (checkForPowerErrors())
					{
						PICkitFunctions.VddOff();
					}
				}
				else
				{
					checkForPowerErrors();
					PICkitFunctions.VddOff();
				}
			}
			else
			{
				chkBoxVddOn.Checked = false;
				PICkitFunctions.VddOff();
			}
		}

		private void guiChangeVDD(object sender, EventArgs e)
		{
			if (detectPICkit2(showFound: false, detectMult: false))
			{
				PICkitFunctions.SetVDDVoltage((float)numUpDnVDD.Value, 0.85f);
			}
		}

		private void pickitFormClosing(object sender, FormClosingEventArgs e)
		{
			SaveINI();
		}

		private void fileMenuExit(object sender, EventArgs e)
		{
			Close();
		}

		private void menuFileImportHex(object sender, EventArgs e)
		{
			if (PICkitFunctions.FamilyIsKeeloq())
			{
				openHexFileDialog.Filter = "HEX files|*.hex;*.num|All files|*.*";
			}
			else if (PICkitFunctions.FamilyIsEEPROM())
			{
				openHexFileDialog.Filter = "HEX or BIN files|*.hex;*.bin|All files|*.*";
			}
			else
			{
				openHexFileDialog.Filter = "HEX files|*.hex|All files|*.*";
			}
			openHexFileDialog.ShowDialog();
			updateGUI(updateMemories: true);
		}

		private void importHexFile(object sender, CancelEventArgs e)
		{
			importHexFileGo();
		}

		private bool importHexFileGo()
		{
			int activePart = PICkitFunctions.ActivePart;
			bool flag = deviceVerification;
			deviceVerification = false;
			if (!preProgrammingCheck(PICkitFunctions.GetActiveFamily()))
			{
				deviceVerification = flag;
				displayStatusWindow.Text = "Device Error - hex file not loaded.";
				statusWindowColor = Constants.StatusColor.red;
				displayDataSource.Text = "None.";
				importGo = false;
				return false;
			}
			deviceVerification = flag;
			if (activePart != PICkitFunctions.ActivePart || PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem == 0 || (checkBoxProgMemEnabled.Checked && checkBoxEEMem.Checked))
			{
				PICkitFunctions.ResetBuffers();
			}
			else
			{
				if (checkBoxProgMemEnabled.Checked)
				{
					PICkitFunctions.DeviceBuffers.ClearProgramMemory(PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
					PICkitFunctions.DeviceBuffers.ClearConfigWords(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank);
					PICkitFunctions.DeviceBuffers.ClearUserIDs(PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].UserIDBytes, PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
				}
				if (checkBoxEEMem.Checked)
				{
					PICkitFunctions.DeviceBuffers.ClearEEPromMemory(PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemAddressIncrement, PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
				}
			}
			if (TestMemoryEnabled && TestMemoryOpen && formTestMem.HexImportExportTM())
			{
				formTestMem.ClearTestMemory();
			}
			string text = "Hex";
			if (openHexFileDialog.FileName.Substring(openHexFileDialog.FileName.Length - 4).ToUpper() == ".BIN" && PICkitFunctions.FamilyIsEEPROM())
			{
				text = "Bin";
			}
			switch (ImportExportHex.ImportHexFile(openHexFileDialog.FileName, checkBoxProgMemEnabled.Checked, checkBoxEEMem.Checked))
			{
			case Constants.FileRead.success:
				displayStatusWindow.Text = text + " file sucessfully imported.";
				if (multiWindow)
				{
					displayDataSource.Text = openHexFileDialog.FileName;
				}
				else
				{
					displayDataSource.Text = shortenHex(openHexFileDialog.FileName);
				}
				checkImportFile = true;
				importGo = true;
				break;
			case Constants.FileRead.noconfig:
				statusWindowColor = Constants.StatusColor.yellow;
				displayStatusWindow.Text = "Warning: No configuration words in hex file.\nIn MPLAB use File-Export to save hex with config.";
				if (multiWindow)
				{
					displayDataSource.Text = openHexFileDialog.FileName;
				}
				else
				{
					displayDataSource.Text = shortenHex(openHexFileDialog.FileName);
				}
				checkImportFile = true;
				importGo = true;
				break;
			case Constants.FileRead.partialcfg:
				statusWindowColor = Constants.StatusColor.yellow;
				displayStatusWindow.Text = "Warning: Some configuration words not in hex file.\nEnsure default values above right are acceptable.";
				if (multiWindow)
				{
					displayDataSource.Text = openHexFileDialog.FileName;
				}
				else
				{
					displayDataSource.Text = shortenHex(openHexFileDialog.FileName);
				}
				checkImportFile = true;
				importGo = true;
				break;
			case Constants.FileRead.largemem:
				statusWindowColor = Constants.StatusColor.yellow;
				displayStatusWindow.Text = "Warning: " + text + " File Loaded is larger than device.";
				if (multiWindow)
				{
					displayDataSource.Text = openHexFileDialog.FileName;
				}
				else
				{
					displayDataSource.Text = shortenHex(openHexFileDialog.FileName);
				}
				checkImportFile = true;
				importGo = true;
				break;
			default:
				statusWindowColor = Constants.StatusColor.red;
				displayStatusWindow.Text = "Error reading " + text + " file.";
				displayDataSource.Text = "None (Empty/Erased)";
				checkImportFile = false;
				importGo = false;
				PICkitFunctions.ResetBuffers();
				break;
			}
			if (checkImportFile)
			{
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].OSSCALSave)
				{
					PICkitFunctions.SetMCLRTemp(nMCLR: true);
					PICkitFunctions.VddOn();
					PICkitFunctions.ReadOSSCAL();
					PICkitFunctions.DeviceBuffers.ProgramMemory[PICkitFunctions.DeviceBuffers.ProgramMemory.Length - 1] = PICkitFunctions.DeviceBuffers.OSCCAL;
				}
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BandGapMask != 0)
				{
					PICkitFunctions.SetMCLRTemp(nMCLR: true);
					PICkitFunctions.VddOn();
					PICkitFunctions.ReadBandGap();
				}
				conditionalVDDOff();
				bool flag2 = false;
				bool flag3 = false;
				do
				{
					if (openHexFileDialog.FileName == hex4 || flag2)
					{
						if (!hex4ToolStripMenuItem.Visible && hex3.Length > 3)
						{
							hex4ToolStripMenuItem.Visible = true;
						}
						hex4 = hex3;
						hex4ToolStripMenuItem.Text = "&4" + hex3ToolStripMenuItem.Text.Substring(2);
						flag2 = true;
						flag3 = true;
					}
					if (openHexFileDialog.FileName == hex3 || flag2)
					{
						if (!hex3ToolStripMenuItem.Visible && hex2.Length > 3)
						{
							hex3ToolStripMenuItem.Visible = true;
						}
						hex3 = hex2;
						hex3ToolStripMenuItem.Text = "&3" + hex2ToolStripMenuItem.Text.Substring(2);
						flag2 = true;
						flag3 = true;
					}
					if (openHexFileDialog.FileName == hex2 || flag2)
					{
						if (!hex2ToolStripMenuItem.Visible && hex1.Length > 3)
						{
							hex2ToolStripMenuItem.Visible = true;
						}
						hex2 = hex1;
						hex2ToolStripMenuItem.Text = "&2" + hex1ToolStripMenuItem.Text.Substring(2);
						flag3 = true;
					}
					flag2 = true;
					if (openHexFileDialog.FileName == hex1)
					{
						flag3 = true;
					}
				}
				while (!flag3);
				if (!hex1ToolStripMenuItem.Visible)
				{
					hex1ToolStripMenuItem.Visible = true;
					toolStripMenuItem5.Visible = true;
				}
				hex1 = openHexFileDialog.FileName;
				hex1ToolStripMenuItem.Text = "&1 " + shortenHex(openHexFileDialog.FileName);
			}
			return checkImportFile;
		}

		private void menuFileExportHex(object sender, EventArgs e)
		{
			if (PICkitFunctions.FamilyIsKeeloq())
			{
				MessageBox.Show("Export not supported for\nthis part type.");
				return;
			}
			if (PICkitFunctions.FamilyIsEEPROM())
			{
				saveHexFileDialog.Filter = "Hex files|*.hex|Bin Files|*.bin|All files|*.*";
			}
			else
			{
				saveHexFileDialog.Filter = "Hex files|*.hex|All files|*.*";
			}
			saveHexFileDialog.ShowDialog();
		}

		private void exportHexFile(object sender, CancelEventArgs e)
		{
			ImportExportHex.ExportHexFile(saveHexFileDialog.FileName, checkBoxProgMemEnabled.Checked, checkBoxEEMem.Checked);
		}

		private bool preProgrammingCheck(int family)
		{
			statusGroupBox.Update();
			if (PICkitFunctions.LearnMode)
			{
				PICkitFunctions.SetVDDVoltage((float)numUpDnVDD.Value, 0.85f);
				return true;
			}
			if (!detectPICkit2(showFound: false, detectMult: false))
			{
				return false;
			}
			if (checkForPowerErrors())
			{
				updateGUI(updateMemories: false);
				return false;
			}
			lookForPoweredTarget(!timerAutoImportWrite.Enabled);
			if (PICkitFunctions.DevFile.Families[family].PartDetect)
			{
				if (!PICkitFunctions.DetectDevice(family, resetOnNotFound: false, chkBoxVddOn.Checked))
				{
					semiEnableGUIControls();
					statusWindowColor = Constants.StatusColor.yellow;
					displayStatusWindow.Text = "No device detected.";
					if (PICkitFunctions.DevFile.Families[family].Vpp < 1f)
					{
						displayStatusWindow.Text += "\nEnsure proper capacitance on VDDCORE/VCAP pin.";
					}
					checkForPowerErrors();
					updateGUI(updateMemories: false);
					return false;
				}
				setGUIVoltageLimits(setValue: false);
				fullEnableGUIControls();
				updateGUI(updateMemories: false);
			}
			else if (PICkitFunctions.DevFile.Families[family].DeviceIDMask != 0 && deviceVerification)
			{
				if (!PICkitFunctions.VerifyDeviceID(resetOnNoDevice: false, chkBoxVddOn.Checked))
				{
					statusWindowColor = Constants.StatusColor.yellow;
					if (PICkitFunctions.LastDeviceID == 0 || PICkitFunctions.LastDeviceID == PICkitFunctions.DevFile.Families[family].DeviceIDMask)
					{
						displayStatusWindow.Text = "No device detected.";
					}
					else
					{
						displayStatusWindow.Text = "Selected device not detected.";
						for (int i = 0; i < PICkitFunctions.DevFile.PartsList.Length; i++)
						{
							if (PICkitFunctions.DevFile.PartsList[i].Family == family && PICkitFunctions.DevFile.PartsList[i].DeviceID == PICkitFunctions.LastDeviceID)
							{
								Label label = displayStatusWindow;
								label.Text = label.Text + "\nDetected a " + PICkitFunctions.DevFile.PartsList[i].PartName + " instead.";
								break;
							}
						}
					}
					checkForPowerErrors();
					updateGUI(updateMemories: false);
					return false;
				}
			}
			else
			{
				PICkitFunctions.SetMCLRTemp(nMCLR: true);
				PICkitFunctions.SetVDDVoltage((float)numUpDnVDD.Value, 0.85f);
				PICkitFunctions.VddOn();
				PICkitFunctions.RunScript(0, 1);
				Thread.Sleep(300);
				PICkitFunctions.RunScript(1, 1);
				conditionalVDDOff();
				if (checkForPowerErrors())
				{
					updateGUI(updateMemories: false);
					return false;
				}
			}
			PICkitFunctions.SetVDDVoltage((float)numUpDnVDD.Value, 0.85f);
			if (!checkBoxEEMem.Enabled && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0)
			{
				checkBoxEEMem.Checked = true;
			}
			return true;
		}

		private void readDevice(object sender, EventArgs e)
		{
			deviceRead();
		}

		private void deviceRead()
		{
			if (PICkitFunctions.FamilyIsKeeloq())
			{
				displayStatusWindow.Text = "Read not supported for this device type.";
				statusWindowColor = Constants.StatusColor.yellow;
				updateGUI(updateMemories: false);
			}
			else
			{
				if (!preProgrammingCheck(PICkitFunctions.GetActiveFamily()))
				{
					return;
				}
				if (PICkitFunctions.FamilyIsPIC32())
				{
					if (PIC32MXFunctions.PIC32Read())
					{
						statusWindowColor = Constants.StatusColor.normal;
					}
					else
					{
						statusWindowColor = Constants.StatusColor.red;
					}
					conditionalVDDOff();
					updateGUI(updateMemories: true);
					return;
				}
				displayStatusWindow.Text = "Reading device:\n";
				Update();
				byte[] array = new byte[128];
				PICkitFunctions.SetMCLRTemp(nMCLR: true);
				PICkitFunctions.VddOn();
				if (checkBoxProgMemEnabled.Checked)
				{
					displayStatusWindow.Text += "Program Memory... ";
					Update();
					if (useProgExec33())
					{
						if (!dsPIC33_PE.PE33Read(displayStatusWindow.Text))
						{
							statusWindowColor = Constants.StatusColor.red;
							conditionalVDDOff();
							updateGUI(updateMemories: true);
							return;
						}
					}
					else if (useProgExec24F())
					{
						if (!PIC24F_PE.PE24FRead(displayStatusWindow.Text))
						{
							statusWindowColor = Constants.StatusColor.red;
							conditionalVDDOff();
							updateGUI(updateMemories: true);
							return;
						}
					}
					else
					{
						PICkitFunctions.RunScript(0, 1);
						if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemAddrSetScript != 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemAddrBytes != 0)
						{
							if (PICkitFunctions.FamilyIsEEPROM())
							{
								PICkitFunctions.DownloadAddress3MSBFirst(eeprom24BitAddress(0, setReadBit: false));
								PICkitFunctions.RunScript(5, 1);
								if (eeprom_CheckBusErrors())
								{
									return;
								}
							}
							else
							{
								PICkitFunctions.DownloadAddress3(0);
								PICkitFunctions.RunScript(5, 1);
							}
						}
						int bytesPerLocation = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
						int num = 128 / (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemRdWords * bytesPerLocation);
						int num2 = num * PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemRdWords;
						int num3 = 0;
						progressBar1.Value = 0;
						progressBar1.Maximum = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem / num2;
						do
						{
							if (PICkitFunctions.FamilyIsEEPROM())
							{
								if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 1 && num3 > PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[1] && num3 % (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[1] + 1) == 0)
								{
									PICkitFunctions.DownloadAddress3MSBFirst(eeprom24BitAddress(num3, setReadBit: false));
									PICkitFunctions.RunScript(5, 1);
								}
								PICkitFunctions.Download3Multiples(eeprom24BitAddress(num3, setReadBit: true), num, PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemRdWords);
							}
							PICkitFunctions.RunScriptUploadNoLen(3, num);
							Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
							PICkitFunctions.UploadDataNoLen();
							Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
							int num4 = 0;
							for (int i = 0; i < num2; i++)
							{
								int num5 = 0;
								uint num6 = array[num4 + num5++];
								if (num5 < bytesPerLocation)
								{
									num6 = (uint)((int)num6 | (array[num4 + num5++] << 8));
								}
								if (num5 < bytesPerLocation)
								{
									num6 = (uint)((int)num6 | (array[num4 + num5++] << 16));
								}
								if (num5 < bytesPerLocation)
								{
									num6 = (uint)((int)num6 | (array[num4 + num5++] << 24));
								}
								num4 += num5;
								if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
								{
									num6 = ((num6 >> 1) & PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
								}
								PICkitFunctions.DeviceBuffers.ProgramMemory[num3++] = num6;
								if (num3 == PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem)
								{
									break;
								}
								if (num3 % 32768 == 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemAddrSetScript != 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemAddrBytes != 0 && PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 65535)
								{
									PICkitFunctions.DownloadAddress3(65536 * (num3 / 32768));
									PICkitFunctions.RunScript(5, 1);
									break;
								}
							}
							progressBar1.PerformStep();
						}
						while (num3 < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem);
						PICkitFunctions.RunScript(1, 1);
						if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 3 && bytesPerLocation == 2 && PICkitFunctions.FamilyIsEEPROM())
						{
							uint num7 = 0u;
							for (int j = 0; j < PICkitFunctions.DeviceBuffers.ProgramMemory.Length; j++)
							{
								num7 = ((PICkitFunctions.DeviceBuffers.ProgramMemory[j] << 8) & 0xFF00);
								PICkitFunctions.DeviceBuffers.ProgramMemory[j] >>= 8;
								PICkitFunctions.DeviceBuffers.ProgramMemory[j] |= num7;
							}
						}
					}
				}
				if (checkBoxEEMem.Checked && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0)
				{
					readEEPROM();
				}
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords > 0 && checkBoxProgMemEnabled.Checked)
				{
					displayStatusWindow.Text += "UserIDs... ";
					Update();
					PICkitFunctions.RunScript(0, 1);
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDRdPrepScript > 0)
					{
						PICkitFunctions.RunScript(16, 1);
					}
					int userIDBytes = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].UserIDBytes;
					int num8 = 0;
					int num9 = 0;
					PICkitFunctions.RunScriptUploadNoLen(17, 1);
					Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
					if ((long)(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords * userIDBytes) > 64L)
					{
						PICkitFunctions.UploadDataNoLen();
						Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
					}
					PICkitFunctions.RunScript(1, 1);
					do
					{
						int num10 = 0;
						uint num11 = array[num9 + num10++];
						if (num10 < userIDBytes)
						{
							num11 = (uint)((int)num11 | (array[num9 + num10++] << 8));
						}
						if (num10 < userIDBytes)
						{
							num11 = (uint)((int)num11 | (array[num9 + num10++] << 16));
						}
						if (num10 < userIDBytes)
						{
							num11 = (uint)((int)num11 | (array[num9 + num10++] << 24));
						}
						num9 += num10;
						if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
						{
							num11 = ((num11 >> 1) & PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
						}
						PICkitFunctions.DeviceBuffers.UserIDs[num8++] = num11;
					}
					while (num8 < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords);
				}
				int num12 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr / (int)PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemHexBytes;
				int configWords = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords;
				if (configWords > 0 && num12 >= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem && checkBoxProgMemEnabled.Checked)
				{
					displayStatusWindow.Text += "Config... ";
					Update();
					PICkitFunctions.ReadConfigOutsideProgMem();
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BandGapMask != 0)
					{
						PICkitFunctions.DeviceBuffers.BandGap = (PICkitFunctions.DeviceBuffers.ConfigWords[0] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BandGapMask);
					}
				}
				else if (configWords > 0 && checkBoxProgMemEnabled.Checked)
				{
					displayStatusWindow.Text += "Config... ";
					Update();
					for (int k = 0; k < configWords; k++)
					{
						PICkitFunctions.DeviceBuffers.ConfigWords[k] = PICkitFunctions.DeviceBuffers.ProgramMemory[num12 + k];
					}
				}
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].OSSCALSave)
				{
					PICkitFunctions.ReadOSSCAL();
				}
				if (TestMemoryEnabled && TestMemoryOpen)
				{
					formTestMem.ReadTestMemory();
				}
				conditionalVDDOff();
				displayStatusWindow.Text += "Done.";
				displayDataSource.Text = "Read from " + PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].PartName;
				checkImportFile = false;
				updateGUI(updateMemories: true);
			}
		}

		private void readEEPROM()
		{
			byte[] array = new byte[128];
			displayStatusWindow.Text += "EE... ";
			Update();
			PICkitFunctions.RunScript(0, 1);
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EERdPrepScript > 0)
			{
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemHexBytes == 4)
				{
					PICkitFunctions.DownloadAddress3((int)(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEAddr / 2u));
				}
				else
				{
					PICkitFunctions.DownloadAddress3(0);
				}
				PICkitFunctions.RunScript(8, 1);
			}
			int eEMemBytesPerWord = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemBytesPerWord;
			int num = 128 / (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EERdLocations * eEMemBytesPerWord);
			int num2 = num * PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EERdLocations;
			int num3 = 0;
			uint eEBlank = getEEBlank();
			progressBar1.Value = 0;
			progressBar1.Maximum = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem / num2;
			do
			{
				PICkitFunctions.RunScriptUploadNoLen(9, num);
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
				PICkitFunctions.UploadDataNoLen();
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
				int num4 = 0;
				for (int i = 0; i < num2; i++)
				{
					int num5 = 0;
					uint num6 = array[num4 + num5++];
					if (num5 < eEMemBytesPerWord)
					{
						num6 = (uint)((int)num6 | (array[num4 + num5++] << 8));
					}
					num4 += num5;
					if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
					{
						num6 = ((num6 >> 1) & eEBlank);
					}
					PICkitFunctions.DeviceBuffers.EEPromMemory[num3++] = num6;
					if (num3 >= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem)
					{
						break;
					}
				}
				progressBar1.PerformStep();
			}
			while (num3 < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem);
			PICkitFunctions.RunScript(1, 1);
		}

		private void eraseDevice(object sender, EventArgs e)
		{
			eraseDeviceAll(forceOSSCAL: false, new uint[0]);
		}

		private void eraseDeviceAll(bool forceOSSCAL, uint[] calWords)
		{
			if (PICkitFunctions.FamilyIsKeeloq() || PICkitFunctions.FamilyIsMCP())
			{
				displayStatusWindow.Text = "Erase not supported for this device type.";
				statusWindowColor = Constants.StatusColor.yellow;
				updateGUI(updateMemories: false);
			}
			else
			{
				if (!preProgrammingCheck(PICkitFunctions.GetActiveFamily()))
				{
					return;
				}
				DeviceData deviceData = PICkitFunctions.CloneBuffers(PICkitFunctions.DeviceBuffers);
				if (PICkitFunctions.FamilyIsEEPROM() && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] != 3 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] != 4)
				{
					PICkitFunctions.ResetBuffers();
					checkImportFile = false;
					if (!eepromWrite(eraseWrite: true))
					{
						if (!toolStripMenuItemClearBuffersErase.Checked)
						{
							PICkitFunctions.DeviceBuffers = deviceData;
						}
						return;
					}
					displayStatusWindow.Text += "Complete";
					if (!toolStripMenuItemClearBuffersErase.Checked)
					{
						PICkitFunctions.DeviceBuffers = deviceData;
					}
					else
					{
						displayDataSource.Text = "None (Empty/Erased)";
					}
					updateGUI(updateMemories: true);
				}
				else
				{
					if (!checkEraseVoltage(checkRowErase: false))
					{
						return;
					}
					progressBar1.Value = 0;
					PICkitFunctions.SetMCLRTemp(nMCLR: true);
					PICkitFunctions.VddOn();
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].OSSCALSave && !forceOSSCAL)
					{
						PICkitFunctions.ReadOSSCAL();
						if (!verifyOSCCAL())
						{
							return;
						}
					}
					uint oSCCAL = PICkitFunctions.DeviceBuffers.OSCCAL;
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BandGapMask != 0)
					{
						PICkitFunctions.ReadBandGap();
					}
					uint bandGap = PICkitFunctions.DeviceBuffers.BandGap;
					displayStatusWindow.Text = "Erasing device...";
					Update();
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMemEraseScript > 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DebugRowEraseSize == 0)
					{
						PICkitFunctions.RunScript(0, 1);
						if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWrPrepScript > 0)
						{
							PICkitFunctions.DownloadAddress3(0);
							PICkitFunctions.RunScript(14, 1);
						}
						PICkitFunctions.ExecuteScript(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMemEraseScript);
						PICkitFunctions.RunScript(1, 1);
					}
					PICkitFunctions.RunScript(0, 1);
					if (TestMemoryEnabled && TestMemoryOpen && calWords.Length > 0)
					{
						byte[] array = new byte[2 * calWords.Length];
						for (int i = 0; i < calWords.Length; i++)
						{
							calWords[i] <<= 1;
							array[2 * i] = (byte)(calWords[i] & 0xFF);
							array[2 * i + 1] = (byte)(calWords[i] >> 8);
						}
						PICkitFunctions.DataClrAndDownload(array, 0);
						PICkitFunctions.RunScript(21, 1);
					}
					else
					{
						if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ChipErasePrepScript > 0)
						{
							PICkitFunctions.RunScript(4, 1);
						}
						PICkitFunctions.RunScript(22, 1);
					}
					PICkitFunctions.RunScript(1, 1);
					PICkitFunctions.ResetBuffers();
					if (TestMemoryEnabled && TestMemoryOpen && !toolStripMenuItemClearBuffersErase.Checked)
					{
						formTestMem.ClearTestMemory();
					}
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].OSSCALSave)
					{
						PICkitFunctions.DeviceBuffers.OSCCAL = oSCCAL;
						deviceData.OSCCAL = oSCCAL;
						PICkitFunctions.WriteOSSCAL();
						PICkitFunctions.DeviceBuffers.ProgramMemory[PICkitFunctions.DeviceBuffers.ProgramMemory.Length - 1] = PICkitFunctions.DeviceBuffers.OSCCAL;
						deviceData.ProgramMemory[deviceData.ProgramMemory.Length - 1] = PICkitFunctions.DeviceBuffers.OSCCAL;
					}
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BandGapMask != 0)
					{
						PICkitFunctions.DeviceBuffers.BandGap = bandGap;
						deviceData.BandGap = bandGap;
						PICkitFunctions.WriteConfigOutsideProgMem(codeProtect: false, dataProtect: false);
					}
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].WriteCfgOnErase)
					{
						int num = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr / (int)PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemHexBytes;
						int configWords = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords;
						int num2 = PICkitFunctions.DeviceBuffers.ProgramMemory.Length;
						if (num < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem && configWords > 0)
						{
							uint num3 = 0u;
							num3 = ((PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue != 65535) ? 16711680u : 61440u);
							for (int num4 = configWords; num4 > 0; num4--)
							{
								PICkitFunctions.DeviceBuffers.ProgramMemory[num2 - num4] = (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[configWords - num4] | num3);
							}
							writeConfigInsideProgramMem();
						}
						else
						{
							PICkitFunctions.WriteConfigOutsideProgMem(codeProtect: false, dataProtect: false);
						}
					}
					if (!toolStripMenuItemClearBuffersErase.Checked)
					{
						PICkitFunctions.DeviceBuffers = deviceData;
					}
					displayStatusWindow.Text += "Complete";
					Update();
					if (toolStripMenuItemClearBuffersErase.Checked)
					{
						displayDataSource.Text = "None (Empty/Erased)";
					}
					checkImportFile = false;
					conditionalVDDOff();
					updateGUI(updateMemories: true);
				}
			}
		}

		private bool checkEraseVoltage(bool checkRowErase)
		{
			if ((float)(numUpDnVDD.Value + 0.05m) < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddErase && ShowWriteEraseVDDDialog)
			{
				if (checkRowErase && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DebugRowEraseScript > 0)
				{
					return false;
				}
				dialogVddErase.UpdateText();
				bool enabled = timerAutoImportWrite.Enabled;
				timerAutoImportWrite.Enabled = false;
				dialogVddErase.ShowDialog();
				timerAutoImportWrite.Enabled = enabled;
				return ContinueWriteErase;
			}
			return true;
		}

		private bool verifyOSCCAL()
		{
			if (!PICkitFunctions.ValidateOSSCAL() && verifyOSCCALValue && MessageBox.Show("Invalid OSCCAL Value detected:\n\nTo abort, click 'Cancel'\nTo continue, click 'OK'", "Warning!", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
			{
				conditionalVDDOff();
				displayStatusWindow.Text = "Operation Aborted.\n";
				statusWindowColor = Constants.StatusColor.red;
				updateGUI(updateMemories: true);
				return false;
			}
			return true;
		}

		private void writeDevice(object sender, EventArgs e)
		{
			deviceWrite();
		}

		private bool deviceWrite()
		{
			uint num = 0u;
			if (PICkitFunctions.FamilyIsEEPROM())
			{
				return eepromWrite(eraseWrite: false);
			}
			bool flag = false;
			if (!preProgrammingCheck(PICkitFunctions.GetActiveFamily()))
			{
				return false;
			}
			if (!checkEraseVoltage(checkRowErase: true) && !PICkitFunctions.FamilyIsPIC32())
			{
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DebugRowEraseScript <= 0)
				{
					return false;
				}
				flag = true;
			}
			updateGUI(updateMemories: false);
			Update();
			if (checkImportFile && !PICkitFunctions.LearnMode)
			{
				FileInfo fileInfo = new FileInfo(openHexFileDialog.FileName);
				if (ImportExportHex.LastWriteTime != fileInfo.LastWriteTime)
				{
					displayStatusWindow.Text = "Reloading Hex File\n";
					Update();
					Thread.Sleep(300);
					if (!importHexFileGo())
					{
						displayStatusWindow.Text = "Error Loading Hex File: Write aborted.\n";
						statusWindowColor = Constants.StatusColor.red;
						updateGUI(updateMemories: true);
						return false;
					}
				}
			}
			if (PICkitFunctions.FamilyIsPIC32())
			{
				if (PIC32MXFunctions.P32Write(verifyOnWriteToolStripMenuItem.Checked, enableCodeProtectToolStripMenuItem.Checked))
				{
					statusWindowColor = Constants.StatusColor.green;
					conditionalVDDOff();
					updateGUI(updateMemories: true);
					return true;
				}
				statusWindowColor = Constants.StatusColor.red;
				conditionalVDDOff();
				updateGUI(updateMemories: true);
				return true;
			}
			PICkitFunctions.SetMCLRTemp(nMCLR: true);
			PICkitFunctions.VddOn();
			if (PICkitFunctions.LearnMode && PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].DeviceIDMask != 0)
			{
				PICkitFunctions.MetaCmd_CHECK_DEVICE_ID();
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].OSSCALSave)
			{
				if (PICkitFunctions.LearnMode)
				{
					PICkitFunctions.DeviceBuffers.ProgramMemory[PICkitFunctions.DeviceBuffers.ProgramMemory.Length - 1] = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue;
					PICkitFunctions.MetaCmd_READ_OSCCAL();
				}
				else
				{
					PICkitFunctions.ReadOSSCAL();
					PICkitFunctions.DeviceBuffers.ProgramMemory[PICkitFunctions.DeviceBuffers.ProgramMemory.Length - 1] = PICkitFunctions.DeviceBuffers.OSCCAL;
					if (!verifyOSCCAL())
					{
						return false;
					}
				}
			}
			_ = PICkitFunctions.DeviceBuffers.OSCCAL;
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BandGapMask != 0)
			{
				if (PICkitFunctions.LearnMode)
				{
					PICkitFunctions.MetaCmd_READ_BANDGAP();
				}
				else
				{
					PICkitFunctions.ReadBandGap();
				}
			}
			_ = PICkitFunctions.DeviceBuffers.BandGap;
			bool flag2 = false;
			if (checkBoxProgMemEnabled.Checked && (checkBoxEEMem.Checked || !checkBoxEEMem.Enabled))
			{
				if (flag)
				{
					displayStatusWindow.Text = "Erasing Part with Low Voltage Row Erase...\n";
					Update();
					PICkitFunctions.RowEraseDevice();
				}
				else
				{
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMemEraseScript > 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DebugRowEraseSize == 0)
					{
						PICkitFunctions.RunScript(0, 1);
						if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWrPrepScript > 0)
						{
							PICkitFunctions.DownloadAddress3(0);
							PICkitFunctions.RunScript(14, 1);
						}
						PICkitFunctions.ExecuteScript(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMemEraseScript);
						PICkitFunctions.RunScript(1, 1);
					}
					PICkitFunctions.RunScript(0, 1);
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ChipErasePrepScript > 0)
					{
						PICkitFunctions.RunScript(4, 1);
					}
					PICkitFunctions.RunScript(22, 1);
					PICkitFunctions.RunScript(1, 1);
				}
			}
			else if (checkBoxProgMemEnabled.Checked && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemEraseScript != 0)
			{
				if (flag)
				{
					displayStatusWindow.Text = "Erasing Part with Low Voltage Row Erase...\n";
					Update();
					PICkitFunctions.RowEraseDevice();
				}
				else
				{
					PICkitFunctions.RunScript(0, 1);
					PICkitFunctions.RunScript(23, 1);
					PICkitFunctions.RunScript(1, 1);
				}
			}
			else if (checkBoxEEMem.Checked && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMemEraseScript != 0)
			{
				PICkitFunctions.RunScript(0, 1);
				PICkitFunctions.RunScript(24, 1);
				PICkitFunctions.RunScript(1, 1);
			}
			else if (!checkBoxEEMem.Checked && checkBoxEEMem.Enabled && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemEraseScript == 0)
			{
				displayStatusWindow.Text = "Reading device:\n";
				Update();
				readEEPROM();
				updateGUI(updateMemories: true);
				if (flag)
				{
					displayStatusWindow.Text = "Erasing Part with Low Voltage Row Erase...\n";
					Update();
					PICkitFunctions.RowEraseDevice();
				}
				else
				{
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMemEraseScript > 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DebugRowEraseSize == 0)
					{
						PICkitFunctions.RunScript(0, 1);
						if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWrPrepScript > 0)
						{
							PICkitFunctions.DownloadAddress3(0);
							PICkitFunctions.RunScript(14, 1);
						}
						PICkitFunctions.ExecuteScript(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMemEraseScript);
						PICkitFunctions.RunScript(1, 1);
					}
					PICkitFunctions.RunScript(0, 1);
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ChipErasePrepScript > 0)
					{
						PICkitFunctions.RunScript(4, 1);
					}
					PICkitFunctions.RunScript(22, 1);
					PICkitFunctions.RunScript(1, 1);
					flag2 = true;
				}
			}
			displayStatusWindow.Text = "Writing device:\n";
			Update();
			bool flag3 = false;
			int num2 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr / (int)PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemHexBytes;
			int configWords = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords;
			int num3 = PICkitFunctions.DeviceBuffers.ProgramMemory.Length;
			uint[] array = new uint[configWords];
			if (num2 < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem && configWords > 0)
			{
				flag3 = true;
				for (int num4 = configWords; num4 > 0; num4--)
				{
					array[num4 - 1] = PICkitFunctions.DeviceBuffers.ProgramMemory[num3 - num4];
					PICkitFunctions.DeviceBuffers.ProgramMemory[num3 - num4] = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue;
				}
			}
			num3--;
			if (checkBoxProgMemEnabled.Checked)
			{
				displayStatusWindow.Text += "Program Memory... ";
				Update();
				progressBar1.Value = 0;
				PICkitFunctions.RunScript(0, 1);
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemWrPrepScript != 0)
				{
					PICkitFunctions.DownloadAddress3(0);
					PICkitFunctions.RunScript(6, 1);
				}
				if (PICkitFunctions.FamilyIsKeeloq())
				{
					PICkitFunctions.HCS360_361_VppSpecial();
				}
				int progMemWrWords = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemWrWords;
				int bytesPerLocation = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
				int num5 = 256 / (progMemWrWords * bytesPerLocation);
				int num6 = num5 * progMemWrWords;
				int num7 = 0;
				num3 = PICkitFunctions.FindLastUsedInBuffer(PICkitFunctions.DeviceBuffers.ProgramMemory, PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue, num3);
				if ((progMemWrWords == num3 + 1 || num6 > num3 + 1) && !PICkitFunctions.LearnMode)
				{
					num5 = 1;
					num6 = progMemWrWords;
				}
				int num8 = (num3 + 1) / num6;
				if ((num3 + 1) % num6 > 0)
				{
					num8++;
				}
				num3 = num8 * num6;
				progressBar1.Maximum = num3 / num6;
				if (useProgExec33())
				{
					if (!dsPIC33_PE.PE33Write(num3, displayStatusWindow.Text))
					{
						statusWindowColor = Constants.StatusColor.red;
						conditionalVDDOff();
						updateGUI(updateMemories: true);
						return false;
					}
				}
				else if (useProgExec24F())
				{
					if (!PIC24F_PE.PE24FWrite(num3, displayStatusWindow.Text, verifyOnWriteToolStripMenuItem.Checked))
					{
						statusWindowColor = Constants.StatusColor.red;
						conditionalVDDOff();
						updateGUI(updateMemories: true);
						return false;
					}
				}
				else
				{
					byte[] downloadBuffer = new byte[256];
					do
					{
						int num9 = 0;
						for (int i = 0; i < num6; i++)
						{
							if (num7 == num3)
							{
								break;
							}
							uint num10 = PICkitFunctions.DeviceBuffers.ProgramMemory[num7++];
							if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
							{
								num10 <<= 1;
							}
							downloadBuffer[num9++] = (byte)(num10 & 0xFF);
							num += (byte)(num10 & 0xFF);
							for (int j = 1; j < bytesPerLocation; j++)
							{
								num10 >>= 8;
								downloadBuffer[num9++] = (byte)(num10 & 0xFF);
								num += (byte)(num10 & 0xFF);
							}
						}
						if (PICkitFunctions.FamilyIsKeeloq())
						{
							processKeeloqData(ref downloadBuffer, num7);
						}
						for (int num11 = PICkitFunctions.DataClrAndDownload(downloadBuffer, 0); num11 < num9; num11 = PICkitFunctions.DataDownload(downloadBuffer, num11, num9))
						{
						}
						PICkitFunctions.RunScript(7, num5);
						if (num7 % 32768 == 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemWrPrepScript != 0)
						{
							PICkitFunctions.DownloadAddress3(65536 * (num7 / 32768));
							PICkitFunctions.RunScript(6, 1);
						}
						progressBar1.PerformStep();
					}
					while (num7 < num3);
					PICkitFunctions.RunScript(1, 1);
				}
			}
			int num12 = num3;
			if (flag3)
			{
				for (int num13 = configWords; num13 > 0; num13--)
				{
					PICkitFunctions.DeviceBuffers.ProgramMemory[PICkitFunctions.DeviceBuffers.ProgramMemory.Length - num13] = array[num13 - 1];
				}
			}
			if ((checkBoxEEMem.Checked || flag2) && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0)
			{
				displayStatusWindow.Text += "EE... ";
				Update();
				PICkitFunctions.RunScript(0, 1);
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEWrPrepScript > 1)
				{
					if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemHexBytes == 4)
					{
						PICkitFunctions.DownloadAddress3((int)(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEAddr / 2u));
					}
					else
					{
						PICkitFunctions.DownloadAddress3(0);
					}
					PICkitFunctions.RunScript(10, 1);
				}
				int eEMemBytesPerWord = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemBytesPerWord;
				uint eEBlank = getEEBlank();
				int num14 = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEWrLocations;
				if (num14 < 16)
				{
					num14 = 16;
				}
				num3 = ((!checkBoxProgMemEnabled.Checked || flag || PICkitFunctions.LearnMode) ? (PICkitFunctions.DeviceBuffers.EEPromMemory.Length - 1) : PICkitFunctions.FindLastUsedInBuffer(PICkitFunctions.DeviceBuffers.EEPromMemory, eEBlank, PICkitFunctions.DeviceBuffers.EEPromMemory.Length - 1));
				int num15 = (num3 + 1) / num14;
				if ((num3 + 1) % num14 > 0)
				{
					num15++;
				}
				num3 = num15 * num14;
				byte[] array2 = new byte[num14 * eEMemBytesPerWord];
				int repetitions = num14 / (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEWrLocations;
				int num16 = 0;
				progressBar1.Value = 0;
				progressBar1.Maximum = num3 / num14;
				do
				{
					int num17 = 0;
					for (int k = 0; k < num14; k++)
					{
						uint num18 = PICkitFunctions.DeviceBuffers.EEPromMemory[num16++];
						if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
						{
							num18 <<= 1;
						}
						array2[num17++] = (byte)(num18 & 0xFF);
						num += (byte)(num18 & 0xFF);
						for (int l = 1; l < eEMemBytesPerWord; l++)
						{
							num18 >>= 8;
							array2[num17++] = (byte)(num18 & 0xFF);
							num += (byte)(num18 & 0xFF);
						}
					}
					PICkitFunctions.DataClrAndDownload(array2, 0);
					PICkitFunctions.RunScript(11, repetitions);
					progressBar1.PerformStep();
				}
				while (num16 < num3);
				PICkitFunctions.RunScript(1, 1);
			}
			if (checkBoxProgMemEnabled.Checked && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords > 0)
			{
				displayStatusWindow.Text += "UserIDs... ";
				Update();
				PICkitFunctions.RunScript(0, 1);
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWrPrepScript > 0)
				{
					PICkitFunctions.RunScript(18, 1);
				}
				int userIDBytes = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].UserIDBytes;
				byte[] array3 = new byte[PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords * userIDBytes];
				int num19 = 0;
				int num20 = 0;
				for (int m = 0; m < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords; m++)
				{
					uint num21 = PICkitFunctions.DeviceBuffers.UserIDs[num20++];
					if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
					{
						num21 <<= 1;
					}
					array3[num19++] = (byte)(num21 & 0xFF);
					num += (byte)(num21 & 0xFF);
					for (int n = 1; n < userIDBytes; n++)
					{
						num21 >>= 8;
						array3[num19++] = (byte)(num21 & 0xFF);
						num += (byte)(num21 & 0xFF);
					}
				}
				for (int num22 = PICkitFunctions.DataClrAndDownload(array3, 0); num22 < num19; num22 = PICkitFunctions.DataDownload(array3, num22, num19))
				{
				}
				PICkitFunctions.RunScript(19, 1);
				PICkitFunctions.RunScript(1, 1);
			}
			bool flag4 = true;
			if (flag3)
			{
				if (PICkitFunctions.LearnMode)
				{
					if (num12 == PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem)
					{
						num = ((PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue <= 65535) ? (num - 8) : (num - 128));
					}
				}
				else
				{
					num12 -= configWords;
				}
			}
			if (verifyOnWriteToolStripMenuItem.Checked)
			{
				if (PICkitFunctions.LearnMode)
				{
					PICkitFunctions.MetaCmd_START_CHECKSUM();
				}
				flag4 = deviceVerify(writeVerify: true, num12 - 1, flag2);
				if (PICkitFunctions.LearnMode)
				{
					PICkitFunctions.MetaCmd_VERIFY_CHECKSUM(num);
					num = 0u;
				}
			}
			if (PICkitFunctions.LearnMode && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].OSSCALSave)
			{
				PICkitFunctions.MetaCmd_WRITE_OSCCAL();
				PICkitFunctions.DeviceBuffers.ProgramMemory[PICkitFunctions.DeviceBuffers.ProgramMemory.Length - 1] = PICkitFunctions.DeviceBuffers.OSCCAL;
			}
			if (flag4)
			{
				if (configWords > 0 && !flag3 && checkBoxProgMemEnabled.Checked)
				{
					if (!verifyOnWriteToolStripMenuItem.Checked)
					{
						displayStatusWindow.Text += "Config... ";
						Update();
					}
					if ((PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].FamilyName == "PIC18F" || PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].FamilyName == "PIC18F_K_") && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords > 5 && (PICkitFunctions.DeviceBuffers.ConfigWords[5] & -8193) == PICkitFunctions.DeviceBuffers.ConfigWords[5])
					{
						uint num23 = PICkitFunctions.DeviceBuffers.ConfigWords[5];
						PICkitFunctions.DeviceBuffers.ConfigWords[5] = 65535u;
						PICkitFunctions.WriteConfigOutsideProgMem(codeProtect: false, dataProtect: false);
						PICkitFunctions.DeviceBuffers.ConfigWords[5] = num23;
					}
					num += PICkitFunctions.WriteConfigOutsideProgMem(enableCodeProtectToolStripMenuItem.Enabled && enableCodeProtectToolStripMenuItem.Checked, enableDataProtectStripMenuItem.Enabled && enableDataProtectStripMenuItem.Checked);
					if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue == 65535)
					{
						num += PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[7];
					}
					if (verifyOnWriteToolStripMenuItem.Checked && (!PICkitFunctions.LearnMode || PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BandGapMask == 0))
					{
						if (verifyConfig(configWords, num2))
						{
							statusWindowColor = Constants.StatusColor.green;
							displayStatusWindow.Text = "Programming Successful.\n";
						}
						else if (!PICkitFunctions.LearnMode)
						{
							statusWindowColor = Constants.StatusColor.red;
							flag4 = false;
						}
						if (PICkitFunctions.LearnMode && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BandGapMask == 0)
						{
							PICkitFunctions.MetaCmd_VERIFY_CHECKSUM(num);
						}
					}
				}
				else if (configWords > 0 && checkBoxProgMemEnabled.Checked)
				{
					if (!verifyOnWriteToolStripMenuItem.Checked)
					{
						displayStatusWindow.Text += "Config... ";
						Update();
					}
					for (int num24 = 0; num24 < configWords; num24++)
					{
						if (num24 == PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPConfig - 1)
						{
							if (enableCodeProtectToolStripMenuItem.Enabled && enableCodeProtectToolStripMenuItem.Checked)
							{
								PICkitFunctions.DeviceBuffers.ProgramMemory[num2 + num24] &= (uint)(~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPMask);
							}
							if (enableDataProtectStripMenuItem.Enabled && enableDataProtectStripMenuItem.Checked)
							{
								PICkitFunctions.DeviceBuffers.ProgramMemory[num2 + num24] &= (uint)(~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DPMask);
							}
						}
					}
					writeConfigInsideProgramMem();
					if (verifyOnWriteToolStripMenuItem.Checked)
					{
						statusWindowColor = Constants.StatusColor.green;
						displayStatusWindow.Text = "Programming Successful.\n";
					}
					else
					{
						flag4 = false;
					}
				}
				else if (!checkBoxProgMemEnabled.Checked)
				{
					statusWindowColor = Constants.StatusColor.green;
					displayStatusWindow.Text = "Programming Successful.\n";
				}
				else
				{
					statusWindowColor = Constants.StatusColor.green;
					displayStatusWindow.Text = "Programming Successful.\n";
				}
				conditionalVDDOff();
				if (!verifyOnWriteToolStripMenuItem.Checked)
				{
					displayStatusWindow.Text += "Done.";
				}
				if (PICkitFunctions.LearnMode)
				{
					displayStatusWindow.Text = "Programmer-To-Go download complete.";
				}
				updateGUI(updateMemories: true);
				return flag4;
			}
			return false;
		}

		private void writeConfigInsideProgramMem()
		{
			PICkitFunctions.RunScript(0, 1);
			int num = PICkitFunctions.DeviceBuffers.ProgramMemory.Length - PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemWrWords;
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemWrPrepScript != 0)
			{
				PICkitFunctions.DownloadAddress3(num * PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].AddressIncrement);
				PICkitFunctions.RunScript(6, 1);
			}
			byte[] array = new byte[256];
			int num2 = 0;
			for (int i = 0; i < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemWrWords; i++)
			{
				uint num3 = PICkitFunctions.DeviceBuffers.ProgramMemory[num++];
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
				{
					num3 <<= 1;
				}
				array[num2++] = (byte)(num3 & 0xFF);
				for (int j = 1; j < PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation; j++)
				{
					num3 >>= 8;
					array[num2++] = (byte)(num3 & 0xFF);
				}
			}
			for (int num4 = PICkitFunctions.DataClrAndDownload(array, 0); num4 < num2; num4 = PICkitFunctions.DataDownload(array, num4, num2))
			{
			}
			PICkitFunctions.RunScript(7, 1);
			PICkitFunctions.RunScript(1, 1);
		}

		private void processKeeloqData(ref byte[] downloadBuffer, int wordsWritten)
		{
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DeviceID == 4294967094u)
			{
				for (int num = wordsWritten / 2; num > 0; num--)
				{
					downloadBuffer[num * 4 - 1] = (byte)(~downloadBuffer[num * 2 - 1]);
					downloadBuffer[num * 4 - 2] = (byte)(~downloadBuffer[num * 2 - 2]);
					downloadBuffer[num * 4 - 3] = downloadBuffer[num * 2 - 1];
					downloadBuffer[num * 4 - 4] = downloadBuffer[num * 2 - 2];
				}
				downloadBuffer[0] >>= 1;
			}
		}

		private void blankCheck(object sender, EventArgs e)
		{
			blankCheckDevice();
		}

		private bool blankCheckDevice()
		{
			if (PICkitFunctions.FamilyIsKeeloq() || PICkitFunctions.FamilyIsMCP())
			{
				displayStatusWindow.Text = "Blank Check not supported for this device type.";
				statusWindowColor = Constants.StatusColor.yellow;
				updateGUI(updateMemories: false);
				return false;
			}
			if (!preProgrammingCheck(PICkitFunctions.GetActiveFamily()))
			{
				return false;
			}
			if (PICkitFunctions.FamilyIsPIC32())
			{
				if (PIC32MXFunctions.PIC32BlankCheck())
				{
					statusWindowColor = Constants.StatusColor.green;
					conditionalVDDOff();
					updateGUI(updateMemories: true);
					return true;
				}
				statusWindowColor = Constants.StatusColor.red;
				conditionalVDDOff();
				updateGUI(updateMemories: true);
				return true;
			}
			DeviceData deviceData = new DeviceData(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem, PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem, PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords, PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords, PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue, PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemAddressIncrement, PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].UserIDBytes, PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank, PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[7]);
			int num = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr / (int)PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemHexBytes;
			int configWords = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords;
			if (num < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem)
			{
				for (int i = 0; i < configWords; i++)
				{
					uint num2 = (uint)((int)deviceData.ProgramMemory[num + i] & -65536);
					if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue == 65535)
					{
						num2 |= 0xF000;
					}
					deviceData.ProgramMemory[num + i] = (num2 | PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[i]);
				}
			}
			displayStatusWindow.Text = "Checking if Device is blank:\n";
			Update();
			PICkitFunctions.SetMCLRTemp(nMCLR: true);
			PICkitFunctions.VddOn();
			byte[] array = new byte[128];
			displayStatusWindow.Text += "Program Memory... ";
			Update();
			if (useProgExec33())
			{
				if (!dsPIC33_PE.PE33BlankCheck(displayStatusWindow.Text))
				{
					conditionalVDDOff();
					displayStatusWindow.Text = "Program Memory is not blank.";
					statusWindowColor = Constants.StatusColor.red;
					updateGUI(updateMemories: true);
					return false;
				}
			}
			else if (useProgExec24F())
			{
				if (!PIC24F_PE.PE24FBlankCheck(displayStatusWindow.Text))
				{
					conditionalVDDOff();
					statusWindowColor = Constants.StatusColor.red;
					updateGUI(updateMemories: true);
					return false;
				}
			}
			else
			{
				PICkitFunctions.RunScript(0, 1);
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemAddrSetScript != 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemAddrBytes != 0)
				{
					if (PICkitFunctions.FamilyIsEEPROM())
					{
						PICkitFunctions.DownloadAddress3MSBFirst(eeprom24BitAddress(0, setReadBit: false));
						PICkitFunctions.RunScript(5, 1);
						if (eeprom_CheckBusErrors())
						{
							return false;
						}
					}
					else
					{
						PICkitFunctions.DownloadAddress3(0);
						PICkitFunctions.RunScript(5, 1);
					}
				}
				int bytesPerLocation = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
				int num3 = 128 / (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemRdWords * bytesPerLocation);
				int num4 = num3 * PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemRdWords;
				int num5 = 0;
				progressBar1.Value = 0;
				progressBar1.Maximum = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem / num4;
				do
				{
					if (PICkitFunctions.FamilyIsEEPROM())
					{
						if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 1 && num5 > PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[1] && num5 % (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[1] + 1) == 0)
						{
							PICkitFunctions.DownloadAddress3MSBFirst(eeprom24BitAddress(num5, setReadBit: false));
							PICkitFunctions.RunScript(5, 1);
						}
						PICkitFunctions.Download3Multiples(eeprom24BitAddress(num5, setReadBit: true), num3, PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemRdWords);
					}
					PICkitFunctions.RunScriptUploadNoLen(3, num3);
					Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
					PICkitFunctions.UploadDataNoLen();
					Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
					int num6 = 0;
					for (int j = 0; j < num4; j++)
					{
						int num7 = 0;
						uint num8 = array[num6 + num7++];
						if (num7 < bytesPerLocation)
						{
							num8 = (uint)((int)num8 | (array[num6 + num7++] << 8));
						}
						if (num7 < bytesPerLocation)
						{
							num8 = (uint)((int)num8 | (array[num6 + num7++] << 16));
						}
						if (num7 < bytesPerLocation)
						{
							num8 = (uint)((int)num8 | (array[num6 + num7++] << 24));
						}
						num6 += num7;
						if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
						{
							num8 = ((num8 >> 1) & PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
						}
						if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].OSSCALSave && num5 == PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem - 1)
						{
							num8 = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue;
						}
						if (num8 != deviceData.ProgramMemory[num5++])
						{
							PICkitFunctions.RunScript(1, 1);
							conditionalVDDOff();
							if (PICkitFunctions.FamilyIsEEPROM())
							{
								displayStatusWindow.Text = "EEPROM is not blank starting at address\n";
							}
							else
							{
								displayStatusWindow.Text = "Program Memory is not blank starting at address\n";
							}
							displayStatusWindow.Text += $"0x{--num5 * PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].AddressIncrement:X6}";
							statusWindowColor = Constants.StatusColor.red;
							updateGUI(updateMemories: true);
							return false;
						}
						if (num5 == PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem)
						{
							break;
						}
						if (num5 % 32768 == 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemAddrSetScript != 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemAddrBytes != 0 && PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 65535)
						{
							PICkitFunctions.DownloadAddress3(65536 * (num5 / 32768));
							PICkitFunctions.RunScript(5, 1);
							break;
						}
					}
					progressBar1.PerformStep();
				}
				while (num5 < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem);
				PICkitFunctions.RunScript(1, 1);
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0)
			{
				displayStatusWindow.Text += "EE... ";
				Update();
				PICkitFunctions.RunScript(0, 1);
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EERdPrepScript > 0)
				{
					if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemHexBytes == 4)
					{
						PICkitFunctions.DownloadAddress3((int)(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEAddr / 2u));
					}
					else
					{
						PICkitFunctions.DownloadAddress3(0);
					}
					PICkitFunctions.RunScript(8, 1);
				}
				int eEMemBytesPerWord = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemBytesPerWord;
				uint eEBlank = getEEBlank();
				int num9 = 128 / (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EERdLocations * eEMemBytesPerWord);
				int num10 = num9 * PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EERdLocations;
				int num11 = 0;
				progressBar1.Value = 0;
				progressBar1.Maximum = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem / num10;
				do
				{
					PICkitFunctions.RunScriptUploadNoLen(9, num9);
					Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
					PICkitFunctions.UploadDataNoLen();
					Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
					int num12 = 0;
					for (int k = 0; k < num10; k++)
					{
						int num13 = 0;
						uint num14 = array[num12 + num13++];
						if (num13 < eEMemBytesPerWord)
						{
							num14 = (uint)((int)num14 | (array[num12 + num13++] << 8));
						}
						num12 += num13;
						if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
						{
							num14 = ((num14 >> 1) & eEBlank);
						}
						num11++;
						if (num14 != eEBlank)
						{
							PICkitFunctions.RunScript(1, 1);
							conditionalVDDOff();
							displayStatusWindow.Text = "EE Data Memory is not blank starting at address\n";
							if (eEBlank == 65535)
							{
								displayStatusWindow.Text += $"0x{--num11 * 2:X4}";
							}
							else
							{
								displayStatusWindow.Text += $"0x{--num11:X4}";
							}
							statusWindowColor = Constants.StatusColor.red;
							updateGUI(updateMemories: true);
							return false;
						}
						if (num11 >= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem)
						{
							break;
						}
					}
					progressBar1.PerformStep();
				}
				while (num11 < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem);
				PICkitFunctions.RunScript(1, 1);
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords > 0 && !PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BlankCheckSkipUsrIDs)
			{
				displayStatusWindow.Text += "UserIDs... ";
				Update();
				PICkitFunctions.RunScript(0, 1);
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDRdPrepScript > 0)
				{
					PICkitFunctions.RunScript(16, 1);
				}
				int userIDBytes = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].UserIDBytes;
				int num15 = 0;
				int num16 = 0;
				PICkitFunctions.RunScriptUploadNoLen(17, 1);
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
				if ((long)(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords * userIDBytes) > 64L)
				{
					PICkitFunctions.UploadDataNoLen();
					Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
				}
				PICkitFunctions.RunScript(1, 1);
				do
				{
					int num17 = 0;
					uint num18 = array[num16 + num17++];
					if (num17 < userIDBytes)
					{
						num18 = (uint)((int)num18 | (array[num16 + num17++] << 8));
					}
					if (num17 < userIDBytes)
					{
						num18 = (uint)((int)num18 | (array[num16 + num17++] << 16));
					}
					if (num17 < userIDBytes)
					{
						num18 = (uint)((int)num18 | (array[num16 + num17++] << 24));
					}
					num16 += num17;
					if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
					{
						num18 = ((num18 >> 1) & PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
					}
					num15++;
					uint num19 = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue;
					if (userIDBytes == 1)
					{
						num19 &= 0xFF;
					}
					if (num18 != num19)
					{
						conditionalVDDOff();
						displayStatusWindow.Text = "User IDs are not blank.";
						statusWindowColor = Constants.StatusColor.red;
						updateGUI(updateMemories: true);
						return false;
					}
				}
				while (num15 < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords);
			}
			if (configWords > 0 && num > PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem)
			{
				displayStatusWindow.Text += "Config... ";
				Update();
				PICkitFunctions.RunScript(0, 1);
				PICkitFunctions.RunScript(13, 1);
				PICkitFunctions.UploadData();
				PICkitFunctions.RunScript(1, 1);
				int num20 = 2;
				for (int l = 0; l < configWords; l++)
				{
					uint num21 = PICkitFunctions.Usb_read_array[num20++];
					num21 = (uint)((int)num21 | (PICkitFunctions.Usb_read_array[num20++] << 8));
					if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
					{
						num21 = ((num21 >> 1) & PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
					}
					num21 &= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[l];
					int num22 = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[l] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigBlank[l];
					if (num22 != num21)
					{
						conditionalVDDOff();
						displayStatusWindow.Text = "Configuration is not blank.";
						statusWindowColor = Constants.StatusColor.red;
						updateGUI(updateMemories: true);
						return false;
					}
				}
			}
			PICkitFunctions.RunScript(1, 1);
			conditionalVDDOff();
			statusWindowColor = Constants.StatusColor.green;
			displayStatusWindow.Text = "Device is Blank.";
			updateGUI(updateMemories: true);
			return true;
		}

		private void progMemEdit(object sender, DataGridViewCellEventArgs e)
		{
			int rowIndex = e.RowIndex;
			int columnIndex = e.ColumnIndex;
			string p_value = "0x" + dataGridProgramMemory[columnIndex, rowIndex].FormattedValue.ToString();
			int num = 0;
			try
			{
				num = Utilities.Convert_Value_To_Int(p_value);
			}
			catch
			{
				num = 0;
			}
			int num2 = dataGridProgramMemory.ColumnCount - 1;
			if (comboBoxProgMemView.SelectedIndex >= 1)
			{
				num2 /= 2;
			}
			int num3 = rowIndex * num2 + columnIndex - 1;
			if (PICkitFunctions.FamilyIsPIC32())
			{
				int programMem = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem;
				int bootFlash = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BootFlash;
				programMem -= bootFlash;
				num3 -= num2;
				if (num3 > programMem)
				{
					num3 -= num2;
				}
			}
			PICkitFunctions.DeviceBuffers.ProgramMemory[num3] = (uint)(num & PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
			displayDataSource.Text = "Edited.";
			checkImportFile = false;
			progMemJustEdited = true;
			updateGUI(updateMemories: true);
		}

		private void eEpromEdit(object sender, DataGridViewCellEventArgs e)
		{
			int rowIndex = e.RowIndex;
			int columnIndex = e.ColumnIndex;
			string p_value = "0x" + dataGridViewEEPROM[columnIndex, rowIndex].FormattedValue.ToString();
			int num = 0;
			try
			{
				num = Utilities.Convert_Value_To_Int(p_value);
			}
			catch
			{
				num = 0;
			}
			int num2 = dataGridViewEEPROM.ColumnCount - 1;
			if (comboBoxEE.SelectedIndex >= 1)
			{
				num2 /= 2;
			}
			PICkitFunctions.DeviceBuffers.EEPromMemory[rowIndex * num2 + columnIndex - 1] = (uint)(num & getEEBlank());
			displayDataSource.Text = "Edited.";
			checkImportFile = false;
			eeMemJustEdited = true;
			updateGUI(updateMemories: true);
		}

		private void checkCommunication(object sender, EventArgs e)
		{
			if (detectPICkit2(showFound: true, detectMult: true))
			{
				partialEnableGUIControls();
				lookForPoweredTarget(showMessageBox: false);
				if (!PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].PartDetect)
				{
					setGUIVoltageLimits(setValue: true);
					PICkitFunctions.SetVDDVoltage((float)numUpDnVDD.Value, 0.85f);
					displayStatusWindow.Text += "\n[Parts in this family are not auto-detect.]";
					fullEnableGUIControls();
				}
				else if (PICkitFunctions.DetectDevice(16777215, resetOnNotFound: true, chkBoxVddOn.Checked))
				{
					setGUIVoltageLimits(setValue: true);
					PICkitFunctions.SetVDDVoltage((float)numUpDnVDD.Value, 0.85f);
					displayStatusWindow.Text += "\nPIC Device Found.";
					fullEnableGUIControls();
				}
				displayDataSource.Text = "None (Empty/Erased)";
				checkForPowerErrors();
				updateGUI(updateMemories: true);
			}
		}

		private void verifyDevice(object sender, EventArgs e)
		{
			if (PICkitFunctions.FamilyIsKeeloq())
			{
				displayStatusWindow.Text = "Verify not supported for this device type.";
				statusWindowColor = Constants.StatusColor.yellow;
				updateGUI(updateMemories: false);
			}
			else
			{
				deviceVerify(writeVerify: false, 0, forceEEVerify: false);
			}
		}

		private bool deviceVerify(bool writeVerify, int lastLocation, bool forceEEVerify)
		{
			if (!writeVerify && !preProgrammingCheck(PICkitFunctions.GetActiveFamily()))
			{
				return false;
			}
			if (PICkitFunctions.FamilyIsPIC32())
			{
				if (PIC32MXFunctions.P32Verify(writeVerify, enableCodeProtectToolStripMenuItem.Checked))
				{
					statusWindowColor = Constants.StatusColor.green;
					conditionalVDDOff();
					updateGUI(updateMemories: true);
					return true;
				}
				statusWindowColor = Constants.StatusColor.red;
				conditionalVDDOff();
				updateGUI(updateMemories: true);
				return true;
			}
			displayStatusWindow.Text = "Verifying Device:\n";
			Update();
			if (!PICkitFunctions.FamilyIsKeeloq() && (!writeVerify || !PICkitFunctions.FamilyIsPIC24FJ()))
			{
				PICkitFunctions.SetMCLRTemp(nMCLR: true);
			}
			PICkitFunctions.VddOn();
			byte[] array = new byte[128];
			int configLocation = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr / (int)PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemHexBytes;
			int configWords = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords;
			int num = PICkitFunctions.DeviceBuffers.ProgramMemory.Length - 1;
			if (writeVerify)
			{
				num = lastLocation;
			}
			if (checkBoxProgMemEnabled.Checked)
			{
				displayStatusWindow.Text += "Program Memory... ";
				Update();
				if (useProgExec33())
				{
					if (!dsPIC33_PE.PE33VerifyCRC(displayStatusWindow.Text))
					{
						if (!writeVerify)
						{
							displayStatusWindow.Text = "Verification of Program Memory failed.\n";
						}
						else
						{
							displayStatusWindow.Text = "Programming of Program Memory failed.\n";
						}
						conditionalVDDOff();
						statusWindowColor = Constants.StatusColor.red;
						updateGUI(updateMemories: true);
						return false;
					}
				}
				else if (useProgExec24F())
				{
					if (!PIC24F_PE.PE24FVerify(displayStatusWindow.Text, writeVerify, lastLocation))
					{
						conditionalVDDOff();
						statusWindowColor = Constants.StatusColor.red;
						updateGUI(updateMemories: true);
						return false;
					}
				}
				else
				{
					PICkitFunctions.RunScript(0, 1);
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemAddrSetScript != 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemAddrBytes != 0)
					{
						if (PICkitFunctions.FamilyIsEEPROM())
						{
							PICkitFunctions.DownloadAddress3MSBFirst(eeprom24BitAddress(0, setReadBit: false));
							PICkitFunctions.RunScript(5, 1);
							if (!writeVerify && eeprom_CheckBusErrors())
							{
								return false;
							}
						}
						else
						{
							PICkitFunctions.DownloadAddress3(0);
							PICkitFunctions.RunScript(5, 1);
						}
					}
					int bytesPerLocation = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
					int num2 = 128 / (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemRdWords * bytesPerLocation);
					int num3 = num2 * PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemRdWords;
					int num4 = 0;
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemRdWords == num + 1)
					{
						num2 = 1;
						num3 = num + 1;
					}
					progressBar1.Value = 0;
					progressBar1.Maximum = num / num3;
					do
					{
						if (PICkitFunctions.FamilyIsEEPROM())
						{
							if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 1 && num4 > PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[1] && num4 % (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[1] + 1) == 0)
							{
								PICkitFunctions.DownloadAddress3MSBFirst(eeprom24BitAddress(num4, setReadBit: false));
								PICkitFunctions.RunScript(5, 1);
							}
							PICkitFunctions.Download3Multiples(eeprom24BitAddress(num4, setReadBit: true), num2, PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemRdWords);
						}
						PICkitFunctions.RunScriptUploadNoLen(3, num2);
						Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
						PICkitFunctions.UploadDataNoLen();
						Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
						int num5 = 0;
						for (int i = 0; i < num3; i++)
						{
							int num6 = 0;
							uint num7 = array[num5 + num6++];
							if (num6 < bytesPerLocation)
							{
								num7 = (uint)((int)num7 | (array[num5 + num6++] << 8));
							}
							if (num6 < bytesPerLocation)
							{
								num7 = (uint)((int)num7 | (array[num5 + num6++] << 16));
							}
							if (num6 < bytesPerLocation)
							{
								num7 = (uint)((int)num7 | (array[num5 + num6++] << 24));
							}
							num5 += num6;
							if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
							{
								num7 = ((num7 >> 1) & PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
							}
							if (bytesPerLocation == 2 && PICkitFunctions.FamilyIsEEPROM() && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 3)
							{
								uint num8 = 0u;
								num8 = ((num7 << 8) & 0xFF00);
								num7 >>= 8;
								num7 |= num8;
							}
							if (num7 != PICkitFunctions.DeviceBuffers.ProgramMemory[num4++] && !PICkitFunctions.LearnMode)
							{
								PICkitFunctions.RunScript(1, 1);
								conditionalVDDOff();
								if (!writeVerify)
								{
									if (PICkitFunctions.FamilyIsEEPROM())
									{
										displayStatusWindow.Text = "Verification of EEPROM failed at address\n";
									}
									else
									{
										displayStatusWindow.Text = "Verification of Program Memory failed at address\n";
									}
								}
								else if (PICkitFunctions.FamilyIsEEPROM())
								{
									displayStatusWindow.Text = "Programming failed at EEPROM address\n";
								}
								else
								{
									displayStatusWindow.Text = "Programming failed at Program Memory address\n";
								}
								displayStatusWindow.Text += $"0x{--num4 * PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].AddressIncrement:X6}";
								statusWindowColor = Constants.StatusColor.red;
								updateGUI(updateMemories: true);
								return false;
							}
							if (num4 % 32768 == 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemAddrSetScript != 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemAddrBytes != 0 && PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 65535)
							{
								PICkitFunctions.DownloadAddress3(65536 * (num4 / 32768));
								PICkitFunctions.RunScript(5, 1);
								break;
							}
							if (num4 > num)
							{
								break;
							}
						}
						progressBar1.PerformStep();
					}
					while (num4 < num);
					PICkitFunctions.RunScript(1, 1);
				}
			}
			if ((checkBoxEEMem.Checked || forceEEVerify) && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0)
			{
				if (PICkitFunctions.LearnMode && PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
				{
					PICkitFunctions.MetaCmd_CHANGE_CHKSM_FRMT(2);
				}
				displayStatusWindow.Text += "EE... ";
				Update();
				PICkitFunctions.RunScript(0, 1);
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EERdPrepScript > 0)
				{
					if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemHexBytes == 4)
					{
						PICkitFunctions.DownloadAddress3((int)(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEAddr / 2u));
					}
					else
					{
						PICkitFunctions.DownloadAddress3(0);
					}
					PICkitFunctions.RunScript(8, 1);
				}
				int eEMemBytesPerWord = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemBytesPerWord;
				int num9 = 128 / (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EERdLocations * eEMemBytesPerWord);
				int num10 = num9 * PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EERdLocations;
				int num11 = 0;
				uint eEBlank = getEEBlank();
				progressBar1.Value = 0;
				progressBar1.Maximum = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem / num10;
				do
				{
					PICkitFunctions.RunScriptUploadNoLen(9, num9);
					Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
					PICkitFunctions.UploadDataNoLen();
					Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
					int num12 = 0;
					for (int j = 0; j < num10; j++)
					{
						int num13 = 0;
						uint num14 = array[num12 + num13++];
						if (num13 < eEMemBytesPerWord)
						{
							num14 = (uint)((int)num14 | (array[num12 + num13++] << 8));
						}
						num12 += num13;
						if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
						{
							num14 = ((num14 >> 1) & eEBlank);
						}
						if (num14 != PICkitFunctions.DeviceBuffers.EEPromMemory[num11++] && !PICkitFunctions.LearnMode)
						{
							PICkitFunctions.RunScript(1, 1);
							conditionalVDDOff();
							if (!writeVerify)
							{
								displayStatusWindow.Text = "Verification of EE Data Memory failed at address\n";
							}
							else
							{
								displayStatusWindow.Text = "Programming failed at EE Data address\n";
							}
							if (eEBlank == 65535)
							{
								displayStatusWindow.Text += $"0x{--num11 * 2:X4}";
							}
							else
							{
								displayStatusWindow.Text += $"0x{--num11:X4}";
							}
							statusWindowColor = Constants.StatusColor.red;
							updateGUI(updateMemories: true);
							return false;
						}
						if (num11 >= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem)
						{
							break;
						}
					}
					progressBar1.PerformStep();
				}
				while (num11 < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem);
				PICkitFunctions.RunScript(1, 1);
				if (PICkitFunctions.LearnMode && PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
				{
					PICkitFunctions.MetaCmd_CHANGE_CHKSM_FRMT(1);
				}
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords > 0 && checkBoxProgMemEnabled.Checked)
			{
				displayStatusWindow.Text += "UserIDs... ";
				Update();
				PICkitFunctions.RunScript(0, 1);
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDRdPrepScript > 0)
				{
					PICkitFunctions.RunScript(16, 1);
				}
				int userIDBytes = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].UserIDBytes;
				int num15 = 0;
				int num16 = 0;
				PICkitFunctions.RunScriptUploadNoLen(17, 1);
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
				if ((long)(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords * userIDBytes) > 64L)
				{
					PICkitFunctions.UploadDataNoLen();
					Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
				}
				PICkitFunctions.RunScript(1, 1);
				do
				{
					int num17 = 0;
					uint num18 = array[num16 + num17++];
					if (num17 < userIDBytes)
					{
						num18 = (uint)((int)num18 | (array[num16 + num17++] << 8));
					}
					if (num17 < userIDBytes)
					{
						num18 = (uint)((int)num18 | (array[num16 + num17++] << 16));
					}
					if (num17 < userIDBytes)
					{
						num18 = (uint)((int)num18 | (array[num16 + num17++] << 24));
					}
					num16 += num17;
					if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
					{
						num18 = ((num18 >> 1) & PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
					}
					if (num18 != PICkitFunctions.DeviceBuffers.UserIDs[num15++] && !PICkitFunctions.LearnMode)
					{
						conditionalVDDOff();
						if (!writeVerify)
						{
							displayStatusWindow.Text = "Verification of User IDs failed.";
						}
						else
						{
							displayStatusWindow.Text = "Programming failed at User IDs.";
						}
						statusWindowColor = Constants.StatusColor.red;
						updateGUI(updateMemories: true);
						return false;
					}
				}
				while (num15 < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords);
			}
			if (!writeVerify && !verifyConfig(configWords, configLocation))
			{
				return false;
			}
			PICkitFunctions.RunScript(1, 1);
			if (!writeVerify)
			{
				statusWindowColor = Constants.StatusColor.green;
				displayStatusWindow.Text = "Verification Successful.\n";
				conditionalVDDOff();
			}
			updateGUI(updateMemories: true);
			return true;
		}

		private bool verifyConfig(int configWords, int configLocation)
		{
			if (configWords > 0 && configLocation > PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem && checkBoxProgMemEnabled.Checked)
			{
				displayStatusWindow.Text += "Config... ";
				Update();
				PICkitFunctions.RunScript(0, 1);
				PICkitFunctions.RunScript(13, 1);
				PICkitFunctions.UploadData();
				PICkitFunctions.RunScript(1, 1);
				int num = 2;
				for (int i = 0; i < configWords; i++)
				{
					uint num2 = PICkitFunctions.Usb_read_array[num++];
					num2 = (uint)((int)num2 | (PICkitFunctions.Usb_read_array[num++] << 8));
					if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
					{
						num2 = ((num2 >> 1) & PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
					}
					num2 &= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[i];
					uint num3 = PICkitFunctions.DeviceBuffers.ConfigWords[i] & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[i];
					if (i == PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPConfig - 1)
					{
						if (enableCodeProtectToolStripMenuItem.Enabled && enableCodeProtectToolStripMenuItem.Checked)
						{
							num3 = (uint)((int)num3 & ~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CPMask);
						}
						if (enableDataProtectStripMenuItem.Enabled && enableDataProtectStripMenuItem.Checked)
						{
							num3 = (uint)((int)num3 & ~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DPMask);
						}
					}
					if (num3 != num2 && !PICkitFunctions.LearnMode)
					{
						conditionalVDDOff();
						displayStatusWindow.Text = "Verification of configuration failed.";
						statusWindowColor = Constants.StatusColor.red;
						updateGUI(updateMemories: true);
						return false;
					}
				}
			}
			return true;
		}

		private void downloadPk2Firmware(object sender, EventArgs e)
		{
			if (openFWFile.ShowDialog() == DialogResult.OK)
			{
				downloadNewFirmware();
			}
		}

		private void downloadNewFirmware()
		{
			progressBar1.Value = 0;
			progressBar1.Maximum = 2;
			displayStatusWindow.Text = "Downloading New PICkit 2 Operating System.";
			displayStatusWindow.BackColor = Color.SteelBlue;
			Update();
			if (!Pk2BootLoader.ReadHexAndDownload(openFWFile.FileName, ref pk2number))
			{
				displayStatusWindow.Text = "Downloading failed.\nUse Tools > Check Communications to reconnect.";
				displayStatusWindow.BackColor = Color.Salmon;
				downloadPICkit2FirmwareToolStripMenuItem.Enabled = false;
				chkBoxVddOn.Enabled = false;
				numUpDnVDD.Enabled = false;
				deviceToolStripMenuItem.Enabled = false;
				disableGUIControls();
				return;
			}
			progressBar1.PerformStep();
			displayStatusWindow.Text = "Verifying PICkit 2 Operating System.";
			Update();
			if (!Pk2BootLoader.ReadHexAndVerify(openFWFile.FileName))
			{
				displayStatusWindow.Text = "Operating System verification failed.";
				displayStatusWindow.BackColor = Color.Salmon;
				return;
			}
			if (!PICkitFunctions.BL_WriteFWLoadedKey())
			{
				displayStatusWindow.Text = "Error loading Operating System.";
				displayStatusWindow.BackColor = Color.Salmon;
				return;
			}
			progressBar1.PerformStep();
			displayStatusWindow.Text = "Verification Successful!\nWaiting for PICkit 2 to reset....";
			displayStatusWindow.BackColor = Color.LimeGreen;
			Update();
			PICkitFunctions.BL_Reset();
			Thread.Sleep(5000);
			PICkitFunctions.ResetPk2Number();
			if (detectPICkit2(showFound: true, detectMult: true))
			{
				PICkitFunctions.VddOff();
				lookForPoweredTarget(showMessageBox: false);
				if (PICkitFunctions.DetectDevice(16777215, resetOnNotFound: true, chkBoxVddOn.Checked))
				{
					setGUIVoltageLimits(setValue: true);
					displayStatusWindow.Text += "\nPIC Device Found.";
					fullEnableGUIControls();
				}
				else
				{
					partialEnableGUIControls();
				}
				checkForPowerErrors();
				updateGUI(updateMemories: true);
			}
		}

		private void programmingSpeed(object sender, EventArgs e)
		{
			if (fastProgrammingToolStripMenuItem.Checked)
			{
				PICkitFunctions.SetFastProgramming(fast: true);
				displayStatusWindow.BackColor = SystemColors.Info;
				if (PICkitFunctions.FamilyIsEEPROM())
				{
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 1)
					{
						displayStatusWindow.Text = "Fast programming On- 400kHz I2C\n";
					}
					else if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 4)
					{
						displayStatusWindow.Text = "Fast programming On- FBUS = 100kHz\n";
					}
					else
					{
						displayStatusWindow.Text = "Fast programming On- 925kHz SCK\n";
					}
				}
				else
				{
					displayStatusWindow.Text = "Fast programming On- Programming operations\n";
					displayStatusWindow.Text += "are faster, but less tolerant of loaded ICSP lines.";
				}
				return;
			}
			PICkitFunctions.SetFastProgramming(fast: false);
			displayStatusWindow.BackColor = SystemColors.Info;
			if (PICkitFunctions.FamilyIsEEPROM())
			{
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 1)
				{
					displayStatusWindow.Text = "Fast programming Off - 100kHz I2C\n";
				}
				else if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 4)
				{
					displayStatusWindow.Text = "Fast programming Off- FBUS = 25kHz\n";
				}
				else
				{
					displayStatusWindow.Text = "Fast programming Off - 245kHz SCK\n";
				}
			}
			else
			{
				displayStatusWindow.Text = "Fast programming Off - Programming operations\n";
				displayStatusWindow.Text += "are slower, but more tolerant of loaded ICSP lines.";
			}
		}

		private void clickAbout(object sender, EventArgs e)
		{
			DialogAbout dialogAbout = new DialogAbout();
			dialogAbout.ShowDialog();
		}

		private void launchUsersGuide(object sender, EventArgs e)
		{
			try
			{
				Process.Start(HomeDirectory + "\\PICkit2 User Guide 51553E.pdf");
			}
			catch
			{
				MessageBox.Show("Unable to open User's Guide.");
			}
		}

		private void launchReadMe(object sender, EventArgs e)
		{
			try
			{
				Process.Start(HomeDirectory + "\\PICkit 2 Readme.txt");
			}
			catch
			{
				MessageBox.Show("Unable to open ReadMe file.");
			}
		}

		private void codeProtect(object sender, EventArgs e)
		{
			if (enableDataProtectStripMenuItem.Enabled && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DPMask == 0)
			{
				enableDataProtectStripMenuItem.Checked = enableCodeProtectToolStripMenuItem.Checked;
			}
			updateGUI(updateMemories: true);
		}

		private void dataProtect(object sender, EventArgs e)
		{
			if (enableDataProtectStripMenuItem.Enabled && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DPMask == 0)
			{
				enableCodeProtectToolStripMenuItem.Checked = enableDataProtectStripMenuItem.Checked;
			}
			updateGUI(updateMemories: true);
		}

		private void writeOnButton(object sender, EventArgs e)
		{
			if (writeOnPICkitButtonToolStripMenuItem.Checked)
			{
				timerButton.Enabled = true;
				buttonLast = true;
				displayStatusWindow.Text = "Waiting for PICkit 2 button to be pressed....";
			}
			else
			{
				timerButton.Enabled = false;
			}
		}

		private void timerGoesOff(object sender, EventArgs e)
		{
			if (!PICkitFunctions.ButtonPressed())
			{
				buttonLast = false;
			}
			else if (!buttonLast)
			{
				buttonLast = true;
				deviceWrite();
				checkForPowerErrors();
			}
		}

		private void conditionalVDDOff()
		{
			if (!chkBoxVddOn.Checked)
			{
				PICkitFunctions.VddOff();
			}
		}

		private void buttonReadExport(object sender, EventArgs e)
		{
			if (PICkitFunctions.FamilyIsKeeloq())
			{
				displayStatusWindow.Text = "Read not supported for this device type.";
				statusWindowColor = Constants.StatusColor.yellow;
				updateGUI(updateMemories: false);
			}
			else
			{
				deviceRead();
				updateGUI(updateMemories: true);
				Refresh();
				saveHexFileDialog.ShowDialog();
			}
		}

		private void menuVDDAuto(object sender, EventArgs e)
		{
			vddAuto();
		}

		private void vddAuto()
		{
			autoDetectToolStripMenuItem.Checked = true;
			forcePICkit2ToolStripMenuItem.Checked = false;
			forceTargetToolStripMenuItem.Checked = false;
			lookForPoweredTarget(showMessageBox: false);
		}

		private void menuVDDPk2(object sender, EventArgs e)
		{
			vddPk2();
		}

		private void vddPk2()
		{
			autoDetectToolStripMenuItem.Checked = false;
			forcePICkit2ToolStripMenuItem.Checked = true;
			forceTargetToolStripMenuItem.Checked = false;
			lookForPoweredTarget(showMessageBox: false);
		}

		private void menuVDDTarget(object sender, EventArgs e)
		{
			vddTarget();
		}

		private void vddTarget()
		{
			autoDetectToolStripMenuItem.Checked = false;
			forcePICkit2ToolStripMenuItem.Checked = false;
			forceTargetToolStripMenuItem.Checked = true;
			lookForPoweredTarget(showMessageBox: false);
		}

		private void deviceFamilyClick(object sender, ToolStripItemClickedEventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)e.ClickedItem;
			if (toolStripMenuItem.HasDropDownItems)
			{
				return;
			}
			string text = "";
			labelConfig.Enabled = false;
			text = ((!toolStripMenuItem.OwnerItem.Equals(deviceToolStripMenuItem)) ? (toolStripMenuItem.OwnerItem.Text + "/" + toolStripMenuItem.Text) : toolStripMenuItem.Text);
			int i;
			for (i = 0; i < PICkitFunctions.DevFile.Families.Length && !(text == PICkitFunctions.DevFile.Families[i].FamilyName); i++)
			{
			}
			for (int j = 1; j < PICkitFunctions.DevFile.Info.NumberParts; j++)
			{
				if (PICkitFunctions.DevFile.PartsList[j].Family == i)
				{
					PICkitFunctions.DevFile.PartsList[0].VddMax = PICkitFunctions.DevFile.PartsList[j].VddMax;
					PICkitFunctions.DevFile.PartsList[0].VddMin = PICkitFunctions.DevFile.PartsList[j].VddMin;
					break;
				}
			}
			FamilySelectLogic(i, updateGUI_OK: true);
		}

		private void FamilySelectLogic(int family, bool updateGUI_OK)
		{
			if (family != PICkitFunctions.GetActiveFamily())
			{
				PICkitFunctions.ActivePart = 0;
				setGUIVoltageLimits(setValue: true);
			}
			else
			{
				setGUIVoltageLimits(setValue: false);
			}
			displayStatusWindow.Text = "";
			if (PICkitFunctions.DevFile.Families[family].PartDetect)
			{
				PICkitFunctions.SetActiveFamily(family);
				if (preProgrammingCheck(family))
				{
					displayStatusWindow.Text = PICkitFunctions.DevFile.Families[family].FamilyName + " device found.";
					setGUIVoltageLimits(setValue: false);
				}
				comboBoxSelectPart.Visible = false;
				displayDevice.Visible = true;
				if (updateGUI_OK)
				{
					updateGUI(updateMemories: true);
				}
			}
			else
			{
				buildDeviceSelectDropDown(family);
				comboBoxSelectPart.Visible = true;
				comboBoxSelectPart.SelectedIndex = 0;
				displayDevice.Visible = true;
				PICkitFunctions.SetActiveFamily(family);
				if (updateGUI_OK)
				{
					updateGUI(updateMemories: true);
				}
				disableGUIControls();
			}
			displayDataSource.Text = "None (Empty/Erased)";
		}

		private void buildDeviceSelectDropDown(int family)
		{
			comboBoxSelectPart.Items.Clear();
			comboBoxSelectPart.Items.Add("-Select Part-");
			for (int i = 1; i < PICkitFunctions.DevFile.Info.NumberParts; i++)
			{
				if (PICkitFunctions.DevFile.PartsList[i].Family == family)
				{
					comboBoxSelectPart.Items.Add(PICkitFunctions.DevFile.PartsList[i].PartName);
				}
			}
		}

		private void selectPart(object sender, EventArgs e)
		{
			if (comboBoxSelectPart.SelectedIndex == 0)
			{
				disableGUIControls();
			}
			else
			{
				string b = comboBoxSelectPart.SelectedItem.ToString();
				fullEnableGUIControls();
				for (int i = 0; i < PICkitFunctions.DevFile.Info.NumberParts; i++)
				{
					if (PICkitFunctions.DevFile.PartsList[i].PartName == b)
					{
						PICkitFunctions.ActivePart = i;
						break;
					}
				}
			}
			PICkitFunctions.PrepNewPart(resetBuffers: true);
			setGUIVoltageLimits(setValue: true);
			displayDataSource.Text = "None (Empty/Erased)";
			if (useLVP && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].LVPScript > 0)
			{
				toolStripMenuItemLVPEnabled.Checked = true;
			}
			useLVP = false;
			updateGUI(updateMemories: true);
		}

		private void autoDownloadFW(object sender, EventArgs e)
		{
			timerDLFW.Enabled = false;
			displayStatusWindow.Text = "The PICkit 2 Operating System v" + PICkitFunctions.FirmwareVersion + " must be updated.";
			DialogResult dialogResult = MessageBox.Show("PICkit 2 Operating System must be updated\nbefore it can be used with this software\nversion.\n\nClick OK to download a new Operating System.", "Update Operating System", MessageBoxButtons.OKCancel);
			if (dialogResult == DialogResult.OK)
			{
				openFWFile.FileName = "PK2V023200.hex";
				downloadNewFirmware();
				oldFirmware = false;
			}
			else
			{
				displayStatusWindow.Text = "The PICkit 2 OS v" + PICkitFunctions.FirmwareVersion + " must be updated.\nUse the Tools menu to download a new OS.";
			}
		}

		private void SaveINI()
		{
			StreamWriter streamWriter = File.CreateText(HomeDirectory + "\\PICkit2.ini");
			string value = ";PICkit 2 version 2.61.00 INI file.";
			streamWriter.WriteLine(value);
			DateTime dateTime = default(DateTime);
			dateTime = DateTime.Now;
			value = ";" + dateTime.Date.ToShortDateString() + " " + dateTime.ToShortTimeString();
			streamWriter.WriteLine(value);
			streamWriter.WriteLine("");
			value = "Y";
			if (toolStripMenuItemManualSelect.Checked)
			{
				value = "N";
				searchOnStartup = false;
			}
			else if (!autoDetectInINI)
			{
				searchOnStartup = true;
			}
			streamWriter.WriteLine("ADET: " + value);
			value = "N";
			if (searchOnStartup)
			{
				value = "Y";
			}
			streamWriter.WriteLine("PDET: " + value);
			value = ((PICkitFunctions.DevFile.Families != null) ? PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].FamilyName : lastFamily);
			streamWriter.WriteLine("LFAM: " + value);
			value = "N";
			if (verifyOnWriteToolStripMenuItem.Checked)
			{
				value = "Y";
			}
			streamWriter.WriteLine("VRFW: " + value);
			value = "N";
			if (writeOnPICkitButtonToolStripMenuItem.Checked)
			{
				value = "Y";
			}
			streamWriter.WriteLine("WRBT: " + value);
			value = "N";
			if (MCLRtoolStripMenuItem.Checked)
			{
				value = "Y";
			}
			streamWriter.WriteLine("MCLR: " + value);
			if (VppFirstToolStripMenuItem.Checked)
			{
				restoreVddTarget();
			}
			value = "Auto";
			if (forcePICkit2ToolStripMenuItem.Checked)
			{
				value = "PICkit";
			}
			else if (forceTargetToolStripMenuItem.Checked)
			{
				value = "Target";
			}
			streamWriter.WriteLine("TVDD: " + value);
			value = "N";
			if (fastProgrammingToolStripMenuItem.Checked)
			{
				value = "Y";
			}
			streamWriter.WriteLine("FPRG: " + value);
			value = $"PCLK: {slowSpeedICSP:G}";
			streamWriter.WriteLine(value);
			value = "N";
			if (multiWindow)
			{
				comboBoxProgMemView.SelectedIndex = programMemMultiWin.GetViewMode();
			}
			if (comboBoxProgMemView.SelectedIndex == 1)
			{
				value = "Y";
			}
			else if (comboBoxProgMemView.SelectedIndex == 2)
			{
				value = "B";
			}
			streamWriter.WriteLine("PASC: " + value);
			value = "N";
			if (multiWindow)
			{
				comboBoxProgMemView.SelectedIndex = eepromDataMultiWin.GetViewMode();
			}
			if (comboBoxEE.SelectedIndex == 1)
			{
				value = "Y";
			}
			else if (comboBoxEE.SelectedIndex == 2)
			{
				value = "B";
			}
			streamWriter.WriteLine("EASC: " + value);
			value = "N";
			if (allowDataEdits)
			{
				value = "Y";
			}
			streamWriter.WriteLine("EDIT: " + value);
			if (displayRev.Visible)
			{
				streamWriter.WriteLine("REVS: Y");
			}
			value = $"SETV: {numUpDnVDD.Value:0.0}";
			streamWriter.WriteLine(value);
			value = "N";
			if (toolStripMenuItemClearBuffersErase.Checked)
			{
				value = "Y";
			}
			streamWriter.WriteLine("CLBF: " + value);
			value = "N";
			if (usePE33)
			{
				value = "Y";
			}
			streamWriter.WriteLine("PE33: " + value);
			value = "N";
			if (usePE24)
			{
				value = "Y";
			}
			streamWriter.WriteLine("PE24: " + value);
			value = "0";
			if (as1BitValueToolStripMenuItem.Checked)
			{
				value = "1";
			}
			else if (asReadOrImportedToolStripMenuItem.Checked)
			{
				value = "R";
			}
			streamWriter.WriteLine("CFGU: " + value);
			value = "N";
			if (toolStripMenuItemLVPEnabled.Checked)
			{
				value = "Y";
			}
			streamWriter.WriteLine("LVPE: " + value);
			value = "N";
			if (deviceVerification)
			{
				value = "Y";
			}
			streamWriter.WriteLine("DVER: " + value);
			streamWriter.WriteLine("HEX1: " + hex1);
			streamWriter.WriteLine("HEX2: " + hex2);
			streamWriter.WriteLine("HEX3: " + hex3);
			streamWriter.WriteLine("HEX4: " + hex4);
			if (selectDeviceFile)
			{
				streamWriter.WriteLine("SDAT: Y");
			}
			if (TestMemoryEnabled)
			{
				value = "N";
				if (TestMemoryOpen)
				{
					value = "Y";
				}
				streamWriter.WriteLine("TMEN: " + value);
				value = $"TMWD: {TestMemoryWords:G}";
				streamWriter.WriteLine(value);
				value = "N";
				if (TestMemoryImportExport)
				{
					value = "Y";
				}
				streamWriter.WriteLine("TMIE: " + value);
			}
			value = "N";
			if (multiWindow)
			{
				value = "Y";
			}
			streamWriter.WriteLine("MWEN: " + value);
			value = $"MWLX: {base.Location.X:G}";
			streamWriter.WriteLine(value);
			value = $"MWLY: {base.Location.Y:G}";
			streamWriter.WriteLine(value);
			value = "N";
			if (mainWinOwnsMem)
			{
				value = "Y";
			}
			streamWriter.WriteLine("MWFR: " + value);
			value = "N";
			if (multiWinPMemOpen)
			{
				value = "Y";
			}
			streamWriter.WriteLine("PMEN: " + value);
			value = $"PMLX: {programMemMultiWin.Location.X:G}";
			streamWriter.WriteLine(value);
			value = $"PMLY: {programMemMultiWin.Location.Y:G}";
			streamWriter.WriteLine(value);
			value = $"PMSX: {programMemMultiWin.Size.Width:G}";
			streamWriter.WriteLine(value);
			value = $"PMSY: {programMemMultiWin.Size.Height:G}";
			streamWriter.WriteLine(value);
			value = "N";
			if (multiWinEEMemOpen)
			{
				value = "Y";
			}
			streamWriter.WriteLine("EEEN: " + value);
			value = $"EELX: {eepromDataMultiWin.Location.X:G}";
			streamWriter.WriteLine(value);
			value = $"EELY: {eepromDataMultiWin.Location.Y:G}";
			streamWriter.WriteLine(value);
			value = $"EESX: {eepromDataMultiWin.Size.Width:G}";
			streamWriter.WriteLine(value);
			value = $"EESY: {eepromDataMultiWin.Size.Height:G}";
			streamWriter.WriteLine(value);
			streamWriter.WriteLine("UABD: " + uartWindow.GetBaudRate());
			value = "N";
			if (uartWindow.IsHexMode())
			{
				value = "Y";
			}
			streamWriter.WriteLine("UAHX: " + value);
			streamWriter.WriteLine("UAS1: " + uartWindow.GetStringMacro(1));
			streamWriter.WriteLine("UAS2: " + uartWindow.GetStringMacro(2));
			streamWriter.WriteLine("UAS3: " + uartWindow.GetStringMacro(3));
			streamWriter.WriteLine("UAS4: " + uartWindow.GetStringMacro(4));
			value = "N";
			if (uartWindow.GetAppendCRLF())
			{
				value = "Y";
			}
			streamWriter.WriteLine("UACL: " + value);
			value = "N";
			if (uartWindow.GetWrap())
			{
				value = "Y";
			}
			streamWriter.WriteLine("UAWR: " + value);
			value = "N";
			if (uartWindow.GetEcho())
			{
				value = "Y";
			}
			streamWriter.WriteLine("UAEC: " + value);
			value = "N";
			if (logicWindow.getModeAnalyzer())
			{
				value = "Y";
			}
			streamWriter.WriteLine("LTAM: " + value);
			value = $"LTZM: {logicWindow.getZoom():G}";
			streamWriter.WriteLine(value);
			value = $"LTT1: {logicWindow.getCh1Trigger():G}";
			streamWriter.WriteLine(value);
			value = $"LTT2: {logicWindow.getCh2Trigger():G}";
			streamWriter.WriteLine(value);
			value = $"LTT3: {logicWindow.getCh3Trigger():G}";
			streamWriter.WriteLine(value);
			value = $"LTTC: {logicWindow.getTrigCount():G}";
			streamWriter.WriteLine(value);
			value = $"LTSR: {logicWindow.getSampleRate():G}";
			streamWriter.WriteLine(value);
			value = $"LTTP: {logicWindow.getTriggerPosition():G}";
			streamWriter.WriteLine(value);
			value = "N";
			if (logicWindow.getCursorsEnabled())
			{
				value = "Y";
			}
			streamWriter.WriteLine("LTCE: " + value);
			value = $"LTCX: {logicWindow.getXCursorPos():G}";
			streamWriter.WriteLine(value);
			value = $"LTCY: {logicWindow.getYCursorPos():G}";
			streamWriter.WriteLine(value);
			value = "0";
			if (ptgMemory > 0 && ptgMemory <= 5)
			{
				if (ptgMemory == 1)
				{
					value = "1";
				}
				else if (ptgMemory == 2)
				{
					value = "2";
				}
				else if (ptgMemory == 3)
				{
					value = "3";
				}
				else if (ptgMemory == 4)
				{
					value = "4";
				}
				else if (ptgMemory == 5)
				{
					value = "5";
				}
			}
			streamWriter.WriteLine("PTGM: " + value);
			value = "N";
			if (PlaySuccessWav)
			{
				value = "Y";
			}
			streamWriter.WriteLine("SDSP: " + value);
			value = "N";
			if (PlayWarningWav)
			{
				value = "Y";
			}
			streamWriter.WriteLine("SDWP: " + value);
			value = "N";
			if (PlayErrorWav)
			{
				value = "Y";
			}
			streamWriter.WriteLine("SDEP: " + value);
			streamWriter.WriteLine("SDSF: " + SuccessWavFile);
			streamWriter.WriteLine("SDWF: " + WarningWavFile);
			streamWriter.WriteLine("SDEF: " + ErrorWavFile);
			streamWriter.Flush();
			streamWriter.Close();
		}

		private float loadINI()
		{
			float num = 0f;
			int num2 = 0;
			try
			{
				int height = SystemInformation.VirtualScreen.Height;
				int width = SystemInformation.VirtualScreen.Width;
				FileInfo fileInfo = new FileInfo("PICkit2.ini");
				HomeDirectory = fileInfo.DirectoryName;
				SuccessWavFile = HomeDirectory + SuccessWavFile;
				WarningWavFile = HomeDirectory + WarningWavFile;
				ErrorWavFile = HomeDirectory + ErrorWavFile;
				TextReader textReader = fileInfo.OpenText();
				for (string text = textReader.ReadLine(); text != null; text = textReader.ReadLine())
				{
					if (text != "" && string.Compare(text.Substring(0, 1), ";") != 0 && string.Compare(text.Substring(0, 1), " ") != 0)
					{
						switch (text.Substring(0, 5))
						{
						case "ADET:":
							if (string.Compare(text.Substring(6, 1), "N") == 0)
							{
								toolStripMenuItemManualSelect.Checked = true;
								autoDetectInINI = false;
								searchOnStartup = false;
							}
							break;
						case "PDET:":
							if (string.Compare(text.Substring(6, 1), "N") == 0)
							{
								searchOnStartup = false;
							}
							break;
						case "LFAM:":
							lastFamily = text.Substring(6);
							break;
						case "VRFW:":
							if (string.Compare(text.Substring(6, 1), "N") == 0)
							{
								verifyOnWriteToolStripMenuItem.Checked = false;
							}
							break;
						case "WRBT:":
							if (string.Compare(text.Substring(6, 1), "Y") == 0)
							{
								writeOnPICkitButtonToolStripMenuItem.Checked = true;
								timerButton.Enabled = true;
								buttonLast = true;
							}
							break;
						case "MCLR:":
							if (string.Compare(text.Substring(6, 1), "Y") == 0)
							{
								MCLRtoolStripMenuItem.Checked = true;
								checkBoxMCLR.Checked = true;
								PICkitFunctions.HoldMCLR(nMCLR: true);
							}
							break;
						case "TVDD:":
							if (string.Compare(text.Substring(6, 1), "P") == 0)
							{
								vddPk2();
							}
							else if (string.Compare(text.Substring(6, 1), "T") == 0)
							{
								vddTarget();
							}
							break;
						case "FPRG:":
							if (string.Compare(text.Substring(6, 1), "N") == 0)
							{
								fastProgrammingToolStripMenuItem.Checked = false;
								PICkitFunctions.SetFastProgramming(fast: false);
							}
							break;
						case "PCLK:":
							if (text.Length == 7)
							{
								slowSpeedICSP = byte.Parse(text.Substring(6, 1));
							}
							else
							{
								slowSpeedICSP = byte.Parse(text.Substring(6, 2));
							}
							if (slowSpeedICSP < 2)
							{
								slowSpeedICSP = 2;
							}
							if (slowSpeedICSP > 16)
							{
								slowSpeedICSP = 16;
							}
							break;
						case "PASC:":
							if (string.Compare(text.Substring(6, 1), "Y") == 0)
							{
								comboBoxProgMemView.SelectedIndex = 1;
							}
							else if (string.Compare(text.Substring(6, 1), "B") == 0)
							{
								comboBoxProgMemView.SelectedIndex = 2;
							}
							break;
						case "EASC:":
							if (string.Compare(text.Substring(6, 1), "Y") == 0)
							{
								comboBoxEE.SelectedIndex = 1;
							}
							else if (string.Compare(text.Substring(6, 1), "B") == 0)
							{
								comboBoxEE.SelectedIndex = 2;
							}
							break;
						case "EDIT:":
							if (string.Compare(text.Substring(6, 1), "N") == 0)
							{
								allowDataEdits = false;
								calibrateToolStripMenuItem.Visible = false;
							}
							break;
						case "REVS:":
							displayRev.Visible = true;
							break;
						case "SETV:":
							if (text.Length == 9)
							{
								num = float.Parse(text.Substring(6, 3));
								if (num > 5f)
								{
									num = 5f;
								}
								if ((double)num < 2.5)
								{
									num = 2.5f;
								}
							}
							else
							{
								num = 0f;
							}
							break;
						case "CLBF:":
							if (string.Compare(text.Substring(6, 1), "N") == 0)
							{
								toolStripMenuItemClearBuffersErase.Checked = false;
							}
							break;
						case "PE33:":
							if (string.Compare(text.Substring(6, 1), "N") == 0)
							{
								usePE33 = false;
							}
							break;
						case "PE24:":
							if (string.Compare(text.Substring(6, 1), "N") == 0)
							{
								usePE24 = false;
							}
							break;
						case "CFGU:":
							if (string.Compare(text.Substring(6, 1), "1") == 0)
							{
								as0BitValueToolStripMenuItem.Checked = false;
								as1BitValueToolStripMenuItem.Checked = true;
							}
							else if (string.Compare(text.Substring(6, 1), "R") == 0)
							{
								as0BitValueToolStripMenuItem.Checked = false;
								asReadOrImportedToolStripMenuItem.Checked = true;
							}
							break;
						case "LVPE:":
							if (string.Compare(text.Substring(6, 1), "Y") == 0)
							{
								useLVP = true;
							}
							break;
						case "DVER:":
							if (string.Compare(text.Substring(6, 1), "N") == 0)
							{
								deviceVerification = false;
							}
							break;
						case "HEX1:":
							hex1 = text.Substring(6);
							if (hex1.Length > 3)
							{
								hex1ToolStripMenuItem.Visible = true;
								toolStripMenuItem5.Visible = true;
							}
							break;
						case "HEX2:":
							hex2 = text.Substring(6);
							if (hex2.Length > 3)
							{
								hex2ToolStripMenuItem.Visible = true;
							}
							break;
						case "HEX3:":
							hex3 = text.Substring(6);
							if (hex3.Length > 3)
							{
								hex3ToolStripMenuItem.Visible = true;
							}
							break;
						case "HEX4:":
							hex4 = text.Substring(6);
							if (hex4.Length > 3)
							{
								hex4ToolStripMenuItem.Visible = true;
							}
							break;
						case "SDAT:":
							if (string.Compare(text.Substring(6, 1), "Y") == 0)
							{
								selectDeviceFile = true;
							}
							break;
						case "TMEN:":
							TestMemoryEnabled = true;
							if (text.Length > 5 && string.Compare(text.Substring(6, 1), "Y") == 0)
							{
								TestMemoryOpen = true;
							}
							break;
						case "TMWD:":
							TestMemoryWords = int.Parse(text.Substring(6, text.Length - 6));
							if (TestMemoryWords < 16)
							{
								TestMemoryWords = 16;
							}
							if (TestMemoryWords > 1024)
							{
								TestMemoryWords = 1024;
							}
							break;
						case "TMIE:":
							if (string.Compare(text.Substring(6, 1), "Y") == 0)
							{
								TestMemoryImportExport = true;
							}
							break;
						case "MWEN:":
							if (string.Compare(text.Substring(6, 1), "Y") == 0)
							{
								multiWindow = true;
								viewChanged = true;
							}
							break;
						case "MWLX:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 < 0)
							{
								num2 = 0;
							}
							if (num2 > width)
							{
								num2 = width - 75;
							}
							base.Location = new Point(num2, base.Location.Y);
							break;
						case "MWLY:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 < 0)
							{
								num2 = 0;
							}
							if (num2 > height)
							{
								num2 = height - 75;
							}
							base.Location = new Point(base.Location.X, num2);
							break;
						case "MWFR:":
							if (string.Compare(text.Substring(6, 1), "N") == 0)
							{
								mainWinOwnsMem = false;
							}
							break;
						case "PMEN:":
							if (string.Compare(text.Substring(6, 1), "N") == 0)
							{
								multiWinPMemOpen = false;
							}
							break;
						case "PMLX:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 < 0)
							{
								num2 = 0;
							}
							if (num2 > width)
							{
								num2 = width - 75;
							}
							programMemMultiWin.Location = new Point(num2, programMemMultiWin.Location.Y);
							break;
						case "PMLY:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 < 0)
							{
								num2 = 0;
							}
							if (num2 > height)
							{
								num2 = height - 75;
							}
							programMemMultiWin.Location = new Point(programMemMultiWin.Location.X, num2);
							break;
						case "PMSX:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 < 50)
							{
								num2 = 50;
							}
							if (num2 > width)
							{
								num2 = width;
							}
							programMemMultiWin.Size = new Size(num2, programMemMultiWin.Size.Height);
							break;
						case "PMSY:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 < 50)
							{
								num2 = 50;
							}
							if (num2 > height)
							{
								num2 = height;
							}
							programMemMultiWin.Size = new Size(programMemMultiWin.Size.Width, num2);
							break;
						case "EEEN:":
							if (string.Compare(text.Substring(6, 1), "N") == 0)
							{
								multiWinEEMemOpen = false;
							}
							break;
						case "EELX:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 < 0)
							{
								num2 = 0;
							}
							if (num2 > width)
							{
								num2 = width - 75;
							}
							eepromDataMultiWin.Location = new Point(num2, eepromDataMultiWin.Location.Y);
							break;
						case "EELY:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 < 0)
							{
								num2 = 0;
							}
							if (num2 > height)
							{
								num2 = height - 75;
							}
							eepromDataMultiWin.Location = new Point(eepromDataMultiWin.Location.X, num2);
							break;
						case "EESX:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 < 50)
							{
								num2 = 50;
							}
							if (num2 > width)
							{
								num2 = width;
							}
							eepromDataMultiWin.Size = new Size(num2, eepromDataMultiWin.Size.Height);
							break;
						case "EESY:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 < 50)
							{
								num2 = 50;
							}
							if (num2 > height)
							{
								num2 = height;
							}
							eepromDataMultiWin.Size = new Size(eepromDataMultiWin.Size.Width, num2);
							break;
						case "UABD:":
							uartWindow.SetBaudRate(text.Substring(6));
							break;
						case "UAHX:":
							if (string.Compare(text.Substring(6, 1), "Y") == 0)
							{
								uartWindow.SetModeHex();
							}
							break;
						case "UAS1:":
							uartWindow.SetStringMacro(text.Substring(6), 1);
							break;
						case "UAS2:":
							uartWindow.SetStringMacro(text.Substring(6), 2);
							break;
						case "UAS3:":
							uartWindow.SetStringMacro(text.Substring(6), 3);
							break;
						case "UAS4:":
							uartWindow.SetStringMacro(text.Substring(6), 4);
							break;
						case "UACL:":
							if (string.Compare(text.Substring(6, 1), "N") == 0)
							{
								uartWindow.ClearAppendCRLF();
							}
							break;
						case "UAWR:":
							if (string.Compare(text.Substring(6, 1), "N") == 0)
							{
								uartWindow.ClearWrap();
							}
							break;
						case "UAEC:":
							if (string.Compare(text.Substring(6, 1), "N") == 0)
							{
								uartWindow.ClearEcho();
							}
							break;
						case "LTAM:":
							if (string.Compare(text.Substring(6, 1), "Y") == 0)
							{
								logicWindow.setModeAnalyzer();
							}
							break;
						case "LTZM:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 > 3)
							{
								num2 = 3;
							}
							logicWindow.setZoom(num2);
							break;
						case "LTT1:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 > 5)
							{
								num2 = 5;
							}
							logicWindow.setCh1Trigger(num2);
							break;
						case "LTT2:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 > 5)
							{
								num2 = 5;
							}
							logicWindow.setCh2Trigger(num2);
							break;
						case "LTT3:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 > 5)
							{
								num2 = 5;
							}
							logicWindow.setCh3Trigger(num2);
							break;
						case "LTTC:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 > 256)
							{
								num2 = 256;
							}
							if (num2 < 1)
							{
								num2 = 1;
							}
							logicWindow.setTrigCount(num2);
							break;
						case "LTSR:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 > 7)
							{
								num2 = 7;
							}
							logicWindow.setSampleRate(num2);
							break;
						case "LTTP:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 > 5)
							{
								num2 = 5;
							}
							logicWindow.setTriggerPosition(num2);
							break;
						case "LTCE:":
							if (string.Compare(text.Substring(6, 1), "Y") == 0)
							{
								logicWindow.setCursorsEnabled(enable: true);
							}
							break;
						case "LTCX:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 > 4095)
							{
								num2 = 4095;
							}
							logicWindow.setXCursorPos(num2);
							break;
						case "LTCY:":
							num2 = int.Parse(text.Substring(6, text.Length - 6));
							if (num2 > 4095)
							{
								num2 = 4095;
							}
							logicWindow.setYCursorPos(num2);
							break;
						case "PTGM:":
							if (string.Compare(text.Substring(6, 1), "1") == 0)
							{
								ptgMemory = 1;
							}
							else if (string.Compare(text.Substring(6, 1), "2") == 0)
							{
								ptgMemory = 2;
							}
							else if (string.Compare(text.Substring(6, 1), "3") == 0)
							{
								ptgMemory = 3;
							}
							else if (string.Compare(text.Substring(6, 1), "4") == 0)
							{
								ptgMemory = 4;
							}
							else if (string.Compare(text.Substring(6, 1), "5") == 0)
							{
								ptgMemory = 5;
							}
							break;
						case "SDSP:":
							if (string.Compare(text.Substring(6, 1), "Y") == 0)
							{
								PlaySuccessWav = true;
							}
							break;
						case "SDWP:":
							if (string.Compare(text.Substring(6, 1), "Y") == 0)
							{
								PlayWarningWav = true;
							}
							break;
						case "SDEP:":
							if (string.Compare(text.Substring(6, 1), "Y") == 0)
							{
								PlayErrorWav = true;
							}
							break;
						case "SDSF:":
							SuccessWavFile = text.Substring(6);
							break;
						case "SDWF:":
							WarningWavFile = text.Substring(6);
							break;
						case "SDEF:":
							ErrorWavFile = text.Substring(6);
							break;
						}
					}
				}
				textReader.Close();
			}
			catch
			{
				return 0f;
			}
			hex1ToolStripMenuItem.Text = "&1 " + shortenHex(hex1);
			hex2ToolStripMenuItem.Text = "&2 " + shortenHex(hex2);
			hex3ToolStripMenuItem.Text = "&3 " + shortenHex(hex3);
			hex4ToolStripMenuItem.Text = "&4 " + shortenHex(hex4);
			return num;
		}

		private string shortenHex(string fullPath)
		{
			if (fullPath.Length > 42)
			{
				return fullPath.Substring(0, 3) + "..." + fullPath.Substring(fullPath.Length - 36);
			}
			return fullPath;
		}

		private void hex1Click(object sender, EventArgs e)
		{
			hexImportFromHistory(hex1);
		}

		private void hex2Click(object sender, EventArgs e)
		{
			hexImportFromHistory(hex2);
		}

		private void hex3Click(object sender, EventArgs e)
		{
			hexImportFromHistory(hex3);
		}

		private void hex4Click(object sender, EventArgs e)
		{
			hexImportFromHistory(hex4);
		}

		private void hexImportFromHistory(string filename)
		{
			if (importFileToolStripMenuItem.Enabled && filename.Length > 3)
			{
				openHexFileDialog.FileName = filename;
				importHexFileGo();
				updateGUI(updateMemories: true);
			}
		}

		private void launchLPCDemoGuide(object sender, EventArgs e)
		{
			try
			{
				Process.Start(HomeDirectory + "\\Low Pin Count User Guide 51556a.pdf");
			}
			catch
			{
				MessageBox.Show("Unable to open\nLPC Demo Board User's Guide.");
			}
		}

		private void uG44pinToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start(HomeDirectory + "\\44-Pin Demo Board User Guide 41296b.pdf");
			}
			catch
			{
				MessageBox.Show("Unable to open\n44-Pin Demo Board User's Guide.");
			}
		}

		private void memorySelectVerify(object sender, EventArgs e)
		{
			if (sender.Equals(checkBoxProgMemEnabled))
			{
				checkBoxProgMemEnabledAlt.Checked = checkBoxProgMemEnabled.Checked;
			}
			if (sender.Equals(checkBoxProgMemEnabledAlt))
			{
				checkBoxProgMemEnabled.Checked = checkBoxProgMemEnabledAlt.Checked;
			}
			if (sender.Equals(checkBoxEEMem))
			{
				checkBoxEEDATAMemoryEnabledAlt.Checked = checkBoxEEMem.Checked;
			}
			if (sender.Equals(checkBoxEEDATAMemoryEnabledAlt))
			{
				checkBoxEEMem.Checked = checkBoxEEDATAMemoryEnabledAlt.Checked;
			}
			if (!checkBoxProgMemEnabled.Checked && !checkBoxEEMem.Checked)
			{
				MessageBox.Show("At least one memory region\nmust be selected.");
				if (sender.Equals(checkBoxProgMemEnabled) || sender.Equals(checkBoxProgMemEnabledAlt))
				{
					checkBoxProgMemEnabled.Checked = true;
					checkBoxProgMemEnabledAlt.Checked = true;
				}
				else
				{
					checkBoxEEMem.Checked = true;
					checkBoxEEDATAMemoryEnabledAlt.Checked = true;
				}
			}
			updateGUI(updateMemories: false);
		}

		private void setOSCCAL(object sender, EventArgs e)
		{
			if (setOSCCALToolStripMenuItem.Enabled)
			{
				SetOSCCAL setOSCCAL = new SetOSCCAL();
				setOSCCAL.ShowDialog();
				if (setOSCCALValue)
				{
					eraseDeviceAll(forceOSSCAL: true, new uint[0]);
					displayStatusWindow.Text += "\nOSCCAL Set.";
				}
				setOSCCALValue = false;
				updateGUI(updateMemories: true);
			}
		}

		private void pickit2OnTheWeb(object sender, EventArgs e)
		{
			try
			{
				Process.Start("http://www.microchip.com/pickit2");
			}
			catch
			{
				MessageBox.Show("Unable to open link.");
			}
		}

		private void troubleshhotToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogTroubleshoot dialogTroubleshoot = new DialogTroubleshoot();
			dialogTroubleshoot.ShowDialog();
			chkBoxVddOn.Checked = false;
			if (selfPoweredTarget)
			{
				PICkitFunctions.ForceTargetPowered();
			}
		}

		private void MCLRtoolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (MCLRtoolStripMenuItem.Checked)
			{
				checkBoxMCLR.Checked = false;
				MCLRtoolStripMenuItem.Checked = false;
				PICkitFunctions.HoldMCLR(nMCLR: false);
			}
			else
			{
				checkBoxMCLR.Checked = true;
				MCLRtoolStripMenuItem.Checked = true;
				PICkitFunctions.HoldMCLR(nMCLR: true);
			}
		}

		private void toolStripMenuItemTestMemory_Click(object sender, EventArgs e)
		{
			if (TestMemoryEnabled && !TestMemoryOpen)
			{
				openTestMemory();
			}
		}

		private void openTestMemory()
		{
			formTestMem = new FormTestMemory();
			formTestMem.UpdateMainFormGUI = ExtCallUpdateGUI;
			formTestMem.CallMainFormEraseWrCal = ExtCallCalEraseWrite;
			formTestMem.Show();
		}

		private void buttonImportWrite(object sender, EventArgs e)
		{
		}

		private void checkBoxAutoImportWrite_Click(object sender, EventArgs e)
		{
			if (!checkBoxAutoImportWrite.Checked)
			{
				displayStatusWindow.Text = "Exited Auto-Import-Write mode.";
			}
			if (!checkBoxAutoImportWrite.Checked)
			{
				return;
			}
			importGo = false;
			if (hex1.Length > 3)
			{
				openHexFileDialog.FileName = hex1;
			}
			openHexFileDialog.ShowDialog();
			if (importGo)
			{
				updateGUI(updateMemories: true);
				Refresh();
				if (deviceWrite())
				{
					importFileToolStripMenuItem.Enabled = false;
					exportFileToolStripMenuItem.Enabled = false;
					readDeviceToolStripMenuItem.Enabled = false;
					writeDeviceToolStripMenuItem.Enabled = false;
					verifyToolStripMenuItem.Enabled = false;
					eraseToolStripMenuItem.Enabled = false;
					blankCheckToolStripMenuItem.Enabled = false;
					writeOnPICkitButtonToolStripMenuItem.Enabled = false;
					pICkit2GoToolStripMenuItem.Enabled = false;
					setOSCCALToolStripMenuItem.Enabled = false;
					buttonRead.Enabled = false;
					buttonWrite.Enabled = false;
					buttonVerify.Enabled = false;
					buttonErase.Enabled = false;
					buttonBlankCheck.Enabled = false;
					dataGridProgramMemory.Enabled = false;
					dataGridViewEEPROM.Enabled = false;
					buttonExportHex.Enabled = false;
					deviceToolStripMenuItem.Enabled = false;
					checkCommunicationToolStripMenuItem.Enabled = false;
					troubleshhotToolStripMenuItem.Enabled = false;
					downloadPICkit2FirmwareToolStripMenuItem.Enabled = false;
					displayStatusWindow.Text += "Waiting for file update...  (Click button again to exit)";
					timerAutoImportWrite.Enabled = true;
				}
				else
				{
					importGo = false;
				}
			}
			else
			{
				updateGUI(updateMemories: true);
			}
			if (!importGo)
			{
				checkBoxAutoImportWrite.Checked = false;
			}
		}

		private void checkBoxAutoImportWrite_Changed(object sender, EventArgs e)
		{
			if (!checkBoxAutoImportWrite.Checked || !importGo)
			{
				importFileToolStripMenuItem.Enabled = true;
				exportFileToolStripMenuItem.Enabled = true;
				readDeviceToolStripMenuItem.Enabled = true;
				writeDeviceToolStripMenuItem.Enabled = true;
				verifyToolStripMenuItem.Enabled = true;
				eraseToolStripMenuItem.Enabled = true;
				blankCheckToolStripMenuItem.Enabled = true;
				writeOnPICkitButtonToolStripMenuItem.Enabled = true;
				pICkit2GoToolStripMenuItem.Enabled = true;
				setOSCCALToolStripMenuItem.Enabled = true;
				buttonRead.Enabled = true;
				buttonWrite.Enabled = true;
				buttonVerify.Enabled = true;
				buttonErase.Enabled = true;
				buttonBlankCheck.Enabled = true;
				dataGridProgramMemory.Enabled = true;
				dataGridViewEEPROM.Enabled = true;
				buttonExportHex.Enabled = true;
				deviceToolStripMenuItem.Enabled = true;
				checkCommunicationToolStripMenuItem.Enabled = true;
				troubleshhotToolStripMenuItem.Enabled = true;
				downloadPICkit2FirmwareToolStripMenuItem.Enabled = true;
				timerAutoImportWrite.Enabled = false;
				FLASHWINFO pwfi = default(FLASHWINFO);
				pwfi.cbSize = (ushort)Marshal.SizeOf(pwfi);
				pwfi.hwnd = base.Handle;
				pwfi.dwFlags = 14u;
				pwfi.uCount = ushort.MaxValue;
				pwfi.dwTimeout = 0u;
				FlashWindowEx(ref pwfi);
				if (base.WindowState == FormWindowState.Minimized)
				{
					base.WindowState = FormWindowState.Normal;
				}
			}
		}

		private void timerAutoImportWrite_Tick(object sender, EventArgs e)
		{
			FileInfo fileInfo = new FileInfo(openHexFileDialog.FileName);
			if (ImportExportHex.LastWriteTime != fileInfo.LastWriteTime)
			{
				if (deviceWrite())
				{
					importFileToolStripMenuItem.Enabled = false;
					exportFileToolStripMenuItem.Enabled = false;
					readDeviceToolStripMenuItem.Enabled = false;
					writeDeviceToolStripMenuItem.Enabled = false;
					verifyToolStripMenuItem.Enabled = false;
					eraseToolStripMenuItem.Enabled = false;
					blankCheckToolStripMenuItem.Enabled = false;
					writeOnPICkitButtonToolStripMenuItem.Enabled = false;
					pICkit2GoToolStripMenuItem.Enabled = false;
					setOSCCALToolStripMenuItem.Enabled = false;
					buttonRead.Enabled = false;
					buttonWrite.Enabled = false;
					buttonVerify.Enabled = false;
					buttonErase.Enabled = false;
					buttonBlankCheck.Enabled = false;
					dataGridProgramMemory.Enabled = false;
					dataGridViewEEPROM.Enabled = false;
					buttonExportHex.Enabled = false;
					deviceToolStripMenuItem.Enabled = false;
					checkCommunicationToolStripMenuItem.Enabled = false;
					troubleshhotToolStripMenuItem.Enabled = false;
					downloadPICkit2FirmwareToolStripMenuItem.Enabled = false;
					displayStatusWindow.Text += "Waiting for file update...  (Click button again to exit)";
				}
				else
				{
					timerAutoImportWrite.Enabled = false;
					checkBoxAutoImportWrite.Checked = false;
				}
			}
		}

		private bool checkForTest()
		{
			string path = "Pk2Test.dll";
			if (TestMemoryEnabled)
			{
				return File.Exists(path);
			}
			return false;
		}

		private bool testMenuBuild()
		{
			try
			{
				string[] menus = MAN.GetMenus();
				testToolStripMenuItem.Text = "Test " + menus[menus.Length - 1];
				for (int i = 0; i < menus.Length - 1; i++)
				{
					testToolStripMenuItem.DropDown.Items.Add(menus[i]);
				}
				MAN.UpdateMainFormGUI = ExtCallUpdateGUI;
				MAN.VerifyInMainForm = ExtCallVerify;
				MAN.WriteInMainForm = ExtCallWrite;
				MAN.ReadInMainForm = ExtCallRead;
				MAN.EraseInMainForm = ExtCallErase;
				MAN.BlankCheckInMainForm = ExtCallBlank;
				testToolStripMenuItem.Visible = true;
				return true;
			}
			catch
			{
				MessageBox.Show("Error Connecting to\nPk2Test.dll 001", "PICkit 2 Error");
				return false;
			}
		}

		private void testMenuDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			int num = testToolStripMenuItem.DropDown.Items.IndexOf(e.ClickedItem);
			try
			{
				MAN.CallTestForms(num);
			}
			catch
			{
				MessageBox.Show("Error Connecting to\nPk2Test.dll 002", "PICkit 2 Error");
			}
		}

		private void buttonShowIDMem_Click(object sender, EventArgs e)
		{
			if (!DialogUserIDs.IDMemOpen)
			{
				dialogIDMemory = new DialogUserIDs();
				dialogIDMemory.Show();
			}
		}

		private uint getEEBlank()
		{
			uint result = 255u;
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemAddressIncrement > 1)
			{
				result = 65535u;
			}
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue == 4095)
			{
				result = 4095u;
			}
			return result;
		}

		private void restoreVddTarget()
		{
			if (VddTargetSave == Constants.VddTargetSelect.auto)
			{
				vddAuto();
			}
			else if (VddTargetSave == Constants.VddTargetSelect.pickit2)
			{
				vddPk2();
			}
			else
			{
				vddTarget();
			}
		}

		private void VppFirstToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (VppFirstToolStripMenuItem.Checked)
			{
				if (toolStripMenuItemLVPEnabled.Checked)
				{
					string scriptName = PICkitFunctions.DevFile.Scripts[PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].LVPScript - 1].ScriptName;
					scriptName = scriptName.Substring(scriptName.Length - 2);
					if (scriptName == "HV")
					{
						MessageBox.Show("'Use High Voltage Program Entry' is enabled.\n\nVPP First Program Entry may not be used\nwhile that option is enabled.", "Use VPP First Program Entry");
					}
					else
					{
						MessageBox.Show("'Use LVP Program Entry' is enabled.\n\nVPP First Program Entry may not be used\nwhile that option is enabled.", "Use VPP First Program Entry");
					}
					VppFirstToolStripMenuItem.Checked = false;
					return;
				}
				PICkitFunctions.SetVPPFirstProgramEntry();
				displayStatusWindow.Text = "VPP First programming mode entry set.\nTo use, PICkit 2 MUST supply VDD to target.";
				if (toolStripMenuItemManualSelect.Checked)
				{
					PICkitFunctions.PrepNewPart(resetBuffers: false);
				}
				if (autoDetectToolStripMenuItem.Checked)
				{
					VddTargetSave = Constants.VddTargetSelect.auto;
				}
				else if (forcePICkit2ToolStripMenuItem.Checked)
				{
					VddTargetSave = Constants.VddTargetSelect.pickit2;
				}
				else
				{
					VddTargetSave = Constants.VddTargetSelect.target;
				}
				vddPk2();
				targetPowerToolStripMenuItem.Enabled = false;
			}
			else
			{
				PICkitFunctions.ClearVppFirstProgramEntry();
				if (toolStripMenuItemManualSelect.Checked)
				{
					PICkitFunctions.PrepNewPart(resetBuffers: false);
				}
				if (!toolStripMenuItemLVPEnabled.Checked)
				{
					displayStatusWindow.Text = "Normal programming mode entry.";
				}
				targetPowerToolStripMenuItem.Enabled = true;
				restoreVddTarget();
			}
		}

		private bool eepromWrite(bool eraseWrite)
		{
			if (!preProgrammingCheck(PICkitFunctions.GetActiveFamily()))
			{
				return false;
			}
			updateGUI(updateMemories: false);
			Update();
			if (checkImportFile && !eraseWrite)
			{
				FileInfo fileInfo = new FileInfo(openHexFileDialog.FileName);
				if (ImportExportHex.LastWriteTime != fileInfo.LastWriteTime)
				{
					displayStatusWindow.Text = "Reloading Hex File\n";
					Update();
					Thread.Sleep(300);
					if (!importHexFileGo())
					{
						displayStatusWindow.Text = "Error Loading Hex File: Write aborted.\n";
						statusWindowColor = Constants.StatusColor.red;
						updateGUI(updateMemories: true);
						return false;
					}
				}
			}
			PICkitFunctions.VddOn();
			if (eraseWrite)
			{
				displayStatusWindow.Text = "Erasing device:\n";
			}
			else
			{
				displayStatusWindow.Text = "Writing device:\n";
			}
			Update();
			int programMem = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem;
			if (checkBoxProgMemEnabled.Checked)
			{
				PICkitFunctions.RunScript(0, 1);
				displayStatusWindow.Text += "EEPROM... ";
				Update();
				progressBar1.Value = 0;
				int num = 3;
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 4)
				{
					num = 4;
				}
				int progMemWrWords = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemWrWords;
				int bytesPerLocation = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
				int num2 = 256;
				if (programMem < num2)
				{
					num2 = programMem + programMem / (progMemWrWords * bytesPerLocation) * num;
				}
				if (num2 > 256)
				{
					num2 = 256;
				}
				int num3 = num2 / (progMemWrWords * bytesPerLocation + num);
				int num4 = num3 * progMemWrWords;
				int num5 = 0;
				progressBar1.Maximum = programMem / num4;
				byte[] array = new byte[256];
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemWrPrepScript != 0)
				{
					PICkitFunctions.RunScript(6, 1);
				}
				do
				{
					int num6 = 0;
					for (int i = 0; i < num4; i++)
					{
						if (num5 == programMem)
						{
							num3 = num6 / (progMemWrWords * bytesPerLocation + num);
							break;
						}
						if (num5 % progMemWrWords == 0)
						{
							int num7 = eeprom24BitAddress(num5, setReadBit: false);
							if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 4)
							{
								array[num6++] = 150;
							}
							array[num6++] = (byte)((num7 >> 16) & 0xFF);
							array[num6++] = (byte)((num7 >> 8) & 0xFF);
							array[num6++] = (byte)(num7 & 0xFF);
						}
						uint num8 = PICkitFunctions.DeviceBuffers.ProgramMemory[num5++];
						array[num6++] = (byte)(num8 & 0xFF);
						for (int j = 1; j < bytesPerLocation; j++)
						{
							num8 >>= 8;
							array[num6++] = (byte)(num8 & 0xFF);
						}
						if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 3 && bytesPerLocation == 2)
						{
							byte b = array[num6 - 2];
							array[num6 - 2] = array[num6 - 1];
							array[num6 - 1] = b;
						}
					}
					for (int num9 = PICkitFunctions.DataClrAndDownload(array, 0); num9 < num6; num9 = PICkitFunctions.DataDownload(array, num9, num6))
					{
					}
					PICkitFunctions.RunScript(7, num3);
					if ((PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 1 || PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 4) && eeprom_CheckBusErrors())
					{
						return false;
					}
					progressBar1.PerformStep();
				}
				while (num5 < programMem);
			}
			PICkitFunctions.RunScript(1, 1);
			bool flag = true;
			if (verifyOnWriteToolStripMenuItem.Checked && !eraseWrite)
			{
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 4)
				{
					conditionalVDDOff();
				}
				flag = deviceVerify(writeVerify: true, programMem - 1, forceEEVerify: false);
			}
			conditionalVDDOff();
			if (flag && !eraseWrite)
			{
				statusWindowColor = Constants.StatusColor.green;
				displayStatusWindow.Text = "Programming Successful.\n";
				updateGUI(updateMemories: true);
				return true;
			}
			return flag;
		}

		private int eeprom24BitAddress(int wordsWritten, bool setReadBit)
		{
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 1)
			{
				int num = wordsWritten;
				int num2 = 0;
				int num3 = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[3];
				num2 = (wordsWritten & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[1] & 0xFFFF);
				num >>= (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[2];
				num <<= 17 + num3;
				if (num3 > 0)
				{
					if (checkBoxA0CS.Checked)
					{
						num |= 0x20000;
					}
					if (checkBoxA1CS.Checked)
					{
						num |= 0x40000;
					}
					if (checkBoxA2CS.Checked)
					{
						num |= 0x80000;
					}
				}
				num2 += (num & 0xE0000) + 10485760;
				if (setReadBit)
				{
					num2 |= 0x10000;
				}
				return num2;
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 2)
			{
				int num4 = wordsWritten;
				int num5 = 0;
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem <= 65536)
				{
					num5 = (wordsWritten & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[1] & 0xFFFF);
					num4 >>= (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[2];
					num4 <<= 19;
					num5 += (num4 & 0x80000) + 131072;
					if (setReadBit)
					{
						num5 |= 0x10000;
					}
				}
				else
				{
					num5 = wordsWritten;
				}
				return num5;
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 3)
			{
				int num6 = 5;
				int num7 = 0;
				num7 = (wordsWritten & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[1] & 0xFFFF);
				if (setReadBit)
				{
					num6 = 6;
				}
				num6 <<= (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[2];
				return num7 | num6;
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 4)
			{
				int num8 = 0;
				num8 = (wordsWritten & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[1] & 0xFFFF);
				if (setReadBit)
				{
					return num8 | 0x30000;
				}
				return num8 | 0x6C0000;
			}
			return 0;
		}

		private bool eeprom_CheckBusErrors()
		{
			if (PICkitFunctions.BusErrorCheck())
			{
				PICkitFunctions.RunScript(1, 1);
				conditionalVDDOff();
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[0] == 4)
				{
					displayStatusWindow.Text = "UNI/O Bus Error (NoSAK) - Aborted.\n";
				}
				else
				{
					displayStatusWindow.Text = "I2C Bus Error (No Acknowledge) - Aborted.\n";
				}
				statusWindowColor = Constants.StatusColor.yellow;
				updateGUI(updateMemories: true);
				return true;
			}
			return false;
		}

		private void calibrateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DialogCalibrate dialogCalibrate = new DialogCalibrate();
			dialogCalibrate.ShowDialog();
			chkBoxVddOn.Checked = false;
			if (selfPoweredTarget)
			{
				PICkitFunctions.ForceTargetPowered();
			}
			detectPICkit2(showFound: true, detectMult: true);
		}

		private void UARTtoolStripMenuItem_Click(object sender, EventArgs e)
		{
			timerButton.Enabled = false;
			MCLRtoolStripMenuItem.Checked = false;
			checkBoxMCLR.Checked = false;
			uartWindow.SetVddBox(numUpDnVDD.Enabled, chkBoxVddOn.Checked);
			if (multiWindow)
			{
				programMemMultiWin.Hide();
				eepromDataMultiWin.Hide();
			}
			Hide();
			uartWindow.ShowDialog();
			Show();
			if (multiWindow)
			{
				if (multiWinPMemOpen)
				{
					programMemMultiWin.Show();
				}
				if (multiWinEEMemOpen && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0)
				{
					eepromDataMultiWin.Show();
				}
				Focus();
			}
			if (!selfPoweredTarget)
			{
				PICkitFunctions.ForcePICkitPowered();
			}
			if (writeOnPICkitButtonToolStripMenuItem.Checked)
			{
				buttonLast = true;
				timerButton.Enabled = true;
			}
		}

		private void toolStripMenuItemSingleWindow_Click(object sender, EventArgs e)
		{
			if (multiWindow)
			{
				viewChanged = true;
			}
			multiWindow = false;
			updateGUI(updateMemories: true);
		}

		private void toolStripMenuItemMultiWindow_Click(object sender, EventArgs e)
		{
			if (!multiWindow)
			{
				viewChanged = true;
			}
			multiWindow = true;
			updateGUI(updateMemories: true);
		}

		private void toolStripMenuItemShowProgramMemory_Click(object sender, EventArgs e)
		{
			if (multiWinPMemOpen)
			{
				multiWinPMemOpen = false;
				toolStripMenuItemShowProgramMemory.Checked = false;
				programMemMultiWin.Hide();
			}
			else
			{
				multiWinPMemOpen = true;
				toolStripMenuItemShowProgramMemory.Checked = true;
				programMemMultiWin.Show();
			}
			Focus();
		}

		private void toolStripMenuItemShowEEPROMData_Click(object sender, EventArgs e)
		{
			if (multiWinEEMemOpen)
			{
				multiWinEEMemOpen = false;
				toolStripMenuItemShowEEPROMData.Checked = false;
				eepromDataMultiWin.Hide();
			}
			else
			{
				multiWinEEMemOpen = true;
				toolStripMenuItemShowEEPROMData.Checked = true;
				eepromDataMultiWin.Show();
			}
			Focus();
		}

		private void FormPICkit2_Move(object sender, EventArgs e)
		{
			if (base.WindowState == FormWindowState.Minimized)
			{
				return;
			}
			if (multiWindow && mainWinOwnsMem)
			{
				int num = base.Location.X - lastLoc.X;
				int num2 = base.Location.Y - lastLoc.Y;
				int height = SystemInformation.VirtualScreen.Height;
				int width = SystemInformation.VirtualScreen.Width;
				int num3 = programMemMultiWin.Location.X + num;
				int num4 = programMemMultiWin.Location.Y + num2;
				if (num3 + 75 > width)
				{
					num3 = width - 75;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 + 75 > height)
				{
					num4 = height - 75;
				}
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (programMemMultiWin.WindowState != FormWindowState.Maximized && programMemMultiWin.WindowState != FormWindowState.Minimized)
				{
					programMemMultiWin.Location = new Point(num3, num4);
				}
				num3 = eepromDataMultiWin.Location.X + num;
				num4 = eepromDataMultiWin.Location.Y + num2;
				if (num3 + 75 > width)
				{
					num3 = width - 75;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 + 75 > height)
				{
					num4 = height - 75;
				}
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (eepromDataMultiWin.WindowState != FormWindowState.Maximized && eepromDataMultiWin.WindowState != FormWindowState.Minimized)
				{
					eepromDataMultiWin.Location = new Point(num3, num4);
				}
			}
			lastLoc = base.Location;
		}

		private void pICkit2GoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (PICkitFunctions.FamilyIsEEPROM() || PICkitFunctions.FamilyIsKeeloq() || PICkitFunctions.FamilyIsPIC32() || PICkitFunctions.FamilyIsMCP())
			{
				MessageBox.Show("PICkit 2 Programmer-To-Go does not support\n" + PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].FamilyName + " family devices.", "Unsupported Device Family");
				return;
			}
			if (PICkitFunctions.ActivePart == 0)
			{
				MessageBox.Show("No device selected!", "Programmer-To-Go");
				return;
			}
			if (!checkBoxEEMem.Checked && checkBoxEEMem.Enabled && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemEraseScript == 0)
			{
				MessageBox.Show("PICkit 2 Programmer-To-Go does not support\npreserving EEPROM on devices requiring a\nRead/Restore operation.\n\nThe entire device must be programmed.", "Programmer-To-Go");
				return;
			}
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 16383)
			{
				int bytesPerLocation = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
				int num = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr / (int)PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemHexBytes;
				int configWords = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords;
				int num2 = PICkitFunctions.DeviceBuffers.ProgramMemory.Length;
				if (num < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem && configWords > 0)
				{
					num2 -= configWords + 1;
				}
				int progMemWrWords = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgMemWrWords;
				int num3 = 256 / (progMemWrWords * bytesPerLocation);
				int num4 = num3 * progMemWrWords;
				num2 = PICkitFunctions.FindLastUsedInBuffer(PICkitFunctions.DeviceBuffers.ProgramMemory, PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue, num2 - 1);
				int num5 = (num2 + 1) / num4;
				if ((num2 + 1) % num4 > 0)
				{
					num5++;
				}
				num2 = num5 * num4;
				if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 65535)
				{
					float num6 = 1.23f;
					if (PICkitFunctions.FamilyIsdsPIC30())
					{
						num6 = 1.26f;
					}
					num2 = (int)((float)num2 * num6);
				}
				else
				{
					float num7 = 1.22f;
					if (PICkitFunctions.FamilyIsPIC18J())
					{
						num7 = 1.17f;
					}
					num2 = (int)((float)num2 * num7);
				}
				num2 *= bytesPerLocation;
				int num8 = 131072;
				if (ptgMemory >= 1)
				{
					num8 = 131072 * (2 << ptgMemory - 1);
				}
				if (num2 > num8)
				{
					if (ptgMemory > 0)
					{
						MessageBox.Show("The data in the buffer is too large\nto be downloaded to PICkit 2.\n\nIt cannot be used with Programmer-To-Go.", "Programmer-To-Go");
					}
					else
					{
						MessageBox.Show("The data in the buffer is too large\nto be downloaded to PICkit 2.\n\nSee section 3.1 of the Programmer-To-Go\nUser Guide for information on increasing\nthe PICkit 2 memory.", "Programmer-To-Go");
					}
					return;
				}
			}
			if (VppFirstToolStripMenuItem.Checked && VppFirstToolStripMenuItem.Enabled && (float)numUpDnVDD.Value < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddErase && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DebugRowEraseScript == 0)
			{
				MessageBox.Show("VPP First Program Entry selected:\nPICkit 2 must power target.\n\nHowever, VDD box setpoint is below the\nminimum Erase voltage for this part.", "Programmer-To-Go");
				return;
			}
			timerButton.Enabled = false;
			DialogPK2Go dialogPK2Go = new DialogPK2Go();
			dialogPK2Go.VDDVolts = (float)numUpDnVDD.Value;
			if (multiWindow)
			{
				dialogPK2Go.dataSource = shortenHex(displayDataSource.Text);
			}
			else
			{
				dialogPK2Go.dataSource = displayDataSource.Text;
			}
			if (enableCodeProtectToolStripMenuItem.Checked || enableDataProtectStripMenuItem.Checked)
			{
				if (enableDataProtectStripMenuItem.Checked)
				{
					dialogPK2Go.dataProtect = true;
				}
				if (enableCodeProtectToolStripMenuItem.Checked)
				{
					dialogPK2Go.codeProtect = true;
				}
			}
			dialogPK2Go.writeProgMem = checkBoxProgMemEnabled.Checked;
			dialogPK2Go.writeEEPROM = checkBoxEEMem.Checked;
			if (verifyOnWriteToolStripMenuItem.Checked)
			{
				dialogPK2Go.verifyDevice = true;
			}
			if (VppFirstToolStripMenuItem.Enabled && VppFirstToolStripMenuItem.Checked)
			{
				dialogPK2Go.vppFirst = true;
			}
			if (fastProgrammingToolStripMenuItem.Enabled && !fastProgrammingToolStripMenuItem.Checked)
			{
				dialogPK2Go.fastProgramming = false;
			}
			dialogPK2Go.icspSpeedSlow = slowSpeedICSP;
			if (MCLRtoolStripMenuItem.Enabled && MCLRtoolStripMenuItem.Checked)
			{
				dialogPK2Go.holdMCLR = true;
			}
			dialogPK2Go.SetPTGMemory(ptgMemory);
			dialogPK2Go.PICkit2WriteGo = ExtCallWrite;
			dialogPK2Go.OpenProgToGoGuide = OpenProgToGoUserGuide;
			bool flag = usePE33;
			usePE33 = false;
			bool flag2 = usePE24;
			usePE24 = false;
			dialogPK2Go.ShowDialog();
			usePE33 = flag;
			usePE24 = flag2;
			if (!selfPoweredTarget)
			{
				PICkitFunctions.ForcePICkitPowered();
			}
			else
			{
				PICkitFunctions.ForcePICkitPowered();
			}
			if (writeOnPICkitButtonToolStripMenuItem.Checked)
			{
				buttonLast = true;
				timerButton.Enabled = true;
			}
		}

		private void toolStripMenuItemManualSelect_Click(object sender, EventArgs e)
		{
			ManualAutoSelectToggle(updateGUI_OK: true);
		}

		private void ManualAutoSelectToggle(bool updateGUI_OK)
		{
			if (toolStripMenuItemManualSelect.Checked)
			{
				for (int i = 0; i < PICkitFunctions.DevFile.Families.Length; i++)
				{
					PICkitFunctions.DevFile.Families[i].PartDetect = false;
				}
			}
			else
			{
				for (int j = 0; j < PICkitFunctions.DevFile.Families.Length; j++)
				{
					if (PICkitFunctions.DevFile.Families[j].DeviceIDMask != 0)
					{
						PICkitFunctions.DevFile.Families[j].PartDetect = true;
					}
				}
				toolStripMenuItemLVPEnabled.Checked = false;
			}
			FamilySelectLogic(PICkitFunctions.GetActiveFamily(), updateGUI_OK);
		}

		private void toolStripMenuItemProgToGo_Click(object sender, EventArgs e)
		{
			OpenProgToGoUserGuide();
		}

		public void OpenProgToGoUserGuide()
		{
			try
			{
				Process.Start(HomeDirectory + "\\Programmer-To-Go User Guide.pdf");
			}
			catch
			{
				MessageBox.Show("Unable to open Programmer-To-Go Guide.");
			}
		}

		private void toolStripMenuItemLogicTool_Click(object sender, EventArgs e)
		{
			timerButton.Enabled = false;
			MCLRtoolStripMenuItem.Checked = false;
			checkBoxMCLR.Checked = false;
			logicWindow.SetVddBox(numUpDnVDD.Enabled, chkBoxVddOn.Checked);
			if (multiWindow)
			{
				programMemMultiWin.Hide();
				eepromDataMultiWin.Hide();
			}
			Hide();
			logicWindow.ShowDialog();
			Show();
			if (multiWindow)
			{
				if (multiWinPMemOpen)
				{
					programMemMultiWin.Show();
				}
				if (multiWinEEMemOpen && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0)
				{
					eepromDataMultiWin.Show();
				}
				Focus();
			}
			if (writeOnPICkitButtonToolStripMenuItem.Checked)
			{
				buttonLast = true;
				timerButton.Enabled = true;
			}
		}

		private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (e.ClickedItem.Text == "Select All")
			{
				if (dataGridProgramMemory.ContainsFocus)
				{
					dataGridProgramMemory.SelectAll();
				}
				else if (dataGridViewEEPROM.ContainsFocus)
				{
					dataGridViewEEPROM.SelectAll();
				}
			}
			else if (e.ClickedItem.Text == "Copy")
			{
				if (dataGridProgramMemory.ContainsFocus)
				{
					Clipboard.SetDataObject(dataGridProgramMemory.GetClipboardContent());
				}
				else if (dataGridViewEEPROM.ContainsFocus)
				{
					Clipboard.SetDataObject(dataGridViewEEPROM.GetClipboardContent());
				}
			}
		}

		private void dataGridProgramMemory_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				dataGridProgramMemory.Focus();
			}
		}

		private void dataGridViewEEPROM_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				dataGridViewEEPROM.Focus();
			}
		}

		private void toolStripMenuItemLogicToolUG_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start(HomeDirectory + "\\Logic Tool User Guide.pdf");
			}
			catch
			{
				MessageBox.Show("Unable to open Logic Tool User Guide.");
			}
		}

		private void calAutoRegenerateToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!setOSCCALToolStripMenuItem.Enabled || MessageBox.Show("Regenerating the OSCCAL value\nwill completely erase this\npart.\n\nAre you sure you wish to\ncontinue?", "Regenerate OSCCAL", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
			{
				return;
			}
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue == 4095)
			{
				short num = 0;
				float num2 = 0f;
				verifyOSCCALValue = false;
				for (int i = 0; i < 5; i++)
				{
					float num3 = (1f - 400f / num2) / 0.0057f + 0.5f;
					num = (short)(num + (short)num3);
					if (num < -64 || num > 63)
					{
						conditionalVDDOff();
						eraseDeviceAll(forceOSSCAL: false, new uint[0]);
						verifyOSCCALValue = true;
						updateGUI(updateMemories: true);
						MessageBox.Show("Regenerating OSCCAL Failed!\n\nCalibration out of range.", "Regenerate OSCCAL");
						return;
					}
					PICkitFunctions.ResetBuffers();
					PICkitFunctions.DeviceBuffers.ProgramMemory[0] = (uint)((int)Constants.BASELINE_CAL[0] | ((num << 1) & 0xFF));
					PICkitFunctions.DeviceBuffers.ConfigWords[0] = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[6];
					for (int j = 1; j < Constants.BASELINE_CAL.Length; j++)
					{
						PICkitFunctions.DeviceBuffers.ProgramMemory[j] = Constants.BASELINE_CAL[j];
					}
					if (!deviceWrite())
					{
						PICkitFunctions.ResetBuffers();
						verifyOSCCALValue = true;
						updateGUI(updateMemories: true);
						MessageBox.Show("Regenerating OSCCAL Failed!\n\nUnable to program part.", "Regenerate OSCCAL");
						return;
					}
					PICkitFunctions.VddOn();
					for (int k = 0; k < 3; k++)
					{
						num2 = PICkitFunctions.MeasurePGDPulse();
						if (num2 < 695f && num2 > 10f)
						{
							break;
						}
						if (k == 2)
						{
							conditionalVDDOff();
							eraseDeviceAll(forceOSSCAL: false, new uint[0]);
							verifyOSCCALValue = true;
							MessageBox.Show("Regenerating OSCCAL Failed!\n\nUnable to connect to\ncalibration executive.", "Regenerate OSCCAL");
							updateGUI(updateMemories: true);
							return;
						}
					}
					conditionalVDDOff();
					float num4 = 404f;
					if (i == 4)
					{
						num4 = 406f;
					}
					float num5 = 396f;
					if (i == 4)
					{
						num4 = 394f;
					}
					if (num2 > num5 && num2 < num4)
					{
						PICkitFunctions.DeviceBuffers.OSCCAL = PICkitFunctions.DeviceBuffers.ProgramMemory[0];
						eraseDeviceAll(forceOSSCAL: true, new uint[0]);
						verifyOSCCALValue = true;
						MessageBox.Show("Success!\n\nOSSCAL Regenerated and\nwritten to device.", "Regenerate OSCCAL");
						updateGUI(updateMemories: true);
						return;
					}
				}
			}
			else
			{
				short num6 = 32;
				float num7 = 0f;
				verifyOSCCALValue = false;
				for (int l = 0; l < 5; l++)
				{
					float num8 = (1f - 400f / num7) / 0.007f + 0.5f;
					num6 = (short)(num6 + (short)num8);
					if (num6 < 0 || num6 > 63)
					{
						conditionalVDDOff();
						eraseDeviceAll(forceOSSCAL: false, new uint[0]);
						verifyOSCCALValue = true;
						updateGUI(updateMemories: true);
						MessageBox.Show("Regenerating OSCCAL Failed!\n\nCalibration out of range.", "Regenerate OSCCAL");
						return;
					}
					PICkitFunctions.ResetBuffers();
					PICkitFunctions.DeviceBuffers.ProgramMemory[0] = (uint)((int)Constants.MR16F676FAM_CAL[0] | ((num6 << 2) & 0xFF));
					PICkitFunctions.DeviceBuffers.ConfigWords[0] = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[6];
					for (int m = 1; m < Constants.MR16F676FAM_CAL.Length; m++)
					{
						PICkitFunctions.DeviceBuffers.ProgramMemory[m] = Constants.MR16F676FAM_CAL[m];
					}
					if (!deviceWrite())
					{
						PICkitFunctions.ResetBuffers();
						verifyOSCCALValue = true;
						updateGUI(updateMemories: true);
						MessageBox.Show("Regenerating OSCCAL Failed!\n\nUnable to program part.", "Regenerate OSCCAL");
						return;
					}
					PICkitFunctions.VddOn();
					for (int n = 0; n < 3; n++)
					{
						num7 = PICkitFunctions.MeasurePGDPulse();
						if (num7 < 695f && num7 > 10f)
						{
							break;
						}
						if (n == 2)
						{
							conditionalVDDOff();
							eraseDeviceAll(forceOSSCAL: false, new uint[0]);
							verifyOSCCALValue = true;
							MessageBox.Show("Regenerating OSCCAL Failed!\n\nUnable to connect to\ncalibration executive.", "Regenerate OSCCAL");
							updateGUI(updateMemories: true);
							return;
						}
					}
					conditionalVDDOff();
					float num9 = 404f;
					if (l == 4)
					{
						num9 = 406f;
					}
					float num10 = 396f;
					if (l == 4)
					{
						num9 = 394f;
					}
					if (num7 > num10 && num7 < num9)
					{
						PICkitFunctions.DeviceBuffers.OSCCAL = (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[7] | (PICkitFunctions.DeviceBuffers.ProgramMemory[0] & 0xFF));
						eraseDeviceAll(forceOSSCAL: true, new uint[0]);
						verifyOSCCALValue = true;
						MessageBox.Show("Success!\n\nOSSCAL Regenerated and\nwritten to device.", "Regenerate OSCCAL");
						updateGUI(updateMemories: true);
						return;
					}
				}
			}
			eraseDeviceAll(forceOSSCAL: false, new uint[0]);
			verifyOSCCALValue = true;
			updateGUI(updateMemories: true);
			MessageBox.Show("Regenerating OSCCAL Failed!\n\nUnable to calibrate.", "Regenerate OSCCAL");
		}

		private void timerInitalUpdate_Tick(object sender, EventArgs e)
		{
			timerInitalUpdate.Enabled = false;
			toolStripMenuItemShowProgramMemory.Checked = saveMultWinPMemOpen;
			multiWinPMemOpen = saveMultWinPMemOpen;
			if (multiWinPMemOpen)
			{
				programMemMultiWin.Show();
			}
			toolStripMenuItemShowEEPROMData.Checked = saveMultiWinEEMemOpen;
			multiWinEEMemOpen = saveMultiWinEEMemOpen;
			if (multiWinEEMemOpen && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0)
			{
				eepromDataMultiWin.Show();
			}
			Focus();
		}

		private void mainWindowAlwaysInFrontToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (mainWindowAlwaysInFrontToolStripMenuItem.Checked)
			{
				mainWinOwnsMem = true;
				AddOwnedForm(programMemMultiWin);
				AddOwnedForm(eepromDataMultiWin);
			}
			else
			{
				mainWinOwnsMem = false;
				RemoveOwnedForm(programMemMultiWin);
				RemoveOwnedForm(eepromDataMultiWin);
			}
		}

		private bool useProgExec33()
		{
			if ((PICkitFunctions.FamilyIsdsPIC33F() || PICkitFunctions.FamilyIsPIC24H()) && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem >= 4096)
			{
				return usePE33;
			}
			return false;
		}

		private bool useProgExec24F()
		{
			if (PICkitFunctions.FamilyIsPIC24FJ())
			{
				return usePE24;
			}
			return false;
		}

		private void updateAlertSoundCheck()
		{
			toolStripMenuItemSounds.Checked = (PlayErrorWav || PlaySuccessWav || PlayWarningWav);
		}

		private void toolStripMenuItemSounds_Click(object sender, EventArgs e)
		{
			dialogSounds dialogSounds = new dialogSounds();
			dialogSounds.ShowDialog();
			updateAlertSoundCheck();
		}

		private void as0BitValueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			as0BitValueToolStripMenuItem.Checked = true;
			as1BitValueToolStripMenuItem.Checked = false;
			asReadOrImportedToolStripMenuItem.Checked = false;
			updateGUI(updateMemories: true);
		}

		private void as1BitValueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			as0BitValueToolStripMenuItem.Checked = false;
			as1BitValueToolStripMenuItem.Checked = true;
			asReadOrImportedToolStripMenuItem.Checked = false;
			updateGUI(updateMemories: true);
		}

		private void asReadOrImportedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			as0BitValueToolStripMenuItem.Checked = false;
			as1BitValueToolStripMenuItem.Checked = false;
			asReadOrImportedToolStripMenuItem.Checked = true;
			updateGUI(updateMemories: true);
		}

		private void labelConfig_Click(object sender, EventArgs e)
		{
			DialogConfigEdit dialogConfigEdit = new DialogConfigEdit();
			dialogConfigEdit.ScalefactW = ScalefactW;
			dialogConfigEdit.ScalefactH = ScalefactH;
			if (as0BitValueToolStripMenuItem.Checked)
			{
				dialogConfigEdit.SetDisplayMask(0);
			}
			else if (as1BitValueToolStripMenuItem.Checked)
			{
				dialogConfigEdit.SetDisplayMask(1);
			}
			else
			{
				dialogConfigEdit.SetDisplayMask(2);
			}
			dialogConfigEdit.ShowDialog();
			if (ConfigsEdited)
			{
				displayDataSource.Text = "Edited.";
				checkImportFile = false;
				ConfigsEdited = false;
			}
			updateGUI(updateMemories: true);
		}

		private void toolStripMenuItemLVPEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if (toolStripMenuItemLVPEnabled.Checked)
			{
				if (!toolStripMenuItemManualSelect.Checked)
				{
					string scriptName = PICkitFunctions.DevFile.Scripts[PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].LVPScript - 1].ScriptName;
					scriptName = scriptName.Substring(scriptName.Length - 2);
					if (scriptName == "HV")
					{
						MessageBox.Show("High Voltage Program entry may not be used\nwhen auto-detecting parts.\n\nSelect 'Programmer > Manual Device Select'\nto allow HVP to be used.", "Use HVP Program Entry");
					}
					else
					{
						MessageBox.Show("Low Voltage Program entry may not be used\nwhen auto-detecting parts.\n\nSelect 'Programmer > Manual Device Select'\nto allow LVP to be used.", "Use LVP Program Entry");
					}
					toolStripMenuItemLVPEnabled.Checked = false;
				}
				else if (VppFirstToolStripMenuItem.Checked)
				{
					MessageBox.Show("'Use VPP First Program Entry' is enabled.\n\nLVP Program Entry may not be used while\nthat option is enabled.", "Use LVP Program Entry");
					toolStripMenuItemLVPEnabled.Checked = false;
				}
				else
				{
					PICkitFunctions.SetLVPProgramEntry();
					string scriptName2 = PICkitFunctions.DevFile.Scripts[PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].LVPScript - 1].ScriptName;
					if (scriptName2.Substring(scriptName2.Length - 2) == "HV")
					{
						displayStatusWindow.Text = "High Voltage Programming (HVP) entry set.";
					}
					else
					{
						displayStatusWindow.Text = "Low Voltage Programming (LVP) entry set.";
					}
					scriptName2 = scriptName2.Substring(scriptName2.Length - 3);
					if (scriptName2 == "PGM")
					{
						displayStatusWindow.Text += "\nConnect PICkit 2 AUX to device PGM pin.";
					}
					PICkitFunctions.PrepNewPart(resetBuffers: false);
				}
			}
			else
			{
				PICkitFunctions.ClearLVPProgramEntry();
				if (!VppFirstToolStripMenuItem.Checked)
				{
					displayStatusWindow.Text = "Normal programming mode entry.";
				}
				if (toolStripMenuItemManualSelect.Checked)
				{
					PICkitFunctions.PrepNewPart(resetBuffers: false);
				}
			}
			updateGUI(updateMemories: false);
		}
	}
}
