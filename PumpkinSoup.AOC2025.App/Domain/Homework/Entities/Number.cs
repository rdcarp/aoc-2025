using PumpkinSoup.AOC2025.App.Domain.Homework.ValueObjects;

namespace PumpkinSoup.AOC2025.App.Domain.Homework.Entities;

public record Number
{
    private readonly List<Digit> _digits = new();
    
    public void PushNextSignificantDigit(Digit digit)
    {
        _digits.Add(digit);
    }
    
    public long Value => _digits
        .Select((d, i) => new {d.Value, index = i})
        .Aggregate(0L, (acc, x) => acc + x.Value * (long)Math.Pow(10, (_digits.Count() - 1) - x.index));
}