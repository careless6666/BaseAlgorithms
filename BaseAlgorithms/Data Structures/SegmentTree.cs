using System;
using System.Collections.Generic;
using System.Text;

namespace BaseAlgorithms.Data_Structures
{

    public class SegmentTree
    {
        public STNode NewNode(Interval i)
        {
            var temp = new STNode
            {
                Interval = new Interval(i),
                Max = i.High
            };

            temp.Left = temp.Right = null;

            return temp;
        }

        // A utility function to insert a new Interval Search Tree Node 
        // This is similar to BST Insert.  Here the low value of interval 
        // is used tomaintain BST property 
        public STNode Insert(STNode root, Interval i)
        {
            // Base case: Tree is empty, new node becomes root 
            if (root == null)
                return NewNode(i);

            // Get low value of interval at root 
            var l = root.Interval.Low;

            // If root's low value is smaller, then new interval goes to 
            // left subtree 
            if (i.Low < l)
                root.Left = Insert(root.Left, i);

            // Else, new node goes to right subtree. 
            else
                root.Right = Insert(root.Right, i);

            // Update the max value of this ancestor if needed 
            if (root.Max < i.High)
                root.Max = i.High;

            return root;
        }

        // A utility function to check if given two intervals overlap 
        public bool DoOverlap(Interval i1, Interval i2)
        {
            if (i1.Low <= i2.High && i2.Low <= i1.High)
                return true;
            return false;
        }

        // The main function that searches a given interval i in a given 
        // Interval Tree. 
        public Interval OverlapSearch(STNode root, Interval i)
        {
            // Base Case, tree is empty 
            if (root == null) return null;

            // If given interval overlaps with root 
            if (DoOverlap(root.Interval, i))
                return root.Interval;

            // If left child of root is present and max of left child is 
            // greater than or equal to given interval, then i may 
            // overlap with an interval is left subtree 
            if (root.Left != null && root.Left.Max >= i.Low)
                return OverlapSearch(root.Left, i);

            // Else interval can only overlap with right subtree 
            return OverlapSearch(root.Right, i);
        }

        public void InOrder(STNode root)
        {
            if (root == null) return;

            InOrder(root.Left);

            Console.WriteLine("[" + root.Interval.Low + ", " + root.Interval.High + "]"
                + " max = " + root.Max);

            InOrder(root.Right);
        }

    }

    public class STNode
    {
        public Interval Interval;  // 'i' could also be a normal variable 
        public int Max;
        public  STNode Left, Right; 
    };

    public class Interval
    {
        public Interval(int low, int high)
        {
            Low = low;
            High = high;
        }

        public Interval(Interval i)
        {
            Low = i.Low;
            High = i.High;
        }

        public int Low, High;
    };
}
