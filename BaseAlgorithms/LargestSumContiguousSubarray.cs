namespace BaseAlgorithms
{
    public class LargestSumContiguousSubarray
    {
        public static int MaxSubArraySum(int[] a)
        {
            var size = a.Length;
            int maxSoFar = int.MinValue,
                maxEndingHere = 0;

            for (var i = 0; i < size; i++)
            {
                maxEndingHere = maxEndingHere + a[i];

                if (maxSoFar < maxEndingHere)
                    maxSoFar = maxEndingHere;

                if (maxEndingHere < 0)
                    maxEndingHere = 0;
            }

            return maxSoFar;
        }
    }
}
