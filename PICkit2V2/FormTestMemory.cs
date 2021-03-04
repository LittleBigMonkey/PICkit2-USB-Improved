using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class FormTestMemory : Form
	{
		private IContainer components;

		private DataGridView dataGridTestMemory;

		private Label label1;

		private TextBox textBoxTestMemSize;

		private Label labelTestMemSize8;

		private Label label11;

		private CheckBox checkBoxTestMemImportExport;

		private Label label2;

		private Label label3;

		private Label labelBLConfig;

		private TextBox textBoxBaselineConfig;

		private Label labelNotSupported;

		private Button buttonClearTestMem;

		private Label label4;

		private Button buttonWriteCalWords;

		private Label labelCalWarning;

		public static uint[] TestMemory = new uint[1024];

		public static bool ReWriteCalWords = false;

		private bool testMemJustEdited;

		private int lastPart;

		private int lastFamily;

		public DelegateUpdateGUI UpdateMainFormGUI;

		public DelegateWriteCal CallMainFormEraseWrCal;

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
			dataGridTestMemory = new System.Windows.Forms.DataGridView();
			label1 = new System.Windows.Forms.Label();
			textBoxTestMemSize = new System.Windows.Forms.TextBox();
			labelTestMemSize8 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			checkBoxTestMemImportExport = new System.Windows.Forms.CheckBox();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			labelBLConfig = new System.Windows.Forms.Label();
			textBoxBaselineConfig = new System.Windows.Forms.TextBox();
			labelNotSupported = new System.Windows.Forms.Label();
			buttonClearTestMem = new System.Windows.Forms.Button();
			label4 = new System.Windows.Forms.Label();
			buttonWriteCalWords = new System.Windows.Forms.Button();
			labelCalWarning = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)dataGridTestMemory).BeginInit();
			SuspendLayout();
			dataGridTestMemory.AllowUserToAddRows = false;
			dataGridTestMemory.AllowUserToDeleteRows = false;
			dataGridTestMemory.AllowUserToResizeColumns = false;
			dataGridTestMemory.AllowUserToResizeRows = false;
			dataGridTestMemory.BackgroundColor = System.Drawing.SystemColors.Window;
			dataGridTestMemory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dataGridTestMemory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dataGridTestMemory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridTestMemory.ColumnHeadersVisible = false;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			dataGridTestMemory.DefaultCellStyle = dataGridViewCellStyle2;
			dataGridTestMemory.Location = new System.Drawing.Point(16, 52);
			dataGridTestMemory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			dataGridTestMemory.MultiSelect = false;
			dataGridTestMemory.Name = "dataGridTestMemory";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dataGridTestMemory.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			dataGridTestMemory.RowHeadersVisible = false;
			dataGridTestMemory.RowHeadersWidth = 75;
			dataGridTestMemory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridTestMemory.RowsDefaultCellStyle = dataGridViewCellStyle4;
			dataGridTestMemory.RowTemplate.Height = 17;
			dataGridTestMemory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			dataGridTestMemory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			dataGridTestMemory.Size = new System.Drawing.Size(467, 171);
			dataGridTestMemory.TabIndex = 5;
			dataGridTestMemory.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridTestMemory_CellEndEdit);
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(12, 23);
			label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(139, 17);
			label1.TabIndex = 6;
			label1.Text = "Test Memory Words:";
			textBoxTestMemSize.Location = new System.Drawing.Point(160, 20);
			textBoxTestMemSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			textBoxTestMemSize.Name = "textBoxTestMemSize";
			textBoxTestMemSize.Size = new System.Drawing.Size(64, 22);
			textBoxTestMemSize.TabIndex = 7;
			textBoxTestMemSize.Leave += new System.EventHandler(textBoxTestMemSize_Leave);
			textBoxTestMemSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBoxTestMemSize_KeyPress);
			labelTestMemSize8.AutoSize = true;
			labelTestMemSize8.ForeColor = System.Drawing.Color.Red;
			labelTestMemSize8.Location = new System.Drawing.Point(233, 16);
			labelTestMemSize8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelTestMemSize8.Name = "labelTestMemSize8";
			labelTestMemSize8.Size = new System.Drawing.Size(92, 34);
			labelTestMemSize8.TabIndex = 22;
			labelTestMemSize8.Text = "Must be\r\nmultiple of 16";
			labelTestMemSize8.Visible = false;
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
			label11.Location = new System.Drawing.Point(16, 226);
			label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(120, 17);
			label11.TabIndex = 23;
			label11.Text = "Hex Import-Export";
			checkBoxTestMemImportExport.AutoSize = true;
			checkBoxTestMemImportExport.Location = new System.Drawing.Point(16, 246);
			checkBoxTestMemImportExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			checkBoxTestMemImportExport.Name = "checkBoxTestMemImportExport";
			checkBoxTestMemImportExport.Size = new System.Drawing.Size(161, 21);
			checkBoxTestMemImportExport.TabIndex = 24;
			checkBoxTestMemImportExport.Text = "Include Test Memory";
			checkBoxTestMemImportExport.UseVisualStyleBackColor = true;
			checkBoxTestMemImportExport.CheckedChanged += new System.EventHandler(checkBoxTestMemImportExport_CheckedChanged);
			label2.BackColor = System.Drawing.Color.LightSteelBlue;
			label2.Location = new System.Drawing.Point(357, 7);
			label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(60, 16);
			label2.TabIndex = 25;
			label2.Text = "UserIDs";
			label3.BackColor = System.Drawing.Color.LightSalmon;
			label3.Location = new System.Drawing.Point(423, 7);
			label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(60, 16);
			label3.TabIndex = 26;
			label3.Text = "Config";
			labelBLConfig.AutoSize = true;
			labelBLConfig.Location = new System.Drawing.Point(307, 246);
			labelBLConfig.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelBLConfig.Name = "labelBLConfig";
			labelBLConfig.Size = new System.Drawing.Size(110, 17);
			labelBLConfig.TabIndex = 27;
			labelBLConfig.Text = "Baseline Config:";
			textBoxBaselineConfig.BackColor = System.Drawing.Color.LightSalmon;
			textBoxBaselineConfig.Location = new System.Drawing.Point(417, 242);
			textBoxBaselineConfig.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			textBoxBaselineConfig.Name = "textBoxBaselineConfig";
			textBoxBaselineConfig.Size = new System.Drawing.Size(64, 22);
			textBoxBaselineConfig.TabIndex = 28;
			textBoxBaselineConfig.Text = "0000";
			textBoxBaselineConfig.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBoxBaselineConfig.Leave += new System.EventHandler(textBoxBaselineConfig_Leave);
			textBoxBaselineConfig.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBoxBaselineConfig_KeyPress);
			labelNotSupported.AutoSize = true;
			labelNotSupported.BackColor = System.Drawing.SystemColors.Info;
			labelNotSupported.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelNotSupported.ForeColor = System.Drawing.Color.Red;
			labelNotSupported.Location = new System.Drawing.Point(37, 100);
			labelNotSupported.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelNotSupported.Name = "labelNotSupported";
			labelNotSupported.Size = new System.Drawing.Size(379, 62);
			labelNotSupported.TabIndex = 29;
			labelNotSupported.Text = "Test Memory Not Supported\r\n            on this family";
			labelNotSupported.Visible = false;
			buttonClearTestMem.Location = new System.Drawing.Point(208, 239);
			buttonClearTestMem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			buttonClearTestMem.Name = "buttonClearTestMem";
			buttonClearTestMem.Size = new System.Drawing.Size(67, 28);
			buttonClearTestMem.TabIndex = 30;
			buttonClearTestMem.Text = "Clear";
			buttonClearTestMem.UseVisualStyleBackColor = true;
			buttonClearTestMem.Click += new System.EventHandler(buttonClearTestMem_Click);
			label4.BackColor = System.Drawing.Color.Gold;
			label4.Location = new System.Drawing.Point(423, 28);
			label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(60, 16);
			label4.TabIndex = 31;
			label4.Text = "CalWrd";
			buttonWriteCalWords.Location = new System.Drawing.Point(335, 266);
			buttonWriteCalWords.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			buttonWriteCalWords.Name = "buttonWriteCalWords";
			buttonWriteCalWords.Size = new System.Drawing.Size(111, 28);
			buttonWriteCalWords.TabIndex = 32;
			buttonWriteCalWords.Text = "Write CalWrd";
			buttonWriteCalWords.UseVisualStyleBackColor = true;
			buttonWriteCalWords.Click += new System.EventHandler(buttonWriteCalWords_Click);
			labelCalWarning.AutoSize = true;
			labelCalWarning.ForeColor = System.Drawing.Color.Red;
			labelCalWarning.Location = new System.Drawing.Point(323, 226);
			labelCalWarning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			labelCalWarning.Name = "labelCalWarning";
			labelCalWarning.Size = new System.Drawing.Size(136, 34);
			labelCalWarning.TabIndex = 33;
			labelCalWarning.Text = "Writing Cal Words\r\nwill erase ALL Flash!";
			labelCalWarning.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			labelCalWarning.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(120f, 120f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(500, 300);
			base.Controls.Add(labelCalWarning);
			base.Controls.Add(buttonWriteCalWords);
			base.Controls.Add(label4);
			base.Controls.Add(buttonClearTestMem);
			base.Controls.Add(labelNotSupported);
			base.Controls.Add(textBoxBaselineConfig);
			base.Controls.Add(labelBLConfig);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(checkBoxTestMemImportExport);
			base.Controls.Add(label11);
			base.Controls.Add(labelTestMemSize8);
			base.Controls.Add(textBoxTestMemSize);
			base.Controls.Add(label1);
			base.Controls.Add(dataGridTestMemory);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormTestMemory";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Test memory";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(FormTestMemory_FormClosing);
			((System.ComponentModel.ISupportInitialize)dataGridTestMemory).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public FormTestMemory()
		{
			InitializeComponent();
			initTestMemoryGUI();
			ClearTestMemory();
			UpdateTestMemForm();
			UpdateTestMemoryGrid();
			FormPICkit2.TestMemoryOpen = true;
		}

		public void ReadTestMemory()
		{
			byte[] array = new byte[128];
			PICkitFunctions.RunScript(0, 1);
			int bytesPerLocation = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
			int num = 128 / (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].TestMemoryRdWords * bytesPerLocation);
			int num2 = num * PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].TestMemoryRdWords;
			int num3 = 0;
			prepTestMem();
			do
			{
				PICkitFunctions.RunScriptUploadNoLen(27, num);
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 0L, 64L);
				PICkitFunctions.UploadDataNoLen();
				Array.Copy(PICkitFunctions.Usb_read_array, 1L, array, 64L, 64L);
				int num4 = 0;
				for (int i = 0; i < num2; i++)
				{
					int num5 = 0;
					uint num6 = array[num4 + num5++];
					if (num5 < bytesPerLocation)
					{
						num6 = (uint)((int)num6 | (array[num4 + num5++] << 8));
					}
					if (num5 < bytesPerLocation)
					{
						num6 = (uint)((int)num6 | (array[num4 + num5++] << 16));
					}
					if (num5 < bytesPerLocation)
					{
						num6 = (uint)((int)num6 | (array[num4 + num5++] << 24));
					}
					num4 += num5;
					if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemShift > 0)
					{
						num6 = ((num6 >> 1) & PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
					}
					TestMemory[num3++] = num6;
				}
			}
			while (num3 < FormPICkit2.TestMemoryWords);
			PICkitFunctions.RunScript(1, 1);
		}

		public bool HexImportExportTM()
		{
			if (checkBoxTestMemImportExport.Enabled)
			{
				return checkBoxTestMemImportExport.Checked;
			}
			return false;
		}

		private void prepTestMem()
		{
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart == 16384 || PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart == 65536)
			{
				PICkitFunctions.SendScript(new byte[7]
				{
					238,
					6,
					0,
					242,
					0,
					242,
					0
				});
			}
			else if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart == 2048)
			{
				int num = getTestMemAddress() / 4 - 1;
				PICkitFunctions.SendScript(new byte[18]
				{
					210,
					(byte)(num & 0xFF),
					210,
					(byte)((num >> 8) & 0xFF),
					238,
					6,
					6,
					238,
					6,
					6,
					238,
					6,
					6,
					238,
					6,
					6,
					221,
					12
				});
			}
			else if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart == 2097152)
			{
				PICkitFunctions.SendScript(new byte[18]
				{
					218,
					32,
					14,
					218,
					248,
					110,
					218,
					0,
					14,
					218,
					247,
					110,
					218,
					0,
					14,
					218,
					246,
					110
				});
			}
		}

		private void initTestMemoryGUI()
		{
			dataGridTestMemory.DefaultCellStyle.Font = new Font("Courier New", 9f);
			dataGridTestMemory.ColumnCount = 9;
			dataGridTestMemory.RowCount = 512;
			dataGridTestMemory[0, 0].Selected = true;
			dataGridTestMemory[0, 0].Selected = false;
			dataGridTestMemory.Columns[0].Width = (int)(59f * FormPICkit2.ScalefactW);
			dataGridTestMemory.Columns[0].ReadOnly = true;
			if (FormPICkit2.TestMemoryImportExport)
			{
				checkBoxTestMemImportExport.Checked = true;
			}
		}

		public void UpdateTestMemForm()
		{
			textBoxTestMemSize.Text = FormPICkit2.TestMemoryWords.ToString();
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart != 0)
			{
				textBoxBaselineConfig.Enabled = true;
				textBoxTestMemSize.Enabled = true;
				checkBoxTestMemImportExport.Enabled = true;
				labelNotSupported.Visible = false;
			}
			else
			{
				textBoxBaselineConfig.Enabled = false;
				textBoxTestMemSize.Enabled = false;
				checkBoxTestMemImportExport.Enabled = false;
				dataGridTestMemory.Enabled = false;
				labelNotSupported.Visible = true;
			}
		}

		public void ClearTestMemory()
		{
			for (int i = 0; i < TestMemory.Length; i++)
			{
				TestMemory[i] = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue;
			}
		}

		public void UpdateTestMemoryGrid()
		{
			bool flag = false;
			int num = 0;
			int num2 = getTestMemAddress() * PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemHexBytes;
			int num3 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDAddr;
			if (PICkitFunctions.ActivePart != lastPart || PICkitFunctions.GetActiveFamily() != lastFamily)
			{
				ClearTestMemory();
				lastPart = PICkitFunctions.ActivePart;
				lastFamily = PICkitFunctions.GetActiveFamily();
			}
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart == 2048)
			{
				num3 = num2;
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords > 0 && num3 >= num2 && num3 < num2 + FormPICkit2.TestMemoryWords)
			{
				flag = true;
				num = (num3 - num2) / (int)PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
			}
			bool flag2 = false;
			int num4 = 0;
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords > 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr >= num2 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr < num2 + FormPICkit2.TestMemoryWords)
			{
				flag2 = true;
				num4 = (int)(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr - num2) / (int)PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
			}
			int num5 = 9;
			dataGridTestMemory.Columns[0].Width = (int)(51f * FormPICkit2.ScalefactW);
			int num6 = 8;
			int width = (int)(35f * FormPICkit2.ScalefactW);
			int num7 = getTestMemAddress();
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart == 2097152)
			{
				num7 *= 2;
			}
			if (dataGridTestMemory.ColumnCount != num5)
			{
				dataGridTestMemory.Rows.Clear();
				dataGridTestMemory.ColumnCount = num5;
			}
			for (int i = 1; i < dataGridTestMemory.ColumnCount; i++)
			{
				dataGridTestMemory.Columns[i].Width = width;
			}
			int addressIncrement = PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].AddressIncrement;
			int num8 = num6;
			int num9 = FormPICkit2.TestMemoryWords / num8;
			int num10 = addressIncrement * num6;
			if (dataGridTestMemory.RowCount != num9)
			{
				dataGridTestMemory.Rows.Clear();
				dataGridTestMemory.RowCount = num9;
			}
			int num11 = dataGridTestMemory.RowCount * num10 - 1;
			string format = "{0:X3}";
			if (num11 > 65535)
			{
				format = "{0:X5}";
			}
			else if (num11 > 4095)
			{
				format = "{0:X4}";
			}
			int j = 0;
			int num12 = 0;
			for (; j < dataGridTestMemory.RowCount; j++)
			{
				dataGridTestMemory[0, j].Value = string.Format(format, num7 + num12);
				dataGridTestMemory[0, j].Style.BackColor = SystemColors.ControlLight;
				num12 += num10;
			}
			string format2 = "{0:X3}";
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 4095)
			{
				format2 = "{0:X4}";
			}
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue > 65535)
			{
				format2 = "{0:X6}";
			}
			for (int k = 0; k < num8; k++)
			{
				dataGridTestMemory.Columns[k + 1].ReadOnly = true;
			}
			int l = 0;
			int num13 = 0;
			for (; l < dataGridTestMemory.RowCount; l++)
			{
				for (int m = 0; m < num8; m++)
				{
					if (flag && num13 >= num && num13 < num + PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords)
					{
						TestMemory[num13] = PICkitFunctions.DeviceBuffers.UserIDs[num13 - num];
						dataGridTestMemory[m + 1, l].ToolTipText = string.Format(format, num7 + num13 * addressIncrement);
						dataGridTestMemory[m + 1, l].Value = string.Format(format2, PICkitFunctions.DeviceBuffers.UserIDs[num13++ - num]);
						dataGridTestMemory[m + 1, l].Style.BackColor = Color.LightSteelBlue;
						dataGridTestMemory[m + 1, l].ReadOnly = false;
					}
					else if (flag2 && num13 >= num4 && num13 < num4 + PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords)
					{
						TestMemory[num13] = PICkitFunctions.DeviceBuffers.ConfigWords[num13 - num4];
						dataGridTestMemory[m + 1, l].ToolTipText = string.Format(format, num7 + num13 * addressIncrement);
						dataGridTestMemory[m + 1, l].Value = string.Format(format2, PICkitFunctions.DeviceBuffers.ConfigWords[num13++ - num4]);
						dataGridTestMemory[m + 1, l].Style.BackColor = Color.LightSalmon;
						dataGridTestMemory[m + 1, l].ReadOnly = false;
					}
					else if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CalibrationWords > 0 && num13 >= num4 + PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords && num13 < num4 + PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords + PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CalibrationWords)
					{
						dataGridTestMemory[m + 1, l].ToolTipText = string.Format(format, num7 + num13 * addressIncrement);
						dataGridTestMemory[m + 1, l].Value = string.Format(format2, TestMemory[num13++]);
						dataGridTestMemory[m + 1, l].Style.BackColor = Color.Gold;
						dataGridTestMemory[m + 1, l].ReadOnly = false;
					}
					else
					{
						dataGridTestMemory[m + 1, l].ToolTipText = string.Format(format, num7 + num13 * addressIncrement);
						dataGridTestMemory[m + 1, l].Value = string.Format(format2, TestMemory[num13++]);
						dataGridTestMemory[m + 1, l].Style.BackColor = SystemColors.Window;
					}
				}
			}
			if (dataGridTestMemory.FirstDisplayedCell != null && !testMemJustEdited)
			{
				int rowIndex = dataGridTestMemory.FirstDisplayedCell.RowIndex;
				dataGridTestMemory[0, rowIndex].Selected = true;
				dataGridTestMemory[0, rowIndex].Selected = false;
			}
			else if (dataGridTestMemory.FirstDisplayedCell == null)
			{
				dataGridTestMemory[0, 0].Selected = true;
				dataGridTestMemory[0, 0].Selected = false;
			}
			testMemJustEdited = false;
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart == 2048)
			{
				labelBLConfig.Visible = true;
				textBoxBaselineConfig.Visible = true;
				textBoxBaselineConfig.Text = $"{PICkitFunctions.DeviceBuffers.ConfigWords[0]:X4}";
			}
			else
			{
				labelBLConfig.Visible = false;
				textBoxBaselineConfig.Visible = false;
			}
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart == 16384)
			{
				labelCalWarning.Visible = true;
				buttonWriteCalWords.Visible = true;
				buttonWriteCalWords.Enabled = (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CalibrationWords > 0);
			}
			else
			{
				labelCalWarning.Visible = false;
				buttonWriteCalWords.Visible = false;
			}
		}

		private void FormTestMemory_FormClosing(object sender, FormClosingEventArgs e)
		{
			FormPICkit2.TestMemoryOpen = false;
		}

		private int getTestMemAddress()
		{
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart == 2048)
			{
				int num = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ProgramMem;
				if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem > 0)
				{
					num += PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].EEMem;
				}
				return num;
			}
			return (int)(PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart / PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemHexBytes);
		}

		private void textBoxTestMemSize_Leave(object sender, EventArgs e)
		{
			memSizeEdit();
		}

		private void textBoxTestMemSize_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				memSizeEdit();
			}
		}

		private void memSizeEdit()
		{
			labelTestMemSize8.Visible = false;
			try
			{
				string p_value = textBoxTestMemSize.Text;
				if (textBoxTestMemSize.Text.Length > 1)
				{
					if (textBoxTestMemSize.Text.Substring(0, 2) == "0x")
					{
						p_value = textBoxTestMemSize.Text;
					}
					else if (textBoxTestMemSize.Text.Substring(0, 1) == "x")
					{
						p_value = "0" + textBoxTestMemSize.Text;
					}
				}
				FormPICkit2.TestMemoryWords = Utilities.Convert_Value_To_Int(p_value);
				if (FormPICkit2.TestMemoryWords > 1024)
				{
					FormPICkit2.TestMemoryWords = 1024;
				}
				else if (FormPICkit2.TestMemoryWords < 16)
				{
					FormPICkit2.TestMemoryWords = 16;
				}
				else if (FormPICkit2.TestMemoryWords % 16 != 0)
				{
					FormPICkit2.TestMemoryWords = (FormPICkit2.TestMemoryWords / 16 + 1) * 16;
					labelTestMemSize8.Visible = true;
				}
			}
			catch
			{
			}
			UpdateTestMemForm();
			UpdateTestMemoryGrid();
		}

		private void dataGridTestMemory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			int rowIndex = e.RowIndex;
			int columnIndex = e.ColumnIndex;
			string p_value = "0x" + dataGridTestMemory[columnIndex, rowIndex].FormattedValue.ToString();
			int num = Utilities.Convert_Value_To_Int(p_value);
			int num2 = dataGridTestMemory.ColumnCount - 1;
			int num3 = rowIndex * num2 + columnIndex - 1;
			int num4 = getTestMemAddress() * PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemHexBytes;
			int num5 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDAddr;
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart == 2048)
			{
				num5 = num4;
			}
			TestMemory[num3] = (uint)(num & PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords > 0 && num5 >= num4 && num5 < num4 + FormPICkit2.TestMemoryWords)
			{
				int num6 = (num5 - num4) / (int)PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
				if (num3 >= num6 && num3 < num6 + PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].UserIDWords)
				{
					PICkitFunctions.DeviceBuffers.UserIDs[num3 - num6] = (uint)(num & PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
					if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].TestMemoryStart == 2097152)
					{
						PICkitFunctions.DeviceBuffers.UserIDs[num3 - num6] &= 255u;
					}
				}
			}
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords > 0 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr >= num4 && PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr < num4 + FormPICkit2.TestMemoryWords)
			{
				int num7 = (int)(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr - num4) / (int)PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
				if (num3 >= num7 && num3 < num7 + PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords)
				{
					PICkitFunctions.DeviceBuffers.ConfigWords[num3 - num7] = (uint)(num & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[num3 - num7]);
				}
			}
			testMemJustEdited = true;
			UpdateMainFormGUI();
		}

		private void textBoxBaselineConfig_Leave(object sender, EventArgs e)
		{
			baselineConfigEdit();
		}

		private void textBoxBaselineConfig_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				baselineConfigEdit();
			}
		}

		private void baselineConfigEdit()
		{
			string p_value = "0x" + textBoxBaselineConfig.Text;
			int num = Utilities.Convert_Value_To_Int(p_value);
			PICkitFunctions.DeviceBuffers.ConfigWords[0] = (uint)num;
			UpdateTestMemoryGrid();
			UpdateMainFormGUI();
		}

		private void checkBoxTestMemImportExport_CheckedChanged(object sender, EventArgs e)
		{
			FormPICkit2.TestMemoryImportExport = checkBoxTestMemImportExport.Checked;
		}

		private void buttonClearTestMem_Click(object sender, EventArgs e)
		{
			ClearTestMemory();
			UpdateTestMemoryGrid();
		}

		private void buttonWriteCalWords_Click(object sender, EventArgs e)
		{
			uint[] array = new uint[PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].CalibrationWords];
			int num = getTestMemAddress() * PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].ProgMemHexBytes;
			int num2 = (int)(PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr - num) / (int)PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BytesPerLocation;
			int num3 = num2 + PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords;
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = TestMemory[num3 + i];
			}
			CallMainFormEraseWrCal(array);
		}
	}
}
