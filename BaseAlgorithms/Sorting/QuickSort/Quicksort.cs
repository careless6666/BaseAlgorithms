namespace BaseAlgorithms
{
    public class QuickSort
    {
        public static void Sort(int[] elements, int left, int right)
        {
            int i = left, j = right;
            int pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i] < pivot)
                    i++;
                
                while (elements[j] > pivot)
                    j--;
                
                if (i <= j)
                {
                    // Swap
                    (elements[i], elements[j]) = (elements[j], elements[i]);

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
                Sort(elements, left, j);
            
            if (i < right)
                Sort(elements, i, right);
        }
    }
}
