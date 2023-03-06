namespace Sudoku;

public static class SudokuGenerator
{
    public static int[,] Generate()
    {
        // Step 1: Create Grid
        var grid = new int[9, 9];
        
        // Step 2: Fill in numbers
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                grid[row, col] = (row * 3 + row / 3 + col) % 9 + 1;
            }
        }

        // Step 3: Shuffle rows and columns
        ShuffleRows(grid);
        ShuffleColumns(grid);

        // Step 4: Remove cells to create puzzle
        RemoveCells(grid);

        return grid;
    }
    
    private static void ShuffleRows(int[,] grid)
    {
        Random random = new Random();
        for (int block = 0; block < 3; block++)
        {
            for (int i = 0; i < 2; i++)
            {
                int row1 = random.Next(3) + block * 3;
                int row2 = random.Next(3) + block * 3;
                for (int col = 0; col < 9; col++)
                {
                    int temp = grid[row1, col];
                    grid[row1, col] = grid[row2, col];
                    grid[row2, col] = temp;
                }
            }
        }
    }

    private static void ShuffleColumns(int[,] grid)
    {
        Random random = new Random();
        for (int block = 0; block < 3; block++)
        {
            for (int i = 0; i < 2; i++)
            {
                int col1 = random.Next(3) + block * 3;
                int col2 = random.Next(3) + block * 3;
                for (int row = 0; row < 9; row++)
                {
                    int temp = grid[row, col1];
                    grid[row, col1] = grid[row, col2];
                    grid[row, col2] = temp;
                }
            }
        }
    }
    
    private static void RemoveCells(int[,] grid)
    {
        Random random = new Random();
        for (int i = 0; i < 40; i++)
        {
            int row = random.Next(9);
            int col = random.Next(9);
            if (grid[row, col] != 0)
            {
                grid[row, col] = 0;
            }
            else
            {
                i--;
            }
        }
    }

}