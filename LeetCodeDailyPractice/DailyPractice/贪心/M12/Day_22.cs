using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.贪心.M12
{
    public class Day_22
    {
        //435
        //https://leetcode-cn.com/problems/non-overlapping-intervals/
        public int EraseOverlapIntervals(int[][] intervals)
        {
            if (intervals == null || intervals.Length == 0)
            {
                return 0; 
            }
            Array.Sort(intervals, (x, y) =>
            {
                return x[1].CompareTo(y[1]);
            });
            int counter = 0;
            var temp = intervals[0];
            for (int i = 1; i < intervals.Length; i++)
            {
                if (temp[1] > intervals[i][0])
                {
                    counter++;
                }
                else
                {
                    temp = intervals[i];
                }
            }
            return counter;
        }
    }
}
