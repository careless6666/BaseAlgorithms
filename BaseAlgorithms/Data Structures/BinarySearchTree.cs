namespace BaseAlgorithms.Data_Structures
{
    public class BinarySearchTree
    {
        public Node Search(Node root, int key)
        {
            // Base Cases: root is null or key is present at root 
            if (root == null || root.Data == key)
                return root;

            // Key is greater than root's key 
            if (root.Data < key)
                return Search(root.Right, key);

            // Key is smaller than root's key 
            return Search(root.Left, key);
        }

        public Node Insert(Node node, int item)
        {
            if (node == null)
                return new Node(item);

            if (item < node.Data)
                node.Left = Insert(node.Left, item);
            else if (item > node.Data)
                node.Right = Insert(node.Right, item);

            return node;
        }

        Node MinValue(Node node)
        {
            Node current = node;

            /* loop down to find the leftmost leaf */
            while (current.Left != null)
                current = current.Left;

            return current;
        }

        public Node Delete(Node root, int key)
        {
            // base case 
            if (root == null) return root;

            // If the key to be deleted is smaller than the root's key, 
            // then it lies in left subtree 
            if (key < root.Data)
                root.Left = Delete(root.Left, key);

            // If the key to be deleted is greater than the root's key, 
            // then it lies in right subtree 
            else if (key > root.Data)
                root.Right = Delete(root.Right, key);

            // if key is same as root's key, then This is the node 
            // to be deleted 
            else
            {
                // node with only one child or no child 
                if (root.Left == null)
                {
                    var tempLeft = root.Right;
                    root = null;
                    return tempLeft;
                }

                if (root.Right == null)
                {
                    var tempRight = root.Left;
                    root = null;
                    return tempRight;
                }

                // node with two children: Get the inorder successor (smallest 
                // in the right subtree) 
                var temp = MinValue(root.Right);

                // Copy the inorder successor's content to this node 
                root.Data = temp.Data;

                // Delete the inorder successor 
                root.Right = Delete(root.Right, temp.Data);
            }

            return root;
        }
    }
}
