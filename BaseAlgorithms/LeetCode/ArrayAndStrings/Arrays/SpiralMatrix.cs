using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode.ArrayAndStrings.Arrays
{
    public class SpiralMatrix
    {
        public IList<int> SpiralOrder(int[][] matrix) {
            var m = matrix.Length;
            var n = matrix[0].Length;
            //var direction = char[] { 'u', 'r', 'l', 'd' };
            var lastBound = new[] {0, n, -1, m};

            var result = new List<int>();

            var direction = 'r';
            var row = 0;
            var col = 0;

            //result.Add(matrix[row][col]);

            while (result.Count < m * n)
            {
      
                switch (direction)

                {
                    case 'u':
                    {
                        for (var j = lastBound[3] - 1; j > lastBound[0]; j--)
                        {
                            row = j;
                            result.Add(matrix[row][col]);
                        }

                        lastBound[0] = lastBound[0] + 1;
                        col++;
                        direction = 'r';
                        break;
                    }
                    case 'r':
                    {
                        for (var j = lastBound[2] + 1; j < lastBound[1]; j++)
                        {
                            col = j;
                            result.Add(matrix[row][col]);
                        }

                        lastBound[1] = lastBound[1] - 1;
                        row++;
                        direction = 'd';
                        break;
                    }
                    case 'd':
                    {
                        for (var j = lastBound[0] + 1; j < lastBound[3]; j++)
                        {
                            row = j;
                            result.Add(matrix[row][col]);
                        }

                        lastBound[3] = lastBound[3] - 1;
                        col--;
                        direction = 'l';
                        break;
                    }
                    case 'l':
                    {
                        for (var j = lastBound[1] - 1; j > lastBound[2]; j--)
                        {
                            col = j;
                            result.Add(matrix[row][col]);
                        }

                        lastBound[2] = lastBound[2] + 1;
                        row--;
                        direction = 'u';
                        break;
                    }
                }
            }

            return result.ToArray();
        }
    }
}