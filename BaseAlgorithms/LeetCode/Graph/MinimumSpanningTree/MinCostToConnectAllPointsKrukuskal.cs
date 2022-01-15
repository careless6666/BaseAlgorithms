using System;

namespace BaseAlgorithms.LeetCode.Graph.MinimumSpanningTree
{
    public class MinCostToConnectAllPointsKrukuskal
    {
        public int MinCostConnectPoints(int[][] points) {
        var v = points.Length;
            var e = (v * (v - 1))/2;
        
            // keeps track of the distance between any two vertex
            var dist = new int[e][];
            
            // store distance and vertices in a v x 3 array
            for (var i = 0 ; i < e; i++)
            {
                dist[i] = new int[3];            
            }
            
            var m = 0;
            for (var i = 0; i < v; i++)
            {
                for (var j = i + 1; j < v; j++)
                {
                    int d = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                    dist[m][0] = i;
                    dist[m][1] = j;
                    dist[m][2] = d;
                    m++;
                }
            }
            
            // sort based on distance
            Array.Sort(dist, (x, y) => x[2].CompareTo(y[2]));
        
            // for union find with union by rank
            var root = new int[v];
            var rank = new int[v];
        
            for (var i = 0; i < v; i++)
            {
                root[i] = i;
                rank[i] = 1;
            }
            
            var min = 0;
            var se = 0;
            for (var i = 0; i < e; i++)
            {
                if (Union(root, rank, dist[i][0], dist[i][1]))
                {
                    min += dist[i][2];
                    se++;
                
                    if (se == v - 1)
                    {
                        break;
                    }
                }
            }
        
            return min;
        }
        
        private int Find(int[] root, int x)
        {
            if (x == root[x])
            {
                return x;
            }
        
            // path compression optimization
            return root[x] = Find(root, root[x]);
        }
    
        // union by rank
        private bool Union(int[] root, int[] rank, int x, int y)
        {
            var rootX = Find(root, x);
            var rootY = Find(root, y);
        
            if (rootX != rootY)
            {
                if (rank[rootX] > rank[rootY])
                {
                    root[rootY] = rootX;
                }
                else if (rank[rootY] > rank[rootX])
                {
                    root[rootX] = rootY;
                }
                else
                {
                    root[rootY] = rootX;
                    rank[rootX] += 1;
                }
            
                return true;
            }
        
            return false;
        }
    }
}