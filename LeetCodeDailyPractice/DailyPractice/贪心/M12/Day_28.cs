using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.贪心.M12
{
    public class Day_28
    {
        //https://leetcode-cn.com/problems/monotone-increasing-digits/
        //738
        public int MonotoneIncreasingDigits(int N)
        {
            string strNum = N.ToString();
            int[] nums = new int[strNum.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = int.Parse($"{strNum[i]}");
            }
            int flag = nums.Length;
            for (int i = nums.Length - 1; i > 0; i--)
            {
                if (nums[i - 1] > nums[i])
                {
                    flag = i;
                    nums[i - 1]--;
                }

            }
            string rt = "";
            for (int i = flag; i < nums.Length; i++)
            {
                nums[i] = 9;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                rt = $"{rt}{nums[i]}";
            }
            return int.Parse(rt);
        }
    }
}
