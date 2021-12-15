using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode
{
    //https://leetcode.com/problems/binary-tree-inorder-traversal/
    public class BinaryTreeInOrderTraversal
    {
        public IList<int> InorderTraversal(TreeNode root)
        {

            var inorder = new List<int>();
            if (root == null)
            {
                return inorder;
            }

            if (root.left == null && root.right == null)
            {
                inorder.Add(root.val);
                return inorder;
            }

            inorder.AddRange(InorderTraversal(root.left));
            inorder.Add(root.val);
            inorder.AddRange(InorderTraversal(root.right));

            return inorder;
        }
    }
}