using System;
using System.Collections.Generic;

namespace BaseAlgorithms.HeapSort
{
    public class PyramidSort
    {
        static int Add2Pyramid(IList<int> arr, int i, int n)
        {
            int imax;
            if ((2 * i + 2) < n)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else
                imax = 2 * i + 1;

            if (imax >= n)
                return i;

            if (arr[i] >= arr[imax])
                return i;

            var buf = arr[i];
            arr[i] = arr[imax];
            arr[imax] = buf;

            if (imax < n / 2)
                i = imax;

            return i;
        }

        public static void Sort(int[] arr, int len)
        {
            //step 1: building the pyramid
            for (int i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = Add2Pyramid(arr, i, len);
                if (prev_i != i) ++i;
            }

            //step 2: sorting
            for (int k = len - 1; k > 0; --k)
            {
                var buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = Add2Pyramid(arr, i, k);
                }
            }
        }
    }
}
