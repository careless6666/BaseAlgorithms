using System;

namespace BaseAlgorithms.Strings
{
    /// <summary>
    /// Rabin-Karp Algorithm. The average and best-case running time of the Rabin-Karp algorithm is O(n+m), but its worst-case time is O(nm).
    /// </summary>
    public class RKSearch
    {
        // d is the number of characters in the input alphabet 
        private static readonly int d = 256; 
        
        public static int Search(string pat, string txt, int q) 
        { 
            var patLength = pat.Length; 
            var txtLength = txt.Length; 
            int i, j; 
            var p = 0; // hash value for pattern 
            var t = 0; // hash value for txt 
            var h = 1; 
     
            // The value of h would be "pow(d, M-1)%q" 
            for (i = 0; i < patLength-1; i++) 
                h = (h*d)%q; 
     
            // Calculate the hash value of pattern and first 
            // window of text 
            for (i = 0; i < patLength; i++) 
            { 
                p = (d*p + pat[i])%q; 
                t = (d*t + txt[i])%q; 
            } 
     
            // Slide the pattern over text one by one 
            for (i = 0; i <= txtLength - patLength; i++) 
            { 
     
                // Check the hash values of current window of text 
                // and pattern. If the hash values match then only 
                // check for characters on by one 
                if ( p == t ) 
                { 
                    /* Check for characters one by one */
                    for (j = 0; j < patLength; j++) 
                    { 
                        if (txt[i+j] != pat[j]) 
                            break; 
                    } 
     
                    // if p == t and pat[0...M-1] = txt[i, i+1, ...i+M-1] 
                    if (j == patLength) 
                        return i; 
                } 
     
                // Calculate hash value for next window of text: Remove 
                // leading digit, add trailing digit 
                if ( i < txtLength-patLength ) 
                { 
                    t = (d*(t - txt[i]*h) + txt[i+patLength])%q; 
     
                    // We might get negative value of t, converting it 
                    // to positive 
                    if (t < 0) 
                        t = (t + q); 
                } 
            }

            return -1;
        } 
    }
}