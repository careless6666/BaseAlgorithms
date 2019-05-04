using System;

namespace BaseAlgorithms.Data_Structures
{
    public class STNode
    {
        public STNode() { }

        public STNode(int low, int high)
        {
            Low = low;
            High = high;
        }

        public int Low { get; set; }
        public int High { get; set; }
        public Color Color { get; set; }
        public STNode Left { get; set; }
        public STNode Right { get; set; }
        public STNode Parent { get; set; }
        public int Max => Math.Max(Math.Max((Left?.Max ?? 0), Right?.Max ?? 0), High);
    }

    public class SegmentTree
    {
        public STNode Root { get; set; }

        private void RotateLeft(STNode node)
        {
            var nodeRight = node.Right;

            node.Right = nodeRight.Left;

            if (node.Right != null)
                node.Right.Parent = node;

            nodeRight.Parent = node.Parent;

            if (node.Parent == null)
                Root = nodeRight;

            else if (node == node.Parent.Left)
                node.Parent.Left = nodeRight;

            else
                node.Parent.Right = nodeRight;

            nodeRight.Left = node;
            node.Parent = nodeRight;
        }

        private void RotateRight(STNode node)
        {
            var nodeLeft = node.Left;

            node.Left = nodeLeft.Right;

            if (node.Left != null)
                node.Left.Parent = node;

            nodeLeft.Parent = node.Parent;

            if (node.Parent == null)
                Root = node;

            else if (node == node.Parent.Left)
                node.Parent.Left = nodeLeft;

            else
                node.Parent.Right = nodeLeft;

            nodeLeft.Right = node;
            node.Parent = nodeLeft;
        }

        private void FixViolation(STNode node)
        {
            while (
                (node != Root) && (node.Color != Color.Black) &&
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
                            RotateLeft(parentNode);
                            node = parentNode;
                            parentNode = node.Parent;
                        }

                        /* Case : 3 
                           pt is left child of its parent 
                           Right-rotation required */
                        RotateRight(grandParentNode);
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
                            RotateRight(parentNode);
                            node = parentNode;
                            parentNode = node.Parent;
                        }

