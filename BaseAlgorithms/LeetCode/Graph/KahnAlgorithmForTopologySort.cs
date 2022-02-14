using System;
using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode.Graph
{
    public class KahnAlgorithmForTopologySort
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites) {
            var isPossible = true;
            Dictionary<int, List<int>> adjList = new ();
            var indegree = new int[numCourses];
            var topologicalOrder = new int[numCourses];

            // Create the adjacency list representation of the graph
            for (var j = 0; j < prerequisites.Length; j++) {
                var dest = prerequisites[j][0];
                var src = prerequisites[j][1];
                if (!adjList.ContainsKey(src))
                    adjList[src] = new List<int>();
            
                adjList[src].Add(dest);

                // Record in-degree of each vertex
                indegree[dest] += 1;
            }

            // Add all vertices with 0 in-degree to the queue
            Queue<int> q = new ();
            for (var j = 0; j < numCourses; j++) {
                if (indegree[j] == 0) {
                    q.Enqueue(j);
                }
            }

            var i = 0;
            // Process until the Q becomes empty
            while (q.Count != 0) {
                var node = q.Dequeue();
                topologicalOrder[i++] = node;

                // Reduce the in-degree of each neighbor by 1
                if (adjList.ContainsKey(node)) {
                    foreach (var neighbor in adjList[node]) {
                        indegree[neighbor]--;

                        // If in-degree of a neighbor becomes 0, add it to the Q
                        if (indegree[neighbor] == 0) {
                            q.Enqueue(neighbor);
                        }
                    }
                }
            }

            // Check to see if topological sort is possible or not.
            if (i == numCourses) {
                return topologicalOrder;
            }

            return Array.Empty<int>();
        }
    }
}