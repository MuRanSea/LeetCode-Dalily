using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.贪心.M11
{
    //https://leetcode-cn.com/problems/wiggle-subsequence/
    class Day_25
    {
        public int WiggleMaxLength(int[] nums)
        {
            int ans = 0;
            int left = 0;
            int right = 1;
            int[] rt = new int[nums.Length - 1];
            for (int i = 0; i < nums.Length-1; i++)
            {
                rt[i] = nums[i + 1] - nums[i];
            }
            bool flag = rt[left] > 0;
            while (left < right && right < rt.Length)
            {
                while (right<rt.Length&&(rt[right] > 0) != flag)
                {
                    flag = !flag;
                    right++;
                }
                ans = Math.Max(ans, right - left + 1);
                left = right - 1;
            }
            return ans;
        }
    }
    //[1,7,4,9,2,5]
    //(6,-3,5,-7,3)
    //[1,2,3,4,5,6,7,8,9]
    //1,1,1,1,1,1,1,1
}

