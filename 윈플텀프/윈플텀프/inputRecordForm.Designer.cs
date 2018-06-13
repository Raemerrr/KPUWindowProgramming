namespace 윈플텀프
{
    partial class InputRecordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playerNameTextBox = new System.Windows.Forms.TextBox();
            this.completeButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // playerNameTextBox
            // 
            this.playerNameTextBox.Location = new System.Drawing.Point(143, 133);
            this.playerNameTextBox.Name = "playerNameTextBox";
            this.playerNameTextBox.Size = new System.Drawing.Size(215, 25);
            this.playerNameTextBox.TabIndex = 0;
            // 
            // completeButton
            // 
            this.completeButton.Location = new System.Drawing.Point(385, 125);
            this.completeButton.Name = "completeButton";
            this.completeButton.Size = new System.Drawing.Size(95, 37);
            this.completeButton.TabIndex = 1;
            this.completeButton.Text = "입력";
            this.completeButton.UseVisualStyleBackColor = true;
            this.completeButton.Click += new System.EventHandler(this.completeButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("양재소슬체S", 30F);
            this.titleLabel.ForeColor = System.Drawing.Color.Snow;
            this.titleLabel.Location = new System.Drawing.Point(178, 57);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(257, 50);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "순위 변동!";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("양재소슬체S", 15F);
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(28, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "닉네임 : ";
            // 
            // InputRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.completeButton);
            this.Controls.Add(this.playerNameTextBox);
            this.Name = "InputRecordForm";
            this.Text = "iputRecordForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.iputRecordForm_FormClosing);
            this.Load += new System.EventHandler(this.iputRecordForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.iputRecordForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox playerNameTextBox;
        private System.Windows.Forms.Button completeButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label label1;
    }
}