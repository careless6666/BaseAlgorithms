using System.Collections.Generic;
using System.Text;

namespace BaseAlgorithms.LeetCode.ArrayAndStrings.Strings
{
    public class AddBinaryTask
    {
        string? AddBinary(string a, string b)
        {
            if (b.Length > a.Length)
                a = a.PadLeft(b.Length, '0');
            
            if (a.Length > b.Length)
                b = b.PadLeft(a.Length, '0');
            
            var resultStr = new StringBuilder();
            var overflow = 0;
            for (var i = a.Length - 1; i >= 0; i--)
            {
                var intA = a[i] - '0';
                var intB = b[i] - '0';

                var sum = intA + intB + overflow;

                resultStr.Insert(0, sum % 2 != 0 ? '1' : '0');

                overflow = sum > 1 ? 1 : 0;
            }

            if (overflow > 0)
            {
                resultStr.Insert(0, '1');
            }

            return new string(resultStr.ToString());
        }
    }
}