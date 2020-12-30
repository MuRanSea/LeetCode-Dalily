using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JianzhiOffer
{
    public class Jz04
    {
        //https://leetcode-cn.com/problems/er-wei-shu-zu-zhong-de-cha-zhao-lcof/

        //暴力法
        public bool FindNumberIn2DArray(int[][] matrix, int target)
        {
            if (matrix.Length == 0|| matrix[0].Length == 0)
            {
                return false;
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][matrix[i].Length - 1] < target)
                {
                    continue;
                }
                int index = 0;
                while (matrix[i][index] <= target&& index<matrix[i].Length)
                {
                    if (matrix[i][index] == target)
                    {
                        return true;
                    }
                    index++;
                }
            }
            return false;

        }

        //线性法
        public bool FindNumberIn2DArray2(int[][] matrix, int target)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0)
            {
                return false;
            }
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            int row = 0;
            int col = cols-1;
            while (row<rows&&col>=0)
            {
                int value = matrix[row][col];
                if (value == target)
                {
                    return true;
                }
                else if (value > target)
                {
                    col--;
                }
                else
                {
                    row++;
                }
            }
            return false;
        }
    }
}