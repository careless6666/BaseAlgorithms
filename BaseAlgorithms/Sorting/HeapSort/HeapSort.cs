using System.Collections.Generic;

namespace BaseAlgorithms.HeapSort
{
    public class HeapSort
    {
        private int[] _array; //массив сортируемых элементов
        private int heapsize;//число необработанных элементов


        public HeapSort(int[] a)
        {
            _array = a;
            heapsize = a.Length;
        }

        private int Parent(int i) { return (i - 1) / 2; }//Индекс родительского узла
        private int Left(int i) { return 2 * i + 1; }//Индекс левого потомка
        private int Right(int i) { return 2 * i + 2; }//Индекс правого потомка


        public void Sort()
        {
            build_max_heap();//Построение пирамиды
            for (int i = _array.Length - 1; i > 0; i--)
            {

                int temp = _array[0];//Переместим текущий максимальный элемент из нулевой позиции в хвост массива
                _array[0] = _array[i];
                _array[i] = temp;

                heapsize--;//Уменьшим число необработанных элементов
                max_heapify(0);//Восстановление свойства пирамиды
            }
        }

        //Метод переупорядочивает элементы пирамиды при условии,
        //что элемент с индексом i меньше хотя бы одного из своих потомков, нарушая тем самым свойство невозрастающей пирамиды
        private void max_heapify(int i)
        {
            int l = Left(i);
            int r = Right(i);
            int lagest = i;
            if (l < heapsize && _array[l] > _array[i])
                lagest = l;
            if (r < heapsize && _array[r] > _array[lagest])
                lagest = r;
            if (lagest != i)
            {
                int temp = _array[i];
                _array[i] = _array[lagest];
                _array[lagest] = temp;

                max_heapify(lagest);
            }
        }

        //метод строит невозрастающую пирамиду
        private void build_max_heap()
        {
            int i = (_array.Length - 1) / 2;

            while (i >= 0)
            {
                max_heapify(i);
                i--;
            }
        }
    }
}
