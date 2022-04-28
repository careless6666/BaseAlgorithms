using System;
using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode.DP
{
    /// <summary>
    /// You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.
    // Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police.
    /// </summary>
    public class HouseRobber
    {
        public int Rob(int[] nums) {
            return Rob(0, nums);
        }

        private readonly Dictionary<int, int> _memo = new ();

        private int Rob(int i, int[] nums) {
            if(i >= nums.Length)
                return 0;
        
            if(_memo.ContainsKey(i))
                return _memo[i];
        
            var result = Math.Max(Rob(i+1, nums), Rob(i+2, nums) + nums[i]);
        
            _memo[i] = result;
        
            return result;
        
        } 
    }
}