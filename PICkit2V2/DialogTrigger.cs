using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PICkit2V2
{
	public class DialogTrigger : Form
	{
		private IContainer components;

		private Label label1;

		private Label label2;

		private PictureBox pictureBox1;

		private Label label3;

		private Label label4;

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
			pictureBox1 = new System.Windows.Forms.PictureBox();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(12, 42);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(194, 32);
			label1.TabIndex = 0;
			label1.Text = "PICkit 2 Logic Tool is waiting for\r\na valid trigger condition.";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(12, 138);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(190, 48);
			label2.TabIndex = 1;
			label2.Text = "Do not disconnect the PICkit 2 -\r\ndoing so may cause this\r\napplication to hang.";
			pictureBox1.BackColor = System.Drawing.Color.Red;
			pictureBox1.Location = new System.Drawing.Point(15, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(16, 18);
			pictureBox1.TabIndex = 2;
			pictureBox1.TabStop = false;
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(37, 14);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(137, 16);
			label3.TabIndex = 3;
			label3.Text = "Waiting for Trigger";
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(12, 91);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(195, 32);
			label4.TabIndex = 4;
			label4.Text = "To cancel (abort) press the\r\nPICkit 2 pushbutton.";
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.ClientSize = new System.Drawing.Size(237, 196);
			base.ControlBox = false;
			base.Controls.Add(label4);
			base.Controls.Add(label3);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "DialogTrigger";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "PICkit 2 Logic Tool Running";
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		public DialogTrigger()
		{
			InitializeComponent();
			base.Size = new Size(base.Size.Width, (int)(FormPICkit2.ScalefactH * (float)base.Size.Height));
		}
	}
}
