using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.排序
{
    class 选择排序
    {
        public void Sort(int[] nums)
        {
            int min = 0;
            int temp = 0;
            for (int i = 0; i < nums.Length-1; i++)
            {
                min = i;
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[min] > nums[j])
                    {
                        min = j;
                    }
                }
                temp = nums[min];
                nums[min] = nums[i];
                nums[i] = temp;
            }
        }
    }
}