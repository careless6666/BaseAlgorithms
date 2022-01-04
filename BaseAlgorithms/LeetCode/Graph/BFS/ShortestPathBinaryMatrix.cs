using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode.Graph.BFS
{
    public class ShortestPathBinaryMatrixTask
    {
        private static readonly int[][] Directions = 
            new int[][]{ new [] {-1, -1}, new [] {-1, 0}, new []{-1, 1}, new [] {0, -1}, new [] {0, 1},new [] {1, -1},
                new [] {1, 0}, new [] {1, 1}};
        
        public int ShortestPathBinaryMatrix(int[][] grid) {
            // Firstly, we need to check that the start and target cells are open.
            if (grid[0][0] != 0 || grid[^1][grid[0].Length - 1] != 0) {
                return -1;
            }
        
            // Set up the BFS.
            Queue<int[]> queue = new ();
            grid[0][0] = 1;
            queue.Enqueue(new int[]{0, 0});
        
            // Carry out the BFS
            while (queue.Count > 0) {
                var cell = queue.Dequeue();
                var row = cell[0];
                var col = cell[1];
                var distance = grid[row][col];
                if (row == grid.Length - 1 && col == grid[0].Length - 1) {
                    return distance;
                }
                foreach (int[] neighbour in GetNeighbours(row, col, grid)) {
                    var neighbourRow = neighbour[0];
                    var neighbourCol = neighbour[1];
                    queue.Enqueue(new int[]{neighbourRow, neighbourCol});
                    grid[neighbourRow][neighbourCol] = distance + 1;
                }
            }
        
            // The target was unreachable.
            return -1;
        }
        
        private List<int[]> GetNeighbours(int row, int col, int[][] grid) {
            List<int[]> neighbours = new ();
            for (var i = 0; i < Directions.Length; i++) {
                var newRow = row + Directions[i][0];
                var newCol = col + Directions[i][1];
                if (newRow < 0 || newCol < 0 || newRow >= grid.Length 
                    || newCol >= grid[0].Length
                    || grid[newRow][newCol] != 0) {
                    continue;    
                }
                neighbours.Add(new[]{newRow, newCol});
            }
            return neighbours; 
        }
    }
}