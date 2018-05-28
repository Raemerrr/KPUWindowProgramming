namespace 윈플텀프
{
    partial class LoseForm
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("양재소슬체S", 30F);
            this.titleLabel.ForeColor = System.Drawing.Color.Snow;
            this.titleLabel.Location = new System.Drawing.Point(390, 121);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(136, 50);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Lose!!";
            // 
            // mainButton
            // 
            this.mainButton.BackColor = System.Drawing.Color.Transparent;
            this.mainButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mainButton.Font = new System.Drawing.Font("양재튼튼체B", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mainButton.ForeColor = System.Drawing.SystemColors.Control;
            this.mainButton.Location = new System.Drawing.Point(677, 453);
            this.mainButton.Name = "mainButton";
            this.mainButton.Size = new System.Drawing.Size(230, 70);
            this.mainButton.TabIndex = 2;
            this.mainButton.Text = "MAIN MENU";
            this.mainButton.UseVisualStyleBackColor = false;
            this.mainButton.Click += new System.EventHandler(this.mainButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exitButton.Font = new System.Drawing.Font("양재튼튼체B", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.exitButton.ForeColor = System.Drawing.SystemColors.Control;
            this.exitButton.Location = new System.Drawing.Point(677, 544);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(230, 70);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "EXIT";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // LoseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::윈플텀프.Properties.Resources.BackGround;
            this.ClientSize = new System.Drawing.Size(992, 763);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.mainButton);
            this.Controls.Add(this.titleLabel);
            this.Name = "LoseForm";
            this.Text = "LoseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button mainButton;
        private System.Windows.Forms.Button exitButton;
    }
}