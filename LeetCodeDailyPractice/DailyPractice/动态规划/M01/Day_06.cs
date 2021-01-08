using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.动态规划.M01
{
    //https://leetcode-cn.com/problems/climbing-stairs/
    class Day_06
    {
        public int ClimbStairs(int n)
        {
            if (n < 4)
            {
                return n;
            }
            int[] dp = new int[2];
            dp[0] = 1;
            dp[1] = 2;
            for (int i = 3; i <= n; i++)
            {
                var temp = dp[0] + dp[1];
                dp[0] = dp[1];
                dp[1] = temp; 
            }
            return dp[1];
        }
    }
}
