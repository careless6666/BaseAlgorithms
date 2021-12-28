using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode.Graph.DFS
{
    public class AllPathsFromSourceLeadToDestination
    {
        public bool LeadsToDestination(int n, int[][] edges, int source, int destination)
        {
            List<int>[] graph = buildDigraph(n, edges);
            return LeadsToDest(graph, source, destination, new Color?[n]);
        }
        
        private bool LeadsToDest(List<int>[] graph, int node, int dest, Color?[] states) {
        
            // If the state is GRAY, this is a backward edge and hence, it creates a loop.
            if (states[node] != null) {
                return states[node] == Color.BLACK;
            }
        
            // If this is a leaf node, it should be equal to the destination.
            if (graph[node].Count == 0) {
                return node == dest;
            }
        
            // Now, we are processing this node. So we mark it as GRAY
            states[node] = Color.GRAY;
        
            foreach (int next in graph[node]) {
            
                // If we get a `false` from any recursive call on the neighbors, we short circuit and return from there.
                if (!LeadsToDest(graph, next, dest, states)) {
                    return false;
                }
            }
        
            // Recursive processing done for the node. We mark it BLACK
            states[node] = Color.BLACK;
            return true;
        }
    
        private List<int>[] buildDigraph(int n, int[][] edges) {
            var graph = new List<int>[n] ;
            for (var i = 0; i < n; i++) {
                graph[i] = new ();
            }
        
            foreach (var edge in edges) {
                graph[edge[0]].Add(edge[1]);
            }
        
            return graph;
        }
    }
    
    enum Color { GRAY, BLACK };
}