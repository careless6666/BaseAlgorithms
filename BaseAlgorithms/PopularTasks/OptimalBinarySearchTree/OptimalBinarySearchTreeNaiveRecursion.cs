namespace BaseAlgorithms.PopularTasks.OptimalBinarySearchTree
{
    // A naive recursive implementation of optimal binary  
    // search tree problem 
    public class OptimalBinarySearchTreeNaiveRecursion
    {
        // A recursive function to calculate cost of 
        // optimal binary search tree 
        static int OptCost(int []freq, int i, int j) 
        { 
            // Base cases 
            // no elements in this subarray 
            if (j < i)      
                return 0; 
      
            // one element in this subarray     
            if (j == i)      
                return freq[i]; 
      
            // Get sum of freq[i], freq[i+1], ... freq[j] 
            var fsum = Sum(freq, i, j); 
      
            // Initialize minimum value 
            var min = int.MaxValue; 
      
            // One by one consider all elements as root and  
            // recursively find cost of the BST, compare the  
            // cost with min and update min if needed 
            for (var r = i; r <= j; ++r) 
            { 
                var cost = OptCost(freq, i, r-1) +  
                           OptCost(freq, r+1, j); 
                if (cost < min) 
                    min = cost; 
            } 
      
            // Return minimum value 
            return min + fsum; 
        } 
      
        // The main function that calculates minimum cost of 
        // a Binary Search Tree. It mainly uses optCost() to 
        // find the optimal cost. 
        public static int OptimalSearchTree(int []keys, int []freq, int n) 
        { 
            // Here array keys[] is assumed to be sorted in  
            // increasing order. If keys[] is not sorted, then 
            // add code to sort keys, and rearrange freq[]  
            // accordingly. 
            return OptCost(freq, 0, n-1); 
        } 
      
        // A utility function to get sum of array elements  
        // freq[i] to freq[j] 
        static int Sum(int []freq, int i, int j) 
        { 
            var s = 0; 
            for (var k = i; k <=j; k++) 
                s += freq[k]; 
            return s; 
        } 
    }
}