using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    public static class Utils
    {
        public static int[] GetArray(string str)
        {
            str = str.Trim(' ');
            var rt = str.Split(',');
            int[] array = new int[rt.Length];
            for (int i = 0; i < rt.Length; i++)
            {
                array[i] = int.Parse(rt[i]);
            }
            return array;
        }
    }
}
