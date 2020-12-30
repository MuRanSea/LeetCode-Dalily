using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JianzhiOffer
{
    public class Jz05
    {
        //https://leetcode-cn.com/problems/ti-huan-kong-ge-lcof/
        public string ReplaceSpace(string s)
        {
            System.Text.StringBuilder sb = new StringBuilder();
            foreach (var c in s)
            {
                if(c==' ')
                {
                    sb.Append("%20");
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
