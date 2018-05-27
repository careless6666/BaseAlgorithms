namespace BaseAlgorithms.HeapSort
{
    /// <summary>
    /// Simple realization of heap sort algorithm, source https://www.geeksforgeeks.org/heap-sort/
    /// </summary>
    public class HeapSortSimple
    {
        // To heapify a subtree rooted with node i which is
        // an index in arr[]. n is size of heap
        static void Heapify(int[] arr, int n, int i)
        {
            var largest = i;  // Initialize largest as root
            var l = 2 * i + 1;  // left = 2*i + 1
            var r = 2 * i + 2;  // right = 2*i + 2

            // If left child is larger than root
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // If right child is larger than largest so far
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // If largest is not root
            if (largest != i)
            {
                Swap(ref arr[i], ref arr[largest]);

                // Recursively heapify the affected sub-tree
                Heapify(arr, n, largest);
            }
        }

        static void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        // main function to do heap sort
        public static void HeapSort(int[] arr, int n)
        {
            // Build heap (rearrange array)
            for (var i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i);

            // One by one extract an element from heap
            for (var i = n - 1; i >= 0; i--)
            {
                // Move current root to end
                Swap(ref arr[0], ref arr[i]);

                // call max heapify on the reduced heap
                Heapify(arr, i, 0);
            }
        }
    }
}
