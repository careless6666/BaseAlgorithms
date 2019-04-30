using System;
using BaseAlgorithms.Data_Structures;

namespace BaseAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new RedBlackTree();

            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(-1);
            tree.Insert(11);
            tree.Insert(6);
            tree.DisplayTree(tree.Root);
            tree.Delete(tree.Root, -1);
            tree.DisplayTree(tree.Root);
            tree.Delete(tree.Root, 9);
            tree.DisplayTree(tree.Root);
            tree.Delete(tree.Root, 5);
            tree.DisplayTree(tree.Root);
            Console.ReadLine();
        }
    }
}
