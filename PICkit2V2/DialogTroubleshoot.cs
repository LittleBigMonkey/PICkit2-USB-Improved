using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class DialogTroubleshoot : Form
	{
		private IContainer components;

		private Panel panelIntro;

		private Label labelIntroTitle;

		private Panel panelStep1VDDExt;

		private Button buttonStep1Recheck;

		private Label labelStep1ExtTitle;

		private Button buttonCancel;

		private Button buttonNext;

		private Button buttonBack;

		private Label labelIntroText1;

		private Label labelVoltageOnVDD;

		private Label labelVoltageOnVDD2;

		private NumericUpDown numericUpDown1;

		private Label labelTestVDD;

		private Panel panelStep1VDDTest;

		private Label labelStep1Title;

		private PictureBox pictureBox1;

		private PictureBox pictureBox2;

		private Button buttonVDDOn;

		private Label labelReadVDD;

		private Label label1;

		private Label labelGood;

		private Label labelVDDShort;

		private Label labelVDDLow;

		private Panel panelCautionVDD;

		private Label label2;

		private Label label3;

		private Panel panelStep2VPP;

		private PictureBox pictureBox3;

		private Label label6;

		private Label label5;

		private Label labelStep2FamilyVPP;

		private Button buttonTestVPP;

		private Button buttonMCLR;

		private Label labelVPPVDDShort;

		private Label labelVPPResults;

		private Label labelReadVPP;

		private Label labelVPPShort;

		private Label labelVPPLow;

		private Label labelVPPPass;

		private Label labelVPPMCLR;

		private Panel panelPGCPGD;

		private PictureBox pictureBox5;

		private PictureBox pictureBox4;

		private Label label8;

		private RadioButton radioButtonPGCLow;

		private RadioButton radioButtonPGCHigh;

		private GroupBox groupBoxPGD;

		private RadioButton radioButtonPGDLow;

		private RadioButton radioButtonPGDHigh;

		private GroupBox groupBoxPGC;

		private Label label4;

		private Label labelPGxOScope;

		private Label labelPGxVDDShort;

		private Label label9;

		private Label label7;

		private Label labelVPPMCLROff;

		private Button buttonMCLROff;

		private RadioButton radioButtonPGDToggle;

		private System.Windows.Forms.Timer timerPGxToggle;

		private RadioButton radioButtonPGCToggle;

		private Label label10;

		private Label label11;

		private Label label12;

		public DialogTroubleshoot()
		{
			InitializeComponent();
			PICkitFunctions.VddOff();
			PICkitFunctions.SendScript(new byte[2]
			{
				243,
				3
			});
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
				testVDD();
			}
			else if (panelStep1VDDTest.Visible)
			{
				PICkitFunctions.VddOff();
				panelStep1VDDTest.Visible = false;
				panelCautionVDD.Visible = true;
			}
			else if (panelStep1VDDExt.Visible)
			{
				PICkitFunctions.VddOff();
				panelStep1VDDExt.Visible = false;
				panelStep2VPP.Visible = true;
				testVPP_Enter();
			}
			else if (panelCautionVDD.Visible)
			{
				panelCautionVDD.Visible = false;
				panelStep2VPP.Visible = true;
				testVPP_Enter();
			}
			else if (panelStep2VPP.Visible)
			{
				panelStep2VPP.Visible = false;
				panelPGCPGD.Visible = true;
				buttonNext.Enabled = false;
				testPGCPGDEnter();
			}
		}

		private void buttonBack_Click(object sender, EventArgs e)
		{
			if (panelStep1VDDExt.Visible || panelStep1VDDTest.Visible)
			{
				PICkitFunctions.VddOff();
				panelIntro.Visible = true;
				buttonBack.Enabled = false;
				panelStep1VDDTest.Visible = false;
				panelStep1VDDExt.Visible = false;
			}
			else if (panelCautionVDD.Visible || panelStep2VPP.Visible)
			{
				panelCautionVDD.Visible = false;
				panelStep2VPP.Visible = false;
				testVDD();
			}
			else if (panelPGCPGD.Visible)
			{
				panelPGCPGD.Visible = false;
				panelStep2VPP.Visible = true;
				buttonNext.Enabled = true;
				testVPP_Enter();
			}
		}

		private void testVDD()
		{
			float vdd = 0f;
			float vpp = 0f;
			PICkitFunctions.SendScript(new byte[4]
			{
				250,
				248,
				254,
				253
			});
			Thread.Sleep(250);
			if (PICkitFunctions.CheckTargetPower(ref vdd, ref vpp) == Constants.PICkit2PWR.selfpowered)
			{
				panelStep1VDDExt.Visible = true;
				labelVoltageOnVDD.Text = "An external voltage was detected\non the VDD pin at " + $"{vdd:0.0} Volts.";
				return;
			}
			panelStep1VDDExt.Visible = false;
			panelStep1VDDTest.Visible = true;
			labelGood.Visible = false;
			labelVDDShort.Visible = false;
			labelVDDLow.Visible = false;
			labelReadVDD.Text = "";
			numericUpDown1.Maximum = (decimal)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddMax;
			numericUpDown1.Minimum = (decimal)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddMin;
			if ((float)numericUpDown1.Maximum > 4.5f)
			{
				numericUpDown1.Value = 4.5m;
			}
			else
			{
				numericUpDown1.Value = numericUpDown1.Maximum;
			}
		}

		private void buttonStep1Recheck_Click(object sender, EventArgs e)
		{
			testVDD();
		}

		private void buttonVDDOn_Click(object sender, EventArgs e)
		{
			float vdd = 0f;
			float vpp = 0f;
			labelGood.Visible = false;
			labelVDDShort.Visible = false;
			labelVDDLow.Visible = false;
			labelReadVDD.Text = "";
			float voltage = (float)numericUpDown1.Value;
			if (!PICkitFunctions.SetVDDVoltage(voltage, 0.45f))
			{
				return;
			}
			PICkitFunctions.ForcePICkitPowered();
			if (!PICkitFunctions.VddOn())
			{
				return;
			}
			if (PICkitFunctions.PowerStatus() != Constants.PICkit2PWR.vdd_on)
			{
				labelVDDShort.Visible = true;
				labelReadVDD.Text = "Short!";
			}
			else if (PICkitFunctions.ReadPICkitVoltages(ref vdd, ref vpp))
			{
				labelReadVDD.Text = $"{vdd:0.0} V";
				float num = (float)numericUpDown1.Value;
				if (num > 4.6f)
				{
					num = 4.6f;
				}
				if (num - vdd > 0.2f)
				{
					labelVDDLow.Visible = true;
				}
				else
				{
					labelGood.Visible = true;
				}
			}
		}

		private void testVPP_Enter()
		{
			PICkitFunctions.VddOff();
			PICkitFunctions.SendScript(new byte[2]
			{
				243,
				3
			});
			timerPGxToggle.Enabled = false;
			buttonCancel.Text = "Cancel";
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].Vpp < 1f)
			{
				labelStep2FamilyVPP.Text = "1) VPP for this family: " + $"{numericUpDown1.Value:0.0}V (=VDD)";
			}
			else
			{
				labelStep2FamilyVPP.Text = "1) VPP for this family: " + $"{PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].Vpp:0.0} Volts.";
			}
			labelReadVPP.Text = "";
			labelVPPLow.Visible = false;
			labelVPPMCLR.Visible = false;
			labelVPPMCLROff.Visible = false;
			labelVPPPass.Visible = false;
			labelVPPShort.Visible = false;
			labelVPPVDDShort.Visible = false;
		}

		private void buttonTestVPP_Click(object sender, EventArgs e)
		{
			float vdd = 0f;
			float vpp = 0f;
			labelVPPLow.Visible = false;
			labelVPPMCLR.Visible = false;
			labelVPPMCLROff.Visible = false;
			labelVPPPass.Visible = false;
			labelVPPShort.Visible = false;
			labelVPPVDDShort.Visible = false;
			labelReadVPP.Text = "";
			Thread.Sleep(250);
			if (PICkitFunctions.CheckTargetPower(ref vdd, ref vpp) == Constants.PICkit2PWR.selfpowered)
			{
				PICkitFunctions.VddOff();
			}
			else
			{
				PICkitFunctions.SetVDDVoltage((float)numericUpDown1.Value, 0.85f);
				PICkitFunctions.VddOn();
			}
			float num = (!(PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].Vpp > 1f)) ? ((float)numericUpDown1.Value) : PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].Vpp;
			PICkitFunctions.SetVppVoltage(num, 0.5f);
			PICkitFunctions.SendScript(new byte[8]
			{
				250,
				249,
				232,
				30,
				246,
				251,
				232,
				20
			});
			switch (PICkitFunctions.PowerStatus())
			{
			case Constants.PICkit2PWR.no_response:
				return;
			case Constants.PICkit2PWR.vdderror:
			case Constants.PICkit2PWR.vddvpperrors:
				labelVPPVDDShort.Visible = true;
				return;
			case Constants.PICkit2PWR.vpperror:
				labelVPPShort.Visible = true;
				labelReadVPP.Text = "Short!";
				return;
			}
			if (PICkitFunctions.ReadPICkitVoltages(ref vdd, ref vpp))
			{
				labelReadVPP.Text = $"{vpp:0.0} V";
				if (num - vpp > 0.3f)
				{
					labelVPPLow.Visible = true;
				}
				else
				{
					labelVPPPass.Visible = true;
				}
			}
		}

		private void buttonMCLR_Click(object sender, EventArgs e)
		{
			labelVPPLow.Visible = false;
			labelVPPMCLR.Visible = true;
			labelVPPMCLROff.Visible = false;
			labelVPPPass.Visible = false;
			labelVPPShort.Visible = false;
			labelVPPVDDShort.Visible = false;
			labelReadVPP.Text = "/MCLR On";
			PICkitFunctions.SendScript(new byte[3]
			{
				250,
				248,
				247
			});
		}

		private void buttonMCLROff_Click(object sender, EventArgs e)
		{
			labelVPPLow.Visible = false;
			labelVPPMCLR.Visible = false;
			labelVPPMCLROff.Visible = true;
			labelVPPPass.Visible = false;
			labelVPPShort.Visible = false;
			labelVPPVDDShort.Visible = false;
			labelReadVPP.Text = "/MCLR Off";
			PICkitFunctions.SendScript(new byte[3]
			{
				250,
				248,
				246
			});
		}

		private void testPGCPGDEnter()
		{
			float vdd = 0f;
			float vpp = 0f;
			byte[] array = new byte[3]
			{
				250,
				248,
				247
			};
			PICkitFunctions.SendScript(array);
			PICkitFunctions.VddOff();
			buttonCancel.Text = "Finished";
			Thread.Sleep(200);
			if (PICkitFunctions.CheckTargetPower(ref vdd, ref vpp) == Constants.PICkit2PWR.selfpowered)
			{
				PICkitFunctions.VddOff();
			}
			else
			{
				PICkitFunctions.SetVDDVoltage((float)numericUpDown1.Value, 0.85f);
				PICkitFunctions.VddOn();
				Thread.Sleep(50);
			}
			switch (PICkitFunctions.PowerStatus())
			{
			case Constants.PICkit2PWR.no_response:
				return;
			case Constants.PICkit2PWR.vdderror:
			case Constants.PICkit2PWR.vddvpperrors:
				radioButtonPGCHigh.Enabled = false;
				radioButtonPGCLow.Enabled = false;
				radioButtonPGDHigh.Enabled = false;
				radioButtonPGDLow.Enabled = false;
				radioButtonPGCToggle.Enabled = false;
				radioButtonPGDToggle.Enabled = false;
				labelPGxOScope.Visible = false;
				labelPGxVDDShort.Visible = true;
				return;
			case Constants.PICkit2PWR.vpperror:
				radioButtonPGCHigh.Enabled = false;
				radioButtonPGCLow.Enabled = false;
				radioButtonPGDHigh.Enabled = false;
				radioButtonPGDLow.Enabled = false;
				radioButtonPGCToggle.Enabled = false;
				radioButtonPGDToggle.Enabled = false;
				labelPGxOScope.Visible = false;
				labelPGxVDDShort.Visible = true;
				return;
			}
			radioButtonPGCHigh.Enabled = true;
			radioButtonPGCLow.Enabled = true;
			radioButtonPGDHigh.Enabled = true;
			radioButtonPGDLow.Enabled = true;
			radioButtonPGCToggle.Enabled = true;
			radioButtonPGDToggle.Enabled = true;
			labelPGxOScope.Visible = true;
			labelPGxVDDShort.Visible = false;
			array[0] = 243;
			array[1] = 0;
			array[2] = 244;
			PICkitFunctions.SendScript(array);
			radioButtonPGDToggle.Checked = false;
			radioButtonPGCToggle.Checked = false;
			radioButtonPGCHigh.Checked = false;
			radioButtonPGCLow.Checked = true;
			radioButtonPGDHigh.Checked = false;
			radioButtonPGDLow.Checked = true;
		}

		private void radioButtonPGCHigh_CheckedChanged(object sender, EventArgs e)
		{
			byte[] array = new byte[2];
			if (!radioButtonPGDToggle.Checked && !radioButtonPGCToggle.Checked)
			{
				timerPGxToggle.Enabled = false;
				array[0] = 243;
				if (radioButtonPGCHigh.Checked && radioButtonPGDHigh.Checked)
				{
					array[1] = 12;
				}
				else if (radioButtonPGCHigh.Checked)
				{
					array[1] = 4;
				}
				else if (radioButtonPGDHigh.Checked)
				{
					array[1] = 8;
				}
				else
				{
					array[1] = 0;
				}
				PICkitFunctions.SendScript(array);
			}
		}

		private void radioButtonPGDToggle_Click(object sender, EventArgs e)
		{
			PGxToggle();
		}

		private void timerPGxToggle_Tick(object sender, EventArgs e)
		{
			PGxToggle();
		}

		private void PGxToggle()
		{
			timerPGxToggle.Enabled = false;
			byte b = 0;
			byte b2 = 0;
			if (radioButtonPGDToggle.Checked)
			{
				b = (byte)(b | 8);
			}
			if (radioButtonPGCToggle.Checked)
			{
				b = (byte)(b | 4);
			}
			if (radioButtonPGCHigh.Checked)
			{
				b = (byte)(b | 4);
				b2 = (byte)(b2 | 4);
			}
			if (radioButtonPGDHigh.Checked)
			{
				b = (byte)(b | 8);
				b2 = (byte)(b2 | 8);
			}
			PICkitFunctions.SendScript(new byte[17]
			{
				210,
				59,
				210,
				0,
				243,
				b,
				245,
				245,
				243,
				b2,
				245,
				233,
				7,
				0,
				221,
				10,
				244
			});
			timerPGxToggle.Enabled = true;
		}

		private void trblshtingFormClosing(object sender, FormClosingEventArgs e)
		{
			timerPGxToggle.Enabled = false;
			PICkitFunctions.SendScript(new byte[5]
			{
				250,
				246,
				248,
				243,
				3
			});
			PICkitFunctions.VddOff();
		}

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PICkit2V2.DialogTroubleshoot));
			panelIntro = new System.Windows.Forms.Panel();
			labelIntroText1 = new System.Windows.Forms.Label();
			labelIntroTitle = new System.Windows.Forms.Label();
			panelStep1VDDExt = new System.Windows.Forms.Panel();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			labelVoltageOnVDD2 = new System.Windows.Forms.Label();
			labelVoltageOnVDD = new System.Windows.Forms.Label();
			buttonStep1Recheck = new System.Windows.Forms.Button();
			labelStep1ExtTitle = new System.Windows.Forms.Label();
			buttonCancel = new System.Windows.Forms.Button();
			buttonNext = new System.Windows.Forms.Button();
			buttonBack = new System.Windows.Forms.Button();
			labelTestVDD = new System.Windows.Forms.Label();
			numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			panelStep1VDDTest = new System.Windows.Forms.Panel();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			labelGood = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			labelVDDLow = new System.Windows.Forms.Label();
			labelVDDShort = new System.Windows.Forms.Label();
			labelReadVDD = new System.Windows.Forms.Label();
			buttonVDDOn = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			labelStep1Title = new System.Windows.Forms.Label();
			panelCautionVDD = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			panelStep2VPP = new System.Windows.Forms.Panel();
			buttonMCLROff = new System.Windows.Forms.Button();
			labelVPPMCLROff = new System.Windows.Forms.Label();
			labelVPPPass = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			labelVPPMCLR = new System.Windows.Forms.Label();
			labelVPPShort = new System.Windows.Forms.Label();
			labelVPPLow = new System.Windows.Forms.Label();
			labelVPPVDDShort = new System.Windows.Forms.Label();
			labelVPPResults = new System.Windows.Forms.Label();
			buttonMCLR = new System.Windows.Forms.Button();
			labelReadVPP = new System.Windows.Forms.Label();
			buttonTestVPP = new System.Windows.Forms.Button();
			label5 = new System.Windows.Forms.Label();
			labelStep2FamilyVPP = new System.Windows.Forms.Label();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			label6 = new System.Windows.Forms.Label();
			panelPGCPGD = new System.Windows.Forms.Panel();
			labelPGxVDDShort = new System.Windows.Forms.Label();
			labelPGxOScope = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			groupBoxPGD = new System.Windows.Forms.GroupBox();
			radioButtonPGDToggle = new System.Windows.Forms.RadioButton();
			radioButtonPGDLow = new System.Windows.Forms.RadioButton();
			radioButtonPGDHigh = new System.Windows.Forms.RadioButton();
			pictureBox5 = new System.Windows.Forms.PictureBox();
			groupBoxPGC = new System.Windows.Forms.GroupBox();
			radioButtonPGCToggle = new System.Windows.Forms.RadioButton();
			radioButtonPGCLow = new System.Windows.Forms.RadioButton();
			radioButtonPGCHigh = new System.Windows.Forms.RadioButton();
			label8 = new System.Windows.Forms.Label();
			pictureBox4 = new System.Windows.Forms.PictureBox();
			timerPGxToggle = new System.Windows.Forms.Timer(components);
			panelIntro.SuspendLayout();
			panelStep1VDDExt.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			panelStep1VDDTest.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panelCautionVDD.SuspendLayout();
			panelStep2VPP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			panelPGCPGD.SuspendLayout();
			groupBoxPGD.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
			groupBoxPGC.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
			SuspendLayout();
			panelIntro.Controls.Add(labelIntroText1);
			panelIntro.Controls.Add(labelIntroTitle);
			panelIntro.Location = new System.Drawing.Point(16, 15);
			panelIntro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			panelIntro.Name = "panelIntro";
			panelIntro.Size = new System.Drawing.Size(413, 295);
			panelIntro.TabIndex = 0;
			labelIntroText1.AutoSize = true;
			labelIntroText1.Location = new System.Drawing.Point(16, 42);
			labelIntroText1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelIntroText1.Name = "labelIntroText1";
			labelIntroText1.Size = new System.Drawing.Size(384, 238);
			labelIntroText1.TabIndex = 1;
			labelIntroText1.Text = resources.GetString("labelIntroText1.Text");
			labelIntroTitle.AutoSize = true;
			labelIntroTitle.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelIntroTitle.Location = new System.Drawing.Point(68, 0);
			labelIntroTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelIntroTitle.Name = "labelIntroTitle";
			labelIntroTitle.Size = new System.Drawing.Size(244, 24);
			labelIntroTitle.TabIndex = 0;
			labelIntroTitle.Text = "PICkit 2 Troubleshooting";
			panelStep1VDDExt.Controls.Add(pictureBox2);
			panelStep1VDDExt.Controls.Add(labelVoltageOnVDD2);
			panelStep1VDDExt.Controls.Add(labelVoltageOnVDD);
			panelStep1VDDExt.Controls.Add(buttonStep1Recheck);
			panelStep1VDDExt.Controls.Add(labelStep1ExtTitle);
			panelStep1VDDExt.Location = new System.Drawing.Point(16, 15);
			panelStep1VDDExt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			panelStep1VDDExt.Name = "panelStep1VDDExt";
			panelStep1VDDExt.Size = new System.Drawing.Size(413, 295);
			panelStep1VDDExt.TabIndex = 1;
			panelStep1VDDExt.Visible = false;
			pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new System.Drawing.Point(0, 0);
			pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(78, 116);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox2.TabIndex = 7;
			pictureBox2.TabStop = false;
			labelVoltageOnVDD2.AutoSize = true;
			labelVoltageOnVDD2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelVoltageOnVDD2.ForeColor = System.Drawing.Color.Red;
			labelVoltageOnVDD2.Location = new System.Drawing.Point(4, 146);
			labelVoltageOnVDD2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelVoltageOnVDD2.Name = "labelVoltageOnVDD2";
			labelVoltageOnVDD2.Size = new System.Drawing.Size(349, 80);
			labelVoltageOnVDD2.TabIndex = 3;
			labelVoltageOnVDD2.Text = "Click \"Next >\" to skip VDD testing.\r\n\r\nTo test VDD, remove the external voltage and\r\nclick \"Recheck\".";
			labelVoltageOnVDD.AutoSize = true;
			labelVoltageOnVDD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelVoltageOnVDD.ForeColor = System.Drawing.Color.Red;
			labelVoltageOnVDD.Location = new System.Drawing.Point(124, 60);
			labelVoltageOnVDD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelVoltageOnVDD.Name = "labelVoltageOnVDD";
			labelVoltageOnVDD.Size = new System.Drawing.Size(255, 40);
			labelVoltageOnVDD.TabIndex = 2;
			labelVoltageOnVDD.Text = "An external voltage was detected\r\non the VDD pin at ";
			buttonStep1Recheck.Location = new System.Drawing.Point(155, 254);
			buttonStep1Recheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			buttonStep1Recheck.Name = "buttonStep1Recheck";
			buttonStep1Recheck.Size = new System.Drawing.Size(100, 28);
			buttonStep1Recheck.TabIndex = 1;
			buttonStep1Recheck.Text = "Recheck";
			buttonStep1Recheck.UseVisualStyleBackColor = true;
			buttonStep1Recheck.Click += new System.EventHandler(buttonStep1Recheck_Click);
			labelStep1ExtTitle.AutoEllipsis = true;
			labelStep1ExtTitle.AutoSize = true;
			labelStep1ExtTitle.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelStep1ExtTitle.Location = new System.Drawing.Point(149, 0);
			labelStep1ExtTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelStep1ExtTitle.Name = "labelStep1ExtTitle";
			labelStep1ExtTitle.Size = new System.Drawing.Size(185, 24);
			labelStep1ExtTitle.TabIndex = 0;
			labelStep1ExtTitle.Text = "Step 1: Verify VDD";
			buttonCancel.Location = new System.Drawing.Point(329, 318);
			buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new System.Drawing.Size(100, 28);
			buttonCancel.TabIndex = 2;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += new System.EventHandler(buttonCancel_Click);
			buttonNext.Location = new System.Drawing.Point(221, 318);
			buttonNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			buttonNext.Name = "buttonNext";
			buttonNext.Size = new System.Drawing.Size(100, 28);
			buttonNext.TabIndex = 3;
			buttonNext.Text = "Next >";
			buttonNext.UseVisualStyleBackColor = true;
			buttonNext.Click += new System.EventHandler(buttonNext_Click);
			buttonBack.Enabled = false;
			buttonBack.Location = new System.Drawing.Point(113, 318);
			buttonBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			buttonBack.Name = "buttonBack";
			buttonBack.Size = new System.Drawing.Size(100, 28);
			buttonBack.TabIndex = 4;
			buttonBack.Text = "< Back";
			buttonBack.UseVisualStyleBackColor = true;
			buttonBack.Click += new System.EventHandler(buttonBack_Click);
			labelTestVDD.AutoSize = true;
			labelTestVDD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelTestVDD.Location = new System.Drawing.Point(119, 23);
			labelTestVDD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelTestVDD.Name = "labelTestVDD";
			labelTestVDD.Size = new System.Drawing.Size(235, 36);
			labelTestVDD.TabIndex = 4;
			labelTestVDD.Text = "1) Adjust VDD level for your circuit.\r\n(Limits set by active family)";
			numericUpDown1.DecimalPlaces = 1;
			numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			numericUpDown1.Increment = new decimal(new int[4]
			{
				1,
				0,
				0,
				65536
			});
			numericUpDown1.Location = new System.Drawing.Point(23, 150);
			numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new System.Drawing.Size(80, 26);
			numericUpDown1.TabIndex = 5;
			numericUpDown1.Value = new decimal(new int[4]
			{
				45,
				0,
				0,
				65536
			});
			panelStep1VDDTest.Controls.Add(label11);
			panelStep1VDDTest.Controls.Add(label12);
			panelStep1VDDTest.Controls.Add(label10);
			panelStep1VDDTest.Controls.Add(labelGood);
			panelStep1VDDTest.Controls.Add(label1);
			panelStep1VDDTest.Controls.Add(labelVDDLow);
			panelStep1VDDTest.Controls.Add(labelVDDShort);
			panelStep1VDDTest.Controls.Add(labelReadVDD);
			panelStep1VDDTest.Controls.Add(buttonVDDOn);
			panelStep1VDDTest.Controls.Add(pictureBox1);
			panelStep1VDDTest.Controls.Add(numericUpDown1);
			panelStep1VDDTest.Controls.Add(labelStep1Title);
			panelStep1VDDTest.Controls.Add(labelTestVDD);
			panelStep1VDDTest.Location = new System.Drawing.Point(16, 15);
			panelStep1VDDTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			panelStep1VDDTest.Name = "panelStep1VDDTest";
			panelStep1VDDTest.Size = new System.Drawing.Size(413, 295);
			panelStep1VDDTest.TabIndex = 5;
			panelStep1VDDTest.Visible = false;
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label11.ForeColor = System.Drawing.SystemColors.ControlText;
			label11.Location = new System.Drawing.Point(119, 133);
			label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(214, 36);
			label11.TabIndex = 12;
			label11.Text = "The actual voltage is dependent\r\non the host USB Voltage.";
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label12.Location = new System.Drawing.Point(119, 69);
			label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(207, 18);
			label12.TabIndex = 12;
			label12.Text = "2) Click \"Test\" to turn on VDD.";
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.ForeColor = System.Drawing.Color.DarkRed;
			label10.Location = new System.Drawing.Point(119, 96);
			label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(228, 36);
			label10.TabIndex = 11;
			label10.Text = "3) It is important to verify results\r\nusing a volt meter at all VDD pins.";
			labelGood.AutoSize = true;
			labelGood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelGood.ForeColor = System.Drawing.Color.Blue;
			labelGood.Location = new System.Drawing.Point(119, 191);
			labelGood.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelGood.Name = "labelGood";
			labelGood.Size = new System.Drawing.Size(253, 90);
			labelGood.TabIndex = 10;
			labelGood.Text = "Test Passed:\r\nPICkit 2 detected an expected voltage\r\non the VDD pin.  (NOTE: slow rise\r\ntimes can still cause VDD Errors.)\r\nClick \"Next >\" to test VPP.";
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(32, 229);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(59, 17);
			label1.TabIndex = 9;
			label1.Text = "Results:";
			labelVDDLow.AutoSize = true;
			labelVDDLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelVDDLow.ForeColor = System.Drawing.Color.Red;
			labelVDDLow.Location = new System.Drawing.Point(119, 191);
			labelVDDLow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelVDDLow.Name = "labelVDDLow";
			labelVDDLow.Size = new System.Drawing.Size(256, 90);
			labelVDDLow.TabIndex = 6;
			labelVDDLow.Text = "Test Failed: The VDD result is low.\r\nThe target circuit may be pulling too\r\nmuch current from VDD, or there may\r\nbe too much capacitance on VDD.\r\nTry using an external supply.";
			labelVDDShort.AutoSize = true;
			labelVDDShort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelVDDShort.ForeColor = System.Drawing.Color.Red;
			labelVDDShort.Location = new System.Drawing.Point(119, 191);
			labelVDDShort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelVDDShort.Name = "labelVDDShort";
			labelVDDShort.Size = new System.Drawing.Size(248, 90);
			labelVDDShort.TabIndex = 6;
			labelVDDShort.Text = "Test Failed:\r\nA short was detected, and VDD was \r\nshut off.\r\nIf no target is connected, the PICkit 2\r\nmay be damaged.";
			labelVDDShort.Visible = false;
			labelReadVDD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			labelReadVDD.Location = new System.Drawing.Point(23, 254);
			labelReadVDD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelReadVDD.Name = "labelReadVDD";
			labelReadVDD.Size = new System.Drawing.Size(80, 28);
			labelReadVDD.TabIndex = 8;
			buttonVDDOn.Location = new System.Drawing.Point(23, 185);
			buttonVDDOn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			buttonVDDOn.Name = "buttonVDDOn";
			buttonVDDOn.Size = new System.Drawing.Size(80, 28);
			buttonVDDOn.TabIndex = 7;
			buttonVDDOn.Text = "Test";
			buttonVDDOn.UseVisualStyleBackColor = true;
			buttonVDDOn.Click += new System.EventHandler(buttonVDDOn_Click);
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(0, 0);
			pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(78, 116);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox1.TabIndex = 4;
			pictureBox1.TabStop = false;
			labelStep1Title.AutoEllipsis = true;
			labelStep1Title.AutoSize = true;
			labelStep1Title.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelStep1Title.Location = new System.Drawing.Point(151, 0);
			labelStep1Title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelStep1Title.Name = "labelStep1Title";
			labelStep1Title.Size = new System.Drawing.Size(185, 24);
			labelStep1Title.TabIndex = 6;
			labelStep1Title.Text = "Step 1: Verify VDD";
			panelCautionVDD.Controls.Add(label2);
			panelCautionVDD.Controls.Add(label3);
			panelCautionVDD.Location = new System.Drawing.Point(16, 15);
			panelCautionVDD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			panelCautionVDD.Name = "panelCautionVDD";
			panelCautionVDD.Size = new System.Drawing.Size(413, 295);
			panelCautionVDD.TabIndex = 2;
			panelCautionVDD.Visible = false;
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(36, 91);
			label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(314, 120);
			label2.TabIndex = 1;
			label2.Text = "VDD will be turned on in all the following\r\ntests at the voltage set in Step 1, unless\r\nan external supply is detected.\r\n\r\nEnsure that VDD is set to an appropriate\r\nvoltage in Step 1.\r\n";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.Red;
			label3.Location = new System.Drawing.Point(125, 33);
			label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(139, 24);
			label3.TabIndex = 0;
			label3.Text = "-- CAUTION --";
			panelStep2VPP.Controls.Add(buttonMCLROff);
			panelStep2VPP.Controls.Add(labelVPPMCLROff);
			panelStep2VPP.Controls.Add(labelVPPPass);
			panelStep2VPP.Controls.Add(label9);
			panelStep2VPP.Controls.Add(label7);
			panelStep2VPP.Controls.Add(labelVPPMCLR);
			panelStep2VPP.Controls.Add(labelVPPShort);
			panelStep2VPP.Controls.Add(labelVPPLow);
			panelStep2VPP.Controls.Add(labelVPPVDDShort);
			panelStep2VPP.Controls.Add(labelVPPResults);
			panelStep2VPP.Controls.Add(buttonMCLR);
			panelStep2VPP.Controls.Add(labelReadVPP);
			panelStep2VPP.Controls.Add(buttonTestVPP);
			panelStep2VPP.Controls.Add(label5);
			panelStep2VPP.Controls.Add(labelStep2FamilyVPP);
			panelStep2VPP.Controls.Add(pictureBox3);
			panelStep2VPP.Controls.Add(label6);
			panelStep2VPP.Location = new System.Drawing.Point(16, 15);
			panelStep2VPP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			panelStep2VPP.Name = "panelStep2VPP";
			panelStep2VPP.Size = new System.Drawing.Size(413, 295);
			panelStep2VPP.TabIndex = 8;
			panelStep2VPP.Visible = false;
			buttonMCLROff.Location = new System.Drawing.Point(8, 261);
			buttonMCLROff.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			buttonMCLROff.Name = "buttonMCLROff";
			buttonMCLROff.Size = new System.Drawing.Size(96, 28);
			buttonMCLROff.TabIndex = 19;
			buttonMCLROff.Text = "/MCLR Off";
			buttonMCLROff.UseVisualStyleBackColor = true;
			buttonMCLROff.Click += new System.EventHandler(buttonMCLROff_Click);
			labelVPPMCLROff.AutoSize = true;
			labelVPPMCLROff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelVPPMCLROff.ForeColor = System.Drawing.Color.Blue;
			labelVPPMCLROff.Location = new System.Drawing.Point(112, 188);
			labelVPPMCLROff.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelVPPMCLROff.Name = "labelVPPMCLROff";
			labelVPPMCLROff.Size = new System.Drawing.Size(252, 90);
			labelVPPMCLROff.TabIndex = 18;
			labelVPPMCLROff.Text = "/MCLR released.\r\n\r\nIf /MCLR has a pull-up, it should be at\r\nthe pull-up voltage.  If not, it will be at\r\nan indeterminate voltage.";
			labelVPPPass.AutoSize = true;
			labelVPPPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelVPPPass.ForeColor = System.Drawing.Color.Blue;
			labelVPPPass.Location = new System.Drawing.Point(112, 172);
			labelVPPPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelVPPPass.Name = "labelVPPPass";
			labelVPPPass.Size = new System.Drawing.Size(252, 90);
			labelVPPPass.TabIndex = 14;
			labelVPPPass.Text = "Test Passed:\r\n\r\nPlease check the device /MCLR-VPP\r\npin with a voltmeter to verify it sees\r\nthe appropriate VPP voltage.";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(112, 126);
			label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(267, 36);
			label9.TabIndex = 17;
			label9.Text = "4) Click \"/MCLR Off\" to check releasing\r\n/MCLR (VPP = tri-state)";
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(112, 82);
			label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(268, 36);
			label7.TabIndex = 16;
			label7.Text = "3) Click \"/MCLR On\" to check asserting\r\n/MCLR (VPP = 0 V).";
			labelVPPMCLR.AutoSize = true;
			labelVPPMCLR.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelVPPMCLR.ForeColor = System.Drawing.Color.Blue;
			labelVPPMCLR.Location = new System.Drawing.Point(112, 172);
			labelVPPMCLR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelVPPMCLR.Name = "labelVPPMCLR";
			labelVPPMCLR.Size = new System.Drawing.Size(241, 90);
			labelVPPMCLR.TabIndex = 15;
			labelVPPMCLR.Text = "/MCLR asserted.\r\n\r\nPlease check the device /MCLR pin\r\nwith a voltmeter to verify the pin\r\nis pulled low.";
			labelVPPShort.AutoSize = true;
			labelVPPShort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelVPPShort.ForeColor = System.Drawing.Color.Red;
			labelVPPShort.Location = new System.Drawing.Point(112, 172);
			labelVPPShort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelVPPShort.Name = "labelVPPShort";
			labelVPPShort.Size = new System.Drawing.Size(263, 90);
			labelVPPShort.TabIndex = 12;
			labelVPPShort.Text = "Test Failed:\r\nShort Detected.\r\n\r\nA short or very heavy load on VPP was\r\ndetected, and VPP was shut off.";
			labelVPPLow.AutoSize = true;
			labelVPPLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelVPPLow.ForeColor = System.Drawing.Color.Red;
			labelVPPLow.Location = new System.Drawing.Point(112, 172);
			labelVPPLow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelVPPLow.Name = "labelVPPLow";
			labelVPPLow.Size = new System.Drawing.Size(238, 108);
			labelVPPLow.TabIndex = 13;
			labelVPPLow.Text = "Test Failed:\r\nLow VPP detected.\r\n\r\nVPP is not reaching the expected\r\nvoltage.  VPP cannot support more\r\nthan a few mA of current.";
			labelVPPVDDShort.AutoSize = true;
			labelVPPVDDShort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelVPPVDDShort.ForeColor = System.Drawing.Color.Red;
			labelVPPVDDShort.Location = new System.Drawing.Point(112, 172);
			labelVPPVDDShort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelVPPVDDShort.Name = "labelVPPVDDShort";
			labelVPPVDDShort.Size = new System.Drawing.Size(253, 90);
			labelVPPVDDShort.TabIndex = 11;
			labelVPPVDDShort.Text = "Test Failed:\r\nVDD Short Detected.\r\n\r\nVPP cannot be tested if a short exists\r\non VDD.";
			labelVPPResults.AutoSize = true;
			labelVPPResults.Location = new System.Drawing.Point(28, 172);
			labelVPPResults.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelVPPResults.Name = "labelVPPResults";
			labelVPPResults.Size = new System.Drawing.Size(59, 17);
			labelVPPResults.TabIndex = 12;
			labelVPPResults.Text = "Results:";
			buttonMCLR.Location = new System.Drawing.Point(8, 225);
			buttonMCLR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			buttonMCLR.Name = "buttonMCLR";
			buttonMCLR.Size = new System.Drawing.Size(96, 28);
			buttonMCLR.TabIndex = 15;
			buttonMCLR.Text = "/MCLR On";
			buttonMCLR.UseVisualStyleBackColor = true;
			buttonMCLR.Click += new System.EventHandler(buttonMCLR_Click);
			labelReadVPP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			labelReadVPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelReadVPP.Location = new System.Drawing.Point(8, 188);
			labelReadVPP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelReadVPP.Name = "labelReadVPP";
			labelReadVPP.Size = new System.Drawing.Size(95, 28);
			labelReadVPP.TabIndex = 11;
			labelReadVPP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			buttonTestVPP.Location = new System.Drawing.Point(8, 142);
			buttonTestVPP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			buttonTestVPP.Name = "buttonTestVPP";
			buttonTestVPP.Size = new System.Drawing.Size(96, 28);
			buttonTestVPP.TabIndex = 14;
			buttonTestVPP.Text = "Test VPP";
			buttonTestVPP.UseVisualStyleBackColor = true;
			buttonTestVPP.Click += new System.EventHandler(buttonTestVPP_Click);
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(112, 57);
			label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(283, 18);
			label5.TabIndex = 12;
			label5.Text = "2) Click \"Test VPP\" to check VPP voltage.";
			labelStep2FamilyVPP.AutoSize = true;
			labelStep2FamilyVPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelStep2FamilyVPP.Location = new System.Drawing.Point(112, 30);
			labelStep2FamilyVPP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelStep2FamilyVPP.Name = "labelStep2FamilyVPP";
			labelStep2FamilyVPP.Size = new System.Drawing.Size(190, 18);
			labelStep2FamilyVPP.TabIndex = 11;
			labelStep2FamilyVPP.Text = "1) VPP for this family is \r\n";
			pictureBox3.Image = (System.Drawing.Image)resources.GetObject("pictureBox3.Image");
			pictureBox3.Location = new System.Drawing.Point(0, 0);
			pictureBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(78, 116);
			pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox3.TabIndex = 7;
			pictureBox3.TabStop = false;
			label6.AutoEllipsis = true;
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(149, 0);
			label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(183, 24);
			label6.TabIndex = 0;
			label6.Text = "Step 2: Verify VPP";
			panelPGCPGD.Controls.Add(labelPGxVDDShort);
			panelPGCPGD.Controls.Add(labelPGxOScope);
			panelPGCPGD.Controls.Add(label4);
			panelPGCPGD.Controls.Add(groupBoxPGD);
			panelPGCPGD.Controls.Add(pictureBox5);
			panelPGCPGD.Controls.Add(groupBoxPGC);
			panelPGCPGD.Controls.Add(label8);
			panelPGCPGD.Controls.Add(pictureBox4);
			panelPGCPGD.Location = new System.Drawing.Point(16, 15);
			panelPGCPGD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			panelPGCPGD.Name = "panelPGCPGD";
			panelPGCPGD.Size = new System.Drawing.Size(413, 295);
			panelPGCPGD.TabIndex = 9;
			panelPGCPGD.Visible = false;
			labelPGxVDDShort.AutoSize = true;
			labelPGxVDDShort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelPGxVDDShort.ForeColor = System.Drawing.Color.Red;
			labelPGxVDDShort.Location = new System.Drawing.Point(267, 126);
			labelPGxVDDShort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelPGxVDDShort.Name = "labelPGxVDDShort";
			labelPGxVDDShort.Size = new System.Drawing.Size(102, 90);
			labelPGxVDDShort.TabIndex = 18;
			labelPGxVDDShort.Text = "VDD Short\r\ndetected!\r\n\r\nMust be\r\ncleared first.";
			labelPGxOScope.AutoSize = true;
			labelPGxOScope.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelPGxOScope.Location = new System.Drawing.Point(267, 105);
			labelPGxOScope.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelPGxOScope.Name = "labelPGxOScope";
			labelPGxOScope.Size = new System.Drawing.Size(130, 162);
			labelPGxOScope.TabIndex = 17;
			labelPGxOScope.Text = "It is recommended\r\nto use an oscillo-\r\nscope to verify \r\nwaveform edges\r\nare sharp.\r\n\"Toggle 30kHz\"\r\nwill toggle the pin\r\nat approximately\r\n30kHz.\r\n";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(267, 27);
			label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(130, 72);
			label4.TabIndex = 16;
			label4.Text = "Verify signal states\r\nat device pins with\r\na volt meter.\r\n\r\n";
			groupBoxPGD.Controls.Add(radioButtonPGDToggle);
			groupBoxPGD.Controls.Add(radioButtonPGDLow);
			groupBoxPGD.Controls.Add(radioButtonPGDHigh);
			groupBoxPGD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			groupBoxPGD.Location = new System.Drawing.Point(112, 27);
			groupBoxPGD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			groupBoxPGD.Name = "groupBoxPGD";
			groupBoxPGD.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			groupBoxPGD.Size = new System.Drawing.Size(140, 116);
			groupBoxPGD.TabIndex = 13;
			groupBoxPGD.TabStop = false;
			groupBoxPGD.Text = "PGD / ICSPDAT";
			radioButtonPGDToggle.Appearance = System.Windows.Forms.Appearance.Button;
			radioButtonPGDToggle.AutoSize = true;
			radioButtonPGDToggle.Location = new System.Drawing.Point(8, 17);
			radioButtonPGDToggle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			radioButtonPGDToggle.Name = "radioButtonPGDToggle";
			radioButtonPGDToggle.Size = new System.Drawing.Size(106, 27);
			radioButtonPGDToggle.TabIndex = 11;
			radioButtonPGDToggle.TabStop = true;
			radioButtonPGDToggle.Text = "Toggle 30kHz";
			radioButtonPGDToggle.UseVisualStyleBackColor = true;
			radioButtonPGDToggle.Click += new System.EventHandler(radioButtonPGDToggle_Click);
			radioButtonPGDLow.Appearance = System.Windows.Forms.Appearance.Button;
			radioButtonPGDLow.Location = new System.Drawing.Point(8, 81);
			radioButtonPGDLow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			radioButtonPGDLow.Name = "radioButtonPGDLow";
			radioButtonPGDLow.Size = new System.Drawing.Size(112, 28);
			radioButtonPGDLow.TabIndex = 10;
			radioButtonPGDLow.TabStop = true;
			radioButtonPGDLow.Text = "Low (GND)";
			radioButtonPGDLow.UseVisualStyleBackColor = true;
			radioButtonPGDLow.CheckedChanged += new System.EventHandler(radioButtonPGCHigh_CheckedChanged);
			radioButtonPGDHigh.Appearance = System.Windows.Forms.Appearance.Button;
			radioButtonPGDHigh.Location = new System.Drawing.Point(8, 49);
			radioButtonPGDHigh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			radioButtonPGDHigh.Name = "radioButtonPGDHigh";
			radioButtonPGDHigh.Size = new System.Drawing.Size(112, 28);
			radioButtonPGDHigh.TabIndex = 9;
			radioButtonPGDHigh.TabStop = true;
			radioButtonPGDHigh.Text = "High (VDD)";
			radioButtonPGDHigh.UseVisualStyleBackColor = true;
			radioButtonPGDHigh.CheckedChanged += new System.EventHandler(radioButtonPGCHigh_CheckedChanged);
			pictureBox5.Image = (System.Drawing.Image)resources.GetObject("pictureBox5.Image");
			pictureBox5.Location = new System.Drawing.Point(0, 0);
			pictureBox5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			pictureBox5.Name = "pictureBox5";
			pictureBox5.Size = new System.Drawing.Size(78, 116);
			pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox5.TabIndex = 8;
			pictureBox5.TabStop = false;
			groupBoxPGC.Controls.Add(radioButtonPGCToggle);
			groupBoxPGC.Controls.Add(radioButtonPGCLow);
			groupBoxPGC.Controls.Add(radioButtonPGCHigh);
			groupBoxPGC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			groupBoxPGC.Location = new System.Drawing.Point(112, 153);
			groupBoxPGC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			groupBoxPGC.Name = "groupBoxPGC";
			groupBoxPGC.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
			groupBoxPGC.Size = new System.Drawing.Size(140, 116);
			groupBoxPGC.TabIndex = 12;
			groupBoxPGC.TabStop = false;
			groupBoxPGC.Text = "PGC / ICSPCLK";
			radioButtonPGCToggle.Appearance = System.Windows.Forms.Appearance.Button;
			radioButtonPGCToggle.Location = new System.Drawing.Point(8, 17);
			radioButtonPGCToggle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			radioButtonPGCToggle.Name = "radioButtonPGCToggle";
			radioButtonPGCToggle.Size = new System.Drawing.Size(112, 28);
			radioButtonPGCToggle.TabIndex = 12;
			radioButtonPGCToggle.TabStop = true;
			radioButtonPGCToggle.Text = "Toggle 30kHz";
			radioButtonPGCToggle.UseVisualStyleBackColor = true;
			radioButtonPGCToggle.Click += new System.EventHandler(radioButtonPGDToggle_Click);
			radioButtonPGCLow.Appearance = System.Windows.Forms.Appearance.Button;
			radioButtonPGCLow.Location = new System.Drawing.Point(8, 81);
			radioButtonPGCLow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			radioButtonPGCLow.Name = "radioButtonPGCLow";
			radioButtonPGCLow.Size = new System.Drawing.Size(112, 28);
			radioButtonPGCLow.TabIndex = 10;
			radioButtonPGCLow.TabStop = true;
			radioButtonPGCLow.Text = "Low (GND)";
			radioButtonPGCLow.UseVisualStyleBackColor = true;
			radioButtonPGCLow.CheckedChanged += new System.EventHandler(radioButtonPGCHigh_CheckedChanged);
			radioButtonPGCHigh.Appearance = System.Windows.Forms.Appearance.Button;
			radioButtonPGCHigh.Location = new System.Drawing.Point(8, 49);
			radioButtonPGCHigh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			radioButtonPGCHigh.Name = "radioButtonPGCHigh";
			radioButtonPGCHigh.Size = new System.Drawing.Size(112, 28);
			radioButtonPGCHigh.TabIndex = 9;
			radioButtonPGCHigh.TabStop = true;
			radioButtonPGCHigh.Text = "High (VDD)";
			radioButtonPGCHigh.UseVisualStyleBackColor = true;
			radioButtonPGCHigh.CheckedChanged += new System.EventHandler(radioButtonPGCHigh_CheckedChanged);
			label8.AutoEllipsis = true;
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(125, 0);
			label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(254, 24);
			label8.TabIndex = 0;
			label8.Text = "Step 3: Verify PGC + PGD";
			pictureBox4.Image = (System.Drawing.Image)resources.GetObject("pictureBox4.Image");
			pictureBox4.Location = new System.Drawing.Point(0, 153);
			pictureBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			pictureBox4.Name = "pictureBox4";
			pictureBox4.Size = new System.Drawing.Size(78, 116);
			pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox4.TabIndex = 7;
			pictureBox4.TabStop = false;
			timerPGxToggle.Interval = 450;
			timerPGxToggle.Tick += new System.EventHandler(timerPGxToggle_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(120f, 120f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(445, 354);
			base.Controls.Add(panelPGCPGD);
			base.Controls.Add(panelStep2VPP);
			base.Controls.Add(panelCautionVDD);
			base.Controls.Add(panelStep1VDDTest);
			base.Controls.Add(buttonBack);
			base.Controls.Add(buttonNext);
			base.Controls.Add(buttonCancel);
			base.Controls.Add(panelStep1VDDExt);
			base.Controls.Add(panelIntro);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DialogTroubleshoot";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "PICkit 2 Troubleshooting";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(trblshtingFormClosing);
			panelIntro.ResumeLayout(false);
			panelIntro.PerformLayout();
			panelStep1VDDExt.ResumeLayout(false);
			panelStep1VDDExt.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			panelStep1VDDTest.ResumeLayout(false);
			panelStep1VDDTest.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panelCautionVDD.ResumeLayout(false);
			panelCautionVDD.PerformLayout();
			panelStep2VPP.ResumeLayout(false);
			panelStep2VPP.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			panelPGCPGD.ResumeLayout(false);
			panelPGCPGD.PerformLayout();
			groupBoxPGD.ResumeLayout(false);
			groupBoxPGD.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
			groupBoxPGC.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
			ResumeLayout(false);
		}
	}
}
