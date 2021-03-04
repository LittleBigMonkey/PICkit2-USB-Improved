using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class DialogUnitSelect : Form
	{
		private IContainer components;

		private Label label1;

		private Button buttonSelectUnit;

		private ListBox listBoxUnits;

		private Label label2;

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
			buttonSelectUnit = new System.Windows.Forms.Button();
			listBoxUnits = new System.Windows.Forms.ListBox();
			label2 = new System.Windows.Forms.Label();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(13, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(190, 48);
			label1.TabIndex = 0;
			label1.Text = "More than one PICkit 2 unit has\r\nbeen detected. \r\nPlease select a PICkit 2 to use:";
			buttonSelectUnit.Enabled = false;
			buttonSelectUnit.Location = new System.Drawing.Point(76, 166);
			buttonSelectUnit.Name = "buttonSelectUnit";
			buttonSelectUnit.Size = new System.Drawing.Size(80, 26);
			buttonSelectUnit.TabIndex = 2;
			buttonSelectUnit.Text = "Select";
			buttonSelectUnit.UseVisualStyleBackColor = true;
			buttonSelectUnit.Click += new System.EventHandler(buttonSelectUnit_Click);
			listBoxUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			listBoxUnits.FormattingEnabled = true;
			listBoxUnits.ItemHeight = 15;
			listBoxUnits.Location = new System.Drawing.Point(16, 86);
			listBoxUnits.Name = "listBoxUnits";
			listBoxUnits.Size = new System.Drawing.Size(199, 64);
			listBoxUnits.TabIndex = 4;
			listBoxUnits.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(listBoxUnits_MouseDoubleClick);
			listBoxUnits.SelectedIndexChanged += new System.EventHandler(listBoxUnits_SelectedIndexChanged);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(13, 70);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(122, 13);
			label2.TabIndex = 5;
			label2.Text = "Unit#            UnitID";
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(231, 211);
			base.ControlBox = false;
			base.Controls.Add(label2);
			base.Controls.Add(listBoxUnits);
			base.Controls.Add(buttonSelectUnit);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DialogUnitSelect";
			base.ShowIcon = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Select PICkit 2 Unit";
			ResumeLayout(false);
			PerformLayout();
		}

		public DialogUnitSelect()
		{
			InitializeComponent();
			base.Size = new Size(base.Size.Width, (int)(FormPICkit2.ScalefactH * (float)base.Size.Height));
			ushort num = 0;
			while (num < 8)
			{
				Constants.PICkit2USB pICkit2USB = PICkitFunctions.DetectPICkit2Device(num, readFW: false);
				if (pICkit2USB != Constants.PICkit2USB.notFound)
				{
					string text = PICkitFunctions.GetSerialUnitID();
					if (text == "PIC18F2550")
					{
						text = "<bootloader>";
					}
					listBoxUnits.Items.Add("  " + num.ToString() + "                " + text);
					num = (ushort)(num + 1);
					continue;
				}
				break;
			}
		}

		private void listBoxUnits_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			FormPICkit2.pk2number = (ushort)listBoxUnits.SelectedIndex;
			Close();
		}

		private void listBoxUnits_SelectedIndexChanged(object sender, EventArgs e)
		{
			buttonSelectUnit.Enabled = true;
		}

		private void buttonSelectUnit_Click(object sender, EventArgs e)
		{
			FormPICkit2.pk2number = (ushort)listBoxUnits.SelectedIndex;
			Close();
		}
	}
}
