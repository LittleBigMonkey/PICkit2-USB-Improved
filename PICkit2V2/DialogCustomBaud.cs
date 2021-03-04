using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class DialogCustomBaud : Form
	{
		private IContainer components;

		private Label label1;

		private TextBox textBox1;

		private Button buttonOK;

		private Button buttonCancel;

		public DialogCustomBaud()
		{
			InitializeComponent();
			textBox1.Focus();
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (textBox1.Text.Length > 0 && !char.IsDigit(textBox1.Text[textBox1.Text.Length - 1]))
			{
				textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			try
			{
				int num = int.Parse(textBox1.Text);
				if (num < 150 || num > 38400)
				{
					MessageBox.Show("Baud value is outside\nthe Min / Max range.");
				}
				else
				{
					DialogUART.CustomBaud = textBox1.Text;
					Close();
				}
			}
			catch
			{
				MessageBox.Show("Illegal Value.");
			}
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
			label1 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			buttonOK = new System.Windows.Forms.Button();
			buttonCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(13, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(142, 65);
			label1.TabIndex = 0;
			label1.Text = "Enter baud rate in box below\r\nand click \"OK\".\r\n\r\nMinimum = 150 baud\r\nMaximum = 38400 baud";
			textBox1.Location = new System.Drawing.Point(16, 82);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(106, 20);
			textBox1.TabIndex = 1;
			textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
			buttonOK.Location = new System.Drawing.Point(13, 114);
			buttonOK.Name = "buttonOK";
			buttonOK.Size = new System.Drawing.Size(80, 22);
			buttonOK.TabIndex = 2;
			buttonOK.Text = "OK";
			buttonOK.UseVisualStyleBackColor = true;
			buttonOK.Click += new System.EventHandler(buttonOK_Click);
			buttonCancel.Location = new System.Drawing.Point(99, 114);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new System.Drawing.Size(80, 22);
			buttonCancel.TabIndex = 3;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += new System.EventHandler(buttonCancel_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(188, 148);
			base.ControlBox = false;
			base.Controls.Add(buttonCancel);
			base.Controls.Add(buttonOK);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DialogCustomBaud";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Custom Baud Rate";
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
