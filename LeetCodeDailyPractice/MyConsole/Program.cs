using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            s.Start();
            Console.ReadLine();
        }

    }

    class Solution
    {
        public void Start()
        {

            List<byte> bytes = new List<byte>(28);
            //vector
            bytes.AddRange(BitConverter.GetBytes(0.3f));
            bytes.AddRange(BitConverter.GetBytes(0.4f));
            bytes.AddRange(BitConverter.GetBytes(0.3f));
            //qua
            bytes.AddRange(BitConverter.GetBytes(0.1f));
            bytes.AddRange(BitConverter.GetBytes(0.2f));
            bytes.AddRange(BitConverter.GetBytes(0.1f));
            bytes.AddRange(BitConverter.GetBytes(0.3f));


            using(System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes.ToArray()))
            {
                byte[] buf = new byte[4];
                int i = 0;
                while (ms.Position<28)
                {
                    i++;
                    var len = ms.Read(buf, 0, 4);
                    float f = BitConverter.ToSingle(buf);
                    Console.WriteLine($"<<<<<<<<<<<{f}");
                }
            }

        }
        //23:59 , 00:00 ,12:34
        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost.Length == 2)
            {
                return Math.Min(cost[0], cost[1]);
            }
            for (int i = 2; i < cost.Length; i++)
            {
                cost[i] = Math.Min(cost[i - 1], cost[i - 2]) + cost[i];
            }
            return Math.Min(cost[cost.Length-1],cost[cost.Length-2]);
        }

        int[] GetArray(string str)
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
