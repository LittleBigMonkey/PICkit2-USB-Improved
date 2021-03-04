using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class DialogUserIDs : Form
	{
		public static bool IDMemOpen;

		private IContainer components;

		private DataGridView dataGridViewIDMem;

		private Button buttonClose;

		public DialogUserIDs()
		{
			InitializeComponent();
			IDMemOpen = true;
			dataGridViewIDMem.DefaultCellStyle.Font = new Font("Courier New", 9f);
			UpdateIDMemoryGrid();
		}

		public void UpdateIDMemoryGrid()
		{
			int width = (int)(53f * FormPICkit2.ScalefactW);
			dataGridViewIDMem.ColumnCount = 4;
			for (int i = 0; i < dataGridViewIDMem.ColumnCount; i++)
			{
				dataGridViewIDMem.Columns[i].Width = width;
			}
			int rowCount = PICkitFunctions.DeviceBuffers.UserIDs.Length / 4;
			dataGridViewIDMem.RowCount = rowCount;
			int num = 0;
			int num2 = 0;
			for (int j = 0; j < PICkitFunctions.DeviceBuffers.UserIDs.Length; j++)
			{
				dataGridViewIDMem[num2, num].Value = $"{PICkitFunctions.DeviceBuffers.UserIDs[j]:X6}";
				num2++;
				if (num2 >= 4)
				{
					num2 = 0;
					num++;
				}
			}
			dataGridViewIDMem[0, 0].Selected = true;
			dataGridViewIDMem[0, 0].Selected = false;
		}

		private void DialogUserIDs_FormClosing(object sender, FormClosingEventArgs e)
		{
			IDMemOpen = false;
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			dataGridViewIDMem = new System.Windows.Forms.DataGridView();
			buttonClose = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)dataGridViewIDMem).BeginInit();
			SuspendLayout();
			dataGridViewIDMem.AllowUserToAddRows = false;
			dataGridViewIDMem.AllowUserToDeleteRows = false;
			dataGridViewIDMem.AllowUserToResizeColumns = false;
			dataGridViewIDMem.AllowUserToResizeRows = false;
			dataGridViewIDMem.BackgroundColor = System.Drawing.SystemColors.Window;
			dataGridViewIDMem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dataGridViewIDMem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dataGridViewIDMem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewIDMem.ColumnHeadersVisible = false;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			dataGridViewIDMem.DefaultCellStyle = dataGridViewCellStyle2;
			dataGridViewIDMem.GridColor = System.Drawing.SystemColors.Window;
			dataGridViewIDMem.Location = new System.Drawing.Point(16, 15);
			dataGridViewIDMem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			dataGridViewIDMem.MultiSelect = false;
			dataGridViewIDMem.Name = "dataGridViewIDMem";
			dataGridViewIDMem.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dataGridViewIDMem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dataGridViewIDMem.RowHeadersVisible = false;
			dataGridViewIDMem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewIDMem.RowsDefaultCellStyle = dataGridViewCellStyle4;
			dataGridViewIDMem.RowTemplate.Height = 17;
			dataGridViewIDMem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			dataGridViewIDMem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			dataGridViewIDMem.ShowCellToolTips = false;
			dataGridViewIDMem.Size = new System.Drawing.Size(308, 170);
			dataGridViewIDMem.TabIndex = 0;
			buttonClose.Location = new System.Drawing.Point(133, 192);
			buttonClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			buttonClose.Name = "buttonClose";
			buttonClose.Size = new System.Drawing.Size(80, 28);
			buttonClose.TabIndex = 1;
			buttonClose.Text = "Close";
			buttonClose.UseVisualStyleBackColor = true;
			buttonClose.Click += new System.EventHandler(buttonClose_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(120f, 120f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(339, 233);
			base.Controls.Add(buttonClose);
			base.Controls.Add(dataGridViewIDMem);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DialogUserIDs";
			Text = "ID Memory";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(DialogUserIDs_FormClosing);
			((System.ComponentModel.ISupportInitialize)dataGridViewIDMem).EndInit();
			ResumeLayout(false);
		}
	}
}
