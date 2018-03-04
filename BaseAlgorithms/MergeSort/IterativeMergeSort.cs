namespace BaseAlgorithms.MergeSort
{
    public class IterativeMergeSort
    {
        public static int[] Sort(int[] arr)
        {
            MergeSort(arr, arr.Length);

            return arr;
        }

        static void MergeSort(int[] arr, int n)
        {
            int currSize;  // For current size of subarrays to be merged
            // curr_size varies from 1 to n/2
            // to be merged

            // Merge subarrays in bottom up manner.  First merge subarrays of
            // size 1 to create sorted subarrays of size 2, then merge subarrays
            // of size 2 to create sorted subarrays of size 4, and so on.
            for (currSize = 1; currSize <= n - 1; currSize = 2 * currSize)
            {
                // Pick starting point of different subarrays of current size
                int leftStart; // For picking starting index of left subarray
                for (leftStart = 0; leftStart < n - 1; leftStart += 2 * currSize)
                {
                    // Find ending point of left subarray. mid+1 is starting 
                    // point of right
                    int mid = leftStart + currSize - 1;

                    int rightEnd = Min(leftStart + 2 * currSize - 1, n - 1);

                    // Merge Subarrays arr[left_start...mid] & arr[mid+1...right_end]
                    Merge(arr, leftStart, mid, rightEnd);
                }
            }
        }

        /* Function to merge the two haves arr[l..m] and arr[m+1..r] of array arr[] */
        static void Merge(int[] arr, int l, int m, int r)
        {
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;

            /* create temp arrays */
            var lArr = new int[n1]; 
            var rArr = new int[n2];

            /* Copy data to temp arrays L[] and R[] */
            for (i = 0; i < n1; i++)
                lArr[i] = arr[l + i];
            for (j = 0; j < n2; j++)
                rArr[j] = arr[m + 1 + j];

            /* Merge the temp arrays back into arr[l..r]*/
            i = 0;
            j = 0;
            k = l;
            while (i < n1 && j < n2)
            {
                if (lArr[i] <= rArr[j])
                {
                    arr[k] = lArr[i];
                    i++;
                }
                else
                {
                    arr[k] = rArr[j];
                    j++;
                }
                k++;
            }

            /* Copy the remaining elements of L[], if there are any */
            while (i < n1)
            {
                arr[k] = lArr[i];
                i++;
                k++;
            }

            /* Copy the remaining elements of R[], if there are any */
            while (j < n2)
            {
                arr[k] = rArr[j];
                j++;
                k++;
            }
        }

        // Utility function to find minimum of two integers
        private static int Min(int x, int y) { return (x < y) ? x : y; }
    }
}
