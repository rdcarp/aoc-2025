using PumpkinSoup.AOC2025.App.Domain.Cafeteria;

namespace PumpkinSoup.AOC2025.App.Domain.Puzzles.Handlers;

public class CountFreshIngredientIdsHandler : BaseHandler
{
    public override int Day => 5;
    public override int Part => 1;
    
    public override long SolveInternal(string puzzleInput)
    {
        var rangesAndSearchIds = puzzleInput.Trim().Split(Environment.NewLine + Environment.NewLine).Take(2).ToArray();
        var freshIngredientIdRanges = rangesAndSearchIds[0].Split(Environment.NewLine);
        var searchIds = rangesAndSearchIds[1].Split("\r\n").Select(long.Parse);

        var database = new InventoryManagementSystem();

        foreach (var freshIngredientIdRange in freshIngredientIdRanges)
        {
            var fromAndTo = freshIngredientIdRange.Split('-').Select(long.Parse).ToArray()[..2];
            database.AddRangeOfFreshIngredientIds(fromAndTo[0], fromAndTo[1]);
        }

        return searchIds
            .Count(i => database.IsFresh(i));
    }
}