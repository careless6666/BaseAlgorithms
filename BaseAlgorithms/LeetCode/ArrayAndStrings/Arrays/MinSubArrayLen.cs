using System;

namespace BaseAlgorithms.LeetCode.ArrayAndStrings.Arrays
{
    public class MinSubArrayLenTask
    {
        public int MinSubArrayLen(int target, int[] nums) {
            var left = 0;
            var minCount = int.MaxValue;

            var right = left;
            var sum = 0;

            while (left < nums.Length)
            {
                var counter = 0;
                if (left > 0)
                    sum -= nums[left - 1];

                if (sum >= target)
                {
                    minCount = Math.Min(minCount, right - left);
                    left++;
                    continue;
                }

                var j = right;
                for (var i = j; i < nums.Length; i++, j++)
                {
                    sum += nums[i];
                    counter++;
                    if (sum >= target)
                    {
                        right = right + counter;
                        minCount = Math.Min(minCount, right - left);

                        break;
                    }
                }

                if (j == nums.Length)
                {
                    right = nums.Length;
                }

                left++;
            }


            return minCount == int.MaxValue ? 0 : minCount;
        }
    }
}