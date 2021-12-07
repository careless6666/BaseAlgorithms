namespace BaseAlgorithms.LeetCode.Graph.DisjoinSet
{
    public class UnionByRank
    {
        private int[] root;
        private int[] rank;

        public UnionByRank(int size) {
            root = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++) {
                root[i] = i;
                rank[i] = 1; 
            }
        }

        public int Find(int x) {
            while (x != root[x]) {
                x = root[x];
            }
            return x;
        }

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