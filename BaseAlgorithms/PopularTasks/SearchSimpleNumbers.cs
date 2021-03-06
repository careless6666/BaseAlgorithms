using System.Collections.Generic;

namespace BaseAlgorithms.PopularTasks
{
    public class SearchSimpleNumbers
    {
        public static int[] SieveEratosthenes(int n)
        {
            var tmpArr = new int[n];

            for (var i = 2; i < n; i++)
            {
                tmpArr[i] = i;
            }

            for (var i = 2; i < tmpArr.Length; i++)
            {
                var multiple = 2;

                var next = i * multiple;
                
                while (next < n)
                {
                    tmpArr[next] = -1;
                    multiple++;
                    next = i * multiple;
                }
            }

            var result = new List<int>();

            for (var i = 2; i < tmpArr.Length; i++)
            {
                if(tmpArr[i] != -1)
                    result.Add(i);
            }

            return result.ToArray();
        }
        
 }
}