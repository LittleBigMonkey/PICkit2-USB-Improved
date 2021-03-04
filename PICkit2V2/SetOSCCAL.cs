using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class SetOSCCAL : Form
	{
		private IContainer components;

		private Label label1;

		private TextBox textBoxOSCCAL;

		private Label label2;

		private Button buttonSet;

		private Button buttonCancel;

		private Label label3;

		private Label label4;

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
			label1 = new System.Windows.Forms.Label();
			textBoxOSCCAL = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			buttonSet = new System.Windows.Forms.Button();
			buttonCancel = new System.Windows.Forms.Button();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(10, 15);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(81, 13);
			label1.TabIndex = 0;
			label1.Text = "OSCCAL value:";
			textBoxOSCCAL.Location = new System.Drawing.Point(93, 12);
			textBoxOSCCAL.Name = "textBoxOSCCAL";
			textBoxOSCCAL.Size = new System.Drawing.Size(54, 20);
			textBoxOSCCAL.TabIndex = 1;
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(153, 15);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(30, 13);
			label2.TabIndex = 2;
			label2.Text = "(hex)";
			buttonSet.Location = new System.Drawing.Point(12, 88);
			buttonSet.Name = "buttonSet";
			buttonSet.Size = new System.Drawing.Size(75, 23);
			buttonSet.TabIndex = 3;
			buttonSet.Text = "Set";
			buttonSet.UseVisualStyleBackColor = true;
			buttonSet.Click += new System.EventHandler(clickSet);
			buttonCancel.Location = new System.Drawing.Point(105, 88);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new System.Drawing.Size(75, 23);
			buttonCancel.TabIndex = 4;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += new System.EventHandler(clickCancel);
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.ForeColor = System.Drawing.Color.Red;
			label3.Location = new System.Drawing.Point(10, 37);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(71, 13);
			label3.TabIndex = 5;
			label3.Text = "WARNING:";
			label4.AutoSize = true;
			label4.ForeColor = System.Drawing.Color.Red;
			label4.Location = new System.Drawing.Point(10, 53);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(153, 26);
			label4.TabIndex = 6;
			label4.Text = "Setting OSCCAL will erase ALL\r\nmemory in part!";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(192, 123);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(buttonCancel);
			base.Controls.Add(buttonSet);
			base.Controls.Add(label2);
			base.Controls.Add(textBoxOSCCAL);
			base.Controls.Add(label1);
			base.Name = "SetOSCCAL";
			base.ShowIcon = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Set OSCCAL";
			ResumeLayout(false);
			PerformLayout();
		}

		public SetOSCCAL()
		{
			InitializeComponent();
			textBoxOSCCAL.Text = $"{PICkitFunctions.DeviceBuffers.OSCCAL:X4}";
			textBoxOSCCAL.SelectAll();
		}

		private void clickSet(object sender, EventArgs e)
		{
			try
			{
				string p_value = (textBoxOSCCAL.Text.Substring(0, 2) == "0x") ? textBoxOSCCAL.Text : ((!(textBoxOSCCAL.Text.Substring(0, 1) == "x")) ? ("0x" + textBoxOSCCAL.Text) : ("0" + textBoxOSCCAL.Text));
				int oSCCAL = Utilities.Convert_Value_To_Int(p_value);
				PICkitFunctions.DeviceBuffers.OSCCAL = (uint)oSCCAL;
				FormPICkit2.setOSCCALValue = true;
				Close();
			}
			catch
			{
				textBoxOSCCAL.Text = $"{PICkitFunctions.DeviceBuffers.OSCCAL:X4}";
			}
		}

		private void clickCancel(object sender, EventArgs e)
		{
			FormPICkit2.setOSCCALValue = false;
			Close();
		}
	}
}
