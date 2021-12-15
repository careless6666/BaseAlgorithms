using System;

namespace BaseAlgorithms.PopularTasks
{
    public class LongestCommonSubsequence
    {
        public static int LCS(char[] x, char[] y, int m, int n)
        {
            var cache = new int[m + 1, n + 1];

            /* Following steps build L[m+1][n+1]  
            in bottom up fashion. Note 
            that L[i][j] contains length of  
            LCS of X[0..i-1] and Y[0..j-1] */
            for (var i = 0; i <= m; i++)
            {
                for (var j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        cache[i, j] = 0;
                    else if (x[i - 1] == y[j - 1])
                        cache[i, j] = cache[i - 1, j - 1] + 1;
                    else
                        cache[i, j] = Math.Max(cache[i - 1, j], cache[i, j - 1]);
                }
            }
            return cache[m, n];
        }


        public static int LCSSimple(char[] x, char[] y, int m, int n)
        {
            if (m == 0 || n == 0)
                return 0;

            if (x[m - 1] == y[n - 1])
                return 1 + LCSSimple(x, y, m - 1, n - 1);

            return Math.Max(LCSSimple(x, y, m, n - 1), LCSSimple(x, y, m - 1, n));
        }

    }
}
