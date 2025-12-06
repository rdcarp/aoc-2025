using PumpkinSoup.AOC2025.App.Domain.Puzzles.Handlers;
using Spectre.Console;
using Spectre.Console.Cli;

namespace PumpkinSoup.AOC2025.Console.Commands;

public class SolverCommandDispatcher : Command<SolverSettings>
{
    private readonly BaseHandler[] _handlers;

    public SolverCommandDispatcher()
    {
        _handlers = AppDomain.CurrentDomain
            .GetAssemblies()
            .Where(a => a.FullName != null && a.FullName.StartsWith("PumpkinSoup.AOC2025"))
            .SelectMany(a => a.GetTypes())
            .Where(t => !t.IsAbstract && typeof(BaseHandler).IsAssignableFrom(t))
            .Select(t => Activator.CreateInstance(t) as BaseHandler)
            .Where(h => h is not null)
            .Cast<BaseHandler>()
            .ToArray();
    }

    private readonly PuzzleInputReader _puzzleInputReader = new();

    public override int Execute(CommandContext context, SolverSettings settings, CancellationToken cancellationToken)
    {
        var handlers = GetHandlers(settings.Day, settings.Part).ToArray();

        if (handlers.Count() is 0)
            throw new NotImplementedException($"No solution for day {settings.Day} (part {settings.Part}) implemented");

        var table = new Table().LeftAligned();
        table.AddColumn("Day");
        table.AddColumn("Part");
        table.AddColumn("Answer");
        table.AddColumn("Time");

        AnsiConsole.Live(table)
            .Start(ctx =>
                {
                    foreach (var handler in handlers)
                    {
                        var puzzleInput = _puzzleInputReader.ReadPuzzleInput(handler.Day);

                        table.AddRow(
                            handler.Day.ToString(),
                            handler.Part.ToString(),
                            "...",
                            "...");
                        ctx.Refresh();

                        var result = handler.Solve(puzzleInput);

                        table.UpdateCell(
                            table.Rows.Count - 1,
                            2,
                            new Text(result.Answer.ToString())
                        );
                        table.UpdateCell(
                            table.Rows.Count - 1,
                            3,
                            new Text(result.Timer.ElapsedMilliseconds.ToString())
                        );
                        ctx.Refresh();
                    }
                } 
            );

        return 0;
    }

    private IEnumerable<BaseHandler> GetHandlers(int? day, int? part)
    {
        return _handlers
            .Where(h => (day is null || h.Day == day)
                        && (part is null || h.Part == part))
            .OrderBy(handler => handler.Day)
            .ThenBy(handler => handler.Part);
    }
}
