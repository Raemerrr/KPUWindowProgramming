using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        Missile Missile;
        private void GameForm_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            bgImage = 윈플텀프.Properties.Resources.BackGround;
            Missile = new Missile();
            player = new Player();
            previousTime = DateTime.Now;

            active = true;
            player.isMoving = true;
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bgImage, 0, 0, Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            Missile.draw(e.Graphics);
            player.draw(e.Graphics);
        }

        bool active = false;
        DateTime previousTime;
        private void timer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var elapsed = now - previousTime;
            previousTime = now;
            var msec = (int)elapsed.TotalMilliseconds;
            if (!active)
            {
                return;
            }
            Missile.update(msec);
            player.updateFrame(msec);
            int tag = Missile.checkCollision(player);
            if (tag == Constants.TAG_BLUE)
            {
                //active = false;
            }
            //for (int i = 0; i < 30; i++)
            //{
            //    blueMissile[i].updateFrame(msec);
            //}
            //blueMissile.updateFrame(msec);
            Invalidate();

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

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            player.handleKeyUpEvent(e);
        }
    }
}
