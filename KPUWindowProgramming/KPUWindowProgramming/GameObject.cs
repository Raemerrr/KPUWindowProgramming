using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPUWindowProgramming
{
    class GameObject
    {
        protected Bitmap bitmap;
        protected RectangleF rect;
        public int tag = 0;
        public float sizeDiff = 0.0f;

        public GameObject(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            Size size = bitmap.Size;
            rect = new RectangleF(0, 0, size.Width, size.Height);
        }

        public RectangleF bounds
        {
            get
            {
                return rect;
            }
        }

        public virtual RectangleF collisionBounds
        {
            get
            {
                return rect;
            }
        }

        public void setPosition(float x, float y)
        {
            rect.X = x;
            rect.Y = y;
        }

        public RectangleF getPosition()
        {
            return rect;
        }

        public virtual void draw(Graphics g)
        {
            g.DrawImage(bitmap, rect);
        }

        public void move(float dx, float dy)
        {
            rect.X += dx;
            rect.Y += dy;
        }

        public bool collides(GameObject other)
        {
            return this.collisionBounds.IntersectsWith(other.collisionBounds);
        }

        public virtual void handleKeyDownEvent(Keys keyCode) { }
        public virtual void handleKeyUpEvent(Keys keyCode) { }
        public virtual void updateFrame(int msec) { }
    }
}
