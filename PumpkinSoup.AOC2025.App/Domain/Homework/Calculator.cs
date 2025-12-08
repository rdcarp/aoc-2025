using PumpkinSoup.AOC2025.App.Domain.Homework.Entities;
using PumpkinSoup.AOC2025.App.Domain.Homework.Enum;

namespace PumpkinSoup.AOC2025.App.Domain.Homework;

public class Calculator
{
    public long Calculate(MathsProblem problem)
    {
        switch (problem.Operator)
        {
            case MathematicalOperator.Add:
                return problem.Values.Sum();
            case MathematicalOperator.Multiply:
                return problem.Values.Aggregate(1L, (a, b) => a * b);
            default:
                throw new ArgumentException($"Invalid operator: {problem.Operator}");
        }
    }

    public long Calculate(RightToLeftMathsProblem problem)
    {
        
        switch (problem.Operator)
        {
            case MathematicalOperator.Add:
                return problem.Numbers.Select(n => n.Value).Sum();
            case MathematicalOperator.Multiply:
                return problem.Numbers.Select(n => n.Value).Aggregate(1L, (a, b) => a * b);
            default:
                throw new ArgumentException($"Invalid operator: {problem.Operator}");
        }
    }
}
