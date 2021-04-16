using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoordinateSharp;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using RestSharp;
using System.Net;
using System.Runtime.Intrinsics.Arm;

namespace MyConsole
{
    //13001
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
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public void Start()
        {
            var ans = NumSubarrayProductLessThanK(new int[] { 10, 5, 2, 6 }, 100);
            Console.WriteLine($"<<<<<<<<<<<<<<<{ans}");
        }
        /*
           [90,69,null,49,89,null,52]
         */
        //2 3 5

        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k <= 1) return 0;
            int prod = 1, ans = 0, left = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                prod *= nums[right];
                while (prod >= k) prod /= nums[left++];
                Console.WriteLine($"{right} {left}");
                ans += right - left + 1;
            }
            return ans;
        }


        public int NumSubarrayProductLessThanKzz(int[] nums, int k)
        {
            int prod = 1;
            int left = 0;
            int ans = 0;
            for (int right = 0 ; right < nums.Length; right ++)
            {
                prod *= nums[right];
                while (prod >= k)
                {
                    prod /= nums[left++];
                }
                ans = right - left + 1;
            }
            return ans;
        }

        public int FindNthDigit(int n)
        {
            int index = 1;
            Int64 max = 0;
            Int64 pre = 0;
            while (max < n)
            {
                Int64 num = index * (Int64)Math.Pow(10, index - 1) * 9;
                pre = max;
                max += num;
                index++;
            }
            if (max == n)
            {
                return 9;
            }
            index--;
            int rest = (int)(n - pre);//减去前面的
            int rest_index = rest / index;//第几个
            int yushu = rest % index;//余数
            var ans = (int)Math.Pow(10, index - 1) - 1 + rest_index;//算出来这个数
            if (yushu>0)
            {
                ans++;
                return (int)(ans / Math.Pow(10, index-yushu) % 10);
            }
            return (int)(ans / Math.Pow(10, 0) % 10);
        }

    }
}

//前缀树
public class Trie
{
    private class TrieNode
    {
        //值
        public char val;
        public bool isEnd;
        //子节点 26字母
        public TrieNode[] Next;

        public TrieNode(char c)
        {
            isEnd = false;
            Next = new TrieNode[26];
            val = c;
        }
    }

    private const char END_CHAR = 'z';
    private readonly TrieNode _root;

    /** Initialize your data structure here. */
    public Trie()
    {
        _root = new TrieNode(char.MinValue);
    }

    /** Inserts a word into the trie. */
    public void Insert(string word)
    {
        int index = 0;
        var node = _root;
        while (index < word.Length)
        {
            var val = word[index];
            int pos = END_CHAR - val;
            if (node.Next[pos] == null)
            {
                node.Next[pos] = new TrieNode(val);
            }
            node = node.Next[pos];
            index++;
        }
        node.isEnd = true;
    }

    /** Returns if the word is in the trie. */
    public bool Search(string word)
    {
        var node = FindLast(word);
        if (node == null) return false;
        return node.isEnd;
    }

    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix)
    {
        var node = FindLast(prefix);
        if (node == null) return false;
        return true;
    }

    // find last prefix node
    private TrieNode FindLast(string word)
    {
        int index = 0;
        var node = _root;
        while (index < word.Length)
        {
            var val = word[index];
            int pos = END_CHAR - val;
            if (node.Next[pos] == null)
            {
                return null;
            }
            if (node.Next[pos].val != val)
            {
                return null;
            }
            node = node.Next[pos];
            index++;
        }
        return node;
    }
}




