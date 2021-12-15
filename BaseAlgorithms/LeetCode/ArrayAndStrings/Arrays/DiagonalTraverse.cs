using System;
using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode.ArrayAndStrings.Arrays
{
    public class DiagonalTraverse
    {
        public int[] FindDiagonalOrder(int[][] mat) {
            if (mat.Length == 0)
                return Array.Empty<int>();

            var m = mat.Length;

            if (mat[0].Length == 0)
                return Array.Empty<int>();

            var n = mat[0].Length;

            var result = new List<int> {mat[0][0]};

            var upDirection = true;

            var i = 0;
            var j = 0;

            while (result.Count < m * n)
            {
                if (upDirection)
                {
                    if (i - 1 >= 0 && j + 1 < n)
                    {
                        i--;
                        j++;
                    }
                    else
                    {
                        if (j + 1 < n)
                        {
                            j++;
                        }
                        else
                        {
                            if (i < m)
                                i++;
                        }

                        upDirection = !upDirection;
                    }
                }
                else
                {
                    if (j - 1 >= 0 && i + 1 < m)
                    {
                        i++;
                        j--;
                    }
                    else
                    {
                        if (i + 1 < m)
                        {
                            i++;
                        }
                        else
                        {
                            if (j < n)
                                j++;
                        }

                        upDirection = !upDirection;
                    }
                }

                result.Add(mat[i][j]);
            }

            return result.ToArray();
        }
    }
}