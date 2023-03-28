namespace Sudoku;

public class SudokuGenerator
{
    private readonly int[,] _grid;

    public SudokuGenerator()
    {
        _grid = new int[9, 9];
    }

    public int[,] Generate()
    {
        // Step 1: Fill in numbers
        for (var row = 0; row < 9; row++)
        {
            for (var col = 0; col < 9; col++)
            {
                _grid[row, col] = (row * 3 + row / 3 + col) % 9 + 1;
            }
        }

        // Step 3: Shuffle rows and columns
        ShuffleRows();
        ShuffleColumns();

        // Step 4: Remove cells to create puzzle
        RemoveCells(40);

        return _grid;
    }
    
    private void ShuffleRows()
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
                    (_grid[row1, col], _grid[row2, col]) = (_grid[row2, col], _grid[row1, col]);
                }
            }
        }
    }

    private void ShuffleColumns()
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
                    (_grid[row, col1], _grid[row, col2]) = (_grid[row, col2], _grid[row, col1]);
                }
            }
        }
    }
    
    private void RemoveCells(int difficulty)
    {
        var random = new Random();
        for (var i = 0; i < difficulty; i++)
        {
            var row = random.Next(9);
            var col = random.Next(9);
            var currentValue = _grid[row, col]; 
            if (_grid[row, col] != 0)
            {
                _grid[row, col] = 0;
                var solver = new SudokuSolver(CopyGrid(_grid));
                if (solver.Solve() == 1)
                {
                    Console.WriteLine($"{col},{row} is now {_grid[row,col]}");
                    continue;
                }
                // Too many solutions try again
                _grid[row, col] = currentValue;
                i--;
            }
            else
            {
                i--;
            }
        }
    }

    private static int[,] CopyGrid(int[,] grid)
    {
        var newGrid = new int[9,9];
        for (var x = 0; x < 9; x++)
        {
            for (var y = 0; y < 9; y++)
            {
                newGrid[x, y] = grid[x, y];
            }
        }

        return newGrid;
    }
}