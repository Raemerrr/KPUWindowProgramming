﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 윈플텀프
{
    class Missile
    {
        List<List<string>> missileList = new List<List<string>>();
        List<GameObject> Hobjects = new List<GameObject>();
        List<GameObject> Wobjects = new List<GameObject>();
        List<GameObject> _Wobjects = new List<GameObject>();

        public Missile()
        {
            InitMissle();
        }

        private void InitMissle()
        {
            try
            {
                for (int q = 0; q < 10; q++)
                {
                    List<string> ls = new List<string>();
                    string fileName = "Pattern";
                    fileName += q + ".txt";
                    StreamReader sr = new StreamReader("./Resources/Pattern/" + fileName);
                    while (sr.Peek() > -1)
                    {
                        string inputWord = sr.ReadLine();
                        string[] temp = inputWord.Split('\t');
                        foreach (var item in temp)
                        {
                            ls.Add(item);
                        }
                    }
                    missileList.Add(ls);
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public void update(int msec)
        {
            for (int i = Hobjects.Count - 1; i >= 0; i--)
            {
                GameObject o = Hobjects[i];
                var bounds = o.bounds;
                if (bounds.Bottom > Constants.SCREEN_HEIGHT)
                {
                    Hobjects.RemoveAt(i);
                }
            }

            for (int i = Wobjects.Count - 1; i >= 0; i--)
            {
                GameObject o = Wobjects[i];
                var bounds = o.bounds;
                if (bounds.Left > Constants.SCREEN_WIDTH)
                {
                    Wobjects.RemoveAt(i);
                }
            }

            for (int i = _Wobjects.Count - 1; i >= 0; i--)
            {
                GameObject o = _Wobjects[i];
                var bounds = o.bounds;
                if (bounds.Left < 0)
                {
                    _Wobjects.RemoveAt(i);
                }
            }

            if (Hobjects.Count <= 0 && Wobjects.Count <= 0 && _Wobjects.Count <= 0)
            {
                GameForm.gameRound++;
                appendObject();
            }

            int dy = Constants.MISSILE_SPEED * msec / 1000;
            foreach (var obj in Hobjects)
            {
                obj.move(0, dy);
                obj.updateFrame(msec);
            }
            foreach (var obj in Wobjects)
            {
                obj.move(dy + 2, 0);
                obj.updateFrame(msec);
            }
            foreach (var obj in _Wobjects)
            {
                obj.move(-(dy + 2), 0);
                obj.updateFrame(msec);
            }
        }

        private void appendObject()
        {
            if (GameForm.gameRound >= 1)
            {
                Random r = new Random(DateTime.Now.Millisecond);
                int randomNum = r.Next(Constants.MAX_PATTERN);
                for (int i = 0; i < missileList[randomNum].Count - 3; i += 3)
                {
                    GameObject obj;
                    if (missileList[randomNum][i + 2] == Constants.TAG_RED.ToString())
                    {
                        obj = new AnimObject(윈플텀프.Properties.Resources.RedObject, 3, 4.0f);
                        obj.tag = Constants.TAG_RED;
                    }
                    else if (missileList[randomNum][i + 2] == Constants.TAG_BLUE.ToString())
                    {
                        obj = new AnimObject(윈플텀프.Properties.Resources.BlueObject, 3, 4.0f);
                        obj.tag = Constants.TAG_BLUE;
                    }
                    else if (missileList[randomNum][i + 2] == Constants.TAG_GREEN.ToString())
                    {
                        obj = new AnimObject(윈플텀프.Properties.Resources.GreenObject, 3, 4.0f);
                        obj.tag = Constants.TAG_GREEN;
                    }
                    else if (missileList[randomNum][i + 2] == Constants.TAG_HP.ToString())
                    {
                        obj = new GameObject(윈플텀프.Properties.Resources.cHpObject);
                        obj.tag = Constants.TAG_HP;
                    }
                    else
                    {
                        obj = new GameObject(윈플텀프.Properties.Resources.cClearObject);
                        obj.tag = Constants.TAG_CLEAR;
                    }
                    obj.setPosition(float.Parse(missileList[randomNum][i]), float.Parse(missileList[randomNum][i + 1]));
                    Hobjects.Add(obj);
                }
            }
            if (GameForm.gameRound >= 3)
            {
                Random r = new Random(DateTime.Now.Millisecond);
                int randomNum2 = r.Next(Constants.MAX_PATTERN);
                for (int i = 0; i < missileList[randomNum2].Count - 3; i += 3)
                {
                    GameObject obj;
                    if (missileList[randomNum2][i + 2] == Constants.TAG_RED.ToString())
                    {
                        obj = new AnimObject(윈플텀프.Properties.Resources.RedObject, 3, 4.0f);
                        obj.tag = Constants.TAG_RED;
                    }
                    else if (missileList[randomNum2][i + 2] == Constants.TAG_BLUE.ToString())
                    {
                        obj = new AnimObject(윈플텀프.Properties.Resources.BlueObject, 3, 4.0f);
                        obj.tag = Constants.TAG_BLUE;
                    }
                    else if (missileList[randomNum2][i + 2] == Constants.TAG_GREEN.ToString())
                    {
                        obj = new AnimObject(윈플텀프.Properties.Resources.GreenObject, 3, 4.0f);
                        obj.tag = Constants.TAG_GREEN;
                    }
                    else if (missileList[randomNum2][i + 2] == Constants.TAG_HP.ToString())
                    {
                        obj = new GameObject(윈플텀프.Properties.Resources.cHpObject);
                        obj.tag = Constants.TAG_HP;
                    }
                    else
                    {
                        obj = new GameObject(윈플텀프.Properties.Resources.cClearObject);
                        obj.tag = Constants.TAG_CLEAR;
                    }
                    obj.setPosition(float.Parse(missileList[randomNum2][i + 1]) - 100, float.Parse(missileList[randomNum2][i]));
                    Wobjects.Add(obj);
                }
            }
            if (GameForm.gameRound >= 6)
            {
                Random r = new Random(DateTime.Now.Millisecond);
                int randomNum2 = r.Next(Constants.MAX_PATTERN);
                for (int i = 0; i < missileList[randomNum2].Count - 3; i += 3)
                {
                    GameObject obj;
                    if (missileList[randomNum2][i + 2] == Constants.TAG_RED.ToString())
                    {
                        obj = new AnimObject(윈플텀프.Properties.Resources.RedObject, 3, 4.0f);
                        obj.tag = Constants.TAG_RED;
                    }
                    else if (missileList[randomNum2][i + 2] == Constants.TAG_BLUE.ToString())
                    {
                        obj = new AnimObject(윈플텀프.Properties.Resources.BlueObject, 3, 4.0f);
                        obj.tag = Constants.TAG_BLUE;
                    }
                    else if (missileList[randomNum2][i + 2] == Constants.TAG_GREEN.ToString())
                    {
                        obj = new AnimObject(윈플텀프.Properties.Resources.GreenObject, 3, 4.0f);
                        obj.tag = Constants.TAG_GREEN;
                    }
                    else if (missileList[randomNum2][i + 2] == Constants.TAG_HP.ToString())
                    {
                        obj = new GameObject(윈플텀프.Properties.Resources.cHpObject);
                        obj.tag = Constants.TAG_HP;
                    }
                    else
                    {
                        obj = new GameObject(윈플텀프.Properties.Resources.cClearObject);
                        obj.tag = Constants.TAG_CLEAR;
                    }
                    obj.setPosition(float.Parse(missileList[randomNum2][i + 1]) + ((Constants.SCREEN_WIDTH * 2) + 10), float.Parse(missileList[randomNum2][i]));
                    _Wobjects.Add(obj);
                }
            }
        }

        public int checkCollision(Player player)
        {
            //GameObject removedCoin = null;
            foreach (GameObject obj in Hobjects)
            {
                if (obj.tag == Constants.TAG_RED)
                {
                    if (obj.collides(player))
                    {
                        //removedCoin = obj;
                        Hobjects.Remove(obj);
                        player.playerHp -= 1;
                        return Constants.TAG_RED;
                    }
                }
                else if (obj.tag == Constants.TAG_BLUE)
                {
                    if (obj.collides(player))
                    {
                        player.playerHp -= 1;
                        Hobjects.Remove(obj);
                        return Constants.TAG_BLUE;
                    }
                }
                else if (obj.tag == Constants.TAG_GREEN)
                {
                    if (obj.collides(player))
                    {
                        player.playerHp -= 1;
                        Hobjects.Remove(obj);
                        return Constants.TAG_GREEN;
                    }
                }
                else if (obj.tag == Constants.TAG_HP)
                {
                    if (obj.collides(player))
                    {
                        player.playerHp += 1;
                        Hobjects.Remove(obj);
                        return Constants.TAG_HP;
                    }
                }
                else if (obj.tag == Constants.TAG_CLEAR)
                {
                    if (obj.collides(player))
                    {
                        Hobjects.Clear();
                        Wobjects.Clear();
                        _Wobjects.Clear();
                        return Constants.TAG_CLEAR;
                    }
                }
                else
                {
                    return Constants.TAG_NOTHING;
                }
            }
            foreach (GameObject obj in Wobjects)
            {
                if (obj.tag == Constants.TAG_RED)
                {
                    if (obj.collides(player))
                    {
                        //removedCoin = obj;
                        Wobjects.Remove(obj);
                        player.playerHp -= 1;
                        return Constants.TAG_RED;
                    }
                }
                else if (obj.tag == Constants.TAG_BLUE)
                {
                    if (obj.collides(player))
                    {
                        player.playerHp -= 1;
                        Wobjects.Remove(obj);
                        return Constants.TAG_BLUE;
                    }
                }
                else if (obj.tag == Constants.TAG_GREEN)
                {
                    if (obj.collides(player))
                    {
                        player.playerHp -= 1;
                        Wobjects.Remove(obj);
                        return Constants.TAG_GREEN;
                    }
                }
                else if (obj.tag == Constants.TAG_HP)
                {
                    if (obj.collides(player))
                    {
                        player.playerHp += 1;
                        Wobjects.Remove(obj);
                        return Constants.TAG_HP;
                    }
                }
                else if (obj.tag == Constants.TAG_CLEAR)
                {
                    if (obj.collides(player))
                    {
                        Wobjects.Clear();
                        Hobjects.Clear();
                        _Wobjects.Clear();
                        return Constants.TAG_CLEAR;
                    }
                }
                else
                {
                    return Constants.TAG_NOTHING;
                }
            }
            foreach (GameObject obj in _Wobjects)
            {
                if (obj.tag == Constants.TAG_RED)
                {
                    if (obj.collides(player))
                    {
                        //removedCoin = obj;
                        _Wobjects.Remove(obj);
                        player.playerHp -= 1;
                        return Constants.TAG_RED;
                    }
                }
                else if (obj.tag == Constants.TAG_BLUE)
                {
                    if (obj.collides(player))
                    {
                        player.playerHp -= 1;
                        _Wobjects.Remove(obj);
                        return Constants.TAG_BLUE;
                    }
                }
                else if (obj.tag == Constants.TAG_GREEN)
                {
                    if (obj.collides(player))
                    {
                        player.playerHp -= 1;
                        _Wobjects.Remove(obj);
                        return Constants.TAG_GREEN;
                    }
                }
                else if (obj.tag == Constants.TAG_HP)
                {
                    if (obj.collides(player))
                    {
                        player.playerHp += 1;
                        _Wobjects.Remove(obj);
                        return Constants.TAG_HP;
                    }
                }
                else if (obj.tag == Constants.TAG_CLEAR)
                {
                    if (obj.collides(player))
                    {
                        Wobjects.Clear();
                        Hobjects.Clear();
                        _Wobjects.Clear();
                        return Constants.TAG_CLEAR;
                    }
                }
                else
                {
                    return Constants.TAG_NOTHING;
                }
            }
            return Constants.TAG_NOTHING;
        }

        public void draw(Graphics g)
        {
            foreach (var obj in Hobjects)
            {
                obj.draw(g);
            }
            foreach (var obj in Wobjects)
            {
                obj.draw(g);
            }
            foreach (var obj in _Wobjects)
            {
                obj.draw(g);
            }
        }
    }
}