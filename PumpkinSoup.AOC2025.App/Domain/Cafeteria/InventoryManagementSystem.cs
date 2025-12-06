using System.ComponentModel;
using PumpkinSoup.AOC2025.App.Domain.Cafeteria.Entities;

namespace PumpkinSoup.AOC2025.App.Domain.Cafeteria;

public class InventoryManagementSystem
{
    private List<FreshIngredientIdRange> _freshIngredientIdRanges = new();
    private bool ContainsOverlappingRanges => _freshIngredientIdRanges
        .Any(r => _freshIngredientIdRanges
            .Any(r2 => r2 != r && r.IsOverlapping(r2))); 

    public void AddRangeOfFreshIngredientIds(long lower, long upper)
    {   
        _freshIngredientIdRanges.Add(new FreshIngredientIdRange(lower, upper));

        while (CollapseRanges()) ;
    }
    
    public bool CollapseRanges()
    {
        var newRanges = new List<FreshIngredientIdRange>();
        
        Queue<FreshIngredientIdRange> queue = new();
        _freshIngredientIdRanges.OrderBy(r => r.From).ToList().ForEach(r => queue.Enqueue(r));

        while (queue.Count > 0)
        {
            var range = queue.Dequeue();
         
            if (queue.TryPeek(out var other) && range.IsOverlapping(other))
            {
                range = range.Merge(other);
                queue.Dequeue();
                
                newRanges.Add(range);
            }
            else
            {
                newRanges.Add(range);
            }
        }
        
        _freshIngredientIdRanges = newRanges;

        return ContainsOverlappingRanges;
    }
    
    public bool IsFresh(long ingredientId)
    {
        return _freshIngredientIdRanges.Exists(r => r.From <= ingredientId && ingredientId <= r.To);
    }

    public long CountFreshIngredientIds()
    {
        return _freshIngredientIdRanges.Sum(r => r.To - r.From + 1);
    }
}