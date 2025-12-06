using PumpkinSoup.AOC2025.App.Domain.Homework;
using PumpkinSoup.AOC2025.App.Domain.Homework.Entities;

namespace PumpkinSoup.AOC2025.App.Domain.Puzzles.Handlers.Day06;

public class SumVerticalMathsHandler : BaseHandler
{
    public override int Day => 6;
    public override int Part => 1;
    
    public override long SolveInternal(string puzzleInput)
    {
        puzzleInput = CleanPuzzleInput(puzzleInput);
        
        var lines = puzzleInput.Split('\n').Select(line => line.Trim()).ToArray();

        var operatorsRow = lines.Last();
        var operators = operatorsRow.Trim().Split(" ");
        
        var problems = new MathsProblem[operators.Length];
        
        for (int i = 0; i < problems.Length; i++)
        {
            problems[i] = new MathsProblem();
            problems[i].SetOperator(operators[i]);
        }

        var valueLines = lines[..^1];
        foreach (var valueLine in valueLines)
        {
            var values = valueLine.Split(' ');
            for (int i = 0; i < values.Length; i++)
            {
                problems[i].AddValue(long.Parse(values[i]));
            }
        }

        var calculator = new Calculator();
        return problems.Sum(p => calculator.Calculate(p));
    }
    
    private static string CleanPuzzleInput(string puzzleInput)
    {
        var after = int.MinValue;
        var before = puzzleInput.Length;

        while (before != after)
        {
            before = after;
            puzzleInput = puzzleInput.Replace("  ", " ");
            after = puzzleInput.Length;
        }

        return puzzleInput;
    }
}
