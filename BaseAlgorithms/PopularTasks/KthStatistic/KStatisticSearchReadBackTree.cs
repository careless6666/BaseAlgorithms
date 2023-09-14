using System;
using System.Collections.Generic;
using System.Text;
using BaseAlgorithms.Data_Structures;

namespace BaseAlgorithms.PopularTasks
{
    /// <summary>
    /// Поиск к статистики через красно черное дерево
    /// </summary>
    public class KStatisticSearchReadBackTree
    {
        RedBlackTree rbTree = new RedBlackTree();

        public KStatisticSearchReadBackTree(int[] srcArr)
        {
            foreach (var i in srcArr)
                rbTree.Insert(i);
        }

        public int GetStatistic(int k)
        {
            return GetStatistic(rbTree.Root, k).Data;
        }

        private KStatisticRBNode GetStatistic(KStatisticRBNode node, int k)
        {
            var r = (node.Left?.Size ?? 0) + 1;

            if (k == r)
                return node;

            if (k < r)
            {
                return GetStatistic(node.Left, k);
            }

            return GetStatistic(node.Right, k - r);
        }


        public class RedBlackTree
        {

            public KStatisticRBNode Root { get; set; }

            private void RotateLeft(KStatisticRBNode node)
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

            private void RotateRight(KStatisticRBNode node)
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


            private void FixViolation(KStatisticRBNode node)
            {
                while (node != Root && (node.Color != Color.Black) &&
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

            private void SwapColor(KStatisticRBNode a, KStatisticRBNode b)
            {
                var tmp = a.Color;
                a.Color = b.Color;
                b.Color = tmp;
            }

            /* A utility function to insert a new node with given key 
            in BST */
            KStatisticRBNode BSTInsert(KStatisticRBNode root, KStatisticRBNode node)
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
                var node = new KStatisticRBNode(data);

                // Do a normal BST insert 
                Root = BSTInsert(Root, node);

                // fix Red Black Tree violations 
                FixViolation(node);
            }

            public KStatisticRBNode Search(KStatisticRBNode root, int key)
            {
                var isFound = false;
                var temp = root;
                KStatisticRBNode item = null;
                while (!isFound)
                {
                    if (temp == null)
                    {
                        break;
                    }
                    if (key < temp.Data)
                    {
                        temp = temp.Left;

                        if (temp == null)
                            return null;

                    }
                    if (key > temp.Data)
                    {
                        temp = temp.Right;
                        if (temp == null)
                            return null;
                    }
                    if (key == temp.Data)
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

            public void Delete(KStatisticRBNode root, int key)
            {
                //first find the node in the tree to delete and assign to item pointer/reference
                var item = Search(root, key);
                KStatisticRBNode itemNode;

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
                    item.Data = itemNode.Data;
                }
                if (itemNode.Color == Color.Black)
                {
                    DeleteFixUp(root, childNode);
                }

            }

            private void DeleteFixUp(KStatisticRBNode root, KStatisticRBNode node)
            {

                while (node != null && node != root && node.Color == Color.Black)
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
                        node = root; //case 4
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
                        node = root;
                    }
                }
                if (node != null)
                    node.Color = Color.Black;

            }

            public void DisplayTree(KStatisticRBNode root)
            {
                if (root == null)
                {
                    Console.WriteLine("Nothing in the tree!");
                    return;
                }

                InOrderDisplay(root);
            }

            private void InOrderDisplay(KStatisticRBNode current)
            {
                if (current != null)
                {
                    InOrderDisplay(current.Left);
                    Console.Write("({0}) ", current.Data);
                    InOrderDisplay(current.Right);
                }
            }

            private KStatisticRBNode TreeSuccessor(KStatisticRBNode node)
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

            private KStatisticRBNode Minimum(KStatisticRBNode node)
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

        }
    }

    public class KStatisticRBNode : RBNode
    {
        public KStatisticRBNode(int data) : base(data)
        {

        }

        public new KStatisticRBNode Left { get; set; }
        public new KStatisticRBNode Right { get; set; }
        public new KStatisticRBNode Parent { get; set; }

        public int Size => (Left?.Size ?? 0) + (Right?.Size ?? 0) + 1;
    }

}
