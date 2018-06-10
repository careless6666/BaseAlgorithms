using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseAlgorithms
{
    public class CountingSort
    {
        public static void Sort(int[] arr)
        {
            var n = arr.Length;

            // The output character array that
            // will have sorted arr
            var output = new int[n];


            var countArrSize = arr.Max() + 1;
            // Create a count array to store 
            // count of inidividul characters 
            // and initialize count array as 0
            var count = new int[countArrSize];

            for (var i = 0; i < countArrSize; ++i)
                count[i] = 0;

            // store count of each character
            for (var i = 0; i < n; ++i)
                ++count[arr[i]];

            // Change count[i] so that count[i] 
            // now contains actual position of 
            // this character in output array
            for (var i = 1; i <= countArrSize-1; ++i)
                count[i] += count[i - 1];

            // Build the output character array
            for (var i = 0; i < n; ++i)
            {
                output[count[arr[i]] - 1] = arr[i];
                --count[arr[i]];
            }

            // Copy the output array to arr, so
            // that arr now contains sorted 
            // characters
            for (var i = 0; i < n; ++i)
                arr[i] = output[i];
        }
    }
}
