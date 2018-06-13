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
    public partial class MainForm : Form
    {
        public static List<string> playerRecord = new List<string>();
        public static List<int> playerRecordScore = new List<int>();
        public MainForm()
        {
            InitializeComponent();
            playerRecord.Clear();
            playerRecordScore.Clear();
            InitRecord();
        }
        private void InitRecord()
        {
            try
            {
                StreamReader sr = new StreamReader("./Resources/Record.txt");
                while (sr.Peek() > -1)
                {
                    string inputWord = sr.ReadLine();
                    playerRecord.Add(inputWord);
                    string[] temp = inputWord.Split(' ');
                    playerRecordScore.Add(Int32.Parse(temp[1]));
                }
                sr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        Bitmap bgImage;
        private void startButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            GameForm gameForm = new GameForm();
            gameForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            bgImage = 윈플텀프.Properties.Resources.BackGround;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bgImage, 0, 0, Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
        }
    }
}
