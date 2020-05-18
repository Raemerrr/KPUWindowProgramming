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

namespace KPUWindowProgramming
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
            string folderPath = "./Resources";
            DirectoryInfo di = new DirectoryInfo(folderPath);
            string filePath = folderPath + "/Record.txt";
            try
            {
                //디렉토리가 없다면 생성
                if (!di.Exists)
                {
                    di.Create();
                }
                //랭킹 등록 파일이 없다면 생성
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }
                StreamReader sr = new StreamReader(filePath);
                while (sr.Peek() > -1)
                {
                    string inputWord = sr.ReadLine();
                    playerRecord.Add(inputWord);
                    string[] temp = inputWord.Split(' ');
                    playerRecordScore.Add(Int32.Parse(temp[1]));
                }
                sr.Close();
                //MessageBox.Show("playerRecord Size : " + playerRecord.Count.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                MessageBox.Show("파일생성");
                File.Create(filePath).Close();
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
            bgImage = KPUWindowProgramming.Properties.Resources.BackGround;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            System.Windows.Forms.Application.Exit();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bgImage, 0, 0, Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
        }
    }
}
