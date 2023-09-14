using System.Collections.Generic;

namespace BaseAlgorithms.PopularTasks.KthStatistic;

/*
 * time complexity n*log(k) => n
 */
public class KthStatisticPriorityQueue
{
    public int FindKthLargest(int[] nums, int k) {
        var minHeap = new PriorityQueue<int, int>();

        foreach (var num in nums) {
            minHeap.Enqueue(num, num);
            while (minHeap.Count > k)
                minHeap.Dequeue();
        }

        return minHeap.Peek();
    }
}