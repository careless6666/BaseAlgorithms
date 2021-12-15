namespace BaseAlgorithms.LeetCode.Graph.DisjoinSet
{
    public class PathCompressionOptimization
    {
        private int[] root;

        public PathCompressionOptimization(int size) {
            root = new int[size];
            for (int i = 0; i < size; i++) {
                root[i] = i;
            }
        }

        public int Find(int x) {
            if (x == root[x]) {
                return x;
            }
            return root[x] = Find(root[x]);
        }

        public void Union(int x, int y) {
            int rootX = Find(x);
            int rootY = Find(y);
            if (rootX != rootY) {
                root[rootY] = rootX;
            }
        }

        public bool Connected(int x, int y) {
            return Find(x) == Find(y);
        }
    }
}