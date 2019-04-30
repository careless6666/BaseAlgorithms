using System;

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

        public RBNode Search(RBNode root, int key)
        {
            var isFound = false;
            var temp = root;
            RBNode item = null;
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

        public void Delete(RBNode root, int key)
        {
            //first find the node in the tree to delete and assign to item pointer/reference
            var item = Search(root, key);
            RBNode itemNode;

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

        private void DeleteFixUp(RBNode root, RBNode node)
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
                        RotateLeft(root, node.Parent); //case 1
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
                        RotateRight(root,parentRight); //case 3
                        parentRight = node.Parent.Right; //case 3
                    }
                    parentRight.Color = node.Parent.Color; //case 4
                    node.Parent.Color = Color.Black; //case 4
                    parentRight.Right.Color = Color.Black; //case 4
                    RotateLeft(root, node.Parent); //case 4
                    node = root; //case 4
                }
                else //mirror code from above with "right" & "left" exchanged
                {
                    var parentLeft = node.Parent.Left;
                    if (parentLeft.Color == Color.Red)
                    {
                        parentLeft.Color = Color.Black;
                        node.Parent.Color = Color.Red;
                        RotateRight(root, node.Parent);
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
                        RotateLeft(root, parentLeft);
                        parentLeft = node.Parent.Left;
                    }
                    parentLeft.Color = node.Parent.Color;
                    node.Parent.Color = Color.Black;
                    parentLeft.Left.Color = Color.Black;
                    RotateRight(root, node.Parent);
                    node = root;
                }
            }
            if (node != null)
                node.Color = Color.Black;

        }

        public void DisplayTree(RBNode root)
        {
            if (root == null)
            {
                Console.WriteLine("Nothing in the tree!");
                return;
            }

            InOrderDisplay(root);
        }

        private void InOrderDisplay(RBNode current)
        {
            if (current != null)
            {
                InOrderDisplay(current.Left);
                Console.Write("({0}) ", current.Data);
                InOrderDisplay(current.Right);
            }
        }

        private RBNode TreeSuccessor(RBNode node)
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

        private RBNode Minimum(RBNode node)
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


/*
 * Красно-черное дерево - это бинарное дерево с следующими свойствами:
 * Каждый узел покрашен либо в черный, либо в красный цвет.
 * Листьями объявляются NIL-узлы (т.е. "виртуальные" узлы, наследники узлов, которые обычно называют листьями; на них "указывают" NULL указатели). Листья покрашены в черный цвет.
 * Если узел красный, то оба его потомка черны.
 * На всех ветвях дерева, ведущих от его корня к листьям, число черных узлов одинаково.
 * Количество черных узлов на ветви от корня до листа называется черной высотой дерева. Перечисленные свойства гарантируют,
 * что самая длинная ветвь от корня к листу не более чем вдвое длиннее любой другой ветви от корня к листу. Чтобы понять, почему это так, рассмотрим дерево с черной высотой 2.
 * Кратчайшее возможное расстояние от корня до листа равно двум - когда оба узла черные.
 * Длиннейшее расстояние от корня до листа равно четырем - узлы при этом покрашены (от корня к листу) так: красный, черный, красный, черный.
 * Сюда нельзя добавить черные узлы, поскольку при этом нарушится свойство 4, из которого вытекает корректность понятия черной высоты. Поскольку согласно свойству 3
 * у красных узлов непременно черные наследники, в подобной последовательности недопустимы и два красных узла подряд. Таким образом, длиннейший путь, который мы можем
 * сконструировать, состоит из чередования красных и черных узлов, что и приводит нас к удвоенной длине пути, проходящего только через черные узлы. Все операции
 * над деревом должны уметь работать с перечисленными свойствами. В частности, при вставке и удалении эти свойства должны сохраниться.
 *
 *
 *
 * source http://algolist.manual.ru/ds/rbtree.php
 *
 *
 */



