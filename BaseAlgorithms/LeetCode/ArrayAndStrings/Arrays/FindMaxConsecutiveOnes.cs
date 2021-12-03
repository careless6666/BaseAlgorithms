using System;

namespace BaseAlgorithms.LeetCode.ArrayAndStrings.Arrays
{
    public class FindMaxConsecutiveOnesTask
    {
        public int FindMaxConsecutiveOnes(int[] nums) {
            var currentCounter = 0;
            var maxCounter = 0;
        
            for(var i = 0; i < nums.Length; i++){
                if(nums[i] == 1){
                    currentCounter++;
                }
            
                if(nums[i] == 0){
                    maxCounter = Math.Max(maxCounter, currentCounter);
                    currentCounter = 0;
                }
            }
            
            maxCounter = Math.Max(maxCounter, currentCounter);
        
            return maxCounter;
        }
    }
}