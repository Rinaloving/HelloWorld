using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlappyBird.Properties;
using System.Drawing;

namespace FlappyBird
{
    public class Bird : GameObject
    {
        //我们在这个类中 ，需要将鸟绘制到我们的窗体上
        //所以说，我们需要获得到鸟的图片

        //获得图片
        private static Image[] imgs = { 
                                Resources._0,
                                Resources._1,
                                Resources._2
                               };

        //通过三张图片，实现挥动翅膀的效果

        /// <summary>
        /// 存储小鸟图片的索引 方便我们绘制到窗体上
        /// </summary>
        public int BirdIndex
        {
            get;
            set;
        }

        public Bird(int x, int y, int birdIndex):base(x,y,imgs[0].Width, imgs[0].Height)
        {
            this.BirdIndex = birdIndex;
            this.DurationTime = 100; //初始化时间
            this.CurrentSpeed = 0.0f; //初始化速度
        }

        //应该把这个小鸟绘制到窗体上
        public override void Draw(Graphics g)
        {
            switch (this.BirdIndex)
            {
                case 0:
                    g.DrawImage(imgs[0],this.X,this.Y);
                    break;
                case 1:
                    g.DrawImage(imgs[1], this.X, this.Y);
                    break;
                case 2:
                    g.DrawImage(imgs[2], this.X, this.Y);
                    break;
            }

            //每绘制完一张图片我们让索引进行++
            this.BirdIndex++;
            if (this.BirdIndex >= 3)
            {
                this.BirdIndex = 0;
            }
        }

        /// <summary>
        /// 当我们点击窗体，或者摁下空格的时候，都应该让小鸟向上移动
        /// </summary>
        public override void Move()
        {
            this.Y -= 40;
            //不让小鸟超过窗体
            if (this.Y <= 0)
            {
                this.Y = 0;
            }
        }

        /// <summary>
        /// 小鸟当前的速度
        /// </summary>
        public float CurrentSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// 获得时间
        /// </summary>
        public int DurationTime
        {
            get;
            set;
        }
    }
    
}
