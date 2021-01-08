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
            if (nums.Length < 2)
            {
                return nums.Length;
            }
            int ans = 1;
            int preFlag = nums[1]-nums[0];
            if (preFlag != 0) //[1,2] = 2 ;[1,1] = 1
            {
                ans++;
            }
            for (int i = 2; i < nums.Length; i++)
            {
                var flag = nums[i] - nums[i-1];
                if ((flag > 0 && preFlag <= 0) || 
                    (flag < 0 && preFlag >= 0))
                {
                    preFlag = flag;
                    ans++;
                }
            }
            return ans;
        }
    }
}

