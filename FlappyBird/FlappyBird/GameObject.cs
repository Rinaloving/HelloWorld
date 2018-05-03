using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public abstract class GameObject
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public GameObject(int x, int y, int width, int height) 
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        //move 方法 和 draw 方法
        //鸟是上下移动，管子是左右移动

        public abstract void Move();
        /// <summary>
        /// 绘制对象的抽象方法，具体怎么绘制，子类自己去重写
        /// </summary>
        /// <param name="g"></param>
        public abstract void Draw(Graphics g);

        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y,this.Width, this.Height);
        }

    }
}
