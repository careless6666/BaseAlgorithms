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

        public RBNode Uncle()
        {
            // If no parent or grandparent, then no uncle 
            if (Parent?.Parent == null)
                return null;

            if (Parent.IsOnLeft())
                // uncle on right 
                return Parent.Parent.Right;
            else
                // uncle on left 
                return Parent.Parent.Left;
        }

        bool IsOnLeft() { return this == Parent.Left; }

        RBNode Sibling()
        {
            // sibling null if no parent 
            if (Parent == null)
                return null;

            if (IsOnLeft())
                return Parent.Right;

            return Parent.Left;
        }

        // moves node down and moves given node in its place 
        void MoveDown(RBNode nParent)
        {
            if (Parent != null)
            {
                if (IsOnLeft())
                {
                    Parent.Left = nParent;
                }
                else
                {
                    Parent.Right = nParent;
                }
            }
            nParent.Parent = Parent;
            Parent = nParent;
        }

        bool HasRedChild()
        {
            return (Left != null && Left.Color == Color.Red) || 
                (Right != null && Right.Color == Color.Red);
        }

    }

    public enum Color {
        Red,
        Black
    }
}
