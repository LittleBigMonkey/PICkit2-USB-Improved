using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class FormMultiWinProgMem : Form
	{
		private IContainer components;

		private DataGridView dataGridProgramMemory;

		private ComboBox comboBoxProgMemView;

		private Label displayDataSource;

		private Label labelDataSource;

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

		public DelegateMultiProgMemClosed TellMainFormProgMemClosed;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PICkit2V2.FormMultiWinProgMem));
			dataGridProgramMemory = new System.Windows.Forms.DataGridView();
			comboBoxProgMemView = new System.Windows.Forms.ComboBox();
			displayDataSource = new System.Windows.Forms.Label();
			labelDataSource = new System.Windows.Forms.Label();
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripMenuItemContextSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItemContextCopy = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)dataGridProgramMemory).BeginInit();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
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
			dataGridProgramMemory.Size = new System.Drawing.Size(512, 123);
			dataGridProgramMemory.TabIndex = 5;
			dataGridProgramMemory.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(dataGridProgramMemory_CellMouseDown);
			dataGridProgramMemory.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(progMemEdit);
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
			comboBoxProgMemView.TabIndex = 6;
			comboBoxProgMemView.SelectionChangeCommitted += new System.EventHandler(comboBoxProgMemView_SelectionChangeCommitted);
			displayDataSource.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			displayDataSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			displayDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			displayDataSource.Location = new System.Drawing.Point(172, 13);
			displayDataSource.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			displayDataSource.MinimumSize = new System.Drawing.Size(279, 16);
			displayDataSource.Name = "displayDataSource";
			displayDataSource.Size = new System.Drawing.Size(352, 16);
			displayDataSource.TabIndex = 8;
			displayDataSource.Text = "None (Empty/Erased)";
			displayDataSource.UseCompatibleTextRendering = true;
			labelDataSource.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			labelDataSource.AutoSize = true;
			labelDataSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelDataSource.Location = new System.Drawing.Point(119, 14);
			labelDataSource.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			labelDataSource.Name = "labelDataSource";
			labelDataSource.Size = new System.Drawing.Size(51, 13);
			labelDataSource.TabIndex = 7;
			labelDataSource.Text = "Source:";
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
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(536, 174);
			base.Controls.Add(displayDataSource);
			base.Controls.Add(labelDataSource);
			base.Controls.Add(comboBoxProgMemView);
			base.Controls.Add(dataGridProgramMemory);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			MinimumSize = new System.Drawing.Size(200, 110);
			base.Name = "FormMultiWinProgMem";
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			Text = "PICkit 2 Program Memory";
			base.Resize += new System.EventHandler(FormMultiWinProgMem_Resize);
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormMultiWinProgMem_FormClosing);
			base.ResizeEnd += new System.EventHandler(FormMultiWinProgMem_ResizeEnd);
			((System.ComponentModel.ISupportInitialize)dataGridProgramMemory).EndInit();
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		public FormMultiWinProgMem()
		{
			InitializeComponent();
		}

		public void InitProgMemDisplay(int viewMode)
		{
			dataGridProgramMemory.DefaultCellStyle.Font = new Font("Courier New", 9f);
			comboBoxProgMemView.SelectedIndex = viewMode;
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

		public void ReCalcMultiWinProgMem()
		{
			uint programMem = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem;
			if (programMem == 0 || base.WindowState == FormWindowState.Minimized)
			{
				return;
			}
			uint blankValue = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue;
			if (blankValue == uint.MaxValue)
			{
				comboBoxProgMemView.SelectedIndex = 0;
				comboBoxProgMemView.Enabled = false;
			}
			else
			{
				comboBoxProgMemView.Enabled = true;
			}
			uint num = programMem * PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].AddressIncrement - 1;
			int num2 = 32;
			addrFormat = "{0:X3}";
			if (blankValue == uint.MaxValue)
			{
				num2 = 65;
				addrFormat = "{0:X8}";
			}
			else if (num > 65535)
			{
				num2 = 44;
				addrFormat = "{0:X5}";
			}
			else if (num > 4095)
			{
				num2 = 38;
				addrFormat = "{0:X4}";
			}
			num2 = (int)((float)num2 * FormPICkit2.ScalefactW);
			int num3 = 24;
			int num4 = 16;
			asciiBytes = 1;
			dataFormat = "{0:X2}";
			if (blankValue == uint.MaxValue)
			{
				num3 = 65;
				num4 = 58;
				asciiBytes = 4;
				dataFormat = "{0:X8}";
			}
			else if (blankValue > 65535)
			{
				num3 = 50;
				num4 = 43;
				asciiBytes = 3;
				dataFormat = "{0:X6}";
			}
			else if (blankValue > 4095)
			{
				num3 = 36;
				num4 = 28;
				asciiBytes = 2;
				dataFormat = "{0:X4}";
			}
			else if (blankValue > 255)
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
			if (num7 > (int)programMem)
			{
				num7 = (int)programMem;
			}
			num3 = num6 / num7;
			if (comboBoxProgMemView.SelectedIndex > 0)
			{
				num4 = (int)(num5 * (float)num3);
				num3 -= num4;
			}
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
			int num9 = (int)programMem / num7;
			if ((long)programMem % (long)num7 > 0)
			{
				num9++;
			}
			if (blankValue == uint.MaxValue)
			{
				num9 += 2;
			}
			dataGridProgramMemory.RowCount = num9;
			int num10 = num7 * PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].AddressIncrement;
			if (blankValue == uint.MaxValue)
			{
				int programMem2 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem;
				int bootFlash = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BootFlash;
				programMem2 -= bootFlash;
				programMem2 /= num7;
				dataGridProgramMemory.ShowCellToolTips = false;
				dataGridProgramMemory[0, 0].Value = "Program";
				dataGridProgramMemory[1, 0].Value = "Flash";
				for (int k = 0; k < dataGridProgramMemory.ColumnCount; k++)
				{
					dataGridProgramMemory[k, 0].Style.BackColor = SystemColors.ControlDark;
					dataGridProgramMemory[k, 0].ReadOnly = true;
				}
				int l = 1;
				int num11 = 486539264;
				for (; l <= programMem2; l++)
				{
					dataGridProgramMemory[0, l].Value = string.Format(addrFormat, num11);
					dataGridProgramMemory[0, l].Style.BackColor = SystemColors.ControlLight;
					num11 += num10;
				}
				dataGridProgramMemory[0, programMem2 + 1].Value = "Boot";
				dataGridProgramMemory[1, programMem2 + 1].Value = "Flash";
				for (int m = 0; m < dataGridProgramMemory.ColumnCount; m++)
				{
					dataGridProgramMemory[m, programMem2 + 1].Style.BackColor = SystemColors.ControlDark;
					dataGridProgramMemory[m, programMem2 + 1].ReadOnly = true;
				}
				int n = programMem2 + 2;
				int num12 = 532676608;
				for (; n < dataGridProgramMemory.RowCount; n++)
				{
					dataGridProgramMemory[0, n].Value = string.Format(addrFormat, num12);
					dataGridProgramMemory[0, n].Style.BackColor = SystemColors.ControlLight;
					num12 += num10;
				}
			}
			else
			{
				dataGridProgramMemory.ShowCellToolTips = true;
				int num13 = 0;
				int num14 = 0;
				for (; num13 < num9; num13++)
				{
					dataGridProgramMemory[0, num13].Value = string.Format(addrFormat, num14);
					dataGridProgramMemory[0, num13].ReadOnly = true;
					dataGridProgramMemory[0, num13].Style.BackColor = SystemColors.ControlLight;
					num14 += num10;
				}
			}
			updateDisplay();
		}

		public void UpdateMultiWinProgMem(string dataSource)
		{
			if (lastPart != PICkitFunctions.ActivePart || lastFam != PICkitFunctions.GetActiveFamily())
			{
				lastPart = PICkitFunctions.ActivePart;
				lastFam = PICkitFunctions.GetActiveFamily();
				ReCalcMultiWinProgMem();
			}
			else
			{
				updateDisplay();
			}
			displayDataSource.Text = dataSource;
		}

		public string GetDataSource()
		{
			return displayDataSource.Text;
		}

		private void updateDisplay()
		{
			int num = dataGridProgramMemory.RowCount - 1;
			int num2 = dataGridProgramMemory.ColumnCount - 1;
			int addressIncrement = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].AddressIncrement;
			uint blankValue = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue;
			if (comboBoxProgMemView.SelectedIndex > 0)
			{
				num2 /= 2;
			}
			int programMem = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem;
			int bootFlash = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BootFlash;
			programMem -= bootFlash;
			programMem /= num2;
			int num3 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem % num2;
			if (num3 == 0)
			{
				num3 = num2;
			}
			int num4 = num * num2;
			if (blankValue == uint.MaxValue)
			{
				int num5 = 0;
				for (int i = 1; i <= programMem; i++)
				{
					for (int j = 0; j < num2; j++)
					{
						dataGridProgramMemory[j + 1, i].Value = string.Format(dataFormat, PICkitFunctions.DeviceBuffers.ProgramMemory[num5++]);
					}
				}
				for (int k = programMem + 2; k < dataGridProgramMemory.RowCount - 1; k++)
				{
					for (int l = 0; l < num2; l++)
					{
						dataGridProgramMemory[l + 1, k].Value = string.Format(dataFormat, PICkitFunctions.DeviceBuffers.ProgramMemory[num5++]);
					}
				}
				num3 = bootFlash % num2;
				if (num3 == 0)
				{
					num3 = num2;
				}
				for (int m = 1; m <= num2; m++)
				{
					if (m <= num3)
					{
						dataGridProgramMemory[m, num].Value = string.Format(dataFormat, PICkitFunctions.DeviceBuffers.ProgramMemory[num5++]);
						continue;
					}
					dataGridProgramMemory[m, num].Value = "";
					dataGridProgramMemory[m, num].ReadOnly = true;
				}
			}
			else
			{
				int n = 0;
				int num6 = 0;
				int num7 = 0;
				for (; n < num; n++)
				{
					for (int num8 = 1; num8 <= num2; num8++)
					{
						dataGridProgramMemory[num8, n].Value = string.Format(dataFormat, PICkitFunctions.DeviceBuffers.ProgramMemory[num6++]);
						dataGridProgramMemory[num8, n].ToolTipText = string.Format(addrFormat, num7);
						num7 += addressIncrement;
					}
				}
				for (int num9 = 1; num9 <= num2; num9++)
				{
					if (num9 <= num3)
					{
						dataGridProgramMemory[num9, num].Value = string.Format(dataFormat, PICkitFunctions.DeviceBuffers.ProgramMemory[num4]);
						dataGridProgramMemory[num9, num].ToolTipText = string.Format(addrFormat, num4++ * addressIncrement);
					}
					else
					{
						dataGridProgramMemory[num9, num].Value = "";
						dataGridProgramMemory[num9, num].ToolTipText = "";
						dataGridProgramMemory[num9, num].ReadOnly = true;
					}
				}
			}
			if (comboBoxProgMemView.SelectedIndex > 0)
			{
				for (int num10 = num2 + 1; num10 <= 2 * num2; num10++)
				{
					dataGridProgramMemory.Columns[num10].ReadOnly = true;
				}
				if (comboBoxProgMemView.SelectedIndex == 1)
				{
					int num11 = 0;
					int num12 = 0;
					int num13 = 0;
					for (; num11 < num; num11++)
					{
						for (int num14 = num2 + 1; num14 <= 2 * num2; num14++)
						{
							dataGridProgramMemory[num14, num11].Value = Utilities.ConvertIntASCII((int)PICkitFunctions.DeviceBuffers.ProgramMemory[num12++], asciiBytes);
							dataGridProgramMemory[num14, num11].ToolTipText = string.Format(addrFormat, num13);
							num13 += addressIncrement;
						}
					}
					num4 = num * num2;
					for (int num15 = num2 + 1; num15 <= 2 * num2; num15++)
					{
						if (num15 <= num2 + num3)
						{
							dataGridProgramMemory[num15, num].Value = Utilities.ConvertIntASCII((int)PICkitFunctions.DeviceBuffers.ProgramMemory[num4++], asciiBytes);
							dataGridProgramMemory[num15, num].ToolTipText = string.Format(addrFormat, num4 * addressIncrement);
						}
						else
						{
							dataGridProgramMemory[num15, num].Value = "";
							dataGridProgramMemory[num15, num].ToolTipText = "";
							dataGridProgramMemory[num15, num].ReadOnly = true;
						}
					}
				}
				else
				{
					int num16 = 0;
					int num17 = 0;
					int num18 = 0;
					for (; num16 < num; num16++)
					{
						for (int num19 = num2 + 1; num19 <= 2 * num2; num19++)
						{
							dataGridProgramMemory[num19, num16].Value = Utilities.ConvertIntASCIIReverse((int)PICkitFunctions.DeviceBuffers.ProgramMemory[num17++], asciiBytes);
							dataGridProgramMemory[num19, num16].ToolTipText = string.Format(addrFormat, num18);
							num18 += addressIncrement;
						}
					}
					num4 = num * num2;
					for (int num20 = num2 + 1; num20 <= 2 * num2; num20++)
					{
						if (num20 <= num2 + num3)
						{
							dataGridProgramMemory[num20, num].Value = Utilities.ConvertIntASCIIReverse((int)PICkitFunctions.DeviceBuffers.ProgramMemory[num4++], asciiBytes);
							dataGridProgramMemory[num20, num].ToolTipText = string.Format(addrFormat, num4 * addressIncrement);
						}
						else
						{
							dataGridProgramMemory[num20, num].Value = "";
							dataGridProgramMemory[num20, num].ToolTipText = "";
							dataGridProgramMemory[num20, num].ReadOnly = true;
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
			else if (dataGridProgramMemory.FirstDisplayedCell == null && dataGridProgramMemory.RowCount > 0)
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
			int num3 = rowIndex * num2 + columnIndex - 1;
			if (PICkitFunctions.FamilyIsPIC32())
			{
				int programMem = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem;
				int bootFlash = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].BootFlash;
				programMem -= bootFlash;
				num3 -= num2;
				if (num3 > programMem)
				{
					num3 -= num2;
				}
			}
			PICkitFunctions.DeviceBuffers.ProgramMemory[num3] = (uint)(num & PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
			TellMainFormProgMemEdited();
			progMemJustEdited = true;
			TellMainFormUpdateGUI();
		}

		private void FormMultiWinProgMem_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.FormOwnerClosing)
			{
				e.Cancel = true;
				TellMainFormProgMemClosed();
				Hide();
			}
		}

		private void FormMultiWinProgMem_ResizeEnd(object sender, EventArgs e)
		{
			ReCalcMultiWinProgMem();
		}

		private void FormMultiWinProgMem_Resize(object sender, EventArgs e)
		{
			if (base.WindowState == FormWindowState.Maximized)
			{
				maxed = true;
				ReCalcMultiWinProgMem();
			}
			else if (maxed)
			{
				maxed = false;
				ReCalcMultiWinProgMem();
			}
		}

		private void comboBoxProgMemView_SelectionChangeCommitted(object sender, EventArgs e)
		{
			ReCalcMultiWinProgMem();
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
