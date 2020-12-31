using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.贪心.M12
{
    //  714
    public class Day_29
    {
        public int MaxProfit(int[] prices, int fee)
        {
            int coast = -prices[0];
            int earning = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                var preEarning = coast;
                //缓存最少的花费
                coast = Math.Max(coast, earning - prices[i]);
                //缓存最大的收入
                earning = Math.Max(earning, prices[i] + preEarning-fee);
            }
            return earning;
        }
    }
}