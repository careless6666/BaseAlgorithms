using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode.DP
{
    /// <summary>
    /// You are climbing a staircase. It takes n steps to reach the top. Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
    /// </summary>
    public class ClimbingStairs
    {
        public int ClimbStairs(int n) {
            return ClimbStairs(0, n);
        }

        readonly Dictionary<int, int> _memo = new ();

        private int ClimbStairs(int i, int n){
            if(i > n)
                return 0;
        
            if(i == n)
                return 1;
        
            if(_memo.ContainsKey(i))
                return _memo[i];
        
            var result = ClimbStairs(i + 1, n) + ClimbStairs(i + 2, n);
        
            _memo[i] = result;
        
            return result;
        }
    }
}