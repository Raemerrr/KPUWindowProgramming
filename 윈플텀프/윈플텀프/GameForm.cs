using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace 윈플텀프
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }
        Player player;
        Bitmap bgImage;
        Missile missile;
        List<GameObject> hpMarkList = new List<GameObject>();
        public static int score;
        public static int playerIndex;
        public static string recordName = "임시용- ";
        private void GameForm_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            bgImage = 윈플텀프.Properties.Resources.BackGround;
            missile = new Missile();
            player = new Player();
            previousTime = DateTime.Now;

            for (int i = 0; i < Constants.PLAYER_INIT_HP; i++)
            {
                GameObject hpMark = new GameObject(윈플텀프.Properties.Resources.HpMark);
                hpMark.setPosition(i * 55, i);
                hpMarkList.Add(hpMark);
            }
            active = true;
            player.isMoving = true;
            timer.Enabled = true;
            score = 0;
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bgImage, 0, 0, Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            missile.draw(e.Graphics);
            player.draw(e.Graphics);
            foreach (GameObject hpObj in hpMarkList)
            {
                hpObj.draw(e.Graphics);
            }
        }

        bool active = false;
        DateTime previousTime;
        bool recordFlag = false;
        private void timer_Tick(object sender, EventArgs e)
        {
            score++;
            timeLabel.Text = "SCORE : " + score.ToString();
            var now = DateTime.Now;
            var elapsed = now - previousTime;
            previousTime = now;
            var msec = (int)elapsed.TotalMilliseconds;
            if (!active)
            {
                return;
            }
            missile.update(msec);
            player.updateFrame(msec);
            int tag = missile.checkCollision(player);
            if (tag == player.playerColor)
            {
                score += 20;
            }
            else if (tag == Constants.TAG_BLUE && player.playerColor != Constants.TAG_BLUE)
            {
                if (hpMarkList.Count > 0)
                {
                    hpMarkList.RemoveAt(hpMarkList.Count - 1);
                }
            }
            else if (tag == Constants.TAG_RED && player.playerColor != Constants.TAG_RED)
            {
                if (hpMarkList.Count > 0)
                {
                    hpMarkList.RemoveAt(hpMarkList.Count - 1);
                }
            }
            else if (tag == Constants.TAG_GREEN && player.playerColor != Constants.TAG_GREEN)
            {
                if (hpMarkList.Count > 0)
                {
                    hpMarkList.RemoveAt(hpMarkList.Count - 1);
                }
            }
            else if (tag == Constants.TAG_HP)
            {
                if (hpMarkList.Count < 3)
                {
                    GameObject hpMark = new GameObject(윈플텀프.Properties.Resources.HpMark);
                    hpMark.setPosition(hpMarkList.Count * 55, 0);
                    hpMarkList.Add(hpMark);
                }
            }
            Invalidate();
            if (hpMarkList.Count <= 0)
            {
                timer.Enabled = false;
                timer.Dispose();
                for (int i = 0; i < MainForm.playerRecordScore.Count; i++)
                {
                    if (score > MainForm.playerRecordScore[i])
                    {
                        InputRecordForm inputForm = new InputRecordForm();
                        inputForm.Show();
                        playerIndex = i;
                        recordFlag = true;
                        return;
                    }
                }
                if (!recordFlag)
                {
                    this.Dispose();
                    this.Visible = false;
                    LoseForm loseForm = new LoseForm();
                    loseForm.Show();
                }
            }
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            player.handleKeyUpEvent(e);
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            player.handleKeyDownEvent(e);
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            player.isMoving = false;
        }
    }
}
