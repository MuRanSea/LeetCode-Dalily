using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.动态规划.M01
{
    //https://leetcode-cn.com/problems/unique-paths-ii/
    class Day_12
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var m = obstacleGrid.Length;
            var n = obstacleGrid[0].Length;
            int[,] dp = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                if (i > 0 && dp[i - 1, 0] == 0)
                {
                    dp[i, 0] = 0;
                }
                else if (obstacleGrid[i][0] == 0)
                {
                    dp[i, 0] = 1;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (i > 0 && dp[0, i - 1] == 0)
                {
                    dp[0, i] = 0;
                }
                else if (obstacleGrid[0][i] == 0)
                {
                    dp[0, i] = 1;
                }
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                    {
                        continue;
                    }
                    dp[i, j] = dp[i, j - 1] + dp[i - 1, j];
                }
            }
            return dp[m - 1, n - 1];
        }
    }
}
