using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseAlgorithms.LeetCode.Graph.SingleSourceShortestPath
{
    public class NetworkDelayTimeDijkstra
    {
        Dictionary<int, int> _dist;
        
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            Dictionary<int, List<int[]>> graph = new ();
            foreach (var edge in times) {
                if (!graph.ContainsKey(edge[0]))
                    graph[edge[0]] = new List<int[]>();
                graph[edge[0]].Add(new []{edge[2], edge[1]});
            }
            foreach (int node in graph.Keys)
            {
                graph[node] = graph[node].OrderBy(x => x[0]).ToList();//  arr.ToList();// Collections.sort(graph.get(node), (a, b) -> a[0] - b[0]);
            }
            _dist = new ();
            for (var node = 1; node <= n; ++node)
                _dist[node] =  int.MaxValue;

            Dfs(graph, k, 0);
            var ans = 0;
            foreach (var cand in _dist.Values) {
                if (cand == int.MaxValue) return -1;
                ans = Math.Max(ans, cand);
            }
            return ans;
        }

        private void Dfs(Dictionary<int, List<int[]>> graph, int node, int elapsed) {
            if (elapsed >= _dist[node]) return;
            _dist[node] = elapsed;
            if (graph.ContainsKey(node))
                foreach (int[] info in graph[node])
                    Dfs(graph, info[1], elapsed + info[0]);
        }
    }
}