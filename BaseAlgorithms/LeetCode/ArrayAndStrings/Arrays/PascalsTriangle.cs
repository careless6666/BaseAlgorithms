using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode.ArrayAndStrings.Arrays
{
    public class PascalsTriangle
    {
        public IList<IList<int>> Generate(int numRows)
        {
            var res = new int[numRows][];
            res[0] = new[] {1};

            if (numRows == 1)
            {
                return res;
            }

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
    }
}