using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class DialogDevFile : Form
	{
		private IContainer components;

		private Label label1;

		private Button buttonLoadDevFile;

		private ListBox listBoxDevFiles;

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
			buttonLoadDevFile = new System.Windows.Forms.Button();
			listBoxDevFiles = new System.Windows.Forms.ListBox();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(16, 11);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(183, 17);
			label1.TabIndex = 1;
			label1.Text = "Select a Device File to load:";
			buttonLoadDevFile.Location = new System.Drawing.Point(144, 284);
			buttonLoadDevFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			buttonLoadDevFile.Name = "buttonLoadDevFile";
			buttonLoadDevFile.Size = new System.Drawing.Size(100, 28);
			buttonLoadDevFile.TabIndex = 2;
			buttonLoadDevFile.Text = "Load";
			buttonLoadDevFile.UseVisualStyleBackColor = true;
			buttonLoadDevFile.Click += new System.EventHandler(buttonLoadDevFile_Click);
			listBoxDevFiles.FormattingEnabled = true;
			listBoxDevFiles.ItemHeight = 16;
			listBoxDevFiles.Location = new System.Drawing.Point(20, 31);
			listBoxDevFiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			listBoxDevFiles.Name = "listBoxDevFiles";
			listBoxDevFiles.Size = new System.Drawing.Size(352, 244);
			listBoxDevFiles.TabIndex = 3;
			base.AutoScaleDimensions = new System.Drawing.SizeF(120f, 120f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(389, 327);
			base.Controls.Add(listBoxDevFiles);
			base.Controls.Add(buttonLoadDevFile);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DialogDevFile";
			Text = "DialogDevFile";
			ResumeLayout(false);
			PerformLayout();
		}

		public DialogDevFile()
		{
			InitializeComponent();
			DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
			FileInfo[] files = directoryInfo.GetFiles("*.dat");
			foreach (FileInfo fileInfo in files)
			{
				listBoxDevFiles.Items.Add(fileInfo.Name);
			}
		}

		private void buttonLoadDevFile_Click(object sender, EventArgs e)
		{
			FormPICkit2.DeviceFileName = listBoxDevFiles.SelectedItem.ToString();
			Close();
		}
	}
}
