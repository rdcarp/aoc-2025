// See https://aka.ms/new-console-template for more information

using PumpkinSoup.AOC2025.Console.Commands;
using Spectre.Console.Cli;

var app = new CommandApp();
app.Configure(config =>
{
    config.AddCommand<SolverCommandDispatcher>("solve");
    config.PropagateExceptions();
});

app.Run(args);
