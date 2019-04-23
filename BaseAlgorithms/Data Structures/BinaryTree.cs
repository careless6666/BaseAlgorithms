using System;
using System.Collections.Generic;
using System.Text;

namespace BaseAlgorithms.Data_Structures
{
    public class Node
    {
        public Node() { }
        public Node(int item) => Data = item;
        

        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }


}
