using System.Collections.Generic;
using System.Linq;

namespace BaseAlgorithms.LeetCode.Graph.BFS
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

        public void Bfs(int start, int end, Dictionary<int, List<int>> graphDict, List<int> currentPath,
            List<List<int>> resultList)
        {
            var queue = new Queue<(int, int)>();

            queue.Enqueue((start, 0));

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                
                currentPath.Add(node.Item1);

                if (resultList.Count == 0)
                {
                    resultList.Add(new List<int>() { node.Item1});
                }
                else
                {
                    foreach (var item in resultList)
                    {
                        if (item.Count == node.Item2)
                        {
                            item.Add(node.Item1);
                            break;
                        }
                    }    
                }

                if (start == end)
                {
                    //resultList.Add(currentPath);
                    continue;
                }

                foreach (var gr in graphDict[start])
                    queue.Enqueue((gr, node.Item2 + 1));
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