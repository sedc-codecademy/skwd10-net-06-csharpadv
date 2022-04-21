namespace CSharpAdvanced_G3_L6_WinForms
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
            this.clickCounterLabel = new System.Windows.Forms.Label();
            this.clickCounterButton = new System.Windows.Forms.Button();
            this.myCheckBox = new System.Windows.Forms.CheckBox();
            this.toggleLabel = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.textBoxLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clickCounterLabel
            // 
            this.clickCounterLabel.AutoSize = true;
            this.clickCounterLabel.Location = new System.Drawing.Point(43, 35);
            this.clickCounterLabel.Name = "clickCounterLabel";
            this.clickCounterLabel.Size = new System.Drawing.Size(38, 15);
            this.clickCounterLabel.TabIndex = 0;
            this.clickCounterLabel.Text = "label1";
            // 
            // clickCounterButton
            // 
            this.clickCounterButton.Location = new System.Drawing.Point(43, 80);
            this.clickCounterButton.Name = "clickCounterButton";
            this.clickCounterButton.Size = new System.Drawing.Size(75, 23);
            this.clickCounterButton.TabIndex = 1;
            this.clickCounterButton.Text = "Click Me!";
            this.clickCounterButton.UseVisualStyleBackColor = true;
            // 
            // myCheckBox
            // 
            this.myCheckBox.AutoSize = true;
            this.myCheckBox.Location = new System.Drawing.Point(234, 34);
            this.myCheckBox.Name = "myCheckBox";
            this.myCheckBox.Size = new System.Drawing.Size(117, 19);
            this.myCheckBox.TabIndex = 2;
            this.myCheckBox.Text = "Toggle Checkbox";
            this.myCheckBox.UseVisualStyleBackColor = true;
            // 
            // toggleLabel
            // 
            this.toggleLabel.AutoSize = true;
            this.toggleLabel.Location = new System.Drawing.Point(248, 72);
            this.toggleLabel.Name = "toggleLabel";
            this.toggleLabel.Size = new System.Drawing.Size(0, 15);
            this.toggleLabel.TabIndex = 3;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(58, 140);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(100, 23);
            this.textBoxInput.TabIndex = 4;
            // 
            // textBoxLabel
            // 
            this.textBoxLabel.AutoSize = true;
            this.textBoxLabel.Location = new System.Drawing.Point(67, 199);
            this.textBoxLabel.Name = "textBoxLabel";
            this.textBoxLabel.Size = new System.Drawing.Size(0, 15);
            this.textBoxLabel.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 423);
            this.Controls.Add(this.textBoxLabel);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.toggleLabel);
            this.Controls.Add(this.myCheckBox);
            this.Controls.Add(this.clickCounterButton);
            this.Controls.Add(this.clickCounterLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label clickCounterLabel;
        private Button button1;
        private Button clickCounterButton;
        private CheckBox myCheckBox;
        private Label toggleLabel;
        private TextBox textBoxInput;
        private Label textBoxLabel;
    }
}