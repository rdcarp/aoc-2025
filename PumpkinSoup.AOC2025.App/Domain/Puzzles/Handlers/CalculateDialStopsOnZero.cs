using PumpkinSoup.AOC2025.App.Domain.Safes.Entities;

namespace PumpkinSoup.AOC2025.App.Domain.Puzzles.Handlers;

public class CalculateDialStopsOnZero : BaseHandler
{
    public override int Day => 1;
    public override int Part => 1;

    public override long SolveInternal(string puzzleInput)
    {
        var safe = new Safe(new Dial(100, 50));

        var rotations = puzzleInput.Trim().Split('\n');

        foreach (var instruction in rotations)
        {
            var direction = instruction[0] == 'L' ? DialDirection.Left : DialDirection.Right;
            var amount = int.Parse(instruction[1..]);
    
            safe.Dial.SpinIt(direction, amount);
        }

        return safe.Dial.ZeroStops;
    }
}
