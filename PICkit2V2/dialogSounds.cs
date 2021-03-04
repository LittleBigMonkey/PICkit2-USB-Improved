using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class dialogSounds : Form
	{
		private IContainer components;

		private Label label1;

		private Label label2;

		private Label label3;

		private CheckBox checkBoxSuccess;

		private CheckBox checkBoxWarning;

		private CheckBox checkBoxError;

		private TextBox textBoxSuccessFile;

		private TextBox textBoxWarningFile;

		private TextBox textBoxErrorFile;

		private Button buttonSuccessBrowse;

		private Button buttonWarningBrowse;

		private Button buttonErrorBrowse;

		private Button buttonOK;

		private OpenFileDialog openFileDialogWAV;

		private SoundPlayer wavPlayer = new SoundPlayer();

		private TextBox destSoundTextBox;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PICkit2V2.dialogSounds));
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			checkBoxSuccess = new System.Windows.Forms.CheckBox();
			checkBoxWarning = new System.Windows.Forms.CheckBox();
			checkBoxError = new System.Windows.Forms.CheckBox();
			textBoxSuccessFile = new System.Windows.Forms.TextBox();
			textBoxWarningFile = new System.Windows.Forms.TextBox();
			textBoxErrorFile = new System.Windows.Forms.TextBox();
			buttonSuccessBrowse = new System.Windows.Forms.Button();
			buttonWarningBrowse = new System.Windows.Forms.Button();
			buttonErrorBrowse = new System.Windows.Forms.Button();
			buttonOK = new System.Windows.Forms.Button();
			openFileDialogWAV = new System.Windows.Forms.OpenFileDialog();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(516, 39);
			label1.TabIndex = 0;
			label1.Text = resources.GetString("label1.Text");
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(12, 61);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(50, 13);
			label2.TabIndex = 0;
			label2.Text = "Enable:";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(110, 61);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(112, 13);
			label3.TabIndex = 0;
			label3.Text = "Play this WAV file:";
			checkBoxSuccess.BackColor = System.Drawing.Color.LimeGreen;
			checkBoxSuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			checkBoxSuccess.ForeColor = System.Drawing.SystemColors.ControlText;
			checkBoxSuccess.Location = new System.Drawing.Point(15, 80);
			checkBoxSuccess.Name = "checkBoxSuccess";
			checkBoxSuccess.Size = new System.Drawing.Size(74, 17);
			checkBoxSuccess.TabIndex = 1;
			checkBoxSuccess.Text = "Success";
			checkBoxSuccess.UseVisualStyleBackColor = false;
			checkBoxSuccess.Click += new System.EventHandler(checkBoxSuccess_CheckedChanged);
			checkBoxWarning.BackColor = System.Drawing.Color.Yellow;
			checkBoxWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			checkBoxWarning.ForeColor = System.Drawing.SystemColors.ControlText;
			checkBoxWarning.Location = new System.Drawing.Point(15, 103);
			checkBoxWarning.Name = "checkBoxWarning";
			checkBoxWarning.Size = new System.Drawing.Size(74, 17);
			checkBoxWarning.TabIndex = 1;
			checkBoxWarning.Text = "Warning";
			checkBoxWarning.UseVisualStyleBackColor = false;
			checkBoxWarning.Click += new System.EventHandler(checkBoxWarning_CheckedChanged);
			checkBoxError.BackColor = System.Drawing.Color.Salmon;
			checkBoxError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			checkBoxError.ForeColor = System.Drawing.SystemColors.ControlText;
			checkBoxError.Location = new System.Drawing.Point(15, 126);
			checkBoxError.Name = "checkBoxError";
			checkBoxError.Size = new System.Drawing.Size(74, 17);
			checkBoxError.TabIndex = 1;
			checkBoxError.Text = "Error";
			checkBoxError.UseVisualStyleBackColor = false;
			checkBoxError.Click += new System.EventHandler(checkBoxError_CheckedChanged);
			textBoxSuccessFile.Location = new System.Drawing.Point(113, 78);
			textBoxSuccessFile.Name = "textBoxSuccessFile";
			textBoxSuccessFile.Size = new System.Drawing.Size(341, 20);
			textBoxSuccessFile.TabIndex = 2;
			textBoxWarningFile.Location = new System.Drawing.Point(113, 101);
			textBoxWarningFile.Name = "textBoxWarningFile";
			textBoxWarningFile.Size = new System.Drawing.Size(341, 20);
			textBoxWarningFile.TabIndex = 2;
			textBoxErrorFile.Location = new System.Drawing.Point(113, 124);
			textBoxErrorFile.Name = "textBoxErrorFile";
			textBoxErrorFile.Size = new System.Drawing.Size(341, 20);
			textBoxErrorFile.TabIndex = 2;
			buttonSuccessBrowse.Location = new System.Drawing.Point(460, 76);
			buttonSuccessBrowse.Name = "buttonSuccessBrowse";
			buttonSuccessBrowse.Size = new System.Drawing.Size(60, 23);
			buttonSuccessBrowse.TabIndex = 3;
			buttonSuccessBrowse.Text = "Browse";
			buttonSuccessBrowse.UseVisualStyleBackColor = true;
			buttonSuccessBrowse.Click += new System.EventHandler(buttonSuccessBrowse_Click);
			buttonWarningBrowse.Location = new System.Drawing.Point(460, 99);
			buttonWarningBrowse.Name = "buttonWarningBrowse";
			buttonWarningBrowse.Size = new System.Drawing.Size(60, 23);
			buttonWarningBrowse.TabIndex = 3;
			buttonWarningBrowse.Text = "Browse";
			buttonWarningBrowse.UseVisualStyleBackColor = true;
			buttonWarningBrowse.Click += new System.EventHandler(button1_Click);
			buttonErrorBrowse.Location = new System.Drawing.Point(460, 122);
			buttonErrorBrowse.Name = "buttonErrorBrowse";
			buttonErrorBrowse.Size = new System.Drawing.Size(60, 23);
			buttonErrorBrowse.TabIndex = 3;
			buttonErrorBrowse.Text = "Browse";
			buttonErrorBrowse.UseVisualStyleBackColor = true;
			buttonErrorBrowse.Click += new System.EventHandler(buttonErrorBrowse_Click);
			buttonOK.Location = new System.Drawing.Point(437, 151);
			buttonOK.Name = "buttonOK";
			buttonOK.Size = new System.Drawing.Size(83, 23);
			buttonOK.TabIndex = 3;
			buttonOK.Text = "OK";
			buttonOK.UseVisualStyleBackColor = true;
			buttonOK.Click += new System.EventHandler(buttonOK_Click);
			openFileDialogWAV.DefaultExt = "wav";
			openFileDialogWAV.Filter = "WAV files|*.wav|All files|*.*";
			openFileDialogWAV.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialogWAV_FileOk);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(532, 182);
			base.Controls.Add(buttonOK);
			base.Controls.Add(buttonErrorBrowse);
			base.Controls.Add(buttonWarningBrowse);
			base.Controls.Add(buttonSuccessBrowse);
			base.Controls.Add(textBoxErrorFile);
			base.Controls.Add(textBoxWarningFile);
			base.Controls.Add(textBoxSuccessFile);
			base.Controls.Add(checkBoxError);
			base.Controls.Add(checkBoxWarning);
			base.Controls.Add(checkBoxSuccess);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "dialogSounds";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Alert Sounds";
			ResumeLayout(false);
			PerformLayout();
		}

		public dialogSounds()
		{
			InitializeComponent();
			checkBoxSuccess.Checked = FormPICkit2.PlaySuccessWav;
			checkBoxWarning.Checked = FormPICkit2.PlayWarningWav;
			checkBoxError.Checked = FormPICkit2.PlayErrorWav;
			textBoxSuccessFile.Text = FormPICkit2.SuccessWavFile;
			textBoxWarningFile.Text = FormPICkit2.WarningWavFile;
			textBoxErrorFile.Text = FormPICkit2.ErrorWavFile;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			FormPICkit2.PlaySuccessWav = checkBoxSuccess.Checked;
			FormPICkit2.PlayWarningWav = checkBoxWarning.Checked;
			FormPICkit2.PlayErrorWav = checkBoxError.Checked;
			FormPICkit2.SuccessWavFile = textBoxSuccessFile.Text;
			FormPICkit2.WarningWavFile = textBoxWarningFile.Text;
			FormPICkit2.ErrorWavFile = textBoxErrorFile.Text;
			Close();
		}

		private void buttonSuccessBrowse_Click(object sender, EventArgs e)
		{
			destSoundTextBox = textBoxSuccessFile;
			openFileDialogWAV.FileName = textBoxSuccessFile.Text;
			openFileDialogWAV.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			destSoundTextBox = textBoxWarningFile;
			openFileDialogWAV.FileName = textBoxWarningFile.Text;
			openFileDialogWAV.ShowDialog();
		}

		private void buttonErrorBrowse_Click(object sender, EventArgs e)
		{
			destSoundTextBox = textBoxErrorFile;
			openFileDialogWAV.FileName = textBoxErrorFile.Text;
			openFileDialogWAV.ShowDialog();
		}

		private void checkBoxSuccess_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxSuccess.Checked)
			{
				try
				{
					wavPlayer.SoundLocation = textBoxSuccessFile.Text;
					wavPlayer.Play();
				}
				catch
				{
				}
			}
		}

		private void checkBoxWarning_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxWarning.Checked)
			{
				try
				{
					wavPlayer.SoundLocation = textBoxWarningFile.Text;
					wavPlayer.Play();
				}
				catch
				{
				}
			}
		}

		private void checkBoxError_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxError.Checked)
			{
				try
				{
					wavPlayer.SoundLocation = textBoxErrorFile.Text;
					wavPlayer.Play();
				}
				catch
				{
				}
			}
		}

		private void openFileDialogWAV_FileOk(object sender, CancelEventArgs e)
		{
			destSoundTextBox.Text = openFileDialogWAV.FileName;
		}
	}
}
