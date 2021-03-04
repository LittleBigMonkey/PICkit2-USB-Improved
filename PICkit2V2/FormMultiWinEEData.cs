using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class FormMultiWinEEData : Form
	{
		private IContainer components;

		private ComboBox comboBoxProgMemView;

		private DataGridView dataGridProgramMemory;

		private Label displayEEProgInfo;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem toolStripMenuItemContextSelectAll;

		private ToolStripMenuItem toolStripMenuItemContextCopy;

		public bool InitDone;

		private string dataFormat = "";

		private string addrFormat = "";

		private bool maxed;

		private bool progMemJustEdited;

		private int asciiBytes;

		private int lastPart;

		private int lastFam;

		public DelegateMemEdited TellMainFormProgMemEdited;

		public DelegateUpdateGUI TellMainFormUpdateGUI;

		public DelegateMultiEEMemClosed TellMainFormEEMemClosed;

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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PICkit2V2.FormMultiWinEEData));
			comboBoxProgMemView = new System.Windows.Forms.ComboBox();
			dataGridProgramMemory = new System.Windows.Forms.DataGridView();
			displayEEProgInfo = new System.Windows.Forms.Label();
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripMenuItemContextSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItemContextCopy = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)dataGridProgramMemory).BeginInit();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			comboBoxProgMemView.BackColor = System.Drawing.SystemColors.Info;
			comboBoxProgMemView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBoxProgMemView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			comboBoxProgMemView.FormattingEnabled = true;
			comboBoxProgMemView.Items.AddRange(new object[3]
			{
				"Hex Only",
				"Word ASCII",
				"Byte ASCII"
			});
			comboBoxProgMemView.Location = new System.Drawing.Point(12, 11);
			comboBoxProgMemView.Margin = new System.Windows.Forms.Padding(2);
			comboBoxProgMemView.Name = "comboBoxProgMemView";
			comboBoxProgMemView.Size = new System.Drawing.Size(91, 21);
			comboBoxProgMemView.TabIndex = 8;
			comboBoxProgMemView.SelectionChangeCommitted += new System.EventHandler(comboBoxProgMemView_SelectionChangeCommitted);
			dataGridProgramMemory.AllowUserToAddRows = false;
			dataGridProgramMemory.AllowUserToDeleteRows = false;
			dataGridProgramMemory.AllowUserToResizeColumns = false;
			dataGridProgramMemory.AllowUserToResizeRows = false;
			dataGridProgramMemory.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			dataGridProgramMemory.BackgroundColor = System.Drawing.SystemColors.Window;
			dataGridProgramMemory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dataGridProgramMemory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dataGridProgramMemory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridProgramMemory.ColumnHeadersVisible = false;
			dataGridProgramMemory.ContextMenuStrip = contextMenuStrip1;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			dataGridProgramMemory.DefaultCellStyle = dataGridViewCellStyle2;
			dataGridProgramMemory.Enabled = false;
			dataGridProgramMemory.Location = new System.Drawing.Point(12, 39);
			dataGridProgramMemory.Name = "dataGridProgramMemory";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dataGridProgramMemory.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dataGridProgramMemory.RowHeadersVisible = false;
			dataGridProgramMemory.RowHeadersWidth = 75;
			dataGridProgramMemory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridProgramMemory.RowsDefaultCellStyle = dataGridViewCellStyle4;
			dataGridProgramMemory.RowTemplate.Height = 17;
			dataGridProgramMemory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			dataGridProgramMemory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			dataGridProgramMemory.Size = new System.Drawing.Size(510, 49);
			dataGridProgramMemory.TabIndex = 7;
			dataGridProgramMemory.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridProgramMemory_CellMouseDown);
			dataGridProgramMemory.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(progMemEdit);
			displayEEProgInfo.AutoSize = true;
			displayEEProgInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			displayEEProgInfo.ForeColor = System.Drawing.Color.Red;
			displayEEProgInfo.Location = new System.Drawing.Point(107, 14);
			displayEEProgInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			displayEEProgInfo.Name = "displayEEProgInfo";
			displayEEProgInfo.Size = new System.Drawing.Size(206, 13);
			displayEEProgInfo.TabIndex = 9;
			displayEEProgInfo.Text = "Preserve EEPROM and User IDs on write.";
			displayEEProgInfo.Visible = false;
			contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2]
			{
				toolStripMenuItemContextSelectAll,
				toolStripMenuItemContextCopy
			});
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new System.Drawing.Size(164, 48);
			toolStripMenuItemContextSelectAll.Name = "toolStripMenuItemContextSelectAll";
			toolStripMenuItemContextSelectAll.ShortcutKeyDisplayString = "Ctrl-A";
			toolStripMenuItemContextSelectAll.Size = new System.Drawing.Size(163, 22);
			toolStripMenuItemContextSelectAll.Text = "Select All";
			toolStripMenuItemContextSelectAll.Click += new System.EventHandler(toolStripMenuItemContextSelectAll_Click);
			toolStripMenuItemContextCopy.Name = "toolStripMenuItemContextCopy";
			toolStripMenuItemContextCopy.ShortcutKeyDisplayString = "Ctrl-C";
			toolStripMenuItemContextCopy.Size = new System.Drawing.Size(163, 22);
			toolStripMenuItemContextCopy.Text = "Copy";
			toolStripMenuItemContextCopy.Click += new System.EventHandler(toolStripMenuItemContextCopy_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(536, 100);
			base.Controls.Add(displayEEProgInfo);
			base.Controls.Add(comboBoxProgMemView);
			base.Controls.Add(dataGridProgramMemory);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MinimumSize = new System.Drawing.Size(200, 110);
			base.Name = "FormMultiWinEEData";
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "PICkit 2 EEPROM Data";
			base.Resize += new System.EventHandler(FormMultiWinEEData_Resize);
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormMultiWinEEData_FormClosing);
			base.ResizeEnd += new System.EventHandler(FormMultiWinEEData_ResizeEnd);
			((System.ComponentModel.ISupportInitialize)dataGridProgramMemory).EndInit();
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		public FormMultiWinEEData()
		{
			InitializeComponent();
		}

		public void InitMemDisplay(int viewMode)
		{
			dataGridProgramMemory.DefaultCellStyle.Font = new Font("Courier New", 9f);
			comboBoxProgMemView.SelectedIndex = viewMode;
			ReCalcMultiWinMem();
			InitDone = true;
		}

		public int GetViewMode()
		{
			return comboBoxProgMemView.SelectedIndex;
		}

		public void DisplayDisable()
		{
			comboBoxProgMemView.Enabled = false;
			dataGridProgramMemory.Enabled = false;
			dataGridProgramMemory.ForeColor = SystemColors.GrayText;
		}

		public void DisplayEnable()
		{
			comboBoxProgMemView.Enabled = true;
			dataGridProgramMemory.Enabled = true;
			dataGridProgramMemory.ForeColor = SystemColors.WindowText;
		}

		public void DisplayEETextOn(string displayText)
		{
			displayEEProgInfo.Text = displayText;
			displayEEProgInfo.Visible = true;
		}

		public void DisplayEETextOff()
		{
			displayEEProgInfo.Visible = false;
		}

		public void ReCalcMultiWinMem()
		{
			uint eEMem = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem;
			if (eEMem == 0 || base.WindowState == FormWindowState.Minimized)
			{
				return;
			}
			uint num = eEMem * PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemAddressIncrement - 1;
			int num2 = 30;
			addrFormat = "{0:X2}";
			if (num > 4095)
			{
				num2 = 40;
				addrFormat = "{0:X4}";
			}
			else if (num > 255)
			{
				num2 = 32;
				addrFormat = "{0:X3}";
			}
			num2 = (int)((float)num2 * FormPICkit2.ScalefactW);
			uint blankValue = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue;
			int num3 = 24;
			int num4 = 16;
			asciiBytes = 1;
			dataFormat = "{0:X2}";
			if (blankValue > 65535)
			{
				num3 = 36;
				num4 = 28;
				asciiBytes = 2;
				dataFormat = "{0:X4}";
			}
			else if (blankValue == 4095)
			{
				num3 = 28;
				num4 = 28;
				asciiBytes = 2;
				dataFormat = "{0:X3}";
			}
			float num5 = 1f;
			if (comboBoxProgMemView.SelectedIndex > 0)
			{
				num5 = (float)num4 / ((float)num4 + (float)num3);
				num3 += num4;
			}
			num3 = (int)((float)num3 * FormPICkit2.ScalefactW);
			int num6 = dataGridProgramMemory.Size.Width - num2 - (int)(20f * FormPICkit2.ScalefactW);
			int num7 = num6 / num3;
			for (int num8 = 1; num8 <= 256; num8 *= 2)
			{
				if (num8 > num7)
				{
					num7 = num8 / 2;
					break;
				}
			}
			if (num7 > (int)eEMem)
			{
				num7 = (int)eEMem;
			}
			num3 = num6 / num7;
			if (comboBoxProgMemView.SelectedIndex > 0)
			{
				num4 = (int)(num5 * (float)num3);
				num3 -= num4;
			}
			if (dataGridProgramMemory.FirstDisplayedCell != null && !progMemJustEdited)
			{
				int rowIndex = dataGridProgramMemory.FirstDisplayedCell.RowIndex;
				dataGridProgramMemory.MultiSelect = false;
				dataGridProgramMemory[0, rowIndex].Selected = true;
				dataGridProgramMemory[0, rowIndex].Selected = false;
				dataGridProgramMemory.MultiSelect = true;
			}
			else if (dataGridProgramMemory.FirstDisplayedCell == null && dataGridProgramMemory.RowCount > 0)
			{
				dataGridProgramMemory.MultiSelect = false;
				dataGridProgramMemory[0, 0].Selected = true;
				dataGridProgramMemory[0, 0].Selected = false;
				dataGridProgramMemory.MultiSelect = true;
			}
			progMemJustEdited = false;
			dataGridProgramMemory.Rows.Clear();
			if (comboBoxProgMemView.SelectedIndex > 0)
			{
				dataGridProgramMemory.ColumnCount = 2 * num7 + 1;
			}
			else
			{
				dataGridProgramMemory.ColumnCount = num7 + 1;
			}
			dataGridProgramMemory.Columns[0].Width = num2;
			for (int i = 1; i <= num7; i++)
			{
				dataGridProgramMemory.Columns[i].Width = num3;
			}
			if (comboBoxProgMemView.SelectedIndex > 0)
			{
				for (int j = num7 + 1; j <= 2 * num7; j++)
				{
					dataGridProgramMemory.Columns[j].Width = num4;
				}
			}
			int num9 = (int)eEMem / num7;
			if ((long)eEMem % (long)num7 > 0)
			{
				num9++;
			}
			dataGridProgramMemory.RowCount = num9;
			int num10 = num7 * PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemAddressIncrement;
			int k = 0;
			int num11 = 0;
			for (; k < num9; k++)
			{
				dataGridProgramMemory[0, k].Value = string.Format(addrFormat, num11);
				dataGridProgramMemory[0, k].ReadOnly = true;
				dataGridProgramMemory[0, k].Style.BackColor = SystemColors.ControlLight;
				num11 += num10;
			}
			updateDisplay();
		}

		public void UpdateMultiWinMem()
		{
			if (lastPart != PICkitFunctions.ActivePart || lastFam != PICkitFunctions.GetActiveFamily())
			{
				ReCalcMultiWinMem();
			}
			else
			{
				updateDisplay();
			}
		}

		private void updateDisplay()
		{
			int num = dataGridProgramMemory.RowCount - 1;
			int num2 = dataGridProgramMemory.ColumnCount - 1;
			int eEMemAddressIncrement = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].EEMemAddressIncrement;
			if (comboBoxProgMemView.SelectedIndex > 0)
			{
				num2 /= 2;
			}
			int i = 0;
			int num3 = 0;
			int num4 = 0;
			for (; i < num; i++)
			{
				for (int j = 1; j <= num2; j++)
				{
					dataGridProgramMemory[j, i].Value = string.Format(dataFormat, PICkitFunctions.DeviceBuffers.EEPromMemory[num3++]);
					dataGridProgramMemory[j, i].ToolTipText = string.Format(addrFormat, num4);
					num4 += eEMemAddressIncrement;
				}
			}
			int num5 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem % num2;
			if (num5 == 0)
			{
				num5 = num2;
			}
			int num6 = num * num2;
			for (int k = 1; k <= num2; k++)
			{
				if (k <= num5)
				{
					dataGridProgramMemory[k, num].Value = string.Format(dataFormat, PICkitFunctions.DeviceBuffers.EEPromMemory[num6++]);
					dataGridProgramMemory[k, num].ToolTipText = string.Format(addrFormat, num6 * eEMemAddressIncrement);
				}
				else
				{
					dataGridProgramMemory[k, num].Value = "";
					dataGridProgramMemory[k, num].ToolTipText = "";
					dataGridProgramMemory[k, num].ReadOnly = true;
				}
			}
			if (comboBoxProgMemView.SelectedIndex > 0)
			{
				for (int l = num2 + 1; l <= 2 * num2; l++)
				{
					dataGridProgramMemory.Columns[l].ReadOnly = true;
				}
				if (comboBoxProgMemView.SelectedIndex == 1)
				{
					int m = 0;
					int num7 = 0;
					int num8 = 0;
					for (; m < num; m++)
					{
						for (int n = num2 + 1; n <= 2 * num2; n++)
						{
							dataGridProgramMemory[n, m].Value = Utilities.ConvertIntASCII((int)PICkitFunctions.DeviceBuffers.EEPromMemory[num7++], asciiBytes);
							dataGridProgramMemory[n, m].ToolTipText = string.Format(addrFormat, num8);
							num8 += eEMemAddressIncrement;
						}
					}
					num6 = num * num2;
					for (int num9 = num2 + 1; num9 <= 2 * num2; num9++)
					{
						if (num9 <= num2 + num5)
						{
							dataGridProgramMemory[num9, num].Value = Utilities.ConvertIntASCII((int)PICkitFunctions.DeviceBuffers.EEPromMemory[num6++], asciiBytes);
							dataGridProgramMemory[num9, num].ToolTipText = string.Format(addrFormat, num6 * eEMemAddressIncrement);
						}
						else
						{
							dataGridProgramMemory[num9, num].Value = "";
							dataGridProgramMemory[num9, num].ToolTipText = "";
							dataGridProgramMemory[num9, num].ReadOnly = true;
						}
					}
				}
				else
				{
					int num10 = 0;
					int num11 = 0;
					int num12 = 0;
					for (; num10 < num; num10++)
					{
						for (int num13 = num2 + 1; num13 <= 2 * num2; num13++)
						{
							dataGridProgramMemory[num13, num10].Value = Utilities.ConvertIntASCIIReverse((int)PICkitFunctions.DeviceBuffers.EEPromMemory[num11++], asciiBytes);
							dataGridProgramMemory[num13, num10].ToolTipText = string.Format(addrFormat, num12);
							num12 += eEMemAddressIncrement;
						}
					}
					num6 = num * num2;
					for (int num14 = num2 + 1; num14 <= 2 * num2; num14++)
					{
						if (num14 <= num2 + num5)
						{
							dataGridProgramMemory[num14, num].Value = Utilities.ConvertIntASCIIReverse((int)PICkitFunctions.DeviceBuffers.EEPromMemory[num6++], asciiBytes);
							dataGridProgramMemory[num14, num].ToolTipText = string.Format(addrFormat, num6 * eEMemAddressIncrement);
						}
						else
						{
							dataGridProgramMemory[num14, num].Value = "";
							dataGridProgramMemory[num14, num].ToolTipText = "";
							dataGridProgramMemory[num14, num].ReadOnly = true;
						}
					}
				}
			}
			if (dataGridProgramMemory.FirstDisplayedCell != null && !progMemJustEdited)
			{
				int rowIndex = dataGridProgramMemory.FirstDisplayedCell.RowIndex;
				dataGridProgramMemory.MultiSelect = false;
				dataGridProgramMemory[0, rowIndex].Selected = true;
				dataGridProgramMemory[0, rowIndex].Selected = false;
				dataGridProgramMemory.MultiSelect = true;
			}
			else if (dataGridProgramMemory.FirstDisplayedCell == null)
			{
				dataGridProgramMemory.MultiSelect = false;
				dataGridProgramMemory[0, 0].Selected = true;
				dataGridProgramMemory[0, 0].Selected = false;
				dataGridProgramMemory.MultiSelect = true;
			}
			progMemJustEdited = false;
		}

		private void progMemEdit(object sender, DataGridViewCellEventArgs e)
		{
			int rowIndex = e.RowIndex;
			int columnIndex = e.ColumnIndex;
			string p_value = "0x" + dataGridProgramMemory[columnIndex, rowIndex].FormattedValue.ToString();
			int num = 0;
			try
			{
				num = Utilities.Convert_Value_To_Int(p_value);
			}
			catch
			{
				num = 0;
			}
			int num2 = dataGridProgramMemory.ColumnCount - 1;
			if (comboBoxProgMemView.SelectedIndex >= 1)
			{
				num2 /= 2;
			}
			uint num3 = 255u;
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 65535)
			{
				num3 = 65535u;
			}
			else if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue == 4095)
			{
				num3 = 4095u;
			}
			PICkitFunctions.DeviceBuffers.EEPromMemory[rowIndex * num2 + columnIndex - 1] = (uint)(num & num3);
			TellMainFormProgMemEdited();
			progMemJustEdited = true;
			TellMainFormUpdateGUI();
		}

		private void FormMultiWinEEData_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				e.Cancel = true;
				TellMainFormEEMemClosed();
				Hide();
			}
		}

		private void comboBoxProgMemView_SelectionChangeCommitted(object sender, EventArgs e)
		{
			ReCalcMultiWinMem();
		}

		private void FormMultiWinEEData_ResizeEnd(object sender, EventArgs e)
		{
			ReCalcMultiWinMem();
		}

		private void FormMultiWinEEData_Resize(object sender, EventArgs e)
		{
			if (base.WindowState == FormWindowState.Maximized)
			{
				maxed = true;
				ReCalcMultiWinMem();
			}
			else if (maxed)
			{
				maxed = false;
				ReCalcMultiWinMem();
			}
		}

		private void toolStripMenuItemContextSelectAll_Click(object sender, EventArgs e)
		{
			dataGridProgramMemory.SelectAll();
		}

		private void toolStripMenuItemContextCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(dataGridProgramMemory.GetClipboardContent());
		}

		private void dataGridProgramMemory_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				dataGridProgramMemory.Focus();
			}
		}
	}
}
