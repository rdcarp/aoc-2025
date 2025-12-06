using PumpkinSoup.AOC2025.App.Domain.Homework.Enum;

namespace PumpkinSoup.AOC2025.App.Domain.Homework.Entities;

public record MathsProblem
{
    private readonly List<long> _values = new();
    private MathematicalOperator _operator = MathematicalOperator.Undefined;
    
    public List<long> Values => _values;
    public MathematicalOperator Operator => _operator;

    public void AddValue(long value) => _values.Add(value);
    public void SetOperator(MathematicalOperator op) => _operator = op;
    public void SetOperator(string op) => _operator = op switch
    {
        "+" => MathematicalOperator.Add,
        "*" => MathematicalOperator.Multiply,
        _ => throw new ArgumentException($"Invalid operator: {op}")
    };
}
