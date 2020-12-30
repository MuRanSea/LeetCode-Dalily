using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JianzhiOffer
{
    //https://leetcode-cn.com/problems/xuan-zhuan-shu-zu-de-zui-xiao-shu-zi-lcof/
    class Jz11
    {
        
        //错误的二分法
        public int MinArray(int[] numbers)
        {
            int left = 0;
            int right = numbers.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (numbers[mid] <= numbers[right])
                {
                    right--;
                }
                else
                {
                    left = mid+1;
                }

            }
            return numbers[right];
        }

        //正确的二分法
        public int MinArray1(int[] numbers)
        {
            int left = 0;
            int right = numbers.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (numbers[mid] < numbers[right])
                {
                    right = mid;
                }
                else if (numbers[mid] == numbers[right])
                {
                    right--;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return numbers[left];
        }

        //暴力搜索法
        public int MinArray2(int[] numbers)
        {
            if (numbers[0] < numbers[numbers.Length - 1])
            {
                return numbers[0];
            }
            for (int i = numbers.Length-1; i > 0; i--)
            {
                if (numbers[i] < numbers[i - 1])
                {
                    return numbers[i];
                }
            }
            return numbers[0];
        }

        //排序法
        public int MinArray3(int[] numbers)
        {
            Array.Sort(numbers);
            return numbers[0];
        }

    }
}
