using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.贪心.M12
{
    public class Day_21
    {
        //452
        //https://leetcode-cn.com/problems/minimum-number-of-arrows-to-burst-balloons/

        //左边界升序
        public int FindMinArrowShots0(int[][] points)
        {
            if (points == null || points.Length == 0)
            {
                return 0;
            }
            Array.Sort(points, (x, y) =>
            {
                if (x[0] == y[0])
                {
                    return x[1].CompareTo(y[1]);
                }
                return x[0].CompareTo(y[0]);
            });
            int arrowCounter = 1;
            int[] temp = points[0];
            for (int i = 1; i < points.Length; i++)
            {
                if (points[i][0] <= temp[1])
                {
                    temp[0] = points[i][0];
                    temp[1] = Math.Min(temp[1], points[i][1]);
                }
                else
                {
                    arrowCounter++;
                    temp = points[i];
                }
            }
            return arrowCounter;
        }

        //
        //右边界降序
        public int FindMinArrowShots1(int[][] points)
        {
            if (points == null || points.Length == 0)
            {
                return 0;
            }
            Array.Sort(points, (x, y) =>
            {
                if (x[1] == y[1])
                {
                    return -x[0].CompareTo(y[0]);
                }
                return -x[1].CompareTo(y[1]);
            });
            int arrowCounter = 1;
            int left = points[0][0];
            for (int i = 1; i < points.Length; i++)
            {
                if (left > points[i][1])
                {
                    arrowCounter++;
                    left = points[i][0];
                }
                else
                {
                    left = Math.Max(left, points[i][0]);
                }
            }
            return arrowCounter;
        }
       
        
    }
}
