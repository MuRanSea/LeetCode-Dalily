using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JianzhiOffer
{
    //https://leetcode-cn.com/problems/er-jin-zhi-zhong-1de-ge-shu-lcof/
    class Jz15
    {
        
        public int HammingWeight(uint n)
        {
            int count = 0;
            while (n > 0)
            {
                if (n % 2 == 1)
                {
                    count++;
                }
                n /= 2;
            }
            return count;
        }

        public int HammingWeight2(uint n)
        {
            int count = 0;

            var s = n << 32;

            return count;
        }
    }
}
