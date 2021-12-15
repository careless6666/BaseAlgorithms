﻿namespace BaseAlgorithms
{
    public class QuickSortIterative
    {
        public static void Sort(ref int[] data)
        {
            var startIndex = 0;
            var endIndex = data.Length - 1;
            var top = -1;
            var stack = new int[data.Length];

            stack[++top] = startIndex;
            stack[++top] = endIndex;

            while (top >= 0)
            {
                endIndex = stack[top--];
                startIndex = stack[top--];

                var p = Partition(ref data, startIndex, endIndex);

                if (p - 1 > startIndex)
                {
                    stack[++top] = startIndex;
                    stack[++top] = p - 1;
                }

                if (p + 1 >= endIndex)
                    continue;

                stack[++top] = p + 1;
                stack[++top] = endIndex;
            }
        }

        private static int Partition(ref int[] data, int left, int right)
        {
            var x = data[right];
            var i = (left - 1);

            for (var j = left; j <= right - 1; ++j)
            {
                if (data[j] <= x)
                {
                    ++i;
                    Swap(ref data[i], ref data[j]);
                }
            }

            Swap(ref data[i + 1], ref data[right]);

            return (i + 1);
        }

        private static void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

    }
}
