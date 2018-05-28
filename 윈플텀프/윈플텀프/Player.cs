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
        enum Direction { Right, Left, Up, Down, Right_Up, Right_Down, Left_Up, Left_Down, NONE };
        private const int INIT_X = 30;
        private const int INIT_Y = 250;
        private const int MOVE_SPEED = 10;
        bool[] inputCheck = new bool[4] { false, false, false, false };
        private const int GRAVITY = 1600;

        public bool isMoving = false;

        public Player() : base(윈플텀프.Properties.Resources.Player, 3, 4.0f)
        {
            setPosition(INIT_X, INIT_Y);
        }

        public override RectangleF collisionBounds
        {
            get
            {
                RectangleF rect = this.rect;
                rect.Inflate(-50, -10);
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
                if (rect.X < (810 - MOVE_SPEED - rect.Width))
                {
                    move(MOVE_SPEED, 0);
                }
            }
            if (inputCheck[Convert.ToInt32(Direction.Left)])
            {
                if (rect.X > (0 + MOVE_SPEED))
                {
                    move(-MOVE_SPEED, 0);
                }
            }
            if (inputCheck[Convert.ToInt32(Direction.Up)])
            {
                if (rect.Y > (0 + MOVE_SPEED))
                {
                    move(0, -MOVE_SPEED);
                }
            }
            if (inputCheck[Convert.ToInt32(Direction.Down)])
            {
                //화면크기 
                if (rect.Y < (610 - MOVE_SPEED - rect.Height))
                {
                    move(0, MOVE_SPEED);
                }
            }
        }
    }
}
