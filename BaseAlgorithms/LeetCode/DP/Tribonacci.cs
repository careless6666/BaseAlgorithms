using System.Collections.Generic;

namespace BaseAlgorithms.LeetCode.DP
{
    public class TribonacciTask
    {
        private int Tribonacci(int n) {
            Tribonacci(n, n);
            return _memo[n];
        }
    
        private Dictionary <int, int> _memo = new ();

        private int Tribonacci(int i, int n) 
        {
        
            if(i <= 0)
            {
                _memo[i] = 0;            
                return 0;
            }
        
            if(_memo.ContainsKey(i))
                return _memo[i];
        
            if(i == 1)
            {
                _memo[i] = 1;            
                return 1;
            }
        
            var result = Tribonacci(i - 3, n) + Tribonacci(i - 2, n) + Tribonacci(i - 1, n);

            _memo[i] = result;
        
    
            return result;
        }
    }
}