namespace Sudoku;

public static class SudokuGenerator
{
    public static int[,] Generate()
    {
        // Step 1: Create Grid
        var grid = new int[9, 9];
        
        // Step 2: Fill in numbers
        for (var row = 0; row < 9; row++)
        {
            for (var col = 0; col < 9; col++)
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
        var random = new Random();
        for (var block = 0; block < 3; block++)
        {
            for (var i = 0; i < 2; i++)
            {
                var row1 = random.Next(3) + block * 3;
                var row2 = random.Next(3) + block * 3;
                for (var col = 0; col < 9; col++)
                {
                    (grid[row1, col], grid[row2, col]) = (grid[row2, col], grid[row1, col]);
                }
            }
        }
    }

    private static void ShuffleColumns(int[,] grid)
    {
        var random = new Random();
        for (var block = 0; block < 3; block++)
        {
            for (var i = 0; i < 2; i++)
            {
                var col1 = random.Next(3) + block * 3;
                var col2 = random.Next(3) + block * 3;
                for (var row = 0; row < 9; row++)
                {
                    (grid[row, col1], grid[row, col2]) = (grid[row, col2], grid[row, col1]);
                }
            }
        }
    }
    
    private static void RemoveCells(int[,] grid)
    {
        var random = new Random();
        for (var i = 0; i < 40; i++)
        {
            var row = random.Next(9);
            var col = random.Next(9);
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