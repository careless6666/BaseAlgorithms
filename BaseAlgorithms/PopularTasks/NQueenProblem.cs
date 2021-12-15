namespace BaseAlgorithms.PopularTasks
{
    //Backtracking approach
    // Constrain: only one queen in each column
    // { 0,  1,  0,  0}
    // { 0,  0,  0,  1}
    // { 1,  0,  0,  0}
    // { 0,  0,  1,  0}
    public class NQueenProblem
    {
        readonly int N = 4;

        /* A utility function to check if a queen can
        be placed on board[row,col]. Note that this
        function is called when "col" queens are already
        placeed in columns from 0 to col -1. So we need
        to check only left side for attacking queens */
        bool isSafe(int[,] board, int row, int col)
        {
            int i, j;

            /* Check this row on left side */
            for (i = 0; i < col; i++)
                if (board[row, i] == 1)
                    return false;

            /* Check upper diagonal on left side */
            for (i = row, j = col;
                i >= 0 &&
                j >= 0;
                i--, j--)
                if (board[i, j] == 1)
                    return false;

            /* Check lower diagonal on left side */
            for (i = row, j = col;
                j >= 0 &&
                i < N;
                i++, j--)
                if (board[i, j] == 1)
                    return false;

            return true;
        }

        public bool SolveNQUtil(int[,] board, int column)
        {
            /* base case: If all queens are placed then return true */
            if (column >= N)
                return true;

            /* Consider this column and try placing this queen in all rows one by one */
            for (var i = 0; i < N; i++)
            {
                /* Check if the queen can be placed on
                board[i,col] */
                if (isSafe(board, i, column))
                {
                    /* Place this queen in board[i,col] */
                    board[i, column] = 1;

                    /* recur to place rest of the queens */
                    if (SolveNQUtil(board, column + 1))
                        return true;

                    /* If placing queen in board[i,col]
                    doesn't lead to a solution then
                    remove queen from board[i,col] */
                    board[i, column] = 0; // BACKTRACK
                }
            }

            /* If the queen can not be placed in any row in this colum col, then return false */
            return false;
        }
    }
}