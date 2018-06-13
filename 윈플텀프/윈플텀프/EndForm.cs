using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 윈플텀프
{
    public partial class EndForm : Form
    {
        public EndForm()
        {
            InitializeComponent();
            recordRank();
        }
        Bitmap bgImage;

        private void recordRank()
        {
            if (GameForm.winCheck)
            {
                titleLabel.Text = "Win!!";
            }
            else
            {
                titleLabel.Text = "Lose!!";
            }
            for (int i = 0; i < MainForm.playerRecord.Count; i++)
            {
                Label rank = new Label();
                rank.Name = "rankLabel" + i.ToString();
                //rank.Size = new Size(500,50);
                rank.AutoSize = true;
                rank.Location = new Point(336, 313 + (i * 50));
                rank.Text = MainForm.playerRecord[i];
                rank.Font = new Font("양재깨비체B", 24, FontStyle.Bold);
                rank.BackColor = Color.Transparent;
                rank.ForeColor = Color.Snow;
                this.Controls.Add(rank);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void EndForm_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(Constants.SCREEN_WIDTH - 200, Constants.SCREEN_HEIGHT);
            bgImage = 윈플텀프.Properties.Resources.BackGround;

        }

        private void EndForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bgImage, 0, 0, Constants.SCREEN_WIDTH - 200, Constants.SCREEN_HEIGHT);
        }
    }
}
