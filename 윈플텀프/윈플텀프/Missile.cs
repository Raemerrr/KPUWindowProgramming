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
        public Missile() { InitMissle(); }
        List<List<string>> missileList = new List<List<string>>();
        const int BOX_Y = 440;
        const int CROC_Y = 400;
        const int COIN_Y = 400;
        const int speed = 220;

        public const int TAG_NOTHING = -1;
        public const int TAG_RED = 0;
        public const int TAG_BLUE = 1;
        public const int TAG_GREEN = 2;
        public const int TAG_HP = 3;
        public const int TAG_CLEAR = 4;

        List<GameObject> objects = new List<GameObject>();

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

            int dy = speed * msec / 1000;
            foreach (var obj in objects)
            {
                obj.move(0, dy);
                obj.updateFrame(msec);
            }
        }

        private void appendObject()
        {
            int randomNum = new Random().Next(10);
            for (int i = 0; i < missileList[randomNum].Count - 3; i += 3) 
            {
                GameObject obj;
                if (missileList[randomNum][i + 2] == "0")
                {
                    obj = new AnimObject(윈플텀프.Properties.Resources.RedObject, 3, 4.0f);
                    obj.tag = TAG_RED;
                }
                else if (missileList[randomNum][i + 2] == "1")
                {
                    obj = new AnimObject(윈플텀프.Properties.Resources.BlueObject, 3, 4.0f);
                    obj.tag = TAG_BLUE;
                }
                else if (missileList[randomNum][i + 2] == "2")
                {
                    obj = new AnimObject(윈플텀프.Properties.Resources.GreenObject, 3, 4.0f);
                    obj.tag = TAG_GREEN;
                }
                else if (missileList[randomNum][i + 2] == "3")
                {
                    obj = new AnimObject(윈플텀프.Properties.Resources.cHpObject, 1, 0.0f);
                    obj.tag = TAG_HP;
                }
                else
                {
                    obj = new AnimObject(윈플텀프.Properties.Resources.cClearObject, 1, 0.0f);
                    obj.tag = TAG_CLEAR;
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
                if (obj.tag == TAG_RED)
                {
                    if (obj.collides(player))
                    {
                        //removedCoin = obj;
                        objects.Remove(obj);
                        return TAG_RED;
                    }
                }
                else if (obj.tag == TAG_BLUE)
                {
                    if (obj.collides(player))
                    {
                        return TAG_BLUE;
                    }
                }
                else
                {
                    if (obj.collides(player))
                    {
                        return TAG_GREEN;
                    }
                }
            }
            return TAG_NOTHING;
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
