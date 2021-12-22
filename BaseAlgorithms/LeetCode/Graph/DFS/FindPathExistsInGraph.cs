using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode.Graph.DFS
{
    public class FindPathExistsInGraph
    {
        public bool Dfs(int start, int end, Dictionary<int, List<int>> graph, HashSet<int> visited) {
            if(start == end) 
                return true;
    
            visited.Add(start);
    
            foreach(var i in graph[start]) {
                if(!visited.Contains(i))
                    if(Dfs(i,end, graph, visited)) 
                        return true;
            }
            return false;
        }
    
        public bool ValidPath(int n, int[][] edges, int start, int end) {
            HashSet<int> visited = new ();
    
            Dictionary<int,List<int>> graph = new ();
    
            for(int i = 0; i < n; i++ ) {
                graph.Add(i, new List<int>());
            }
    
            foreach(int[] pair in  edges) {
                graph[pair[0]].Add(pair[1]);
                graph[pair[1]].Add(pair[0]);
            }
    
            return Dfs(start, end, graph, visited);
        }
    }
}