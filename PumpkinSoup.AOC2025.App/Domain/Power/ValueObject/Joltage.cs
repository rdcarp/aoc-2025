namespace PumpkinSoup.AOC2025.App.Domain.Power.ValueObject;

public record Joltage
{
    public long Value { get; }

    public Joltage(long value)
    {
        Value = value;
    }
}
