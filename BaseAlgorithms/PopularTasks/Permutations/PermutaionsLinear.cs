using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseAlgorithms.PopularTasks
{
    public class PermutaionsLinear
    {
        private List<string> ReqursiveGenerationResult;

        public List<List<int>> Generate(int n)
        {
            var arr = new int[n];
            for (var i = 0; i < n; i++)
                arr[i] = i + 1;

            var res = new List<List<int>> {arr.ToList()};

            while (NextSet(arr, n))
            {
                res.Add(arr.ToList());
            }

            return res;
        }

        bool NextSet(int[] a, int n)
        {
            var j = n - 2;
            while (j != -1 && a[j] >= a[j + 1]) j--;
            if (j == -1)
                return false; // больше перестановок нет
            var k = n - 1;
            while (a[j] >= a[k]) k--;
            Swap(a, j, k);
            int l = j + 1, r = n - 1; // сортируем оставшуюся часть последовательности
            while (l < r)
                Swap(a, l++, r--);
            return true;
        }

        void Swap(int[] a, int i, int j)
        {
            var s = a[i];
            a[i] = a[j];
            a[j] = s;
        }
    }

    
}
