namespace PumpkinSoup.AOC2025.App.Domain.Safes.Entities;

public class DialNumber(int number)
{
    private DialNumber? _previous;
    private DialNumber? _next;

    public int Number { get; } = number;
    public DialNumber Previous => _previous!;
    public DialNumber Next => _next!;

    public void SetPrevious(DialNumber previous)
    {
        _previous = previous;
    }

    public void SetNext(DialNumber next)
    {
        _next = next;
    }
}
