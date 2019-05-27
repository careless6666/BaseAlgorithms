using System;
using System.Collections.Generic;
using System.Text;

namespace BaseAlgorithms.Sorting
{
    public class BubbleSort
    {
        public void Sort(int[] arr)
        {
            var n = arr.Length;
            for (var i = 0; i < n - 1; i++)
            for (var j = 0; j < n - i - 1; j++)
                if (arr[j] > arr[j + 1])
                {
                    // swap temp and arr[i] 
                    var temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
        }
    }
}
