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


        const int BOX_Y = 440;
        const int CROC_Y = 400;
        const int COIN_Y = 400;
        const int speed = 220;

        public const int TAG_NOTHING = 0;
        public const int TAG_RED = 1;
        public const int TAG_BLUE = 2;
        public const int TAG_GREEN = 3;

        List<GameObject> objects = new List<GameObject>();

        private void InitMissle() {
            for (int q = 0; q < 10; q++)
            {
                List<string> ls = new List<string>();
                string fileName = "Pattern";
                fileName += q + ".txt";
                StreamReader sr = new StreamReader(@"D:\1.산기대\4-1학기\윈플\텀프준비\csharpConsole\csharpConsole\Resources\Pattern\" + fileName);
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
            float y = 0;
            if (objects.Count > 0)
            {
                var obj = objects[objects.Count - 1];
                var bounds = obj.bounds;
                y = bounds.Bottom - obj.sizeDiff;
            }

            if (y < 610)
            {
                appendObject(y);
            }
            int dy = speed * msec / 1000;
            foreach (var obj in objects)
            {
                obj.move(0, dy);
                obj.updateFrame(msec);
            }
        }

        private void appendObject(float y)
        {
            /*
            GameObject obj;
            float x;
            int randomNum = new Random().Next(3);
            if (randomNum == 0)
            {
                obj = new AnimObject(윈플텀프.Properties.Resources.RedObject, 3, 4.0f);
                obj.tag = TAG_RED;
                x = CROC_Y;
            }
            else if (randomNum == 1)
            {
                obj = new AnimObject(윈플텀프.Properties.Resources.BlueObject, 3, 4.0f);
                obj.tag = TAG_BLUE;
                x = COIN_Y;
            }
            else
            {
                obj = new AnimObject(윈플텀프.Properties.Resources.GreenObject, 3, 4.0f);
                obj.tag = TAG_BLUE;
                x = CROC_Y + 30;
            }
            obj.setPosition(x, y);
            objects.Add(obj);
            */
            GameObject obj;
            float x;
            int randomNum = new Random().Next(3);
            if (randomNum == 0)
            {
                obj = new AnimObject(윈플텀프.Properties.Resources.RedObject, 3, 4.0f);
                obj.tag = TAG_RED;
                x = CROC_Y;
            }
            else if (randomNum == 1)
            {
                obj = new AnimObject(윈플텀프.Properties.Resources.BlueObject, 3, 4.0f);
                obj.tag = TAG_BLUE;
                x = COIN_Y;
            }
            else
            {
                obj = new AnimObject(윈플텀프.Properties.Resources.GreenObject, 3, 4.0f);
                obj.tag = TAG_BLUE;
                x = CROC_Y + 30;
            }
            obj.setPosition(x, y);
            objects.Add(obj);
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
