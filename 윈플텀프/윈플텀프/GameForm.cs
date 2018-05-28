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
        Missile Missile = new Missile();
        //GameObject[] blueMissile = new GameObject[30];
        private void GameForm_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(810, 610);
            bgImage = 윈플텀프.Properties.Resources.BackGround;
            player = new Player();
            previousTime = DateTime.Now;
            //for (int i = 0; i < 30; i++)
            //{
            //    blueMissile[i] = new AnimObject(윈플텀프.Properties.Resources.BlueObject, 3, 3.0f);
            //    blueMissile[i].setPosition(i*10,i*10);
            //}
            //blueMissile = new AnimObject(윈플텀프.Properties.Resources.BlueObject, 3, 3.0f);
            //blueMissile.setPosition(100,100);
            active = true;
            player.isMoving = true;
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bgImage, 0, 0, 810, 610);
            //blueMissile.draw(e.Graphics);
            //for (int i = 0; i < 30; i++)
            //{
            //    blueMissile[i].draw(e.Graphics);
            //}
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
            player.updateFrame(msec);
            Missile.update(msec);
            int tag = Missile.checkCollision(player);
            if (tag == Missile.TAG_BLUE)
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
