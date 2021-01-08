using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.排序
{
    class 快速排序
    {
        private List<T> QuickSort<T>(List<T> nums) where T : IComparable
        {
            if (nums.Count < 2)
            {
                return nums;
            }
            T middle = nums[0];
            List<T> left = new List<T>();
            List<T> right = new List<T>();
            for (int i = 1; i < nums.Count; i++)
            {
                var num = nums[i];
                if (num .CompareTo(middle)<=0)
                {
                    left.Add(num);
                }
                else
                {
                    right.Add(num);
                }
            }
            List<T> newArray = QuickSort(left);
            newArray.Add(middle);
            newArray.AddRange(QuickSort(right));
            return newArray;
        }


        public void QuickSort(int[] A, int left, int right)
        {
            if (left > right || left < 0 || right < 0) return;

            int index = Partition(A, left, right);

            if (index != -1)
            {
                QuickSort(A, left, index - 1);
                QuickSort(A, index + 1, right);
            }
        }

        private static int Partition(int[] A, int left, int right)
        {
            if (left > right) return -1;

            int end = left;

            int pivot = A[right];    // choose last one to pivot, easy to code
            for (int i = left; i < right; i++)
            {
                if (A[i] < pivot)
                {
                    swap(A, i, end);
                    end++;
                }
            }

            swap(A, end, right);

            return end;
        }

        private static void swap(int[] A, int left, int right)
        {
            int tmp = A[left];
            A[left] = A[right];
            A[right] = tmp;
        }
    }
}
