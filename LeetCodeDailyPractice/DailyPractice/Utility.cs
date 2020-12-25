using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice
{
    public static class Utility
    {
        /// <summary>
        /// 解析字符串为数组，二维的.[[1,3],[2,3]]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[][] ParseArray(string input,int count)
        {
            List<int[]> rt = new List<int[]>();
            input = input.Replace("[", "").Replace("]", "");
            var array = input.Split(',');
            if (array.Length % count != 0)
            {
                return null;
            }
            for (int i = 0; i < array.Length;)
            {
                int[] item = new int[count];
                for (int j = 0; j < count; j++)
                {
                    item[j] = int.Parse(array[i++]);
                }
                rt.Add(item);
            }
            return rt.ToArray();
        }

        /// <summary>
        /// 解析为数组
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int[] ParseArray(string input)
        {
            input = input.Replace("[", "").Replace("]", "");
            var array = input.Split(',');
            int[] rt = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                rt[i] = int.Parse(array[i]);
            }
            return rt;
        }
    }
}
