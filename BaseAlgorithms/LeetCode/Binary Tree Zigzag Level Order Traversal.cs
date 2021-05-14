using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BaseAlgorithms.LeetCode
{
    //https://leetcode.com/problems/binary-tree-zigzag-level-order-traversal/
    
  public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
  }
 
    public class BinaryTreeZigzagLevelOrderTraversal
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            var queue = new Queue<(TreeNode node, bool leftDirection, int level)>();

            if (root == null)
                return new Collection<IList<int>>();
            
            
            queue.Enqueue((root, true, 0));
            
            var dictionary = new Dictionary<int, List<int>>();

            while (queue.Count > 0)
            {
                var (node, leftDirection, level) = queue.Dequeue();

                if (!dictionary.ContainsKey(level))
                    dictionary[level] = new List<int>();
                
                if (node.left != null)
                    queue.Enqueue((node.left, !leftDirection, level + 1));

                if (node.right != null)
                    queue.Enqueue((node.right, !leftDirection, level + 1));
                
                
                if (leftDirection)
                    dictionary[level].Add(node.val);
                else
                    dictionary[level].Insert(0,node.val);
            }

            return dictionary
                .Select(x=>(IList<int>)x.Value)
                .ToList();
        }
    }
}