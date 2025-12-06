using System.Diagnostics;

namespace PumpkinSoup.AOC2025.App.Domain.Puzzles.Handlers;

public abstract class BaseHandler
{
    public virtual int Day => throw new NotImplementedException();
    public virtual int Part => throw new NotImplementedException();
    public virtual long SolveInternal(string puzzleInput) => throw new NotImplementedException();
    
    public CommandResult Solve(string puzzleInput)
    {
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        var answer = SolveInternal(puzzleInput);
        stopwatch.Stop();

        return new CommandResult(answer, stopwatch);
    }
}

public record CommandResult(long Answer, Stopwatch Timer);
