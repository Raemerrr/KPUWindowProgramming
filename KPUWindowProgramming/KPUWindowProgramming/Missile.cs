using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPUWindowProgramming
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
                List<string> pattern = new List<string>() { "Pattern0", "Pattern1", "Pattern2", "Pattern3", "Pattern4", "Pattern5", "Pattern6", "Pattern7", "Pattern8", "Pattern9" };
                //조금이나마 지저분한 부분을 수정했으나, 리소스 파일들이 늘어날 경우 리소스의 모든 것을 탐색하기엔 무리가 있다.
                ResourceSet resourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
                foreach (DictionaryEntry entry in resourceSet)
                {
                    string resourceKey = entry.Key.ToString();
                    if (pattern.Contains(resourceKey))
                    {
                        List<string> ls = new List<string>();
                        object resource = entry.Value;
                        string line = resource.ToString().Replace("\r\n", "\t");
                        string[] temp = line.Split('\t');
                        foreach (var item in temp)
                        {
                            ls.Add(item);
                        }
                        missileList.Add(ls);
                    }
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

            int speed = Constants.MISSILE_SPEED * msec / 1000;
            foreach (var obj in Hobjects)
            {
                obj.move(0, speed);
                obj.updateFrame(msec);
            }
            foreach (var obj in Wobjects)
            {
                obj.move((speed + 2), 0);
                obj.updateFrame(msec);
            }
            foreach (var obj in _Wobjects)
            {
                obj.move(-(speed + 2), 0);
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
                        obj = new AnimObject(KPUWindowProgramming.Properties.Resources.RedObject, 3, 4.0f);
                        obj.tag = Constants.TAG_RED;
                    }
                    else if (missileList[randomNum][i + 2] == Constants.TAG_BLUE.ToString())
                    {
                        obj = new AnimObject(KPUWindowProgramming.Properties.Resources.BlueObject, 3, 4.0f);
                        obj.tag = Constants.TAG_BLUE;
                    }
                    else if (missileList[randomNum][i + 2] == Constants.TAG_GREEN.ToString())
                    {
                        obj = new AnimObject(KPUWindowProgramming.Properties.Resources.GreenObject, 3, 4.0f);
                        obj.tag = Constants.TAG_GREEN;
                    }
                    else if (missileList[randomNum][i + 2] == Constants.TAG_HP.ToString())
                    {
                        obj = new GameObject(KPUWindowProgramming.Properties.Resources.cHpObject);
                        obj.tag = Constants.TAG_HP;
                    }
                    else
                    {
                        obj = new GameObject(KPUWindowProgramming.Properties.Resources.cClearObject);
                        obj.tag = Constants.TAG_CLEAR;
                    }
                    obj.setPosition(float.Parse(missileList[randomNum][i]), float.Parse(missileList[randomNum][i + 1]));
                    Hobjects.Add(obj);
                }
            }
            if (GameForm.gameRound >= 3)
            {
                Random r = new Random(DateTime.Now.Millisecond * 2);
                int randomNum = r.Next(Constants.MAX_PATTERN);
                for (int i = 0; i < missileList[randomNum].Count - 3; i += 3)
                {
                    GameObject obj;
                    if (missileList[randomNum][i + 2] == Constants.TAG_RED.ToString())
                    {
                        obj = new AnimObject(KPUWindowProgramming.Properties.Resources.RedObject, 3, 4.0f);
                        obj.tag = Constants.TAG_RED;
                    }
                    else if (missileList[randomNum][i + 2] == Constants.TAG_BLUE.ToString())
                    {
                        obj = new AnimObject(KPUWindowProgramming.Properties.Resources.BlueObject, 3, 4.0f);
                        obj.tag = Constants.TAG_BLUE;
                    }
                    else if (missileList[randomNum][i + 2] == Constants.TAG_GREEN.ToString())
                    {
                        obj = new AnimObject(KPUWindowProgramming.Properties.Resources.GreenObject, 3, 4.0f);
                        obj.tag = Constants.TAG_GREEN;
                    }
                    else if (missileList[randomNum][i + 2] == Constants.TAG_HP.ToString())
                    {
                        obj = new GameObject(KPUWindowProgramming.Properties.Resources.cHpObject);
                        obj.tag = Constants.TAG_HP;
                    }
                    else
                    {
                        obj = new GameObject(KPUWindowProgramming.Properties.Resources.cClearObject);
                        obj.tag = Constants.TAG_CLEAR;
                    }
                    obj.setPosition(float.Parse(missileList[randomNum][i + 1]) - 100, float.Parse(missileList[randomNum][i]));
                    Wobjects.Add(obj);
                }
            }
            if (GameForm.gameRound >= 6)
            {
                Random r = new Random(DateTime.Now.Millisecond * 3);
                int randomNum = r.Next(Constants.MAX_PATTERN);
                for (int i = 0; i < missileList[randomNum].Count - 3; i += 3)
                {
                    GameObject obj;
                    if (missileList[randomNum][i + 2] == Constants.TAG_RED.ToString())
                    {
                        obj = new AnimObject(KPUWindowProgramming.Properties.Resources.RedObject, 3, 4.0f);
                        obj.tag = Constants.TAG_RED;
                    }
                    else if (missileList[randomNum][i + 2] == Constants.TAG_BLUE.ToString())
                    {
                        obj = new AnimObject(KPUWindowProgramming.Properties.Resources.BlueObject, 3, 4.0f);
                        obj.tag = Constants.TAG_BLUE;
                    }
                    else if (missileList[randomNum][i + 2] == Constants.TAG_GREEN.ToString())
                    {
                        obj = new AnimObject(KPUWindowProgramming.Properties.Resources.GreenObject, 3, 4.0f);
                        obj.tag = Constants.TAG_GREEN;
                    }
                    else if (missileList[randomNum][i + 2] == Constants.TAG_HP.ToString())
                    {
                        obj = new GameObject(KPUWindowProgramming.Properties.Resources.cHpObject);
                        obj.tag = Constants.TAG_HP;
                    }
                    else
                    {
                        obj = new GameObject(KPUWindowProgramming.Properties.Resources.cClearObject);
                        obj.tag = Constants.TAG_CLEAR;
                    }
                    obj.setPosition(float.Parse(missileList[randomNum][i + 1]) + ((Constants.SCREEN_WIDTH * 2) + 10), float.Parse(missileList[randomNum][i]));
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
                        player.playerHp -= 1;
                        _Wobjects.Remove(obj);
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