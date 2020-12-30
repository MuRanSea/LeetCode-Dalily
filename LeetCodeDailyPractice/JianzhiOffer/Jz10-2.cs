using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JianzhiOffer
{
    class Jz10_2
    {
        //https://leetcode-cn.com/problems/qing-wa-tiao-tai-jie-wen-ti-lcof/
        public int NumWays(int n)
        {
            if (n < 4)
            {
                return n;
            }
            var a = 2;
            var b = 3;
            for (int i = 4; i <= n; i++)
            {
                var c = a + b;
                a = b;
                b = c;
            }
            return b;
        }

        public int NumWays1(int n)
        {
            if (n < 4)
            {
                return n;
            }
            return NumWays1(n - 1) + NumWays1(n - 2);
        }
    }
}
