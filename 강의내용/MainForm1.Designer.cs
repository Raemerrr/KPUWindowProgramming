namespace HelloCSharp
{
    partial class MainForm1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.apple_Button = new System.Windows.Forms.RadioButton();
            this.pear_Button = new System.Windows.Forms.RadioButton();
            this.strawberry_Button3 = new System.Windows.Forms.RadioButton();
            this.banana_Button = new System.Windows.Forms.RadioButton();
            this.displayLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // apple_Button
            // 
            this.apple_Button.AutoSize = true;
            this.apple_Button.Location = new System.Drawing.Point(74, 128);
            this.apple_Button.Name = "apple_Button";
            this.apple_Button.Size = new System.Drawing.Size(58, 19);
            this.apple_Button.TabIndex = 0;
            this.apple_Button.TabStop = true;
            this.apple_Button.Text = "사과";
            this.apple_Button.UseVisualStyleBackColor = true;
            this.apple_Button.CheckedChanged += new System.EventHandler(this.fruitRadio_CheckedChanged);
            // 
            // pear_Button
            // 
            this.pear_Button.AutoSize = true;
            this.pear_Button.Location = new System.Drawing.Point(305, 128);
            this.pear_Button.Name = "pear_Button";
            this.pear_Button.Size = new System.Drawing.Size(43, 19);
            this.pear_Button.TabIndex = 1;
            this.pear_Button.TabStop = true;
            this.pear_Button.Text = "배";
            this.pear_Button.UseVisualStyleBackColor = true;
            this.pear_Button.CheckedChanged += new System.EventHandler(this.fruitRadio_CheckedChanged);
            // 
            // strawberry_Button3
            // 
            this.strawberry_Button3.AutoSize = true;
            this.strawberry_Button3.Location = new System.Drawing.Point(74, 217);
            this.strawberry_Button3.Name = "strawberry_Button3";
            this.strawberry_Button3.Size = new System.Drawing.Size(58, 19);
            this.strawberry_Button3.TabIndex = 2;
            this.strawberry_Button3.TabStop = true;
            this.strawberry_Button3.Text = "딸기";
            this.strawberry_Button3.UseVisualStyleBackColor = true;
            this.strawberry_Button3.CheckedChanged += new System.EventHandler(this.fruitRadio_CheckedChanged);
            // 
            // banana_Button
            // 
            this.banana_Button.AutoSize = true;
            this.banana_Button.Location = new System.Drawing.Point(305, 217);
            this.banana_Button.Name = "banana_Button";
            this.banana_Button.Size = new System.Drawing.Size(73, 19);
            this.banana_Button.TabIndex = 3;
            this.banana_Button.TabStop = true;
            this.banana_Button.Text = "바나나";
            this.banana_Button.UseVisualStyleBackColor = true;
            this.banana_Button.CheckedChanged += new System.EventHandler(this.fruitRadio_CheckedChanged);
            // 
            // displayLabel
            // 
            this.displayLabel.AutoSize = true;
            this.displayLabel.Location = new System.Drawing.Point(196, 261);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(67, 15);
            this.displayLabel.TabIndex = 4;
            this.displayLabel.Text = "과일이름";
            // 
            // MainForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 319);
            this.Controls.Add(this.displayLabel);
            this.Controls.Add(this.banana_Button);
            this.Controls.Add(this.strawberry_Button3);
            this.Controls.Add(this.pear_Button);
            this.Controls.Add(this.apple_Button);
            this.Name = "MainForm1";
            this.Text = "Hello World!!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton apple_Button;
        private System.Windows.Forms.RadioButton pear_Button;
        private System.Windows.Forms.RadioButton strawberry_Button3;
        private System.Windows.Forms.RadioButton banana_Button;
        private System.Windows.Forms.Label displayLabel;
    }
}

