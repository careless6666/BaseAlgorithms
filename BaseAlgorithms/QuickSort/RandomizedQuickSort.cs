using System;
using System.Collections.Generic;
using System.Text;

namespace BaseAlgorithms
{
    public class RandomizedQuickSort
    {
        public static void Sort(int[] input, int left, int right)
        {
            if (left >= right)
                return;

            int q = RandomizedPartition(input, left, right);
            Sort(input, left, q - 1);
            Sort(input, q + 1, right);
        }

        private static int RandomizedPartition(int[] input, int left, int right)
        {
            var random = new Random();
            var i = random.Next(left, right);

            var pivot = input[i];
            input[i] = input[right];
            input[right] = pivot;

            return Partition(input, left, right);
        }

        private static int Partition(int[] input, int left, int right)
        {
            var pivot = input[right];

            var i = left;
            for (var j = left; j < right; j++)
            {
                if (input[j] > pivot)
                    continue;

                var temp = input[j];
                input[j] = input[i];
                input[i] = temp;
                i++;
            }

            input[right] = input[i];
            input[i] = pivot;

            return i;
        }
    }
}
