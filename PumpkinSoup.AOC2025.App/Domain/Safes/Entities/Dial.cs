using System.Diagnostics.CodeAnalysis;

namespace PumpkinSoup.AOC2025.App.Domain.Safes.Entities;

public enum DialDirection
{
    Left,
    Right
}

public class Dial
{
    public int ZeroTouches { get; private set; }
    public int ZeroStops { get; private set; }

    public required DialNumber PointingAt;

    private int CurrentNumber => PointingAt.Number;

    [SetsRequiredMembers]
    public Dial(int totalNumbers, int startsOn)
    {
        var notches = new DialNumber[totalNumbers];

        for (int i = 0; i < totalNumbers; i++)
            notches[i] = new DialNumber(i);

        for (int i = 0; i < totalNumbers; i++)
        {
            notches[i].SetNext(notches[(i + 1) % totalNumbers]);
            notches[(i + 1) % totalNumbers].SetPrevious(notches[i]);
        }

        PointingAt = notches[startsOn];
    }
    
    public void SpinIt(DialDirection direction, int count)
    {
        for (var index = 0; index < count; index++)
        {
            if(direction == DialDirection.Left)
                PointingAt = PointingAt.Previous;
            else
                PointingAt = PointingAt.Next;

            if(CurrentNumber == 0)
                ZeroTouches++;
        }

        if (CurrentNumber == 0)
            ZeroStops++;
    }
}
