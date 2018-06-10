using System.Collections.Generic;

namespace BaseAlgorithms
{
    public class BucketSort
    {
        public static void Sort(int[] arr) => Sort(arr, arr.Length);
        public static void Sort(int[] arr, int n)
        {
            // 1) Create n empty buckets
            var b = new List<int>[n * 100];
            for (var i = 0; i < b.Length; i++)
                b[i] = new List<int>();
            
            // 2) Put array elements in different buckets
            for (var i = 0; i < n; i++)
            {
                var bi = n * arr[i]; // Index in bucket
                b[bi].Add(arr[i]);
            }

            // 3) Sort individual buckets
            for (var i = 0; i < n; i++)
                b[i].Sort();

            // 4) Concatenate all buckets into arr[]
            var index = 0;
            for (var i = 0; i < n*100; i++)
            for (var j = 0; j < b[i].Count; j++)
                arr[index++] = b[i][j];
        }
    }
}
