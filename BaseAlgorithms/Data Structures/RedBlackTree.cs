namespace BaseAlgorithms.Data_Structures
{
    public class RedBlackTree
    {
        private RBNode _root;

        public RBNode Root => _root;

        private void RotateLeft(RBNode root, RBNode node)
        {
            var nodeRight = node.Right;

            node.Right = nodeRight.Left;

            if (node.Right != null)
                node.Right.Parent = node;

            nodeRight.Parent = node.Parent;

            if (node.Parent == null)
                CopyNode(nodeRight, root);

            else if (node == node.Parent.Left)
                node.Parent.Left = nodeRight;

            else
                node.Parent.Right = nodeRight;

            nodeRight.Left = node;
            node.Parent = nodeRight;
        }

        private void RotateRight(RBNode root, RBNode node)
        {
            var nodeLeft = node.Left;

            node.Left = nodeLeft.Right;

            if (node.Left != null)
                node.Left.Parent = node;

            nodeLeft.Parent = node.Parent;

            if (node.Parent == null)
                CopyNode(node, root);

            else if (node == node.Parent.Left)
                node.Parent.Left = nodeLeft;

            else
                node.Parent.Right = nodeLeft;

            nodeLeft.Right = node;
            node.Parent = nodeLeft;
        }

        private static void CopyNode(RBNode srcNode, RBNode dstNode)
        {
            dstNode.Data = srcNode.Data;
            dstNode.Color = srcNode.Color;
            dstNode.Left = srcNode.Left;
            dstNode.Right = srcNode.Right;
            dstNode.Parent = srcNode.Parent;
        }

        private void FixViolation(RBNode root, RBNode node)
        {
            while ((node != root) && (node.Color != Color.Black) &&
           (node.Parent.Color == Color.Red))
            {

                var parentNode = node.Parent;
                var grandParentNode = node.Parent.Parent;

                /*  Case : A 
                    Parent of pt is left child of Grand-parent of pt */
                if (parentNode == grandParentNode.Left)
                {

                    var uncleNode = grandParentNode.Right;

                    /* Case : 1 
                       The uncle of pt is also red 
                       Only Recoloring required */
                    if (uncleNode != null && uncleNode.Color == Color.Red)
                    {
                        grandParentNode.Color = Color.Red;
                        parentNode.Color = Color.Black;
                        uncleNode.Color = Color.Black;
                        node = grandParentNode;
                    }

                    else
                    {
                        /* Case : 2 
                           pt is right child of its parent 
                           Left-rotation required */
                        if (node == parentNode.Right)
                        {
                            RotateLeft(root, parentNode);
                            node = parentNode;
                            parentNode = node.Parent;
                        }

                        /* Case : 3 
                           pt is left child of its parent 
                           Right-rotation required */
                        RotateRight(root, grandParentNode);
                        SwapColor(parentNode, grandParentNode);
                        node = parentNode;
                    }
                }

                /* Case : B 
                   Parent of pt is right child of Grand-parent of pt */
                else
                {
                    var uncleNode = grandParentNode.Left;

                    /*  Case : 1 
                        The uncle of pt is also red 
                        Only Recoloring required */
                    if ((uncleNode != null) && (uncleNode.Color == Color.Red))
                    {
                        grandParentNode.Color = Color.Red;
                        parentNode.Color = Color.Black;
                        uncleNode.Color = Color.Black;
                        node = grandParentNode;
                    }
                    else
                    {
                        /* Case : 2 
                           pt is left child of its parent 
                           Right-rotation required */
                        if (node == parentNode.Left)
                        {
                            RotateRight(root, parentNode);
                            node = parentNode;
                            parentNode = node.Parent;
                        }

                        /* Case : 3 
                           pt is right child of its parent 
                           Left-rotation required */
                        RotateLeft(root, grandParentNode);
                        SwapColor(parentNode, grandParentNode);
                        node = parentNode;
                    }
                }
            }

            root.Color = Color.Black;
        }

        private void SwapColor(RBNode a, RBNode b)
        {
            var tmp = a.Color;
            a.Color = b.Color;
            b.Color = tmp;
        }

        /* A utility function to insert a new node with given key 
        in BST */
        RBNode BSTInsert(RBNode root, RBNode node)
        {
            /* If the tree is empty, return a new node */
            if (root == null)
                return node;

            /* Otherwise, recur down the tree */
            if (node.Data < root.Data)
            {
                root.Left = BSTInsert(root.Left, node);
                root.Left.Parent = root;
            }
            else if (node.Data > root.Data)
            {
                root.Right = BSTInsert(root.Right, node);
                root.Right.Parent = root;
            }

            /* return the (unchanged) node pointer */
            return root;
        }

        public void Insert(int data)
        {
            var node = new RBNode(data);

            // Do a normal BST insert 
            _root = BSTInsert(_root, node);

            // fix Red Black Tree violations 
            FixViolation(_root, node);
        }
    }
}




