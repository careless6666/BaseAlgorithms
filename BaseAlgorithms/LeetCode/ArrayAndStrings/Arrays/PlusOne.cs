using System.Linq;

namespace BaseAlgorithms.LeetCode.ArrayAndStrings.Arrays
{
    public class PlusOneTask
    {
        public int[] PlusOne(int[] digits) {
            var overflow = 1;
            for (var i = digits.Length - 1; i >= 0; i--)
            {
        
                if (digits[i] + overflow < 10)
                {
                    digits[i] += overflow;
                    overflow = 0;
                }
                else
                {
                    var diff = digits[i] + overflow - 10;
                    overflow = (digits[i] + overflow) / 10;
                    digits[i] = diff;
                }
            }
    
            if (overflow > 0)
            {
                var digitList = digits.ToList();
                digitList.Insert(0, overflow);
                return digitList.ToArray();
            }

            return digits;
        }
    }
}