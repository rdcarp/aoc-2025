namespace PumpkinSoup.AOC2025.App.Domain.Cafeteria.Entities;

public record FreshIngredientIdRange(long From, long To)
{
    public bool IsInRange(long id)
    {
        return id >= From && id <= To;
    }
    
    public bool IsOverlapping(FreshIngredientIdRange other)
    {
        return IsInRange(other.From) || IsInRange(other.To);
    }
    
    public FreshIngredientIdRange Merge(FreshIngredientIdRange other)
    {
        if (!IsOverlapping(other))
            throw new ArgumentException("Ranges do not overlap");
        
        return new FreshIngredientIdRange(Math.Min(From, other.From), Math.Max(To, other.To));
    }

    public static FreshIngredientIdRange FromString(string input)
    {
        var fromAndTo = input.Split('-').Select(long.Parse).ToArray()[..2];
        return new FreshIngredientIdRange(fromAndTo[0], fromAndTo[1]);
    }
}