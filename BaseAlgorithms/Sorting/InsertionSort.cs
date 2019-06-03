using System;

namespace BaseAlgorithms
{
    public class InsertionSort
    {
        public static int[] ReverseSort(int[] arr)
        {
            for (var i = 0; i < arr.Length - 1; i++)
            {
                var j = i + 1;
                while (j > 0)
                {
                    if (arr[j] > arr[j-1])
                    {
                        var temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                    j--;
                }
            }

            return arr;
        }

        public static int[] Sort(int[] arr)
        {
            for (var i = 0; i < arr.Length - 1; i++)
            {
                var j = i + 1;
                while (j > 0)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        var temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                    j--;
                }
            }

            return arr;
        }

    }
}
