using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode
{
    public class BinaryTreeInOrderTraversal
    {
        private List<int> _result = new List<int>();
        
        public IList<int> InorderTraversal(TreeNode root)
        {
            if (root == null)
                return _result;
            
            _result.Add(root.val);

            
        }
    }
}