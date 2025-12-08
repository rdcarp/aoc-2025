namespace PumpkinSoup.AOC2025.App.Domain.Homework.ValueObjects;

public record Digit
{
    public int Value { get; init; }
    
    public Digit(int value)
    {
        if(value is < 0 or > 9)
            throw new ArgumentException("Value must be between 0 and 9");
        
        Value = value;
    }
    
    public static implicit operator int(Digit digit) => digit.Value;
    public static implicit operator Digit(int value) => new(value);
}
