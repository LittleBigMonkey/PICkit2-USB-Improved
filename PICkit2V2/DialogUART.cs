using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class DialogUART : Form
	{
		private struct baudTable
		{
			public string baudRate;

			public uint baudValue;
		}

		private const string CUSTOM_BAUD = "Custom...";

		private const int MaxLengthASCII = 60;

		private const int MaxHexLength = 143;

		public DelegateVddCallback VddCallback;

		public static string CustomBaud = "";

		private baudTable[] baudList;

		private StreamWriter logFile;

		private bool newRX = true;

		private int hex1Length;

		private int hex2Length;

		private int hex3Length;

		private int hex4Length;

		private IContainer components;

		private TextBox textBoxDisplay;

		private PictureBox pictureBox1;

		private Label label1;

		private RadioButton radioButtonConnect;

		private RadioButton radioButtonDisconnect;

		private ComboBox comboBoxBaud;

		private Panel panel1;

		private Panel panel2;

		private RadioButton radioButtonHex;

		private RadioButton radioButtonASCII;

		private Label label2;

		private Label label3;

		private TextBox textBoxString1;

		private Button buttonString1;

		private Button buttonString2;

		private TextBox textBoxString2;

		private Button buttonString4;

		private Button buttonString3;

		private TextBox textBoxString3;

		private TextBox textBoxString4;

		private Button buttonLog;

		private Button buttonClearScreen;

		private Button buttonExit;

		private CheckBox checkBoxEcho;

		private Label labelMacros;

		private System.Windows.Forms.Timer timerPollForData;

		private Label label5;

		private CheckBox checkBoxCRLF;

		private SaveFileDialog saveFileDialogLogFile;

		private CheckBox checkBoxWrap;

		private PictureBox pictureBoxHelp;

		private CheckBox checkBoxVDD;

		private Panel panelVdd;

		private Label labelTypeHex;

		public DialogUART()
		{
			InitializeComponent();
			base.KeyPress += OnKeyPress;
			baudList = new baudTable[7];
			baudList[0].baudRate = "300";
			baudList[0].baudValue = 45554u;
			baudList[1].baudRate = "1200";
			baudList[1].baudValue = 60554u;
			baudList[2].baudRate = "2400";
			baudList[2].baudValue = 63054u;
			baudList[3].baudRate = "4800";
			baudList[3].baudValue = 64304u;
			baudList[4].baudRate = "9600";
			baudList[4].baudValue = 64929u;
			baudList[5].baudRate = "19200";
			baudList[5].baudValue = 65242u;
			baudList[6].baudRate = "38400";
			baudList[6].baudValue = 65398u;
			buildBaudList();
		}

		public string GetBaudRate()
		{
			return comboBoxBaud.SelectedItem.ToString();
		}

		public bool IsHexMode()
		{
			return radioButtonHex.Checked;
		}

		public string GetStringMacro(int macroNum)
		{
			switch (macroNum)
			{
			case 2:
				return textBoxString2.Text;
			case 3:
				return textBoxString3.Text;
			case 4:
				return textBoxString4.Text;
			default:
				return textBoxString1.Text;
			}
		}

		public bool GetAppendCRLF()
		{
			return checkBoxCRLF.Checked;
		}

		public bool GetWrap()
		{
			return checkBoxWrap.Checked;
		}

		public bool GetEcho()
		{
			return checkBoxEcho.Checked;
		}

		public void SetBaudRate(string baudRate)
		{
			int num = 0;
			while (true)
			{
				if (num < baudList.Length)
				{
					if (baudRate == comboBoxBaud.Items[num].ToString())
					{
						break;
					}
					if (num + 1 == baudList.Length)
					{
						comboBoxBaud.Items.Add(baudRate);
						comboBoxBaud.SelectedIndex = num + 3;
					}
					num++;
					continue;
				}
				return;
			}
			comboBoxBaud.SelectedIndex = num;
		}

		public void SetStringMacro(string macro, int macroNum)
		{
			switch (macroNum)
			{
			case 2:
				textBoxString2.Text = macro;
				hex1Length = macro.Length;
				break;
			case 3:
				textBoxString3.Text = macro;
				hex2Length = macro.Length;
				break;
			case 4:
				textBoxString4.Text = macro;
				hex3Length = macro.Length;
				break;
			default:
				textBoxString1.Text = macro;
				hex4Length = macro.Length;
				break;
			}
		}

		public void SetModeHex()
		{
			radioButtonHex.Checked = true;
		}

		public void ClearAppendCRLF()
		{
			checkBoxCRLF.Checked = false;
		}

		public void ClearWrap()
		{
			checkBoxWrap.Checked = false;
		}

		public void ClearEcho()
		{
			checkBoxEcho.Checked = false;
		}

		public void SetVddBox(bool enable, bool check)
		{
			checkBoxVDD.Enabled = enable;
			checkBoxVDD.Checked = check;
		}

		private void buildBaudList()
		{
			for (int i = 0; i < baudList.Length; i++)
			{
				comboBoxBaud.Items.Add(baudList[i].baudRate);
			}
			comboBoxBaud.Items.Add("Custom...");
			comboBoxBaud.SelectedIndex = 0;
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void DialogUART_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (logFile != null)
			{
				closeLogFile();
			}
			timerPollForData.Enabled = false;
			PICkitFunctions.ExitUARTMode();
			radioButtonConnect.Checked = false;
			radioButtonDisconnect.Checked = true;
			comboBoxBaud.Enabled = true;
			buttonString1.Enabled = false;
			buttonString2.Enabled = false;
			buttonString3.Enabled = false;
			buttonString4.Enabled = false;
			panelVdd.Enabled = true;
		}

		public void OnKeyPress(object sender, KeyPressEventArgs e)
		{
			string text = "0123456789ABCDEF";
			if (textBoxString1.ContainsFocus | textBoxString2.ContainsFocus | textBoxString3.ContainsFocus | textBoxString4.ContainsFocus)
			{
				return;
			}
			if (e.KeyChar == '\u0003' || e.KeyChar == '\u0018')
			{
				textBoxDisplay.Copy();
			}
			else
			{
				if (radioButtonDisconnect.Checked)
				{
					return;
				}
				textBoxDisplay.Focus();
				if (radioButtonHex.Checked)
				{
					string text2 = e.KeyChar.ToString();
					text2 = text2.ToUpper();
					if (text2.IndexOfAny(text.ToCharArray()) == 0)
					{
						if (labelTypeHex.Visible)
						{
							string str = labelTypeHex.Text.Substring(11, 1) + text2;
							labelTypeHex.Text = "Type Hex : ";
							labelTypeHex.Visible = false;
							byte[] array = new byte[1]
							{
								(byte)Utilities.Convert_Value_To_Int("0x" + str)
							};
							str = "TX:  " + str + "\r\n";
							textBoxDisplay.AppendText(str);
							textBoxDisplay.SelectionStart = textBoxDisplay.Text.Length;
							textBoxDisplay.ScrollToCaret();
							if (logFile != null)
							{
								logFile.Write(str);
							}
							PICkitFunctions.DataDownload(array, 0, array.Length);
						}
						else
						{
							labelTypeHex.Text = "Type Hex : " + text2 + "_";
							labelTypeHex.Visible = true;
						}
					}
					else
					{
						labelTypeHex.Text = "Type Hex : ";
						labelTypeHex.Visible = false;
					}
				}
				else if (e.KeyChar == '\u0016')
				{
					textBoxDisplay.SelectionStart = textBoxDisplay.Text.Length;
					TextBox textBox = new TextBox();
					textBox.Multiline = true;
					textBox.Paste();
					do
					{
						int num = textBox.Text.Length;
						if (num > 60)
						{
							num = 60;
						}
						sendString(textBox.Text.Substring(0, num), appendCRLF: false);
						textBox.Text = textBox.Text.Substring(num);
						float num2 = float.Parse(comboBoxBaud.SelectedItem.ToString());
						num2 = 1f / num2 * 12f * (float)num;
						num2 *= 1000f;
						Thread.Sleep((int)num2);
					}
					while (textBox.Text.Length > 0);
					textBox.Dispose();
				}
				else
				{
					string text3 = e.KeyChar.ToString();
					if (text3 == "\r")
					{
						text3 = "\r\n";
					}
					sendString(text3, appendCRLF: false);
				}
			}
		}

		private void radioButtonConnect_Click_1(object sender, EventArgs e)
		{
			if (radioButtonConnect.Checked)
			{
				return;
			}
			if (comboBoxBaud.SelectedIndex == 0)
			{
				MessageBox.Show("Please Select a Baud Rate.");
				return;
			}
			uint num = 0u;
			for (int i = 0; i < baudList.Length; i++)
			{
				if (comboBoxBaud.SelectedItem.ToString() == baudList[i].baudRate)
				{
					num = baudList[i].baudValue;
					break;
				}
				if (i + 1 == baudList.Length)
				{
					try
					{
						float num2 = float.Parse(comboBoxBaud.SelectedItem.ToString());
						num2 = (1f / num2 - 3E-06f) / 1.6667E-07f;
						num = 65536 - (uint)num2;
					}
					catch
					{
						MessageBox.Show("Error with Baud setting.");
						return;
					}
				}
			}
			panelVdd.Enabled = false;
			PICkitFunctions.EnterUARTMode(num);
			radioButtonConnect.Checked = true;
			radioButtonDisconnect.Checked = false;
			buttonString1.Enabled = true;
			buttonString2.Enabled = true;
			buttonString3.Enabled = true;
			buttonString4.Enabled = true;
			comboBoxBaud.Enabled = false;
			if (num < 60554)
			{
				timerPollForData.Interval = 75;
			}
			else
			{
				timerPollForData.Interval = 15;
			}
			timerPollForData.Enabled = true;
		}

		private void radioButtonDisconnect_Click(object sender, EventArgs e)
		{
			if (!radioButtonDisconnect.Checked)
			{
				radioButtonConnect.Checked = false;
				radioButtonDisconnect.Checked = true;
				PICkitFunctions.ExitUARTMode();
				comboBoxBaud.Enabled = true;
				timerPollForData.Enabled = false;
				buttonString1.Enabled = false;
				buttonString2.Enabled = false;
				buttonString3.Enabled = false;
				buttonString4.Enabled = false;
				panelVdd.Enabled = true;
				labelTypeHex.Text = "Type Hex : ";
				labelTypeHex.Visible = false;
			}
		}

		private void buttonClearScreen_Click(object sender, EventArgs e)
		{
			textBoxDisplay.Text = "";
		}

		private void timerPollForData_Tick(object sender, EventArgs e)
		{
			PICkitFunctions.UploadData();
			if (PICkitFunctions.Usb_read_array[1] > 0)
			{
				string text = "";
				if (radioButtonASCII.Checked)
				{
					text = Encoding.ASCII.GetString(PICkitFunctions.Usb_read_array, 2, PICkitFunctions.Usb_read_array[1]);
				}
				else
				{
					if (newRX)
					{
						text = "RX:  ";
						newRX = false;
					}
					for (int i = 0; i < PICkitFunctions.Usb_read_array[1]; i++)
					{
						text += $"{PICkitFunctions.Usb_read_array[i + 2]:X2} ";
					}
				}
				if (logFile != null)
				{
					logFile.Write(text);
				}
				textBoxDisplay.AppendText(text);
				while (textBoxDisplay.Text.Length > 16400)
				{
					int num = textBoxDisplay.Text.IndexOf("\r\n") + 2;
					if (num == 1)
					{
						num = textBoxDisplay.Text.Length - 16000;
					}
					textBoxDisplay.Text = textBoxDisplay.Text.Substring(num);
				}
				textBoxDisplay.SelectionStart = textBoxDisplay.Text.Length;
				textBoxDisplay.ScrollToCaret();
				return;
			}
			if (!newRX && radioButtonHex.Checked)
			{
				textBoxDisplay.AppendText("\r\n");
				if (logFile != null)
				{
					logFile.Write("\r\n");
				}
				textBoxDisplay.SelectionStart = textBoxDisplay.Text.Length;
				textBoxDisplay.ScrollToCaret();
			}
			newRX = true;
		}

		private int getLastLineLength(string text)
		{
			int num = text.LastIndexOf("\r\n") + 2;
			if (num < 2)
			{
				num = 0;
			}
			return text.Length - num;
		}

		private void textBoxString1_TextChanged(object sender, EventArgs e)
		{
			if (textBoxString1.Text.Length > 60 && radioButtonASCII.Checked)
			{
				textBoxString1.Text = textBoxString1.Text.Substring(0, 60);
				textBoxString1.SelectionStart = 60;
			}
			if (radioButtonHex.Checked)
			{
				formatHexString(textBoxString1, ref hex1Length);
			}
		}

		private void textBoxString2_TextChanged(object sender, EventArgs e)
		{
			if (textBoxString2.Text.Length > 60 && radioButtonASCII.Checked)
			{
				textBoxString2.Text = textBoxString2.Text.Substring(0, 60);
				textBoxString2.SelectionStart = 60;
			}
			if (radioButtonHex.Checked)
			{
				formatHexString(textBoxString2, ref hex2Length);
			}
		}

		private void textBoxString3_TextChanged(object sender, EventArgs e)
		{
			if (textBoxString3.Text.Length > 60 && radioButtonASCII.Checked)
			{
				textBoxString3.Text = textBoxString3.Text.Substring(0, 60);
				textBoxString3.SelectionStart = 60;
			}
			if (radioButtonHex.Checked)
			{
				formatHexString(textBoxString3, ref hex3Length);
			}
		}

		private void textBoxString4_TextChanged(object sender, EventArgs e)
		{
			if (textBoxString4.Text.Length > 60 && radioButtonASCII.Checked)
			{
				textBoxString4.Text = textBoxString4.Text.Substring(0, 60);
				textBoxString4.SelectionStart = 60;
			}
			if (radioButtonHex.Checked)
			{
				formatHexString(textBoxString4, ref hex4Length);
			}
		}

		private void formatHexString(TextBox textBoxToFormat, ref int priorLength)
		{
			string text = textBoxToFormat.Text.ToUpper();
			text = text.Replace(" ", "");
			string text2 = "";
			for (int i = 0; i < text.Length; i++)
			{
				text2 = ((char.IsNumber(text, i) || text[i] == 'A' || text[i] == 'B' || text[i] == 'C' || text[i] == 'D' || text[i] == 'E' || text[i] == 'F') ? (text2 + text[i]) : (text2 + '0'));
				if ((i + 1) % 2 == 0)
				{
					text2 += " ";
				}
			}
			if (text2.Length > 143)
			{
				text2 = text2.Substring(0, 143);
			}
			int num = textBoxToFormat.SelectionStart;
			if (num > 0 && num <= text2.Length && num < textBoxToFormat.Text.Length && textBoxToFormat.Text[num] == ' ' && text2[num - 1] == ' ')
			{
				num++;
			}
			else if (num >= textBoxToFormat.Text.Length && priorLength < textBoxToFormat.Text.Length)
			{
				num = text2.Length;
			}
			textBoxToFormat.Text = text2;
			textBoxToFormat.SelectionStart = num;
			priorLength = textBoxToFormat.Text.Length;
		}

		private void buttonString1_Click(object sender, EventArgs e)
		{
			sendString(textBoxString1.Text, checkBoxCRLF.Checked);
		}

		private void buttonString2_Click(object sender, EventArgs e)
		{
			sendString(textBoxString2.Text, checkBoxCRLF.Checked);
		}

		private void buttonString3_Click(object sender, EventArgs e)
		{
			sendString(textBoxString3.Text, checkBoxCRLF.Checked);
		}

		private void buttonString4_Click(object sender, EventArgs e)
		{
			sendString(textBoxString4.Text, checkBoxCRLF.Checked);
		}

		private void sendString(string dataString, bool appendCRLF)
		{
			if (dataString.Length == 0)
			{
				return;
			}
			if (radioButtonASCII.Checked)
			{
				if (appendCRLF)
				{
					dataString += "\r\n";
				}
				if (checkBoxEcho.Checked)
				{
					textBoxDisplay.AppendText(dataString);
					textBoxDisplay.SelectionStart = textBoxDisplay.Text.Length;
					textBoxDisplay.ScrollToCaret();
				}
				if (logFile != null)
				{
					logFile.Write(dataString);
				}
				byte[] bytes = Encoding.Unicode.GetBytes(dataString);
				byte[] array = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, bytes);
				PICkitFunctions.DataDownload(array, 0, array.Length);
				return;
			}
			int num = 0;
			if (dataString.Length > 142)
			{
				num = 48;
			}
			else
			{
				num = dataString.Length / 3;
				dataString = dataString.Substring(0, num * 3);
			}
			byte[] array2 = new byte[num];
			for (int i = 0; i < num; i++)
			{
				array2[i] = (byte)Utilities.Convert_Value_To_Int("0x" + dataString.Substring(3 * i, 2));
			}
			dataString = "TX:  " + dataString + "\r\n";
			textBoxDisplay.AppendText(dataString);
			textBoxDisplay.SelectionStart = textBoxDisplay.Text.Length;
			textBoxDisplay.ScrollToCaret();
			if (logFile != null)
			{
				logFile.Write(dataString);
			}
			PICkitFunctions.DataDownload(array2, 0, array2.Length);
		}

		private void buttonLog_Click(object sender, EventArgs e)
		{
			if (logFile == null)
			{
				saveFileDialogLogFile.ShowDialog();
			}
			else
			{
				closeLogFile();
			}
		}

		private void closeLogFile()
		{
			logFile.Close();
			logFile = null;
			buttonLog.Text = "Log to File";
			buttonLog.BackColor = SystemColors.ControlLight;
		}

		private void saveFileDialogLogFile_FileOk(object sender, CancelEventArgs e)
		{
			logFile = new StreamWriter(saveFileDialogLogFile.FileName);
			buttonLog.Text = "Logging Data...";
			buttonLog.BackColor = Color.Green;
		}

		private void radioButtonASCII_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonASCII.Checked)
			{
				checkBoxCRLF.Visible = true;
				checkBoxEcho.Enabled = true;
				labelTypeHex.Visible = false;
				labelTypeHex.Text = "Type Hex : ";
				labelMacros.Text = "String Macros:";
				textBoxString1.Text = convertHexSequenceToStringMacro(textBoxString1.Text);
				textBoxString2.Text = convertHexSequenceToStringMacro(textBoxString2.Text);
				textBoxString3.Text = convertHexSequenceToStringMacro(textBoxString3.Text);
				textBoxString4.Text = convertHexSequenceToStringMacro(textBoxString4.Text);
				if (textBoxDisplay.Text.Length > 0 && textBoxDisplay.Text[textBoxDisplay.Text.Length - 1] != '\n')
				{
					textBoxDisplay.AppendText("\r\n");
				}
			}
		}

		private void radioButtonHex_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButtonHex.Checked)
			{
				checkBoxCRLF.Visible = false;
				checkBoxEcho.Enabled = false;
				labelTypeHex.Text = "Type Hex : ";
				labelTypeHex.Visible = false;
				labelMacros.Text = "Send Hex Sequences:";
				textBoxString1.Text = convertStringMacroToHexSequence(textBoxString1.Text);
				textBoxString2.Text = convertStringMacroToHexSequence(textBoxString2.Text);
				textBoxString3.Text = convertStringMacroToHexSequence(textBoxString3.Text);
				textBoxString4.Text = convertStringMacroToHexSequence(textBoxString4.Text);
				if (textBoxDisplay.Text.Length > 0 && textBoxDisplay.Text[textBoxDisplay.Text.Length - 1] != '\n')
				{
					textBoxDisplay.AppendText("\r\n");
				}
			}
		}

		private string convertHexSequenceToStringMacro(string hexSeq)
		{
			int num = 0;
			num = ((hexSeq.Length <= 142) ? (hexSeq.Length / 3) : 48);
			byte[] array = new byte[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (byte)Utilities.Convert_Value_To_Int("0x" + hexSeq.Substring(3 * i, 2));
			}
			return Encoding.ASCII.GetString(array, 0, array.Length);
		}

		private string convertStringMacroToHexSequence(string stringMacro)
		{
			if (stringMacro.Length > 48)
			{
				stringMacro = stringMacro.Substring(0, 48);
			}
			byte[] bytes = Encoding.Unicode.GetBytes(stringMacro);
			byte[] array = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, bytes);
			string text = "";
			for (int i = 0; i < array.Length; i++)
			{
				text += $"{array[i]:X2} ";
			}
			return text;
		}

		private void checkBoxWrap_CheckedChanged(object sender, EventArgs e)
		{
			textBoxDisplay.WordWrap = checkBoxWrap.Checked;
		}

		private void comboBoxBaud_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(comboBoxBaud.SelectedItem.ToString() == "Custom..."))
			{
				return;
			}
			DialogCustomBaud dialogCustomBaud = new DialogCustomBaud();
			dialogCustomBaud.ShowDialog();
			if (CustomBaud == "")
			{
				comboBoxBaud.SelectedIndex = 0;
				return;
			}
			if (comboBoxBaud.Items.Count != comboBoxBaud.SelectedIndex + 1)
			{
				comboBoxBaud.Items.RemoveAt(comboBoxBaud.SelectedIndex + 1);
			}
			comboBoxBaud.Items.Add(CustomBaud);
			comboBoxBaud.SelectedIndex++;
		}

		private void pictureBoxHelp_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start(FormPICkit2.HomeDirectory + "\\PICkit2 User Guide 51553E.pdf");
			}
			catch
			{
				MessageBox.Show("Unable to open User's Guide.");
			}
		}

		private void checkBoxVDD_Click(object sender, EventArgs e)
		{
			VddCallback(force: true, checkBoxVDD.Checked);
		}

		private void textBoxDisplay_Leave(object sender, EventArgs e)
		{
			labelTypeHex.Visible = false;
			labelTypeHex.Text = "Type Hex : ";
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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PICkit2V2.DialogUART));
			textBoxDisplay = new System.Windows.Forms.TextBox();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label1 = new System.Windows.Forms.Label();
			radioButtonConnect = new System.Windows.Forms.RadioButton();
			radioButtonDisconnect = new System.Windows.Forms.RadioButton();
			comboBoxBaud = new System.Windows.Forms.ComboBox();
			panel1 = new System.Windows.Forms.Panel();
			panel2 = new System.Windows.Forms.Panel();
			radioButtonHex = new System.Windows.Forms.RadioButton();
			radioButtonASCII = new System.Windows.Forms.RadioButton();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			textBoxString1 = new System.Windows.Forms.TextBox();
			buttonString1 = new System.Windows.Forms.Button();
			buttonString2 = new System.Windows.Forms.Button();
			textBoxString2 = new System.Windows.Forms.TextBox();
			buttonString4 = new System.Windows.Forms.Button();
			buttonString3 = new System.Windows.Forms.Button();
			textBoxString3 = new System.Windows.Forms.TextBox();
			textBoxString4 = new System.Windows.Forms.TextBox();
			buttonLog = new System.Windows.Forms.Button();
			buttonClearScreen = new System.Windows.Forms.Button();
			buttonExit = new System.Windows.Forms.Button();
			checkBoxEcho = new System.Windows.Forms.CheckBox();
			labelMacros = new System.Windows.Forms.Label();
			timerPollForData = new System.Windows.Forms.Timer(components);
			label5 = new System.Windows.Forms.Label();
			checkBoxCRLF = new System.Windows.Forms.CheckBox();
			saveFileDialogLogFile = new System.Windows.Forms.SaveFileDialog();
			checkBoxWrap = new System.Windows.Forms.CheckBox();
			pictureBoxHelp = new System.Windows.Forms.PictureBox();
			checkBoxVDD = new System.Windows.Forms.CheckBox();
			panelVdd = new System.Windows.Forms.Panel();
			labelTypeHex = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBoxHelp).BeginInit();
			panelVdd.SuspendLayout();
			SuspendLayout();
			textBoxDisplay.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBoxDisplay.BackColor = System.Drawing.SystemColors.Window;
			textBoxDisplay.Cursor = System.Windows.Forms.Cursors.Default;
			textBoxDisplay.Font = new System.Drawing.Font("Courier New", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBoxDisplay.Location = new System.Drawing.Point(13, 44);
			textBoxDisplay.MaxLength = 17220;
			textBoxDisplay.MinimumSize = new System.Drawing.Size(708, 332);
			textBoxDisplay.Multiline = true;
			textBoxDisplay.Name = "textBoxDisplay";
			textBoxDisplay.ReadOnly = true;
			textBoxDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			textBoxDisplay.Size = new System.Drawing.Size(708, 332);
			textBoxDisplay.TabIndex = 0;
			textBoxDisplay.Leave += new System.EventHandler(textBoxDisplay_Leave);
			pictureBox1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(13, 385);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(189, 116);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			label1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(10, 504);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(181, 13);
			label1.TabIndex = 2;
			label1.Text = "Connect PICkit 2 VDD && target VDD.";
			radioButtonConnect.Appearance = System.Windows.Forms.Appearance.Button;
			radioButtonConnect.AutoCheck = false;
			radioButtonConnect.Location = new System.Drawing.Point(130, 4);
			radioButtonConnect.Name = "radioButtonConnect";
			radioButtonConnect.Size = new System.Drawing.Size(70, 22);
			radioButtonConnect.TabIndex = 14;
			radioButtonConnect.Text = "Connect";
			radioButtonConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			radioButtonConnect.UseVisualStyleBackColor = true;
			radioButtonConnect.Click += new System.EventHandler(radioButtonConnect_Click_1);
			radioButtonDisconnect.Appearance = System.Windows.Forms.Appearance.Button;
			radioButtonDisconnect.AutoCheck = false;
			radioButtonDisconnect.Checked = true;
			radioButtonDisconnect.Location = new System.Drawing.Point(206, 4);
			radioButtonDisconnect.Name = "radioButtonDisconnect";
			radioButtonDisconnect.Size = new System.Drawing.Size(70, 22);
			radioButtonDisconnect.TabIndex = 15;
			radioButtonDisconnect.TabStop = true;
			radioButtonDisconnect.Text = "Disconnect";
			radioButtonDisconnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			radioButtonDisconnect.UseVisualStyleBackColor = true;
			radioButtonDisconnect.Click += new System.EventHandler(radioButtonDisconnect_Click);
			comboBoxBaud.BackColor = System.Drawing.SystemColors.Info;
			comboBoxBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBoxBaud.FormattingEnabled = true;
			comboBoxBaud.Items.AddRange(new object[1]
			{
				"- Select Baud -"
			});
			comboBoxBaud.Location = new System.Drawing.Point(6, 5);
			comboBoxBaud.MaxDropDownItems = 12;
			comboBoxBaud.Name = "comboBoxBaud";
			comboBoxBaud.Size = new System.Drawing.Size(118, 21);
			comboBoxBaud.TabIndex = 13;
			comboBoxBaud.SelectedIndexChanged += new System.EventHandler(comboBoxBaud_SelectedIndexChanged);
			panel1.Controls.Add(comboBoxBaud);
			panel1.Controls.Add(radioButtonDisconnect);
			panel1.Controls.Add(radioButtonConnect);
			panel1.Location = new System.Drawing.Point(13, 8);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(280, 30);
			panel1.TabIndex = 6;
			panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			panel2.Controls.Add(radioButtonHex);
			panel2.Controls.Add(radioButtonASCII);
			panel2.Location = new System.Drawing.Point(618, 9);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(106, 29);
			panel2.TabIndex = 7;
			radioButtonHex.Appearance = System.Windows.Forms.Appearance.Button;
			radioButtonHex.Location = new System.Drawing.Point(57, 3);
			radioButtonHex.Name = "radioButtonHex";
			radioButtonHex.Size = new System.Drawing.Size(47, 22);
			radioButtonHex.TabIndex = 17;
			radioButtonHex.Text = "Hex";
			radioButtonHex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			radioButtonHex.UseVisualStyleBackColor = true;
			radioButtonHex.CheckedChanged += new System.EventHandler(radioButtonHex_CheckedChanged);
			radioButtonASCII.Appearance = System.Windows.Forms.Appearance.Button;
			radioButtonASCII.Checked = true;
			radioButtonASCII.Location = new System.Drawing.Point(3, 3);
			radioButtonASCII.Name = "radioButtonASCII";
			radioButtonASCII.Size = new System.Drawing.Size(47, 22);
			radioButtonASCII.TabIndex = 16;
			radioButtonASCII.TabStop = true;
			radioButtonASCII.Text = "ASCII";
			radioButtonASCII.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			radioButtonASCII.UseVisualStyleBackColor = true;
			radioButtonASCII.CheckedChanged += new System.EventHandler(radioButtonASCII_CheckedChanged);
			label2.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(570, 14);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(47, 15);
			label2.TabIndex = 8;
			label2.Text = "Mode:";
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(363, 8);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(164, 13);
			label3.TabIndex = 9;
			label3.Text = "8 data bits - No parity - 1 Stop bit.";
			textBoxString1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBoxString1.BackColor = System.Drawing.SystemColors.Info;
			textBoxString1.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBoxString1.Location = new System.Drawing.Point(306, 406);
			textBoxString1.Name = "textBoxString1";
			textBoxString1.Size = new System.Drawing.Size(286, 20);
			textBoxString1.TabIndex = 1;
			textBoxString1.TextChanged += new System.EventHandler(textBoxString1_TextChanged);
			buttonString1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			buttonString1.Enabled = false;
			buttonString1.Location = new System.Drawing.Point(246, 404);
			buttonString1.Name = "buttonString1";
			buttonString1.Size = new System.Drawing.Size(54, 22);
			buttonString1.TabIndex = 5;
			buttonString1.Text = "Send";
			buttonString1.UseVisualStyleBackColor = true;
			buttonString1.Click += new System.EventHandler(buttonString1_Click);
			buttonString2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			buttonString2.Enabled = false;
			buttonString2.Location = new System.Drawing.Point(246, 434);
			buttonString2.Name = "buttonString2";
			buttonString2.Size = new System.Drawing.Size(54, 22);
			buttonString2.TabIndex = 6;
			buttonString2.Text = "Send";
			buttonString2.UseVisualStyleBackColor = true;
			buttonString2.Click += new System.EventHandler(buttonString2_Click);
			textBoxString2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBoxString2.BackColor = System.Drawing.SystemColors.Info;
			textBoxString2.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBoxString2.Location = new System.Drawing.Point(306, 435);
			textBoxString2.Name = "textBoxString2";
			textBoxString2.Size = new System.Drawing.Size(286, 20);
			textBoxString2.TabIndex = 2;
			textBoxString2.TextChanged += new System.EventHandler(textBoxString2_TextChanged);
			buttonString4.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			buttonString4.Enabled = false;
			buttonString4.Location = new System.Drawing.Point(246, 490);
			buttonString4.Name = "buttonString4";
			buttonString4.Size = new System.Drawing.Size(54, 22);
			buttonString4.TabIndex = 8;
			buttonString4.Text = "Send";
			buttonString4.UseVisualStyleBackColor = true;
			buttonString4.Click += new System.EventHandler(buttonString4_Click);
			buttonString3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			buttonString3.Enabled = false;
			buttonString3.Location = new System.Drawing.Point(246, 462);
			buttonString3.Name = "buttonString3";
			buttonString3.Size = new System.Drawing.Size(54, 22);
			buttonString3.TabIndex = 7;
			buttonString3.Text = "Send";
			buttonString3.UseVisualStyleBackColor = true;
			buttonString3.Click += new System.EventHandler(buttonString3_Click);
			textBoxString3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBoxString3.BackColor = System.Drawing.SystemColors.Info;
			textBoxString3.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBoxString3.Location = new System.Drawing.Point(306, 464);
			textBoxString3.Name = "textBoxString3";
			textBoxString3.Size = new System.Drawing.Size(286, 20);
			textBoxString3.TabIndex = 3;
			textBoxString3.TextChanged += new System.EventHandler(textBoxString3_TextChanged);
			textBoxString4.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			textBoxString4.BackColor = System.Drawing.SystemColors.Info;
			textBoxString4.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			textBoxString4.Location = new System.Drawing.Point(306, 492);
			textBoxString4.Name = "textBoxString4";
			textBoxString4.Size = new System.Drawing.Size(286, 20);
			textBoxString4.TabIndex = 4;
			textBoxString4.TextChanged += new System.EventHandler(textBoxString4_TextChanged);
			buttonLog.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			buttonLog.Location = new System.Drawing.Point(618, 404);
			buttonLog.Name = "buttonLog";
			buttonLog.Size = new System.Drawing.Size(102, 22);
			buttonLog.TabIndex = 9;
			buttonLog.Text = "Log to File";
			buttonLog.UseVisualStyleBackColor = true;
			buttonLog.Click += new System.EventHandler(buttonLog_Click);
			buttonClearScreen.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			buttonClearScreen.Location = new System.Drawing.Point(618, 434);
			buttonClearScreen.Name = "buttonClearScreen";
			buttonClearScreen.Size = new System.Drawing.Size(102, 22);
			buttonClearScreen.TabIndex = 10;
			buttonClearScreen.Text = "Clear Screen";
			buttonClearScreen.UseVisualStyleBackColor = true;
			buttonClearScreen.Click += new System.EventHandler(buttonClearScreen_Click);
			buttonExit.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			buttonExit.Location = new System.Drawing.Point(618, 490);
			buttonExit.Name = "buttonExit";
			buttonExit.Size = new System.Drawing.Size(102, 22);
			buttonExit.TabIndex = 12;
			buttonExit.Text = "Exit UART Tool";
			buttonExit.UseVisualStyleBackColor = true;
			buttonExit.Click += new System.EventHandler(buttonExit_Click);
			checkBoxEcho.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			checkBoxEcho.AutoSize = true;
			checkBoxEcho.Checked = true;
			checkBoxEcho.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBoxEcho.Location = new System.Drawing.Point(638, 466);
			checkBoxEcho.Name = "checkBoxEcho";
			checkBoxEcho.Size = new System.Drawing.Size(68, 17);
			checkBoxEcho.TabIndex = 11;
			checkBoxEcho.Text = "Echo On";
			checkBoxEcho.UseVisualStyleBackColor = true;
			labelMacros.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			labelMacros.AutoSize = true;
			labelMacros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelMacros.Location = new System.Drawing.Point(243, 382);
			labelMacros.Name = "labelMacros";
			labelMacros.Size = new System.Drawing.Size(100, 15);
			labelMacros.TabIndex = 22;
			labelMacros.Text = "String Macros:";
			timerPollForData.Interval = 15;
			timerPollForData.Tick += new System.EventHandler(timerPollForData_Tick);
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(375, 22);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(137, 13);
			label5.TabIndex = 23;
			label5.Text = "ASCII newline = 0x0D 0x0A";
			checkBoxCRLF.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			checkBoxCRLF.AutoSize = true;
			checkBoxCRLF.Checked = true;
			checkBoxCRLF.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBoxCRLF.Location = new System.Drawing.Point(365, 383);
			checkBoxCRLF.Name = "checkBoxCRLF";
			checkBoxCRLF.Size = new System.Drawing.Size(157, 17);
			checkBoxCRLF.TabIndex = 18;
			checkBoxCRLF.Text = "Append CR+LF (x0D + x0A)";
			checkBoxCRLF.UseVisualStyleBackColor = true;
			saveFileDialogLogFile.DefaultExt = "txt";
			saveFileDialogLogFile.Filter = "All files|*.*|Text files|*.txt";
			saveFileDialogLogFile.InitialDirectory = "c:\\";
			saveFileDialogLogFile.Title = "Log UART data to file";
			saveFileDialogLogFile.FileOk += new System.ComponentModel.CancelEventHandler(saveFileDialogLogFile_FileOk);
			checkBoxWrap.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			checkBoxWrap.AutoSize = true;
			checkBoxWrap.Checked = true;
			checkBoxWrap.CheckState = System.Windows.Forms.CheckState.Checked;
			checkBoxWrap.Location = new System.Drawing.Point(638, 383);
			checkBoxWrap.Name = "checkBoxWrap";
			checkBoxWrap.Size = new System.Drawing.Size(76, 17);
			checkBoxWrap.TabIndex = 24;
			checkBoxWrap.Text = "Wrap Text";
			checkBoxWrap.UseVisualStyleBackColor = true;
			checkBoxWrap.CheckedChanged += new System.EventHandler(checkBoxWrap_CheckedChanged);
			pictureBoxHelp.Cursor = System.Windows.Forms.Cursors.Hand;
			pictureBoxHelp.Image = (System.Drawing.Image)resources.GetObject("pictureBoxHelp.Image");
			pictureBoxHelp.Location = new System.Drawing.Point(540, 10);
			pictureBoxHelp.Name = "pictureBoxHelp";
			pictureBoxHelp.Size = new System.Drawing.Size(24, 24);
			pictureBoxHelp.TabIndex = 26;
			pictureBoxHelp.TabStop = false;
			pictureBoxHelp.Click += new System.EventHandler(pictureBoxHelp_Click);
			checkBoxVDD.AutoSize = true;
			checkBoxVDD.Location = new System.Drawing.Point(6, 5);
			checkBoxVDD.Name = "checkBoxVDD";
			checkBoxVDD.Size = new System.Drawing.Size(49, 17);
			checkBoxVDD.TabIndex = 27;
			checkBoxVDD.Text = "VDD";
			checkBoxVDD.UseVisualStyleBackColor = true;
			checkBoxVDD.Click += new System.EventHandler(checkBoxVDD_Click);
			panelVdd.Controls.Add(checkBoxVDD);
			panelVdd.Location = new System.Drawing.Point(299, 10);
			panelVdd.Name = "panelVdd";
			panelVdd.Size = new System.Drawing.Size(65, 27);
			panelVdd.TabIndex = 28;
			labelTypeHex.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			labelTypeHex.AutoSize = true;
			labelTypeHex.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			labelTypeHex.Location = new System.Drawing.Point(520, 384);
			labelTypeHex.Name = "labelTypeHex";
			labelTypeHex.Size = new System.Drawing.Size(75, 13);
			labelTypeHex.TabIndex = 29;
			labelTypeHex.Text = "Type Hex : A_";
			labelTypeHex.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(736, 526);
			base.Controls.Add(labelTypeHex);
			base.Controls.Add(panelVdd);
			base.Controls.Add(pictureBoxHelp);
			base.Controls.Add(checkBoxWrap);
			base.Controls.Add(checkBoxCRLF);
			base.Controls.Add(label5);
			base.Controls.Add(labelMacros);
			base.Controls.Add(checkBoxEcho);
			base.Controls.Add(buttonExit);
			base.Controls.Add(buttonClearScreen);
			base.Controls.Add(buttonLog);
			base.Controls.Add(textBoxString4);
			base.Controls.Add(textBoxString3);
			base.Controls.Add(buttonString3);
			base.Controls.Add(buttonString4);
			base.Controls.Add(textBoxString2);
			base.Controls.Add(buttonString2);
			base.Controls.Add(buttonString1);
			base.Controls.Add(textBoxString1);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(panel2);
			base.Controls.Add(panel1);
			base.Controls.Add(label1);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(textBoxDisplay);
			base.KeyPreview = true;
			MinimumSize = new System.Drawing.Size(744, 559);
			base.Name = "DialogUART";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "PICkit 2 UART Tool";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(DialogUART_FormClosing);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBoxHelp).EndInit();
			panelVdd.ResumeLayout(false);
			panelVdd.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
