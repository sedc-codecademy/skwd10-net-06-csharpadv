namespace Adv06.WinApp
{
	partial class Form
	{
        private System.Windows.Forms.Button btnClickMe;
        private System.Windows.Forms.Label lblResult;

        private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.btnClickMe = new System.Windows.Forms.Button();
			this.lblResult = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnClickMe
			// 
			this.btnClickMe.BackColor = System.Drawing.Color.LightSkyBlue;
			this.btnClickMe.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnClickMe.Location = new System.Drawing.Point(250, 80);
			this.btnClickMe.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.btnClickMe.Name = "btnClickMe";
			this.btnClickMe.Size = new System.Drawing.Size(300, 150);
			this.btnClickMe.TabIndex = 0;
			this.btnClickMe.Text = "Click me";
			this.btnClickMe.UseVisualStyleBackColor = false;
			this.btnClickMe.Click += new System.EventHandler(this.WhenButtonClicked);
			// 
			// lblResult
			// 
			this.lblResult.AutoSize = true;
			this.lblResult.Location = new System.Drawing.Point(180, 280);
			this.lblResult.Name = "lblResult";
			this.lblResult.Size = new System.Drawing.Size(0, 49);
			this.lblResult.TabIndex = 1;
			// 
			// Form
			// 
			this.AcceptButton = this.btnClickMe;
			this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 49F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(782, 353);
			this.Controls.Add(this.lblResult);
			this.Controls.Add(this.btnClickMe);
			this.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
			this.Name = "Form";
			this.Text = "Window";
			this.Load += new System.EventHandler(this.Form_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }
	}
}

