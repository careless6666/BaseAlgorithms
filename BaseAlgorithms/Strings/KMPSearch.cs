using System;

namespace BaseAlgorithms.Strings
{
    public class KMPSearch
    {
        public int Search(string pat, string txt)
        {
            var patLength = pat.Length;
            var txtLength = txt.Length;

            // create lps[] that will hold the longest 
            // prefix suffix values for pattern 
            var lps = new int[patLength];
            var j = 0; // index for pat[] 

            // Preprocess the pattern (calculate lps[] 
            // array) 
            ComputeLpsArray(pat, patLength, lps);

            int i = 0; // index for txt[] 
            while (i < txtLength)
            {
                if (pat[j] == txt[i])
                {
                    j++;
                    i++;
                }

                if (j == patLength)
                {
                    //j = lps[j - 1];
                    return i - j;
                }

                // mismatch after j matches 
                if (i < txtLength && pat[j] != txt[i])
                {
                    // Do not match lps[0..lps[j-1]] characters, 
                    // they will match anyway 
                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i++;
                }
            }

            return -1;
        }

        private static void ComputeLpsArray(string pat, int patLength, int[] lps)
        {
            // length of the previous longest prefix suffix 
            var len = 0; 
            var i = 1; 
            lps[0] = 0; // lps[0] is always 0 
  
            // the loop calculates lps[i] for i = 1 to M-1 
            while (i < patLength) { 
                if (pat[i] == pat[len]) { 
                    len++; 
                    lps[i] = len; 
                    i++; 
                } 
                else // (pat[i] != pat[len]) 
                {
                    if (len != 0) { 
                        len = lps[len - 1]; 
  
                        // Also, note that we do not increment 
                        // i here 
                    } 
                    else // if (len == 0) 
                    { 
                        lps[i] = len; 
                        i++; 
                    } 
                } 
            } 
        }
    }
}