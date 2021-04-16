using System;
using System.Collections.Generic;
using System.Text;

namespace JianzhiOffer
{
    public class Jz03
    {
        //https://leetcode-cn.com/problems/shu-zu-zhong-zhong-fu-de-shu-zi-lcof/
        public int FindRepeatNumber(int[] nums)
        {
            if (nums.Length == 0)
            {
                return -1;
            }
            int[] temp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                temp[nums[i]]++;
                if (temp[nums[i]] > 1)
                {
                    return nums[i];
                }
            }
            return -1;
        }

    }
}
