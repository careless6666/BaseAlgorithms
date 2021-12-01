using System;

namespace BaseAlgorithms.LeetCode.ArrayAndStrings.Strings
{
    public class LongestCommonPrefixTask
    {
        public string LongestCommonPrefix(string[] strs) {
            if (strs.Length == 0) return "";
            var prefix = strs[0];
            for (var i = 1; i < strs.Length; i++)
                while (strs[i].IndexOf(prefix, StringComparison.Ordinal) != 0) {
                    prefix = prefix[..^1];
                    if (prefix.Length == 0) return "";
                }        
            return prefix;
        }
    }
}