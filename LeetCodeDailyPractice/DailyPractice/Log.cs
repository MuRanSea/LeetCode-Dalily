using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice
{
    public static class Log
    {
        public static void LogArray<T>(T[] array)
        {
            Console.WriteLine(GetArrayStr(array));
        }

        public static void LogArray<T>(T[][] array)
        {
            string str = "[";
            for (int i = 0; i < array.Length; i++)
            {
                str += $"{GetArrayStr(array[i])}";
                if (i != array.Length - 1)
                {
                    str += ",";
                }
            }
            str += "]";
            Console.WriteLine(str);
        }

        private static string GetArrayStr<T>(T[] array)
        {
            string str = "[";
            for (int i = 0; i < array.Length; i++)
            {
                str += $"{array[i]}";
                if (i != array.Length - 1)
                {
                    str += ",";
                }
            }
            str += "]";
            return str;
        }
    }
}
