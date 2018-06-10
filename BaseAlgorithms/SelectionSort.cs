﻿namespace BaseAlgorithms
{
    public class SelectionSort
    {
        public static void Sort(int[] list)
        {
            for (var i = 0; i < list.Length - 1; i++)
            {
                var min = i;
                for (var j = i + 1; j < list.Length; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }
                var dummy = list[i];
                list[i] = list[min];
                list[min] = dummy;
            }
        }
    }
}
