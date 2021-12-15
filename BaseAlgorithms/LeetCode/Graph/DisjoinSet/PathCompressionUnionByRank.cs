namespace BaseAlgorithms.LeetCode.Graph.DisjoinSet
{
    public class PathCompressionUnionByRank
    {
        private int[] root;
        // Use a rank array to record the height of each vertex, i.e., the "rank" of each vertex.
        private int[] rank;

        public PathCompressionUnionByRank(int size) {
            root = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++) {
                root[i] = i;
                rank[i] = 1; // The initial "rank" of each vertex is 1, because each of them is
                // a standalone vertex with no connection to other vertices.
            }
        }

        // The find function here is the same as that in the disjoint set with path compression.
        public int Find(int x) {
            if (x == root[x]) {
                return x;
            }
            return root[x] = Find(root[x]);
        }

        // The union function with union by rank
        public void Union(int x, int y) {
            int rootX = Find(x);
            int rootY = Find(y);
            if (rootX != rootY) {
                if (rank[rootX] > rank[rootY]) {
                    root[rootY] = rootX;
                } else if (rank[rootX] < rank[rootY]) {
                    root[rootX] = rootY;
                } else {
                    root[rootY] = rootX;
                    rank[rootX] += 1;
                }
            }
        }

        public bool Connected(int x, int y) {
            return Find(x) == Find(y);
        }
    }
}