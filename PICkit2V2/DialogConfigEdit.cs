using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class DialogConfigEdit : Form
	{
		private struct config
		{
			public Panel configPanel;

			public Label name;

			public Label addr;

			public Label value;

			public TextBox[] bits;
		}

		private const int K_MAXCONFIGS = 9;

		private IContainer components;

		private Panel panel1;

		private Label labelName1;

		private Button buttonSave;

		private Button buttonCancel;

		private Label label1;

		private Label label2;

		private Label label3;

		private Label label4;

		private TextBox textBox1_12;

		private TextBox textBox1_13;

		private TextBox textBox1_14;

		private TextBox textBoxEx;

		private Label labelVal1;

		private Label labelAdr1;

		private TextBox textBox1_0;

		private TextBox textBox1_1;

		private TextBox textBox1_2;

		private TextBox textBox1_11;

		private TextBox textBox1_3;

		private TextBox textBox1_10;

		private TextBox textBox1_4;

		private TextBox textBox1_9;

		private TextBox textBox1_5;

		private TextBox textBox1_8;

		private TextBox textBox1_7;

		private TextBox textBox1_6;

		private Label label23;

		private Label label22;

		private Label label21;

		private Label label20;

		private Label label19;

		private Label label18;

		private Label label17;

		private Label label16;

		private Label label15;

		private Label label14;

		private Label label13;

		private Label label12;

		private Label label11;

		private Label label10;

		private Label label9;

		private Label label8;

		private Label label5;

		private TextBox textBoxUnimpl;

		private Label label6;

		private Label label7;

		private TextBox textBox1_15;

		private Panel panel2;

		private TextBox textBox2_15;

		private Label label24;

		private Label label25;

		private Label label26;

		private Label label27;

		private Label label28;

		private Label label29;

		private Label label30;

		private Label label31;

		private Label label32;

		private Label label33;

		private Label label34;

		private Label label35;

		private Label label36;

		private Label label37;

		private Label label38;

		private Label label39;

		private TextBox textBox2_0;

		private Label labelVal2;

		private Label labelAdr2;

		private TextBox textBox2_1;

		private Label labelName2;

		private TextBox textBox2_2;

		private TextBox textBox2_11;

		private TextBox textBox2_12;

		private TextBox textBox2_3;

		private TextBox textBox2_10;

		private TextBox textBox2_13;

		private TextBox textBox2_4;

		private TextBox textBox2_9;

		private TextBox textBox2_14;

		private TextBox textBox2_5;

		private TextBox textBox2_8;

		private TextBox textBox2_7;

		private TextBox textBox2_6;

		private Label label40;

		private Label label41;

		private Label label42;

		private Panel panel3;

		private TextBox textBox3_15;

		private Label label43;

		private Label label44;

		private Label label45;

		private Label label46;

		private Label label47;

		private Label label48;

		private Label label49;

		private Label label50;

		private Label label51;

		private Label label52;

		private Label label53;

		private Label label54;

		private Label label55;

		private Label label56;

		private Label label57;

		private Label label58;

		private TextBox textBox3_0;

		private Label labelVal3;

		private Label labelAdr3;

		private TextBox textBox3_1;

		private Label labelName3;

		private TextBox textBox3_2;

		private TextBox textBox3_11;

		private TextBox textBox3_12;

		private TextBox textBox3_3;

		private TextBox textBox3_10;

		private TextBox textBox3_13;

		private TextBox textBox3_4;

		private TextBox textBox3_9;

		private TextBox textBox3_14;

		private TextBox textBox3_5;

		private TextBox textBox3_8;

		private TextBox textBox3_7;

		private TextBox textBox3_6;

		private Panel panel4;

		private TextBox textBox4_15;

		private Label label59;

		private Label label60;

		private Label label61;

		private Label label62;

		private Label label63;

		private Label label64;

		private Label label65;

		private Label label66;

		private Label label67;

		private Label label68;

		private Label label69;

		private Label label70;

		private Label label71;

		private Label label72;

		private Label label73;

		private Label label74;

		private TextBox textBox4_0;

		private Label labelVal4;

		private Label labelAdr4;

		private TextBox textBox4_1;

		private Label labelName4;

		private TextBox textBox4_2;

		private TextBox textBox4_11;

		private TextBox textBox4_12;

		private TextBox textBox4_3;

		private TextBox textBox4_10;

		private TextBox textBox4_13;

		private TextBox textBox4_4;

		private TextBox textBox4_9;

		private TextBox textBox4_14;

		private TextBox textBox4_5;

		private TextBox textBox4_8;

		private TextBox textBox4_7;

		private TextBox textBox4_6;

		private Panel panel5;

		private TextBox textBox5_15;

		private Label label75;

		private Label label76;

		private Label label77;

		private Label label78;

		private Label label79;

		private Label label80;

		private Label label81;

		private Label label82;

		private Label label83;

		private Label label84;

		private Label label85;

		private Label label86;

		private Label label87;

		private Label label88;

		private Label label89;

		private Label label90;

		private TextBox textBox5_0;

		private Label labelVal5;

		private Label labelAdr5;

		private TextBox textBox5_1;

		private Label labelName5;

		private TextBox textBox5_2;

		private TextBox textBox5_11;

		private TextBox textBox5_12;

		private TextBox textBox5_3;

		private TextBox textBox5_10;

		private TextBox textBox5_13;

		private TextBox textBox5_4;

		private TextBox textBox5_9;

		private TextBox textBox5_14;

		private TextBox textBox5_5;

		private TextBox textBox5_8;

		private TextBox textBox5_7;

		private TextBox textBox5_6;

		private Panel panel6;

		private TextBox textBox6_15;

		private Label label91;

		private Label label92;

		private Label label93;

		private Label label94;

		private Label label95;

		private Label label96;

		private Label label97;

		private Label label98;

		private Label label99;

		private Label label100;

		private Label label101;

		private Label label102;

		private Label label103;

		private Label label104;

		private Label label105;

		private Label label106;

		private TextBox textBox6_0;

		private Label labelVal6;

		private Label labelAdr6;

		private TextBox textBox6_1;

		private Label labelName6;

		private TextBox textBox6_2;

		private TextBox textBox6_11;

		private TextBox textBox6_12;

		private TextBox textBox6_3;

		private TextBox textBox6_10;

		private TextBox textBox6_13;

		private TextBox textBox6_4;

		private TextBox textBox6_9;

		private TextBox textBox6_14;

		private TextBox textBox6_5;

		private TextBox textBox6_8;

		private TextBox textBox6_7;

		private TextBox textBox6_6;

		private Panel panel7;

		private TextBox textBox7_15;

		private Label label107;

		private Label label108;

		private Label label109;

		private Label label110;

		private Label label111;

		private Label label112;

		private Label label113;

		private Label label114;

		private Label label115;

		private Label label116;

		private Label label117;

		private Label label118;

		private Label label119;

		private Label label120;

		private Label label121;

		private Label label122;

		private TextBox textBox7_0;

		private Label labelVal7;

		private Label labelAdr7;

		private TextBox textBox7_1;

		private Label labelName7;

		private TextBox textBox7_2;

		private TextBox textBox7_11;

		private TextBox textBox7_12;

		private TextBox textBox7_3;

		private TextBox textBox7_10;

		private TextBox textBox7_13;

		private TextBox textBox7_4;

		private TextBox textBox7_9;

		private TextBox textBox7_14;

		private TextBox textBox7_5;

		private TextBox textBox7_8;

		private TextBox textBox7_7;

		private TextBox textBox7_6;

		private Panel panel8;

		private TextBox textBox8_15;

		private Label label123;

		private Label label124;

		private Label label125;

		private Label label126;

		private Label label127;

		private Label label128;

		private Label label129;

		private Label label130;

		private Label label131;

		private Label label132;

		private Label label133;

		private Label label134;

		private Label label135;

		private Label label136;

		private Label label137;

		private Label label138;

		private TextBox textBox8_0;

		private Label labelVal8;

		private Label labelAdr8;

		private TextBox textBox8_1;

		private Label labelName8;

		private TextBox textBox8_2;

		private TextBox textBox8_11;

		private TextBox textBox8_12;

		private TextBox textBox8_3;

		private TextBox textBox8_10;

		private TextBox textBox8_13;

		private TextBox textBox8_4;

		private TextBox textBox8_9;

		private TextBox textBox8_14;

		private TextBox textBox8_5;

		private TextBox textBox8_8;

		private TextBox textBox8_7;

		private TextBox textBox8_6;

		private Panel panel9;

		private TextBox textBox9_15;

		private Label label139;

		private Label label140;

		private Label label141;

		private Label label142;

		private Label label143;

		private Label label144;

		private Label label145;

		private Label label146;

		private Label label147;

		private Label label148;

		private Label label149;

		private Label label150;

		private Label label151;

		private Label label152;

		private Label label153;

		private Label label154;

		private TextBox textBox9_0;

		private Label labelVal9;

		private Label labelAdr9;

		private TextBox textBox9_1;

		private Label labelName9;

		private TextBox textBox9_2;

		private TextBox textBox9_11;

		private TextBox textBox9_12;

		private TextBox textBox9_3;

		private TextBox textBox9_10;

		private TextBox textBox9_13;

		private TextBox textBox9_4;

		private TextBox textBox9_9;

		private TextBox textBox9_14;

		private TextBox textBox9_5;

		private TextBox textBox9_8;

		private TextBox textBox9_7;

		private TextBox textBox9_6;

		private Label label155;

		public float ScalefactW = 1f;

		public float ScalefactH = 1f;

		private int displayMask;

		private config[] configWords = new config[9];

		private uint[] configSaves = new uint[9];

		private bool saveChanges;

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
			panel1 = new System.Windows.Forms.Panel();
			textBox1_15 = new System.Windows.Forms.TextBox();
			label23 = new System.Windows.Forms.Label();
			label22 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			textBox1_0 = new System.Windows.Forms.TextBox();
			labelVal1 = new System.Windows.Forms.Label();
			labelAdr1 = new System.Windows.Forms.Label();
			textBox1_1 = new System.Windows.Forms.TextBox();
			labelName1 = new System.Windows.Forms.Label();
			textBox1_2 = new System.Windows.Forms.TextBox();
			textBox1_11 = new System.Windows.Forms.TextBox();
			textBox1_12 = new System.Windows.Forms.TextBox();
			textBox1_3 = new System.Windows.Forms.TextBox();
			textBox1_10 = new System.Windows.Forms.TextBox();
			textBox1_13 = new System.Windows.Forms.TextBox();
			textBox1_4 = new System.Windows.Forms.TextBox();
			textBox1_9 = new System.Windows.Forms.TextBox();
			textBox1_14 = new System.Windows.Forms.TextBox();
			textBox1_5 = new System.Windows.Forms.TextBox();
			textBox1_8 = new System.Windows.Forms.TextBox();
			textBox1_7 = new System.Windows.Forms.TextBox();
			textBox1_6 = new System.Windows.Forms.TextBox();
			buttonSave = new System.Windows.Forms.Button();
			buttonCancel = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			textBoxEx = new System.Windows.Forms.TextBox();
			label5 = new System.Windows.Forms.Label();
			textBoxUnimpl = new System.Windows.Forms.TextBox();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			textBox2_15 = new System.Windows.Forms.TextBox();
			label24 = new System.Windows.Forms.Label();
			label25 = new System.Windows.Forms.Label();
			label26 = new System.Windows.Forms.Label();
			label27 = new System.Windows.Forms.Label();
			label28 = new System.Windows.Forms.Label();
			label29 = new System.Windows.Forms.Label();
			label30 = new System.Windows.Forms.Label();
			label31 = new System.Windows.Forms.Label();
			label32 = new System.Windows.Forms.Label();
			label33 = new System.Windows.Forms.Label();
			label34 = new System.Windows.Forms.Label();
			label35 = new System.Windows.Forms.Label();
			label36 = new System.Windows.Forms.Label();
			label37 = new System.Windows.Forms.Label();
			label38 = new System.Windows.Forms.Label();
			label39 = new System.Windows.Forms.Label();
			textBox2_0 = new System.Windows.Forms.TextBox();
			labelVal2 = new System.Windows.Forms.Label();
			labelAdr2 = new System.Windows.Forms.Label();
			textBox2_1 = new System.Windows.Forms.TextBox();
			labelName2 = new System.Windows.Forms.Label();
			textBox2_2 = new System.Windows.Forms.TextBox();
			textBox2_11 = new System.Windows.Forms.TextBox();
			textBox2_12 = new System.Windows.Forms.TextBox();
			textBox2_3 = new System.Windows.Forms.TextBox();
			textBox2_10 = new System.Windows.Forms.TextBox();
			textBox2_13 = new System.Windows.Forms.TextBox();
			textBox2_4 = new System.Windows.Forms.TextBox();
			textBox2_9 = new System.Windows.Forms.TextBox();
			textBox2_14 = new System.Windows.Forms.TextBox();
			textBox2_5 = new System.Windows.Forms.TextBox();
			textBox2_8 = new System.Windows.Forms.TextBox();
			textBox2_7 = new System.Windows.Forms.TextBox();
			textBox2_6 = new System.Windows.Forms.TextBox();
			label40 = new System.Windows.Forms.Label();
			label41 = new System.Windows.Forms.Label();
			label42 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			textBox3_15 = new System.Windows.Forms.TextBox();
			label43 = new System.Windows.Forms.Label();
			label44 = new System.Windows.Forms.Label();
			label45 = new System.Windows.Forms.Label();
			label46 = new System.Windows.Forms.Label();
			label47 = new System.Windows.Forms.Label();
			label48 = new System.Windows.Forms.Label();
			label49 = new System.Windows.Forms.Label();
			label50 = new System.Windows.Forms.Label();
			label51 = new System.Windows.Forms.Label();
			label52 = new System.Windows.Forms.Label();
			label53 = new System.Windows.Forms.Label();
			label54 = new System.Windows.Forms.Label();
			label55 = new System.Windows.Forms.Label();
			label56 = new System.Windows.Forms.Label();
			label57 = new System.Windows.Forms.Label();
			label58 = new System.Windows.Forms.Label();
			textBox3_0 = new System.Windows.Forms.TextBox();
			labelVal3 = new System.Windows.Forms.Label();
			labelAdr3 = new System.Windows.Forms.Label();
			textBox3_1 = new System.Windows.Forms.TextBox();
			labelName3 = new System.Windows.Forms.Label();
			textBox3_2 = new System.Windows.Forms.TextBox();
			textBox3_11 = new System.Windows.Forms.TextBox();
			textBox3_12 = new System.Windows.Forms.TextBox();
			textBox3_3 = new System.Windows.Forms.TextBox();
			textBox3_10 = new System.Windows.Forms.TextBox();
			textBox3_13 = new System.Windows.Forms.TextBox();
			textBox3_4 = new System.Windows.Forms.TextBox();
			textBox3_9 = new System.Windows.Forms.TextBox();
			textBox3_14 = new System.Windows.Forms.TextBox();
			textBox3_5 = new System.Windows.Forms.TextBox();
			textBox3_8 = new System.Windows.Forms.TextBox();
			textBox3_7 = new System.Windows.Forms.TextBox();
			textBox3_6 = new System.Windows.Forms.TextBox();
			panel4 = new System.Windows.Forms.Panel();
			textBox4_15 = new System.Windows.Forms.TextBox();
			label59 = new System.Windows.Forms.Label();
			label60 = new System.Windows.Forms.Label();
			label61 = new System.Windows.Forms.Label();
			label62 = new System.Windows.Forms.Label();
			label63 = new System.Windows.Forms.Label();
			label64 = new System.Windows.Forms.Label();
			label65 = new System.Windows.Forms.Label();
			label66 = new System.Windows.Forms.Label();
			label67 = new System.Windows.Forms.Label();
			label68 = new System.Windows.Forms.Label();
			label69 = new System.Windows.Forms.Label();
			label70 = new System.Windows.Forms.Label();
			label71 = new System.Windows.Forms.Label();
			label72 = new System.Windows.Forms.Label();
			label73 = new System.Windows.Forms.Label();
			label74 = new System.Windows.Forms.Label();
			textBox4_0 = new System.Windows.Forms.TextBox();
			labelVal4 = new System.Windows.Forms.Label();
			labelAdr4 = new System.Windows.Forms.Label();
			textBox4_1 = new System.Windows.Forms.TextBox();
			labelName4 = new System.Windows.Forms.Label();
			textBox4_2 = new System.Windows.Forms.TextBox();
			textBox4_11 = new System.Windows.Forms.TextBox();
			textBox4_12 = new System.Windows.Forms.TextBox();
			textBox4_3 = new System.Windows.Forms.TextBox();
			textBox4_10 = new System.Windows.Forms.TextBox();
			textBox4_13 = new System.Windows.Forms.TextBox();
			textBox4_4 = new System.Windows.Forms.TextBox();
			textBox4_9 = new System.Windows.Forms.TextBox();
			textBox4_14 = new System.Windows.Forms.TextBox();
			textBox4_5 = new System.Windows.Forms.TextBox();
			textBox4_8 = new System.Windows.Forms.TextBox();
			textBox4_7 = new System.Windows.Forms.TextBox();
			textBox4_6 = new System.Windows.Forms.TextBox();
			panel5 = new System.Windows.Forms.Panel();
			textBox5_15 = new System.Windows.Forms.TextBox();
			label75 = new System.Windows.Forms.Label();
			label76 = new System.Windows.Forms.Label();
			label77 = new System.Windows.Forms.Label();
			label78 = new System.Windows.Forms.Label();
			label79 = new System.Windows.Forms.Label();
			label80 = new System.Windows.Forms.Label();
			label81 = new System.Windows.Forms.Label();
			label82 = new System.Windows.Forms.Label();
			label83 = new System.Windows.Forms.Label();
			label84 = new System.Windows.Forms.Label();
			label85 = new System.Windows.Forms.Label();
			label86 = new System.Windows.Forms.Label();
			label87 = new System.Windows.Forms.Label();
			label88 = new System.Windows.Forms.Label();
			label89 = new System.Windows.Forms.Label();
			label90 = new System.Windows.Forms.Label();
			textBox5_0 = new System.Windows.Forms.TextBox();
			labelVal5 = new System.Windows.Forms.Label();
			labelAdr5 = new System.Windows.Forms.Label();
			textBox5_1 = new System.Windows.Forms.TextBox();
			labelName5 = new System.Windows.Forms.Label();
			textBox5_2 = new System.Windows.Forms.TextBox();
			textBox5_11 = new System.Windows.Forms.TextBox();
			textBox5_12 = new System.Windows.Forms.TextBox();
			textBox5_3 = new System.Windows.Forms.TextBox();
			textBox5_10 = new System.Windows.Forms.TextBox();
			textBox5_13 = new System.Windows.Forms.TextBox();
			textBox5_4 = new System.Windows.Forms.TextBox();
			textBox5_9 = new System.Windows.Forms.TextBox();
			textBox5_14 = new System.Windows.Forms.TextBox();
			textBox5_5 = new System.Windows.Forms.TextBox();
			textBox5_8 = new System.Windows.Forms.TextBox();
			textBox5_7 = new System.Windows.Forms.TextBox();
			textBox5_6 = new System.Windows.Forms.TextBox();
			panel6 = new System.Windows.Forms.Panel();
			textBox6_15 = new System.Windows.Forms.TextBox();
			label91 = new System.Windows.Forms.Label();
			label92 = new System.Windows.Forms.Label();
			label93 = new System.Windows.Forms.Label();
			label94 = new System.Windows.Forms.Label();
			label95 = new System.Windows.Forms.Label();
			label96 = new System.Windows.Forms.Label();
			label97 = new System.Windows.Forms.Label();
			label98 = new System.Windows.Forms.Label();
			label99 = new System.Windows.Forms.Label();
			label100 = new System.Windows.Forms.Label();
			label101 = new System.Windows.Forms.Label();
			label102 = new System.Windows.Forms.Label();
			label103 = new System.Windows.Forms.Label();
			label104 = new System.Windows.Forms.Label();
			label105 = new System.Windows.Forms.Label();
			label106 = new System.Windows.Forms.Label();
			textBox6_0 = new System.Windows.Forms.TextBox();
			labelVal6 = new System.Windows.Forms.Label();
			labelAdr6 = new System.Windows.Forms.Label();
			textBox6_1 = new System.Windows.Forms.TextBox();
			labelName6 = new System.Windows.Forms.Label();
			textBox6_2 = new System.Windows.Forms.TextBox();
			textBox6_11 = new System.Windows.Forms.TextBox();
			textBox6_12 = new System.Windows.Forms.TextBox();
			textBox6_3 = new System.Windows.Forms.TextBox();
			textBox6_10 = new System.Windows.Forms.TextBox();
			textBox6_13 = new System.Windows.Forms.TextBox();
			textBox6_4 = new System.Windows.Forms.TextBox();
			textBox6_9 = new System.Windows.Forms.TextBox();
			textBox6_14 = new System.Windows.Forms.TextBox();
			textBox6_5 = new System.Windows.Forms.TextBox();
			textBox6_8 = new System.Windows.Forms.TextBox();
			textBox6_7 = new System.Windows.Forms.TextBox();
			textBox6_6 = new System.Windows.Forms.TextBox();
			panel7 = new System.Windows.Forms.Panel();
			textBox7_15 = new System.Windows.Forms.TextBox();
			label107 = new System.Windows.Forms.Label();
			label108 = new System.Windows.Forms.Label();
			label109 = new System.Windows.Forms.Label();
			label110 = new System.Windows.Forms.Label();
			label111 = new System.Windows.Forms.Label();
			label112 = new System.Windows.Forms.Label();
			label113 = new System.Windows.Forms.Label();
			label114 = new System.Windows.Forms.Label();
			label115 = new System.Windows.Forms.Label();
			label116 = new System.Windows.Forms.Label();
			label117 = new System.Windows.Forms.Label();
			label118 = new System.Windows.Forms.Label();
			label119 = new System.Windows.Forms.Label();
			label120 = new System.Windows.Forms.Label();
			label121 = new System.Windows.Forms.Label();
			label122 = new System.Windows.Forms.Label();
			textBox7_0 = new System.Windows.Forms.TextBox();
			labelVal7 = new System.Windows.Forms.Label();
			labelAdr7 = new System.Windows.Forms.Label();
			textBox7_1 = new System.Windows.Forms.TextBox();
			labelName7 = new System.Windows.Forms.Label();
			textBox7_2 = new System.Windows.Forms.TextBox();
			textBox7_11 = new System.Windows.Forms.TextBox();
			textBox7_12 = new System.Windows.Forms.TextBox();
			textBox7_3 = new System.Windows.Forms.TextBox();
			textBox7_10 = new System.Windows.Forms.TextBox();
			textBox7_13 = new System.Windows.Forms.TextBox();
			textBox7_4 = new System.Windows.Forms.TextBox();
			textBox7_9 = new System.Windows.Forms.TextBox();
			textBox7_14 = new System.Windows.Forms.TextBox();
			textBox7_5 = new System.Windows.Forms.TextBox();
			textBox7_8 = new System.Windows.Forms.TextBox();
			textBox7_7 = new System.Windows.Forms.TextBox();
			textBox7_6 = new System.Windows.Forms.TextBox();
			panel8 = new System.Windows.Forms.Panel();
			textBox8_15 = new System.Windows.Forms.TextBox();
			label123 = new System.Windows.Forms.Label();
			label124 = new System.Windows.Forms.Label();
			label125 = new System.Windows.Forms.Label();
			label126 = new System.Windows.Forms.Label();
			label127 = new System.Windows.Forms.Label();
			label128 = new System.Windows.Forms.Label();
			label129 = new System.Windows.Forms.Label();
			label130 = new System.Windows.Forms.Label();
			label131 = new System.Windows.Forms.Label();
			label132 = new System.Windows.Forms.Label();
			label133 = new System.Windows.Forms.Label();
			label134 = new System.Windows.Forms.Label();
			label135 = new System.Windows.Forms.Label();
			label136 = new System.Windows.Forms.Label();
			label137 = new System.Windows.Forms.Label();
			label138 = new System.Windows.Forms.Label();
			textBox8_0 = new System.Windows.Forms.TextBox();
			labelVal8 = new System.Windows.Forms.Label();
			labelAdr8 = new System.Windows.Forms.Label();
			textBox8_1 = new System.Windows.Forms.TextBox();
			labelName8 = new System.Windows.Forms.Label();
			textBox8_2 = new System.Windows.Forms.TextBox();
			textBox8_11 = new System.Windows.Forms.TextBox();
			textBox8_12 = new System.Windows.Forms.TextBox();
			textBox8_3 = new System.Windows.Forms.TextBox();
			textBox8_10 = new System.Windows.Forms.TextBox();
			textBox8_13 = new System.Windows.Forms.TextBox();
			textBox8_4 = new System.Windows.Forms.TextBox();
			textBox8_9 = new System.Windows.Forms.TextBox();
			textBox8_14 = new System.Windows.Forms.TextBox();
			textBox8_5 = new System.Windows.Forms.TextBox();
			textBox8_8 = new System.Windows.Forms.TextBox();
			textBox8_7 = new System.Windows.Forms.TextBox();
			textBox8_6 = new System.Windows.Forms.TextBox();
			panel9 = new System.Windows.Forms.Panel();
			textBox9_15 = new System.Windows.Forms.TextBox();
			label139 = new System.Windows.Forms.Label();
			label140 = new System.Windows.Forms.Label();
			label141 = new System.Windows.Forms.Label();
			label142 = new System.Windows.Forms.Label();
			label143 = new System.Windows.Forms.Label();
			label144 = new System.Windows.Forms.Label();
			label145 = new System.Windows.Forms.Label();
			label146 = new System.Windows.Forms.Label();
			label147 = new System.Windows.Forms.Label();
			label148 = new System.Windows.Forms.Label();
			label149 = new System.Windows.Forms.Label();
			label150 = new System.Windows.Forms.Label();
			label151 = new System.Windows.Forms.Label();
			label152 = new System.Windows.Forms.Label();
			label153 = new System.Windows.Forms.Label();
			label154 = new System.Windows.Forms.Label();
			textBox9_0 = new System.Windows.Forms.TextBox();
			labelVal9 = new System.Windows.Forms.Label();
			labelAdr9 = new System.Windows.Forms.Label();
			textBox9_1 = new System.Windows.Forms.TextBox();
			labelName9 = new System.Windows.Forms.Label();
			textBox9_2 = new System.Windows.Forms.TextBox();
			textBox9_11 = new System.Windows.Forms.TextBox();
			textBox9_12 = new System.Windows.Forms.TextBox();
			textBox9_3 = new System.Windows.Forms.TextBox();
			textBox9_10 = new System.Windows.Forms.TextBox();
			textBox9_13 = new System.Windows.Forms.TextBox();
			textBox9_4 = new System.Windows.Forms.TextBox();
			textBox9_9 = new System.Windows.Forms.TextBox();
			textBox9_14 = new System.Windows.Forms.TextBox();
			textBox9_5 = new System.Windows.Forms.TextBox();
			textBox9_8 = new System.Windows.Forms.TextBox();
			textBox9_7 = new System.Windows.Forms.TextBox();
			textBox9_6 = new System.Windows.Forms.TextBox();
			label155 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel3.SuspendLayout();
			panel4.SuspendLayout();
			panel5.SuspendLayout();
			panel6.SuspendLayout();
			panel7.SuspendLayout();
			panel8.SuspendLayout();
			panel9.SuspendLayout();
			SuspendLayout();
			panel1.Controls.Add(textBox1_15);
			panel1.Controls.Add(label23);
			panel1.Controls.Add(label22);
			panel1.Controls.Add(label21);
			panel1.Controls.Add(label20);
			panel1.Controls.Add(label19);
			panel1.Controls.Add(label18);
			panel1.Controls.Add(label17);
			panel1.Controls.Add(label16);
			panel1.Controls.Add(label15);
			panel1.Controls.Add(label14);
			panel1.Controls.Add(label13);
			panel1.Controls.Add(label12);
			panel1.Controls.Add(label11);
			panel1.Controls.Add(label10);
			panel1.Controls.Add(label9);
			panel1.Controls.Add(label8);
			panel1.Controls.Add(textBox1_0);
			panel1.Controls.Add(labelVal1);
			panel1.Controls.Add(labelAdr1);
			panel1.Controls.Add(textBox1_1);
			panel1.Controls.Add(labelName1);
			panel1.Controls.Add(textBox1_2);
			panel1.Controls.Add(textBox1_11);
			panel1.Controls.Add(textBox1_12);
			panel1.Controls.Add(textBox1_3);
			panel1.Controls.Add(textBox1_10);
			panel1.Controls.Add(textBox1_13);
			panel1.Controls.Add(textBox1_4);
			panel1.Controls.Add(textBox1_9);
			panel1.Controls.Add(textBox1_14);
			panel1.Controls.Add(textBox1_5);
			panel1.Controls.Add(textBox1_8);
			panel1.Controls.Add(textBox1_7);
			panel1.Controls.Add(textBox1_6);
			panel1.Location = new System.Drawing.Point(12, 77);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(648, 46);
			panel1.TabIndex = 0;
			textBox1_15.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_15.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_15.Location = new System.Drawing.Point(237, 22);
			textBox1_15.Name = "textBox1_15";
			textBox1_15.ReadOnly = true;
			textBox1_15.Size = new System.Drawing.Size(18, 20);
			textBox1_15.TabIndex = 11;
			textBox1_15.Text = "1";
			textBox1_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_15.Click += new System.EventHandler(textBox1_15_Click);
			label23.AutoSize = true;
			label23.Location = new System.Drawing.Point(624, 6);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(13, 13);
			label23.TabIndex = 38;
			label23.Text = "0";
			label22.AutoSize = true;
			label22.Location = new System.Drawing.Point(600, 6);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(13, 13);
			label22.TabIndex = 37;
			label22.Text = "1";
			label21.AutoSize = true;
			label21.Location = new System.Drawing.Point(576, 6);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(13, 13);
			label21.TabIndex = 36;
			label21.Text = "2";
			label20.AutoSize = true;
			label20.Location = new System.Drawing.Point(552, 6);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(13, 13);
			label20.TabIndex = 35;
			label20.Text = "3";
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(520, 6);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(13, 13);
			label19.TabIndex = 34;
			label19.Text = "4";
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(496, 6);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(13, 13);
			label18.TabIndex = 33;
			label18.Text = "5";
			label17.AutoSize = true;
			label17.Location = new System.Drawing.Point(472, 6);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(13, 13);
			label17.TabIndex = 32;
			label17.Text = "6";
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(448, 6);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(13, 13);
			label16.TabIndex = 31;
			label16.Text = "7";
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(415, 6);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(13, 13);
			label15.TabIndex = 30;
			label15.Text = "8";
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(391, 6);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(13, 13);
			label14.TabIndex = 29;
			label14.Text = "9";
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(364, 6);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(19, 13);
			label13.TabIndex = 28;
			label13.Text = "10";
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(340, 6);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(19, 13);
			label12.TabIndex = 27;
			label12.Text = "11";
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(308, 6);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(19, 13);
			label11.TabIndex = 26;
			label11.Text = "12";
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(284, 6);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(19, 13);
			label10.TabIndex = 25;
			label10.Text = "13";
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(260, 6);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(19, 13);
			label9.TabIndex = 24;
			label9.Text = "14";
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(236, 6);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(19, 13);
			label8.TabIndex = 23;
			label8.Text = "15";
			textBox1_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_0.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_0.Location = new System.Drawing.Point(622, 22);
			textBox1_0.Name = "textBox1_0";
			textBox1_0.ReadOnly = true;
			textBox1_0.Size = new System.Drawing.Size(18, 20);
			textBox1_0.TabIndex = 22;
			textBox1_0.Text = "1";
			textBox1_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_0.Click += new System.EventHandler(textBox1_15_Click);
			labelVal1.AutoSize = true;
			labelVal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelVal1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			labelVal1.Location = new System.Drawing.Point(165, 23);
			labelVal1.Name = "labelVal1";
			labelVal1.Size = new System.Drawing.Size(39, 15);
			labelVal1.TabIndex = 7;
			labelVal1.Text = "3FFF";
			labelAdr1.AutoSize = true;
			labelAdr1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelAdr1.Location = new System.Drawing.Point(88, 23);
			labelAdr1.Name = "labelAdr1";
			labelAdr1.Size = new System.Drawing.Size(39, 15);
			labelAdr1.TabIndex = 1;
			labelAdr1.Text = "2007";
			textBox1_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_1.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_1.Location = new System.Drawing.Point(598, 22);
			textBox1_1.Name = "textBox1_1";
			textBox1_1.ReadOnly = true;
			textBox1_1.Size = new System.Drawing.Size(18, 20);
			textBox1_1.TabIndex = 21;
			textBox1_1.Text = "1";
			textBox1_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_1.Click += new System.EventHandler(textBox1_15_Click);
			labelName1.AutoSize = true;
			labelName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelName1.Location = new System.Drawing.Point(-3, 23);
			labelName1.Name = "labelName1";
			labelName1.Size = new System.Drawing.Size(58, 15);
			labelName1.TabIndex = 0;
			labelName1.Text = "CONFIG";
			textBox1_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_2.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_2.Location = new System.Drawing.Point(574, 22);
			textBox1_2.Name = "textBox1_2";
			textBox1_2.ReadOnly = true;
			textBox1_2.Size = new System.Drawing.Size(18, 20);
			textBox1_2.TabIndex = 20;
			textBox1_2.Text = "1";
			textBox1_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_2.Click += new System.EventHandler(textBox1_15_Click);
			textBox1_11.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_11.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_11.Location = new System.Drawing.Point(341, 22);
			textBox1_11.Name = "textBox1_11";
			textBox1_11.ReadOnly = true;
			textBox1_11.Size = new System.Drawing.Size(18, 20);
			textBox1_11.TabIndex = 11;
			textBox1_11.Text = "1";
			textBox1_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_11.Click += new System.EventHandler(textBox1_15_Click);
			textBox1_12.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_12.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_12.Location = new System.Drawing.Point(309, 22);
			textBox1_12.Name = "textBox1_12";
			textBox1_12.ReadOnly = true;
			textBox1_12.Size = new System.Drawing.Size(18, 20);
			textBox1_12.TabIndex = 10;
			textBox1_12.Text = "1";
			textBox1_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_12.Click += new System.EventHandler(textBox1_15_Click);
			textBox1_3.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_3.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_3.Location = new System.Drawing.Point(550, 22);
			textBox1_3.Name = "textBox1_3";
			textBox1_3.ReadOnly = true;
			textBox1_3.Size = new System.Drawing.Size(18, 20);
			textBox1_3.TabIndex = 19;
			textBox1_3.Text = "1";
			textBox1_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_3.Click += new System.EventHandler(textBox1_15_Click);
			textBox1_10.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_10.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_10.Location = new System.Drawing.Point(365, 22);
			textBox1_10.Name = "textBox1_10";
			textBox1_10.ReadOnly = true;
			textBox1_10.Size = new System.Drawing.Size(18, 20);
			textBox1_10.TabIndex = 12;
			textBox1_10.Text = "1";
			textBox1_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_10.Click += new System.EventHandler(textBox1_15_Click);
			textBox1_13.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_13.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_13.Location = new System.Drawing.Point(285, 22);
			textBox1_13.Name = "textBox1_13";
			textBox1_13.ReadOnly = true;
			textBox1_13.Size = new System.Drawing.Size(18, 20);
			textBox1_13.TabIndex = 9;
			textBox1_13.Text = "1";
			textBox1_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_13.Click += new System.EventHandler(textBox1_15_Click);
			textBox1_4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_4.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_4.Location = new System.Drawing.Point(518, 22);
			textBox1_4.Name = "textBox1_4";
			textBox1_4.ReadOnly = true;
			textBox1_4.Size = new System.Drawing.Size(18, 20);
			textBox1_4.TabIndex = 18;
			textBox1_4.Text = "1";
			textBox1_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_4.Click += new System.EventHandler(textBox1_15_Click);
			textBox1_9.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_9.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_9.Location = new System.Drawing.Point(389, 22);
			textBox1_9.Name = "textBox1_9";
			textBox1_9.ReadOnly = true;
			textBox1_9.Size = new System.Drawing.Size(18, 20);
			textBox1_9.TabIndex = 13;
			textBox1_9.Text = "1";
			textBox1_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_9.Click += new System.EventHandler(textBox1_15_Click);
			textBox1_14.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_14.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_14.Location = new System.Drawing.Point(261, 22);
			textBox1_14.Name = "textBox1_14";
			textBox1_14.ReadOnly = true;
			textBox1_14.Size = new System.Drawing.Size(18, 20);
			textBox1_14.TabIndex = 8;
			textBox1_14.Text = "1";
			textBox1_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_14.Click += new System.EventHandler(textBox1_15_Click);
			textBox1_5.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_5.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_5.Location = new System.Drawing.Point(494, 22);
			textBox1_5.Name = "textBox1_5";
			textBox1_5.ReadOnly = true;
			textBox1_5.Size = new System.Drawing.Size(18, 20);
			textBox1_5.TabIndex = 17;
			textBox1_5.Text = "1";
			textBox1_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_5.Click += new System.EventHandler(textBox1_15_Click);
			textBox1_8.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_8.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_8.Location = new System.Drawing.Point(413, 22);
			textBox1_8.Name = "textBox1_8";
			textBox1_8.ReadOnly = true;
			textBox1_8.Size = new System.Drawing.Size(18, 20);
			textBox1_8.TabIndex = 14;
			textBox1_8.Text = "1";
			textBox1_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_8.Click += new System.EventHandler(textBox1_15_Click);
			textBox1_7.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_7.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_7.Location = new System.Drawing.Point(446, 22);
			textBox1_7.Name = "textBox1_7";
			textBox1_7.ReadOnly = true;
			textBox1_7.Size = new System.Drawing.Size(18, 20);
			textBox1_7.TabIndex = 15;
			textBox1_7.Text = "1";
			textBox1_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_7.Click += new System.EventHandler(textBox1_15_Click);
			textBox1_6.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox1_6.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox1_6.Location = new System.Drawing.Point(470, 22);
			textBox1_6.Name = "textBox1_6";
			textBox1_6.ReadOnly = true;
			textBox1_6.Size = new System.Drawing.Size(18, 20);
			textBox1_6.TabIndex = 16;
			textBox1_6.Text = "1";
			textBox1_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox1_6.Click += new System.EventHandler(textBox1_15_Click);
			buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			buttonSave.Location = new System.Drawing.Point(502, 523);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new System.Drawing.Size(75, 23);
			buttonSave.TabIndex = 1;
			buttonSave.Text = "Save";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += new System.EventHandler(buttonSave_Click);
			buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			buttonCancel.Location = new System.Drawing.Point(585, 523);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new System.Drawing.Size(75, 23);
			buttonCancel.TabIndex = 2;
			buttonCancel.Text = "Cancel";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += new System.EventHandler(buttonCancel_Click);
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(9, 58);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(49, 16);
			label1.TabIndex = 3;
			label1.Text = "Name";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(100, 58);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(66, 16);
			label2.TabIndex = 4;
			label2.Text = "Address";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(177, 58);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(48, 16);
			label3.TabIndex = 5;
			label3.Text = "Value";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(422, 58);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(57, 16);
			label4.TabIndex = 6;
			label4.Text = "Bit Edit";
			textBoxEx.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBoxEx.Cursor = System.Windows.Forms.Cursors.Default;
			textBoxEx.Enabled = false;
			textBoxEx.Location = new System.Drawing.Point(172, 25);
			textBoxEx.Name = "textBoxEx";
			textBoxEx.ReadOnly = true;
			textBoxEx.Size = new System.Drawing.Size(18, 20);
			textBoxEx.TabIndex = 7;
			textBoxEx.Text = "1";
			textBoxEx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(9, 9);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(615, 13);
			label5.TabIndex = 7;
			label5.Text = "Device Configuration Words may be edited here at the bit level.  Refer to device datasheet for specific configuration bit functions.";
			textBoxUnimpl.BackColor = System.Drawing.SystemColors.Control;
			textBoxUnimpl.Cursor = System.Windows.Forms.Cursors.Default;
			textBoxUnimpl.Enabled = false;
			textBoxUnimpl.Location = new System.Drawing.Point(12, 25);
			textBoxUnimpl.Name = "textBoxUnimpl";
			textBoxUnimpl.ReadOnly = true;
			textBoxUnimpl.Size = new System.Drawing.Size(18, 20);
			textBoxUnimpl.TabIndex = 8;
			textBoxUnimpl.Text = "-";
			textBoxUnimpl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(36, 28);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(103, 13);
			label6.TabIndex = 9;
			label6.Text = "= Unimplemented bit";
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(196, 28);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(200, 13);
			label7.TabIndex = 10;
			label7.Text = "= Configuration bit.  Click to toggle value.";
			panel2.Controls.Add(textBox2_15);
			panel2.Controls.Add(label24);
			panel2.Controls.Add(label25);
			panel2.Controls.Add(label26);
			panel2.Controls.Add(label27);
			panel2.Controls.Add(label28);
			panel2.Controls.Add(label29);
			panel2.Controls.Add(label30);
			panel2.Controls.Add(label31);
			panel2.Controls.Add(label32);
			panel2.Controls.Add(label33);
			panel2.Controls.Add(label34);
			panel2.Controls.Add(label35);
			panel2.Controls.Add(label36);
			panel2.Controls.Add(label37);
			panel2.Controls.Add(label38);
			panel2.Controls.Add(label39);
			panel2.Controls.Add(textBox2_0);
			panel2.Controls.Add(labelVal2);
			panel2.Controls.Add(labelAdr2);
			panel2.Controls.Add(textBox2_1);
			panel2.Controls.Add(labelName2);
			panel2.Controls.Add(textBox2_2);
			panel2.Controls.Add(textBox2_11);
			panel2.Controls.Add(textBox2_12);
			panel2.Controls.Add(textBox2_3);
			panel2.Controls.Add(textBox2_10);
			panel2.Controls.Add(textBox2_13);
			panel2.Controls.Add(textBox2_4);
			panel2.Controls.Add(textBox2_9);
			panel2.Controls.Add(textBox2_14);
			panel2.Controls.Add(textBox2_5);
			panel2.Controls.Add(textBox2_8);
			panel2.Controls.Add(textBox2_7);
			panel2.Controls.Add(textBox2_6);
			panel2.Location = new System.Drawing.Point(12, 125);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(648, 46);
			panel2.TabIndex = 11;
			textBox2_15.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_15.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_15.Location = new System.Drawing.Point(237, 22);
			textBox2_15.Name = "textBox2_15";
			textBox2_15.ReadOnly = true;
			textBox2_15.Size = new System.Drawing.Size(18, 20);
			textBox2_15.TabIndex = 11;
			textBox2_15.Text = "1";
			textBox2_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_15.Click += new System.EventHandler(textBox1_15_Click);
			label24.AutoSize = true;
			label24.Location = new System.Drawing.Point(624, 6);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(13, 13);
			label24.TabIndex = 38;
			label24.Text = "0";
			label25.AutoSize = true;
			label25.Location = new System.Drawing.Point(600, 6);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(13, 13);
			label25.TabIndex = 37;
			label25.Text = "1";
			label26.AutoSize = true;
			label26.Location = new System.Drawing.Point(576, 6);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(13, 13);
			label26.TabIndex = 36;
			label26.Text = "2";
			label27.AutoSize = true;
			label27.Location = new System.Drawing.Point(552, 6);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(13, 13);
			label27.TabIndex = 35;
			label27.Text = "3";
			label28.AutoSize = true;
			label28.Location = new System.Drawing.Point(520, 6);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(13, 13);
			label28.TabIndex = 34;
			label28.Text = "4";
			label29.AutoSize = true;
			label29.Location = new System.Drawing.Point(496, 6);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(13, 13);
			label29.TabIndex = 33;
			label29.Text = "5";
			label30.AutoSize = true;
			label30.Location = new System.Drawing.Point(472, 6);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(13, 13);
			label30.TabIndex = 32;
			label30.Text = "6";
			label31.AutoSize = true;
			label31.Location = new System.Drawing.Point(448, 6);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(13, 13);
			label31.TabIndex = 31;
			label31.Text = "7";
			label32.AutoSize = true;
			label32.Location = new System.Drawing.Point(415, 6);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(13, 13);
			label32.TabIndex = 30;
			label32.Text = "8";
			label33.AutoSize = true;
			label33.Location = new System.Drawing.Point(391, 6);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(13, 13);
			label33.TabIndex = 29;
			label33.Text = "9";
			label34.AutoSize = true;
			label34.Location = new System.Drawing.Point(364, 6);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(19, 13);
			label34.TabIndex = 28;
			label34.Text = "10";
			label35.AutoSize = true;
			label35.Location = new System.Drawing.Point(340, 6);
			label35.Name = "label35";
			label35.Size = new System.Drawing.Size(19, 13);
			label35.TabIndex = 27;
			label35.Text = "11";
			label36.AutoSize = true;
			label36.Location = new System.Drawing.Point(308, 6);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(19, 13);
			label36.TabIndex = 26;
			label36.Text = "12";
			label37.AutoSize = true;
			label37.Location = new System.Drawing.Point(284, 6);
			label37.Name = "label37";
			label37.Size = new System.Drawing.Size(19, 13);
			label37.TabIndex = 25;
			label37.Text = "13";
			label38.AutoSize = true;
			label38.Location = new System.Drawing.Point(260, 6);
			label38.Name = "label38";
			label38.Size = new System.Drawing.Size(19, 13);
			label38.TabIndex = 24;
			label38.Text = "14";
			label39.AutoSize = true;
			label39.Location = new System.Drawing.Point(236, 6);
			label39.Name = "label39";
			label39.Size = new System.Drawing.Size(19, 13);
			label39.TabIndex = 23;
			label39.Text = "15";
			textBox2_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_0.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_0.Location = new System.Drawing.Point(622, 22);
			textBox2_0.Name = "textBox2_0";
			textBox2_0.ReadOnly = true;
			textBox2_0.Size = new System.Drawing.Size(18, 20);
			textBox2_0.TabIndex = 22;
			textBox2_0.Text = "1";
			textBox2_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_0.Click += new System.EventHandler(textBox1_15_Click);
			labelVal2.AutoSize = true;
			labelVal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelVal2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			labelVal2.Location = new System.Drawing.Point(165, 23);
			labelVal2.Name = "labelVal2";
			labelVal2.Size = new System.Drawing.Size(39, 15);
			labelVal2.TabIndex = 7;
			labelVal2.Text = "3FFF";
			labelAdr2.AutoSize = true;
			labelAdr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelAdr2.Location = new System.Drawing.Point(88, 23);
			labelAdr2.Name = "labelAdr2";
			labelAdr2.Size = new System.Drawing.Size(71, 15);
			labelAdr2.TabIndex = 1;
			labelAdr2.Text = "20080000";
			textBox2_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_1.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_1.Location = new System.Drawing.Point(598, 22);
			textBox2_1.Name = "textBox2_1";
			textBox2_1.ReadOnly = true;
			textBox2_1.Size = new System.Drawing.Size(18, 20);
			textBox2_1.TabIndex = 21;
			textBox2_1.Text = "1";
			textBox2_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_1.Click += new System.EventHandler(textBox1_15_Click);
			labelName2.AutoSize = true;
			labelName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelName2.Location = new System.Drawing.Point(-3, 23);
			labelName2.Name = "labelName2";
			labelName2.Size = new System.Drawing.Size(66, 15);
			labelName2.TabIndex = 0;
			labelName2.Text = "CONFIG2";
			textBox2_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_2.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_2.Location = new System.Drawing.Point(574, 22);
			textBox2_2.Name = "textBox2_2";
			textBox2_2.ReadOnly = true;
			textBox2_2.Size = new System.Drawing.Size(18, 20);
			textBox2_2.TabIndex = 20;
			textBox2_2.Text = "1";
			textBox2_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_2.Click += new System.EventHandler(textBox1_15_Click);
			textBox2_11.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_11.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_11.Location = new System.Drawing.Point(341, 22);
			textBox2_11.Name = "textBox2_11";
			textBox2_11.ReadOnly = true;
			textBox2_11.Size = new System.Drawing.Size(18, 20);
			textBox2_11.TabIndex = 11;
			textBox2_11.Text = "1";
			textBox2_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_11.Click += new System.EventHandler(textBox1_15_Click);
			textBox2_12.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_12.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_12.Location = new System.Drawing.Point(309, 22);
			textBox2_12.Name = "textBox2_12";
			textBox2_12.ReadOnly = true;
			textBox2_12.Size = new System.Drawing.Size(18, 20);
			textBox2_12.TabIndex = 10;
			textBox2_12.Text = "1";
			textBox2_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_12.Click += new System.EventHandler(textBox1_15_Click);
			textBox2_3.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_3.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_3.Location = new System.Drawing.Point(550, 22);
			textBox2_3.Name = "textBox2_3";
			textBox2_3.ReadOnly = true;
			textBox2_3.Size = new System.Drawing.Size(18, 20);
			textBox2_3.TabIndex = 19;
			textBox2_3.Text = "1";
			textBox2_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_3.Click += new System.EventHandler(textBox1_15_Click);
			textBox2_10.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_10.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_10.Location = new System.Drawing.Point(365, 22);
			textBox2_10.Name = "textBox2_10";
			textBox2_10.ReadOnly = true;
			textBox2_10.Size = new System.Drawing.Size(18, 20);
			textBox2_10.TabIndex = 12;
			textBox2_10.Text = "1";
			textBox2_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_10.Click += new System.EventHandler(textBox1_15_Click);
			textBox2_13.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_13.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_13.Location = new System.Drawing.Point(285, 22);
			textBox2_13.Name = "textBox2_13";
			textBox2_13.ReadOnly = true;
			textBox2_13.Size = new System.Drawing.Size(18, 20);
			textBox2_13.TabIndex = 9;
			textBox2_13.Text = "1";
			textBox2_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_13.Click += new System.EventHandler(textBox1_15_Click);
			textBox2_4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_4.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_4.Location = new System.Drawing.Point(518, 22);
			textBox2_4.Name = "textBox2_4";
			textBox2_4.ReadOnly = true;
			textBox2_4.Size = new System.Drawing.Size(18, 20);
			textBox2_4.TabIndex = 18;
			textBox2_4.Text = "1";
			textBox2_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_4.Click += new System.EventHandler(textBox1_15_Click);
			textBox2_9.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_9.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_9.Location = new System.Drawing.Point(389, 22);
			textBox2_9.Name = "textBox2_9";
			textBox2_9.ReadOnly = true;
			textBox2_9.Size = new System.Drawing.Size(18, 20);
			textBox2_9.TabIndex = 13;
			textBox2_9.Text = "1";
			textBox2_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_9.Click += new System.EventHandler(textBox1_15_Click);
			textBox2_14.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_14.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_14.Location = new System.Drawing.Point(261, 22);
			textBox2_14.Name = "textBox2_14";
			textBox2_14.ReadOnly = true;
			textBox2_14.Size = new System.Drawing.Size(18, 20);
			textBox2_14.TabIndex = 8;
			textBox2_14.Text = "1";
			textBox2_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_14.Click += new System.EventHandler(textBox1_15_Click);
			textBox2_5.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_5.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_5.Location = new System.Drawing.Point(494, 22);
			textBox2_5.Name = "textBox2_5";
			textBox2_5.ReadOnly = true;
			textBox2_5.Size = new System.Drawing.Size(18, 20);
			textBox2_5.TabIndex = 17;
			textBox2_5.Text = "1";
			textBox2_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_5.Click += new System.EventHandler(textBox1_15_Click);
			textBox2_8.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_8.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_8.Location = new System.Drawing.Point(413, 22);
			textBox2_8.Name = "textBox2_8";
			textBox2_8.ReadOnly = true;
			textBox2_8.Size = new System.Drawing.Size(18, 20);
			textBox2_8.TabIndex = 14;
			textBox2_8.Text = "1";
			textBox2_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_8.Click += new System.EventHandler(textBox1_15_Click);
			textBox2_7.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_7.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_7.Location = new System.Drawing.Point(446, 22);
			textBox2_7.Name = "textBox2_7";
			textBox2_7.ReadOnly = true;
			textBox2_7.Size = new System.Drawing.Size(18, 20);
			textBox2_7.TabIndex = 15;
			textBox2_7.Text = "1";
			textBox2_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_7.Click += new System.EventHandler(textBox1_15_Click);
			textBox2_6.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox2_6.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox2_6.Location = new System.Drawing.Point(470, 22);
			textBox2_6.Name = "textBox2_6";
			textBox2_6.ReadOnly = true;
			textBox2_6.Size = new System.Drawing.Size(18, 20);
			textBox2_6.TabIndex = 16;
			textBox2_6.Text = "1";
			textBox2_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox2_6.Click += new System.EventHandler(textBox1_15_Click);
			label40.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			label40.AutoSize = true;
			label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label40.Location = new System.Drawing.Point(100, 523);
			label40.Name = "label40";
			label40.Size = new System.Drawing.Size(317, 13);
			label40.TabIndex = 12;
			label40.Text = "Unimplemented bits are displayed in the Value column as selected";
			label41.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			label41.AutoSize = true;
			label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label41.Location = new System.Drawing.Point(100, 536);
			label41.Name = "label41";
			label41.Size = new System.Drawing.Size(44, 13);
			label41.TabIndex = 13;
			label41.Text = "in menu";
			label42.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			label42.AutoSize = true;
			label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
			label42.Location = new System.Drawing.Point(142, 536);
			label42.Name = "label42";
			label42.Size = new System.Drawing.Size(208, 13);
			label42.TabIndex = 14;
			label42.Text = "Tools > Display Unimplemented Config Bits";
			panel3.Controls.Add(textBox3_15);
			panel3.Controls.Add(label43);
			panel3.Controls.Add(label44);
			panel3.Controls.Add(label45);
			panel3.Controls.Add(label46);
			panel3.Controls.Add(label47);
			panel3.Controls.Add(label48);
			panel3.Controls.Add(label49);
			panel3.Controls.Add(label50);
			panel3.Controls.Add(label51);
			panel3.Controls.Add(label52);
			panel3.Controls.Add(label53);
			panel3.Controls.Add(label54);
			panel3.Controls.Add(label55);
			panel3.Controls.Add(label56);
			panel3.Controls.Add(label57);
			panel3.Controls.Add(label58);
			panel3.Controls.Add(textBox3_0);
			panel3.Controls.Add(labelVal3);
			panel3.Controls.Add(labelAdr3);
			panel3.Controls.Add(textBox3_1);
			panel3.Controls.Add(labelName3);
			panel3.Controls.Add(textBox3_2);
			panel3.Controls.Add(textBox3_11);
			panel3.Controls.Add(textBox3_12);
			panel3.Controls.Add(textBox3_3);
			panel3.Controls.Add(textBox3_10);
			panel3.Controls.Add(textBox3_13);
			panel3.Controls.Add(textBox3_4);
			panel3.Controls.Add(textBox3_9);
			panel3.Controls.Add(textBox3_14);
			panel3.Controls.Add(textBox3_5);
			panel3.Controls.Add(textBox3_8);
			panel3.Controls.Add(textBox3_7);
			panel3.Controls.Add(textBox3_6);
			panel3.Location = new System.Drawing.Point(12, 173);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(648, 46);
			panel3.TabIndex = 15;
			textBox3_15.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_15.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_15.Location = new System.Drawing.Point(237, 22);
			textBox3_15.Name = "textBox3_15";
			textBox3_15.ReadOnly = true;
			textBox3_15.Size = new System.Drawing.Size(18, 20);
			textBox3_15.TabIndex = 11;
			textBox3_15.Text = "1";
			textBox3_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_15.Click += new System.EventHandler(textBox1_15_Click);
			label43.AutoSize = true;
			label43.Location = new System.Drawing.Point(624, 6);
			label43.Name = "label43";
			label43.Size = new System.Drawing.Size(13, 13);
			label43.TabIndex = 38;
			label43.Text = "0";
			label44.AutoSize = true;
			label44.Location = new System.Drawing.Point(600, 6);
			label44.Name = "label44";
			label44.Size = new System.Drawing.Size(13, 13);
			label44.TabIndex = 37;
			label44.Text = "1";
			label45.AutoSize = true;
			label45.Location = new System.Drawing.Point(576, 6);
			label45.Name = "label45";
			label45.Size = new System.Drawing.Size(13, 13);
			label45.TabIndex = 36;
			label45.Text = "2";
			label46.AutoSize = true;
			label46.Location = new System.Drawing.Point(552, 6);
			label46.Name = "label46";
			label46.Size = new System.Drawing.Size(13, 13);
			label46.TabIndex = 35;
			label46.Text = "3";
			label47.AutoSize = true;
			label47.Location = new System.Drawing.Point(520, 6);
			label47.Name = "label47";
			label47.Size = new System.Drawing.Size(13, 13);
			label47.TabIndex = 34;
			label47.Text = "4";
			label48.AutoSize = true;
			label48.Location = new System.Drawing.Point(496, 6);
			label48.Name = "label48";
			label48.Size = new System.Drawing.Size(13, 13);
			label48.TabIndex = 33;
			label48.Text = "5";
			label49.AutoSize = true;
			label49.Location = new System.Drawing.Point(472, 6);
			label49.Name = "label49";
			label49.Size = new System.Drawing.Size(13, 13);
			label49.TabIndex = 32;
			label49.Text = "6";
			label50.AutoSize = true;
			label50.Location = new System.Drawing.Point(448, 6);
			label50.Name = "label50";
			label50.Size = new System.Drawing.Size(13, 13);
			label50.TabIndex = 31;
			label50.Text = "7";
			label51.AutoSize = true;
			label51.Location = new System.Drawing.Point(415, 6);
			label51.Name = "label51";
			label51.Size = new System.Drawing.Size(13, 13);
			label51.TabIndex = 30;
			label51.Text = "8";
			label52.AutoSize = true;
			label52.Location = new System.Drawing.Point(391, 6);
			label52.Name = "label52";
			label52.Size = new System.Drawing.Size(13, 13);
			label52.TabIndex = 29;
			label52.Text = "9";
			label53.AutoSize = true;
			label53.Location = new System.Drawing.Point(364, 6);
			label53.Name = "label53";
			label53.Size = new System.Drawing.Size(19, 13);
			label53.TabIndex = 28;
			label53.Text = "10";
			label54.AutoSize = true;
			label54.Location = new System.Drawing.Point(340, 6);
			label54.Name = "label54";
			label54.Size = new System.Drawing.Size(19, 13);
			label54.TabIndex = 27;
			label54.Text = "11";
			label55.AutoSize = true;
			label55.Location = new System.Drawing.Point(308, 6);
			label55.Name = "label55";
			label55.Size = new System.Drawing.Size(19, 13);
			label55.TabIndex = 26;
			label55.Text = "12";
			label56.AutoSize = true;
			label56.Location = new System.Drawing.Point(284, 6);
			label56.Name = "label56";
			label56.Size = new System.Drawing.Size(19, 13);
			label56.TabIndex = 25;
			label56.Text = "13";
			label57.AutoSize = true;
			label57.Location = new System.Drawing.Point(260, 6);
			label57.Name = "label57";
			label57.Size = new System.Drawing.Size(19, 13);
			label57.TabIndex = 24;
			label57.Text = "14";
			label58.AutoSize = true;
			label58.Location = new System.Drawing.Point(236, 6);
			label58.Name = "label58";
			label58.Size = new System.Drawing.Size(19, 13);
			label58.TabIndex = 23;
			label58.Text = "15";
			textBox3_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_0.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_0.Location = new System.Drawing.Point(622, 22);
			textBox3_0.Name = "textBox3_0";
			textBox3_0.ReadOnly = true;
			textBox3_0.Size = new System.Drawing.Size(18, 20);
			textBox3_0.TabIndex = 22;
			textBox3_0.Text = "1";
			textBox3_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_0.Click += new System.EventHandler(textBox1_15_Click);
			labelVal3.AutoSize = true;
			labelVal3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelVal3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			labelVal3.Location = new System.Drawing.Point(165, 23);
			labelVal3.Name = "labelVal3";
			labelVal3.Size = new System.Drawing.Size(39, 15);
			labelVal3.TabIndex = 7;
			labelVal3.Text = "3FFF";
			labelAdr3.AutoSize = true;
			labelAdr3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelAdr3.Location = new System.Drawing.Point(88, 23);
			labelAdr3.Name = "labelAdr3";
			labelAdr3.Size = new System.Drawing.Size(71, 15);
			labelAdr3.TabIndex = 1;
			labelAdr3.Text = "20080000";
			textBox3_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_1.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_1.Location = new System.Drawing.Point(598, 22);
			textBox3_1.Name = "textBox3_1";
			textBox3_1.ReadOnly = true;
			textBox3_1.Size = new System.Drawing.Size(18, 20);
			textBox3_1.TabIndex = 21;
			textBox3_1.Text = "1";
			textBox3_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_1.Click += new System.EventHandler(textBox1_15_Click);
			labelName3.AutoSize = true;
			labelName3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelName3.Location = new System.Drawing.Point(-3, 23);
			labelName3.Name = "labelName3";
			labelName3.Size = new System.Drawing.Size(73, 15);
			labelName3.TabIndex = 0;
			labelName3.Text = "FBORPOR";
			textBox3_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_2.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_2.Location = new System.Drawing.Point(574, 22);
			textBox3_2.Name = "textBox3_2";
			textBox3_2.ReadOnly = true;
			textBox3_2.Size = new System.Drawing.Size(18, 20);
			textBox3_2.TabIndex = 20;
			textBox3_2.Text = "1";
			textBox3_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_2.Click += new System.EventHandler(textBox1_15_Click);
			textBox3_11.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_11.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_11.Location = new System.Drawing.Point(341, 22);
			textBox3_11.Name = "textBox3_11";
			textBox3_11.ReadOnly = true;
			textBox3_11.Size = new System.Drawing.Size(18, 20);
			textBox3_11.TabIndex = 11;
			textBox3_11.Text = "1";
			textBox3_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_11.Click += new System.EventHandler(textBox1_15_Click);
			textBox3_12.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_12.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_12.Location = new System.Drawing.Point(309, 22);
			textBox3_12.Name = "textBox3_12";
			textBox3_12.ReadOnly = true;
			textBox3_12.Size = new System.Drawing.Size(18, 20);
			textBox3_12.TabIndex = 10;
			textBox3_12.Text = "1";
			textBox3_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_12.Click += new System.EventHandler(textBox1_15_Click);
			textBox3_3.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_3.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_3.Location = new System.Drawing.Point(550, 22);
			textBox3_3.Name = "textBox3_3";
			textBox3_3.ReadOnly = true;
			textBox3_3.Size = new System.Drawing.Size(18, 20);
			textBox3_3.TabIndex = 19;
			textBox3_3.Text = "1";
			textBox3_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_3.Click += new System.EventHandler(textBox1_15_Click);
			textBox3_10.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_10.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_10.Location = new System.Drawing.Point(365, 22);
			textBox3_10.Name = "textBox3_10";
			textBox3_10.ReadOnly = true;
			textBox3_10.Size = new System.Drawing.Size(18, 20);
			textBox3_10.TabIndex = 12;
			textBox3_10.Text = "1";
			textBox3_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_10.Click += new System.EventHandler(textBox1_15_Click);
			textBox3_13.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_13.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_13.Location = new System.Drawing.Point(285, 22);
			textBox3_13.Name = "textBox3_13";
			textBox3_13.ReadOnly = true;
			textBox3_13.Size = new System.Drawing.Size(18, 20);
			textBox3_13.TabIndex = 9;
			textBox3_13.Text = "1";
			textBox3_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_13.Click += new System.EventHandler(textBox1_15_Click);
			textBox3_4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_4.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_4.Location = new System.Drawing.Point(518, 22);
			textBox3_4.Name = "textBox3_4";
			textBox3_4.ReadOnly = true;
			textBox3_4.Size = new System.Drawing.Size(18, 20);
			textBox3_4.TabIndex = 18;
			textBox3_4.Text = "1";
			textBox3_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_4.Click += new System.EventHandler(textBox1_15_Click);
			textBox3_9.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_9.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_9.Location = new System.Drawing.Point(389, 22);
			textBox3_9.Name = "textBox3_9";
			textBox3_9.ReadOnly = true;
			textBox3_9.Size = new System.Drawing.Size(18, 20);
			textBox3_9.TabIndex = 13;
			textBox3_9.Text = "1";
			textBox3_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_9.Click += new System.EventHandler(textBox1_15_Click);
			textBox3_14.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_14.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_14.Location = new System.Drawing.Point(261, 22);
			textBox3_14.Name = "textBox3_14";
			textBox3_14.ReadOnly = true;
			textBox3_14.Size = new System.Drawing.Size(18, 20);
			textBox3_14.TabIndex = 8;
			textBox3_14.Text = "1";
			textBox3_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_14.Click += new System.EventHandler(textBox1_15_Click);
			textBox3_5.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_5.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_5.Location = new System.Drawing.Point(494, 22);
			textBox3_5.Name = "textBox3_5";
			textBox3_5.ReadOnly = true;
			textBox3_5.Size = new System.Drawing.Size(18, 20);
			textBox3_5.TabIndex = 17;
			textBox3_5.Text = "1";
			textBox3_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_5.Click += new System.EventHandler(textBox1_15_Click);
			textBox3_8.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_8.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_8.Location = new System.Drawing.Point(413, 22);
			textBox3_8.Name = "textBox3_8";
			textBox3_8.ReadOnly = true;
			textBox3_8.Size = new System.Drawing.Size(18, 20);
			textBox3_8.TabIndex = 14;
			textBox3_8.Text = "1";
			textBox3_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_8.Click += new System.EventHandler(textBox1_15_Click);
			textBox3_7.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_7.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_7.Location = new System.Drawing.Point(446, 22);
			textBox3_7.Name = "textBox3_7";
			textBox3_7.ReadOnly = true;
			textBox3_7.Size = new System.Drawing.Size(18, 20);
			textBox3_7.TabIndex = 15;
			textBox3_7.Text = "1";
			textBox3_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_7.Click += new System.EventHandler(textBox1_15_Click);
			textBox3_6.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox3_6.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox3_6.Location = new System.Drawing.Point(470, 22);
			textBox3_6.Name = "textBox3_6";
			textBox3_6.ReadOnly = true;
			textBox3_6.Size = new System.Drawing.Size(18, 20);
			textBox3_6.TabIndex = 16;
			textBox3_6.Text = "1";
			textBox3_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox3_6.Click += new System.EventHandler(textBox1_15_Click);
			panel4.Controls.Add(textBox4_15);
			panel4.Controls.Add(label59);
			panel4.Controls.Add(label60);
			panel4.Controls.Add(label61);
			panel4.Controls.Add(label62);
			panel4.Controls.Add(label63);
			panel4.Controls.Add(label64);
			panel4.Controls.Add(label65);
			panel4.Controls.Add(label66);
			panel4.Controls.Add(label67);
			panel4.Controls.Add(label68);
			panel4.Controls.Add(label69);
			panel4.Controls.Add(label70);
			panel4.Controls.Add(label71);
			panel4.Controls.Add(label72);
			panel4.Controls.Add(label73);
			panel4.Controls.Add(label74);
			panel4.Controls.Add(textBox4_0);
			panel4.Controls.Add(labelVal4);
			panel4.Controls.Add(labelAdr4);
			panel4.Controls.Add(textBox4_1);
			panel4.Controls.Add(labelName4);
			panel4.Controls.Add(textBox4_2);
			panel4.Controls.Add(textBox4_11);
			panel4.Controls.Add(textBox4_12);
			panel4.Controls.Add(textBox4_3);
			panel4.Controls.Add(textBox4_10);
			panel4.Controls.Add(textBox4_13);
			panel4.Controls.Add(textBox4_4);
			panel4.Controls.Add(textBox4_9);
			panel4.Controls.Add(textBox4_14);
			panel4.Controls.Add(textBox4_5);
			panel4.Controls.Add(textBox4_8);
			panel4.Controls.Add(textBox4_7);
			panel4.Controls.Add(textBox4_6);
			panel4.Location = new System.Drawing.Point(12, 221);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(648, 46);
			panel4.TabIndex = 16;
			textBox4_15.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_15.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_15.Location = new System.Drawing.Point(237, 22);
			textBox4_15.Name = "textBox4_15";
			textBox4_15.ReadOnly = true;
			textBox4_15.Size = new System.Drawing.Size(18, 20);
			textBox4_15.TabIndex = 11;
			textBox4_15.Text = "1";
			textBox4_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_15.Click += new System.EventHandler(textBox1_15_Click);
			label59.AutoSize = true;
			label59.Location = new System.Drawing.Point(624, 6);
			label59.Name = "label59";
			label59.Size = new System.Drawing.Size(13, 13);
			label59.TabIndex = 38;
			label59.Text = "0";
			label60.AutoSize = true;
			label60.Location = new System.Drawing.Point(600, 6);
			label60.Name = "label60";
			label60.Size = new System.Drawing.Size(13, 13);
			label60.TabIndex = 37;
			label60.Text = "1";
			label61.AutoSize = true;
			label61.Location = new System.Drawing.Point(576, 6);
			label61.Name = "label61";
			label61.Size = new System.Drawing.Size(13, 13);
			label61.TabIndex = 36;
			label61.Text = "2";
			label62.AutoSize = true;
			label62.Location = new System.Drawing.Point(552, 6);
			label62.Name = "label62";
			label62.Size = new System.Drawing.Size(13, 13);
			label62.TabIndex = 35;
			label62.Text = "3";
			label63.AutoSize = true;
			label63.Location = new System.Drawing.Point(520, 6);
			label63.Name = "label63";
			label63.Size = new System.Drawing.Size(13, 13);
			label63.TabIndex = 34;
			label63.Text = "4";
			label64.AutoSize = true;
			label64.Location = new System.Drawing.Point(496, 6);
			label64.Name = "label64";
			label64.Size = new System.Drawing.Size(13, 13);
			label64.TabIndex = 33;
			label64.Text = "5";
			label65.AutoSize = true;
			label65.Location = new System.Drawing.Point(472, 6);
			label65.Name = "label65";
			label65.Size = new System.Drawing.Size(13, 13);
			label65.TabIndex = 32;
			label65.Text = "6";
			label66.AutoSize = true;
			label66.Location = new System.Drawing.Point(448, 6);
			label66.Name = "label66";
			label66.Size = new System.Drawing.Size(13, 13);
			label66.TabIndex = 31;
			label66.Text = "7";
			label67.AutoSize = true;
			label67.Location = new System.Drawing.Point(415, 6);
			label67.Name = "label67";
			label67.Size = new System.Drawing.Size(13, 13);
			label67.TabIndex = 30;
			label67.Text = "8";
			label68.AutoSize = true;
			label68.Location = new System.Drawing.Point(391, 6);
			label68.Name = "label68";
			label68.Size = new System.Drawing.Size(13, 13);
			label68.TabIndex = 29;
			label68.Text = "9";
			label69.AutoSize = true;
			label69.Location = new System.Drawing.Point(364, 6);
			label69.Name = "label69";
			label69.Size = new System.Drawing.Size(19, 13);
			label69.TabIndex = 28;
			label69.Text = "10";
			label70.AutoSize = true;
			label70.Location = new System.Drawing.Point(340, 6);
			label70.Name = "label70";
			label70.Size = new System.Drawing.Size(19, 13);
			label70.TabIndex = 27;
			label70.Text = "11";
			label71.AutoSize = true;
			label71.Location = new System.Drawing.Point(308, 6);
			label71.Name = "label71";
			label71.Size = new System.Drawing.Size(19, 13);
			label71.TabIndex = 26;
			label71.Text = "12";
			label72.AutoSize = true;
			label72.Location = new System.Drawing.Point(284, 6);
			label72.Name = "label72";
			label72.Size = new System.Drawing.Size(19, 13);
			label72.TabIndex = 25;
			label72.Text = "13";
			label73.AutoSize = true;
			label73.Location = new System.Drawing.Point(260, 6);
			label73.Name = "label73";
			label73.Size = new System.Drawing.Size(19, 13);
			label73.TabIndex = 24;
			label73.Text = "14";
			label74.AutoSize = true;
			label74.Location = new System.Drawing.Point(236, 6);
			label74.Name = "label74";
			label74.Size = new System.Drawing.Size(19, 13);
			label74.TabIndex = 23;
			label74.Text = "15";
			textBox4_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_0.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_0.Location = new System.Drawing.Point(622, 22);
			textBox4_0.Name = "textBox4_0";
			textBox4_0.ReadOnly = true;
			textBox4_0.Size = new System.Drawing.Size(18, 20);
			textBox4_0.TabIndex = 22;
			textBox4_0.Text = "1";
			textBox4_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_0.Click += new System.EventHandler(textBox1_15_Click);
			labelVal4.AutoSize = true;
			labelVal4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelVal4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			labelVal4.Location = new System.Drawing.Point(165, 23);
			labelVal4.Name = "labelVal4";
			labelVal4.Size = new System.Drawing.Size(39, 15);
			labelVal4.TabIndex = 7;
			labelVal4.Text = "3FFF";
			labelAdr4.AutoSize = true;
			labelAdr4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelAdr4.Location = new System.Drawing.Point(88, 23);
			labelAdr4.Name = "labelAdr4";
			labelAdr4.Size = new System.Drawing.Size(71, 15);
			labelAdr4.TabIndex = 1;
			labelAdr4.Text = "20080000";
			textBox4_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_1.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_1.Location = new System.Drawing.Point(598, 22);
			textBox4_1.Name = "textBox4_1";
			textBox4_1.ReadOnly = true;
			textBox4_1.Size = new System.Drawing.Size(18, 20);
			textBox4_1.TabIndex = 21;
			textBox4_1.Text = "1";
			textBox4_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_1.Click += new System.EventHandler(textBox1_15_Click);
			labelName4.AutoSize = true;
			labelName4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelName4.Location = new System.Drawing.Point(-3, 23);
			labelName4.Name = "labelName4";
			labelName4.Size = new System.Drawing.Size(77, 15);
			labelName4.TabIndex = 0;
			labelName4.Text = "DEVCFG1L";
			textBox4_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_2.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_2.Location = new System.Drawing.Point(574, 22);
			textBox4_2.Name = "textBox4_2";
			textBox4_2.ReadOnly = true;
			textBox4_2.Size = new System.Drawing.Size(18, 20);
			textBox4_2.TabIndex = 20;
			textBox4_2.Text = "1";
			textBox4_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_2.Click += new System.EventHandler(textBox1_15_Click);
			textBox4_11.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_11.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_11.Location = new System.Drawing.Point(341, 22);
			textBox4_11.Name = "textBox4_11";
			textBox4_11.ReadOnly = true;
			textBox4_11.Size = new System.Drawing.Size(18, 20);
			textBox4_11.TabIndex = 11;
			textBox4_11.Text = "1";
			textBox4_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_11.Click += new System.EventHandler(textBox1_15_Click);
			textBox4_12.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_12.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_12.Location = new System.Drawing.Point(309, 22);
			textBox4_12.Name = "textBox4_12";
			textBox4_12.ReadOnly = true;
			textBox4_12.Size = new System.Drawing.Size(18, 20);
			textBox4_12.TabIndex = 10;
			textBox4_12.Text = "1";
			textBox4_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_12.Click += new System.EventHandler(textBox1_15_Click);
			textBox4_3.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_3.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_3.Location = new System.Drawing.Point(550, 22);
			textBox4_3.Name = "textBox4_3";
			textBox4_3.ReadOnly = true;
			textBox4_3.Size = new System.Drawing.Size(18, 20);
			textBox4_3.TabIndex = 19;
			textBox4_3.Text = "1";
			textBox4_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_3.Click += new System.EventHandler(textBox1_15_Click);
			textBox4_10.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_10.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_10.Location = new System.Drawing.Point(365, 22);
			textBox4_10.Name = "textBox4_10";
			textBox4_10.ReadOnly = true;
			textBox4_10.Size = new System.Drawing.Size(18, 20);
			textBox4_10.TabIndex = 12;
			textBox4_10.Text = "1";
			textBox4_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_10.Click += new System.EventHandler(textBox1_15_Click);
			textBox4_13.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_13.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_13.Location = new System.Drawing.Point(285, 22);
			textBox4_13.Name = "textBox4_13";
			textBox4_13.ReadOnly = true;
			textBox4_13.Size = new System.Drawing.Size(18, 20);
			textBox4_13.TabIndex = 9;
			textBox4_13.Text = "1";
			textBox4_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_13.Click += new System.EventHandler(textBox1_15_Click);
			textBox4_4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_4.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_4.Location = new System.Drawing.Point(518, 22);
			textBox4_4.Name = "textBox4_4";
			textBox4_4.ReadOnly = true;
			textBox4_4.Size = new System.Drawing.Size(18, 20);
			textBox4_4.TabIndex = 18;
			textBox4_4.Text = "1";
			textBox4_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_4.Click += new System.EventHandler(textBox1_15_Click);
			textBox4_9.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_9.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_9.Location = new System.Drawing.Point(389, 22);
			textBox4_9.Name = "textBox4_9";
			textBox4_9.ReadOnly = true;
			textBox4_9.Size = new System.Drawing.Size(18, 20);
			textBox4_9.TabIndex = 13;
			textBox4_9.Text = "1";
			textBox4_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_9.Click += new System.EventHandler(textBox1_15_Click);
			textBox4_14.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_14.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_14.Location = new System.Drawing.Point(261, 22);
			textBox4_14.Name = "textBox4_14";
			textBox4_14.ReadOnly = true;
			textBox4_14.Size = new System.Drawing.Size(18, 20);
			textBox4_14.TabIndex = 8;
			textBox4_14.Text = "1";
			textBox4_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_14.Click += new System.EventHandler(textBox1_15_Click);
			textBox4_5.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_5.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_5.Location = new System.Drawing.Point(494, 22);
			textBox4_5.Name = "textBox4_5";
			textBox4_5.ReadOnly = true;
			textBox4_5.Size = new System.Drawing.Size(18, 20);
			textBox4_5.TabIndex = 17;
			textBox4_5.Text = "1";
			textBox4_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_5.Click += new System.EventHandler(textBox1_15_Click);
			textBox4_8.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_8.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_8.Location = new System.Drawing.Point(413, 22);
			textBox4_8.Name = "textBox4_8";
			textBox4_8.ReadOnly = true;
			textBox4_8.Size = new System.Drawing.Size(18, 20);
			textBox4_8.TabIndex = 14;
			textBox4_8.Text = "1";
			textBox4_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_8.Click += new System.EventHandler(textBox1_15_Click);
			textBox4_7.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_7.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_7.Location = new System.Drawing.Point(446, 22);
			textBox4_7.Name = "textBox4_7";
			textBox4_7.ReadOnly = true;
			textBox4_7.Size = new System.Drawing.Size(18, 20);
			textBox4_7.TabIndex = 15;
			textBox4_7.Text = "1";
			textBox4_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_7.Click += new System.EventHandler(textBox1_15_Click);
			textBox4_6.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox4_6.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox4_6.Location = new System.Drawing.Point(470, 22);
			textBox4_6.Name = "textBox4_6";
			textBox4_6.ReadOnly = true;
			textBox4_6.Size = new System.Drawing.Size(18, 20);
			textBox4_6.TabIndex = 16;
			textBox4_6.Text = "1";
			textBox4_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox4_6.Click += new System.EventHandler(textBox1_15_Click);
			panel5.Controls.Add(textBox5_15);
			panel5.Controls.Add(label75);
			panel5.Controls.Add(label76);
			panel5.Controls.Add(label77);
			panel5.Controls.Add(label78);
			panel5.Controls.Add(label79);
			panel5.Controls.Add(label80);
			panel5.Controls.Add(label81);
			panel5.Controls.Add(label82);
			panel5.Controls.Add(label83);
			panel5.Controls.Add(label84);
			panel5.Controls.Add(label85);
			panel5.Controls.Add(label86);
			panel5.Controls.Add(label87);
			panel5.Controls.Add(label88);
			panel5.Controls.Add(label89);
			panel5.Controls.Add(label90);
			panel5.Controls.Add(textBox5_0);
			panel5.Controls.Add(labelVal5);
			panel5.Controls.Add(labelAdr5);
			panel5.Controls.Add(textBox5_1);
			panel5.Controls.Add(labelName5);
			panel5.Controls.Add(textBox5_2);
			panel5.Controls.Add(textBox5_11);
			panel5.Controls.Add(textBox5_12);
			panel5.Controls.Add(textBox5_3);
			panel5.Controls.Add(textBox5_10);
			panel5.Controls.Add(textBox5_13);
			panel5.Controls.Add(textBox5_4);
			panel5.Controls.Add(textBox5_9);
			panel5.Controls.Add(textBox5_14);
			panel5.Controls.Add(textBox5_5);
			panel5.Controls.Add(textBox5_8);
			panel5.Controls.Add(textBox5_7);
			panel5.Controls.Add(textBox5_6);
			panel5.Location = new System.Drawing.Point(12, 269);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(648, 46);
			panel5.TabIndex = 17;
			textBox5_15.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_15.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_15.Location = new System.Drawing.Point(237, 22);
			textBox5_15.Name = "textBox5_15";
			textBox5_15.ReadOnly = true;
			textBox5_15.Size = new System.Drawing.Size(18, 20);
			textBox5_15.TabIndex = 11;
			textBox5_15.Text = "1";
			textBox5_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_15.Click += new System.EventHandler(textBox1_15_Click);
			label75.AutoSize = true;
			label75.Location = new System.Drawing.Point(624, 6);
			label75.Name = "label75";
			label75.Size = new System.Drawing.Size(13, 13);
			label75.TabIndex = 38;
			label75.Text = "0";
			label76.AutoSize = true;
			label76.Location = new System.Drawing.Point(600, 6);
			label76.Name = "label76";
			label76.Size = new System.Drawing.Size(13, 13);
			label76.TabIndex = 37;
			label76.Text = "1";
			label77.AutoSize = true;
			label77.Location = new System.Drawing.Point(576, 6);
			label77.Name = "label77";
			label77.Size = new System.Drawing.Size(13, 13);
			label77.TabIndex = 36;
			label77.Text = "2";
			label78.AutoSize = true;
			label78.Location = new System.Drawing.Point(552, 6);
			label78.Name = "label78";
			label78.Size = new System.Drawing.Size(13, 13);
			label78.TabIndex = 35;
			label78.Text = "3";
			label79.AutoSize = true;
			label79.Location = new System.Drawing.Point(520, 6);
			label79.Name = "label79";
			label79.Size = new System.Drawing.Size(13, 13);
			label79.TabIndex = 34;
			label79.Text = "4";
			label80.AutoSize = true;
			label80.Location = new System.Drawing.Point(496, 6);
			label80.Name = "label80";
			label80.Size = new System.Drawing.Size(13, 13);
			label80.TabIndex = 33;
			label80.Text = "5";
			label81.AutoSize = true;
			label81.Location = new System.Drawing.Point(472, 6);
			label81.Name = "label81";
			label81.Size = new System.Drawing.Size(13, 13);
			label81.TabIndex = 32;
			label81.Text = "6";
			label82.AutoSize = true;
			label82.Location = new System.Drawing.Point(448, 6);
			label82.Name = "label82";
			label82.Size = new System.Drawing.Size(13, 13);
			label82.TabIndex = 31;
			label82.Text = "7";
			label83.AutoSize = true;
			label83.Location = new System.Drawing.Point(415, 6);
			label83.Name = "label83";
			label83.Size = new System.Drawing.Size(13, 13);
			label83.TabIndex = 30;
			label83.Text = "8";
			label84.AutoSize = true;
			label84.Location = new System.Drawing.Point(391, 6);
			label84.Name = "label84";
			label84.Size = new System.Drawing.Size(13, 13);
			label84.TabIndex = 29;
			label84.Text = "9";
			label85.AutoSize = true;
			label85.Location = new System.Drawing.Point(364, 6);
			label85.Name = "label85";
			label85.Size = new System.Drawing.Size(19, 13);
			label85.TabIndex = 28;
			label85.Text = "10";
			label86.AutoSize = true;
			label86.Location = new System.Drawing.Point(340, 6);
			label86.Name = "label86";
			label86.Size = new System.Drawing.Size(19, 13);
			label86.TabIndex = 27;
			label86.Text = "11";
			label87.AutoSize = true;
			label87.Location = new System.Drawing.Point(308, 6);
			label87.Name = "label87";
			label87.Size = new System.Drawing.Size(19, 13);
			label87.TabIndex = 26;
			label87.Text = "12";
			label88.AutoSize = true;
			label88.Location = new System.Drawing.Point(284, 6);
			label88.Name = "label88";
			label88.Size = new System.Drawing.Size(19, 13);
			label88.TabIndex = 25;
			label88.Text = "13";
			label89.AutoSize = true;
			label89.Location = new System.Drawing.Point(260, 6);
			label89.Name = "label89";
			label89.Size = new System.Drawing.Size(19, 13);
			label89.TabIndex = 24;
			label89.Text = "14";
			label90.AutoSize = true;
			label90.Location = new System.Drawing.Point(236, 6);
			label90.Name = "label90";
			label90.Size = new System.Drawing.Size(19, 13);
			label90.TabIndex = 23;
			label90.Text = "15";
			textBox5_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_0.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_0.Location = new System.Drawing.Point(622, 22);
			textBox5_0.Name = "textBox5_0";
			textBox5_0.ReadOnly = true;
			textBox5_0.Size = new System.Drawing.Size(18, 20);
			textBox5_0.TabIndex = 22;
			textBox5_0.Text = "1";
			textBox5_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_0.Click += new System.EventHandler(textBox1_15_Click);
			labelVal5.AutoSize = true;
			labelVal5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelVal5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			labelVal5.Location = new System.Drawing.Point(165, 23);
			labelVal5.Name = "labelVal5";
			labelVal5.Size = new System.Drawing.Size(39, 15);
			labelVal5.TabIndex = 7;
			labelVal5.Text = "3FFF";
			labelAdr5.AutoSize = true;
			labelAdr5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelAdr5.Location = new System.Drawing.Point(88, 23);
			labelAdr5.Name = "labelAdr5";
			labelAdr5.Size = new System.Drawing.Size(71, 15);
			labelAdr5.TabIndex = 1;
			labelAdr5.Text = "20080000";
			textBox5_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_1.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_1.Location = new System.Drawing.Point(598, 22);
			textBox5_1.Name = "textBox5_1";
			textBox5_1.ReadOnly = true;
			textBox5_1.Size = new System.Drawing.Size(18, 20);
			textBox5_1.TabIndex = 21;
			textBox5_1.Text = "1";
			textBox5_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_1.Click += new System.EventHandler(textBox1_15_Click);
			labelName5.AutoSize = true;
			labelName5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelName5.Location = new System.Drawing.Point(-3, 23);
			labelName5.Name = "labelName5";
			labelName5.Size = new System.Drawing.Size(33, 15);
			labelName5.TabIndex = 0;
			labelName5.Text = "FSS";
			textBox5_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_2.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_2.Location = new System.Drawing.Point(574, 22);
			textBox5_2.Name = "textBox5_2";
			textBox5_2.ReadOnly = true;
			textBox5_2.Size = new System.Drawing.Size(18, 20);
			textBox5_2.TabIndex = 20;
			textBox5_2.Text = "1";
			textBox5_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_2.Click += new System.EventHandler(textBox1_15_Click);
			textBox5_11.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_11.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_11.Location = new System.Drawing.Point(341, 22);
			textBox5_11.Name = "textBox5_11";
			textBox5_11.ReadOnly = true;
			textBox5_11.Size = new System.Drawing.Size(18, 20);
			textBox5_11.TabIndex = 11;
			textBox5_11.Text = "1";
			textBox5_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_11.Click += new System.EventHandler(textBox1_15_Click);
			textBox5_12.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_12.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_12.Location = new System.Drawing.Point(309, 22);
			textBox5_12.Name = "textBox5_12";
			textBox5_12.ReadOnly = true;
			textBox5_12.Size = new System.Drawing.Size(18, 20);
			textBox5_12.TabIndex = 10;
			textBox5_12.Text = "1";
			textBox5_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_12.Click += new System.EventHandler(textBox1_15_Click);
			textBox5_3.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_3.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_3.Location = new System.Drawing.Point(550, 22);
			textBox5_3.Name = "textBox5_3";
			textBox5_3.ReadOnly = true;
			textBox5_3.Size = new System.Drawing.Size(18, 20);
			textBox5_3.TabIndex = 19;
			textBox5_3.Text = "1";
			textBox5_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_3.Click += new System.EventHandler(textBox1_15_Click);
			textBox5_10.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_10.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_10.Location = new System.Drawing.Point(365, 22);
			textBox5_10.Name = "textBox5_10";
			textBox5_10.ReadOnly = true;
			textBox5_10.Size = new System.Drawing.Size(18, 20);
			textBox5_10.TabIndex = 12;
			textBox5_10.Text = "1";
			textBox5_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_10.Click += new System.EventHandler(textBox1_15_Click);
			textBox5_13.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_13.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_13.Location = new System.Drawing.Point(285, 22);
			textBox5_13.Name = "textBox5_13";
			textBox5_13.ReadOnly = true;
			textBox5_13.Size = new System.Drawing.Size(18, 20);
			textBox5_13.TabIndex = 9;
			textBox5_13.Text = "1";
			textBox5_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_13.Click += new System.EventHandler(textBox1_15_Click);
			textBox5_4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_4.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_4.Location = new System.Drawing.Point(518, 22);
			textBox5_4.Name = "textBox5_4";
			textBox5_4.ReadOnly = true;
			textBox5_4.Size = new System.Drawing.Size(18, 20);
			textBox5_4.TabIndex = 18;
			textBox5_4.Text = "1";
			textBox5_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_4.Click += new System.EventHandler(textBox1_15_Click);
			textBox5_9.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_9.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_9.Location = new System.Drawing.Point(389, 22);
			textBox5_9.Name = "textBox5_9";
			textBox5_9.ReadOnly = true;
			textBox5_9.Size = new System.Drawing.Size(18, 20);
			textBox5_9.TabIndex = 13;
			textBox5_9.Text = "1";
			textBox5_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_9.Click += new System.EventHandler(textBox1_15_Click);
			textBox5_14.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_14.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_14.Location = new System.Drawing.Point(261, 22);
			textBox5_14.Name = "textBox5_14";
			textBox5_14.ReadOnly = true;
			textBox5_14.Size = new System.Drawing.Size(18, 20);
			textBox5_14.TabIndex = 8;
			textBox5_14.Text = "1";
			textBox5_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_14.Click += new System.EventHandler(textBox1_15_Click);
			textBox5_5.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_5.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_5.Location = new System.Drawing.Point(494, 22);
			textBox5_5.Name = "textBox5_5";
			textBox5_5.ReadOnly = true;
			textBox5_5.Size = new System.Drawing.Size(18, 20);
			textBox5_5.TabIndex = 17;
			textBox5_5.Text = "1";
			textBox5_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_5.Click += new System.EventHandler(textBox1_15_Click);
			textBox5_8.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_8.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_8.Location = new System.Drawing.Point(413, 22);
			textBox5_8.Name = "textBox5_8";
			textBox5_8.ReadOnly = true;
			textBox5_8.Size = new System.Drawing.Size(18, 20);
			textBox5_8.TabIndex = 14;
			textBox5_8.Text = "1";
			textBox5_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_8.Click += new System.EventHandler(textBox1_15_Click);
			textBox5_7.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_7.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_7.ForeColor = System.Drawing.SystemColors.WindowText;
			textBox5_7.Location = new System.Drawing.Point(446, 22);
			textBox5_7.Name = "textBox5_7";
			textBox5_7.ReadOnly = true;
			textBox5_7.Size = new System.Drawing.Size(18, 20);
			textBox5_7.TabIndex = 15;
			textBox5_7.Text = "1";
			textBox5_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_7.Click += new System.EventHandler(textBox1_15_Click);
			textBox5_6.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox5_6.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox5_6.Location = new System.Drawing.Point(470, 22);
			textBox5_6.Name = "textBox5_6";
			textBox5_6.ReadOnly = true;
			textBox5_6.Size = new System.Drawing.Size(18, 20);
			textBox5_6.TabIndex = 16;
			textBox5_6.Text = "1";
			textBox5_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox5_6.Click += new System.EventHandler(textBox1_15_Click);
			panel6.Controls.Add(textBox6_15);
			panel6.Controls.Add(label91);
			panel6.Controls.Add(label92);
			panel6.Controls.Add(label93);
			panel6.Controls.Add(label94);
			panel6.Controls.Add(label95);
			panel6.Controls.Add(label96);
			panel6.Controls.Add(label97);
			panel6.Controls.Add(label98);
			panel6.Controls.Add(label99);
			panel6.Controls.Add(label100);
			panel6.Controls.Add(label101);
			panel6.Controls.Add(label102);
			panel6.Controls.Add(label103);
			panel6.Controls.Add(label104);
			panel6.Controls.Add(label105);
			panel6.Controls.Add(label106);
			panel6.Controls.Add(textBox6_0);
			panel6.Controls.Add(labelVal6);
			panel6.Controls.Add(labelAdr6);
			panel6.Controls.Add(textBox6_1);
			panel6.Controls.Add(labelName6);
			panel6.Controls.Add(textBox6_2);
			panel6.Controls.Add(textBox6_11);
			panel6.Controls.Add(textBox6_12);
			panel6.Controls.Add(textBox6_3);
			panel6.Controls.Add(textBox6_10);
			panel6.Controls.Add(textBox6_13);
			panel6.Controls.Add(textBox6_4);
			panel6.Controls.Add(textBox6_9);
			panel6.Controls.Add(textBox6_14);
			panel6.Controls.Add(textBox6_5);
			panel6.Controls.Add(textBox6_8);
			panel6.Controls.Add(textBox6_7);
			panel6.Controls.Add(textBox6_6);
			panel6.Location = new System.Drawing.Point(12, 317);
			panel6.Name = "panel6";
			panel6.Size = new System.Drawing.Size(648, 46);
			panel6.TabIndex = 18;
			textBox6_15.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_15.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_15.Location = new System.Drawing.Point(237, 22);
			textBox6_15.Name = "textBox6_15";
			textBox6_15.ReadOnly = true;
			textBox6_15.Size = new System.Drawing.Size(18, 20);
			textBox6_15.TabIndex = 11;
			textBox6_15.Text = "1";
			textBox6_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_15.Click += new System.EventHandler(textBox1_15_Click);
			label91.AutoSize = true;
			label91.Location = new System.Drawing.Point(624, 6);
			label91.Name = "label91";
			label91.Size = new System.Drawing.Size(13, 13);
			label91.TabIndex = 38;
			label91.Text = "0";
			label92.AutoSize = true;
			label92.Location = new System.Drawing.Point(600, 6);
			label92.Name = "label92";
			label92.Size = new System.Drawing.Size(13, 13);
			label92.TabIndex = 37;
			label92.Text = "1";
			label93.AutoSize = true;
			label93.Location = new System.Drawing.Point(576, 6);
			label93.Name = "label93";
			label93.Size = new System.Drawing.Size(13, 13);
			label93.TabIndex = 36;
			label93.Text = "2";
			label94.AutoSize = true;
			label94.Location = new System.Drawing.Point(552, 6);
			label94.Name = "label94";
			label94.Size = new System.Drawing.Size(13, 13);
			label94.TabIndex = 35;
			label94.Text = "3";
			label95.AutoSize = true;
			label95.Location = new System.Drawing.Point(520, 6);
			label95.Name = "label95";
			label95.Size = new System.Drawing.Size(13, 13);
			label95.TabIndex = 34;
			label95.Text = "4";
			label96.AutoSize = true;
			label96.Location = new System.Drawing.Point(496, 6);
			label96.Name = "label96";
			label96.Size = new System.Drawing.Size(13, 13);
			label96.TabIndex = 33;
			label96.Text = "5";
			label97.AutoSize = true;
			label97.Location = new System.Drawing.Point(472, 6);
			label97.Name = "label97";
			label97.Size = new System.Drawing.Size(13, 13);
			label97.TabIndex = 32;
			label97.Text = "6";
			label98.AutoSize = true;
			label98.Location = new System.Drawing.Point(448, 6);
			label98.Name = "label98";
			label98.Size = new System.Drawing.Size(13, 13);
			label98.TabIndex = 31;
			label98.Text = "7";
			label99.AutoSize = true;
			label99.Location = new System.Drawing.Point(415, 6);
			label99.Name = "label99";
			label99.Size = new System.Drawing.Size(13, 13);
			label99.TabIndex = 30;
			label99.Text = "8";
			label100.AutoSize = true;
			label100.Location = new System.Drawing.Point(391, 6);
			label100.Name = "label100";
			label100.Size = new System.Drawing.Size(13, 13);
			label100.TabIndex = 29;
			label100.Text = "9";
			label101.AutoSize = true;
			label101.Location = new System.Drawing.Point(364, 6);
			label101.Name = "label101";
			label101.Size = new System.Drawing.Size(19, 13);
			label101.TabIndex = 28;
			label101.Text = "10";
			label102.AutoSize = true;
			label102.Location = new System.Drawing.Point(340, 6);
			label102.Name = "label102";
			label102.Size = new System.Drawing.Size(19, 13);
			label102.TabIndex = 27;
			label102.Text = "11";
			label103.AutoSize = true;
			label103.Location = new System.Drawing.Point(308, 6);
			label103.Name = "label103";
			label103.Size = new System.Drawing.Size(19, 13);
			label103.TabIndex = 26;
			label103.Text = "12";
			label104.AutoSize = true;
			label104.Location = new System.Drawing.Point(284, 6);
			label104.Name = "label104";
			label104.Size = new System.Drawing.Size(19, 13);
			label104.TabIndex = 25;
			label104.Text = "13";
			label105.AutoSize = true;
			label105.Location = new System.Drawing.Point(260, 6);
			label105.Name = "label105";
			label105.Size = new System.Drawing.Size(19, 13);
			label105.TabIndex = 24;
			label105.Text = "14";
			label106.AutoSize = true;
			label106.Location = new System.Drawing.Point(236, 6);
			label106.Name = "label106";
			label106.Size = new System.Drawing.Size(19, 13);
			label106.TabIndex = 23;
			label106.Text = "15";
			textBox6_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_0.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_0.Location = new System.Drawing.Point(622, 22);
			textBox6_0.Name = "textBox6_0";
			textBox6_0.ReadOnly = true;
			textBox6_0.Size = new System.Drawing.Size(18, 20);
			textBox6_0.TabIndex = 22;
			textBox6_0.Text = "1";
			textBox6_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_0.Click += new System.EventHandler(textBox1_15_Click);
			labelVal6.AutoSize = true;
			labelVal6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelVal6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			labelVal6.Location = new System.Drawing.Point(165, 23);
			labelVal6.Name = "labelVal6";
			labelVal6.Size = new System.Drawing.Size(39, 15);
			labelVal6.TabIndex = 7;
			labelVal6.Text = "3FFF";
			labelAdr6.AutoSize = true;
			labelAdr6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelAdr6.Location = new System.Drawing.Point(88, 23);
			labelAdr6.Name = "labelAdr6";
			labelAdr6.Size = new System.Drawing.Size(71, 15);
			labelAdr6.TabIndex = 1;
			labelAdr6.Text = "20080000";
			textBox6_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_1.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_1.Location = new System.Drawing.Point(598, 22);
			textBox6_1.Name = "textBox6_1";
			textBox6_1.ReadOnly = true;
			textBox6_1.Size = new System.Drawing.Size(18, 20);
			textBox6_1.TabIndex = 21;
			textBox6_1.Text = "1";
			textBox6_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_1.Click += new System.EventHandler(textBox1_15_Click);
			labelName6.AutoSize = true;
			labelName6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelName6.Location = new System.Drawing.Point(-3, 23);
			labelName6.Name = "labelName6";
			labelName6.Size = new System.Drawing.Size(66, 15);
			labelName6.TabIndex = 0;
			labelName6.Text = "CONFIG6";
			textBox6_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_2.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_2.Location = new System.Drawing.Point(574, 22);
			textBox6_2.Name = "textBox6_2";
			textBox6_2.ReadOnly = true;
			textBox6_2.Size = new System.Drawing.Size(18, 20);
			textBox6_2.TabIndex = 20;
			textBox6_2.Text = "1";
			textBox6_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_2.Click += new System.EventHandler(textBox1_15_Click);
			textBox6_11.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_11.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_11.Location = new System.Drawing.Point(341, 22);
			textBox6_11.Name = "textBox6_11";
			textBox6_11.ReadOnly = true;
			textBox6_11.Size = new System.Drawing.Size(18, 20);
			textBox6_11.TabIndex = 11;
			textBox6_11.Text = "1";
			textBox6_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_11.Click += new System.EventHandler(textBox1_15_Click);
			textBox6_12.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_12.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_12.Location = new System.Drawing.Point(309, 22);
			textBox6_12.Name = "textBox6_12";
			textBox6_12.ReadOnly = true;
			textBox6_12.Size = new System.Drawing.Size(18, 20);
			textBox6_12.TabIndex = 10;
			textBox6_12.Text = "1";
			textBox6_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_12.Click += new System.EventHandler(textBox1_15_Click);
			textBox6_3.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_3.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_3.Location = new System.Drawing.Point(550, 22);
			textBox6_3.Name = "textBox6_3";
			textBox6_3.ReadOnly = true;
			textBox6_3.Size = new System.Drawing.Size(18, 20);
			textBox6_3.TabIndex = 19;
			textBox6_3.Text = "1";
			textBox6_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_3.Click += new System.EventHandler(textBox1_15_Click);
			textBox6_10.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_10.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_10.Location = new System.Drawing.Point(365, 22);
			textBox6_10.Name = "textBox6_10";
			textBox6_10.ReadOnly = true;
			textBox6_10.Size = new System.Drawing.Size(18, 20);
			textBox6_10.TabIndex = 12;
			textBox6_10.Text = "1";
			textBox6_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_10.Click += new System.EventHandler(textBox1_15_Click);
			textBox6_13.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_13.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_13.Location = new System.Drawing.Point(285, 22);
			textBox6_13.Name = "textBox6_13";
			textBox6_13.ReadOnly = true;
			textBox6_13.Size = new System.Drawing.Size(18, 20);
			textBox6_13.TabIndex = 9;
			textBox6_13.Text = "1";
			textBox6_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_13.Click += new System.EventHandler(textBox1_15_Click);
			textBox6_4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_4.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_4.Location = new System.Drawing.Point(518, 22);
			textBox6_4.Name = "textBox6_4";
			textBox6_4.ReadOnly = true;
			textBox6_4.Size = new System.Drawing.Size(18, 20);
			textBox6_4.TabIndex = 18;
			textBox6_4.Text = "1";
			textBox6_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_4.Click += new System.EventHandler(textBox1_15_Click);
			textBox6_9.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_9.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_9.Location = new System.Drawing.Point(389, 22);
			textBox6_9.Name = "textBox6_9";
			textBox6_9.ReadOnly = true;
			textBox6_9.Size = new System.Drawing.Size(18, 20);
			textBox6_9.TabIndex = 13;
			textBox6_9.Text = "1";
			textBox6_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_9.Click += new System.EventHandler(textBox1_15_Click);
			textBox6_14.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_14.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_14.Location = new System.Drawing.Point(261, 22);
			textBox6_14.Name = "textBox6_14";
			textBox6_14.ReadOnly = true;
			textBox6_14.Size = new System.Drawing.Size(18, 20);
			textBox6_14.TabIndex = 8;
			textBox6_14.Text = "1";
			textBox6_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_14.Click += new System.EventHandler(textBox1_15_Click);
			textBox6_5.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_5.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_5.Location = new System.Drawing.Point(494, 22);
			textBox6_5.Name = "textBox6_5";
			textBox6_5.ReadOnly = true;
			textBox6_5.Size = new System.Drawing.Size(18, 20);
			textBox6_5.TabIndex = 17;
			textBox6_5.Text = "1";
			textBox6_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_5.Click += new System.EventHandler(textBox1_15_Click);
			textBox6_8.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_8.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_8.Location = new System.Drawing.Point(413, 22);
			textBox6_8.Name = "textBox6_8";
			textBox6_8.ReadOnly = true;
			textBox6_8.Size = new System.Drawing.Size(18, 20);
			textBox6_8.TabIndex = 14;
			textBox6_8.Text = "1";
			textBox6_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_8.Click += new System.EventHandler(textBox1_15_Click);
			textBox6_7.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_7.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_7.Location = new System.Drawing.Point(446, 22);
			textBox6_7.Name = "textBox6_7";
			textBox6_7.ReadOnly = true;
			textBox6_7.Size = new System.Drawing.Size(18, 20);
			textBox6_7.TabIndex = 15;
			textBox6_7.Text = "1";
			textBox6_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_7.Click += new System.EventHandler(textBox1_15_Click);
			textBox6_6.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox6_6.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox6_6.Location = new System.Drawing.Point(470, 22);
			textBox6_6.Name = "textBox6_6";
			textBox6_6.ReadOnly = true;
			textBox6_6.Size = new System.Drawing.Size(18, 20);
			textBox6_6.TabIndex = 16;
			textBox6_6.Text = "1";
			textBox6_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox6_6.Click += new System.EventHandler(textBox1_15_Click);
			panel7.Controls.Add(textBox7_15);
			panel7.Controls.Add(label107);
			panel7.Controls.Add(label108);
			panel7.Controls.Add(label109);
			panel7.Controls.Add(label110);
			panel7.Controls.Add(label111);
			panel7.Controls.Add(label112);
			panel7.Controls.Add(label113);
			panel7.Controls.Add(label114);
			panel7.Controls.Add(label115);
			panel7.Controls.Add(label116);
			panel7.Controls.Add(label117);
			panel7.Controls.Add(label118);
			panel7.Controls.Add(label119);
			panel7.Controls.Add(label120);
			panel7.Controls.Add(label121);
			panel7.Controls.Add(label122);
			panel7.Controls.Add(textBox7_0);
			panel7.Controls.Add(labelVal7);
			panel7.Controls.Add(labelAdr7);
			panel7.Controls.Add(textBox7_1);
			panel7.Controls.Add(labelName7);
			panel7.Controls.Add(textBox7_2);
			panel7.Controls.Add(textBox7_11);
			panel7.Controls.Add(textBox7_12);
			panel7.Controls.Add(textBox7_3);
			panel7.Controls.Add(textBox7_10);
			panel7.Controls.Add(textBox7_13);
			panel7.Controls.Add(textBox7_4);
			panel7.Controls.Add(textBox7_9);
			panel7.Controls.Add(textBox7_14);
			panel7.Controls.Add(textBox7_5);
			panel7.Controls.Add(textBox7_8);
			panel7.Controls.Add(textBox7_7);
			panel7.Controls.Add(textBox7_6);
			panel7.Location = new System.Drawing.Point(12, 365);
			panel7.Name = "panel7";
			panel7.Size = new System.Drawing.Size(648, 46);
			panel7.TabIndex = 19;
			textBox7_15.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_15.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_15.Location = new System.Drawing.Point(237, 22);
			textBox7_15.Name = "textBox7_15";
			textBox7_15.ReadOnly = true;
			textBox7_15.Size = new System.Drawing.Size(18, 20);
			textBox7_15.TabIndex = 11;
			textBox7_15.Text = "1";
			textBox7_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_15.Click += new System.EventHandler(textBox1_15_Click);
			label107.AutoSize = true;
			label107.Location = new System.Drawing.Point(624, 6);
			label107.Name = "label107";
			label107.Size = new System.Drawing.Size(13, 13);
			label107.TabIndex = 38;
			label107.Text = "0";
			label108.AutoSize = true;
			label108.Location = new System.Drawing.Point(600, 6);
			label108.Name = "label108";
			label108.Size = new System.Drawing.Size(13, 13);
			label108.TabIndex = 37;
			label108.Text = "1";
			label109.AutoSize = true;
			label109.Location = new System.Drawing.Point(576, 6);
			label109.Name = "label109";
			label109.Size = new System.Drawing.Size(13, 13);
			label109.TabIndex = 36;
			label109.Text = "2";
			label110.AutoSize = true;
			label110.Location = new System.Drawing.Point(552, 6);
			label110.Name = "label110";
			label110.Size = new System.Drawing.Size(13, 13);
			label110.TabIndex = 35;
			label110.Text = "3";
			label111.AutoSize = true;
			label111.Location = new System.Drawing.Point(520, 6);
			label111.Name = "label111";
			label111.Size = new System.Drawing.Size(13, 13);
			label111.TabIndex = 34;
			label111.Text = "4";
			label112.AutoSize = true;
			label112.Location = new System.Drawing.Point(496, 6);
			label112.Name = "label112";
			label112.Size = new System.Drawing.Size(13, 13);
			label112.TabIndex = 33;
			label112.Text = "5";
			label113.AutoSize = true;
			label113.Location = new System.Drawing.Point(472, 6);
			label113.Name = "label113";
			label113.Size = new System.Drawing.Size(13, 13);
			label113.TabIndex = 32;
			label113.Text = "6";
			label114.AutoSize = true;
			label114.Location = new System.Drawing.Point(448, 6);
			label114.Name = "label114";
			label114.Size = new System.Drawing.Size(13, 13);
			label114.TabIndex = 31;
			label114.Text = "7";
			label115.AutoSize = true;
			label115.Location = new System.Drawing.Point(415, 6);
			label115.Name = "label115";
			label115.Size = new System.Drawing.Size(13, 13);
			label115.TabIndex = 30;
			label115.Text = "8";
			label116.AutoSize = true;
			label116.Location = new System.Drawing.Point(391, 6);
			label116.Name = "label116";
			label116.Size = new System.Drawing.Size(13, 13);
			label116.TabIndex = 29;
			label116.Text = "9";
			label117.AutoSize = true;
			label117.Location = new System.Drawing.Point(364, 6);
			label117.Name = "label117";
			label117.Size = new System.Drawing.Size(19, 13);
			label117.TabIndex = 28;
			label117.Text = "10";
			label118.AutoSize = true;
			label118.Location = new System.Drawing.Point(340, 6);
			label118.Name = "label118";
			label118.Size = new System.Drawing.Size(19, 13);
			label118.TabIndex = 27;
			label118.Text = "11";
			label119.AutoSize = true;
			label119.Location = new System.Drawing.Point(308, 6);
			label119.Name = "label119";
			label119.Size = new System.Drawing.Size(19, 13);
			label119.TabIndex = 26;
			label119.Text = "12";
			label120.AutoSize = true;
			label120.Location = new System.Drawing.Point(284, 6);
			label120.Name = "label120";
			label120.Size = new System.Drawing.Size(19, 13);
			label120.TabIndex = 25;
			label120.Text = "13";
			label121.AutoSize = true;
			label121.Location = new System.Drawing.Point(260, 6);
			label121.Name = "label121";
			label121.Size = new System.Drawing.Size(19, 13);
			label121.TabIndex = 24;
			label121.Text = "14";
			label122.AutoSize = true;
			label122.Location = new System.Drawing.Point(236, 6);
			label122.Name = "label122";
			label122.Size = new System.Drawing.Size(19, 13);
			label122.TabIndex = 23;
			label122.Text = "15";
			textBox7_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_0.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_0.Location = new System.Drawing.Point(622, 22);
			textBox7_0.Name = "textBox7_0";
			textBox7_0.ReadOnly = true;
			textBox7_0.Size = new System.Drawing.Size(18, 20);
			textBox7_0.TabIndex = 22;
			textBox7_0.Text = "1";
			textBox7_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_0.Click += new System.EventHandler(textBox1_15_Click);
			labelVal7.AutoSize = true;
			labelVal7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelVal7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			labelVal7.Location = new System.Drawing.Point(165, 23);
			labelVal7.Name = "labelVal7";
			labelVal7.Size = new System.Drawing.Size(39, 15);
			labelVal7.TabIndex = 7;
			labelVal7.Text = "3FFF";
			labelAdr7.AutoSize = true;
			labelAdr7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelAdr7.Location = new System.Drawing.Point(88, 23);
			labelAdr7.Name = "labelAdr7";
			labelAdr7.Size = new System.Drawing.Size(71, 15);
			labelAdr7.TabIndex = 1;
			labelAdr7.Text = "20080000";
			textBox7_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_1.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_1.Location = new System.Drawing.Point(598, 22);
			textBox7_1.Name = "textBox7_1";
			textBox7_1.ReadOnly = true;
			textBox7_1.Size = new System.Drawing.Size(18, 20);
			textBox7_1.TabIndex = 21;
			textBox7_1.Text = "1";
			textBox7_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_1.Click += new System.EventHandler(textBox1_15_Click);
			labelName7.AutoSize = true;
			labelName7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelName7.Location = new System.Drawing.Point(-3, 23);
			labelName7.Name = "labelName7";
			labelName7.Size = new System.Drawing.Size(66, 15);
			labelName7.TabIndex = 0;
			labelName7.Text = "CONFIG7";
			textBox7_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_2.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_2.Location = new System.Drawing.Point(574, 22);
			textBox7_2.Name = "textBox7_2";
			textBox7_2.ReadOnly = true;
			textBox7_2.Size = new System.Drawing.Size(18, 20);
			textBox7_2.TabIndex = 20;
			textBox7_2.Text = "1";
			textBox7_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_2.Click += new System.EventHandler(textBox1_15_Click);
			textBox7_11.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_11.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_11.Location = new System.Drawing.Point(341, 22);
			textBox7_11.Name = "textBox7_11";
			textBox7_11.ReadOnly = true;
			textBox7_11.Size = new System.Drawing.Size(18, 20);
			textBox7_11.TabIndex = 11;
			textBox7_11.Text = "1";
			textBox7_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_11.Click += new System.EventHandler(textBox1_15_Click);
			textBox7_12.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_12.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_12.Location = new System.Drawing.Point(309, 22);
			textBox7_12.Name = "textBox7_12";
			textBox7_12.ReadOnly = true;
			textBox7_12.Size = new System.Drawing.Size(18, 20);
			textBox7_12.TabIndex = 10;
			textBox7_12.Text = "1";
			textBox7_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_12.Click += new System.EventHandler(textBox1_15_Click);
			textBox7_3.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_3.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_3.Location = new System.Drawing.Point(550, 22);
			textBox7_3.Name = "textBox7_3";
			textBox7_3.ReadOnly = true;
			textBox7_3.Size = new System.Drawing.Size(18, 20);
			textBox7_3.TabIndex = 19;
			textBox7_3.Text = "1";
			textBox7_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_3.Click += new System.EventHandler(textBox1_15_Click);
			textBox7_10.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_10.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_10.Location = new System.Drawing.Point(365, 22);
			textBox7_10.Name = "textBox7_10";
			textBox7_10.ReadOnly = true;
			textBox7_10.Size = new System.Drawing.Size(18, 20);
			textBox7_10.TabIndex = 12;
			textBox7_10.Text = "1";
			textBox7_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_10.Click += new System.EventHandler(textBox1_15_Click);
			textBox7_13.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_13.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_13.Location = new System.Drawing.Point(285, 22);
			textBox7_13.Name = "textBox7_13";
			textBox7_13.ReadOnly = true;
			textBox7_13.Size = new System.Drawing.Size(18, 20);
			textBox7_13.TabIndex = 9;
			textBox7_13.Text = "1";
			textBox7_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_13.Click += new System.EventHandler(textBox1_15_Click);
			textBox7_4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_4.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_4.Location = new System.Drawing.Point(518, 22);
			textBox7_4.Name = "textBox7_4";
			textBox7_4.ReadOnly = true;
			textBox7_4.Size = new System.Drawing.Size(18, 20);
			textBox7_4.TabIndex = 18;
			textBox7_4.Text = "1";
			textBox7_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_4.Click += new System.EventHandler(textBox1_15_Click);
			textBox7_9.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_9.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_9.Location = new System.Drawing.Point(389, 22);
			textBox7_9.Name = "textBox7_9";
			textBox7_9.ReadOnly = true;
			textBox7_9.Size = new System.Drawing.Size(18, 20);
			textBox7_9.TabIndex = 13;
			textBox7_9.Text = "1";
			textBox7_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_9.Click += new System.EventHandler(textBox1_15_Click);
			textBox7_14.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_14.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_14.Location = new System.Drawing.Point(261, 22);
			textBox7_14.Name = "textBox7_14";
			textBox7_14.ReadOnly = true;
			textBox7_14.Size = new System.Drawing.Size(18, 20);
			textBox7_14.TabIndex = 8;
			textBox7_14.Text = "1";
			textBox7_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_14.Click += new System.EventHandler(textBox1_15_Click);
			textBox7_5.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_5.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_5.Location = new System.Drawing.Point(494, 22);
			textBox7_5.Name = "textBox7_5";
			textBox7_5.ReadOnly = true;
			textBox7_5.Size = new System.Drawing.Size(18, 20);
			textBox7_5.TabIndex = 17;
			textBox7_5.Text = "1";
			textBox7_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_5.Click += new System.EventHandler(textBox1_15_Click);
			textBox7_8.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_8.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_8.Location = new System.Drawing.Point(413, 22);
			textBox7_8.Name = "textBox7_8";
			textBox7_8.ReadOnly = true;
			textBox7_8.Size = new System.Drawing.Size(18, 20);
			textBox7_8.TabIndex = 14;
			textBox7_8.Text = "1";
			textBox7_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_8.Click += new System.EventHandler(textBox1_15_Click);
			textBox7_7.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_7.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_7.Location = new System.Drawing.Point(446, 22);
			textBox7_7.Name = "textBox7_7";
			textBox7_7.ReadOnly = true;
			textBox7_7.Size = new System.Drawing.Size(18, 20);
			textBox7_7.TabIndex = 15;
			textBox7_7.Text = "1";
			textBox7_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_7.Click += new System.EventHandler(textBox1_15_Click);
			textBox7_6.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox7_6.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox7_6.Location = new System.Drawing.Point(470, 22);
			textBox7_6.Name = "textBox7_6";
			textBox7_6.ReadOnly = true;
			textBox7_6.Size = new System.Drawing.Size(18, 20);
			textBox7_6.TabIndex = 16;
			textBox7_6.Text = "1";
			textBox7_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox7_6.Click += new System.EventHandler(textBox1_15_Click);
			panel8.Controls.Add(textBox8_15);
			panel8.Controls.Add(label123);
			panel8.Controls.Add(label124);
			panel8.Controls.Add(label125);
			panel8.Controls.Add(label126);
			panel8.Controls.Add(label127);
			panel8.Controls.Add(label128);
			panel8.Controls.Add(label129);
			panel8.Controls.Add(label130);
			panel8.Controls.Add(label131);
			panel8.Controls.Add(label132);
			panel8.Controls.Add(label133);
			panel8.Controls.Add(label134);
			panel8.Controls.Add(label135);
			panel8.Controls.Add(label136);
			panel8.Controls.Add(label137);
			panel8.Controls.Add(label138);
			panel8.Controls.Add(textBox8_0);
			panel8.Controls.Add(labelVal8);
			panel8.Controls.Add(labelAdr8);
			panel8.Controls.Add(textBox8_1);
			panel8.Controls.Add(labelName8);
			panel8.Controls.Add(textBox8_2);
			panel8.Controls.Add(textBox8_11);
			panel8.Controls.Add(textBox8_12);
			panel8.Controls.Add(textBox8_3);
			panel8.Controls.Add(textBox8_10);
			panel8.Controls.Add(textBox8_13);
			panel8.Controls.Add(textBox8_4);
			panel8.Controls.Add(textBox8_9);
			panel8.Controls.Add(textBox8_14);
			panel8.Controls.Add(textBox8_5);
			panel8.Controls.Add(textBox8_8);
			panel8.Controls.Add(textBox8_7);
			panel8.Controls.Add(textBox8_6);
			panel8.Location = new System.Drawing.Point(12, 413);
			panel8.Name = "panel8";
			panel8.Size = new System.Drawing.Size(648, 46);
			panel8.TabIndex = 20;
			textBox8_15.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_15.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_15.Location = new System.Drawing.Point(237, 22);
			textBox8_15.Name = "textBox8_15";
			textBox8_15.ReadOnly = true;
			textBox8_15.Size = new System.Drawing.Size(18, 20);
			textBox8_15.TabIndex = 11;
			textBox8_15.Text = "1";
			textBox8_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_15.Click += new System.EventHandler(textBox1_15_Click);
			label123.AutoSize = true;
			label123.Location = new System.Drawing.Point(624, 6);
			label123.Name = "label123";
			label123.Size = new System.Drawing.Size(13, 13);
			label123.TabIndex = 38;
			label123.Text = "0";
			label124.AutoSize = true;
			label124.Location = new System.Drawing.Point(600, 6);
			label124.Name = "label124";
			label124.Size = new System.Drawing.Size(13, 13);
			label124.TabIndex = 37;
			label124.Text = "1";
			label125.AutoSize = true;
			label125.Location = new System.Drawing.Point(576, 6);
			label125.Name = "label125";
			label125.Size = new System.Drawing.Size(13, 13);
			label125.TabIndex = 36;
			label125.Text = "2";
			label126.AutoSize = true;
			label126.Location = new System.Drawing.Point(552, 6);
			label126.Name = "label126";
			label126.Size = new System.Drawing.Size(13, 13);
			label126.TabIndex = 35;
			label126.Text = "3";
			label127.AutoSize = true;
			label127.Location = new System.Drawing.Point(520, 6);
			label127.Name = "label127";
			label127.Size = new System.Drawing.Size(13, 13);
			label127.TabIndex = 34;
			label127.Text = "4";
			label128.AutoSize = true;
			label128.Location = new System.Drawing.Point(496, 6);
			label128.Name = "label128";
			label128.Size = new System.Drawing.Size(13, 13);
			label128.TabIndex = 33;
			label128.Text = "5";
			label129.AutoSize = true;
			label129.Location = new System.Drawing.Point(472, 6);
			label129.Name = "label129";
			label129.Size = new System.Drawing.Size(13, 13);
			label129.TabIndex = 32;
			label129.Text = "6";
			label130.AutoSize = true;
			label130.Location = new System.Drawing.Point(448, 6);
			label130.Name = "label130";
			label130.Size = new System.Drawing.Size(13, 13);
			label130.TabIndex = 31;
			label130.Text = "7";
			label131.AutoSize = true;
			label131.Location = new System.Drawing.Point(415, 6);
			label131.Name = "label131";
			label131.Size = new System.Drawing.Size(13, 13);
			label131.TabIndex = 30;
			label131.Text = "8";
			label132.AutoSize = true;
			label132.Location = new System.Drawing.Point(391, 6);
			label132.Name = "label132";
			label132.Size = new System.Drawing.Size(13, 13);
			label132.TabIndex = 29;
			label132.Text = "9";
			label133.AutoSize = true;
			label133.Location = new System.Drawing.Point(364, 6);
			label133.Name = "label133";
			label133.Size = new System.Drawing.Size(19, 13);
			label133.TabIndex = 28;
			label133.Text = "10";
			label134.AutoSize = true;
			label134.Location = new System.Drawing.Point(340, 6);
			label134.Name = "label134";
			label134.Size = new System.Drawing.Size(19, 13);
			label134.TabIndex = 27;
			label134.Text = "11";
			label135.AutoSize = true;
			label135.Location = new System.Drawing.Point(308, 6);
			label135.Name = "label135";
			label135.Size = new System.Drawing.Size(19, 13);
			label135.TabIndex = 26;
			label135.Text = "12";
			label136.AutoSize = true;
			label136.Location = new System.Drawing.Point(284, 6);
			label136.Name = "label136";
			label136.Size = new System.Drawing.Size(19, 13);
			label136.TabIndex = 25;
			label136.Text = "13";
			label137.AutoSize = true;
			label137.Location = new System.Drawing.Point(260, 6);
			label137.Name = "label137";
			label137.Size = new System.Drawing.Size(19, 13);
			label137.TabIndex = 24;
			label137.Text = "14";
			label138.AutoSize = true;
			label138.Location = new System.Drawing.Point(236, 6);
			label138.Name = "label138";
			label138.Size = new System.Drawing.Size(19, 13);
			label138.TabIndex = 23;
			label138.Text = "15";
			textBox8_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_0.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_0.Location = new System.Drawing.Point(622, 22);
			textBox8_0.Name = "textBox8_0";
			textBox8_0.ReadOnly = true;
			textBox8_0.Size = new System.Drawing.Size(18, 20);
			textBox8_0.TabIndex = 22;
			textBox8_0.Text = "1";
			textBox8_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_0.Click += new System.EventHandler(textBox1_15_Click);
			labelVal8.AutoSize = true;
			labelVal8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelVal8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			labelVal8.Location = new System.Drawing.Point(165, 23);
			labelVal8.Name = "labelVal8";
			labelVal8.Size = new System.Drawing.Size(39, 15);
			labelVal8.TabIndex = 7;
			labelVal8.Text = "3FFF";
			labelAdr8.AutoSize = true;
			labelAdr8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelAdr8.Location = new System.Drawing.Point(88, 23);
			labelAdr8.Name = "labelAdr8";
			labelAdr8.Size = new System.Drawing.Size(71, 15);
			labelAdr8.TabIndex = 1;
			labelAdr8.Text = "20080000";
			textBox8_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_1.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_1.Location = new System.Drawing.Point(598, 22);
			textBox8_1.Name = "textBox8_1";
			textBox8_1.ReadOnly = true;
			textBox8_1.Size = new System.Drawing.Size(18, 20);
			textBox8_1.TabIndex = 21;
			textBox8_1.Text = "1";
			textBox8_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_1.Click += new System.EventHandler(textBox1_15_Click);
			labelName8.AutoSize = true;
			labelName8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelName8.Location = new System.Drawing.Point(-3, 23);
			labelName8.Name = "labelName8";
			labelName8.Size = new System.Drawing.Size(38, 15);
			labelName8.TabIndex = 0;
			labelName8.Text = "FICD";
			textBox8_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_2.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_2.Location = new System.Drawing.Point(574, 22);
			textBox8_2.Name = "textBox8_2";
			textBox8_2.ReadOnly = true;
			textBox8_2.Size = new System.Drawing.Size(18, 20);
			textBox8_2.TabIndex = 20;
			textBox8_2.Text = "1";
			textBox8_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_2.Click += new System.EventHandler(textBox1_15_Click);
			textBox8_11.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_11.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_11.Location = new System.Drawing.Point(341, 22);
			textBox8_11.Name = "textBox8_11";
			textBox8_11.ReadOnly = true;
			textBox8_11.Size = new System.Drawing.Size(18, 20);
			textBox8_11.TabIndex = 11;
			textBox8_11.Text = "1";
			textBox8_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_11.Click += new System.EventHandler(textBox1_15_Click);
			textBox8_12.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_12.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_12.Location = new System.Drawing.Point(309, 22);
			textBox8_12.Name = "textBox8_12";
			textBox8_12.ReadOnly = true;
			textBox8_12.Size = new System.Drawing.Size(18, 20);
			textBox8_12.TabIndex = 10;
			textBox8_12.Text = "1";
			textBox8_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_12.Click += new System.EventHandler(textBox1_15_Click);
			textBox8_3.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_3.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_3.Location = new System.Drawing.Point(550, 22);
			textBox8_3.Name = "textBox8_3";
			textBox8_3.ReadOnly = true;
			textBox8_3.Size = new System.Drawing.Size(18, 20);
			textBox8_3.TabIndex = 19;
			textBox8_3.Text = "1";
			textBox8_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_3.Click += new System.EventHandler(textBox1_15_Click);
			textBox8_10.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_10.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_10.Location = new System.Drawing.Point(365, 22);
			textBox8_10.Name = "textBox8_10";
			textBox8_10.ReadOnly = true;
			textBox8_10.Size = new System.Drawing.Size(18, 20);
			textBox8_10.TabIndex = 12;
			textBox8_10.Text = "1";
			textBox8_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_10.Click += new System.EventHandler(textBox1_15_Click);
			textBox8_13.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_13.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_13.Location = new System.Drawing.Point(285, 22);
			textBox8_13.Name = "textBox8_13";
			textBox8_13.ReadOnly = true;
			textBox8_13.Size = new System.Drawing.Size(18, 20);
			textBox8_13.TabIndex = 9;
			textBox8_13.Text = "1";
			textBox8_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_13.Click += new System.EventHandler(textBox1_15_Click);
			textBox8_4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_4.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_4.Location = new System.Drawing.Point(518, 22);
			textBox8_4.Name = "textBox8_4";
			textBox8_4.ReadOnly = true;
			textBox8_4.Size = new System.Drawing.Size(18, 20);
			textBox8_4.TabIndex = 18;
			textBox8_4.Text = "1";
			textBox8_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_4.Click += new System.EventHandler(textBox1_15_Click);
			textBox8_9.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_9.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_9.Location = new System.Drawing.Point(389, 22);
			textBox8_9.Name = "textBox8_9";
			textBox8_9.ReadOnly = true;
			textBox8_9.Size = new System.Drawing.Size(18, 20);
			textBox8_9.TabIndex = 13;
			textBox8_9.Text = "1";
			textBox8_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_9.Click += new System.EventHandler(textBox1_15_Click);
			textBox8_14.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_14.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_14.Location = new System.Drawing.Point(261, 22);
			textBox8_14.Name = "textBox8_14";
			textBox8_14.ReadOnly = true;
			textBox8_14.Size = new System.Drawing.Size(18, 20);
			textBox8_14.TabIndex = 8;
			textBox8_14.Text = "1";
			textBox8_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_14.Click += new System.EventHandler(textBox1_15_Click);
			textBox8_5.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_5.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_5.Location = new System.Drawing.Point(494, 22);
			textBox8_5.Name = "textBox8_5";
			textBox8_5.ReadOnly = true;
			textBox8_5.Size = new System.Drawing.Size(18, 20);
			textBox8_5.TabIndex = 17;
			textBox8_5.Text = "1";
			textBox8_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_5.Click += new System.EventHandler(textBox1_15_Click);
			textBox8_8.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_8.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_8.Location = new System.Drawing.Point(413, 22);
			textBox8_8.Name = "textBox8_8";
			textBox8_8.ReadOnly = true;
			textBox8_8.Size = new System.Drawing.Size(18, 20);
			textBox8_8.TabIndex = 14;
			textBox8_8.Text = "1";
			textBox8_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_8.Click += new System.EventHandler(textBox1_15_Click);
			textBox8_7.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_7.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_7.Location = new System.Drawing.Point(446, 22);
			textBox8_7.Name = "textBox8_7";
			textBox8_7.ReadOnly = true;
			textBox8_7.Size = new System.Drawing.Size(18, 20);
			textBox8_7.TabIndex = 15;
			textBox8_7.Text = "1";
			textBox8_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_7.Click += new System.EventHandler(textBox1_15_Click);
			textBox8_6.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox8_6.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox8_6.Location = new System.Drawing.Point(470, 22);
			textBox8_6.Name = "textBox8_6";
			textBox8_6.ReadOnly = true;
			textBox8_6.Size = new System.Drawing.Size(18, 20);
			textBox8_6.TabIndex = 16;
			textBox8_6.Text = "1";
			textBox8_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox8_6.Click += new System.EventHandler(textBox1_15_Click);
			panel9.Controls.Add(textBox9_15);
			panel9.Controls.Add(label139);
			panel9.Controls.Add(label140);
			panel9.Controls.Add(label141);
			panel9.Controls.Add(label142);
			panel9.Controls.Add(label143);
			panel9.Controls.Add(label144);
			panel9.Controls.Add(label145);
			panel9.Controls.Add(label146);
			panel9.Controls.Add(label147);
			panel9.Controls.Add(label148);
			panel9.Controls.Add(label149);
			panel9.Controls.Add(label150);
			panel9.Controls.Add(label151);
			panel9.Controls.Add(label152);
			panel9.Controls.Add(label153);
			panel9.Controls.Add(label154);
			panel9.Controls.Add(textBox9_0);
			panel9.Controls.Add(labelVal9);
			panel9.Controls.Add(labelAdr9);
			panel9.Controls.Add(textBox9_1);
			panel9.Controls.Add(labelName9);
			panel9.Controls.Add(textBox9_2);
			panel9.Controls.Add(textBox9_11);
			panel9.Controls.Add(textBox9_12);
			panel9.Controls.Add(textBox9_3);
			panel9.Controls.Add(textBox9_10);
			panel9.Controls.Add(textBox9_13);
			panel9.Controls.Add(textBox9_4);
			panel9.Controls.Add(textBox9_9);
			panel9.Controls.Add(textBox9_14);
			panel9.Controls.Add(textBox9_5);
			panel9.Controls.Add(textBox9_8);
			panel9.Controls.Add(textBox9_7);
			panel9.Controls.Add(textBox9_6);
			panel9.Location = new System.Drawing.Point(12, 461);
			panel9.Name = "panel9";
			panel9.Size = new System.Drawing.Size(648, 46);
			panel9.TabIndex = 21;
			textBox9_15.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_15.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_15.Location = new System.Drawing.Point(237, 22);
			textBox9_15.Name = "textBox9_15";
			textBox9_15.ReadOnly = true;
			textBox9_15.Size = new System.Drawing.Size(18, 20);
			textBox9_15.TabIndex = 11;
			textBox9_15.Text = "1";
			textBox9_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_15.Click += new System.EventHandler(textBox1_15_Click);
			label139.AutoSize = true;
			label139.Location = new System.Drawing.Point(624, 6);
			label139.Name = "label139";
			label139.Size = new System.Drawing.Size(13, 13);
			label139.TabIndex = 38;
			label139.Text = "0";
			label140.AutoSize = true;
			label140.Location = new System.Drawing.Point(600, 6);
			label140.Name = "label140";
			label140.Size = new System.Drawing.Size(13, 13);
			label140.TabIndex = 37;
			label140.Text = "1";
			label141.AutoSize = true;
			label141.Location = new System.Drawing.Point(576, 6);
			label141.Name = "label141";
			label141.Size = new System.Drawing.Size(13, 13);
			label141.TabIndex = 36;
			label141.Text = "2";
			label142.AutoSize = true;
			label142.Location = new System.Drawing.Point(552, 6);
			label142.Name = "label142";
			label142.Size = new System.Drawing.Size(13, 13);
			label142.TabIndex = 35;
			label142.Text = "3";
			label143.AutoSize = true;
			label143.Location = new System.Drawing.Point(520, 6);
			label143.Name = "label143";
			label143.Size = new System.Drawing.Size(13, 13);
			label143.TabIndex = 34;
			label143.Text = "4";
			label144.AutoSize = true;
			label144.Location = new System.Drawing.Point(496, 6);
			label144.Name = "label144";
			label144.Size = new System.Drawing.Size(13, 13);
			label144.TabIndex = 33;
			label144.Text = "5";
			label145.AutoSize = true;
			label145.Location = new System.Drawing.Point(472, 6);
			label145.Name = "label145";
			label145.Size = new System.Drawing.Size(13, 13);
			label145.TabIndex = 32;
			label145.Text = "6";
			label146.AutoSize = true;
			label146.Location = new System.Drawing.Point(448, 6);
			label146.Name = "label146";
			label146.Size = new System.Drawing.Size(13, 13);
			label146.TabIndex = 31;
			label146.Text = "7";
			label147.AutoSize = true;
			label147.Location = new System.Drawing.Point(415, 6);
			label147.Name = "label147";
			label147.Size = new System.Drawing.Size(13, 13);
			label147.TabIndex = 30;
			label147.Text = "8";
			label148.AutoSize = true;
			label148.Location = new System.Drawing.Point(391, 6);
			label148.Name = "label148";
			label148.Size = new System.Drawing.Size(13, 13);
			label148.TabIndex = 29;
			label148.Text = "9";
			label149.AutoSize = true;
			label149.Location = new System.Drawing.Point(364, 6);
			label149.Name = "label149";
			label149.Size = new System.Drawing.Size(19, 13);
			label149.TabIndex = 28;
			label149.Text = "10";
			label150.AutoSize = true;
			label150.Location = new System.Drawing.Point(340, 6);
			label150.Name = "label150";
			label150.Size = new System.Drawing.Size(19, 13);
			label150.TabIndex = 27;
			label150.Text = "11";
			label151.AutoSize = true;
			label151.Location = new System.Drawing.Point(308, 6);
			label151.Name = "label151";
			label151.Size = new System.Drawing.Size(19, 13);
			label151.TabIndex = 26;
			label151.Text = "12";
			label152.AutoSize = true;
			label152.Location = new System.Drawing.Point(284, 6);
			label152.Name = "label152";
			label152.Size = new System.Drawing.Size(19, 13);
			label152.TabIndex = 25;
			label152.Text = "13";
			label153.AutoSize = true;
			label153.Location = new System.Drawing.Point(260, 6);
			label153.Name = "label153";
			label153.Size = new System.Drawing.Size(19, 13);
			label153.TabIndex = 24;
			label153.Text = "14";
			label154.AutoSize = true;
			label154.Location = new System.Drawing.Point(236, 6);
			label154.Name = "label154";
			label154.Size = new System.Drawing.Size(19, 13);
			label154.TabIndex = 23;
			label154.Text = "15";
			textBox9_0.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_0.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_0.Location = new System.Drawing.Point(622, 22);
			textBox9_0.Name = "textBox9_0";
			textBox9_0.ReadOnly = true;
			textBox9_0.Size = new System.Drawing.Size(18, 20);
			textBox9_0.TabIndex = 22;
			textBox9_0.Text = "1";
			textBox9_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_0.Click += new System.EventHandler(textBox1_15_Click);
			labelVal9.AutoSize = true;
			labelVal9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelVal9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			labelVal9.Location = new System.Drawing.Point(165, 23);
			labelVal9.Name = "labelVal9";
			labelVal9.Size = new System.Drawing.Size(39, 15);
			labelVal9.TabIndex = 7;
			labelVal9.Text = "3FFF";
			labelAdr9.AutoSize = true;
			labelAdr9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelAdr9.Location = new System.Drawing.Point(88, 23);
			labelAdr9.Name = "labelAdr9";
			labelAdr9.Size = new System.Drawing.Size(71, 15);
			labelAdr9.TabIndex = 1;
			labelAdr9.Text = "20080000";
			textBox9_1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_1.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_1.Location = new System.Drawing.Point(598, 22);
			textBox9_1.Name = "textBox9_1";
			textBox9_1.ReadOnly = true;
			textBox9_1.Size = new System.Drawing.Size(18, 20);
			textBox9_1.TabIndex = 21;
			textBox9_1.Text = "1";
			textBox9_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_1.Click += new System.EventHandler(textBox1_15_Click);
			labelName9.AutoSize = true;
			labelName9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			labelName9.Location = new System.Drawing.Point(-3, 23);
			labelName9.Name = "labelName9";
			labelName9.Size = new System.Drawing.Size(34, 15);
			labelName9.TabIndex = 0;
			labelName9.Text = "FDS";
			textBox9_2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_2.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_2.Location = new System.Drawing.Point(574, 22);
			textBox9_2.Name = "textBox9_2";
			textBox9_2.ReadOnly = true;
			textBox9_2.Size = new System.Drawing.Size(18, 20);
			textBox9_2.TabIndex = 20;
			textBox9_2.Text = "1";
			textBox9_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_2.Click += new System.EventHandler(textBox1_15_Click);
			textBox9_11.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_11.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_11.Location = new System.Drawing.Point(341, 22);
			textBox9_11.Name = "textBox9_11";
			textBox9_11.ReadOnly = true;
			textBox9_11.Size = new System.Drawing.Size(18, 20);
			textBox9_11.TabIndex = 11;
			textBox9_11.Text = "1";
			textBox9_11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_11.Click += new System.EventHandler(textBox1_15_Click);
			textBox9_12.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_12.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_12.Location = new System.Drawing.Point(309, 22);
			textBox9_12.Name = "textBox9_12";
			textBox9_12.ReadOnly = true;
			textBox9_12.Size = new System.Drawing.Size(18, 20);
			textBox9_12.TabIndex = 10;
			textBox9_12.Text = "1";
			textBox9_12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_12.Click += new System.EventHandler(textBox1_15_Click);
			textBox9_3.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_3.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_3.Location = new System.Drawing.Point(550, 22);
			textBox9_3.Name = "textBox9_3";
			textBox9_3.ReadOnly = true;
			textBox9_3.Size = new System.Drawing.Size(18, 20);
			textBox9_3.TabIndex = 19;
			textBox9_3.Text = "1";
			textBox9_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_3.Click += new System.EventHandler(textBox1_15_Click);
			textBox9_10.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_10.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_10.Location = new System.Drawing.Point(365, 22);
			textBox9_10.Name = "textBox9_10";
			textBox9_10.ReadOnly = true;
			textBox9_10.Size = new System.Drawing.Size(18, 20);
			textBox9_10.TabIndex = 12;
			textBox9_10.Text = "1";
			textBox9_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_10.Click += new System.EventHandler(textBox1_15_Click);
			textBox9_13.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_13.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_13.Location = new System.Drawing.Point(285, 22);
			textBox9_13.Name = "textBox9_13";
			textBox9_13.ReadOnly = true;
			textBox9_13.Size = new System.Drawing.Size(18, 20);
			textBox9_13.TabIndex = 9;
			textBox9_13.Text = "1";
			textBox9_13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_13.Click += new System.EventHandler(textBox1_15_Click);
			textBox9_4.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_4.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_4.Location = new System.Drawing.Point(518, 22);
			textBox9_4.Name = "textBox9_4";
			textBox9_4.ReadOnly = true;
			textBox9_4.Size = new System.Drawing.Size(18, 20);
			textBox9_4.TabIndex = 18;
			textBox9_4.Text = "1";
			textBox9_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_4.Click += new System.EventHandler(textBox1_15_Click);
			textBox9_9.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_9.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_9.Location = new System.Drawing.Point(389, 22);
			textBox9_9.Name = "textBox9_9";
			textBox9_9.ReadOnly = true;
			textBox9_9.Size = new System.Drawing.Size(18, 20);
			textBox9_9.TabIndex = 13;
			textBox9_9.Text = "1";
			textBox9_9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_9.Click += new System.EventHandler(textBox1_15_Click);
			textBox9_14.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_14.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_14.Location = new System.Drawing.Point(261, 22);
			textBox9_14.Name = "textBox9_14";
			textBox9_14.ReadOnly = true;
			textBox9_14.Size = new System.Drawing.Size(18, 20);
			textBox9_14.TabIndex = 8;
			textBox9_14.Text = "1";
			textBox9_14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_14.Click += new System.EventHandler(textBox1_15_Click);
			textBox9_5.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_5.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_5.Location = new System.Drawing.Point(494, 22);
			textBox9_5.Name = "textBox9_5";
			textBox9_5.ReadOnly = true;
			textBox9_5.Size = new System.Drawing.Size(18, 20);
			textBox9_5.TabIndex = 17;
			textBox9_5.Text = "1";
			textBox9_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_5.Click += new System.EventHandler(textBox1_15_Click);
			textBox9_8.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_8.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_8.Location = new System.Drawing.Point(413, 22);
			textBox9_8.Name = "textBox9_8";
			textBox9_8.ReadOnly = true;
			textBox9_8.Size = new System.Drawing.Size(18, 20);
			textBox9_8.TabIndex = 14;
			textBox9_8.Text = "1";
			textBox9_8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_8.Click += new System.EventHandler(textBox1_15_Click);
			textBox9_7.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_7.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_7.Location = new System.Drawing.Point(446, 22);
			textBox9_7.Name = "textBox9_7";
			textBox9_7.ReadOnly = true;
			textBox9_7.Size = new System.Drawing.Size(18, 20);
			textBox9_7.TabIndex = 15;
			textBox9_7.Text = "1";
			textBox9_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_7.Click += new System.EventHandler(textBox1_15_Click);
			textBox9_6.BackColor = System.Drawing.SystemColors.ControlLightLight;
			textBox9_6.Cursor = System.Windows.Forms.Cursors.Hand;
			textBox9_6.Location = new System.Drawing.Point(470, 22);
			textBox9_6.Name = "textBox9_6";
			textBox9_6.ReadOnly = true;
			textBox9_6.Size = new System.Drawing.Size(18, 20);
			textBox9_6.TabIndex = 16;
			textBox9_6.Text = "1";
			textBox9_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			textBox9_6.Click += new System.EventHandler(textBox1_15_Click);
			label155.AutoSize = true;
			label155.BackColor = System.Drawing.SystemColors.ControlLightLight;
			label155.Location = new System.Drawing.Point(175, 28);
			label155.Name = "label155";
			label155.Size = new System.Drawing.Size(13, 13);
			label155.TabIndex = 22;
			label155.Text = "1";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(672, 558);
			base.Controls.Add(panel9);
			base.Controls.Add(panel8);
			base.Controls.Add(panel7);
			base.Controls.Add(panel6);
			base.Controls.Add(panel5);
			base.Controls.Add(panel4);
			base.Controls.Add(panel3);
			base.Controls.Add(label42);
			base.Controls.Add(label41);
			base.Controls.Add(label40);
			base.Controls.Add(panel2);
			base.Controls.Add(label7);
			base.Controls.Add(label6);
			base.Controls.Add(textBoxUnimpl);
			base.Controls.Add(label5);
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(buttonCancel);
			base.Controls.Add(buttonSave);
			base.Controls.Add(panel1);
			base.Controls.Add(label155);
			base.Controls.Add(textBoxEx);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DialogConfigEdit";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			Text = "Configuration Word Editor";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(DialogConfigEdit_FormClosing);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			panel7.ResumeLayout(false);
			panel7.PerformLayout();
			panel8.ResumeLayout(false);
			panel8.PerformLayout();
			panel9.ResumeLayout(false);
			panel9.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		public DialogConfigEdit()
		{
			InitializeComponent();
			for (int i = 0; i < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords; i++)
			{
				configSaves[i] = PICkitFunctions.DeviceBuffers.ConfigWords[i];
			}
			configWords[0].configPanel = panel1;
			configWords[0].name = labelName1;
			configWords[0].addr = labelAdr1;
			configWords[0].value = labelVal1;
			configWords[0].bits = new TextBox[16];
			configWords[0].bits[0] = textBox1_0;
			configWords[0].bits[1] = textBox1_1;
			configWords[0].bits[2] = textBox1_2;
			configWords[0].bits[3] = textBox1_3;
			configWords[0].bits[4] = textBox1_4;
			configWords[0].bits[5] = textBox1_5;
			configWords[0].bits[6] = textBox1_6;
			configWords[0].bits[7] = textBox1_7;
			configWords[0].bits[8] = textBox1_8;
			configWords[0].bits[9] = textBox1_9;
			configWords[0].bits[10] = textBox1_10;
			configWords[0].bits[11] = textBox1_11;
			configWords[0].bits[12] = textBox1_12;
			configWords[0].bits[13] = textBox1_13;
			configWords[0].bits[14] = textBox1_14;
			configWords[0].bits[15] = textBox1_15;
			configWords[1].configPanel = panel2;
			configWords[1].name = labelName2;
			configWords[1].addr = labelAdr2;
			configWords[1].value = labelVal2;
			configWords[1].bits = new TextBox[16];
			configWords[1].bits[0] = textBox2_0;
			configWords[1].bits[1] = textBox2_1;
			configWords[1].bits[2] = textBox2_2;
			configWords[1].bits[3] = textBox2_3;
			configWords[1].bits[4] = textBox2_4;
			configWords[1].bits[5] = textBox2_5;
			configWords[1].bits[6] = textBox2_6;
			configWords[1].bits[7] = textBox2_7;
			configWords[1].bits[8] = textBox2_8;
			configWords[1].bits[9] = textBox2_9;
			configWords[1].bits[10] = textBox2_10;
			configWords[1].bits[11] = textBox2_11;
			configWords[1].bits[12] = textBox2_12;
			configWords[1].bits[13] = textBox2_13;
			configWords[1].bits[14] = textBox2_14;
			configWords[1].bits[15] = textBox2_15;
			configWords[2].configPanel = panel3;
			configWords[2].name = labelName3;
			configWords[2].addr = labelAdr3;
			configWords[2].value = labelVal3;
			configWords[2].bits = new TextBox[16];
			configWords[2].bits[0] = textBox3_0;
			configWords[2].bits[1] = textBox3_1;
			configWords[2].bits[2] = textBox3_2;
			configWords[2].bits[3] = textBox3_3;
			configWords[2].bits[4] = textBox3_4;
			configWords[2].bits[5] = textBox3_5;
			configWords[2].bits[6] = textBox3_6;
			configWords[2].bits[7] = textBox3_7;
			configWords[2].bits[8] = textBox3_8;
			configWords[2].bits[9] = textBox3_9;
			configWords[2].bits[10] = textBox3_10;
			configWords[2].bits[11] = textBox3_11;
			configWords[2].bits[12] = textBox3_12;
			configWords[2].bits[13] = textBox3_13;
			configWords[2].bits[14] = textBox3_14;
			configWords[2].bits[15] = textBox3_15;
			configWords[3].configPanel = panel4;
			configWords[3].name = labelName4;
			configWords[3].addr = labelAdr4;
			configWords[3].value = labelVal4;
			configWords[3].bits = new TextBox[16];
			configWords[3].bits[0] = textBox4_0;
			configWords[3].bits[1] = textBox4_1;
			configWords[3].bits[2] = textBox4_2;
			configWords[3].bits[3] = textBox4_3;
			configWords[3].bits[4] = textBox4_4;
			configWords[3].bits[5] = textBox4_5;
			configWords[3].bits[6] = textBox4_6;
			configWords[3].bits[7] = textBox4_7;
			configWords[3].bits[8] = textBox4_8;
			configWords[3].bits[9] = textBox4_9;
			configWords[3].bits[10] = textBox4_10;
			configWords[3].bits[11] = textBox4_11;
			configWords[3].bits[12] = textBox4_12;
			configWords[3].bits[13] = textBox4_13;
			configWords[3].bits[14] = textBox4_14;
			configWords[3].bits[15] = textBox4_15;
			configWords[4].configPanel = panel5;
			configWords[4].name = labelName5;
			configWords[4].addr = labelAdr5;
			configWords[4].value = labelVal5;
			configWords[4].bits = new TextBox[16];
			configWords[4].bits[0] = textBox5_0;
			configWords[4].bits[1] = textBox5_1;
			configWords[4].bits[2] = textBox5_2;
			configWords[4].bits[3] = textBox5_3;
			configWords[4].bits[4] = textBox5_4;
			configWords[4].bits[5] = textBox5_5;
			configWords[4].bits[6] = textBox5_6;
			configWords[4].bits[7] = textBox5_7;
			configWords[4].bits[8] = textBox5_8;
			configWords[4].bits[9] = textBox5_9;
			configWords[4].bits[10] = textBox5_10;
			configWords[4].bits[11] = textBox5_11;
			configWords[4].bits[12] = textBox5_12;
			configWords[4].bits[13] = textBox5_13;
			configWords[4].bits[14] = textBox5_14;
			configWords[4].bits[15] = textBox5_15;
			configWords[5].configPanel = panel6;
			configWords[5].name = labelName6;
			configWords[5].addr = labelAdr6;
			configWords[5].value = labelVal6;
			configWords[5].bits = new TextBox[16];
			configWords[5].bits[0] = textBox6_0;
			configWords[5].bits[1] = textBox6_1;
			configWords[5].bits[2] = textBox6_2;
			configWords[5].bits[3] = textBox6_3;
			configWords[5].bits[4] = textBox6_4;
			configWords[5].bits[5] = textBox6_5;
			configWords[5].bits[6] = textBox6_6;
			configWords[5].bits[7] = textBox6_7;
			configWords[5].bits[8] = textBox6_8;
			configWords[5].bits[9] = textBox6_9;
			configWords[5].bits[10] = textBox6_10;
			configWords[5].bits[11] = textBox6_11;
			configWords[5].bits[12] = textBox6_12;
			configWords[5].bits[13] = textBox6_13;
			configWords[5].bits[14] = textBox6_14;
			configWords[5].bits[15] = textBox6_15;
			configWords[6].configPanel = panel7;
			configWords[6].name = labelName7;
			configWords[6].addr = labelAdr7;
			configWords[6].value = labelVal7;
			configWords[6].bits = new TextBox[16];
			configWords[6].bits[0] = textBox7_0;
			configWords[6].bits[1] = textBox7_1;
			configWords[6].bits[2] = textBox7_2;
			configWords[6].bits[3] = textBox7_3;
			configWords[6].bits[4] = textBox7_4;
			configWords[6].bits[5] = textBox7_5;
			configWords[6].bits[6] = textBox7_6;
			configWords[6].bits[7] = textBox7_7;
			configWords[6].bits[8] = textBox7_8;
			configWords[6].bits[9] = textBox7_9;
			configWords[6].bits[10] = textBox7_10;
			configWords[6].bits[11] = textBox7_11;
			configWords[6].bits[12] = textBox7_12;
			configWords[6].bits[13] = textBox7_13;
			configWords[6].bits[14] = textBox7_14;
			configWords[6].bits[15] = textBox7_15;
			configWords[7].configPanel = panel8;
			configWords[7].name = labelName8;
			configWords[7].addr = labelAdr8;
			configWords[7].value = labelVal8;
			configWords[7].bits = new TextBox[16];
			configWords[7].bits[0] = textBox8_0;
			configWords[7].bits[1] = textBox8_1;
			configWords[7].bits[2] = textBox8_2;
			configWords[7].bits[3] = textBox8_3;
			configWords[7].bits[4] = textBox8_4;
			configWords[7].bits[5] = textBox8_5;
			configWords[7].bits[6] = textBox8_6;
			configWords[7].bits[7] = textBox8_7;
			configWords[7].bits[8] = textBox8_8;
			configWords[7].bits[9] = textBox8_9;
			configWords[7].bits[10] = textBox8_10;
			configWords[7].bits[11] = textBox8_11;
			configWords[7].bits[12] = textBox8_12;
			configWords[7].bits[13] = textBox8_13;
			configWords[7].bits[14] = textBox8_14;
			configWords[7].bits[15] = textBox8_15;
			configWords[8].configPanel = panel9;
			configWords[8].name = labelName9;
			configWords[8].addr = labelAdr9;
			configWords[8].value = labelVal9;
			configWords[8].bits = new TextBox[16];
			configWords[8].bits[0] = textBox9_0;
			configWords[8].bits[1] = textBox9_1;
			configWords[8].bits[2] = textBox9_2;
			configWords[8].bits[3] = textBox9_3;
			configWords[8].bits[4] = textBox9_4;
			configWords[8].bits[5] = textBox9_5;
			configWords[8].bits[6] = textBox9_6;
			configWords[8].bits[7] = textBox9_7;
			configWords[8].bits[8] = textBox9_8;
			configWords[8].bits[9] = textBox9_9;
			configWords[8].bits[10] = textBox9_10;
			configWords[8].bits[11] = textBox9_11;
			configWords[8].bits[12] = textBox9_12;
			configWords[8].bits[13] = textBox9_13;
			configWords[8].bits[14] = textBox9_14;
			configWords[8].bits[15] = textBox9_15;
			int num = 0;
			for (int j = 0; j < 9; j++)
			{
				for (int k = 0; k < 16; k++)
				{
					configWords[j].bits[k].Tag = num++;
				}
			}
		}

		public void SetDisplayMask(int option)
		{
			displayMask = option;
			redraw();
		}

		private void redraw()
		{
			int num = 9 - PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords;
			num *= (int)(48f * ScalefactH);
			num -= (int)(24f * ScalefactH);
			base.Size = new Size(base.Size.Width, base.Size.Height - num);
			string[] array = new string[9];
			for (int i = 1; i <= array.Length; i++)
			{
				array[i - 1] = $"CONFIG{i:G}";
			}
			int num2 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr / 2;
			int num3 = 1;
			if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords == 1)
			{
				array[0] = "CONFIG";
			}
			if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue == 65535)
			{
				num2 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr;
				num3 = 2;
			}
			else if (PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue == 16777215)
			{
				if (PICkitFunctions.FamilyIsPIC24FJ())
				{
					for (int j = 1; j <= PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords; j++)
					{
						array[PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords - j] = $"CW{j:G}";
					}
					num2 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr / 2;
					num3 = 2;
				}
				else if (PICkitFunctions.FamilyIsPIC24H() || PICkitFunctions.FamilyIsdsPIC33F() || PICkitFunctions.FamilyIsdsPIC30SMPS() || PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords == 9)
				{
					array[0] = "FBS";
					array[1] = "FSS";
					array[2] = "FGS";
					array[3] = "FOSCSEL";
					array[4] = "FOSC";
					array[5] = "FWDT";
					array[6] = "FPOR";
					array[7] = "FICD";
					array[8] = "FDS";
					num2 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr / 2;
					num3 = 2;
				}
				else
				{
					array[0] = "FOSC";
					array[1] = "FWDT";
					array[2] = "FBORPOR";
					array[3] = "FBS";
					array[4] = "FSS";
					array[5] = "FGS";
					array[6] = "FICD";
					num2 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr / 2;
					num3 = 2;
				}
			}
			else if (PICkitFunctions.FamilyIsPIC32())
			{
				array[0] = "DEVCFG2L";
				array[1] = "DEVCFG2H";
				array[2] = "DEVCFG1L";
				array[3] = "DEVCFG1H";
				array[4] = "DEVCFG0L";
				array[5] = "DEVCFG0H";
				num2 = (int)PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigAddr;
				num3 = 2;
			}
			for (int k = 0; k < 9; k++)
			{
				if (k < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords)
				{
					_ = PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[k];
					configWords[k].name.Text = array[k];
					configWords[k].addr.Text = $"{num2 + k * num3:X}";
					ushort num4 = (ushort)PICkitFunctions.DeviceBuffers.ConfigWords[k];
					if (displayMask == 0)
					{
						num4 = (ushort)(num4 & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[k]);
					}
					else if (displayMask == 1)
					{
						num4 = (ushort)(num4 | (ushort)(~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[k]));
					}
					num4 = (ushort)(num4 & (ushort)PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
					configWords[k].value.Text = $"{num4:X4}";
					ushort num5 = 1;
					for (int l = 0; l < 16; l++)
					{
						if ((PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[k] & num5) > 0)
						{
							if ((PICkitFunctions.DeviceBuffers.ConfigWords[k] & num5) != 0)
							{
								configWords[k].bits[l].Text = "1";
							}
							else
							{
								configWords[k].bits[l].Text = "0";
							}
						}
						else
						{
							configWords[k].bits[l].Text = "-";
							configWords[k].bits[l].BackColor = SystemColors.Control;
							configWords[k].bits[l].Enabled = false;
						}
						num5 = (ushort)(num5 << 1);
					}
					if (PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[k] == 0)
					{
						configWords[k].configPanel.Enabled = false;
					}
				}
				else
				{
					configWords[k].configPanel.Visible = false;
				}
			}
		}

		private void textBox1_15_Click(object sender, EventArgs e)
		{
			int num = (int)((TextBox)sender).Tag;
			int num2 = num / 16;
			num %= 16;
			uint num3 = 1u;
			num3 <<= num;
			if (configWords[num2].bits[num].Text == "1")
			{
				configWords[num2].bits[num].Text = "0";
				PICkitFunctions.DeviceBuffers.ConfigWords[num2] &= ~num3;
			}
			else
			{
				configWords[num2].bits[num].Text = "1";
				PICkitFunctions.DeviceBuffers.ConfigWords[num2] |= num3;
			}
			if (configWords[num2].bits[num].ForeColor == Color.Crimson)
			{
				configWords[num2].bits[num].ForeColor = SystemColors.WindowText;
			}
			else
			{
				configWords[num2].bits[num].ForeColor = Color.Crimson;
			}
			ushort num4 = (ushort)PICkitFunctions.DeviceBuffers.ConfigWords[num2];
			if (displayMask == 0)
			{
				num4 = (ushort)(num4 & PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[num2]);
			}
			else if (displayMask == 1)
			{
				num4 = (ushort)(num4 | (ushort)(~PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigMasks[num2]));
			}
			num4 = (ushort)(num4 & (ushort)PICkitFunctions.DevFile.Families[PICkitFunctions.GetActiveFamily()].BlankValue);
			configWords[num2].value.Text = $"{num4:X4}";
			configWords[num2].value.ForeColor = SystemColors.ActiveCaption;
			int num5 = 0;
			while (true)
			{
				if (num5 < 16)
				{
					if (configWords[num2].bits[num5].ForeColor == Color.Crimson)
					{
						break;
					}
					num5++;
					continue;
				}
				return;
			}
			configWords[num2].value.ForeColor = Color.Crimson;
		}

		private void DialogConfigEdit_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool flag = false;
			for (int i = 0; i < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords; i++)
			{
				if (configWords[i].value.ForeColor == Color.Crimson)
				{
					flag = true;
					break;
				}
			}
			if (flag && !saveChanges)
			{
				if (MessageBox.Show("Are you sure you wish to exit\nwithout saving your Configuration edits?\n\nClick 'OK' to exit without saving your changes.", "Exit without Saving?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
				for (int j = 0; j < PICkitFunctions.DevFile.PartsList[PICkitFunctions.ActivePart].ConfigWords; j++)
				{
					PICkitFunctions.DeviceBuffers.ConfigWords[j] = configSaves[j];
				}
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			saveChanges = false;
			Close();
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			saveChanges = true;
			FormPICkit2.ConfigsEdited = true;
			Close();
		}
	}
}
