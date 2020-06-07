using System;
using System.Threading.Tasks;

namespace BaseAlgorithms.MergeSort
{
    public class ParallelMergeSort
    {
        private readonly int _maxParallelDepth;

        public ParallelMergeSort() => _maxParallelDepth = DetermineMaxParallelDepth();

        protected int DetermineMaxParallelDepth()
        {
            const int MaxTasksPerProcessor = 8;
            var maxTaskCount = Environment.ProcessorCount * MaxTasksPerProcessor;
            return (int) Math.Log(maxTaskCount, 2);
        }

        public void Sort(int[] list, bool ascending = true)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            if (list.Length < 2)
                return;

            var tempList = new int[list.Length];
            SortBlock(list, tempList, 0, list.Length - 1, 1);
        }

        void SortBlock(int[] list, int[] tempList, int beginBlock, int endBlock, int recursionDepth)
        {
            // Odd levels should store the result in the list, even levels in the
            // in tempList. This swapping avoids array copying from a temp list.
            var mergeToTempList = recursionDepth % 2 == 0;
            var workParallel = recursionDepth <= _maxParallelDepth;
            var blockSize = endBlock - beginBlock + 1;

            if (blockSize == 1) //array.length == 1
            {
                if (mergeToTempList)
                    Array.Copy(list, beginBlock, tempList, beginBlock, blockSize);
            }
            else
            {
                // Split sorting into halves
                var middle = beginBlock + ((endBlock - beginBlock) / 2); // avoid overflows
                if (workParallel)
                {
                    Parallel.Invoke(
                        () => SortBlock(list, tempList, beginBlock, middle, recursionDepth + 1),
                        () => SortBlock(list, tempList, middle + 1, endBlock, recursionDepth + 1));
                }
                else
                {
                    SortBlock(list, tempList, beginBlock, middle, recursionDepth + 1);
                    SortBlock(list, tempList, middle + 1, endBlock, recursionDepth + 1);
                }

                // Merge sorted halves
                if (mergeToTempList)
                    MergeTwoBlocks(list, tempList, beginBlock, middle, middle + 1, endBlock);
                else
                    MergeTwoBlocks(tempList, list, beginBlock, middle, middle + 1, endBlock);
            }
        }
        
        void MergeTwoBlocks(int[] sourceList, int[] targetList, int beginBlock1, int endBlock1, int beginBlock2, int endBlock2)
        {
            for (int targetIndex = beginBlock1; targetIndex <= endBlock2; targetIndex++)
            {
                if (beginBlock1 > endBlock1)
                {
                    // Nothing is left from block1, take next element from block2
                    targetList[targetIndex] = sourceList[beginBlock2++];
                }
                else if (beginBlock2 > endBlock2)
                {
                    // Nothing is left from block2, take next element from block1
                    targetList[targetIndex] = sourceList[beginBlock1++];
                }
                else
                {
                    // Compare the next elements from both blocks and take the smaller one
                    if (sourceList[beginBlock1] - sourceList[beginBlock2] <= 0)
                        targetList[targetIndex] = sourceList[beginBlock1++];
                    else
                        targetList[targetIndex] = sourceList[beginBlock2++];
                }
            }
        }
    }
}