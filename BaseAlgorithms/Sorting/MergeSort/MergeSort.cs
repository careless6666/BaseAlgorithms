using System.Linq;

namespace BaseAlgorithms.MergeSort
{
    public class MergeSort
    {
        public static int[] Sort(int[] arr)
        {
            if (arr.Length == 1)
                return arr;

            var middlePoint = arr.Length / 2;
            return Merge(Sort(arr.Take(middlePoint).ToArray()), 
                Sort(arr.Skip(middlePoint).ToArray()));
        }

        private static int[] Merge(int[] leftArr, int[] rightArr)
        {
            var leftCounter = 0;
            var rightCounter = 0;

            var merged = new int[leftArr.Length + rightArr.Length];
            for (var i = 0; i < leftArr.Length + rightArr.Length; i++)
            {
                if (rightCounter < rightArr.Length && leftCounter < leftArr.Length)
                {
                    if (leftArr[leftCounter] > rightArr[rightCounter])
                        merged[i] = rightArr[rightCounter++];
                    else
                        merged[i] = leftArr[leftCounter++];
                }
                else
                {
                    if (rightCounter < rightArr.Length)
                        merged[i] = rightArr[rightCounter++];
                    else
                        merged[i] = leftArr[leftCounter++];
                }
            }

            return merged;
        }
    }
}
