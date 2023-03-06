using Sudoku;

var grid = SudokuGenerator.Generate();

for (var i = 0; i < 9; i++)
{
    var output = string.Empty;
    for (var j = 0; j < 9; j++)
    {
        output += grid[i, j].ToString();
    }

    Console.WriteLine(output);
}