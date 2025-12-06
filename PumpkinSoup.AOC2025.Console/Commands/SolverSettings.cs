using Spectre.Console.Cli;

namespace PumpkinSoup.AOC2025.Console.Commands;

public class SolverSettings : CommandSettings
{
    [CommandArgument(0, "[DAY]")]
    public int? Day { get; set; }
    
    [CommandArgument(1, "[PART]")]
    public int? Part { get; set; }
}
