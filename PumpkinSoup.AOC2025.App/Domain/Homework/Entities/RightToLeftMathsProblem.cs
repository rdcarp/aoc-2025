using PumpkinSoup.AOC2025.App.Domain.Homework.Enum;

namespace PumpkinSoup.AOC2025.App.Domain.Homework.Entities;

public class RightToLeftMathsProblem
{
    public MathematicalOperator Operator { get; private set; }

    private List<Number> _numbers = new();

    public List<Number> Numbers => _numbers;
    
    public void AddNumber(Number number)
    {
        Numbers.Add(number);
    }

    public void SetOperator(char op) => SetOperator(op.ToString());
    
    public void SetOperator(string op) => Operator = op switch
    {
        "+" => MathematicalOperator.Add,
        "*" => MathematicalOperator.Multiply,
        _ => throw new ArgumentException($"Invalid operator: {op}")
    };
}
