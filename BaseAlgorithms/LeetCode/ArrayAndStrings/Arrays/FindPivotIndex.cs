namespace BaseAlgorithms.LeetCode.ArrayAndStrings.Arrays
{
    public class FindPivotIndex
    {
        public int PivotIndex(int[] nums) {
            switch (nums.Length)
            {
                case 1:
                case 2 when nums[1]== 0:
                    return 0;
                case 2 when nums[0] == 0:
                    return 1;
            }

            var leftSum = 0;
            var rightSum = 0;
        
            for(var i = 1; i < nums.Length; i++){
                rightSum += nums[i];
            }
        
            if(leftSum == rightSum){
                return 0;
            }

            for(var i = 0; i < nums.Length - 1; i++){
                
                leftSum += nums[i];
                rightSum -= nums[i + 1];

                if(leftSum == rightSum){
                    return i + 1;
                }
            }
        
            return -1;
        }
    }
}