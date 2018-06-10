namespace BaseAlgorithms
{
    /// <summary>
    /// Поиск к-ой порядковой статистики
    /// </summary>
    public class OrderStatistics
    {
        public static int GetStatistics(int[] arr, int k)
        {
            var n = arr.Length - 1;
            for (int l = 1, r = n;;)
            {

                if (r <= l + 1)
                {
                    // текущая часть состоит из 1 или 2 элементов -
                    //	 легко можем найти ответ
                    if (r == l + 1 && arr[r] < arr[l])
                        Common.Swap(ref arr[l], ref arr[r]);
                    return arr[k];
                }

                // упорядочиваем a[l], a[l+1], a[r]
                var mid = (l + r) >> 1;
                Common.Swap(ref arr[mid], ref arr[l + 1]);
                if (arr[l] > arr[r])
                    Common.Swap(ref arr[l], ref arr[r]);
                if (arr[l + 1] > arr[r])
                    Common.Swap(ref arr[l + 1], ref arr[r]);
                if (arr[l] > arr[l + 1])
                    Common.Swap(ref arr[l], ref arr[l + 1]);

                // выполняем разделение
                // барьером является a[l+1], т.е. медиана среди a[l], a[l+1], a[r]
                var i = l + 1;
                var j = r;
                var cur = arr[l + 1];

                for (;;)
                {
                    while (arr[++i] < cur) ;
                    while (arr[--j] > cur) ;
                    if (i > j)
                        break;
                    Common.Swap(ref arr[i], ref arr[j]);
                }

                // вставляем барьер
                arr[l + 1] = arr[j];
                arr[j] = cur;

                // продолжаем работать в той части,
                //	 которая должна содержать искомый элемент
                if (j >= k)
                    r = j - 1;
                if (j <= k)
                    l = i;

            }
        }
    }
}
