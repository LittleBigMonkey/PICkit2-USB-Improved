using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class DialogAbout : Form
	{
		private IContainer components;

		private Label label1;

		private Label label2;

		private Label label3;

		private Label label4;

		private Label label5;

		private Label displayAppVer;

		private Label displayDevFileVer;

		private Label displayPk2FWVer;

		private TextBox textBox1;

		private LinkLabel linkLabel1;

		private Button buttonOK;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PICkit2V2.DialogAbout));
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			displayAppVer = new System.Windows.Forms.Label();
			displayDevFileVer = new System.Windows.Forms.Label();
			displayPk2FWVer = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			buttonOK = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Arial", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(13, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(64, 22);
			label1.TabIndex = 0;
			label1.Text = "PICkit";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Lucida Handwriting", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.ForeColor = System.Drawing.Color.Red;
			label2.Location = new System.Drawing.Point(74, 4);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(31, 31);
			label2.TabIndex = 1;
			label2.Text = "2";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(226, 9);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(97, 13);
			label3.TabIndex = 2;
			label3.Text = "Application Version";
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(226, 22);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(98, 13);
			label4.TabIndex = 3;
			label4.Text = "Device File Version";
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(226, 34);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(105, 13);
			label5.TabIndex = 4;
			label5.Text = "OS Firmware Version";
			displayAppVer.AutoSize = true;
			displayAppVer.Location = new System.Drawing.Point(364, 9);
			displayAppVer.Name = "displayAppVer";
			displayAppVer.Size = new System.Drawing.Size(43, 13);
			displayAppVer.TabIndex = 5;
			displayAppVer.Text = "2.00.00";
			displayAppVer.TextAlign = System.Drawing.ContentAlignment.TopRight;
			displayDevFileVer.AutoSize = true;
			displayDevFileVer.Location = new System.Drawing.Point(364, 22);
			displayDevFileVer.Name = "displayDevFileVer";
			displayDevFileVer.Size = new System.Drawing.Size(49, 13);
			displayDevFileVer.TabIndex = 6;
			displayDevFileVer.Text = "00.00.00";
			displayDevFileVer.TextAlign = System.Drawing.ContentAlignment.TopRight;
			displayPk2FWVer.AutoSize = true;
			displayPk2FWVer.Location = new System.Drawing.Point(364, 34);
			displayPk2FWVer.Name = "displayPk2FWVer";
			displayPk2FWVer.Size = new System.Drawing.Size(49, 13);
			displayPk2FWVer.TabIndex = 7;
			displayPk2FWVer.Text = "00.00.00";
			displayPk2FWVer.TextAlign = System.Drawing.ContentAlignment.TopRight;
			textBox1.BackColor = System.Drawing.SystemColors.Window;
			textBox1.Location = new System.Drawing.Point(13, 62);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.ReadOnly = true;
			textBox1.Size = new System.Drawing.Size(403, 216);
			textBox1.TabIndex = 8;
			textBox1.Text = resources.GetString("textBox1.Text");
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new System.Drawing.Point(14, 34);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(102, 13);
			linkLabel1.TabIndex = 9;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "www.microchip.com";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(microchipLinkClicked);
			buttonOK.Location = new System.Drawing.Point(178, 283);
			buttonOK.Name = "buttonOK";
			buttonOK.Size = new System.Drawing.Size(79, 22);
			buttonOK.TabIndex = 10;
			buttonOK.Text = "OK";
			buttonOK.UseVisualStyleBackColor = true;
			buttonOK.Click += new System.EventHandler(clickOK);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(429, 314);
			base.Controls.Add(buttonOK);
			base.Controls.Add(linkLabel1);
			base.Controls.Add(textBox1);
			base.Controls.Add(displayPk2FWVer);
			base.Controls.Add(displayDevFileVer);
			base.Controls.Add(displayAppVer);
			base.Controls.Add(label5);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DialogAbout";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "About";
			ResumeLayout(false);
			PerformLayout();
		}

		public DialogAbout()
		{
			InitializeComponent();
			displayAppVer.Text = "2.61.00";
			displayDevFileVer.Text = PICkitFunctions.DeviceFileVersion;
			displayPk2FWVer.Text = PICkitFunctions.FirmwareVersion;
			textBox1.Select(0, 0);
		}

		private void clickOK(object sender, EventArgs e)
		{
			Close();
		}

		private void microchipLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				visitMicrochipSite();
			}
			catch
			{
				MessageBox.Show("Unable to open link that was clicked.");
			}
		}

		private void visitMicrochipSite()
		{
			linkLabel1.LinkVisited = true;
			Process.Start("http://www.microchip.com");
		}
	}
}
