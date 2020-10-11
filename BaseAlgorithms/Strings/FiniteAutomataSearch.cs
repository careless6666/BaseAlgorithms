using System;

namespace BaseAlgorithms.Strings
{
    /// <summary>
    /// The time complexity of the search process is O(n).
    /// </summary>
    public class FiniteAutomataSearch
    {
        private static readonly int NoOfChars = 256;

        static int GetNextState(char[] pat, int patLength,
            int state, int x)
        {
            // If the character c is same as next  
            // character in pattern,then simply  
            // increment state  
            if (state < patLength && (char) x == pat[state])
            {
                return state + 1;
            }

            // ns stores the result  
            // which is next state  
            int ns, i;

            // ns finally contains the longest  
            // prefix which is also suffix in  
            // "pat[0..state-1]c"  

            // Start from the largest possible   
            // value and stop when you find a  
            // prefix which is also suffix  
            for (ns = state; ns > 0; ns--)
            {
                if (pat[ns - 1] == (char) x)
                {
                    for (i = 0; i < ns - 1; i++)
                    {
                        if (pat[i] != pat[state - ns + 1 + i])
                        {
                            break;
                        }
                    }

                    if (i == ns - 1)
                    {
                        return ns;
                    }
                }
            }

            return 0;
        }

        /* This function builds the TF table which  
        represents Finite Automata for a given pattern */
        static void ComputeTf(char[] pat,
            int patLength, int[][] TF)
        {
            int state, x;
            for (state = 0; state <= patLength; ++state)
            {
                for (x = 0; x < NoOfChars; ++x)
                {
                    TF[state][x] = GetNextState(pat, patLength,
                        state, x);
                }
            }
        }

/* Prints all occurrences of  
   pat in txt */
        public static int Search(char[] pat, char[] txt)
        {
            var patLength = pat.Length;
            var txtLength = txt.Length;

            var tf = RectangularArrays.ReturnRectangularIntArray(patLength + 1, NoOfChars);

            ComputeTf(pat, patLength, tf);

            // Process txt over FA.  
            int i, state = 0;
            for (i = 0; i < txtLength; i++)
            {
                state = tf[state][txt[i]];
                if (state == patLength)
                {
                    return (i - patLength + 1);
                }
            }

            return -1;
        }

        static class RectangularArrays
        {
            public static int[][] ReturnRectangularIntArray(int size1,
                int size2)
            {
                var newArray = new int[size1][];
                for (var array1 = 0; array1 < size1; array1++)
                {
                    newArray[array1] = new int[size2];
                }

                return newArray;
            }
        }
    }
}