﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPUWindowProgramming
{
    class Player : AnimObject
    {
        enum Direction { Right, Left, Up, Down };
        bool[] inputCheck = new bool[Constants.PLAYER_DIRECTION] { false, false, false, false };
        public bool isMoving = false;
        int hp;
        public int playerColor = 0;
       
        public Player() : base(KPUWindowProgramming.Properties.Resources.Player2, 4, 0.0f)
        {
            hp = Constants.PLAYER_INIT_HP;
            setPosition(Constants.PLAYER_INIT_X, Constants.PLAYER_INIT_Y);
        }

        public int playerHp
        {
            set { hp = value; }
            get { return hp; }
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
            beginChange();
        }

        public void handleKeyUpEvent(KeyEventArgs keyCode)
        {
            if (keyCode.KeyCode == Keys.Right || keyCode.KeyCode == Keys.L)
            {
                inputCheck[Convert.ToInt32(Direction.Right)] = false;
            }
            if (keyCode.KeyCode == Keys.Left || keyCode.KeyCode == Keys.J)
            {
                inputCheck[Convert.ToInt32(Direction.Left)] = false;
            }
            if (keyCode.KeyCode == Keys.Up || keyCode.KeyCode == Keys.I)
            {
                inputCheck[Convert.ToInt32(Direction.Up)] = false;
            }
            if (keyCode.KeyCode == Keys.Down || keyCode.KeyCode == Keys.K)
            {
                inputCheck[Convert.ToInt32(Direction.Down)] = false;
            }
        }

        public void handleKeyDownEvent(KeyEventArgs keyCode)
        {
            if (keyCode.KeyCode == Keys.Right || keyCode.KeyCode == Keys.L)
            {
                inputCheck[Convert.ToInt32(Direction.Right)] = true;
            }
            if (keyCode.KeyCode == Keys.Left || keyCode.KeyCode == Keys.J)
            {
                inputCheck[Convert.ToInt32(Direction.Left)] = true;
            }
            if (keyCode.KeyCode == Keys.Up || keyCode.KeyCode == Keys.I)
            {
                inputCheck[Convert.ToInt32(Direction.Up)] = true;
            }
            if (keyCode.KeyCode == Keys.Down || keyCode.KeyCode == Keys.K)
            {
                inputCheck[Convert.ToInt32(Direction.Down)] = true;
            }

            //플레이어 색 입력
            if (keyCode.KeyCode == Keys.Q)
            {
                playerColor = Constants.TAG_RED;
            }else if (keyCode.KeyCode == Keys.W)
            {
                playerColor = Constants.TAG_BLUE;
            }else if (keyCode.KeyCode == Keys.E)
            {
                playerColor = Constants.TAG_GREEN;
            }
            else if (keyCode.KeyCode == Keys.Z)
            {
                playerColor = Constants.PLAYER_INVINCIBILITY;
            }
        }

        private void beginChange()
        {
            //AnimObject의 framesPerSecond 때문에 계속 0이 되기때문에 지속적으로 프레임마다 색 입력을 해줘야함
            index = playerColor;
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
