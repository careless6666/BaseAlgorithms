using System;

namespace BaseAlgorithms
{
    public class InPlaceMergeSort
    {
        public static int[] Sort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
            return arr;
        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            if (right - left == 0)
            {//only one element.
                //no Swap
            }
            else if (right - left == 1)
            {//only two elements and swaps them
                if (arr[left] > arr[right])
                    Swap(arr, left, right);
            }
            else
            {
                var middlePoint = (left + right) / 2;

                MergeSort(arr, left, middlePoint);//sort the left side
                MergeSort(arr, middlePoint + 1, right);//sort the right side
                Merge(arr, left, right, middlePoint);//combines them
            }
        }

        static void Merge(int[] arr, int left, int right, int mid)
        {
            var i = left;
            //sort left part
            while (i <= mid)
            {
                if (arr[i] > arr[mid + 1])
                {
                    Swap(arr, i, mid + 1);
                    SortRightPart(arr, mid + 1, right);
                }
                i++;
            }
        }

        static void Swap(int[] arr, int left, int right)
        {
            arr[left] = arr[left] ^ arr[right];
            arr[right] = arr[left] ^ arr[right];
            arr[left] = arr[left] ^ arr[right];
        }

        static void SortRightPart(int[] arr, int left, int right)
        {
            for (var i = left; i < right; i++)
            {
                if (arr[i] > arr[i + 1])
                    Swap(arr, i, i + 1);
            }
        }
    }
}