                        /* Case : 3 
                           pt is right child of its parent 
                           Left-rotation required */
                        RotateLeft(grandParentNode);
                        SwapColor(parentNode, grandParentNode);
                        node = parentNode;
                    }
                }
            }

            Root.Color = Color.Black;
        }

        private void SwapColor(STNode a, STNode b)
        {
            var tmp = a.Color;
            a.Color = b.Color;
            b.Color = tmp;
        }

        /* A utility function to insert a new node with given key 
        in BST */
        STNode BSTInsert(STNode root, STNode node)
        {
            /* If the tree is empty, return a new node */
            if (root == null)
                return node;

            /* Otherwise, recur down the tree */
            if (node.Low < root.Low)
            {
                root.Left = BSTInsert(root.Left, node);
                root.Left.Parent = root;
            }
            else if (node.Low > root.Low)
            {
                root.Right = BSTInsert(root.Right, node);
                root.Right.Parent = root;
            }

            /* return the (unchanged) node pointer */
            return root;
        }

        public void Insert(int low, int high)
        {
            var node = new STNode(low, high);

            // Do a normal BST insert 
            Root = BSTInsert(Root, node);

            // fix Red Black Tree violations 
            FixViolation(node);
        }

        public STNode SearchOverlap(int low, int high)
        {
            var node = Root;
            while (node != null && (node.High < low || node.Low > high))
            {
                if (node.Left != null && node.Left.Max > low)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return node;
        }

        public STNode Search(STNode root, int key)
        {
            var isFound = false;
            var temp = root;
            STNode item = null;
            while (!isFound)
            {
                if (temp == null)
                {
                    break;
                }
                if (key < temp.Low)
                {
                    temp = temp.Left;

                    if (temp == null)
                        return null;

                }
                if (key > temp.Low)
                {
                    temp = temp.Right;
                    if (temp == null)
                        return null;
                }
                if (key == temp.Low)
                {
                    isFound = true;
                    item = temp;
                }
            }
            if (isFound)
            {
                Console.WriteLine("{0} was found", key);
                return temp;
            }

            Console.WriteLine("{0} not found", key);
            return null;
        }

        public void Delete(STNode root, int key)
        {
            //first find the node in the tree to delete and assign to item pointer/reference
            var item = Search(root, key);
            STNode itemNode;

            if (item == null)
            {
                Console.WriteLine("Nothing to delete!");
                return;
            }
            if (item.Left == null || item.Right == null)
            {
                itemNode = item;
            }
            else
            {
                itemNode = TreeSuccessor(item);
            }

            var childNode = itemNode.Left ?? itemNode.Right;

            if (childNode != null)
            {
                childNode.Parent = itemNode;
            }
            if (itemNode.Parent == null)
            {
                root = childNode;
            }
            else if (itemNode == itemNode.Parent.Left)
            {
                itemNode.Parent.Left = childNode;
            }
            else
            {
                itemNode.Parent.Left = childNode;
            }
            if (itemNode != item)
            {
                item.Low = itemNode.Low;
            }
            if (itemNode.Color == Color.Black)
            {
                DeleteFixUp(childNode);
            }

        }

        private void DeleteFixUp(STNode node)
        {

            while (node != null && node != Root && node.Color == Color.Black)
            {
                if (node == node.Parent.Left)
                {
                    var parentRight = node.Parent.Right;
                    if (parentRight.Color == Color.Red)
                    {
                        parentRight.Color = Color.Black; //case 1
                        node.Parent.Color = Color.Red; //case 1
                        RotateLeft(node.Parent); //case 1
                        parentRight = node.Parent.Right; //case 1
                    }
                    if (parentRight.Left.Color == Color.Black && parentRight.Right.Color == Color.Black)
                    {
                        parentRight.Color = Color.Red; //case 2
                        node = node.Parent; //case 2
                    }
                    else if (parentRight.Right.Color == Color.Black)
                    {
                        parentRight.Left.Color = Color.Black; //case 3
                        parentRight.Color = Color.Red; //case 3
                        RotateRight(parentRight); //case 3
                        parentRight = node.Parent.Right; //case 3
                    }
                    parentRight.Color = node.Parent.Color; //case 4
                    node.Parent.Color = Color.Black; //case 4
                    parentRight.Right.Color = Color.Black; //case 4
                    RotateLeft(node.Parent); //case 4
                    node = Root; //case 4
                }
                else //mirror code from above with "right" & "left" exchanged
                {
                    var parentLeft = node.Parent.Left;
                    if (parentLeft.Color == Color.Red)
                    {
                        parentLeft.Color = Color.Black;
                        node.Parent.Color = Color.Red;
                        RotateRight(node.Parent);
                        parentLeft = node.Parent.Left;
                    }
                    if (parentLeft.Right.Color == Color.Black && parentLeft.Left.Color == Color.Black)
                    {
                        parentLeft.Color = Color.Black;
                        node = node.Parent;
                    }
                    else if (parentLeft.Left.Color == Color.Black)
                    {
                        parentLeft.Right.Color = Color.Black;
                        parentLeft.Color = Color.Red;
                        RotateLeft(parentLeft);
                        parentLeft = node.Parent.Left;
                    }
                    parentLeft.Color = node.Parent.Color;
                    node.Parent.Color = Color.Black;
                    parentLeft.Left.Color = Color.Black;
                    RotateRight(node.Parent);
                    node = Root;
                }
            }
            if (node != null)
                node.Color = Color.Black;

        }

        public void DisplayTree(STNode root)
        {
            if (root == null)
            {
                Console.WriteLine("Nothing in the tree!");
                return;
            }

            InOrderDisplay(root);
        }

        private void InOrderDisplay(STNode current)
        {
            if (current != null)
            {
                InOrderDisplay(current.Left);
                Console.Write("({0},{1}) ", current.Low, current.High);
                InOrderDisplay(current.Right);
            }
        }

        private STNode TreeSuccessor(STNode node)
        {
            if (node.Left != null)
            {
                return Minimum(node);
            }

            var parentNode = node.Parent;
            while (parentNode != null && node == parentNode.Right)
            {
                node = parentNode;
                parentNode = parentNode.Parent;
            }
            return parentNode;
        }

        private STNode Minimum(STNode node)
        {
            while (node.Left.Left != null)
            {
                node = node.Left;
            }
            if (node.Left.Right != null)
            {
                node = node.Left.Right;
            }
            return node;
        }
    };
}
