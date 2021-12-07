namespace BaseAlgorithms.LeetCode.Graph.DisjoinSet
{
    public class SetQuickFind
    {
        private int[] root;

        public SetQuickFind(int size) {
            root = new int[size];
            for (var i = 0; i < size; i++) {
                root[i] = i;
            }
        }

        public int find(int x) {
            return root[x];
        }
		
        public void Union(int x, int y) {
            var rootX = find(x);
            var rootY = find(y);
            if (rootX != rootY) {
                for (int i = 0; i < root.Length; i++) {
                    if (root[i] == rootY) {
                        root[i] = rootX;
                    }
                }
            }
        }

        public bool Connected(int x, int y) {
            return find(x) == find(y);
        }
    }
}