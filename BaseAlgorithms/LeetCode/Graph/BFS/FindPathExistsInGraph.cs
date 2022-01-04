using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode.Graph.BFS
{
    public class FindPathExistsInGraph
    {
        public bool Bfs (int start, int end, Dictionary<int, List<int>> graph, HashSet<int> visited) {
        
            var queue = new Queue<int>();

            queue.Enqueue(start);
            
            while(queue.Count > 0){
                var node = queue.Dequeue();

                if (node == end)
                    return true;

                if (!visited.Contains(node))
                {
                    visited.Add(node);
                    foreach (var item in graph[node])
                    {
                        queue.Enqueue(item);
                    }
                }
            }

            return false;
        }
    
        public bool ValidPath(int n, int[][] edges, int start, int end) {
            HashSet<int> visited = new ();
    
            Dictionary<int,List<int>> graph = new ();
    
            for(var i = 0; i < n; i++ ) {
                graph.Add(i, new List<int>());
            }
    
            foreach(var pair in  edges) {
                graph[pair[0]].Add(pair[1]);
                graph[pair[1]].Add(pair[0]);
            }
    
            return Bfs(start, end, graph, visited);
        }
    }
}