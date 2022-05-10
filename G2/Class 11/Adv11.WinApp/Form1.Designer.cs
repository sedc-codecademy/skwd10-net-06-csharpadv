namespace Adv11.WinApp
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.AsyncBtn = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.ResultLbl = new System.Windows.Forms.Label();
			this.SyncBtn = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.CheckBtn = new System.Windows.Forms.Button();
			this.MessageLbl = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// AsyncBtn
			// 
			this.AsyncBtn.BackColor = System.Drawing.Color.MediumSpringGreen;
			this.AsyncBtn.Location = new System.Drawing.Point(145, 288);
			this.AsyncBtn.Name = "AsyncBtn";
			this.AsyncBtn.Size = new System.Drawing.Size(193, 93);
			this.AsyncBtn.TabIndex = 0;
			this.AsyncBtn.Text = "Async Work";
			this.AsyncBtn.UseVisualStyleBackColor = false;
			this.AsyncBtn.Click += new System.EventHandler(this.AsyncBtn_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(145, 111);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(101, 24);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "checkBox1";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(145, 168);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(101, 24);
			this.checkBox2.TabIndex = 2;
			this.checkBox2.Text = "checkBox2";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(545, 108);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(125, 27);
			this.textBox1.TabIndex = 3;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(545, 165);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(125, 27);
			this.textBox2.TabIndex = 3;
			// 
			// ResultLbl
			// 
			this.ResultLbl.AutoSize = true;
			this.ResultLbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ResultLbl.Location = new System.Drawing.Point(272, 433);
			this.ResultLbl.Name = "ResultLbl";
			this.ResultLbl.Size = new System.Drawing.Size(269, 41);
			this.ResultLbl.TabIndex = 1;
			this.ResultLbl.Text = "Work is not started";
			// 
			// SyncBtn
			// 
			this.SyncBtn.BackColor = System.Drawing.Color.Salmon;
			this.SyncBtn.Location = new System.Drawing.Point(477, 288);
			this.SyncBtn.Name = "SyncBtn";
			this.SyncBtn.Size = new System.Drawing.Size(193, 93);
			this.SyncBtn.TabIndex = 0;
			this.SyncBtn.Text = "Sync Work";
			this.SyncBtn.UseVisualStyleBackColor = false;
			this.SyncBtn.Click += new System.EventHandler(this.SyncBtn_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(555, 62);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 20);
			this.label3.TabIndex = 1;
			this.label3.Text = "Test Input Fields";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(140, 62);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(121, 20);
			this.label4.TabIndex = 1;
			this.label4.Text = "Test Check Boxes";
			// 
			// CheckBtn
			// 
			this.CheckBtn.Location = new System.Drawing.Point(326, 168);
			this.CheckBtn.Name = "CheckBtn";
			this.CheckBtn.Size = new System.Drawing.Size(160, 29);
			this.CheckBtn.TabIndex = 4;
			this.CheckBtn.Text = "Check For Message";
			this.CheckBtn.UseVisualStyleBackColor = true;
			this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
			// 
			// MessageLbl
			// 
			this.MessageLbl.AutoSize = true;
			this.MessageLbl.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.MessageLbl.Location = new System.Drawing.Point(315, 221);
			this.MessageLbl.Name = "MessageLbl";
			this.MessageLbl.Size = new System.Drawing.Size(183, 41);
			this.MessageLbl.TabIndex = 1;
			this.MessageLbl.Text = "No message";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(822, 544);
			this.Controls.Add(this.MessageLbl);
			this.Controls.Add(this.CheckBtn);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.SyncBtn);
			this.Controls.Add(this.ResultLbl);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.AsyncBtn);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button AsyncBtn;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label ResultLbl;
		private System.Windows.Forms.Button SyncBtn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button CheckBtn;
		private System.Windows.Forms.Label MessageLbl;
	}
}

