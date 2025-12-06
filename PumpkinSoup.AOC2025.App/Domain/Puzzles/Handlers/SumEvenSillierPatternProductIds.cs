using PumpkinSoup.AOC2025.App.Domain.GiftShop.Entities;
using PumpkinSoup.AOC2025.App.Domain.GiftShop.ValueObjects;

namespace PumpkinSoup.AOC2025.App.Domain.Puzzles.Handlers;

public class SumEvenSillierPatternProductIds : BaseHandler
{
    public override int Day => 2;
    public override int Part => 2;

    public override long SolveInternal(string puzzleInput)
    {
        var database = new Database();
        var produceIdRanges = puzzleInput.Split(',');

        foreach (var produceIdRange in produceIdRanges)
        {
            var fromAndTo = produceIdRange.Split('-').Select(long.Parse).ToArray()[..2];
            for(long id = fromAndTo[0]; id <= fromAndTo[1]; id++)
                database.AddProduct(new Product(new ProductId(id)));
        }

        var invalidIds = database
            .EnumerateProducts()
            .Where(p => p.ProductId.IsEvenSillierPattern());

        return invalidIds.Sum(p => p.ProductId.Value);
    }
}