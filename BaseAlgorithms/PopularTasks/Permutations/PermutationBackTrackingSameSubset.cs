using System.Collections.Generic;

namespace BaseAlgorithms.PopularTasks;

public class PermutationBackTracking
{
    public List<int[]> Permute(int[] nums)
    {
        var ans = new List<int[]>();
        Backtrack(new(), ans, nums);
        return ans;
    }

    private static void Backtrack(List<int> curr, ICollection<int[]> ans, int[] nums)
    {
        if (curr.Count == nums.Length)
        {
            ans.Add(curr.ToArray());
            return;
        }

        foreach (var num in nums)
        {
            if (curr.Contains(num))
                continue;

            curr.Add(num);
            Backtrack(curr, ans, nums);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}

//123
//132
//213
//231
//312
//321