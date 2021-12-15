namespace BaseAlgorithms
{
    public class QuickSortInPlace
    {
        public static void Sort(int[] a) => SortInPlace(a, 0, a.Length - 1);
            
        public static void SortInPlace(int[] a, int first, int last)
        {
            if ((last - first) >= 1)
            {
                var pivotposition = Partition(a, first, last);
                SortInPlace(a, first, pivotposition - 1);
                SortInPlace(a, pivotposition + 1, last);
            }

        }

        private static int Partition(int[] a, int first, int last)
        {
            var pivot = a[last];
            var wallindex = first;
            for (var currentindex = first; currentindex < last; ++currentindex)
            {
                if (a[currentindex] >= pivot)
                    continue;

                Swap(a, wallindex, currentindex);
                ++wallindex;
            }
            Swap(a, wallindex, last);
            return wallindex;

        }
        
        private static void Swap(int[] a, int indexA, int indexB)
        {
            var temp = a[indexA];
            a[indexA] = a[indexB];
            a[indexB] = temp;
        }
    }
}
