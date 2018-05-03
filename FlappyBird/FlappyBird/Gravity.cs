using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    /// <summary>
    /// 重力类
    /// </summary>
    class Gravity
    {
        public static float _gravity = 9.8f;

        //计算小鸟下降了多少，将下降的距离重新赋值
        //给纵坐标,这样就实现了小鸟按照重力进行下降

        public static float GetHeight(float speed, float second)
        {
            return (float)(0.5 * _gravity * second * second) + 
                speed * second;


        }

    }
}
