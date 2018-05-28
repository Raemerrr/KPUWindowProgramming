using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 윈플텀프
{
    class Player : AnimObject
    {
        enum Direction { Right, Left, Up, Down, NONE };
        bool[] inputCheck = new bool[4] { false, false, false, false };
        public bool isMoving = false;
        bool temp = false;
        public Player() : base(윈플텀프.Properties.Resources.Player, 3, 0.0f)
        {
            setPosition(Constants.PLAYER_INIT_X, Constants.PLAYER_INIT_Y);
        }

        public override RectangleF collisionBounds
        {
            get
            {
                RectangleF rect = this.rect;
                return rect;
            }
        }
        
        public override void updateFrame(int msec)
        {
            base.updateFrame(msec);
        }

        public void handleKeyUpEvent(KeyEventArgs keyCode)
        {
            if (keyCode.KeyCode == Keys.Right)
            {
                inputCheck[Convert.ToInt32(Direction.Right)] = false;
            }
            if (keyCode.KeyCode == Keys.Left)
            {
                inputCheck[Convert.ToInt32(Direction.Left)] = false;
            }
            if (keyCode.KeyCode == Keys.Up)
            {
                inputCheck[Convert.ToInt32(Direction.Up)] = false;
            }
            if (keyCode.KeyCode == Keys.Down)
            {
                inputCheck[Convert.ToInt32(Direction.Down)] = false;
            }
            else
            {
                //아무 작업을 하지 않기위해.
            }
            startMoving();
        }

        public void handleKeyDownEvent(KeyEventArgs keyCode)
        {
            if (keyCode.KeyCode == Keys.Right)
            {
                inputCheck[Convert.ToInt32(Direction.Right)] = true;
            }
            if (keyCode.KeyCode == Keys.Left)
            {
                inputCheck[Convert.ToInt32(Direction.Left)] = true;
            }
            if (keyCode.KeyCode == Keys.Up)
            {
                inputCheck[Convert.ToInt32(Direction.Up)] = true;
            }
            if (keyCode.KeyCode == Keys.Down)
            {
                inputCheck[Convert.ToInt32(Direction.Down)] = true;
            }

            if (keyCode.KeyCode == Keys.Q)
            {
                // frameCount = 0;
                index = 0;
            }
            if (keyCode.KeyCode == Keys.W)
            {
                index = 1;
                //frameCount = 1;
            }
            if (keyCode.KeyCode == Keys.E)
            {
                //frameCount = 2;
                index = 2;
            }

            else
            {
                //아무 작업을 하지 않기위해.
            }
            startMoving();
        }

        private void startMoving()
        {
            if (inputCheck[Convert.ToInt32(Direction.Right)])
            {
                //화면크기 
                if (rect.X < (Constants.SCREEN_WIDTH - 10 - Constants.PLAYER_SPEED - rect.Width))
                {
                    move(Constants.PLAYER_SPEED, 0);
                }
            }
            if (inputCheck[Convert.ToInt32(Direction.Left)])
            {
                if (rect.X > (0 + Constants.PLAYER_SPEED))
                {
                    move(-Constants.PLAYER_SPEED, 0);
                }
            }
            if (inputCheck[Convert.ToInt32(Direction.Up)])
            {
                if (rect.Y > (0 + Constants.PLAYER_SPEED))
                {
                    move(0, -Constants.PLAYER_SPEED);
                }
            }
            if (inputCheck[Convert.ToInt32(Direction.Down)])
            {
                //화면크기 
                if (rect.Y < (Constants.SCREEN_HEIGHT - Constants.PLAYER_SPEED - rect.Height))
                {
                    move(0, Constants.PLAYER_SPEED);
                }
            }
        }
    }
}
