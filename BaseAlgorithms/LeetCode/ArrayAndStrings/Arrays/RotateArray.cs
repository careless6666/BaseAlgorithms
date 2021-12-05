using System;

namespace BaseAlgorithms.LeetCode.ArrayAndStrings.Arrays
{
    public class RotateArray
    {
        public static void Rotate(int[] nums, int k) {
            if (nums.Length < 2)
                return;

            while (k > nums.Length)
            {
                k -= nums.Length;
            }
        
            Array.Reverse(nums, 0, nums.Length);
            Array.Reverse(nums,0, k);
            Array.Reverse(nums,k, nums.Length - k);
        }

        public static void CyclicReplacementsRotate(int[] nums, int k)
        {
            k = k % nums.Length;
            int count = 0;
            for (int start = 0; count < nums.Length; start++) {
                int current = start;
                int prev = nums[start];
                do {
                    var next = (current + k) % nums.Length;
                    (nums[next], prev) = (prev, nums[next]);
                    current = next;
                    count++;
                } while (start != current);
            }
        }
    }
}