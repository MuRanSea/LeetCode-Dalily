using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.贪心.M12
{
    //https://leetcode-cn.com/problems/lemonade-change/submissions/
    class Day_16
    {
        public bool LemonadeChange(int[] bills)
        {
            int five = 0;
            int ten = 0;
            for (int i = 0; i < bills.Length; i++)
            {
                if (bills[i] == 10)
                {
                    ten++;
                    five--;
                }
                else if (bills[i] == 20)
                {
                    if (ten > 0)
                    {
                        ten--;
                        five--;
                    }
                    else
                    {
                        five -= 3;
                    }
                }
                else
                {
                    five++;
                }
                if (five < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
