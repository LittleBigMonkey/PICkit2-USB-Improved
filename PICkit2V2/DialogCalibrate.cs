using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class DialogCalibrate : Form
	{
		private IContainer components;

		private Panel panelIntro;

		private Button buttonBack;

		private Button buttonNext;

		private Button buttonCancel;

		private Label label1;

		private Label label2;

		private Button buttonClearUnitID;

		private Button buttonClearCal;

		private Panel panelSetup;

		private PictureBox pictureBox1;

		private Label label3;

		private Label label5;

		private Label label4;

		private Label label6;

		private Panel panelCal;

		private Label label9;

		private PictureBox pictureBox2;

		private Label label10;

		private TextBox textBoxVDD;

		private Label label7;

		private Label labelBadCal;

		private Label labelGoodCal;

		private Button buttonCalibrate;

		private Label label8;

		private Label label11;

		private Panel panelUnitID;

		private Label label12;

		private Label label15;

		private Label label16;

		private Button buttonSetUnitID;

		private TextBox textBoxUnitID;

		private Label labelAssignedID;

		private bool unitIDChanged;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PICkit2V2.DialogCalibrate));
			panelIntro = new System.Windows.Forms.Panel();
			label2 = new System.Windows.Forms.Label();
			buttonClearUnitID = new System.Windows.Forms.Button();
			buttonClearCal = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			buttonBack = new System.Windows.Forms.Button();
			buttonNext = new System.Windows.Forms.Button();
			buttonCancel = new System.Windows.Forms.Button();
			panelSetup = new System.Windows.Forms.Panel();
			label11 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label3 = new System.Windows.Forms.Label();
			panelCal = new System.Windows.Forms.Panel();
			labelBadCal = new System.Windows.Forms.Label();
			labelGoodCal = new System.Windows.Forms.Label();
			buttonCalibrate = new System.Windows.Forms.Button();
			label8 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			textBoxVDD = new System.Windows.Forms.TextBox();
			label9 = new System.Windows.Forms.Label();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			label10 = new System.Windows.Forms.Label();
			panelUnitID = new System.Windows.Forms.Panel();
			labelAssignedID = new System.Windows.Forms.Label();
			buttonSetUnitID = new System.Windows.Forms.Button();
			textBoxUnitID = new System.Windows.Forms.TextBox();
			label12 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			panelIntro.SuspendLayout();
			panelSetup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panelCal.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			panelUnitID.SuspendLayout();
			SuspendLayout();
			panelIntro.Controls.Add(label2);
			panelIntro.Controls.Add(buttonClearUnitID);
			panelIntro.Controls.Add(buttonClearCal);
			panelIntro.Controls.Add(label1);
			panelIntro.Location = new System.Drawing.Point(13, 12);
			panelIntro.Name = "panelIntro";
			panelIntro.Size = new System.Drawing.Size(330, 236);
			panelIntro.TabIndex = 0;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(0, 29);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(307, 169);
			label2.TabIndex = 3;
			label2.Text = resources.GetString("label2.Text");
			buttonClearUnitID.Enabled = false;
			buttonClearUnitID.Location = new System.Drawing.Point(176, 205);
			buttonClearUnitID.Name = "buttonClearUnitID";
			buttonClearUnitID.Size = new System.Drawing.Size(134, 22);
			buttonClearUnitID.TabIndex = 2;
			buttonClearUnitID.Text = "Clear Unit ID";
			buttonClearUnitID.UseVisualStyleBackColor = true;
			buttonClearUnitID.Click += new System.EventHandler(buttonClearUnitID_Click);
			buttonClearCal.Enabled = false;
			buttonClearCal.Location = new System.Drawing.Point(22, 205);
			buttonClearCal.Name = "buttonClearCal";
			buttonClearCal.Size = new System.Drawing.Size(134, 22);
			buttonClearCal.TabIndex = 1;
			buttonClearCal.Text = "Clear Calibration";
			buttonClearCal.UseVisualStyleBackColor = true;
			buttonClearCal.Click += new System.EventHandler(buttonClearCal_Click);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(63, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(193, 19);
			label1.TabIndex = 0;
			label1.Text = "PICkit 2 VDD Calibration";
			buttonBack.Enabled = false;
			buttonBack.Location = new System.Drawing.Point(90, 254);
			buttonBack.Name = "buttonBack";
			buttonBack.Size = new System.Drawing.Size(80, 22);
			buttonBack.TabIndex = 1;
			buttonBack.Text = "< Back";
			buttonBack.UseVisualStyleBackColor = true;
			buttonBack.Click += new System.EventHandler(buttonBack_Click);
			buttonNext.Location = new System.Drawing.Point(177, 254);
			buttonNext.Name = "buttonNext";
			buttonNext.Size = new System.Drawing.Size(80, 22);
			buttonNext.TabIndex = 2;
			buttonNext.Text = "Next >";
			buttonNext.UseVisualStyleBackColor = true;
			buttonNext.Click += new System.EventHandler(buttonNext_Click);
			buttonCancel.Location = new System.Drawing.Point(263, 254);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new System.Drawing.Size(80, 22);
			buttonCancel.TabIndex = 3;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += new System.EventHandler(buttonCancel_Click);
			panelSetup.Controls.Add(label11);
			panelSetup.Controls.Add(label6);
			panelSetup.Controls.Add(label5);
			panelSetup.Controls.Add(label4);
			panelSetup.Controls.Add(pictureBox1);
			panelSetup.Controls.Add(label3);
			panelSetup.Location = new System.Drawing.Point(13, 12);
			panelSetup.Name = "panelSetup";
			panelSetup.Size = new System.Drawing.Size(330, 236);
			panelSetup.TabIndex = 4;
			panelSetup.Visible = false;
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label11.ForeColor = System.Drawing.Color.Red;
			label11.Location = new System.Drawing.Point(4, 222);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(306, 15);
			label11.TabIndex = 6;
			label11.Text = "CAUTION: Clicking NEXT will erase existing calibration.";
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(4, 168);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(289, 45);
			label6.TabIndex = 5;
			label6.Text = "Step 3:\r\nClick NEXT and the PICkit 2 will apply approximately\r\n4 Volts to the VDD pin.";
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(102, 94);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(195, 60);
			label5.TabIndex = 4;
			label5.Text = "Step 2:\r\nConnect a voltage meter between\r\npin 2 (VDD) and pin 3 (GND) of the\r\nPICkit 2 ICSP connector.";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(102, 22);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(186, 60);
			label4.TabIndex = 3;
			label4.Text = "Step 1:\r\nMake sure the PICkit 2 is not\r\nconnected to any device or circuit\r\nboard.";
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(0, 22);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(78, 116);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox1.TabIndex = 2;
			pictureBox1.TabStop = false;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(61, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(193, 19);
			label3.TabIndex = 1;
			label3.Text = "PICkit 2 VDD Calibration";
			panelCal.Controls.Add(labelBadCal);
			panelCal.Controls.Add(labelGoodCal);
			panelCal.Controls.Add(buttonCalibrate);
			panelCal.Controls.Add(label8);
			panelCal.Controls.Add(label7);
			panelCal.Controls.Add(textBoxVDD);
			panelCal.Controls.Add(label9);
			panelCal.Controls.Add(pictureBox2);
			panelCal.Controls.Add(label10);
			panelCal.Location = new System.Drawing.Point(13, 12);
			panelCal.Name = "panelCal";
			panelCal.Size = new System.Drawing.Size(330, 236);
			panelCal.TabIndex = 6;
			panelCal.Visible = false;
			labelBadCal.AutoSize = true;
			labelBadCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelBadCal.ForeColor = System.Drawing.Color.Red;
			labelBadCal.Location = new System.Drawing.Point(3, 198);
			labelBadCal.Name = "labelBadCal";
			labelBadCal.Size = new System.Drawing.Size(276, 30);
			labelBadCal.TabIndex = 9;
			labelBadCal.Text = "Could not fully calibrate the unit.  The USB voltage\r\nmay be too low to completely calibrate.";
			labelBadCal.Visible = false;
			labelGoodCal.AutoSize = true;
			labelGoodCal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelGoodCal.ForeColor = System.Drawing.Color.Blue;
			labelGoodCal.Location = new System.Drawing.Point(3, 208);
			labelGoodCal.Name = "labelGoodCal";
			labelGoodCal.Size = new System.Drawing.Size(170, 15);
			labelGoodCal.TabIndex = 8;
			labelGoodCal.Text = "CALIBRATION SUCCESSFUL!";
			labelGoodCal.Visible = false;
			buttonCalibrate.Location = new System.Drawing.Point(6, 172);
			buttonCalibrate.Name = "buttonCalibrate";
			buttonCalibrate.Size = new System.Drawing.Size(112, 22);
			buttonCalibrate.TabIndex = 7;
			buttonCalibrate.Text = "Calibrate";
			buttonCalibrate.UseVisualStyleBackColor = true;
			buttonCalibrate.Click += new System.EventHandler(buttonCalibrate_Click);
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(3, 139);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(287, 30);
			label8.TabIndex = 6;
			label8.Text = "Step 5:\r\nClick the CALIBRATE button to calibrate the PICkit 2.";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(164, 104);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(80, 13);
			label7.TabIndex = 5;
			label7.Text = "Volts Measured";
			textBoxVDD.Location = new System.Drawing.Point(105, 102);
			textBoxVDD.Name = "textBoxVDD";
			textBoxVDD.Size = new System.Drawing.Size(53, 20);
			textBoxVDD.TabIndex = 4;
			textBoxVDD.Text = "4.000";
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(102, 22);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(209, 60);
			label9.TabIndex = 3;
			label9.Text = "Step 4:\r\nEnter the actual voltage measured\r\non the volt meter in the box below, up\r\nto 3 decimal places.";
			pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new System.Drawing.Point(0, 22);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(78, 116);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox2.TabIndex = 2;
			pictureBox2.TabStop = false;
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label10.Location = new System.Drawing.Point(61, 0);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(193, 19);
			label10.TabIndex = 1;
			label10.Text = "PICkit 2 VDD Calibration";
			panelUnitID.Controls.Add(labelAssignedID);
			panelUnitID.Controls.Add(buttonSetUnitID);
			panelUnitID.Controls.Add(textBoxUnitID);
			panelUnitID.Controls.Add(label12);
			panelUnitID.Controls.Add(label15);
			panelUnitID.Controls.Add(label16);
			panelUnitID.Location = new System.Drawing.Point(13, 12);
			panelUnitID.Name = "panelUnitID";
			panelUnitID.Size = new System.Drawing.Size(330, 236);
			panelUnitID.TabIndex = 7;
			panelUnitID.Visible = false;
			labelAssignedID.AutoSize = true;
			labelAssignedID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			labelAssignedID.ForeColor = System.Drawing.Color.Blue;
			labelAssignedID.Location = new System.Drawing.Point(58, 217);
			labelAssignedID.Name = "labelAssignedID";
			labelAssignedID.Size = new System.Drawing.Size(179, 15);
			labelAssignedID.TabIndex = 7;
			labelAssignedID.Text = "Unit ID Assigned to this PICkit 2.";
			labelAssignedID.Visible = false;
			buttonSetUnitID.Location = new System.Drawing.Point(186, 188);
			buttonSetUnitID.Name = "buttonSetUnitID";
			buttonSetUnitID.Size = new System.Drawing.Size(106, 22);
			buttonSetUnitID.TabIndex = 6;
			buttonSetUnitID.Text = "Assign Unit ID";
			buttonSetUnitID.UseVisualStyleBackColor = true;
			buttonSetUnitID.Click += new System.EventHandler(buttonSetUnitID_Click);
			textBoxUnitID.Location = new System.Drawing.Point(26, 190);
			textBoxUnitID.Name = "textBoxUnitID";
			textBoxUnitID.Size = new System.Drawing.Size(134, 20);
			textBoxUnitID.TabIndex = 5;
			textBoxUnitID.Text = "AAAAAAAAAAAAAA";
			textBoxUnitID.TextChanged += new System.EventHandler(textBoxUnitID_TextChanged);
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label12.Location = new System.Drawing.Point(118, 18);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(76, 18);
			label12.TabIndex = 4;
			label12.Text = "(Optional)";
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label15.Location = new System.Drawing.Point(0, 48);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(308, 120);
			label15.TabIndex = 3;
			label15.Text = resources.GetString("label15.Text");
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label16.Location = new System.Drawing.Point(61, 0);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(190, 19);
			label16.TabIndex = 1;
			label16.Text = "Unit Identification Name";
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(354, 282);
			base.Controls.Add(panelUnitID);
			base.Controls.Add(panelCal);
			base.Controls.Add(panelSetup);
			base.Controls.Add(buttonCancel);
			base.Controls.Add(buttonNext);
			base.Controls.Add(buttonBack);
			base.Controls.Add(panelIntro);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DialogCalibrate";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "DialogCalibrate";
			panelIntro.ResumeLayout(false);
			panelIntro.PerformLayout();
			panelSetup.ResumeLayout(false);
			panelSetup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panelCal.ResumeLayout(false);
			panelCal.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			panelUnitID.ResumeLayout(false);
			panelUnitID.PerformLayout();
			ResumeLayout(false);
		}

		public DialogCalibrate()
		{
			InitializeComponent();
			PICkitFunctions.VddOff();
			PICkitFunctions.ForcePICkitPowered();
			setupClearButtons();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			PICkitFunctions.VddOff();
			if (unitIDChanged)
			{
				PICkitFunctions.ResetPICkit2();
				Thread.Sleep(1000);
				MessageBox.Show("Resetting PICkit 2.\n\nPlease wait for USB enumeration\nto complete before clicking OK...", "Reset PICkit 2");
				Thread.Sleep(1000);
			}
			Close();
		}

		private void setupClearButtons()
		{
			if (PICkitFunctions.isCalibrated())
			{
				buttonClearCal.Enabled = true;
				buttonClearCal.Text = "Clear Calibration";
			}
			else
			{
				buttonClearCal.Enabled = false;
				buttonClearCal.Text = "Unit Not Calibrated";
			}
			if (PICkitFunctions.UnitIDRead().Length > 0)
			{
				buttonClearUnitID.Enabled = true;
				buttonClearUnitID.Text = "Clear Unit ID";
			}
			else
			{
				buttonClearUnitID.Enabled = false;
				buttonClearUnitID.Text = "No Assigned ID";
			}
		}

		private void buttonNext_Click(object sender, EventArgs e)
		{
			if (panelIntro.Visible)
			{
				panelIntro.Visible = false;
				panelSetup.Visible = true;
				buttonBack.Enabled = true;
			}
			else if (panelSetup.Visible)
			{
				panelSetup.Visible = false;
				panelCal.Visible = true;
				buttonCalibrate.Enabled = true;
				labelGoodCal.Visible = false;
				labelBadCal.Visible = false;
				textBoxVDD.Text = "4.000";
				textBoxVDD.Focus();
				textBoxVDD.SelectAll();
				PICkitFunctions.SetVoltageCals(256, 0, 128);
				PICkitFunctions.SetVDDVoltage(4f, 3.4f);
				PICkitFunctions.VddOn();
			}
			else if (panelCal.Visible)
			{
				panelCal.Visible = false;
				panelUnitID.Visible = true;
				buttonSetUnitID.Enabled = true;
				labelAssignedID.Visible = false;
				textBoxUnitID.Text = PICkitFunctions.UnitIDRead();
				textBoxUnitID.Focus();
				textBoxVDD.SelectAll();
				buttonNext.Enabled = false;
				buttonCancel.Text = "Finished";
				PICkitFunctions.VddOff();
			}
		}

		private void buttonBack_Click(object sender, EventArgs e)
		{
			if (panelSetup.Visible)
			{
				panelIntro.Visible = true;
				panelSetup.Visible = false;
				buttonBack.Enabled = false;
				setupClearButtons();
			}
			else if (panelCal.Visible)
			{
				PICkitFunctions.VddOff();
				panelSetup.Visible = true;
				panelCal.Visible = false;
			}
			else if (panelUnitID.Visible)
			{
				panelUnitID.Visible = false;
				panelCal.Visible = true;
				buttonCalibrate.Enabled = false;
				labelGoodCal.Visible = false;
				labelBadCal.Visible = false;
				textBoxVDD.Text = "-";
				buttonNext.Enabled = true;
				buttonCancel.Text = "Cancel";
			}
		}

		private void buttonCalibrate_Click(object sender, EventArgs e)
		{
			float vdd = 0f;
			float vpp = 0f;
			float num = 0f;
			bool flag = true;
			try
			{
				num = float.Parse(textBoxVDD.Text);
			}
			catch
			{
				MessageBox.Show("Invalid 'volts measured' value.");
				return;
			}
			PICkitFunctions.ReadPICkitVoltages(ref vdd, ref vpp);
			num /= vdd;
			if (num > 1.25f)
			{
				num = 1.25f;
				flag = false;
			}
			if (num < 0.75f)
			{
				num = 0.75f;
				flag = false;
			}
			float num2 = 256f * num;
			PICkitFunctions.SetVoltageCals((ushort)num2, 0, 128);
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			PICkitFunctions.SetVDDVoltage(3f, 2f);
			Thread.Sleep(150);
			PICkitFunctions.ReadPICkitVoltages(ref vdd, ref vpp);
			num5 = vdd;
			PICkitFunctions.SetVDDVoltage(4f, 2.7f);
			Thread.Sleep(150);
			PICkitFunctions.ReadPICkitVoltages(ref vdd, ref vpp);
			num3 = (3f - 4f * num5 / vdd) * (float)(PICkitFunctions.CalculateVddCPP(4f) >> 6);
			if (num3 > 127f)
			{
				num3 = 127f;
				flag = false;
			}
			if (num3 < -128f)
			{
				num3 = -128f;
				flag = false;
			}
			num4 = 1f / (vdd - num5) * 128f;
			if (num4 > 173f)
			{
				num4 = 173f;
				flag = false;
			}
			if (num4 < 83f)
			{
				num4 = 83f;
				flag = false;
			}
			if (flag)
			{
				labelGoodCal.Visible = true;
				labelBadCal.Visible = false;
				PICkitFunctions.SetVoltageCals((ushort)num2, (byte)num3, (byte)((double)num4 + 0.5));
			}
			else
			{
				labelGoodCal.Visible = false;
				labelBadCal.Visible = true;
				PICkitFunctions.SetVoltageCals(256, 0, 128);
			}
			buttonCalibrate.Enabled = false;
			PICkitFunctions.VddOff();
		}

		private void textBoxUnitID_TextChanged(object sender, EventArgs e)
		{
			if (textBoxUnitID.Text.Length > 14)
			{
				textBoxUnitID.Text = textBoxUnitID.Text.Substring(0, 14);
				textBoxUnitID.SelectionStart = 14;
			}
		}

		private void buttonSetUnitID_Click(object sender, EventArgs e)
		{
			if (PICkitFunctions.UnitIDWrite(textBoxUnitID.Text))
			{
				labelAssignedID.Visible = true;
				buttonSetUnitID.Enabled = false;
				unitIDChanged = true;
			}
		}

		private void buttonClearCal_Click(object sender, EventArgs e)
		{
			PICkitFunctions.SetVoltageCals(256, 0, 128);
			buttonClearCal.Enabled = false;
			buttonClearCal.Text = "Unit Not Calibrated";
		}

		private void buttonClearUnitID_Click(object sender, EventArgs e)
		{
			PICkitFunctions.UnitIDWrite("");
			buttonClearUnitID.Enabled = false;
			buttonClearUnitID.Text = "No Assigned ID";
			unitIDChanged = true;
		}
	}
}
