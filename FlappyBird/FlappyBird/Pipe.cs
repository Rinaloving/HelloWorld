using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlappyBird.Properties;

namespace FlappyBird
{
    /// <summary>
    /// 管道类
    /// </summary>
    /// 

    public enum PipeDirection
    {
        Up,
        Down
    }
    class Pipe
    {
        //管道分为两种，一种向上，一种向下

        public int X { get; set; }

        public int Y { get; set; }

        public int PPHeight { get; set; }
        public int PPWidth { get; set; }

        public PipeDirection PP
        {
            get;
            set;
        }

        public Pipe(int x, int y, PipeDirection pp)
        {
            this.X = x;
            this.Y = y;
            this.PP = pp;
        }

        //获得管道的图片
        public Image img = Resources.flappy_packer;

        //在图片中将图片拿出来
        /// <summary>
        /// 从大图中截取图片矩形
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Image GetImage(int x, int y)
        {
            //创建位图对象 宽128 高 830
            Bitmap bmp = new Bitmap(128,830);

            //将截取出来的图片 通过GDI+对象 绘制到位图上

            Graphics g = Graphics.FromImage(bmp);
            //开始绘制
            //第一个矩形表示要绘制到bmp上矩形的大小
            //第二个矩形表示从原图的哪个位置开始截图片
            g.DrawImage(img,new Rectangle(0,0,128,830),
                new Rectangle(x, y, 128, 830), GraphicsUnit.Pixel); // GraphicsUnit.Pixel 按像素处理

            return bmp;
        }


        public void DrawGD(Graphics g)
        {
            //在绘制管道的时候，应该根据不同的方向 绘制不同的管道
            switch (this.PP)
            {
                case PipeDirection.Up:
                    g.DrawImage(GetImage(160, 495), this.X, this.Y);
                    //g.DrawImage(Resources.flappy_pipe3,this.X,this.Y);
                    break;
                case PipeDirection.Down:
                    g.DrawImage(GetImage(10, 495), this.X, this.Y);
                    break;
                default:
                    break;
            }


        }


        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.PPWidth, this.PPHeight);
        }
        /// <summary>
        /// 上面的管道纵坐标应该从0开始计算，碰撞高度减去小鸟的高度
        /// </summary>
        /// <returns></returns>
        public Rectangle GetUpRectangle()
        {
            return new Rectangle(this.X, 0, this.PPWidth, this.PPHeight - SingleObject.GetSingle().SingleBird.Height);
        }

    }
}
