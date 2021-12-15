namespace BaseAlgorithms.LeetCode.ArrayAndStrings.Arrays
{
    public class TwoSum2InputArrayIsSorted
    {
        public int[] TwoSum(int[] numbers, int target) {
            var low = 0;
            var high = numbers.Length - 1;
            while (low < high) {
                int sum = numbers[low] + numbers[high];
                          
                if (sum == target) {
                    return new int []{low + 1, high + 1};
                } else if (sum < target) {
                    ++low;
                } else {
                    --high;
                }
            }
            // In case there is no solution, return {-1, -1}.
            return new int [] {-1, -1};
        }
    }
}