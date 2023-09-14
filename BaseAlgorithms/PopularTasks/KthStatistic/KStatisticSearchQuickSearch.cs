namespace BaseAlgorithms.PopularTasks;

public class KStatisticSearchQuickSearch
{
    public int OrderStatistics(int[] a, int n, int k)
    {
        var l = 0;
        var r = n-1;
        while (true)
        {
            if (r <= l + 1)
            {
                // the current part size is either 1 or 2, so it is easy to find the answer
                if (r == l + 1 && a[r] < a[l])
                    Swap(a, l, r);
                return a[k];
            }

            // ordering a[l], a[l+1], a[r]
            var mid = (l + r) >> 1;
            Swap(a, mid, l + 1);
            if (a[l] > a[r])
                Swap(a, l, r);
            if (a[l + 1] > a[r])
                Swap(a, l + 1, r);
            if (a[l] > a[l + 1])
                Swap(a, l, l + 1);

            // performing division
            // barrier is a[l + 1], i.e. median among a[l], a[l + 1], a[r]
            var i = l + 1;
            var j = r;
            var cur = a[l + 1];
            for (;;)
            {
                while (a[++i] < cur);
                while (a[--j] > cur);
                if (i > j)
                    break;
                Swap(a, i, j);
            }

            // inserting the barrier
            a[l + 1] = a[j];
            a[j] = cur;

            // we continue to work in that part, which must contain the required element
            if (j >= k)
                r = j - 1;
            if (j <= k)
                l = i;
        }
    }

    private static void Swap(int[] arr, int i, int j)
    {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }
}