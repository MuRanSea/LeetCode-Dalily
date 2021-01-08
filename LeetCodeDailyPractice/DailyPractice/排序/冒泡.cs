using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.排序
{
    class 冒泡
    {
        public void Sort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length-i; j++)
                {
                    if (nums[j] < nums[j - 1])
                    {
                        //swap value
                        var temp = nums[j];
                        nums[j] = nums[j - 1];
                        nums[j - 1] = temp;
                    }
                }
            }
        }
    }
}
