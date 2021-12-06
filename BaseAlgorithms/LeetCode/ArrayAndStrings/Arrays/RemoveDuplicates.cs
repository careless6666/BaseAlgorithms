namespace BaseAlgorithms.LeetCode.ArrayAndStrings.Arrays
{
    public class RemoveDuplicatesTask
    {
        public int RemoveDuplicates(int[] nums) {
            var k = 0;
            var lastSymbol = int.MinValue;
            for(var i = 0; i < nums.Length; i++){
                if(nums[i] != lastSymbol){
                    lastSymbol = nums[i];
                    nums[k++] = nums[i];
                }
            }
        
            return k;
        }
    }
}