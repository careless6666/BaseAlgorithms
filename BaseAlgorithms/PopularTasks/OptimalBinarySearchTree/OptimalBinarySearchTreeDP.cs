namespace BaseAlgorithms.PopularTasks.OptimalBinarySearchTree
{
    //https://www.geeksforgeeks.org/optimal-binary-search-tree-dp-24/
    
    
    public class OptimalBinarySearchTreeDP
    {
        /* A Dynamic Programming based function that calculates 
    minimum cost of a Binary Search Tree. */
        public static int OptimalSearchTree(int []keys, int []freq, int n) { 
  
            /* Create an auxiliary 2D matrix to store results of  
            subproblems */
            var cost = new int[n + 1,n + 1]; 
  
            /* cost[i][j] = Optimal cost of binary search tree that  
            can be formed from keys[i] to keys[j]. cost[0][n-1]  
            will store the resultant cost */
  
            // For a single key, cost is equal to frequency of the key 
            for (var i = 0; i < n; i++) 
                cost[i,i] = freq[i]; 
  
            // Now we need to consider chains of length 2, 3, ... . 
            // L is chain length. 
            for (var L = 2; L <= n; L++) { 
  
                // i is row number in cost[][] 
                for (var i = 0; i <= n - L + 1; i++) { 
  
                    // Get column number j from row number i and  
                    // chain length L 
                    var j = i + L - 1; 
                    cost[i,j] = int.MaxValue; 
  
                    // Try making all keys in interval keys[i..j] as root 
                    for (var r = i; r <= j; r++) { 
  
                        // c = cost when keys[r] becomes root of this subtree 
                        var c = ((r > i) ? cost[i,r - 1] : 0) 
                                + ((r < j) ? cost[r + 1,j] : 0) + Sum(freq, i, j); 
                        if (c < cost[i,j]) 
                            cost[i,j] = c; 
                    } 
                } 
            } 
            return cost[0,n - 1]; 
        } 
  
        // A utility function to get sum of array elements  
        // freq[i] to freq[j] 
        static int Sum(int []freq, int i, int j) { 
            var s = 0; 
            for (var k = i; k <= j; k++) { 
                if (k >= freq.Length) 
                    continue; 
                s += freq[k]; 
            } 
            return s; 
        } 
    }
}