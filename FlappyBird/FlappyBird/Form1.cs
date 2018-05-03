using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitialGame();
        }


        //开始初始化游戏，给游戏添加游戏对象

        private Pipe ppUp;
        private Pipe ppDown;

        public void InitialGame()
        {
            SingleObject.GetSingle().AddGameObject(new Bird(50,200,0));
            //对管道进行初始化
            ppUp = new Pipe(100,-600,PipeDirection.Up);
            ppDown = new Pipe(100, 400, PipeDirection.Down);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //给当前背景设置背景图片

            //this.BackgroundImage = FlappyBird.Properties.Resources.bg;
            ////设置图片在窗口中的显示效果
            //this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        /// <summary>
        /// 绘制窗体的时候，重绘游戏对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //在绘制窗体的时候，把小鸟绘制在窗口
            SingleObject.GetSingle().DrawGameObject(e.Graphics);
            //访问管道对象
            ppUp.DrawGD(e.Graphics);
            ppDown.DrawGD(e.Graphics);

        }

        private void timer1_tick(object sender, EventArgs e)
        {
            //重新绘制
            this.Invalidate();
        }

        /// <summary>
        /// 当鼠标点击窗体的时候，调用小鸟Move方法向上移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            SingleObject.GetSingle().SingleBird.Move();
            SingleObject.GetSingle().SingleBird.CurrentSpeed = 10f;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //如果摁下了空格键
            if (e.KeyCode == Keys.Space)
            {
                SingleObject.GetSingle().SingleBird.Move();
                SingleObject.GetSingle().SingleBird.CurrentSpeed = 10f;
            }
        }

        /// <summary>
        /// 让小鸟按照重力的感觉来下落
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_tick(object sender, EventArgs e)
        {
            //获得小鸟下降的高度
            var height = Gravity.GetHeight(SingleObject.GetSingle().SingleBird.CurrentSpeed,
                SingleObject.GetSingle().SingleBird.DurationTime*0.001f); //将毫秒转换成帧
            //获得小鸟下落后的新坐标
            int y = SingleObject.GetSingle().SingleBird.Y + (int)height;

            //赋值前，给y做一个限定
            //限定小鸟的纵坐标
            y = y < 0 ? 0 : y;
            //限定小鸟不让他掉到地面以下
            y = y > this.Size.Height - pictureBox1.Height - 60 ? this.Size.Height-pictureBox1.Height-60 : y;
            //将新坐标y，赋值给小鸟的坐标
            SingleObject.GetSingle().SingleBird.Y = y;

            //v = v0+at;当前速度
            SingleObject.GetSingle().SingleBird.CurrentSpeed = SingleObject.GetSingle().SingleBird.CurrentSpeed +
                SingleObject.GetSingle().SingleBird.DurationTime * Gravity._gravity * 0.001f;


        }

        private int PPDistance = 150; // 上下管道间距

       //让管道从右向左移动
        private void MovePipe()
        {
            //在游戏中不停的向左边移动，其实就是减少管道的x坐标
            ppUp.X -= 10;
            ppDown.X -= 10;
            //解决问题:管道移出了界面 但是并没有从右边出来
            //解决：我们判断 当管道移出了界面的时候
            if (ppUp.X < -128)
            {
                ppUp.X = this.Width * 4 / 3 - 128;
                ppDown.X = this.Width * 4 / 3 - 128;
                //下面要解决的问题，就是让两个管子，有高有低
                ppUp.PPHeight = SetRandomHeigth();
                //上面的管子高度确定了 下面的也就确定了
                ppDown.PPHeight = this.Size.Height - this.pictureBox1.Height
                    - PPDistance - ppUp.PPHeight;

                //最终还是根据高度计算出y的坐标赋值给管道
                ppUp.Y = ppUp.PPHeight - 830; // 830 ppUp.Y 不能有负数
                ppDown.Y = ppUp.PPHeight + PPDistance;

            }
        }

        /// <summary>
        /// 设置上面管子的高度随机
        /// </summary>
        /// <returns></returns>
        public int SetRandomHeigth()
        {
            Random r = new Random();
            int totalHeight = this.Size.Height - this.pictureBox1.Height;
            return r.Next(90,totalHeight -90 -PPDistance);
        }


        /// <summary>
        /// 在这个timer中 让管道不停的移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer3_tick(object sender, EventArgs e)
        {
            MovePipe();

            //不停的去判断是否发生了碰撞 SingleObject.GetSingle().SingleBird.GetRectangle().IntersectsWith(ppDown.GetRectangle())||
            if (SingleObject.GetSingle().SingleBird.GetRectangle().IntersectsWith(ppDown.GetRectangle()))
            {
                MessageBox.Show("Game Over!!");
            }
            if (SingleObject.GetSingle().SingleBird.GetRectangle().IntersectsWith(ppUp.GetRectangle()))
            {
                MessageBox.Show("Game Over222!!");
            }
        }


    }
}
