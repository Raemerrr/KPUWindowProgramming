using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 윈플텀프
{
    class Missile 
    {
        List<List<string>> missileList = new List<List<string>>();
        List<GameObject> objects = new List<GameObject>();

        public Missile()
        {
            InitMissle();
        }

        private void InitMissle() {
            for (int q = 0; q < 10; q++)
            {
                List<string> ls = new List<string>();
                string fileName = "Pattern";
                fileName += q + ".txt";
                StreamReader sr = new StreamReader(@"D:\SorceTree\윈도우즈프로그래밍\윈플텀프\윈플텀프\Resources\Pattern\" + fileName);
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

        public void update(int msec)
        {
            while (objects.Count > 0)
            {
                GameObject first = objects[0];
                var bounds = first.bounds;
                if (bounds.Bottom > 610)
                {
                    objects.RemoveAt(0);
                }
                else
                {
                    break;
                }
            }

            if (objects.Count <= 0)
            {
                appendObject();
            }
            //else
            //{
            //    foreach (var obj in objects)
            //    {
            //        if (obj.bounds.Bottom > 610)
            //        {
            //            objects.Remove(obj);
            //        }
            //    }
            //}

            int dy = Constants.MISSILE_SPEED * msec / 1000;
            foreach (var obj in objects)
            {
                obj.move(0, dy);
                obj.updateFrame(msec);
            }
        }

        private void appendObject()
        {
            int randomNum = new Random().Next(Constants.MAX_PATTERN);
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
                objects.Add(obj);
            }
        }

        public int checkCollision(Player player)
        {
            //GameObject removedCoin = null;
            foreach (GameObject obj in objects)
            {
                if (obj.tag == Constants.TAG_RED)
                {
                    if (obj.collides(player))
                    {
                        //removedCoin = obj;
                        objects.Remove(obj);
                        return Constants.TAG_RED;
                    }
                }
                else if (obj.tag == Constants.TAG_BLUE)
                {
                    if (obj.collides(player))
                    {
                        return Constants.TAG_BLUE;
                    }
                }
                else
                {
                    if (obj.collides(player))
                    {
                        return Constants.TAG_GREEN;
                    }
                }
            }
            return Constants.TAG_NOTHING;
            //if (removedCoin != null) {
            //    //playSOUnd();
            //}
        }

        public void draw(Graphics g)
        {
            foreach (var obj in objects)
            {
                obj.draw(g);
            }
        }
    }
}
