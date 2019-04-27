using System;
using System.Collections.Generic;
using System.Text;

namespace BaseAlgorithms.Data_Structures
{
    public class RBNode
    {
        public int Data { get; set; }
        public Color Color { get; set; }
        public  RBNode Left { get; set; }
        public  RBNode Right { get; set; }
        public  RBNode Parent { get; set; }

        public RBNode(int data) => Data = data;
        
    }

    public enum Color {
        Red,
        Black
    }
}
