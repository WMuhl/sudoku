using Sudoku;

var generator = new SudokuGenerator();
var grid = generator.Generate();

for (var i = 0; i < 9; i++)
{
    var output = string.Empty;
    for (var j = 0; j < 9; j++)
    {
        output += grid[i, j].ToString();
    }

    Console.WriteLine(output);
}

var solver = new SudokuSolver(grid);
var numberOfSolutions = solver.Solve();
Console.WriteLine($"{numberOfSolutions} solutions found:");