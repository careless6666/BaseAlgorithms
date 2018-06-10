using System;

namespace BaseAlgorithms
{
    public class InsertionSort
    {
        public static T[] ReverseSort<T>(T[] arr) where T : struct,
            IComparable,
            IComparable<T>,
            IConvertible,
            IEquatable<T>,
            IFormattable
        {

            for (var i = 0; i < arr.Length - 1; i++)
            {
                var j = i + 1;
                while (j > 0)
                {
                    if (IsGreaterThan(arr[j], arr[j-1]))
                    {
                        var temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                    j--;
                }
            }

            return arr;
        }

        public static bool IsGreaterThan<T>(T actual, T comp) where T : IComparable<T>
            => actual.CompareTo(comp) > 0;

        public static T[] Sort<T>(T[] arr) where T : struct,
            IComparable,
            IComparable<T>,
            IConvertible,
            IEquatable<T>,
            IFormattable
        {

            for (var i = 0; i < arr.Length - 1; i++)
            {
                var j = i + 1;
                while (j > 0)
                {
                    if (IsGreaterThan(arr[j - 1], arr[j]))
                    {
                        var temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                    j--;
                }
            }

            return arr;
        }

    }
}
