using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.贪心.M11
{
    //https://leetcode-cn.com/problems/assign-cookies/
    class Day_24
    {
        public int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);
            int want = 0;
            int size = 0;
            while (want < g.Length && size < s.Length)
            {
                if (g[want] <= s[size])
                {
                    want++;
                }
                size++;
            }
            return want;
        }
    }
}
