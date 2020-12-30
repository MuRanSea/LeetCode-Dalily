using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JianzhiOffer
{
    //https://leetcode-cn.com/problems/zhong-jian-er-cha-shu-lcof/
    //前序遍历 preorder = [3, 9, 20, 15, 7]
    //中序遍历 inorder = [9, 3, 15, 20, 7]
    public class Jz07
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return null;
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

}
