using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class DialogVDDErase : Form
	{
		private IContainer components;

		private Label label1;

		private Label label2;

		private Label label3;

		private CheckBox checkBoxDoNotShow;

		private Button buttonContinue;

		private Button buttonCancel;

		public DialogVDDErase()
		{
			InitializeComponent();
		}

		public void UpdateText()
		{
			label2.Text = "This device requires a minimum VDD of " + PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].VddErase.ToString() + "V\nfor Bulk Erase operations.";
		}

		private void continueClick(object sender, EventArgs e)
		{
			if (checkBoxDoNotShow.Checked)
			{
				FormPICkit2.ShowWriteEraseVDDDialog = false;
			}
			FormPICkit2.ContinueWriteErase = true;
			Close();
		}

		private void cancelClick(object sender, EventArgs e)
		{
			FormPICkit2.ContinueWriteErase = false;
			Close();
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
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			checkBoxDoNotShow = new System.Windows.Forms.CheckBox();
			buttonContinue = new System.Windows.Forms.Button();
			buttonCancel = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(13, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(58, 13);
			label1.TabIndex = 0;
			label1.Text = "Warning:";
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(13, 22);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(217, 26);
			label2.TabIndex = 1;
			label2.Text = "This device requires a minimum VDD of ?.?V\r\nfor Bulk Erase operations.";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(13, 62);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(217, 26);
			label3.TabIndex = 2;
			label3.Text = "If you continue it may fail to erase or program\r\nproperly.";
			checkBoxDoNotShow.AutoSize = true;
			checkBoxDoNotShow.Location = new System.Drawing.Point(13, 102);
			checkBoxDoNotShow.Name = "checkBoxDoNotShow";
			checkBoxDoNotShow.Size = new System.Drawing.Size(209, 17);
			checkBoxDoNotShow.TabIndex = 3;
			checkBoxDoNotShow.Text = "In the future, do not show this warning.";
			checkBoxDoNotShow.UseVisualStyleBackColor = true;
			buttonContinue.Location = new System.Drawing.Point(78, 126);
			buttonContinue.Name = "buttonContinue";
			buttonContinue.Size = new System.Drawing.Size(80, 22);
			buttonContinue.TabIndex = 4;
			buttonContinue.Text = "Continue";
			buttonContinue.UseVisualStyleBackColor = true;
			buttonContinue.Click += new System.EventHandler(continueClick);
			buttonCancel.Location = new System.Drawing.Point(164, 126);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new System.Drawing.Size(80, 22);
			buttonCancel.TabIndex = 5;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += new System.EventHandler(cancelClick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(254, 161);
			base.Controls.Add(buttonCancel);
			base.Controls.Add(buttonContinue);
			base.Controls.Add(checkBoxDoNotShow);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DialogVDDErase";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Warning!";
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
