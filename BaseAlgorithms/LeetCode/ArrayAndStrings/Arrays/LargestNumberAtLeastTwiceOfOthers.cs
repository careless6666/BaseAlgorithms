namespace BaseAlgorithms.LeetCode.ArrayAndStrings.Arrays
{
    public class LargestNumberAtLeastTwiceOfOthers
    {
        public int DominantIndex(int[] nums) {
            var max=int.MinValue;
            var index=-1;
            for(var i=0;i<nums.Length;i++)
            {
                if(nums[i]>max)
                {
                    max=nums[i];
                    index=i;
                }
            }

            for(var i=0;i<nums.Length;i++)
            {
                if(index!=i)
                {
                    if(2*nums[i]>max)
                        return -1;
                }
            }
            return index;
        }
    }
}