using System.Collections.Generic;
using System.Linq;

namespace BaseAlgorithms.LeetCode.Graph.DFS
{
    public class AllPathsFromSourceToTarget
    {
        public void Dfs(int start, int end, Dictionary<int, List<int>> graphDict, List<int> currentPath, List<List<int>> resultList)
        {
            currentPath.Add(start);
            if (start == end)
            {
                resultList.Add(currentPath);
                return;
            }

            foreach (var gr in graphDict[start])
            {
                Dfs(gr, end, graphDict, currentPath.ToList(), resultList);
            }
        }

        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {
            var graphDict = new Dictionary<int, List<int>>();

            for (int i = 0; i < graph.Length; i++)
            {
                graphDict[i] = new List<int>(graph[i]);
            }

            var resultList = new List<List<int>>();
            Dfs(0, graph.Length - 1, graphDict, new List<int>(), resultList);

            return resultList.ToArray();
        }
    }
}