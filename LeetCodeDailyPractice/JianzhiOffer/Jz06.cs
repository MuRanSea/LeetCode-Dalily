using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JianzhiOffer
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    //1 2 3
    class Jz06
    {

        //https://leetcode-cn.com/problems/cong-wei-dao-tou-da-yin-lian-biao-lcof/
        //翻转链表
        public int[] ReversePrint(ListNode head)
        {
            int count = 0;
            int index = 0;
            ListNode current = head;
            ListNode pre = null;
            while (current != null)
            {
                var next = current.next;
                current.next = pre;
                pre = current;
                current = next;
                count++;
            }
            int[] array = new int[count];
            while (pre != null)
            {
                array[index] = pre.val;
                pre = pre.next;
                index++;
            }
            return array;
        }

        //栈,先进后出
        public int[] ReversePrint1(ListNode head)
        {
            Stack<int> numStack = new Stack<int>();
            ListNode current = head;
            while (current != null)
            {
                numStack.Push(current.val);
                current = current.next;
            }
            return numStack.ToArray();
        }
    }
}
