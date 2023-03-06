
using Sudoku;

var grid = SudokuGenerator.Generate();

for (var i = 0; i < 9; i++)
{
    var output = String.Empty;
    for (int j = 0; j < 9; j++)
    {
        output += grid[i, j].ToString();
    }

    Console.WriteLine(output);
}