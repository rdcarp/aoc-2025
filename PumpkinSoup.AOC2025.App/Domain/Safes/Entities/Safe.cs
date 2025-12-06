namespace PumpkinSoup.AOC2025.App.Domain.Safes.Entities;

public class Safe(Dial dial)
{
    public Dial Dial { get; init; } = dial;

    public void ApplyInstructions((DialDirection, int)[] instructions)
    {
        foreach (var (direction, count) in instructions)
            dial.SpinIt(direction, count);
    }

    public int ApplyDecoyInstructions((DialDirection, int)[] instructions)
    {
        ApplyInstructions(instructions);
        
        return dial.ZeroStops;
    }

    public int ApplyDecoyInstructionsMethod0x434C49434B((DialDirection, int)[] instructions)
    {
        ApplyInstructions(instructions);

        return dial.ZeroTouches;
    }
}
