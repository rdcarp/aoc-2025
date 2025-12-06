using Spectre.Console.Cli;

namespace PumpkinSoup.AOC2025.Console.Commands;

public abstract class BaseCommand : Command<PuzzleCommandsSettings>
{
    public abstract int Day { get; }
    public abstract int Part { get; }
    protected string PuzzleInput { get; private set; }

    protected abstract long Solve();

    public int Solive()
    {
        PuzzleInput = File.ReadAllText($"Inputs\\day{Day.ToString().PadLeft(2, '0')}.txt");

        System.Console.WriteLine($"Day {Day} Part {Part}");

        var answer = Solve();
    
        System.Console.WriteLine($"Answer: {answer}");

        return 0;
    }
}
