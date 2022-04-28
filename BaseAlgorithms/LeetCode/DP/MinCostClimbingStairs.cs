using System;
using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode.DP
{
    public class MinCostClimbingStairsTask
    {
        public int MinCostClimbingStairs(int[] cost) {
            return MinCostClimbingStairs(cost.Length, cost);   
        }
    
        private readonly Dictionary<int, int> _memo = new ();

        private int MinCostClimbingStairs(int i, int[] cost) {
            if(i <= 1)
                return 0;        
        
            if(_memo.ContainsKey(i))
                return _memo[i];
        
 
            var downOne = cost[i-1] + MinCostClimbingStairs(i-1, cost);
            var downTwo = cost[i-2] + MinCostClimbingStairs(i-2, cost);
            var result =  Math.Min(downOne, downTwo);
        
            _memo[i] = result;
        
            return result;
        }
    }
}