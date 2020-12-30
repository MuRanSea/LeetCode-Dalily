using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyPractice.Y2020.M12
{
    //https://leetcode-cn.com/problems/binary-tree-cameras/
    /*
     
    题解：后序遍历，从子节点推导出父节点的状态。（左右两个节点只要有没被覆盖的，这个节点就需要安装摄像头）
    假设有三种状态 0 无覆盖，1摄像头，2有覆盖。（覆盖代表被摄像头覆盖的节点，空节点也算被覆盖的）
    
    那么则有 ：
    1. 当自己被覆盖是 此时 cur=2 返回2.
    2. left=2并且right=2同时满足时，代表子节点被覆盖，则父节点是无覆盖的。返回 0.
    3. 当left=0或者right=0，也就是左右只要有一个节点是无覆盖的，这说明此节点肯定要安装摄像头。返回 1.
    4. 与3的条件相反，left==1或者right==1，这说明该节点肯定被一个或者两个摄像机覆盖了。返回 2
    
    假如递归的结果是0，则代表根节点是无覆盖的，需要放个摄像头覆盖根节点。
     */ 
    public class Day_30
    {
        private int result = 0;

        private int Traversal(TreeNode cur)
        {
            if (cur == null)
            {
                return 2;
            }
            int left = Traversal(cur.left);
            int right = Traversal(cur.right);
            if (left == 2 && right == 2)
            {
                return 0;
            }
            else if (left == 0 || right == 0)
            {
                result++;
                return 1;
            }
            else
            {
                return 2;
            }
        }
      
        public int MinCameraCover(TreeNode root)
        {
            result = 0;
            if (Traversal(root)==0)
            {
                result++;
            }
            return result;
        }
    }


    public class Day_30_1
    {
        public int minCameraCover(TreeNode root)
        {
            int[] array = dfs(root);
            return array[1];
        }
        public int[] dfs(TreeNode root)
        {
            if (root == null)
            {
                return new int[] { int.MaxValue / 2, 0, 0 };
            }
            int[] leftArray = dfs(root.left);
            int[] rightArray = dfs(root.right);
            int[] array = new int[3];
            array[0] = leftArray[2] + rightArray[2] + 1;
            array[1] = Math.Min(array[0], Math.Min(leftArray[0] + rightArray[1], rightArray[0] + leftArray[1]));
            array[2] = Math.Min(array[0], leftArray[1] + rightArray[1]);
            return array;
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
