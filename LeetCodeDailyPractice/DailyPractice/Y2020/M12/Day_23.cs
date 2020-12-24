using System;
using System.Collections.Generic;

namespace DailyPractice.Y2020.M12
{
    public class Day_23
    {
        //763
        //https://leetcode-cn.com/problems/partition-labels/
        public IList<int> PartitionLabels(string S)
        {
            if (string.IsNullOrEmpty(S))
            {
                return null;
            }
            char c = 'a';
            int[] hash = new int[27];
            List<int> result = new List<int>();
            for (int i = 0; i < S.Length; i++)
            {
                hash[S[i] - c] = i;
            }
            int left = 0;
            int right = 0;
            for (int i = 0; i < S.Length; i++)
            {
                right = Math.Max(right, hash[S[i] - c]);
                if (right == i)
                {
                    result.Add(right - left + 1);
                    left = i + 1;
                }
            }
            return result;
        }
    }
}
