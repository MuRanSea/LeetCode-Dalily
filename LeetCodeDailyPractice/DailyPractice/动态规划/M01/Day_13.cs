using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.动态规划.M01
{
    //https://leetcode-cn.com/problems/integer-break/
    class Day_13
    {
        //

        public int IntegerBreak(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 0;
            for (int i = 2; i <= n; i++)
            {
                int max = 0;
                for (int j = 1; j < i; j++)
                {
                    max = Math.Max(max, Math.Max(j * (i - j), j * dp[i - j]));
                }
                dp[i] = max;
            }
            return dp[n];
        }

        //贪心版本，当n>3时尽可能多的3就是最大乘积
        public int IntegerBreakTx(int n)
        {
            if (n <= 3)
            {
                return n - 1;
            }
            int ans = 1;
            while (n > 4)
            {
                ans *= 3;
                n -= 3;
            }
            return ans * n;
        }
    }
}
