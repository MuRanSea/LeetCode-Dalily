using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.动态规划.M01
{
    //https://leetcode-cn.com/problems/unique-paths/
    class Day_11
    {
        public int UniquePaths(int m, int n)
        {
            int[,] dp = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                dp[i, 0] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                dp[0, i] = 1;
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dp[i,j] = dp[i - 1,j] + dp[i,j - 1];
                }
            }
            return dp[m-1,n-1];
        }
    }
}
