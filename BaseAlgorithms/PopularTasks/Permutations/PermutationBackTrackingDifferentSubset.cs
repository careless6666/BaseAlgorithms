using System.Collections.Generic;

namespace BaseAlgorithms.PopularTasks;

public class PermutationBackTrackingDifferentSubset
{
    public List<int[]> Subsets(int[] nums)
    {
        List<int[]> ans = new();
        Backtrack(new(), 0, ans, nums);
        return ans;
    }

    public void Backtrack(List<int> curr, int i, List<int[]> ans, int[] nums)
    {
        if (i > nums.Length)
        {
            return;
        }

        ans.Add(curr.ToArray());
        for (var j = i; j < nums.Length; j++)
        {
            curr.Add(nums[j]);
            Backtrack(curr, j + 1, ans, nums);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}