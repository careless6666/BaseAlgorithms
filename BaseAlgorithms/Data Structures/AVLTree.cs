using System;
using System.Collections.Generic;
using System.Text;

namespace BaseAlgorithms.Data_Structures
{
    public class AVLTree
    {
        private Node _root;

        public Node Root => _root;

        public void Add(int data)
        {
            var newItem = new Node(data);
            if (Root == null)
            {
                _root = newItem;
            }
            else
            {
                _root = RecursiveInsert(Root, newItem);
            }
        }

        private Node RecursiveInsert(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.Data < current.Data)
            {
                current.Left = RecursiveInsert(current.Left, n);
                current = BalanceTree(current);
            }
            else if (n.Data > current.Data)
            {
                current.Right = RecursiveInsert(current.Right, n);
                current = BalanceTree(current);
            }
            return current;
        }

        private Node BalanceTree(Node current)
        {
            int bFactor = BalanceFactor(current);
            if (bFactor > 1)
            {
                current = BalanceFactor(current.Left) > 0 
                    ? RotateLL(current) 
                    : RotateLR(current);
            }
            else if (bFactor < -1)
            {
                current = BalanceFactor(current.Right) > 0 
                    ? RotateRL(current) 
                    : RotateRR(current);
            }
            return current;
        }

        public void Delete(int target)
        {//and here
            _root = Delete(_root, target);
        }
        private Node Delete(Node current, int target)
        {
            if (current == null)
            { return null; }
            else
            {
                //left subtree
                if (target < current.Data)
                {
                    current.Left = Delete(current.Left, target);
                    if (BalanceFactor(current) == -2)//here
                    {
                        if (BalanceFactor(current.Right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                //right subtree
                else if (target > current.Data)
                {
                    current.Right = Delete(current.Right, target);
                    if (BalanceFactor(current) == 2)
                    {
                        if (BalanceFactor(current.Left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                //if target is found
                else
                {
                    if (current.Right != null)
                    {
                        //delete its inorder successor
                        var parent = current.Right;
                        while (parent.Left != null)
                        {
                            parent = parent.Left;
                        }
                        current.Data = parent.Data;
                        current.Right = Delete(current.Right, parent.Data);
                        if (BalanceFactor(current) == 2)//rebalancing
                        {
                            if (BalanceFactor(current.Left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else { current = RotateLR(current); }
                        }
                    }
                    else
                    {   //if current.left != null
                        return current.Left;
                    }
                }
            }
            return current;
        }

        public bool Find(int key)
        {
            if (Find(key, _root).Data == key)
            {
                Console.WriteLine("{0} was found!", key);
                return true;
            }

            Console.WriteLine("Nothing found!");
            return false;
        }

        private Node Find(int target, Node current)
        {

            if (target < current.Data)
            {
                if (target == current.Data)
                {
                    return current;
                }
                else
                    return Find(target, current.Left);
            }
            else
            {
                if (target == current.Data)
                {
                    return current;
                }
                else
                    return Find(target, current.Right);
            }
        }

        public void DisplayTree()
        {
            if (Root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(Root);
            Console.WriteLine();
        }
        private void InOrderDisplayTree(Node current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.Left);
                Console.Write("({0}) ", current.Data);
                InOrderDisplayTree(current.Right);
            }
        }
        private int Max(int l, int r)
        {
            return l > r ? l : r;
        }

        private int GetHeight(Node current)
        {
            var height = 0;
            if (current != null)
            {
                var l = GetHeight(current.Left);
                var r = GetHeight(current.Right);
                var m = Max(l, r);
                height = m + 1;
            }
            return height;
        }

        /// <summary>
        /// difference of height for right and left subtree
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        private int BalanceFactor(Node current)
        {
            var l = GetHeight(current.Left);
            var r = GetHeight(current.Right);
            var bFactor = l - r;
            return bFactor;
        }
        private Node RotateRR(Node parent)
        {
            var pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }

        private Node RotateLL(Node parent)
        {
            var pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            var pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            var pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }
    }
}

/*
 *
 *АВЛ-дерево (англ. AVL-Tree) — сбалансированное двоичное дерево поиска, в котором поддерживается
 * следующее свойство: для каждой его вершины высота её двух поддеревьев различается не более
 * чем на 1.
 *
 */
