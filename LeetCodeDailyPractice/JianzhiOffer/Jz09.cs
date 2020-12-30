using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JianzhiOffer
{
    //https://leetcode-cn.com/problems/yong-liang-ge-zhan-shi-xian-dui-lie-lcof/
    class Jz09
    {
        //进栈
        private readonly Stack<int> _in;
        //出栈
        private readonly Stack<int> _out;

        public Jz09()
        {
            _in = new Stack<int>();
            _out = new Stack<int>();
        }
        public void AppendTail(int value)
        {
            _in.Push(value);
        }

        public int DeleteHead()
        {
            if (_out.Count == 0)
            {
                while (_in.Count > 0)
                {
                    _out.Push(_in.Pop());
                }
            }
            if (_out.Count == 0)
            {
                return -1;
            }
            return _out.Pop();
        }
    }
}
