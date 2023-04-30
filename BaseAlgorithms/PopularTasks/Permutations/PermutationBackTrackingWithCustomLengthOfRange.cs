using System.Collections.Generic;

namespace BaseAlgorithms.PopularTasks;

public class PermutationBackTrackingWithCustomLengthOfRange
{
    public List<int[]> Combine(int n, int k)
    {
        List<int[]> ans = new();
        Backtrack(new(), 1, ans, n, k);
        return ans;
    }

    public void Backtrack(List<int> curr, int i, List<int[]> ans, int n, int k)
    {
        if (curr.Count == k)
        {
            ans.Add(curr.ToArray());
            return;
        }

        for (var num = i; num <= n; num++)
        {
            curr.Add(num);
            Backtrack(curr, num + 1, ans, n, k);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}