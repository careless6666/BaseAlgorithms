using System.Collections.Generic;
using System.Linq;

namespace BaseAlgorithms.LeetCode.ArrayAndStrings.Arrays
{
    public class PascalsTriangle
    {
        public IList<IList<int>> Generate(int numRows)
        {
            var res = new int[numRows][];
            res[0] = new[] {1};

            if (numRows == 1)
                return res;
            
            for (var i = 1; i < numRows; i++)
            {
                res[i] = new int [i + 1];
                for (var j = 0; j < i + 1; j++)
                {
                    var left = (j - 1) < 0 ? 0 : res[i - 1][j - 1];
                    var right = (j) >= res[i - 1].Length ? 0 : res[i - 1][j];
                    res[i][j] = left + right;
                }
            }

            return res;
        }

        public IList<int> GetRow(int rowIndex) {
            var row = new int[rowIndex + 1];
            row[0] = 1;
            
            for (var i = 0; i < rowIndex + 1; i++)
            {
                var lastSize = 1;
                for (var j = i; j > 0; j--) {
                    row[j] = row[j] + row[j - 1];
                    lastSize = j;
                }
                row[lastSize - 1] = 1;
            }

            return row.ToList();
        }
    }
}