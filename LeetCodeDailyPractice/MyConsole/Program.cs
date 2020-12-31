using System;
using System.Collections.Generic;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo f = new Foo();
            Console.WriteLine(f.WiggleMaxLength(new int[] {1,1,1,1,1}));
        }


       
    }

    class Foo
    {
        public int WiggleMaxLength(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int ans = 1;
            int pre = nums[0];
            int preFlag = int.MinValue;
            for (int i = 1; i < nums.Length-1; i++)
            {
                var temp = nums[i] - pre;
                if(preFlag == int.MinValue)
                {

                }
                if(temp * preFlag < 0)
                {
                    preFlag = temp;
                    ans++;
                }
            }
            return ans;
        }

        //[1,17,5,10,13,15,10,5,16,8]
        //[1,17,10,13,10,16,8]

    }
}
