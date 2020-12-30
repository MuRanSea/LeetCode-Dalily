using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JianzhiOffer
{
    //https://leetcode-cn.com/problems/fei-bo-na-qi-shu-lie-lcof/
    public class Jz10
    {
        public int Fib(int n)
        { 
            if (n < 2)
            {
                return n;
            }
            return (Fib(n - 1) + Fib(n - 2)) % 1000000007;
        }
        // 0 1 1 2
        public int Fib2(int n)
        {
            if (n < 2)
            {
                return n;
            }
            int a = 0;
            int b = 1;
            for (int i = 2; i <= n; i++)
            {
                var c = (a + b) % 1000000007;
                a = b;
                b = c;
            }
            return b;
        }
    }
}
