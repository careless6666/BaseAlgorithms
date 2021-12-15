namespace BaseAlgorithms
{
    public class LargestSumContiguousSubarray
    {
        /// <summary>
        /// Kadane’s Algorithm
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int MaxSubArraySum(int[] arr)
        {
            int maxSoFar = int.MinValue,
                maxEndingHere = 0;

            foreach (var item in arr)
            {
                maxEndingHere += item;

                if (maxSoFar < maxEndingHere)
                    maxSoFar = maxEndingHere;

                if (maxEndingHere < 0)
                    maxEndingHere = 0;
            }

            return maxSoFar;
        }
    }
}
