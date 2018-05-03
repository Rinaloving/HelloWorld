using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    /// <summary>
    /// 在全局当中，不管哪个地方，都可以获得唯一的游戏对象
    /// </summary>
    class SingleObject
    {
        //实现单例设计模式
        //1.构造函数私有化
        private SingleObject() { }

        //2.声明全局唯一的单例
        private static SingleObject _singleObject = null;

        //3.对外提供一个获得对象的方法
        public static SingleObject GetSingle()
        {
            if (_singleObject == null)
            {
                _singleObject = new SingleObject();
            }
            return _singleObject;
        }

        //在单例中开始存储唯一的游戏对象

        //小鸟

        public Bird SingleBird { get; set; }

        /// <summary>
        /// 给当前类添加一个 向游戏中添加游戏对象的方法
        /// </summary>
        /// <param name="go">因为游戏对象他们的类型各不相同</param>
        public void AddGameObject(GameObject go)
        {
            SingleBird = (Bird)go;
        }


        public void DrawGameObject(Graphics g)
        {
            SingleBird.Draw(g);
        }
    }
}
