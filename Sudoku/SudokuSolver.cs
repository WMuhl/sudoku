namespace Sudoku;

public class SudokuSolver
{
    private readonly int[,] _grid;

    public SudokuSolver(int[,] grid)
    {
        _grid = grid;
    }

    public int Solve()
    {
        var numSolutions = 0;
        Solve(0, 0, ref numSolutions);
        return numSolutions;
    }

    private bool Solve(int row, int col, ref int numSolutions)
    {
        // If we've reached the end of the grid, we've found a solution
        if (row == 9)
        {
            numSolutions++;
            return true;
        }

        // If the current cell is already filled in, move on to the next cell
        if (_grid[row, col] != 0)
        {
            return TrySolveNextCell(row, col, ref numSolutions);
        }

        // Try filling in the current cell with each possible value
        for (var val = 1; val <= 9; val++)
        {
            if (IsSafe(row, col, val))
            {
                _grid[row, col] = val;

                // Recursively solve the rest of the puzzle
                if (TrySolveNextCell(row, col, ref numSolutions) && numSolutions > 1)
                {
                    return true;
                }

                // If we haven't found a solution, backtrack and try a different value
                _grid[row, col] = 0;
            }
        }

        // If we've tried every possible value for the current cell and none of them work, backtrack
        return false;
    }

    private bool TrySolveNextCell(int row, int col, ref int numSolutions)
    {
        if (col == 8)
        {
            return Solve(row + 1, 0, ref numSolutions); // Move to the first cell of the next row
        }

        return Solve(row, col + 1, ref numSolutions); // Move to the next cell in the current row
    }

    private bool IsSafe(int row, int col, int val)
    {
        // Check if the value is already in the same row or column
        for (var i = 0; i < 9; i++)
        {
            if (_grid[row, i] == val || _grid[i, col] == val)
            {
                return false;
            }
        }

        // Check if the value is already in the same 3x3 subgrid
        var subgridRow = (row / 3) * 3;
        var subgridCol = (col / 3) * 3;
        for (var i = subgridRow; i < subgridRow + 3; i++)
        {
            for (var j = subgridCol; j < subgridCol + 3; j++)
            {
                if (_grid[i, j] == val)
                {
                    return false;
                }
            }
        }

        return true;
    }
}