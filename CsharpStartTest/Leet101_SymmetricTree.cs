using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpStartTest
{
    class Leet101_SymmetricTree
    {
        public static void main()
        {
            //實作一個treenode
            TreeNode root = new TreeNode(1);
            root.left =new TreeNode(2);
            root.right = new TreeNode(2);
            root.left.left = new TreeNode(3);
            root.right.right = new TreeNode(3);
            root.right.left = new TreeNode(4);
            root.left.right = new TreeNode(4);

            bool result=IsSymmetric(root);
            Console.Write(result);
        }
        static bool IsSymmetric (TreeNode root)
        {
            return true;
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
