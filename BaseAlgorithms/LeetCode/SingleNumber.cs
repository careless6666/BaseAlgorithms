using System;
using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode
{
    public class SingleNumberSearch
    {
        private Dictionary<int, int> dict = new Dictionary<int, int>();
        public int SingleNumber(int[] nums) {
            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num] += 1;
                }
                else
                {
                    dict[num] = 1;
                }
            }

            foreach (var i in dict)
            {
                if (i.Value == 1)
                {
                    return i.Key;
                }
            }

            throw new Exception();
        }
    }
}