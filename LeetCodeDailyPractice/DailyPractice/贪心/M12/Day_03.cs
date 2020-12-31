using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.贪心.M12
{
    //https://leetcode-cn.com/problems/maximize-sum-of-array-after-k-negations/
    class Day_03
    {
        public int LargestSumAfterKNegations(int[] A, int K)
        {
            int ans = 0;
            Array.Sort(A);
            int min = int.MaxValue;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < 0 && K > 0)
                {
                    A[i] *= -1;
                    K--;
                }
                min = Math.Min(min, A[i]);
                ans += A[i];
            }
            if (K > 0 && K % 2 == 1)
            {
                ans -= min * 2;
            }
            return ans;
        }
        
    }
}
