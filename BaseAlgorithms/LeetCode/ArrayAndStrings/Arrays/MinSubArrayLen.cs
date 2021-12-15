using System;

namespace BaseAlgorithms.LeetCode.ArrayAndStrings.Arrays
{
    public class MinSubArrayLenTask
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            var ans = int.MaxValue;
            var left = 0;
            var sum = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                while (sum >= target)
                {
                    ans = Math.Min(ans, i + 1 - left);
                    sum -= nums[left++];
                }
            }

            return (ans != int.MaxValue) ? ans : 0;
        }
    }
}