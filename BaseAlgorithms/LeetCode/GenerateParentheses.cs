using System;
using System.Collections.Generic;
using System.Linq;

namespace BaseAlgorithms.LeetCode
{
    public class GenerateParentheses
    {
        List<string> _resultList = new List<string>();

        public IList<string> GenerateParenthesis(int n)
        {
            
            var tmpStr = string.Empty;
            var fact = Factorial(n);
            var stack = new Stack<char>(fact);
            Generator(fact, stack, tmpStr);

            return _resultList;
        }

        private int Factorial(int num)
        {
            var n = num;
            for (int i = n - 1; i > 0; i--)
                n *= i;

            return n;
        }


        private void Generator(int length, Stack<char> stack, string tmpStr)
        {
            if (length != 0)
            {
                if (IsValid(length,'(', stack))
                {
                    var newTmpStr = tmpStr + "(";
                    Generator(length - 1, stack, newTmpStr);
                }

                if (IsValid(length,')', stack))
                {
                    var newTmpStr = tmpStr + ")";
                    Generator(length - 1, stack, newTmpStr);
                }
            }
            else
            {
                if (stack.Count == 0)
                    _resultList.Add(tmpStr);
            }
        }

        private bool IsValid(int length, char s, Stack<char> stack)
        {
            if (s == '(')
            {
                stack.ToArray()[^length] = '(';
                return true;
            }

            if (s == ')')
            {
                if (stack.Count == 0)
                    return false;

                var item = stack.Pop();
                if (item == '(')
                    return true;

                return false;
            }

            return false;
        }
    }
}