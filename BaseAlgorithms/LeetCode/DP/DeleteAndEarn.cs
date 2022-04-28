using System;
using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode.DP
{
    /// <summary>
    /// You are given an integer array nums. You want to maximize the number of points you get by performing the following operation any number of times: 
    /// Pick any nums[i] and delete it to earn nums[i] points. Afterwards, you must delete every element equal to nums[i] - 1 and every element equal to nums[i] + 1.
    ///    Return the maximum number of points you can earn by applying the above operation some number of times.
    /// </summary>
    public class DeleteAndEarnTask
    {
        public int DeleteAndEarn(int[] nums) {
        
            var maxNumber = 0;
        
            for(var i = 0; i < nums.Length; i++){
                _points[nums[i]] = _points.GetValueOrDefault(nums[i], 0) + nums[i];            
                maxNumber = Math.Max(maxNumber, nums[i]);
            }
        
            return MaxPoints(maxNumber);
        }
    
        private readonly Dictionary<int, int> _memo = new ();
        private readonly Dictionary<int, int> _points = new ();
    
        private int MaxPoints(int num) {
        
            if(num == 0) 
                return 0;
        
            if(num == 1)
                return _points.GetValueOrDefault(1, 0);
        
            if(_memo.ContainsKey(num))
                return _memo[num];
        
            var gain = _points.GetValueOrDefault(num, 0);
            var result = Math.Max(MaxPoints(num - 1), MaxPoints(num - 2) + gain);
        
            _memo[num] = result;
        
            return result;
        } 
    }
}