using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.动态规划.M01
{
    //https://leetcode-cn.com/problems/fibonacci-number/
    class Day_05
    {
        // 0 1 1 2 3 5 8 13 21
        public int Fib(int n)
        {
            if (n < 2)
            {
                return n;
            }
            int[] dp = new int[] { 0, 1 };
            for (int i = 2; i <= n; i++)
            {
                var temp = dp[0] + dp[1];
                dp[0] = dp[1];
                dp[1] = temp;
            }
            return dp[1];
        }
    }
}
