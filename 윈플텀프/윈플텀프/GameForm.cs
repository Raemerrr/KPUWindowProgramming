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
        public static int playerRankIndex;
        public static int gameRound;
        public static string recordName;
        public static bool winCheck;

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
            playerRankIndex = 0;
            gameRound = 0;
            recordName = string.Empty;
            winCheck = false;
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
        private void timer_Tick(object sender, EventArgs e)
        {
            score++;
            roundLabel.Text = "ROUND : " + gameRound.ToString();
            scoreLabel.Text = "SCORE : " + score.ToString();
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
                score += Constants.ADD_SCORE_NONE;
            }
            else if (tag == Constants.TAG_BLUE && player.playerColor != Constants.TAG_BLUE && player.playerColor != Constants.PLAYER_INVINCIBILITY)
            {
                if (hpMarkList.Count > 0)
                {
                    hpMarkList.RemoveAt(hpMarkList.Count - 1);
                }
            }
            else if (tag == Constants.TAG_RED && player.playerColor != Constants.TAG_RED && player.playerColor != Constants.PLAYER_INVINCIBILITY)
            {
                if (hpMarkList.Count > 0)
                {
                    hpMarkList.RemoveAt(hpMarkList.Count - 1);
                }
            }
            else if (tag == Constants.TAG_GREEN && player.playerColor != Constants.TAG_GREEN && player.playerColor != Constants.PLAYER_INVINCIBILITY)
            {
                if (hpMarkList.Count > 0)
                {
                    hpMarkList.RemoveAt(hpMarkList.Count - 1);
                }
            }
            else if (tag == Constants.TAG_HP)
            {
                score += Constants.ADD_SCORE_HP;
                if (hpMarkList.Count < Constants.PLAYER_INIT_HP)
                {
                    GameObject hpMark = new GameObject(윈플텀프.Properties.Resources.HpMark);
                    hpMark.setPosition(hpMarkList.Count * 55, 0);
                    hpMarkList.Add(hpMark);
                }
            }
            else if (tag == Constants.TAG_CLEAR)
            {
                //클리어 아이템은 라운드를 증가시키지 않음.
                gameRound--;
                score += Constants.ADD_SCORE_CLEAR;
            }
            Invalidate();
            //게임 완료 조건
            if (gameRound >= Constants.MAX_GAME_ROUND)
            {
                winCheck = true;
                GameForm_EndSetting();
            }
            //게임 실패 조건
            if (hpMarkList.Count <= 0)
            {
                winCheck = false;
                GameForm_EndSetting();
            }
        }
        private void GameForm_EndSetting()
        {
            timer.Enabled = false;
            timer.Dispose();

            if (MainForm.playerRecordScore.Count == 0)
            {
                this.Dispose();
                this.Visible = false;
                InputRecordForm inputForm = new InputRecordForm();
                inputForm.Show();
                return;
            }
            else
            {
                for (int i = 0; i < MainForm.playerRecordScore.Count; i++)
                {
                    if (score > MainForm.playerRecordScore[i])
                    {
                        this.Dispose();
                        this.Visible = false;
                        playerRankIndex = i;
                        InputRecordForm inputForm = new InputRecordForm();
                        inputForm.Show();
                        return;
                    }
                }
            }
            this.Dispose();
            this.Visible = false;
            EndForm endForm = new EndForm();
            endForm.Show();
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
            player.isMoving = false;
            this.Dispose();
            System.Windows.Forms.Application.Exit();
        }
    }
}
