namespace BaseAlgorithms.LeetCode.Graph.SingleSourceShortestPath
{
    public class CheapestFlightsWithinKStopsBellmanFordAlgorithm
    {
        //https://leetcode.com/explore/learn/card/graph/622/single-source-shortest-path-algorithm/3866/
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
            // We use two arrays for storing distances and keep swapping
            // between them to save on the memory
            var distances = new long[2][];

            for (var i = 0; i < 2; i++)
            {
                distances[i] = new long [n];
                for (var j = 0; j < n; j++)
                    distances[i][j] = int.MaxValue;
            }
            
            distances[0][src] = distances[1][src] = 0;
        
            // K + 1 iterations of Bellman Ford
            for (var iterations = 0; iterations < k + 1; iterations++) {
            
                // Iterate over all the edges
                foreach (var edge in flights) {
                
                    int s = edge[0], d = edge[1], wUV = edge[2];
                
                    // Current distance of node "s" from src
                    var dU = distances[1 - iterations&1][s];
                
                    // Current distance of node "d" from src
                    // Note that this will port existing values as
                    // well from the "previous" array if they didn't already exist
                    var dV = distances[iterations&1][d];
                
                    // Relax the edge if possible
                    if (dU + wUV < dV) {
                        distances[iterations&1][d] = dU + wUV;
                    }
                }
            }
        
            return distances[k&1][dst] < int.MaxValue ? (int)distances[k&1][dst] : -1;
        }
    }
}