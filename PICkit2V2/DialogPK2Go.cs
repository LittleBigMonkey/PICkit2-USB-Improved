using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class DialogPK2Go : Form
	{
		private IContainer components;

		private Panel panelIntro;

		private Button buttonBack;

		private Button buttonNext;

		private Button buttonCancel;

		private Button buttonHelp;

		private Panel panelSettings;

		private Label label16;

		private Label label1;

		private Label label15;

		private GroupBox groupBox1;

		private Label label2;

		private RadioButton radioButtonPK2Power;

		private RadioButton radioButtonSelfPower;

		private GroupBox groupBox2;

		private Label label5;

		private Label labelPartNumber;

		private Label label3;

		private Label labelDataSource;

		private Label label4;

		private Panel panelDownload;

		private GroupBox groupBox3;

		private Label labelTargetPowerSmmry;

		private Label label12;

		private Label label7;

		private Label labelSourceSmmry;

		private Label label8;

		private Label labelOSCCAL_BandGap;

		private Label label10;

		private Label labelMemRegions;

		private Label labelCodeProtect;

		private Label label14;

		private Label labelVerify;

		private Label label11;

		private Label labelDataProtect;

		private Label label9;

		private Label labelRowErase;

		private CheckBox checkBoxRowErase;

		private Label labelVDDMin;

		private Label labelPNsmmry;

		private Label labelMemRegionsSmmry;

		private Label label6;

		private Label labelMCLRHoldSmmry;

		private Label labelFastProgSmmry;

		private Label labelVerifySmmry;

		private Label labelVPP1stSmmry;

		private Panel panelDownloading;

		private Label labelDOWNLOADING;

		private Panel panelDownloadDone;

		private Label label13;

		private Label label17;

		private Timer timerBlink;

		private Label label20;

		private Label label19;

		private Label label18;

		private PictureBox pictureBoxTarget;

		private Panel panelErrors;

		private Label label21;

		private Label label22;

		private Label label23;

		private PictureBox pictureBoxBusy;

		private Label label26;

		private Label label25;

		private RadioButton radioButton4Blinks;

		private RadioButton radioButton3Blinks;

		private RadioButton radioButton2Blinks;

		private RadioButton radioButtonVErr;

		private Label label24;

		private Label label27;

		private Label label28;

		private Label label29;

		private Label label256K;

		public float VDDVolts;

		public string dataSource = "--";

		public bool codeProtect;

		public bool dataProtect;

		public bool verifyDevice;

		public bool vppFirst;

		public bool writeProgMem = true;

		public bool writeEEPROM = true;

		public bool fastProgramming = true;

		public bool holdMCLR;

		public byte icspSpeedSlow = 4;

		private byte ptgMemory;

		private int blinkCount;

		public DelegateWrite PICkit2WriteGo;

		public DelegateOpenProgToGoGuide OpenProgToGoGuide;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PICkit2V2.DialogPK2Go));
			panelIntro = new System.Windows.Forms.Panel();
			label8 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			buttonBack = new System.Windows.Forms.Button();
			buttonNext = new System.Windows.Forms.Button();
			buttonCancel = new System.Windows.Forms.Button();
			buttonHelp = new System.Windows.Forms.Button();
			panelSettings = new System.Windows.Forms.Panel();
			groupBox2 = new System.Windows.Forms.GroupBox();
			label14 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			labelVerify = new System.Windows.Forms.Label();
			labelMemRegions = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			labelDataProtect = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			labelCodeProtect = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			labelOSCCAL_BandGap = new System.Windows.Forms.Label();
			labelDataSource = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			labelPartNumber = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label2 = new System.Windows.Forms.Label();
			labelRowErase = new System.Windows.Forms.Label();
			checkBoxRowErase = new System.Windows.Forms.CheckBox();
			radioButtonPK2Power = new System.Windows.Forms.RadioButton();
			radioButtonSelfPower = new System.Windows.Forms.RadioButton();
			label1 = new System.Windows.Forms.Label();
			panelDownload = new System.Windows.Forms.Panel();
			label7 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			labelSourceSmmry = new System.Windows.Forms.Label();
			labelTargetPowerSmmry = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			labelVDDMin = new System.Windows.Forms.Label();
			labelPNsmmry = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			labelMemRegionsSmmry = new System.Windows.Forms.Label();
			labelVPP1stSmmry = new System.Windows.Forms.Label();
			labelVerifySmmry = new System.Windows.Forms.Label();
			labelFastProgSmmry = new System.Windows.Forms.Label();
			labelMCLRHoldSmmry = new System.Windows.Forms.Label();
			panelDownloading = new System.Windows.Forms.Panel();
			labelDOWNLOADING = new System.Windows.Forms.Label();
			panelDownloadDone = new System.Windows.Forms.Panel();
			label13 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			timerBlink = new System.Windows.Forms.Timer(components);
			pictureBoxTarget = new System.Windows.Forms.PictureBox();
			label18 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			panelErrors = new System.Windows.Forms.Panel();
			label21 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			pictureBoxBusy = new System.Windows.Forms.PictureBox();
			label23 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			radioButtonVErr = new System.Windows.Forms.RadioButton();
			radioButton2Blinks = new System.Windows.Forms.RadioButton();
			radioButton3Blinks = new System.Windows.Forms.RadioButton();
			radioButton4Blinks = new System.Windows.Forms.RadioButton();
			label25 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			label27 = new System.Windows.Forms.Label();
			label28 = new System.Windows.Forms.Label();
			label29 = new System.Windows.Forms.Label();
			label256K = new System.Windows.Forms.Label();
			panelIntro.SuspendLayout();
			panelSettings.SuspendLayout();
			groupBox2.SuspendLayout();
			groupBox1.SuspendLayout();
			panelDownload.SuspendLayout();
			groupBox3.SuspendLayout();
			panelDownloading.SuspendLayout();
			panelDownloadDone.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBoxTarget).BeginInit();
			panelErrors.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBoxBusy).BeginInit();
			SuspendLayout();
			panelIntro.Controls.Add(label256K);
			panelIntro.Controls.Add(label8);
			panelIntro.Controls.Add(label15);
			panelIntro.Controls.Add(label16);
			panelIntro.Location = new System.Drawing.Point(12, 12);
			panelIntro.Name = "panelIntro";
			panelIntro.Size = new System.Drawing.Size(351, 331);
			panelIntro.TabIndex = 0;
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(69, 31);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(213, 19);
			label8.TabIndex = 5;
			label8.Text = "Programmer-To-Go Wizard";
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label15.Location = new System.Drawing.Point(29, 90);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(290, 195);
			label15.TabIndex = 4;
			label15.Text = resources.GetString("label15.Text");
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label16.Location = new System.Drawing.Point(81, 12);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(188, 19);
			label16.TabIndex = 2;
			label16.Text = "Welcome to the PICkit 2";
			buttonBack.Enabled = false;
			buttonBack.Location = new System.Drawing.Point(102, 350);
			buttonBack.Name = "buttonBack";
			buttonBack.Size = new System.Drawing.Size(82, 22);
			buttonBack.TabIndex = 7;
			buttonBack.Text = "< Back";
			buttonBack.UseVisualStyleBackColor = true;
			buttonBack.Click += new System.EventHandler(buttonBack_Click);
			buttonNext.Location = new System.Drawing.Point(192, 350);
			buttonNext.Name = "buttonNext";
			buttonNext.Size = new System.Drawing.Size(82, 22);
			buttonNext.TabIndex = 6;
			buttonNext.Text = "Next >";
			buttonNext.UseVisualStyleBackColor = true;
			buttonNext.Click += new System.EventHandler(buttonNext_Click);
			buttonCancel.Location = new System.Drawing.Point(282, 350);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new System.Drawing.Size(82, 22);
			buttonCancel.TabIndex = 5;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += new System.EventHandler(buttonCancel_Click);
			buttonHelp.Location = new System.Drawing.Point(12, 350);
			buttonHelp.Name = "buttonHelp";
			buttonHelp.Size = new System.Drawing.Size(82, 22);
			buttonHelp.TabIndex = 6;
			buttonHelp.Text = "Help";
			buttonHelp.UseVisualStyleBackColor = true;
			buttonHelp.Click += new System.EventHandler(buttonHelp_Click);
			panelSettings.Controls.Add(groupBox2);
			panelSettings.Controls.Add(groupBox1);
			panelSettings.Controls.Add(label1);
			panelSettings.Location = new System.Drawing.Point(12, 12);
			panelSettings.Name = "panelSettings";
			panelSettings.Size = new System.Drawing.Size(351, 331);
			panelSettings.TabIndex = 8;
			panelSettings.Visible = false;
			groupBox2.Controls.Add(label14);
			groupBox2.Controls.Add(label4);
			groupBox2.Controls.Add(labelVerify);
			groupBox2.Controls.Add(labelMemRegions);
			groupBox2.Controls.Add(label11);
			groupBox2.Controls.Add(labelDataProtect);
			groupBox2.Controls.Add(label9);
			groupBox2.Controls.Add(labelCodeProtect);
			groupBox2.Controls.Add(label10);
			groupBox2.Controls.Add(labelOSCCAL_BandGap);
			groupBox2.Controls.Add(labelDataSource);
			groupBox2.Controls.Add(label5);
			groupBox2.Controls.Add(labelPartNumber);
			groupBox2.Controls.Add(label3);
			groupBox2.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			groupBox2.Location = new System.Drawing.Point(12, 34);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(325, 154);
			groupBox2.TabIndex = 6;
			groupBox2.TabStop = false;
			groupBox2.Text = "Buffer Settings";
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label14.Location = new System.Drawing.Point(6, 109);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(79, 15);
			label14.TabIndex = 18;
			label14.Text = "Verify Device:";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(59, 135);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(198, 13);
			label4.TabIndex = 9;
			label4.Text = "Click CANCEL to change buffer settings.\r\n";
			labelVerify.AutoSize = true;
			labelVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelVerify.Location = new System.Drawing.Point(90, 109);
			labelVerify.Name = "labelVerify";
			labelVerify.Size = new System.Drawing.Size(30, 15);
			labelVerify.TabIndex = 17;
			labelVerify.Text = "Yes";
			labelMemRegions.AutoSize = true;
			labelMemRegions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelMemRegions.Location = new System.Drawing.Point(115, 94);
			labelMemRegions.Name = "labelMemRegions";
			labelMemRegions.Size = new System.Drawing.Size(151, 15);
			labelMemRegions.TabIndex = 12;
			labelMemRegions.Text = "Program Entire Device";
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label11.Location = new System.Drawing.Point(5, 94);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(104, 15);
			label11.TabIndex = 15;
			label11.Text = "Memory Regions:";
			labelDataProtect.AutoSize = true;
			labelDataProtect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelDataProtect.Location = new System.Drawing.Point(251, 79);
			labelDataProtect.Name = "labelDataProtect";
			labelDataProtect.Size = new System.Drawing.Size(25, 15);
			labelDataProtect.TabIndex = 14;
			labelDataProtect.Text = "NA";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(168, 79);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(77, 15);
			label9.TabIndex = 12;
			label9.Text = "Data Protect:";
			labelCodeProtect.AutoSize = true;
			labelCodeProtect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelCodeProtect.Location = new System.Drawing.Point(91, 79);
			labelCodeProtect.Name = "labelCodeProtect";
			labelCodeProtect.Size = new System.Drawing.Size(27, 15);
			labelCodeProtect.TabIndex = 13;
			labelCodeProtect.Text = "ON";
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.Location = new System.Drawing.Point(5, 79);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(80, 15);
			label10.TabIndex = 11;
			label10.Text = "Code Protect:";
			labelOSCCAL_BandGap.AutoSize = true;
			labelOSCCAL_BandGap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			labelOSCCAL_BandGap.Location = new System.Drawing.Point(59, 33);
			labelOSCCAL_BandGap.Name = "labelOSCCAL_BandGap";
			labelOSCCAL_BandGap.Size = new System.Drawing.Size(177, 15);
			labelOSCCAL_BandGap.TabIndex = 10;
			labelOSCCAL_BandGap.Text = "OSCCAL will be preserved.";
			labelOSCCAL_BandGap.Visible = false;
			labelDataSource.AutoSize = true;
			labelDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelDataSource.Location = new System.Drawing.Point(32, 63);
			labelDataSource.Name = "labelDataSource";
			labelDataSource.Size = new System.Drawing.Size(88, 13);
			labelDataSource.TabIndex = 8;
			labelDataSource.Text = "<DataSource>";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(6, 48);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(109, 15);
			label5.TabIndex = 7;
			label5.Text = "Buffer data source:";
			labelPartNumber.AutoSize = true;
			labelPartNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelPartNumber.Location = new System.Drawing.Point(59, 18);
			labelPartNumber.Name = "labelPartNumber";
			labelPartNumber.Size = new System.Drawing.Size(100, 15);
			labelPartNumber.TabIndex = 6;
			labelPartNumber.Text = "<PartNumber>";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(6, 18);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(47, 15);
			label3.TabIndex = 5;
			label3.Text = "Device:";
			groupBox1.Controls.Add(labelVDDMin);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(labelRowErase);
			groupBox1.Controls.Add(checkBoxRowErase);
			groupBox1.Controls.Add(radioButtonPK2Power);
			groupBox1.Controls.Add(radioButtonSelfPower);
			groupBox1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			groupBox1.Location = new System.Drawing.Point(12, 194);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(325, 137);
			groupBox1.TabIndex = 5;
			groupBox1.TabStop = false;
			groupBox1.Text = "Power Settings";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(66, 107);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(191, 26);
			label2.TabIndex = 5;
			label2.Text = "To change PICkit 2 VDD voltage, click\r\n    CANCEL and adjust the VDD box.\r\n";
			labelRowErase.AutoSize = true;
			labelRowErase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelRowErase.ForeColor = System.Drawing.Color.OrangeRed;
			labelRowErase.Location = new System.Drawing.Point(13, 89);
			labelRowErase.Name = "labelRowErase";
			labelRowErase.Size = new System.Drawing.Size(281, 13);
			labelRowErase.TabIndex = 11;
			labelRowErase.Text = "Row Erase used: Will NOT program Code Protected parts!";
			labelRowErase.Visible = false;
			checkBoxRowErase.AutoSize = true;
			checkBoxRowErase.Enabled = false;
			checkBoxRowErase.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			checkBoxRowErase.Location = new System.Drawing.Point(48, 44);
			checkBoxRowErase.Name = "checkBoxRowErase";
			checkBoxRowErase.Size = new System.Drawing.Size(176, 20);
			checkBoxRowErase.TabIndex = 2;
			checkBoxRowErase.Text = "Use low voltage row erase";
			checkBoxRowErase.UseVisualStyleBackColor = true;
			checkBoxRowErase.CheckedChanged += new System.EventHandler(checkBoxRowErase_CheckedChanged);
			radioButtonPK2Power.AutoSize = true;
			radioButtonPK2Power.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			radioButtonPK2Power.Location = new System.Drawing.Point(16, 66);
			radioButtonPK2Power.Name = "radioButtonPK2Power";
			radioButtonPK2Power.Size = new System.Drawing.Size(249, 20);
			radioButtonPK2Power.TabIndex = 1;
			radioButtonPK2Power.TabStop = true;
			radioButtonPK2Power.Text = "Power target from PICkit 2 at 0.0 Volts";
			radioButtonPK2Power.UseVisualStyleBackColor = true;
			radioButtonPK2Power.Click += new System.EventHandler(radioButtonPK2Power_Click);
			radioButtonSelfPower.AutoSize = true;
			radioButtonSelfPower.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			radioButtonSelfPower.Location = new System.Drawing.Point(16, 21);
			radioButtonSelfPower.Name = "radioButtonSelfPower";
			radioButtonSelfPower.Size = new System.Drawing.Size(216, 20);
			radioButtonSelfPower.TabIndex = 0;
			radioButtonSelfPower.TabStop = true;
			radioButtonSelfPower.Text = "Target has its own power supply.";
			radioButtonSelfPower.UseVisualStyleBackColor = true;
			radioButtonSelfPower.Click += new System.EventHandler(radioButtonSelfPower_Click);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(90, 12);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(171, 19);
			label1.TabIndex = 3;
			label1.Text = "Programmer Settings";
			panelDownload.Controls.Add(label7);
			panelDownload.Controls.Add(groupBox3);
			panelDownload.Controls.Add(label12);
			panelDownload.Location = new System.Drawing.Point(12, 12);
			panelDownload.Name = "panelDownload";
			panelDownload.Size = new System.Drawing.Size(351, 331);
			panelDownload.TabIndex = 9;
			panelDownload.Visible = false;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(70, 239);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(212, 45);
			label7.TabIndex = 7;
			label7.Text = "Click the DOWNLOAD button below to\r\nset up PICkit 2 for Programmer-To-Go\r\noperation.\r\n";
			groupBox3.Controls.Add(labelMCLRHoldSmmry);
			groupBox3.Controls.Add(labelFastProgSmmry);
			groupBox3.Controls.Add(labelVerifySmmry);
			groupBox3.Controls.Add(labelVPP1stSmmry);
			groupBox3.Controls.Add(labelMemRegionsSmmry);
			groupBox3.Controls.Add(label6);
			groupBox3.Controls.Add(labelPNsmmry);
			groupBox3.Controls.Add(labelSourceSmmry);
			groupBox3.Controls.Add(labelTargetPowerSmmry);
			groupBox3.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			groupBox3.Location = new System.Drawing.Point(12, 34);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(327, 171);
			groupBox3.TabIndex = 6;
			groupBox3.TabStop = false;
			groupBox3.Text = "Download Summary";
			labelSourceSmmry.AutoSize = true;
			labelSourceSmmry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelSourceSmmry.Location = new System.Drawing.Point(6, 58);
			labelSourceSmmry.Name = "labelSourceSmmry";
			labelSourceSmmry.Size = new System.Drawing.Size(88, 13);
			labelSourceSmmry.TabIndex = 10;
			labelSourceSmmry.Text = "<DataSource>";
			labelTargetPowerSmmry.AutoSize = true;
			labelTargetPowerSmmry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelTargetPowerSmmry.Location = new System.Drawing.Point(6, 75);
			labelTargetPowerSmmry.Name = "labelTargetPowerSmmry";
			labelTargetPowerSmmry.Size = new System.Drawing.Size(108, 15);
			labelTargetPowerSmmry.TabIndex = 7;
			labelTargetPowerSmmry.Text = "<Target Power>";
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label12.Location = new System.Drawing.Point(81, 12);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(168, 19);
			label12.TabIndex = 3;
			label12.Text = "Download to PICkit 2";
			labelVDDMin.AutoSize = true;
			labelVDDMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelVDDMin.ForeColor = System.Drawing.Color.OrangeRed;
			labelVDDMin.Location = new System.Drawing.Point(45, 47);
			labelVDDMin.Name = "labelVDDMin";
			labelVDDMin.Size = new System.Drawing.Size(132, 13);
			labelVDDMin.TabIndex = 12;
			labelVDDMin.Text = "VDD must be >= 0.0 Volts.";
			labelVDDMin.Visible = false;
			labelPNsmmry.AutoSize = true;
			labelPNsmmry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelPNsmmry.Location = new System.Drawing.Point(6, 21);
			labelPNsmmry.Name = "labelPNsmmry";
			labelPNsmmry.Size = new System.Drawing.Size(100, 15);
			labelPNsmmry.TabIndex = 11;
			labelPNsmmry.Text = "<PartNumber>";
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(6, 41);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(76, 15);
			label6.TabIndex = 12;
			label6.Text = "Data source:";
			labelMemRegionsSmmry.AutoSize = true;
			labelMemRegionsSmmry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelMemRegionsSmmry.Location = new System.Drawing.Point(6, 94);
			labelMemRegionsSmmry.Name = "labelMemRegionsSmmry";
			labelMemRegionsSmmry.Size = new System.Drawing.Size(134, 13);
			labelMemRegionsSmmry.TabIndex = 13;
			labelMemRegionsSmmry.Text = "<MemRegions CP-DP>";
			labelVPP1stSmmry.AutoSize = true;
			labelVPP1stSmmry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelVPP1stSmmry.Location = new System.Drawing.Point(6, 107);
			labelVPP1stSmmry.Name = "labelVPP1stSmmry";
			labelVPP1stSmmry.Size = new System.Drawing.Size(62, 13);
			labelVPP1stSmmry.TabIndex = 14;
			labelVPP1stSmmry.Text = "<VPP1st>";
			labelVerifySmmry.AutoSize = true;
			labelVerifySmmry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelVerifySmmry.Location = new System.Drawing.Point(6, 120);
			labelVerifySmmry.Name = "labelVerifySmmry";
			labelVerifySmmry.Size = new System.Drawing.Size(53, 13);
			labelVerifySmmry.TabIndex = 15;
			labelVerifySmmry.Text = "<Verify>";
			labelFastProgSmmry.AutoSize = true;
			labelFastProgSmmry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelFastProgSmmry.Location = new System.Drawing.Point(6, 133);
			labelFastProgSmmry.Name = "labelFastProgSmmry";
			labelFastProgSmmry.Size = new System.Drawing.Size(117, 13);
			labelFastProgSmmry.TabIndex = 16;
			labelFastProgSmmry.Text = "<FastProgramming>";
			labelMCLRHoldSmmry.AutoSize = true;
			labelMCLRHoldSmmry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelMCLRHoldSmmry.Location = new System.Drawing.Point(6, 146);
			labelMCLRHoldSmmry.Name = "labelMCLRHoldSmmry";
			labelMCLRHoldSmmry.Size = new System.Drawing.Size(81, 13);
			labelMCLRHoldSmmry.TabIndex = 17;
			labelMCLRHoldSmmry.Text = "<MCLRHold>";
			panelDownloading.Controls.Add(labelDOWNLOADING);
			panelDownloading.Location = new System.Drawing.Point(12, 12);
			panelDownloading.Name = "panelDownloading";
			panelDownloading.Size = new System.Drawing.Size(351, 331);
			panelDownloading.TabIndex = 6;
			panelDownloading.Visible = false;
			labelDOWNLOADING.AutoSize = true;
			labelDOWNLOADING.Font = new System.Drawing.Font("Arial", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelDOWNLOADING.Location = new System.Drawing.Point(72, 153);
			labelDOWNLOADING.Name = "labelDOWNLOADING";
			labelDOWNLOADING.Size = new System.Drawing.Size(206, 24);
			labelDOWNLOADING.TabIndex = 2;
			labelDOWNLOADING.Text = "Downloading Now...";
			panelDownloadDone.Controls.Add(label20);
			panelDownloadDone.Controls.Add(label19);
			panelDownloadDone.Controls.Add(label18);
			panelDownloadDone.Controls.Add(pictureBoxTarget);
			panelDownloadDone.Controls.Add(label17);
			panelDownloadDone.Controls.Add(label13);
			panelDownloadDone.Location = new System.Drawing.Point(12, 12);
			panelDownloadDone.Name = "panelDownloadDone";
			panelDownloadDone.Size = new System.Drawing.Size(351, 331);
			panelDownloadDone.TabIndex = 10;
			panelDownloadDone.Visible = false;
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label13.Location = new System.Drawing.Point(75, 15);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(201, 22);
			label13.TabIndex = 2;
			label13.Text = "Download Complete!";
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label17.Location = new System.Drawing.Point(17, 62);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(323, 48);
			label17.TabIndex = 3;
			label17.Text = "The PICkit 2 unit will indicate it's in Programmer-To-Go\r\nmode and ready to program by blinking the \"Target\" \r\nLED twice in succession:";
			timerBlink.Interval = 250;
			timerBlink.Tick += new System.EventHandler(timerBlink_Tick);
			pictureBoxTarget.BackColor = System.Drawing.SystemColors.ControlText;
			pictureBoxTarget.Location = new System.Drawing.Point(73, 125);
			pictureBoxTarget.Name = "pictureBoxTarget";
			pictureBoxTarget.Size = new System.Drawing.Size(15, 15);
			pictureBoxTarget.TabIndex = 4;
			pictureBoxTarget.TabStop = false;
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label18.Location = new System.Drawing.Point(101, 125);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(48, 15);
			label18.TabIndex = 6;
			label18.Text = "Target";
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label19.Location = new System.Drawing.Point(16, 159);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(230, 16);
			label19.TabIndex = 7;
			label19.Text = "Remove the PICkit 2 from USB now.";
			label20.AutoSize = true;
			label20.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label20.Location = new System.Drawing.Point(16, 175);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(332, 144);
			label20.TabIndex = 8;
			label20.Text = resources.GetString("label20.Text");
			panelErrors.Controls.Add(label29);
			panelErrors.Controls.Add(label28);
			panelErrors.Controls.Add(label27);
			panelErrors.Controls.Add(label26);
			panelErrors.Controls.Add(label25);
			panelErrors.Controls.Add(radioButton4Blinks);
			panelErrors.Controls.Add(radioButton3Blinks);
			panelErrors.Controls.Add(radioButton2Blinks);
			panelErrors.Controls.Add(radioButtonVErr);
			panelErrors.Controls.Add(label24);
			panelErrors.Controls.Add(label23);
			panelErrors.Controls.Add(pictureBoxBusy);
			panelErrors.Controls.Add(label22);
			panelErrors.Controls.Add(label21);
			panelErrors.Location = new System.Drawing.Point(12, 12);
			panelErrors.Name = "panelErrors";
			panelErrors.Size = new System.Drawing.Size(351, 331);
			panelErrors.TabIndex = 11;
			panelErrors.Visible = false;
			label21.AutoSize = true;
			label21.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label21.Location = new System.Drawing.Point(69, 12);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(226, 19);
			label21.TabIndex = 4;
			label21.Text = "Programming && Error Codes";
			label22.AutoSize = true;
			label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label22.Location = new System.Drawing.Point(25, 33);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(287, 150);
			label22.TabIndex = 8;
			label22.Text = resources.GetString("label22.Text");
			pictureBoxBusy.BackColor = System.Drawing.SystemColors.ControlText;
			pictureBoxBusy.Location = new System.Drawing.Point(107, 194);
			pictureBoxBusy.Name = "pictureBoxBusy";
			pictureBoxBusy.Size = new System.Drawing.Size(15, 15);
			pictureBoxBusy.TabIndex = 9;
			pictureBoxBusy.TabStop = false;
			label23.AutoSize = true;
			label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label23.Location = new System.Drawing.Point(138, 194);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(37, 15);
			label23.TabIndex = 10;
			label23.Text = "Busy";
			label24.AutoSize = true;
			label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
			label24.Location = new System.Drawing.Point(25, 212);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(188, 15);
			label24.TabIndex = 11;
			label24.Text = "Error Codes (Select for example):";
			radioButtonVErr.AutoSize = true;
			radioButtonVErr.Checked = true;
			radioButtonVErr.Location = new System.Drawing.Point(28, 230);
			radioButtonVErr.Name = "radioButtonVErr";
			radioButtonVErr.Size = new System.Drawing.Size(85, 17);
			radioButtonVErr.TabIndex = 12;
			radioButtonVErr.TabStop = true;
			radioButtonVErr.Text = "Fast Blinking";
			radioButtonVErr.UseVisualStyleBackColor = true;
			radioButtonVErr.Click += new System.EventHandler(radioButtonVErr_Click);
			radioButton2Blinks.AutoSize = true;
			radioButton2Blinks.Location = new System.Drawing.Point(28, 264);
			radioButton2Blinks.Name = "radioButton2Blinks";
			radioButton2Blinks.Size = new System.Drawing.Size(62, 17);
			radioButton2Blinks.TabIndex = 13;
			radioButton2Blinks.Text = "2 Blinks";
			radioButton2Blinks.UseVisualStyleBackColor = true;
			radioButton2Blinks.Click += new System.EventHandler(radioButtonVErr_Click);
			radioButton3Blinks.AutoSize = true;
			radioButton3Blinks.Location = new System.Drawing.Point(186, 230);
			radioButton3Blinks.Name = "radioButton3Blinks";
			radioButton3Blinks.Size = new System.Drawing.Size(62, 17);
			radioButton3Blinks.TabIndex = 14;
			radioButton3Blinks.Text = "3 Blinks";
			radioButton3Blinks.UseVisualStyleBackColor = true;
			radioButton3Blinks.Click += new System.EventHandler(radioButtonVErr_Click);
			radioButton4Blinks.AutoSize = true;
			radioButton4Blinks.Location = new System.Drawing.Point(186, 264);
			radioButton4Blinks.Name = "radioButton4Blinks";
			radioButton4Blinks.Size = new System.Drawing.Size(62, 17);
			radioButton4Blinks.TabIndex = 15;
			radioButton4Blinks.Text = "4 Blinks";
			radioButton4Blinks.UseVisualStyleBackColor = true;
			radioButton4Blinks.Click += new System.EventHandler(radioButtonVErr_Click);
			label25.AutoSize = true;
			label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label25.Location = new System.Drawing.Point(48, 246);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(88, 15);
			label25.TabIndex = 16;
			label25.Text = "VDD/VPP Error";
			label26.AutoSize = true;
			label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label26.Location = new System.Drawing.Point(47, 280);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(89, 15);
			label26.TabIndex = 17;
			label26.Text = "Device ID Error";
			label27.AutoSize = true;
			label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label27.Location = new System.Drawing.Point(206, 246);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(73, 15);
			label27.TabIndex = 18;
			label27.Text = "Verify Failed";
			label28.AutoSize = true;
			label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label28.Location = new System.Drawing.Point(206, 280);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(78, 15);
			label28.TabIndex = 19;
			label28.Text = "Internal Error";
			label29.AutoSize = true;
			label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label29.Location = new System.Drawing.Point(28, 312);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(294, 13);
			label29.TabIndex = 19;
			label29.Text = "Click EXIT to close Wizard.  Click HELP for more information.\r\n";
			label256K.AutoSize = true;
			label256K.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label256K.Location = new System.Drawing.Point(156, 306);
			label256K.Name = "label256K";
			label256K.Size = new System.Drawing.Size(196, 13);
			label256K.TabIndex = 6;
			label256K.Text = "256K PICkit 2 upgrade support enabled.\r\n";
			label256K.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(374, 380);
			base.Controls.Add(panelErrors);
			base.Controls.Add(panelDownloadDone);
			base.Controls.Add(panelDownloading);
			base.Controls.Add(panelDownload);
			base.Controls.Add(panelSettings);
			base.Controls.Add(buttonHelp);
			base.Controls.Add(buttonBack);
			base.Controls.Add(panelIntro);
			base.Controls.Add(buttonNext);
			base.Controls.Add(buttonCancel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DialogPK2Go";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Programmer-To-Go Wizard";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(DialogPK2Go_FormClosing);
			panelIntro.ResumeLayout(false);
			panelIntro.PerformLayout();
			panelSettings.ResumeLayout(false);
			panelSettings.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			panelDownload.ResumeLayout(false);
			panelDownload.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			panelDownloading.ResumeLayout(false);
			panelDownloading.PerformLayout();
			panelDownloadDone.ResumeLayout(false);
			panelDownloadDone.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBoxTarget).EndInit();
			panelErrors.ResumeLayout(false);
			panelErrors.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBoxBusy).EndInit();
			ResumeLayout(false);
		}

		public DialogPK2Go()
		{
			InitializeComponent();
		}

		public void SetPTGMemory(byte value)
		{
			ptgMemory = value;
			if (ptgMemory > 0 && ptgMemory <= 5)
			{
				label256K.Visible = true;
			}
			if (ptgMemory == 1)
			{
				label256K.Text = "256K PICkit 2 upgrade support enabled.\r\n";
			}
			else if (ptgMemory == 2)
			{
				label256K.Text = "512K SPI memory support enabled.\r\n";
			}
			else if (ptgMemory == 3)
			{
				label256K.Text = "1M SPI memory support enabled.\r\n";
			}
			else if (ptgMemory == 4)
			{
				label256K.Text = "2M SPI memory support enabled.\r\n";
			}
			else if (ptgMemory == 5)
			{
				label256K.Text = "4M SPI memory support enabled.\r\n";
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void buttonNext_Click(object sender, EventArgs e)
		{
			if (panelIntro.Visible)
			{
				panelIntro.Visible = false;
				buttonBack.Enabled = true;
				fillSettings(changePower: true);
			}
			else if (panelSettings.Visible)
			{
				if (checkEraseVoltage())
				{
					panelSettings.Visible = false;
					buttonNext.Text = "Download";
					fillDownload();
				}
			}
			else if (panelDownload.Visible)
			{
				downloadGO();
			}
			else if (panelDownloadDone.Visible)
			{
				buttonNext.Enabled = false;
				panelDownloadDone.Visible = false;
				panelErrors.Visible = true;
				timerBlink.Interval = 84;
			}
		}

		private void buttonBack_Click(object sender, EventArgs e)
		{
			if (panelSettings.Visible)
			{
				panelSettings.Visible = false;
				panelIntro.Visible = true;
				buttonBack.Enabled = false;
			}
			else if (panelDownload.Visible)
			{
				panelDownload.Visible = false;
				buttonNext.Text = "Next >";
				fillSettings(changePower: false);
			}
		}

		private bool checkEraseVoltage()
		{
			if (radioButtonSelfPower.Checked)
			{
				return true;
			}
			if (VDDVolts < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddErase && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DebugRowEraseScript == 0)
			{
				DialogResult dialogResult = MessageBox.Show("The selected PICkit 2 VDD voltage is below\nthe minimum required to Bulk Erase this part.\n\nContinue anyway?", labelPartNumber.Text + " VDD Error", MessageBoxButtons.OKCancel);
				if (dialogResult == DialogResult.OK)
				{
					return true;
				}
				return false;
			}
			return true;
		}

		private void fillSettings(bool changePower)
		{
			labelPartNumber.Text = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].PartName;
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].OSSCALSave)
			{
				labelOSCCAL_BandGap.Visible = true;
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BandGapMask != 0)
				{
					labelOSCCAL_BandGap.Text = "OSCCAL && BandGap will be preserved.";
				}
			}
			if (dataSource == "Edited.")
			{
				labelDataSource.Text = "Edited Buffer.";
			}
			else
			{
				labelDataSource.Text = dataSource;
			}
			if (!writeProgMem)
			{
				labelCodeProtect.Text = "N/A";
				labelDataProtect.Text = "N/A";
			}
			else
			{
				if (codeProtect)
				{
					labelCodeProtect.Text = "ON";
				}
				else
				{
					labelCodeProtect.Text = "OFF";
				}
				if (dataProtect)
				{
					labelDataProtect.Text = "ON";
				}
				else if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0)
				{
					labelDataProtect.Text = "OFF";
				}
				else
				{
					labelDataProtect.Text = "N/A";
				}
			}
			if (!writeProgMem)
			{
				labelMemRegions.Text = "Write EEPROM data only.";
			}
			else if (!writeEEPROM && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0)
			{
				labelMemRegions.Text = "Preserve EEPROM on write.";
			}
			else
			{
				labelMemRegions.Text = "Write entire device.";
			}
			if (verifyDevice)
			{
				labelVerify.Text = "Yes";
			}
			else
			{
				labelVerify.Text = "No - device will NOT be verified";
			}
			if (changePower)
			{
				radioButtonPK2Power.Text = $"Power target from PICkit 2 at {VDDVolts:0.0} Volts.";
				if (vppFirst)
				{
					radioButtonSelfPower.Enabled = false;
					radioButtonSelfPower.Text = "Use VPP First - must power from PICkit 2";
					checkBoxRowErase.Enabled = false;
					radioButtonPK2Power.Checked = true;
					pickit2PowerRowErase();
				}
				else
				{
					radioButtonSelfPower.Checked = true;
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DebugRowEraseScript > 0)
					{
						checkBoxRowErase.Text = $"VDD < {PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddErase:0.0}V: Use low voltage row erase";
						checkBoxRowErase.Enabled = true;
					}
					else
					{
						checkBoxRowErase.Visible = false;
						checkBoxRowErase.Enabled = false;
						labelVDDMin.Text = $"VDD must be >= {PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddErase:0.0} Volts.";
						labelVDDMin.Visible = true;
					}
				}
			}
			panelSettings.Visible = true;
		}

		private bool pickit2PowerRowErase()
		{
			if (VDDVolts < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddErase)
			{
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DebugRowEraseScript <= 0)
				{
					MessageBox.Show(string.Format("PICkit 2 cannot program this device\nat the selected VDD voltage.\n\n{0:0.0}V is below the minimum for erase, {0:0.0}V", VDDVolts, PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddErase), "Programmer-To-Go");
					return false;
				}
				labelRowErase.Text = "Row Erase used: Will NOT program Code Protected parts!";
				labelRowErase.Visible = true;
			}
			else
			{
				labelRowErase.Visible = false;
			}
			return true;
		}

		private void fillDownload()
		{
			labelPNsmmry.Text = labelPartNumber.Text;
			labelSourceSmmry.Text = labelDataSource.Text;
			if (radioButtonSelfPower.Checked)
			{
				if (checkBoxRowErase.Enabled && checkBoxRowErase.Checked)
				{
					labelTargetPowerSmmry.Text = "Target is Powered (Use Low Voltage Row Erase)";
				}
				else
				{
					labelTargetPowerSmmry.Text = $"Target is Powered (Min VDD = {PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddErase:0.0} Volts)";
				}
			}
			else
			{
				labelTargetPowerSmmry.Text = $"Power target from PICkit 2 at {VDDVolts:0.0} Volts";
			}
			labelMemRegionsSmmry.Text = labelMemRegions.Text;
			if (writeProgMem)
			{
				if (codeProtect)
				{
					labelMemRegionsSmmry.Text += " -CP";
				}
				if (dataProtect)
				{
					labelMemRegionsSmmry.Text += " -DP";
				}
			}
			if (vppFirst)
			{
				labelVPP1stSmmry.Text = "Use VPP 1st Program Entry";
			}
			else
			{
				labelVPP1stSmmry.Text = "";
			}
			if (verifyDevice)
			{
				labelVerifySmmry.Text = "Device will be verified";
			}
			else
			{
				labelVerifySmmry.Text = "Device will NOT be verified";
			}
			if (fastProgramming)
			{
				labelFastProgSmmry.Text = "Fast Programming is ON";
			}
			else
			{
				labelFastProgSmmry.Text = "Fast Programming is OFF";
			}
			if (holdMCLR)
			{
				labelMCLRHoldSmmry.Text = "MCLR kept asserted during && after programming";
			}
			else
			{
				labelMCLRHoldSmmry.Text = "MCLR released after programming";
			}
			panelDownload.Visible = true;
		}

		private void downloadGO()
		{
			panelDownload.Visible = false;
			panelDownloading.Visible = true;
			buttonHelp.Enabled = false;
			buttonBack.Enabled = false;
			buttonNext.Enabled = false;
			buttonCancel.Enabled = false;
			buttonCancel.Text = "Exit";
			Update();
			if (radioButtonSelfPower.Checked)
			{
				PICkitFunctions.ForceTargetPowered();
			}
			else
			{
				PICkitFunctions.ForcePICkitPowered();
			}
			if (ptgMemory <= 5)
			{
				PICkitFunctions.EnterLearnMode(ptgMemory);
			}
			else
			{
				PICkitFunctions.EnterLearnMode(0);
			}
			if (fastProgramming)
			{
				PICkitFunctions.SetProgrammingSpeed(0);
			}
			else
			{
				PICkitFunctions.SetProgrammingSpeed(icspSpeedSlow);
			}
			PICkit2WriteGo(verify: true);
			PICkitFunctions.ExitLearnMode();
			if (ptgMemory <= 5)
			{
				PICkitFunctions.EnablePK2GoMode(ptgMemory);
			}
			else
			{
				PICkitFunctions.EnablePK2GoMode(0);
			}
			PICkitFunctions.DisconnectPICkit2Unit();
			panelDownloading.Visible = false;
			panelDownloadDone.Visible = true;
			buttonHelp.Enabled = true;
			buttonNext.Enabled = true;
			buttonNext.Text = "Next >";
			buttonCancel.Enabled = true;
			timerBlink.Enabled = true;
		}

		private void radioButtonPK2Power_Click(object sender, EventArgs e)
		{
			radiobuttonPower();
		}

		private void radioButtonSelfPower_Click(object sender, EventArgs e)
		{
			radiobuttonPower();
		}

		private void radiobuttonPower()
		{
			if (radioButtonPK2Power.Checked)
			{
				checkBoxRowErase.Enabled = false;
				if (!pickit2PowerRowErase())
				{
					radioButtonPK2Power.Checked = false;
					radioButtonSelfPower.Checked = true;
				}
				return;
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].DebugRowEraseScript > 0)
			{
				checkBoxRowErase.Enabled = true;
			}
			else
			{
				checkBoxRowErase.Enabled = false;
			}
			if (checkBoxRowErase.Enabled && checkBoxRowErase.Checked)
			{
				labelRowErase.Text = "Row Erase used: Will NOT program Code Protected parts!";
				labelRowErase.Visible = true;
			}
			else
			{
				labelRowErase.Visible = false;
			}
		}

		private void checkBoxRowErase_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxRowErase.Enabled && checkBoxRowErase.Checked)
			{
				labelRowErase.Text = "Row Erase used: Will NOT program Code Protected parts!";
				labelRowErase.Visible = true;
			}
			else
			{
				labelRowErase.Visible = false;
			}
		}

		private void timerBlink_Tick(object sender, EventArgs e)
		{
			if (panelDownloadDone.Visible)
			{
				blinkCount++;
				if (blinkCount > 5)
				{
					blinkCount = 0;
				}
				if (blinkCount < 4)
				{
					if ((blinkCount & 1) == 0)
					{
						pictureBoxTarget.BackColor = Color.Yellow;
					}
					else
					{
						pictureBoxTarget.BackColor = SystemColors.ControlText;
					}
				}
				return;
			}
			if (radioButtonVErr.Checked)
			{
				blinkCount++;
				if ((blinkCount & 1) == 0)
				{
					pictureBoxBusy.BackColor = Color.Red;
				}
				else
				{
					pictureBoxBusy.BackColor = SystemColors.ControlText;
				}
				return;
			}
			int num = 4;
			if (radioButton3Blinks.Checked)
			{
				num = 6;
			}
			else if (radioButton4Blinks.Checked)
			{
				num = 8;
			}
			if (blinkCount++ <= num)
			{
				if ((blinkCount & 1) == 0)
				{
					pictureBoxBusy.BackColor = Color.Red;
				}
				else
				{
					pictureBoxBusy.BackColor = SystemColors.ControlText;
				}
			}
			else
			{
				blinkCount = 0;
			}
		}

		private void DialogPK2Go_FormClosing(object sender, FormClosingEventArgs e)
		{
			PICkitFunctions.ExitLearnMode();
		}

		private void radioButtonVErr_Click(object sender, EventArgs e)
		{
			if (radioButtonVErr.Checked)
			{
				timerBlink.Interval = 84;
			}
			else
			{
				timerBlink.Interval = 200;
			}
		}

		private void buttonHelp_Click(object sender, EventArgs e)
		{
			OpenProgToGoGuide();
		}
	}
}
