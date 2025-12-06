using PumpkinSoup.AOC2025.App.Domain.Forklifts.Entities;

namespace PumpkinSoup.AOC2025.App.Domain.Puzzles.Handlers;

public class CountAccessiblePaperRollsCommandHandler : BaseHandler
{
    public override int Day => 4;
    public override int Part => 1;

    public override long SolveInternal(string puzzleInput)
    {
        var lines = puzzleInput.Split('\n').Select(line => line.Trim()).ToArray();
        var columnsCount = lines[0].Length;

        var diagram = new HelpfulRollsOfPaperDiagram(lines.Count(), columnsCount);

        for (int lineIndex = 0; lineIndex < lines.Length; lineIndex++)
        {
            var positionMarkers = lines[lineIndex].ToCharArray();

            for (int columnIndex = 0; columnIndex < positionMarkers.Length; columnIndex++)
            {
                if (positionMarkers[columnIndex] == '@')
                    diagram.PlacePaperRoll(columnIndex, lineIndex);
            }
        }

        return diagram.AccessiblePaperRollsCount(3);
    }
}