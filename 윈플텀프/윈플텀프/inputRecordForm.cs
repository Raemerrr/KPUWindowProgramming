using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace 윈플텀프
{
    public partial class InputRecordForm : Form
    {
        public InputRecordForm()
        {
            InitializeComponent();
        }

        Bitmap bgImage;
        private void iputRecordForm_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(Constants.SCREEN_WIDTH/2, Constants.SCREEN_HEIGHT/2);
            bgImage = 윈플텀프.Properties.Resources.BackGround;
          
        }

        private void iputRecordForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bgImage, 0, 0, Constants.SCREEN_WIDTH/2, Constants.SCREEN_HEIGHT/2);
        }

        private void iputRecordForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void completeButton_Click(object sender, EventArgs e)
        {
            GameForm.recordName = playerNameTextBox.Text;
            this.Visible = false;
            this.Dispose();
            if (GameForm.playerIndex < 3)
            {
                MainForm.playerRecord.Insert(GameForm.playerIndex, (GameForm.recordName + "- " + GameForm.score.ToString()));
                MainForm.playerRecord.RemoveAt(MainForm.playerRecord.Count - 1);
            }
            try
            {
                StreamWriter sw = new StreamWriter("./Resources/Record.txt");
                for (int i = 0; i < MainForm.playerRecord.Count; i++)
                {
                    sw.WriteLine(MainForm.playerRecord[i]);
                }
                sw.Close();
                sw.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            LoseForm loseForm = new LoseForm();
            loseForm.Show();
        }
    }
}
