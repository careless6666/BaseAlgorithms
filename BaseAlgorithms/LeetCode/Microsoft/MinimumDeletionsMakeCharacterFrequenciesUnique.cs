using System.Collections.Generic;
using System.Linq;

namespace BaseAlgorithms.LeetCode.Microsoft
{
    /// <summary>
    /// Minimum Deletions to Make Character Frequencies Unique
    ///
    /// A string s is called good if there are no two different characters in s that have the same frequency.
    ///
    /// Given a string s, return the minimum number of characters you need to delete to make s good.
    ///The frequency of a character in a string is the number of times it appears in the string. For example, in the string "aab", the frequency of 'a' is 2, while the frequency of 'b' is 1.
    /// </summary>
    public class MinimumDeletionsMakeCharacterFrequenciesUnique
    {
        public int MinDeletions(string s)
        {
            var dict = new Dictionary<char, int>();
            foreach (var item in s)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item] += 1;    
                }
                else
                {
                    dict[item] = 1;    
                }
            }

            var counter = 0;

            dict = dict.OrderBy(x => x.Value)
                .ToDictionary(x => x.Key, x=>x.Value);

            var keysCount = dict.Keys.Count;
            
            for (var i = 0; i < keysCount; i++)
            {
                var key = dict.Keys.ElementAt(i);
                while(HasDuplicate(dict, key))
                {
                    dict[key] -= 1;
                    counter++;
                }
            }

            return counter;
        }
        
        private bool HasDuplicate(Dictionary<char, int> dict, char key)
        {
            foreach (var i in dict)
            {
                if (i.Key == key)
                    continue;

                if (i.Value == dict[key] && i.Value > 0)
                    return true;
            }

            return false;
        }
    }
}