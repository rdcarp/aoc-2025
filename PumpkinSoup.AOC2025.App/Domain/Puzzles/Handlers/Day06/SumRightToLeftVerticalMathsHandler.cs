using PumpkinSoup.AOC2025.App.Domain.Homework;
using PumpkinSoup.AOC2025.App.Domain.Homework.Entities;

namespace PumpkinSoup.AOC2025.App.Domain.Puzzles.Handlers.Day06;

public class SumRightToLeftVerticalMathsHandler : BaseHandler
{
    public override int Day => 6;
    public override int Part => 2;
    
    public override long SolveInternal(string puzzleInput)
    {
        var lines = puzzleInput.Split("\n").Select(x => x.Replace("\r", "")).ToArray();
        var operatorLine = lines[^1];
        var valueLines = lines[..^1];
        
        var columnIndex = lines[0].Length - 1;
        
        List<RightToLeftMathsProblem> problems = new();
        RightToLeftMathsProblem? problem = null;

        while (columnIndex >= 0)
        {
            if (problem is null)
                problem = new RightToLeftMathsProblem();

            var number = new Number();
            foreach (var line in valueLines)
            {
                if (line[columnIndex] == ' ')
                    continue;

                if(!int.TryParse(line[columnIndex].ToString(), out var digit))
                    throw new ArgumentException($"Invalid digit: {line[columnIndex]}");
        
                number.PushNextSignificantDigit(digit);
            }

            if(number.Value > 0)
                problem.AddNumber(number);

            if (operatorLine[columnIndex] != ' ')
            {
                problem.SetOperator(operatorLine[columnIndex]);
                problems.Add(problem);
                problem = null;
            }

            columnIndex--;
        }

        var calculator = new Calculator();
        
        
        return problems.Select(p => calculator.Calculate(p)).Sum();
    }
}