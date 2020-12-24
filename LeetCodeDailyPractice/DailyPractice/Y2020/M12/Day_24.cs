using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyPractice.Y2020.M12
{
    public class Day_24
    {
        // 56
        //url : https://leetcode-cn.com/problems/merge-intervals/
        public int[][] Merge(int[][] intervals)
        {
            if (intervals==null||intervals.Length == 0)
            {
                return null;
            }
            Array.Sort(intervals, (x, y) =>
            {
                return x[0].CompareTo(y[0]);
            });
            List<int[]> result = new List<int[]>();
            int[] temp = intervals[0];
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] <= temp[1])
                {
                    temp[1] = Math.Max(intervals[i][1],temp[1]);
                }
                else
                {
                    result.Add(temp);
                    temp = intervals[i];
                }
            }
            result.Add(temp);
            return result.ToArray();
        }
    }
}