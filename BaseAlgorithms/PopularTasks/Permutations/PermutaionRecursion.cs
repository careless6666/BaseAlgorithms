using System.Collections.Generic;

namespace BaseAlgorithms.PopularTasks
{
    public class PermutaionRecursion
    {
        private List<string> ReqursiveGenerationResult;
        
        public List<string> GenerateRecursive(string str)
        {
            ReqursiveGenerationResult = new List<string>();

            var n = str.Length;
            Permute(str, 0, n - 1);
            return ReqursiveGenerationResult;
        }

        private void Permute(string str, int l, int r)
        {
            if (l == r)
                ReqursiveGenerationResult.Add(str);
            else
            {
                for (var i = l; i <= r; i++)
                {
                    str = Swap(str, l, i);
                    Permute(str, l + 1, r);
                    str = Swap(str, l, i);
                }
            }
        }

        private static string Swap(string a,
            int i, int j)
        {
            var charArray = a.ToCharArray();
            var temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            var s = new string(charArray);
            return s;
        }
    }
}