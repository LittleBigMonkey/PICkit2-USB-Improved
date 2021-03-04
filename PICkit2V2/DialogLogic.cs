using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class DialogLogic : Form
	{
		private const int SAMPLE_ARRAY_LENGTH = 1024;

		private IContainer components;

		private Label label2;

		private Panel panel2;

		private RadioButton radioButtonAnalyzer;

		private RadioButton radioButtonLogicIO;

		private Panel panelAnalyzer;

		private PictureBox pictureBoxDisplay;

		private Panel panelDisplay;

		private Label label4;

		private Label label3;

		private Label label1;

		private GroupBox groupBoxZoom;

		private Label labelTimeScale;

		private RadioButton radioButton4x;

		private RadioButton radioButtonZoom05;

		private RadioButton radioButton2x;

		private RadioButton radioButtonZoom1x;

		private Label label8;

		private ComboBox comboBoxCh3Trig;

		private ComboBox comboBoxCh2Trig;

		private ComboBox comboBoxCh1Trig;

		private Label label7;

		private Label label6;

		private Label label5;

		private Label label9;

		private Label label14;

		private Label label13;

		private Label label12;

		private Label label11;

		private Label label10;

		private Label label17;

		private TextBox textBox1;

		private Label label16;

		private Label label15;

		private Button buttonExit;

		private GroupBox groupBox2;

		private PictureBox pictureBox1;

		private GroupBox groupBox1;

		private Button buttonRun;

		private Label label18;

		private ComboBox comboBoxSampleRate;

		private Label label19;

		private RadioButton radioButtonTrigStart;

		private Label label21;

		private Label labelAliasFreq;

		private RadioButton radioButtonTrigDly3;

		private RadioButton radioButtonTrigDly2;

		private RadioButton radioButtonTrigDly1;

		private RadioButton radioButtonTrigEnd;

		private RadioButton radioButtonTrigMid;

		private Label label22;

		private Label label23;

		private Label label24;

		private Label label25;

		private Label labelCursor1Val;

		private CheckBox checkBoxCursors;

		private Label labelCursor1;

		private Label labelCursor2Val;

		private Label labelCursor2;

		private Label labelCursorDelta;

		private Label labelCursorDeltaVal;

		private Button buttonHelp;

		private System.Windows.Forms.Timer timerRun;

		private Button buttonSave;

		private SaveFileDialog saveFileDialogDisplay;

		private Panel panelLogicIO;

		private PictureBox pictureBox2;

		private Label label20;

		private Label label29;

		private Label label28;

		private Label label27;

		private Label label26;

		private Panel panel4;

		private RadioButton radioButtonPin6In;

		private RadioButton radioButtonPin6Out;

		private Panel panel3;

		private RadioButton radioButtonPin5In;

		private RadioButton radioButtonPin5Out;

		private Panel panel1;

		private RadioButton radioButtonPin4In;

		private RadioButton radioButtonPin4Out;

		private Label label30;

		private TextBox textBoxPin4In;

		private Label label32;

		private Label label31;

		private TextBox textBoxPin4Out;

		private TextBox textBoxPin1Out;

		private Label label34;

		private Label label33;

		private TextBox textBoxPin5In;

		private TextBox textBoxPin5Out;

		private TextBox textBoxPin6Out;

		private TextBox textBoxPin6In;

		private CheckBox checkBoxIOEnable;

		private Label labelOut6Click;

		private Label labelOut5Click;

		private Label labelOut4Click;

		private Label labelOut1Click;

		private System.Windows.Forms.Timer timerIO;

		private CheckBox checkBoxVDD;

		public DelegateVddCallback VddCallback;

		private byte[] sampleArray = new byte[1024];

		private int lastZoomLevel = 1;

		private int lastSampleRate;

		private int lastTrigPos = 50;

		private int lastTrigDelay;

		private int firstSample;

		private float[] sampleRates = new float[9]
		{
			1E-06f,
			2E-06f,
			4E-06f,
			1E-05f,
			2E-05f,
			4E-05f,
			0.0001f,
			0.0002f,
			0.001f
		};

		private byte[] sampleFactors = new byte[9]
		{
			0,
			1,
			3,
			9,
			19,
			39,
			99,
			199,
			255
		};

		private Bitmap lastDrawnDisplay;

		private int cursor1Pos;

		private int cursor2Pos;

		private int postTrigCount = 1;

		private DialogTrigger trigDialog;

		private bool vddOn;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PICkit2V2.DialogLogic));
			label2 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			radioButtonAnalyzer = new System.Windows.Forms.RadioButton();
			radioButtonLogicIO = new System.Windows.Forms.RadioButton();
			panelAnalyzer = new System.Windows.Forms.Panel();
			buttonSave = new System.Windows.Forms.Button();
			labelCursor1Val = new System.Windows.Forms.Label();
			labelCursor1 = new System.Windows.Forms.Label();
			labelCursorDelta = new System.Windows.Forms.Label();
			labelCursorDeltaVal = new System.Windows.Forms.Label();
			labelCursor2 = new System.Windows.Forms.Label();
			checkBoxCursors = new System.Windows.Forms.CheckBox();
			labelCursor2Val = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			label23 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			groupBox2 = new System.Windows.Forms.GroupBox();
			label25 = new System.Windows.Forms.Label();
			radioButtonTrigDly3 = new System.Windows.Forms.RadioButton();
			radioButtonTrigDly2 = new System.Windows.Forms.RadioButton();
			radioButtonTrigDly1 = new System.Windows.Forms.RadioButton();
			radioButtonTrigEnd = new System.Windows.Forms.RadioButton();
			radioButtonTrigMid = new System.Windows.Forms.RadioButton();
			radioButtonTrigStart = new System.Windows.Forms.RadioButton();
			label21 = new System.Windows.Forms.Label();
			labelAliasFreq = new System.Windows.Forms.Label();
			comboBoxSampleRate = new System.Windows.Forms.ComboBox();
			label19 = new System.Windows.Forms.Label();
			buttonRun = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			groupBox1 = new System.Windows.Forms.GroupBox();
			label18 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			comboBoxCh1Trig = new System.Windows.Forms.ComboBox();
			label13 = new System.Windows.Forms.Label();
			comboBoxCh2Trig = new System.Windows.Forms.ComboBox();
			label12 = new System.Windows.Forms.Label();
			comboBoxCh3Trig = new System.Windows.Forms.ComboBox();
			label11 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			groupBoxZoom = new System.Windows.Forms.GroupBox();
			radioButton4x = new System.Windows.Forms.RadioButton();
			radioButtonZoom05 = new System.Windows.Forms.RadioButton();
			radioButton2x = new System.Windows.Forms.RadioButton();
			radioButtonZoom1x = new System.Windows.Forms.RadioButton();
			labelTimeScale = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			panelDisplay = new System.Windows.Forms.Panel();
			pictureBoxDisplay = new System.Windows.Forms.PictureBox();
			buttonExit = new System.Windows.Forms.Button();
			buttonHelp = new System.Windows.Forms.Button();
			timerRun = new System.Windows.Forms.Timer(components);
			saveFileDialogDisplay = new System.Windows.Forms.SaveFileDialog();
			panelLogicIO = new System.Windows.Forms.Panel();
			checkBoxIOEnable = new System.Windows.Forms.CheckBox();
			labelOut6Click = new System.Windows.Forms.Label();
			labelOut5Click = new System.Windows.Forms.Label();
			labelOut4Click = new System.Windows.Forms.Label();
			labelOut1Click = new System.Windows.Forms.Label();
			textBoxPin6Out = new System.Windows.Forms.TextBox();
			textBoxPin6In = new System.Windows.Forms.TextBox();
			textBoxPin5Out = new System.Windows.Forms.TextBox();
			textBoxPin5In = new System.Windows.Forms.TextBox();
			textBoxPin4Out = new System.Windows.Forms.TextBox();
			textBoxPin1Out = new System.Windows.Forms.TextBox();
			label34 = new System.Windows.Forms.Label();
			label33 = new System.Windows.Forms.Label();
			textBoxPin4In = new System.Windows.Forms.TextBox();
			label32 = new System.Windows.Forms.Label();
			label31 = new System.Windows.Forms.Label();
			panel4 = new System.Windows.Forms.Panel();
			radioButtonPin6In = new System.Windows.Forms.RadioButton();
			radioButtonPin6Out = new System.Windows.Forms.RadioButton();
			panel3 = new System.Windows.Forms.Panel();
			radioButtonPin5In = new System.Windows.Forms.RadioButton();
			radioButtonPin5Out = new System.Windows.Forms.RadioButton();
			panel1 = new System.Windows.Forms.Panel();
			radioButtonPin4In = new System.Windows.Forms.RadioButton();
			radioButtonPin4Out = new System.Windows.Forms.RadioButton();
			label30 = new System.Windows.Forms.Label();
			label29 = new System.Windows.Forms.Label();
			label28 = new System.Windows.Forms.Label();
			label27 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			timerIO = new System.Windows.Forms.Timer(components);
			checkBoxVDD = new System.Windows.Forms.CheckBox();
			panel2.SuspendLayout();
			panelAnalyzer.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			groupBox1.SuspendLayout();
			groupBoxZoom.SuspendLayout();
			panelDisplay.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBoxDisplay).BeginInit();
			panelLogicIO.SuspendLayout();
			panel4.SuspendLayout();
			panel3.SuspendLayout();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			label2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(442, 15);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(47, 15);
			label2.TabIndex = 10;
			label2.Text = "Mode:";
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			panel2.Controls.Add(radioButtonAnalyzer);
			panel2.Controls.Add(radioButtonLogicIO);
			panel2.Location = new System.Drawing.Point(494, 9);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(130, 30);
			panel2.TabIndex = 9;
			radioButtonAnalyzer.Appearance = System.Windows.Forms.Appearance.Button;
			radioButtonAnalyzer.Location = new System.Drawing.Point(69, 2);
			radioButtonAnalyzer.Name = "radioButtonAnalyzer";
			radioButtonAnalyzer.Size = new System.Drawing.Size(60, 22);
			radioButtonAnalyzer.TabIndex = 17;
			radioButtonAnalyzer.Text = "Analyzer";
			radioButtonAnalyzer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			radioButtonAnalyzer.UseVisualStyleBackColor = true;
			radioButtonAnalyzer.CheckedChanged += new System.EventHandler(radioButtonAnalyzer_CheckedChanged);
			radioButtonLogicIO.Appearance = System.Windows.Forms.Appearance.Button;
			radioButtonLogicIO.Checked = true;
			radioButtonLogicIO.Location = new System.Drawing.Point(3, 2);
			radioButtonLogicIO.Name = "radioButtonLogicIO";
			radioButtonLogicIO.Size = new System.Drawing.Size(60, 22);
			radioButtonLogicIO.TabIndex = 16;
			radioButtonLogicIO.TabStop = true;
			radioButtonLogicIO.Text = "Logic I/O";
			radioButtonLogicIO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			radioButtonLogicIO.UseVisualStyleBackColor = true;
			panelAnalyzer.Controls.Add(buttonSave);
			panelAnalyzer.Controls.Add(labelCursor1Val);
			panelAnalyzer.Controls.Add(labelCursor1);
			panelAnalyzer.Controls.Add(labelCursorDelta);
			panelAnalyzer.Controls.Add(labelCursorDeltaVal);
			panelAnalyzer.Controls.Add(labelCursor2);
			panelAnalyzer.Controls.Add(checkBoxCursors);
			panelAnalyzer.Controls.Add(labelCursor2Val);
			panelAnalyzer.Controls.Add(label24);
			panelAnalyzer.Controls.Add(label23);
			panelAnalyzer.Controls.Add(label22);
			panelAnalyzer.Controls.Add(groupBox2);
			panelAnalyzer.Controls.Add(pictureBox1);
			panelAnalyzer.Controls.Add(groupBox1);
			panelAnalyzer.Controls.Add(groupBoxZoom);
			panelAnalyzer.Controls.Add(labelTimeScale);
			panelAnalyzer.Controls.Add(label4);
			panelAnalyzer.Controls.Add(label3);
			panelAnalyzer.Controls.Add(label1);
			panelAnalyzer.Controls.Add(panelDisplay);
			panelAnalyzer.Location = new System.Drawing.Point(12, 39);
			panelAnalyzer.Name = "panelAnalyzer";
			panelAnalyzer.Size = new System.Drawing.Size(610, 326);
			panelAnalyzer.TabIndex = 11;
			panelAnalyzer.Visible = false;
			buttonSave.Location = new System.Drawing.Point(542, 119);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new System.Drawing.Size(68, 23);
			buttonSave.TabIndex = 34;
			buttonSave.Text = "Save";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += new System.EventHandler(buttonSave_Click);
			labelCursor1Val.AutoSize = true;
			labelCursor1Val.Enabled = false;
			labelCursor1Val.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelCursor1Val.ForeColor = System.Drawing.Color.RoyalBlue;
			labelCursor1Val.Location = new System.Drawing.Point(260, 2);
			labelCursor1Val.Name = "labelCursor1Val";
			labelCursor1Val.Size = new System.Drawing.Size(63, 13);
			labelCursor1Val.TabIndex = 29;
			labelCursor1Val.Text = "100.52 us";
			labelCursor1.AutoSize = true;
			labelCursor1.Enabled = false;
			labelCursor1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelCursor1.ForeColor = System.Drawing.Color.RoyalBlue;
			labelCursor1.Location = new System.Drawing.Point(237, 2);
			labelCursor1.Name = "labelCursor1";
			labelCursor1.Size = new System.Drawing.Size(26, 13);
			labelCursor1.TabIndex = 28;
			labelCursor1.Text = "X =";
			labelCursorDelta.AutoSize = true;
			labelCursorDelta.Enabled = false;
			labelCursorDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelCursorDelta.ForeColor = System.Drawing.SystemColors.ControlText;
			labelCursorDelta.Location = new System.Drawing.Point(439, 2);
			labelCursorDelta.Name = "labelCursorDelta";
			labelCursorDelta.Size = new System.Drawing.Size(38, 13);
			labelCursorDelta.TabIndex = 32;
			labelCursorDelta.Text = "Y-X =";
			labelCursorDeltaVal.AutoSize = true;
			labelCursorDeltaVal.Enabled = false;
			labelCursorDeltaVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelCursorDeltaVal.ForeColor = System.Drawing.SystemColors.ControlText;
			labelCursorDeltaVal.Location = new System.Drawing.Point(477, 2);
			labelCursorDeltaVal.Name = "labelCursorDeltaVal";
			labelCursorDeltaVal.Size = new System.Drawing.Size(122, 13);
			labelCursorDeltaVal.TabIndex = 33;
			labelCursorDeltaVal.Text = "100.26 us (9974 Hz)";
			labelCursor2.AutoSize = true;
			labelCursor2.Enabled = false;
			labelCursor2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelCursor2.ForeColor = System.Drawing.Color.DarkViolet;
			labelCursor2.Location = new System.Drawing.Point(338, 2);
			labelCursor2.Name = "labelCursor2";
			labelCursor2.Size = new System.Drawing.Size(26, 13);
			labelCursor2.TabIndex = 29;
			labelCursor2.Text = "Y =";
			checkBoxCursors.AutoSize = true;
			checkBoxCursors.Location = new System.Drawing.Point(161, 1);
			checkBoxCursors.Name = "checkBoxCursors";
			checkBoxCursors.Size = new System.Drawing.Size(61, 17);
			checkBoxCursors.TabIndex = 30;
			checkBoxCursors.Text = "Cursors";
			checkBoxCursors.UseVisualStyleBackColor = true;
			checkBoxCursors.CheckedChanged += new System.EventHandler(checkBoxCursors_CheckedChanged);
			labelCursor2Val.AutoSize = true;
			labelCursor2Val.Enabled = false;
			labelCursor2Val.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelCursor2Val.ForeColor = System.Drawing.Color.DarkViolet;
			labelCursor2Val.Location = new System.Drawing.Point(365, 2);
			labelCursor2Val.Name = "labelCursor2Val";
			labelCursor2Val.Size = new System.Drawing.Size(63, 13);
			labelCursor2Val.TabIndex = 31;
			labelCursor2Val.Text = "200.78 us";
			label24.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label24.AutoSize = true;
			label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label24.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			label24.Location = new System.Drawing.Point(3, 297);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(117, 26);
			label24.TabIndex = 29;
			label24.Text = "Set VDD Voltage value\r\nin main form.";
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(84, 157);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(65, 78);
			label23.TabIndex = 28;
			label23.Text = "NOTE:\r\nCh 1 && Ch 2\r\ninputs have \r\n4.7k Ohm\r\npull-down\r\nresistors.";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(3, 265);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(158, 26);
			label22.TabIndex = 27;
			label22.Text = "PICkit 2 VDD MUST connect to\r\ncircuit VDD.";
			groupBox2.Controls.Add(label25);
			groupBox2.Controls.Add(radioButtonTrigDly3);
			groupBox2.Controls.Add(radioButtonTrigDly2);
			groupBox2.Controls.Add(radioButtonTrigDly1);
			groupBox2.Controls.Add(radioButtonTrigEnd);
			groupBox2.Controls.Add(radioButtonTrigMid);
			groupBox2.Controls.Add(radioButtonTrigStart);
			groupBox2.Controls.Add(label21);
			groupBox2.Controls.Add(labelAliasFreq);
			groupBox2.Controls.Add(comboBoxSampleRate);
			groupBox2.Controls.Add(label19);
			groupBox2.Controls.Add(buttonRun);
			groupBox2.Location = new System.Drawing.Point(359, 146);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(251, 180);
			groupBox2.TabIndex = 26;
			groupBox2.TabStop = false;
			groupBox2.Text = "Aquisition";
			label25.AutoSize = true;
			label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label25.Location = new System.Drawing.Point(110, 164);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(135, 13);
			label25.TabIndex = 31;
			label25.Text = "1 Window = 1000 samples.";
			radioButtonTrigDly3.AutoSize = true;
			radioButtonTrigDly3.Location = new System.Drawing.Point(126, 148);
			radioButtonTrigDly3.Name = "radioButtonTrigDly3";
			radioButtonTrigDly3.Size = new System.Drawing.Size(108, 17);
			radioButtonTrigDly3.TabIndex = 30;
			radioButtonTrigDly3.Text = "Delay 3 Windows";
			radioButtonTrigDly3.UseVisualStyleBackColor = true;
			radioButtonTrigDly2.AutoSize = true;
			radioButtonTrigDly2.Location = new System.Drawing.Point(126, 130);
			radioButtonTrigDly2.Name = "radioButtonTrigDly2";
			radioButtonTrigDly2.Size = new System.Drawing.Size(108, 17);
			radioButtonTrigDly2.TabIndex = 29;
			radioButtonTrigDly2.Text = "Delay 2 Windows";
			radioButtonTrigDly2.UseVisualStyleBackColor = true;
			radioButtonTrigDly1.AutoSize = true;
			radioButtonTrigDly1.Location = new System.Drawing.Point(126, 112);
			radioButtonTrigDly1.Name = "radioButtonTrigDly1";
			radioButtonTrigDly1.Size = new System.Drawing.Size(103, 17);
			radioButtonTrigDly1.TabIndex = 28;
			radioButtonTrigDly1.Text = "Delay 1 Window";
			radioButtonTrigDly1.UseVisualStyleBackColor = true;
			radioButtonTrigEnd.AutoSize = true;
			radioButtonTrigEnd.Location = new System.Drawing.Point(9, 148);
			radioButtonTrigEnd.Name = "radioButtonTrigEnd";
			radioButtonTrigEnd.Size = new System.Drawing.Size(82, 17);
			radioButtonTrigEnd.TabIndex = 27;
			radioButtonTrigEnd.Text = "End of Data";
			radioButtonTrigEnd.UseVisualStyleBackColor = true;
			radioButtonTrigMid.AutoSize = true;
			radioButtonTrigMid.Location = new System.Drawing.Point(9, 130);
			radioButtonTrigMid.Name = "radioButtonTrigMid";
			radioButtonTrigMid.Size = new System.Drawing.Size(94, 17);
			radioButtonTrigMid.TabIndex = 26;
			radioButtonTrigMid.Text = "Center of Data";
			radioButtonTrigMid.UseVisualStyleBackColor = true;
			radioButtonTrigStart.AutoSize = true;
			radioButtonTrigStart.Checked = true;
			radioButtonTrigStart.Location = new System.Drawing.Point(9, 112);
			radioButtonTrigStart.Name = "radioButtonTrigStart";
			radioButtonTrigStart.Size = new System.Drawing.Size(85, 17);
			radioButtonTrigStart.TabIndex = 25;
			radioButtonTrigStart.TabStop = true;
			radioButtonTrigStart.Text = "Start of Data";
			radioButtonTrigStart.UseVisualStyleBackColor = true;
			label21.AutoSize = true;
			label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label21.Location = new System.Drawing.Point(6, 89);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(113, 15);
			label21.TabIndex = 24;
			label21.Text = "Trigger Position:";
			labelAliasFreq.AutoSize = true;
			labelAliasFreq.Location = new System.Drawing.Point(6, 63);
			labelAliasFreq.Name = "labelAliasFreq";
			labelAliasFreq.Size = new System.Drawing.Size(224, 13);
			labelAliasFreq.TabIndex = 23;
			labelAliasFreq.Text = "NOTE: Signals greater than 500 kHz will alias.";
			comboBoxSampleRate.FormattingEnabled = true;
			comboBoxSampleRate.Items.AddRange(new object[8]
			{
				"1 MHz - 1 ms Window",
				"500 kHz - 2 ms Window",
				"250 kHz - 4 ms Window",
				"100 kHz - 10 ms Window",
				"50 kHz - 20 ms Window",
				"25 kHz - 40 ms Window",
				"10 kHz - 100 ms Window",
				"5 kHz - 200 ms Window"
			});
			comboBoxSampleRate.Location = new System.Drawing.Point(9, 37);
			comboBoxSampleRate.Name = "comboBoxSampleRate";
			comboBoxSampleRate.Size = new System.Drawing.Size(168, 21);
			comboBoxSampleRate.TabIndex = 22;
			comboBoxSampleRate.SelectedIndexChanged += new System.EventHandler(comboBoxSampleRate_SelectedIndexChanged);
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label19.Location = new System.Drawing.Point(6, 16);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(94, 15);
			label19.TabIndex = 21;
			label19.Text = "Sample Rate:";
			buttonRun.Location = new System.Drawing.Point(189, 13);
			buttonRun.Name = "buttonRun";
			buttonRun.Size = new System.Drawing.Size(56, 45);
			buttonRun.TabIndex = 0;
			buttonRun.Text = "RUN";
			buttonRun.UseVisualStyleBackColor = true;
			buttonRun.Click += new System.EventHandler(buttonRun_Click);
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(0, 146);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(78, 116);
			pictureBox1.TabIndex = 25;
			pictureBox1.TabStop = false;
			groupBox1.Controls.Add(label18);
			groupBox1.Controls.Add(label17);
			groupBox1.Controls.Add(label15);
			groupBox1.Controls.Add(textBox1);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(label16);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(label14);
			groupBox1.Controls.Add(comboBoxCh1Trig);
			groupBox1.Controls.Add(label13);
			groupBox1.Controls.Add(comboBoxCh2Trig);
			groupBox1.Controls.Add(label12);
			groupBox1.Controls.Add(comboBoxCh3Trig);
			groupBox1.Controls.Add(label11);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(label10);
			groupBox1.Controls.Add(label9);
			groupBox1.Location = new System.Drawing.Point(167, 146);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(186, 180);
			groupBox1.TabIndex = 24;
			groupBox1.TabStop = false;
			groupBox1.Text = "Trigger";
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label18.Location = new System.Drawing.Point(51, 164);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(46, 13);
			label18.TabIndex = 24;
			label18.Text = "(1 - 256)";
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label17.Location = new System.Drawing.Point(102, 144);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(46, 15);
			label17.TabIndex = 23;
			label17.Text = "times.";
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label15.Location = new System.Drawing.Point(6, 16);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(91, 15);
			label15.TabIndex = 20;
			label15.Text = "Trigger when";
			textBox1.Location = new System.Drawing.Point(53, 143);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(43, 20);
			textBox1.TabIndex = 22;
			textBox1.Text = "1";
			textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1.Leave += new System.EventHandler(textBox1_Leave);
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(6, 48);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(45, 15);
			label5.TabIndex = 7;
			label5.Text = "Ch 1 = ";
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label16.Location = new System.Drawing.Point(6, 144);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(49, 15);
			label16.TabIndex = 21;
			label16.Text = "occurs";
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(6, 79);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(45, 15);
			label6.TabIndex = 8;
			label6.Text = "Ch 2 = ";
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(6, 111);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(45, 15);
			label7.TabIndex = 9;
			label7.Text = "Ch 3 = ";
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(102, 63);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(73, 13);
			label14.TabIndex = 19;
			label14.Text = "1 - Logic High";
			comboBoxCh1Trig.FormattingEnabled = true;
			comboBoxCh1Trig.Items.AddRange(new object[5]
			{
				"*",
				"1",
				"0",
				"/",
				"\\"
			});
			comboBoxCh1Trig.Location = new System.Drawing.Point(53, 45);
			comboBoxCh1Trig.Name = "comboBoxCh1Trig";
			comboBoxCh1Trig.Size = new System.Drawing.Size(43, 21);
			comboBoxCh1Trig.TabIndex = 10;
			comboBoxCh1Trig.SelectedIndexChanged += new System.EventHandler(comboBoxCh1Trig_SelectedIndexChanged);
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(102, 81);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(71, 13);
			label13.TabIndex = 18;
			label13.Text = "0 - Logic Low";
			comboBoxCh2Trig.FormattingEnabled = true;
			comboBoxCh2Trig.Items.AddRange(new object[5]
			{
				"*",
				"1",
				"0",
				"/",
				"\\"
			});
			comboBoxCh2Trig.Location = new System.Drawing.Point(53, 76);
			comboBoxCh2Trig.Name = "comboBoxCh2Trig";
			comboBoxCh2Trig.Size = new System.Drawing.Size(43, 21);
			comboBoxCh2Trig.TabIndex = 11;
			comboBoxCh2Trig.SelectedIndexChanged += new System.EventHandler(comboBoxCh2Trig_SelectedIndexChanged);
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(102, 99);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(78, 13);
			label12.TabIndex = 17;
			label12.Text = "/ - Rising Edge";
			comboBoxCh3Trig.FormattingEnabled = true;
			comboBoxCh3Trig.Items.AddRange(new object[5]
			{
				"*",
				"1",
				"0",
				"/",
				"\\"
			});
			comboBoxCh3Trig.Location = new System.Drawing.Point(53, 108);
			comboBoxCh3Trig.Name = "comboBoxCh3Trig";
			comboBoxCh3Trig.Size = new System.Drawing.Size(43, 21);
			comboBoxCh3Trig.TabIndex = 12;
			comboBoxCh3Trig.SelectedIndexChanged += new System.EventHandler(comboBoxCh3Trig_SelectedIndexChanged);
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(102, 117);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(79, 13);
			label11.TabIndex = 16;
			label11.Text = "\\ - Falling Edge";
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(22, 63);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(25, 13);
			label8.TabIndex = 13;
			label8.Text = "and";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(102, 45);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(70, 13);
			label10.TabIndex = 15;
			label10.Text = "* - Don't Care";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(22, 94);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(25, 13);
			label9.TabIndex = 14;
			label9.Text = "and";
			groupBoxZoom.Controls.Add(radioButton4x);
			groupBoxZoom.Controls.Add(radioButtonZoom05);
			groupBoxZoom.Controls.Add(radioButton2x);
			groupBoxZoom.Controls.Add(radioButtonZoom1x);
			groupBoxZoom.Location = new System.Drawing.Point(542, 13);
			groupBoxZoom.Name = "groupBoxZoom";
			groupBoxZoom.Size = new System.Drawing.Size(68, 100);
			groupBoxZoom.TabIndex = 6;
			groupBoxZoom.TabStop = false;
			groupBoxZoom.Text = "Zoom";
			radioButton4x.AutoSize = true;
			radioButton4x.Location = new System.Drawing.Point(9, 73);
			radioButton4x.Name = "radioButton4x";
			radioButton4x.Size = new System.Drawing.Size(36, 17);
			radioButton4x.TabIndex = 10;
			radioButton4x.Text = "4x";
			radioButton4x.UseVisualStyleBackColor = true;
			radioButton4x.Click += new System.EventHandler(radioButtonZoom05_Click);
			radioButtonZoom05.AutoSize = true;
			radioButtonZoom05.Location = new System.Drawing.Point(9, 19);
			radioButtonZoom05.Name = "radioButtonZoom05";
			radioButtonZoom05.Size = new System.Drawing.Size(45, 17);
			radioButtonZoom05.TabIndex = 7;
			radioButtonZoom05.Text = "0.5x";
			radioButtonZoom05.UseVisualStyleBackColor = true;
			radioButtonZoom05.Click += new System.EventHandler(radioButtonZoom05_Click);
			radioButton2x.AutoSize = true;
			radioButton2x.Location = new System.Drawing.Point(9, 55);
			radioButton2x.Name = "radioButton2x";
			radioButton2x.Size = new System.Drawing.Size(36, 17);
			radioButton2x.TabIndex = 9;
			radioButton2x.Text = "2x";
			radioButton2x.UseVisualStyleBackColor = true;
			radioButton2x.Click += new System.EventHandler(radioButtonZoom05_Click);
			radioButtonZoom1x.AutoSize = true;
			radioButtonZoom1x.Checked = true;
			radioButtonZoom1x.Location = new System.Drawing.Point(9, 37);
			radioButtonZoom1x.Name = "radioButtonZoom1x";
			radioButtonZoom1x.Size = new System.Drawing.Size(36, 17);
			radioButtonZoom1x.TabIndex = 8;
			radioButtonZoom1x.TabStop = true;
			radioButtonZoom1x.Text = "1x";
			radioButtonZoom1x.UseVisualStyleBackColor = true;
			radioButtonZoom1x.Click += new System.EventHandler(radioButtonZoom05_Click);
			labelTimeScale.AutoSize = true;
			labelTimeScale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelTimeScale.Location = new System.Drawing.Point(33, 0);
			labelTimeScale.Name = "labelTimeScale";
			labelTimeScale.Size = new System.Drawing.Size(70, 15);
			labelTimeScale.TabIndex = 5;
			labelTimeScale.Text = "50us / Div";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(1, 95);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(29, 13);
			label4.TabIndex = 4;
			label4.Text = "Ch.3";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(1, 65);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(29, 13);
			label3.TabIndex = 3;
			label3.Text = "Ch.2";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(1, 35);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(29, 13);
			label1.TabIndex = 2;
			label1.Text = "Ch.1";
			panelDisplay.AutoScroll = true;
			panelDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			panelDisplay.Controls.Add(pictureBoxDisplay);
			panelDisplay.Location = new System.Drawing.Point(36, 20);
			panelDisplay.Name = "panelDisplay";
			panelDisplay.Size = new System.Drawing.Size(500, 122);
			panelDisplay.TabIndex = 1;
			pictureBoxDisplay.Location = new System.Drawing.Point(0, 0);
			pictureBoxDisplay.Name = "pictureBoxDisplay";
			pictureBoxDisplay.Size = new System.Drawing.Size(1024, 100);
			pictureBoxDisplay.TabIndex = 0;
			pictureBoxDisplay.TabStop = false;
			pictureBoxDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(pictureBoxDisplay_MouseDown);
			buttonExit.Location = new System.Drawing.Point(508, 371);
			buttonExit.Name = "buttonExit";
			buttonExit.Size = new System.Drawing.Size(116, 23);
			buttonExit.TabIndex = 27;
			buttonExit.Text = "Exit Logic Tool";
			buttonExit.UseVisualStyleBackColor = true;
			buttonExit.Click += new System.EventHandler(buttonExit_Click);
			buttonHelp.Location = new System.Drawing.Point(12, 371);
			buttonHelp.Name = "buttonHelp";
			buttonHelp.Size = new System.Drawing.Size(56, 23);
			buttonHelp.TabIndex = 32;
			buttonHelp.Text = "Help";
			buttonHelp.UseVisualStyleBackColor = true;
			buttonHelp.Click += new System.EventHandler(buttonHelp_Click);
			timerRun.Interval = 250;
			timerRun.Tick += new System.EventHandler(timerRun_Tick);
			saveFileDialogDisplay.DefaultExt = "bmp";
			saveFileDialogDisplay.Filter = "Bitmap(.bmp)|*.bmp";
			saveFileDialogDisplay.InitialDirectory = "c:\\";
			saveFileDialogDisplay.Title = "Save Logic Analyzer Display";
			panelLogicIO.Controls.Add(checkBoxIOEnable);
			panelLogicIO.Controls.Add(labelOut6Click);
			panelLogicIO.Controls.Add(labelOut5Click);
			panelLogicIO.Controls.Add(labelOut4Click);
			panelLogicIO.Controls.Add(labelOut1Click);
			panelLogicIO.Controls.Add(textBoxPin6Out);
			panelLogicIO.Controls.Add(textBoxPin6In);
			panelLogicIO.Controls.Add(textBoxPin5Out);
			panelLogicIO.Controls.Add(textBoxPin5In);
			panelLogicIO.Controls.Add(textBoxPin4Out);
			panelLogicIO.Controls.Add(textBoxPin1Out);
			panelLogicIO.Controls.Add(label34);
			panelLogicIO.Controls.Add(label33);
			panelLogicIO.Controls.Add(textBoxPin4In);
			panelLogicIO.Controls.Add(label32);
			panelLogicIO.Controls.Add(label31);
			panelLogicIO.Controls.Add(panel4);
			panelLogicIO.Controls.Add(panel3);
			panelLogicIO.Controls.Add(panel1);
			panelLogicIO.Controls.Add(label30);
			panelLogicIO.Controls.Add(label29);
			panelLogicIO.Controls.Add(label28);
			panelLogicIO.Controls.Add(label27);
			panelLogicIO.Controls.Add(label26);
			panelLogicIO.Controls.Add(label20);
			panelLogicIO.Controls.Add(pictureBox2);
			panelLogicIO.Location = new System.Drawing.Point(12, 39);
			panelLogicIO.Name = "panelLogicIO";
			panelLogicIO.Size = new System.Drawing.Size(610, 326);
			panelLogicIO.TabIndex = 33;
			checkBoxIOEnable.Appearance = System.Windows.Forms.Appearance.Button;
			checkBoxIOEnable.Location = new System.Drawing.Point(515, 277);
			checkBoxIOEnable.Name = "checkBoxIOEnable";
			checkBoxIOEnable.Size = new System.Drawing.Size(78, 34);
			checkBoxIOEnable.TabIndex = 52;
			checkBoxIOEnable.Text = "Enable IO";
			checkBoxIOEnable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			checkBoxIOEnable.UseVisualStyleBackColor = true;
			checkBoxIOEnable.CheckedChanged += new System.EventHandler(checkBoxIOEnable_CheckedChanged);
			labelOut6Click.AutoSize = true;
			labelOut6Click.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelOut6Click.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			labelOut6Click.Location = new System.Drawing.Point(419, 243);
			labelOut6Click.Name = "labelOut6Click";
			labelOut6Click.Size = new System.Drawing.Size(178, 13);
			labelOut6Click.TabIndex = 51;
			labelOut6Click.Text = "<- Click Output box or press <F> key";
			labelOut5Click.AutoSize = true;
			labelOut5Click.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelOut5Click.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			labelOut5Click.Location = new System.Drawing.Point(419, 177);
			labelOut5Click.Name = "labelOut5Click";
			labelOut5Click.Size = new System.Drawing.Size(180, 13);
			labelOut5Click.TabIndex = 50;
			labelOut5Click.Text = "<- Click Output box or press <D> key";
			labelOut4Click.AutoSize = true;
			labelOut4Click.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelOut4Click.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			labelOut4Click.Location = new System.Drawing.Point(419, 111);
			labelOut4Click.Name = "labelOut4Click";
			labelOut4Click.Size = new System.Drawing.Size(179, 13);
			labelOut4Click.TabIndex = 49;
			labelOut4Click.Text = "<- Click Output box or press <S> key";
			labelOut1Click.AutoSize = true;
			labelOut1Click.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelOut1Click.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			labelOut1Click.Location = new System.Drawing.Point(419, 45);
			labelOut1Click.Name = "labelOut1Click";
			labelOut1Click.Size = new System.Drawing.Size(179, 13);
			labelOut1Click.TabIndex = 48;
			labelOut1Click.Text = "<- Click Output box or press <A> key";
			textBoxPin6Out.BackColor = System.Drawing.SystemColors.Control;
			textBoxPin6Out.Cursor = System.Windows.Forms.Cursors.Hand;
			textBoxPin6Out.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			textBoxPin6Out.ForeColor = System.Drawing.SystemColors.Window;
			textBoxPin6Out.Location = new System.Drawing.Point(350, 237);
			textBoxPin6Out.Name = "textBoxPin6Out";
			textBoxPin6Out.ReadOnly = true;
			textBoxPin6Out.Size = new System.Drawing.Size(30, 29);
			textBoxPin6Out.TabIndex = 47;
			textBoxPin6Out.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBoxPin6Out.Click += new System.EventHandler(textBoxPin6Out_Click);
			textBoxPin6In.BackColor = System.Drawing.SystemColors.Control;
			textBoxPin6In.Cursor = System.Windows.Forms.Cursors.Default;
			textBoxPin6In.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			textBoxPin6In.ForeColor = System.Drawing.SystemColors.Window;
			textBoxPin6In.Location = new System.Drawing.Point(266, 239);
			textBoxPin6In.Name = "textBoxPin6In";
			textBoxPin6In.ReadOnly = true;
			textBoxPin6In.Size = new System.Drawing.Size(30, 29);
			textBoxPin6In.TabIndex = 46;
			textBoxPin6In.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBoxPin5Out.BackColor = System.Drawing.Color.Red;
			textBoxPin5Out.Cursor = System.Windows.Forms.Cursors.Hand;
			textBoxPin5Out.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			textBoxPin5Out.ForeColor = System.Drawing.SystemColors.Window;
			textBoxPin5Out.Location = new System.Drawing.Point(350, 173);
			textBoxPin5Out.Name = "textBoxPin5Out";
			textBoxPin5Out.ReadOnly = true;
			textBoxPin5Out.Size = new System.Drawing.Size(30, 29);
			textBoxPin5Out.TabIndex = 45;
			textBoxPin5Out.Text = "1";
			textBoxPin5Out.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBoxPin5Out.Click += new System.EventHandler(textBoxPin5Out_Click);
			textBoxPin5In.BackColor = System.Drawing.Color.DodgerBlue;
			textBoxPin5In.Cursor = System.Windows.Forms.Cursors.Default;
			textBoxPin5In.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			textBoxPin5In.ForeColor = System.Drawing.SystemColors.Window;
			textBoxPin5In.Location = new System.Drawing.Point(266, 173);
			textBoxPin5In.Name = "textBoxPin5In";
			textBoxPin5In.ReadOnly = true;
			textBoxPin5In.Size = new System.Drawing.Size(30, 29);
			textBoxPin5In.TabIndex = 44;
			textBoxPin5In.Text = "1";
			textBoxPin5In.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBoxPin4Out.BackColor = System.Drawing.Color.DarkRed;
			textBoxPin4Out.Cursor = System.Windows.Forms.Cursors.Hand;
			textBoxPin4Out.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			textBoxPin4Out.ForeColor = System.Drawing.SystemColors.Window;
			textBoxPin4Out.Location = new System.Drawing.Point(350, 107);
			textBoxPin4Out.Name = "textBoxPin4Out";
			textBoxPin4Out.ReadOnly = true;
			textBoxPin4Out.Size = new System.Drawing.Size(30, 29);
			textBoxPin4Out.TabIndex = 43;
			textBoxPin4Out.Text = "0";
			textBoxPin4Out.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBoxPin4Out.Click += new System.EventHandler(textBoxPin4Out_Click);
			textBoxPin1Out.BackColor = System.Drawing.Color.DarkRed;
			textBoxPin1Out.Cursor = System.Windows.Forms.Cursors.Hand;
			textBoxPin1Out.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			textBoxPin1Out.ForeColor = System.Drawing.SystemColors.Window;
			textBoxPin1Out.Location = new System.Drawing.Point(350, 39);
			textBoxPin1Out.Name = "textBoxPin1Out";
			textBoxPin1Out.ReadOnly = true;
			textBoxPin1Out.Size = new System.Drawing.Size(30, 29);
			textBoxPin1Out.TabIndex = 42;
			textBoxPin1Out.Text = "0";
			textBoxPin1Out.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBoxPin1Out.Click += new System.EventHandler(textBoxPin1Out_Click);
			label34.AutoSize = true;
			label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
			label34.Location = new System.Drawing.Point(260, 13);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(49, 16);
			label34.TabIndex = 41;
			label34.Text = "Inputs";
			label33.AutoSize = true;
			label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
			label33.Location = new System.Drawing.Point(338, 13);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(60, 16);
			label33.TabIndex = 40;
			label33.Text = "Outputs";
			textBoxPin4In.BackColor = System.Drawing.Color.DarkBlue;
			textBoxPin4In.Cursor = System.Windows.Forms.Cursors.Default;
			textBoxPin4In.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			textBoxPin4In.ForeColor = System.Drawing.SystemColors.Window;
			textBoxPin4In.Location = new System.Drawing.Point(266, 107);
			textBoxPin4In.Name = "textBoxPin4In";
			textBoxPin4In.ReadOnly = true;
			textBoxPin4In.Size = new System.Drawing.Size(30, 29);
			textBoxPin4In.TabIndex = 38;
			textBoxPin4In.Text = "0";
			textBoxPin4In.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			label32.AutoSize = true;
			label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label32.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			label32.Location = new System.Drawing.Point(108, 197);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(53, 26);
			label32.TabIndex = 37;
			label32.Text = "4.7k Ohm\r\npulldown";
			label31.AutoSize = true;
			label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label31.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			label31.Location = new System.Drawing.Point(108, 131);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(53, 26);
			label31.TabIndex = 36;
			label31.Text = "4.7k Ohm\r\npulldown";
			panel4.Controls.Add(radioButtonPin6In);
			panel4.Controls.Add(radioButtonPin6Out);
			panel4.Location = new System.Drawing.Point(170, 233);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(60, 45);
			panel4.TabIndex = 35;
			radioButtonPin6In.AutoSize = true;
			radioButtonPin6In.Checked = true;
			radioButtonPin6In.Enabled = false;
			radioButtonPin6In.Location = new System.Drawing.Point(3, 21);
			radioButtonPin6In.Name = "radioButtonPin6In";
			radioButtonPin6In.Size = new System.Drawing.Size(49, 17);
			radioButtonPin6In.TabIndex = 1;
			radioButtonPin6In.TabStop = true;
			radioButtonPin6In.Text = "Input";
			radioButtonPin6In.UseVisualStyleBackColor = true;
			radioButtonPin6Out.AutoSize = true;
			radioButtonPin6Out.Enabled = false;
			radioButtonPin6Out.Location = new System.Drawing.Point(3, 3);
			radioButtonPin6Out.Name = "radioButtonPin6Out";
			radioButtonPin6Out.Size = new System.Drawing.Size(57, 17);
			radioButtonPin6Out.TabIndex = 0;
			radioButtonPin6Out.Text = "Output";
			radioButtonPin6Out.UseVisualStyleBackColor = true;
			radioButtonPin6Out.CheckedChanged += new System.EventHandler(radioButtonPin6Out_CheckedChanged);
			panel3.Controls.Add(radioButtonPin5In);
			panel3.Controls.Add(radioButtonPin5Out);
			panel3.Location = new System.Drawing.Point(170, 167);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(60, 45);
			panel3.TabIndex = 34;
			radioButtonPin5In.AutoSize = true;
			radioButtonPin5In.Checked = true;
			radioButtonPin5In.Enabled = false;
			radioButtonPin5In.Location = new System.Drawing.Point(3, 21);
			radioButtonPin5In.Name = "radioButtonPin5In";
			radioButtonPin5In.Size = new System.Drawing.Size(49, 17);
			radioButtonPin5In.TabIndex = 1;
			radioButtonPin5In.TabStop = true;
			radioButtonPin5In.Text = "Input";
			radioButtonPin5In.UseVisualStyleBackColor = true;
			radioButtonPin5Out.AutoSize = true;
			radioButtonPin5Out.Enabled = false;
			radioButtonPin5Out.Location = new System.Drawing.Point(3, 3);
			radioButtonPin5Out.Name = "radioButtonPin5Out";
			radioButtonPin5Out.Size = new System.Drawing.Size(57, 17);
			radioButtonPin5Out.TabIndex = 0;
			radioButtonPin5Out.Text = "Output";
			radioButtonPin5Out.UseVisualStyleBackColor = true;
			radioButtonPin5Out.CheckedChanged += new System.EventHandler(radioButtonPin5Out_CheckedChanged);
			panel1.Controls.Add(radioButtonPin4In);
			panel1.Controls.Add(radioButtonPin4Out);
			panel1.Location = new System.Drawing.Point(170, 101);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(60, 45);
			panel1.TabIndex = 33;
			radioButtonPin4In.AutoSize = true;
			radioButtonPin4In.Checked = true;
			radioButtonPin4In.Enabled = false;
			radioButtonPin4In.Location = new System.Drawing.Point(3, 21);
			radioButtonPin4In.Name = "radioButtonPin4In";
			radioButtonPin4In.Size = new System.Drawing.Size(49, 17);
			radioButtonPin4In.TabIndex = 1;
			radioButtonPin4In.TabStop = true;
			radioButtonPin4In.Text = "Input";
			radioButtonPin4In.UseVisualStyleBackColor = true;
			radioButtonPin4Out.AutoSize = true;
			radioButtonPin4Out.Enabled = false;
			radioButtonPin4Out.Location = new System.Drawing.Point(3, 3);
			radioButtonPin4Out.Name = "radioButtonPin4Out";
			radioButtonPin4Out.Size = new System.Drawing.Size(57, 17);
			radioButtonPin4Out.TabIndex = 0;
			radioButtonPin4Out.Text = "Output";
			radioButtonPin4Out.UseVisualStyleBackColor = true;
			radioButtonPin4Out.CheckedChanged += new System.EventHandler(radioButtonPin4Out_CheckedChanged);
			label30.AutoSize = true;
			label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label30.Location = new System.Drawing.Point(167, 50);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(63, 13);
			label30.TabIndex = 32;
			label30.Text = "Output Only";
			label29.AutoSize = true;
			label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label29.Location = new System.Drawing.Point(106, 243);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(49, 20);
			label29.TabIndex = 31;
			label29.Text = "Pin 6";
			label28.AutoSize = true;
			label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label28.Location = new System.Drawing.Point(106, 177);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(49, 20);
			label28.TabIndex = 30;
			label28.Text = "Pin 5";
			label27.AutoSize = true;
			label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label27.Location = new System.Drawing.Point(106, 111);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(49, 20);
			label27.TabIndex = 29;
			label27.Text = "Pin 4";
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(-3, 300);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(356, 26);
			label26.TabIndex = 28;
			label26.Text = "PICkit 2 VDD pin MUST have a valid voltage (either sourced from PICkit 2\r\nor the target) or pins 4, 5, && 6 will not function.";
			label20.AutoSize = true;
			label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label20.Location = new System.Drawing.Point(106, 45);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(49, 20);
			label20.TabIndex = 27;
			label20.Text = "Pin 1";
			pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new System.Drawing.Point(0, 106);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(78, 116);
			pictureBox2.TabIndex = 26;
			pictureBox2.TabStop = false;
			timerIO.Tick += new System.EventHandler(timerIO_Tick);
			checkBoxVDD.AutoSize = true;
			checkBoxVDD.Location = new System.Drawing.Point(12, 16);
			checkBoxVDD.Name = "checkBoxVDD";
			checkBoxVDD.Size = new System.Drawing.Size(66, 17);
			checkBoxVDD.TabIndex = 34;
			checkBoxVDD.Text = "VDD On";
			checkBoxVDD.UseVisualStyleBackColor = true;
			checkBoxVDD.Click += new System.EventHandler(checkBoxVDD_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(634, 401);
			base.Controls.Add(checkBoxVDD);
			base.Controls.Add(panelLogicIO);
			base.Controls.Add(buttonHelp);
			base.Controls.Add(buttonExit);
			base.Controls.Add(panelAnalyzer);
			base.Controls.Add(label2);
			base.Controls.Add(panel2);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.KeyPreview = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DialogLogic";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "PICkit 2 Logic Tool";
			panel2.ResumeLayout(false);
			panelAnalyzer.ResumeLayout(false);
			panelAnalyzer.PerformLayout();
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			groupBoxZoom.ResumeLayout(false);
			groupBoxZoom.PerformLayout();
			panelDisplay.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBoxDisplay).EndInit();
			panelLogicIO.ResumeLayout(false);
			panelLogicIO.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public DialogLogic()
		{
			InitializeComponent();
			base.KeyPress += DialogLogic_KeyPress;
			for (int i = 0; i < 1024; i++)
			{
				sampleArray[i] = 0;
			}
			initLogicIO();
			comboBoxCh1Trig.SelectedIndex = 0;
			comboBoxCh2Trig.SelectedIndex = 0;
			comboBoxCh3Trig.SelectedIndex = 0;
			comboBoxSampleRate.SelectedIndex = 0;
			labelCursor1Val.Text = "0 us";
			labelCursor2Val.Text = "0 us";
			labelCursorDeltaVal.Text = "0 us";
			updateDisplay();
		}

		public bool getModeAnalyzer()
		{
			return radioButtonAnalyzer.Checked;
		}

		public void setModeAnalyzer()
		{
			radioButtonLogicIO.Checked = false;
			radioButtonAnalyzer.Checked = true;
		}

		public int getZoom()
		{
			return lastZoomLevel;
		}

		public void setZoom(int zoom)
		{
			lastZoomLevel = zoom;
			if (zoom != 1)
			{
				radioButtonZoom1x.Checked = false;
				switch (zoom)
				{
				case 0:
					radioButtonZoom05.Checked = true;
					break;
				case 2:
					radioButton2x.Checked = true;
					break;
				case 3:
					radioButton4x.Checked = true;
					break;
				}
				updateDisplay();
			}
		}

		public int getCh1Trigger()
		{
			return comboBoxCh1Trig.SelectedIndex;
		}

		public void setCh1Trigger(int trig)
		{
			comboBoxCh1Trig.SelectedIndex = trig;
		}

		public int getCh2Trigger()
		{
			return comboBoxCh2Trig.SelectedIndex;
		}

		public void setCh2Trigger(int trig)
		{
			comboBoxCh2Trig.SelectedIndex = trig;
		}

		public int getCh3Trigger()
		{
			return comboBoxCh3Trig.SelectedIndex;
		}

		public void setCh3Trigger(int trig)
		{
			comboBoxCh3Trig.SelectedIndex = trig;
		}

		public int getTrigCount()
		{
			return int.Parse(textBox1.Text);
		}

		public void setTrigCount(int count)
		{
			textBox1.Text = count.ToString();
		}

		public int getSampleRate()
		{
			return comboBoxSampleRate.SelectedIndex;
		}

		public void setSampleRate(int rate)
		{
			comboBoxSampleRate.SelectedIndex = rate;
		}

		public int getTriggerPosition()
		{
			int result = 0;
			if (radioButtonTrigMid.Checked)
			{
				result = 1;
			}
			else if (radioButtonTrigEnd.Checked)
			{
				result = 2;
			}
			else if (radioButtonTrigDly1.Checked)
			{
				result = 3;
			}
			else if (radioButtonTrigDly2.Checked)
			{
				result = 4;
			}
			else if (radioButtonTrigDly3.Checked)
			{
				result = 5;
			}
			return result;
		}

		public void setTriggerPosition(int trigpos)
		{
			if (trigpos > 0)
			{
				radioButtonTrigStart.Checked = false;
				switch (trigpos)
				{
				case 1:
					radioButtonTrigMid.Checked = true;
					break;
				case 2:
					radioButtonTrigEnd.Checked = true;
					break;
				case 3:
					radioButtonTrigDly1.Checked = true;
					break;
				case 4:
					radioButtonTrigDly2.Checked = true;
					break;
				case 5:
					radioButtonTrigDly3.Checked = true;
					break;
				}
				updateDisplay();
			}
		}

		public bool getCursorsEnabled()
		{
			return checkBoxCursors.Checked;
		}

		public void setCursorsEnabled(bool enable)
		{
			checkBoxCursors.Checked = enable;
		}

		public int getXCursorPos()
		{
			return cursor1Pos;
		}

		public void setXCursorPos(int pos)
		{
			cursor1Pos = pos;
			updateDisplay();
		}

		public int getYCursorPos()
		{
			return cursor2Pos;
		}

		public void setYCursorPos(int pos)
		{
			cursor2Pos = pos;
			updateDisplay();
		}

		public void SetVddBox(bool enable, bool check)
		{
			checkBoxVDD.Enabled = enable;
			checkBoxVDD.Checked = check;
		}

		private void updateDisplay()
		{
			Bitmap bitmap = drawSampleData(lastZoomLevel, lastTrigPos, firstSample);
			pictureBoxDisplay.Width = bitmap.Width;
			if (!checkBoxCursors.Checked)
			{
				pictureBoxDisplay.Image = bitmap;
			}
			lastDrawnDisplay = bitmap;
			updateDisplayCursors();
			float num = sampleRates[lastSampleRate];
			num *= 50f;
			if (lastZoomLevel == 0)
			{
				num *= 2f;
			}
			else if (lastZoomLevel == 2)
			{
				num /= 2f;
			}
			else if (lastZoomLevel == 3)
			{
				num /= 4f;
			}
			string str = "s";
			if (num < 0.001f)
			{
				num *= 1000000f;
				str = "us";
			}
			else if (num < 1f)
			{
				num *= 1000f;
				str = "ms";
			}
			labelTimeScale.Text = $"{num:G} " + str + " / Div";
		}

		private Bitmap drawSampleData(int zoom, int triggerPos, int startPos)
		{
			int num = 100;
			int num2 = 1;
			switch (zoom)
			{
			case 0:
				triggerPos /= 2;
				num2 = 0;
				break;
			case 2:
				triggerPos *= 2;
				num2 = 2;
				break;
			case 3:
				triggerPos *= 4;
				num2 = 4;
				break;
			}
			Bitmap displayGraph = getDisplayGraph(zoom);
			Graphics graphics = Graphics.FromImage(displayGraph);
			SolidBrush solidBrush = new SolidBrush(Color.Red);
			graphics.FillRectangle(solidBrush, triggerPos, 0, 1, num);
			graphics.FillRectangle(solidBrush, triggerPos - 2, 4, 5, 2);
			graphics.FillRectangle(solidBrush, triggerPos - 2, num - 5, 5, 2);
			if (lastTrigDelay > 0)
			{
				solidBrush = new SolidBrush(Color.White);
				graphics.FillPolygon(solidBrush, new Point[3]
				{
					new Point(triggerPos - 4, 0),
					new Point(triggerPos - 4, 8),
					new Point(triggerPos - 9, 4)
				});
				float num3 = sampleRates[lastSampleRate] * 1000f * (float)lastTrigDelay;
				Font font = new Font(FontFamily.GenericSansSerif, 7f, FontStyle.Bold);
				string str = "s";
				if (num3 < 0.001f)
				{
					num3 *= 1000000f;
					str = "us";
				}
				else if (num3 < 1f)
				{
					num3 *= 1000f;
					str = "ms";
				}
				graphics.DrawString($"DLY {num3:G} " + str, font, solidBrush, triggerPos + 3, -2f);
				font.Dispose();
			}
			solidBrush.Dispose();
			SolidBrush solidBrush2 = new SolidBrush(Color.LimeGreen);
			int num4 = 0;
			byte b = sampleArray[0];
			if (num2 > 0)
			{
				for (int i = 0; i < 1024; i++)
				{
					if (((sampleArray[i] & 1) ^ (b & 1)) > 0)
					{
						graphics.FillRectangle(solidBrush2, num4, 10, 1, 20);
						if (num2 > 1)
						{
							if ((sampleArray[i] & 1) == 0)
							{
								graphics.FillRectangle(solidBrush2, num4 + 1, 27, num2 - 1, 3);
							}
							else
							{
								graphics.FillRectangle(solidBrush2, num4 + 1, 10, num2 - 1, 1);
							}
						}
					}
					else if ((sampleArray[i] & 1) == 0)
					{
						graphics.FillRectangle(solidBrush2, num4, 27, num2, 3);
					}
					else
					{
						graphics.FillRectangle(solidBrush2, num4, 10, num2, 1);
					}
					if (((sampleArray[i] & 2) ^ (b & 2)) > 0)
					{
						graphics.FillRectangle(solidBrush2, num4, 40, 1, 20);
						if (num2 > 1)
						{
							if ((sampleArray[i] & 2) == 0)
							{
								graphics.FillRectangle(solidBrush2, num4 + 1, 57, num2 - 1, 3);
							}
							else
							{
								graphics.FillRectangle(solidBrush2, num4 + 1, 40, num2 - 1, 1);
							}
						}
					}
					else if ((sampleArray[i] & 2) == 0)
					{
						graphics.FillRectangle(solidBrush2, num4, 57, num2, 3);
					}
					else
					{
						graphics.FillRectangle(solidBrush2, num4, 40, num2, 1);
					}
					if (((sampleArray[i] & 4) ^ (b & 4)) > 0)
					{
						graphics.FillRectangle(solidBrush2, num4, 70, 1, 20);
						if (num2 > 1)
						{
							if ((sampleArray[i] & 4) == 0)
							{
								graphics.FillRectangle(solidBrush2, num4 + 1, 87, num2 - 1, 3);
							}
							else
							{
								graphics.FillRectangle(solidBrush2, num4 + 1, 70, num2 - 1, 1);
							}
						}
					}
					else if ((sampleArray[i] & 4) == 0)
					{
						graphics.FillRectangle(solidBrush2, num4, 87, num2, 3);
					}
					else
					{
						graphics.FillRectangle(solidBrush2, num4, 70, num2, 1);
					}
					num4 += num2;
					b = sampleArray[i];
				}
			}
			else
			{
				for (int j = 0; j < 1024; j += 2)
				{
					if (((sampleArray[j] & 1) ^ (b & 1)) > 0 || ((sampleArray[j + 1] & 1) ^ (b & 1)) > 0)
					{
						graphics.FillRectangle(solidBrush2, num4, 10, 1, 20);
					}
					else if ((sampleArray[j] & 1) == 0)
					{
						graphics.FillRectangle(solidBrush2, num4, 27, 1, 3);
					}
					else
					{
						graphics.FillRectangle(solidBrush2, num4, 10, 1, 1);
					}
					if (((sampleArray[j] & 2) ^ (b & 2)) > 0 || ((sampleArray[j + 1] & 2) ^ (b & 2)) > 0)
					{
						graphics.FillRectangle(solidBrush2, num4, 40, 1, 20);
					}
					else if ((sampleArray[j] & 2) == 0)
					{
						graphics.FillRectangle(solidBrush2, num4, 57, 1, 3);
					}
					else
					{
						graphics.FillRectangle(solidBrush2, num4, 40, 1, 1);
					}
					if (((sampleArray[j] & 4) ^ (b & 4)) > 0 || ((sampleArray[j + 1] & 4) ^ (b & 4)) > 0)
					{
						graphics.FillRectangle(solidBrush2, num4, 70, 1, 20);
					}
					else if ((sampleArray[j] & 4) == 0)
					{
						graphics.FillRectangle(solidBrush2, num4, 87, 1, 3);
					}
					else
					{
						graphics.FillRectangle(solidBrush2, num4, 70, 1, 1);
					}
					num4++;
					b = sampleArray[j + 1];
				}
			}
			graphics.Dispose();
			solidBrush2.Dispose();
			return displayGraph;
		}

		private Bitmap getDisplayGraph(int zoom)
		{
			int num = 1024;
			int num2 = 100;
			switch (zoom)
			{
			case 0:
				num = 512;
				break;
			case 2:
				num = 2048;
				break;
			case 3:
				num = 4096;
				break;
			}
			Bitmap bitmap = new Bitmap(num, num2, PixelFormat.Format16bppRgb555);
			Graphics graphics = Graphics.FromImage(bitmap);
			SolidBrush solidBrush = new SolidBrush(Color.Black);
			graphics.FillRectangle(solidBrush, 0, 0, num, num2);
			solidBrush.Dispose();
			SolidBrush solidBrush2 = new SolidBrush(Color.DarkGray);
			for (int i = 0; i < num - 50; i += 50)
			{
				graphics.FillRectangle(solidBrush2, i, 0, 1, num2);
				graphics.FillRectangle(solidBrush2, i + 10, num2 - 7, 1, 7);
				graphics.FillRectangle(solidBrush2, i + 20, num2 - 7, 1, 7);
				graphics.FillRectangle(solidBrush2, i + 30, num2 - 7, 1, 7);
				graphics.FillRectangle(solidBrush2, i + 40, num2 - 7, 1, 7);
				graphics.FillRectangle(solidBrush2, i + 10, 0, 1, 7);
				graphics.FillRectangle(solidBrush2, i + 20, 0, 1, 7);
				graphics.FillRectangle(solidBrush2, i + 30, 0, 1, 7);
				graphics.FillRectangle(solidBrush2, i + 40, 0, 1, 7);
			}
			int num3 = (num - 50) / 50 + 1;
			num3 *= 50;
			if (num3 < num)
			{
				graphics.FillRectangle(solidBrush2, num3, 0, 1, num2);
			}
			num3 += 10;
			if (num3 < num)
			{
				graphics.FillRectangle(solidBrush2, num3, num2 - 7, 1, 7);
				graphics.FillRectangle(solidBrush2, num3, 0, 1, 7);
			}
			num3 += 10;
			if (num3 < num)
			{
				graphics.FillRectangle(solidBrush2, num3, num2 - 7, 1, 7);
				graphics.FillRectangle(solidBrush2, num3, 0, 1, 7);
			}
			num3 += 10;
			if (num3 < num)
			{
				graphics.FillRectangle(solidBrush2, num3, num2 - 7, 1, 7);
				graphics.FillRectangle(solidBrush2, num3, 0, 1, 7);
			}
			num3 += 10;
			if (num3 < num)
			{
				graphics.FillRectangle(solidBrush2, num3, num2 - 7, 1, 7);
				graphics.FillRectangle(solidBrush2, num3, 0, 1, 7);
			}
			solidBrush2.Dispose();
			graphics.Dispose();
			return bitmap;
		}

		private void radioButtonZoom05_Click(object sender, EventArgs e)
		{
			if (radioButtonZoom05.Checked)
			{
				if (lastZoomLevel == 1)
				{
					cursor1Pos /= 2;
					cursor2Pos /= 2;
				}
				else if (lastZoomLevel == 2)
				{
					cursor1Pos /= 4;
					cursor2Pos /= 4;
				}
				else if (lastZoomLevel == 3)
				{
					cursor1Pos /= 8;
					cursor2Pos /= 8;
				}
				lastZoomLevel = 0;
			}
			else if (radioButtonZoom1x.Checked)
			{
				if (lastZoomLevel == 0)
				{
					cursor1Pos *= 2;
					cursor2Pos *= 2;
				}
				else if (lastZoomLevel == 2)
				{
					cursor1Pos /= 2;
					cursor2Pos /= 2;
				}
				else if (lastZoomLevel == 3)
				{
					cursor1Pos /= 4;
					cursor2Pos /= 4;
				}
				lastZoomLevel = 1;
			}
			else if (radioButton2x.Checked)
			{
				if (lastZoomLevel == 0)
				{
					cursor1Pos *= 4;
					cursor2Pos *= 4;
				}
				else if (lastZoomLevel == 1)
				{
					cursor1Pos *= 2;
					cursor2Pos *= 2;
				}
				else if (lastZoomLevel == 3)
				{
					cursor1Pos /= 2;
					cursor2Pos /= 2;
				}
				lastZoomLevel = 2;
			}
			else if (radioButton4x.Checked)
			{
				if (lastZoomLevel == 0)
				{
					cursor1Pos *= 8;
					cursor2Pos *= 8;
				}
				else if (lastZoomLevel == 1)
				{
					cursor1Pos *= 4;
					cursor2Pos *= 4;
				}
				else if (lastZoomLevel == 2)
				{
					cursor1Pos *= 2;
					cursor2Pos *= 2;
				}
				lastZoomLevel = 3;
			}
			updateDisplay();
		}

		private void checkBoxCursors_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxCursors.Checked)
			{
				labelCursor1.Enabled = true;
				labelCursor1Val.Enabled = true;
				labelCursor2.Enabled = true;
				labelCursor2Val.Enabled = true;
				labelCursorDelta.Enabled = true;
				labelCursorDeltaVal.Enabled = true;
				updateDisplay();
			}
			else
			{
				labelCursor1.Enabled = false;
				labelCursor1Val.Enabled = false;
				labelCursor2.Enabled = false;
				labelCursor2Val.Enabled = false;
				labelCursorDelta.Enabled = false;
				labelCursorDeltaVal.Enabled = false;
				updateDisplay();
			}
		}

		private void pictureBoxDisplay_MouseDown(object sender, MouseEventArgs e)
		{
			if (checkBoxCursors.Checked)
			{
				if (e.Button == MouseButtons.Left)
				{
					cursor1Pos = e.X;
				}
				else if (e.Button == MouseButtons.Right)
				{
					cursor2Pos = e.X;
				}
			}
			updateDisplayCursors();
		}

		private void updateDisplayCursors()
		{
			if (checkBoxCursors.Checked)
			{
				int height = lastDrawnDisplay.Height;
				int num = 1;
				int num2 = cursor1Pos;
				int num3 = cursor2Pos;
				if (lastZoomLevel == 0)
				{
					num2 *= 2;
					num3 *= 2;
				}
				else if (lastZoomLevel == 2)
				{
					num = 2;
					num2 /= 2;
					num3 /= 2;
					cursor1Pos -= cursor1Pos % 2;
					cursor2Pos -= cursor2Pos % 2;
				}
				else if (lastZoomLevel == 3)
				{
					num = 4;
					num2 /= 4;
					num3 /= 4;
					cursor1Pos -= cursor1Pos % 4;
					cursor2Pos -= cursor2Pos % 4;
				}
				Bitmap image = (Bitmap)lastDrawnDisplay.Clone();
				Graphics graphics = Graphics.FromImage(image);
				Font font = new Font(FontFamily.GenericSansSerif, 7f);
				SolidBrush brush = new SolidBrush(Color.DodgerBlue);
				graphics.FillRectangle(brush, cursor1Pos, 0, num, height);
				graphics.DrawString("X", font, brush, cursor1Pos - 10, 29f);
				float num4 = (float)(num2 - lastTrigPos) * sampleRates[lastSampleRate];
				num4 += sampleRates[lastSampleRate] * 1000f * (float)lastTrigDelay;
				string str = "s";
				int decimals = 3;
				if (Math.Abs(num4) < 0.001f)
				{
					num4 *= 1000000f;
					str = "us";
					decimals = 0;
				}
				else if (Math.Abs(num4) < 1f)
				{
					num4 *= 1000f;
					str = "ms";
				}
				labelCursor1Val.Text = $"{Math.Round((decimal)num4, decimals):G} " + str;
				brush = new SolidBrush(Color.MediumOrchid);
				graphics.FillRectangle(brush, cursor2Pos, 0, num, height);
				graphics.DrawString("Y", font, brush, cursor2Pos + num + 2, 29f);
				float num5 = (float)(num3 - lastTrigPos) * sampleRates[lastSampleRate];
				num5 += sampleRates[lastSampleRate] * 1000f * (float)lastTrigDelay;
				str = "s";
				decimals = 3;
				if (Math.Abs(num5) < 0.001f)
				{
					num5 *= 1000000f;
					str = "us";
					decimals = 0;
				}
				else if (Math.Abs(num5) < 1f)
				{
					num5 *= 1000f;
					str = "ms";
				}
				labelCursor2Val.Text = $"{Math.Round((decimal)num5, 3):G} " + str;
				pictureBoxDisplay.Image = image;
				num5 = (float)(num3 - num2) * sampleRates[lastSampleRate];
				float num6 = 0f;
				if (Math.Abs(num5) > 0f)
				{
					num6 = Math.Abs(1f / num5);
				}
				str = "s";
				if (Math.Abs(num5) < 0.001f)
				{
					num5 *= 1000000f;
					str = "us";
				}
				else if (Math.Abs(num5) < 1f)
				{
					num5 *= 1000f;
					str = "ms";
				}
				string str2 = "Hz)";
				if (num6 >= 10000f)
				{
					num6 /= 1000f;
					str2 = "kHz)";
				}
				labelCursorDeltaVal.Text = $"{Math.Round((decimal)num5, 2):G} " + str + $" ({Math.Round((decimal)num6, 2):G} " + str2;
				brush.Dispose();
				graphics.Dispose();
			}
		}

		private void comboBoxCh1Trig_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxCh1Trig.SelectedIndex > 2 && comboBoxCh2Trig.SelectedIndex > 2 && comboBoxCh1Trig.SelectedIndex != comboBoxCh2Trig.SelectedIndex)
			{
				MessageBox.Show("If more than one Channel is set to\nedge detect, all Channel edges must\nbe in the same direction.\n\n(Rising or Falling)");
				comboBoxCh1Trig.SelectedIndex = 0;
			}
			if (comboBoxCh1Trig.SelectedIndex > 2 && comboBoxCh3Trig.SelectedIndex > 2 && comboBoxCh1Trig.SelectedIndex != comboBoxCh3Trig.SelectedIndex)
			{
				MessageBox.Show("If more than one Channel is set to\nedge detect, all Channel edges must\nbe in the same direction.\n\n(Rising or Falling)");
				comboBoxCh1Trig.SelectedIndex = 0;
			}
		}

		private void comboBoxCh2Trig_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxCh1Trig.SelectedIndex > 2 && comboBoxCh2Trig.SelectedIndex > 2 && comboBoxCh1Trig.SelectedIndex != comboBoxCh2Trig.SelectedIndex)
			{
				MessageBox.Show("If more than one Channel is set to\nedge detect, all Channel edges must\nbe in the same direction.\n\n(Rising or Falling)");
				comboBoxCh2Trig.SelectedIndex = 0;
			}
			if (comboBoxCh2Trig.SelectedIndex > 2 && comboBoxCh3Trig.SelectedIndex > 2 && comboBoxCh2Trig.SelectedIndex != comboBoxCh3Trig.SelectedIndex)
			{
				MessageBox.Show("If more than one Channel is set to\nedge detect, all Channel edges must\nbe in the same direction.\n\n(Rising or Falling)");
				comboBoxCh2Trig.SelectedIndex = 0;
			}
		}

		private void comboBoxCh3Trig_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxCh1Trig.SelectedIndex > 2 && comboBoxCh3Trig.SelectedIndex > 2 && comboBoxCh1Trig.SelectedIndex != comboBoxCh3Trig.SelectedIndex)
			{
				MessageBox.Show("If more than one Channel is set to\nedge detect, all Channel edges must\nbe in the same direction.\n\n(Rising or Falling)");
				comboBoxCh3Trig.SelectedIndex = 0;
			}
			if (comboBoxCh2Trig.SelectedIndex > 2 && comboBoxCh3Trig.SelectedIndex > 2 && comboBoxCh2Trig.SelectedIndex != comboBoxCh3Trig.SelectedIndex)
			{
				MessageBox.Show("If more than one Channel is set to\nedge detect, all Channel edges must\nbe in the same direction.\n\n(Rising or Falling)");
				comboBoxCh3Trig.SelectedIndex = 0;
			}
		}

		private void textBox1_Leave(object sender, EventArgs e)
		{
			uint num = uint.Parse(textBox1.Text);
			if (num == 0)
			{
				num = 1u;
			}
			if (num > 256)
			{
				num = 256u;
			}
			textBox1.Text = num.ToString();
		}

		private void comboBoxSampleRate_SelectedIndexChanged(object sender, EventArgs e)
		{
			float num = sampleRates[comboBoxSampleRate.SelectedIndex];
			num = 0.5f / num;
			string str = "Hz";
			if (num >= 10000f)
			{
				num /= 1000f;
				str = "kHz";
			}
			labelAliasFreq.Text = $"NOTE: Signals greater than {Math.Round((decimal)num, 1):G} " + str + " will alias.";
		}

		private void buttonRun_Click(object sender, EventArgs e)
		{
			if (comboBoxCh1Trig.SelectedIndex == 0 && comboBoxCh2Trig.SelectedIndex == 0 && comboBoxCh3Trig.SelectedIndex == 0)
			{
				MessageBox.Show("At least one trigger condition\n must be defined.\n\nAll are set to Don't Care.", "PICkit 2 Logic Tool");
				return;
			}
			byte b = 1;
			if (comboBoxCh1Trig.SelectedIndex == 4 || comboBoxCh2Trig.SelectedIndex == 4 || comboBoxCh3Trig.SelectedIndex == 4)
			{
				b = 0;
			}
			byte b2 = 0;
			if (comboBoxCh1Trig.SelectedIndex > 0)
			{
				b2 = (byte)(b2 | 4);
			}
			if (comboBoxCh2Trig.SelectedIndex > 0)
			{
				b2 = (byte)(b2 | 8);
			}
			if (comboBoxCh3Trig.SelectedIndex > 0)
			{
				b2 = (byte)(b2 | 0x10);
			}
			byte b3 = 0;
			if (comboBoxCh1Trig.SelectedIndex == 1 || comboBoxCh1Trig.SelectedIndex == 3)
			{
				b3 = (byte)(b3 | 4);
			}
			if (comboBoxCh2Trig.SelectedIndex == 1 || comboBoxCh2Trig.SelectedIndex == 3)
			{
				b3 = (byte)(b3 | 8);
			}
			if (comboBoxCh3Trig.SelectedIndex == 1 || comboBoxCh3Trig.SelectedIndex == 3)
			{
				b3 = (byte)(b3 | 0x10);
			}
			byte b4 = 0;
			if (comboBoxCh1Trig.SelectedIndex == 4 || comboBoxCh1Trig.SelectedIndex == 3)
			{
				b4 = (byte)(b4 | 4);
			}
			if (comboBoxCh2Trig.SelectedIndex == 4 || comboBoxCh2Trig.SelectedIndex == 3)
			{
				b4 = (byte)(b4 | 8);
			}
			if (comboBoxCh3Trig.SelectedIndex == 4 || comboBoxCh3Trig.SelectedIndex == 3)
			{
				b4 = (byte)(b4 | 0x10);
			}
			byte b5 = byte.Parse(textBox1.Text);
			postTrigCount = 2;
			if (radioButtonTrigStart.Checked)
			{
				postTrigCount = 973;
			}
			else if (radioButtonTrigMid.Checked)
			{
				postTrigCount = 523;
			}
			else if (radioButtonTrigEnd.Checked)
			{
				postTrigCount = 73;
			}
			else if (radioButtonTrigDly1.Checked)
			{
				postTrigCount = 1973;
			}
			else if (radioButtonTrigDly2.Checked)
			{
				postTrigCount = 2973;
			}
			else if (radioButtonTrigDly3.Checked)
			{
				postTrigCount = 3973;
			}
			trigDialog = new DialogTrigger();
			AddOwnedForm(trigDialog);
			trigDialog.Show();
			byte[] array = new byte[9];
			int num = 0;
			array[num++] = 184;
			array[num++] = b;
			array[num++] = b2;
			array[num++] = b3;
			array[num++] = b4;
			array[num++] = b5;
			array[num++] = (byte)((postTrigCount - 1) & 0xFF);
			array[num++] = (byte)((postTrigCount - 1 >> 8) & 0xFF);
			array[num++] = sampleFactors[comboBoxSampleRate.SelectedIndex];
			PICkitFunctions.writeUSB(array);
			timerRun.Enabled = true;
		}

		private void timerRun_Tick(object sender, EventArgs e)
		{
			timerRun.Enabled = false;
			bool flag = PICkitFunctions.readUSB();
			Thread.Sleep(250);
			RemoveOwnedForm(trigDialog);
			trigDialog.Close();
			if (!flag)
			{
				return;
			}
			int num = PICkitFunctions.Usb_read_array[1] + PICkitFunctions.Usb_read_array[2] * 256;
			if ((num & 0x4000) > 0)
			{
				return;
			}
			lastSampleRate = comboBoxSampleRate.SelectedIndex;
			bool flag2 = (num & 0x8000) > 0;
			num &= 0xFFF;
			num++;
			if (num == 2048)
			{
				num = 1536;
			}
			num -= 1536;
			byte[] array = new byte[512];
			byte[] array2 = new byte[3];
			int num2 = 0;
			array2[num2++] = 185;
			array2[num2++] = 0;
			array2[num2++] = 6;
			PICkitFunctions.writeUSB(array2);
			PICkitFunctions.UploadDataNoLen();
			Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
			PICkitFunctions.UploadDataNoLen();
			Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
			num2 = 0;
			array2[num2++] = 185;
			array2[num2++] = 128;
			array2[num2++] = 6;
			PICkitFunctions.writeUSB(array2);
			PICkitFunctions.UploadDataNoLen();
			Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 128L, 64L);
			PICkitFunctions.UploadDataNoLen();
			Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 192L, 64L);
			num2 = 0;
			array2[num2++] = 185;
			array2[num2++] = 0;
			array2[num2++] = 7;
			PICkitFunctions.writeUSB(array2);
			PICkitFunctions.UploadDataNoLen();
			Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 256L, 64L);
			PICkitFunctions.UploadDataNoLen();
			Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 320L, 64L);
			num2 = 0;
			array2[num2++] = 185;
			array2[num2++] = 128;
			array2[num2++] = 7;
			PICkitFunctions.writeUSB(array2);
			PICkitFunctions.UploadDataNoLen();
			Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 384L, 64L);
			PICkitFunctions.UploadDataNoLen();
			Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 448L, 64L);
			lastTrigPos = 1023 - postTrigCount % 1000;
			lastTrigDelay = postTrigCount / 1000;
			num += lastTrigPos / 2 + postTrigCount / 1000 * 12;
			if (lastTrigPos % 2 > 0)
			{
				flag2 = !flag2;
				if (flag2)
				{
					num++;
				}
			}
			num %= 512;
			for (int i = 0; i < sampleArray.Length; i++)
			{
				byte b = array[num];
				if (flag2)
				{
					num--;
					if (num < 0)
					{
						num += 512;
					}
					b = (byte)((b >> 4) + (b << 4));
				}
				b = (byte)(b & 0x1C);
				sampleArray[i] = (byte)(b >> 2);
				flag2 = !flag2;
			}
			sampleArray[0] = sampleArray[1];
			updateDisplay();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			Bitmap bitmap = (Bitmap)pictureBoxDisplay.Image.Clone();
			Graphics graphics = Graphics.FromImage(bitmap);
			Font font = new Font(FontFamily.GenericSansSerif, 7f, FontStyle.Bold);
			SolidBrush solidBrush = new SolidBrush(Color.White);
			graphics.DrawString(labelTimeScale.Text, font, solidBrush, 5f, 88f);
			if (checkBoxCursors.Checked)
			{
				graphics.DrawString("X=" + labelCursor1Val.Text, font, solidBrush, 100f, 88f);
				graphics.DrawString("Y=" + labelCursor2Val.Text, font, solidBrush, 200f, 88f);
			}
			saveFileDialogDisplay.ShowDialog();
			try
			{
				bitmap.Save(saveFileDialogDisplay.FileName);
			}
			catch
			{
			}
			graphics.Dispose();
			solidBrush.Dispose();
			font.Dispose();
			bitmap.Dispose();
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			checkBoxIOEnable.Checked = false;
			Close();
		}

		private void radioButtonAnalyzer_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonLogicIO.Checked)
			{
				panelLogicIO.Visible = true;
				panelAnalyzer.Visible = false;
			}
			else
			{
				panelLogicIO.Visible = false;
				checkBoxIOEnable.Checked = false;
				panelAnalyzer.Visible = true;
			}
		}

		private void initLogicIO()
		{
			radioButtonPin4In.Checked = true;
			radioButtonPin5In.Checked = true;
			radioButtonPin6In.Checked = true;
			textBoxPin1Out.Enabled = true;
			textBoxPin1Out.Text = "0";
			textBoxPin1Out.BackColor = Color.DarkRed;
			labelOut1Click.Visible = true;
			textBoxPin4In.Enabled = true;
			textBoxPin4In.Text = "0";
			textBoxPin4In.BackColor = Color.DarkBlue;
			textBoxPin4Out.Enabled = false;
			textBoxPin4Out.Text = "0";
			textBoxPin4Out.BackColor = SystemColors.Control;
			labelOut4Click.Visible = false;
			textBoxPin5In.Enabled = true;
			textBoxPin5In.Text = "0";
			textBoxPin5In.BackColor = Color.DarkBlue;
			textBoxPin5Out.Enabled = false;
			textBoxPin5Out.Text = "0";
			textBoxPin5Out.BackColor = SystemColors.Control;
			labelOut5Click.Visible = false;
			textBoxPin6In.Enabled = true;
			textBoxPin6In.Text = "0";
			textBoxPin6In.BackColor = Color.DarkBlue;
			textBoxPin6Out.Enabled = false;
			textBoxPin6Out.Text = "0";
			textBoxPin6Out.BackColor = SystemColors.Control;
			labelOut6Click.Visible = false;
		}

		private void textBoxPin1Out_Click(object sender, EventArgs e)
		{
			pinOut(textBoxPin1Out);
		}

		private void textBoxPin4Out_Click(object sender, EventArgs e)
		{
			pinOut(textBoxPin4Out);
		}

		private void textBoxPin5Out_Click(object sender, EventArgs e)
		{
			pinOut(textBoxPin5Out);
		}

		private void textBoxPin6Out_Click(object sender, EventArgs e)
		{
			pinOut(textBoxPin6Out);
		}

		private void pinOut(TextBox textBoxObject)
		{
			if (checkBoxIOEnable.Checked)
			{
				if (textBoxObject.Enabled)
				{
					if (textBoxObject.Text == "0")
					{
						textBoxObject.Text = "1";
						textBoxObject.BackColor = Color.Red;
					}
					else
					{
						textBoxObject.Text = "0";
						textBoxObject.BackColor = Color.DarkRed;
					}
					updateOutputs();
				}
			}
			else
			{
				MessageBox.Show("Click the 'Enable IO' button\n to use the Logic IO.", "PICkit 2 Logic Tool");
			}
		}

		private void checkBoxIOEnable_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxIOEnable.Checked)
			{
				if (!initLogicPins())
				{
					MessageBox.Show("No valid voltage detected on\nPICkit 2 VDD pin.\n\nA valid voltage (2.5V to 5.0V)\nis required for the Logic IO.", "PICkit 2 Logic Tool");
					checkBoxIOEnable.Checked = false;
					return;
				}
				if (PICkitFunctions.PowerStatus() == Constants.PICkit2PWR.vdd_on)
				{
					vddOn = true;
				}
				else
				{
					vddOn = false;
				}
				radioButtonPin4In.Enabled = true;
				radioButtonPin4Out.Enabled = true;
				radioButtonPin5In.Enabled = true;
				radioButtonPin5Out.Enabled = true;
				radioButtonPin6In.Enabled = true;
				radioButtonPin6Out.Enabled = true;
				updateOutputs();
				timerIO.Enabled = true;
			}
			else
			{
				timerIO.Enabled = false;
				radioButtonPin4In.Enabled = false;
				radioButtonPin4Out.Enabled = false;
				radioButtonPin5In.Enabled = false;
				radioButtonPin5Out.Enabled = false;
				radioButtonPin6In.Enabled = false;
				radioButtonPin6Out.Enabled = false;
				exitLogicIO();
			}
		}

		private void radioButtonPin4Out_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonPin4Out.Checked)
			{
				textBoxPin4In.Text = "";
				textBoxPin4In.BackColor = SystemColors.Control;
				textBoxPin4In.Enabled = false;
				textBoxPin4Out.Enabled = true;
				if (textBoxPin4Out.Text == "0")
				{
					textBoxPin4Out.BackColor = Color.DarkRed;
				}
				else
				{
					textBoxPin4Out.BackColor = Color.Red;
				}
				labelOut4Click.Visible = true;
			}
			else
			{
				textBoxPin4In.Enabled = true;
				textBoxPin4In.Text = "0";
				textBoxPin4In.BackColor = Color.DarkBlue;
				textBoxPin4Out.Enabled = false;
				textBoxPin4Out.BackColor = SystemColors.Control;
				labelOut4Click.Visible = false;
			}
			updateOutputs();
		}

		private void radioButtonPin5Out_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonPin5Out.Checked)
			{
				textBoxPin5In.Text = "";
				textBoxPin5In.BackColor = SystemColors.Control;
				textBoxPin5In.Enabled = false;
				textBoxPin5Out.Enabled = true;
				if (textBoxPin5Out.Text == "0")
				{
					textBoxPin5Out.BackColor = Color.DarkRed;
				}
				else
				{
					textBoxPin5Out.BackColor = Color.Red;
				}
				labelOut5Click.Visible = true;
			}
			else
			{
				textBoxPin5In.Enabled = true;
				textBoxPin5In.Text = "0";
				textBoxPin5In.BackColor = Color.DarkBlue;
				textBoxPin5Out.Enabled = false;
				textBoxPin5Out.BackColor = SystemColors.Control;
				labelOut5Click.Visible = false;
			}
			updateOutputs();
		}

		private void radioButtonPin6Out_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonPin6Out.Checked)
			{
				textBoxPin6In.Text = "";
				textBoxPin6In.BackColor = SystemColors.Control;
				textBoxPin6In.Enabled = false;
				textBoxPin6Out.Enabled = true;
				if (textBoxPin6Out.Text == "0")
				{
					textBoxPin6Out.BackColor = Color.DarkRed;
				}
				else
				{
					textBoxPin6Out.BackColor = Color.Red;
				}
				labelOut6Click.Visible = true;
			}
			else
			{
				textBoxPin6In.Enabled = true;
				textBoxPin6In.Text = "0";
				textBoxPin6In.BackColor = Color.DarkBlue;
				textBoxPin6Out.Enabled = false;
				textBoxPin6Out.BackColor = SystemColors.Control;
				labelOut6Click.Visible = false;
			}
			updateOutputs();
		}

		private bool initLogicPins()
		{
			float vdd = 0f;
			float vpp = 0f;
			if (PICkitFunctions.ReadPICkitVoltages(ref vdd, ref vpp) && vdd >= 2.5f)
			{
				PICkitFunctions.SetVppVoltage(vdd, 0.7f);
				PICkitFunctions.SetVDDVoltage(vdd, 0.85f);
				byte[] array = new byte[11];
				int num = 0;
				array[num++] = 166;
				array[num++] = 9;
				array[num++] = 250;
				array[num++] = 247;
				array[num++] = 249;
				array[num++] = 243;
				array[num++] = 3;
				array[num++] = 207;
				array[num++] = 1;
				array[num++] = 232;
				array[num++] = 20;
				return PICkitFunctions.writeUSB(array);
			}
			return false;
		}

		private bool exitLogicIO()
		{
			byte[] array = new byte[9];
			int num = 0;
			array[num++] = 166;
			array[num++] = 7;
			array[num++] = 250;
			array[num++] = 247;
			array[num++] = 248;
			array[num++] = 243;
			array[num++] = 3;
			array[num++] = 207;
			array[num++] = 1;
			return PICkitFunctions.writeUSB(array);
		}

		private bool updateOutputs()
		{
			byte b = 3;
			byte b2 = 1;
			if (radioButtonPin4Out.Checked)
			{
				b = (byte)(b & 0xFD);
				if (textBoxPin4Out.Text == "1")
				{
					b = (byte)(b | 8);
				}
			}
			if (radioButtonPin5Out.Checked)
			{
				b = (byte)(b & 0xFE);
				if (textBoxPin5Out.Text == "1")
				{
					b = (byte)(b | 4);
				}
			}
			if (radioButtonPin6Out.Checked)
			{
				b2 = 0;
				if (textBoxPin6Out.Text == "1")
				{
					b2 = 2;
				}
			}
			byte[] array = new byte[8];
			int num = 0;
			array[num++] = 166;
			array[num++] = 6;
			if (textBoxPin1Out.Text == "0")
			{
				array[num++] = 250;
				array[num++] = 247;
			}
			else
			{
				array[num++] = 246;
				array[num++] = 251;
			}
			array[num++] = 243;
			array[num++] = b;
			array[num++] = 207;
			array[num++] = b2;
			return PICkitFunctions.writeUSB(array);
		}

		public void DialogLogic_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (panelLogicIO.Visible && checkBoxIOEnable.Checked)
			{
				if (e.KeyChar == 'a' || e.KeyChar == 'A')
				{
					pinOut(textBoxPin1Out);
				}
				else if (e.KeyChar == 's' || e.KeyChar == 'S')
				{
					pinOut(textBoxPin4Out);
				}
				else if (e.KeyChar == 'd' || e.KeyChar == 'D')
				{
					pinOut(textBoxPin5Out);
				}
				else if (e.KeyChar == 'f' || e.KeyChar == 'F')
				{
					pinOut(textBoxPin6Out);
				}
			}
		}

		private void timerIO_Tick(object sender, EventArgs e)
		{
			switch (PICkitFunctions.PowerStatus())
			{
			case Constants.PICkit2PWR.vdderror:
			case Constants.PICkit2PWR.vddvpperrors:
				MessageBox.Show("PICkit 2 VDD voltage level error.\nVDD shut off: Disabling IO", "PICkit 2 Error");
				checkBoxIOEnable.Checked = false;
				return;
			case Constants.PICkit2PWR.vpperror:
				if (vddOn)
				{
					MessageBox.Show("Voltage error on Pin 1:\nVDD was shut off.\n\nDisabling IO", "PICkit 2 Error");
					checkBoxIOEnable.Checked = false;
					return;
				}
				MessageBox.Show("Voltage error on Pin 1:\nState reset to '0'", "PICkit 2 Error");
				textBoxPin1Out.Text = "0";
				textBoxPin1Out.BackColor = Color.DarkRed;
				break;
			}
			byte[] array = new byte[5];
			int num = 0;
			array[num++] = 166;
			array[num++] = 2;
			array[num++] = 220;
			array[num++] = 206;
			array[num++] = 170;
			PICkitFunctions.writeUSB(array);
			PICkitFunctions.readUSB();
			if ((PICkitFunctions.Usb_read_array[2] & 2) > 0)
			{
				updateInputBox(textBoxPin4In, "1");
			}
			else
			{
				updateInputBox(textBoxPin4In, "0");
			}
			if ((PICkitFunctions.Usb_read_array[2] & 1) > 0)
			{
				updateInputBox(textBoxPin5In, "1");
			}
			else
			{
				updateInputBox(textBoxPin5In, "0");
			}
			if ((PICkitFunctions.Usb_read_array[3] & 1) > 0)
			{
				updateInputBox(textBoxPin6In, "1");
			}
			else
			{
				updateInputBox(textBoxPin6In, "0");
			}
		}

		private void updateInputBox(TextBox inputBox, string value)
		{
			if (inputBox.Enabled)
			{
				inputBox.Text = value;
				if (value == "1")
				{
					inputBox.BackColor = Color.DodgerBlue;
				}
				else
				{
					inputBox.BackColor = Color.DarkBlue;
				}
			}
		}

		private void buttonHelp_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start(FormPICkit2.HomeDirectory + "\\Logic Tool User Guide.pdf");
			}
			catch
			{
				MessageBox.Show("Unable to open Logic Tool User Guide.");
			}
		}

		private void checkBoxVDD_Click(object sender, EventArgs e)
		{
			VddCallback(force: true, checkBoxVDD.Checked);
		}
	}
}
