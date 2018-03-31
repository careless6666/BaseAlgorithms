namespace BaseAlgorithms
{
    public class LargestSumContiguousSubarray
    {
        public static int MaxSubArraySum(int[] a)
        {
            int maxSoFar = int.MinValue,
                maxEndingHere = 0;

            foreach (var t in a)
            {
                maxEndingHere = maxEndingHere + t;

                if (maxSoFar < maxEndingHere)
                    maxSoFar = maxEndingHere;

                if (maxEndingHere < 0)
                    maxEndingHere = 0;
            }

            return maxSoFar;
        }
    }
}
