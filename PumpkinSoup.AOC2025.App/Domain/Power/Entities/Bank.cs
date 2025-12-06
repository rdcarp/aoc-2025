using PumpkinSoup.AOC2025.App.Domain.Power.ValueObject;

namespace PumpkinSoup.AOC2025.App.Domain.Power.Entities;

public record Bank
{
    private long? _maximumJoltage = null;
    public IEnumerable<Battery> Batteries { get; init; }

    public Bank(IEnumerable<Battery> Batteries)
    {
        this.Batteries = Batteries;
    }

    public static Bank FromString(string input)
    {
        return new Bank(
            input.Trim()
                .ToCharArray()
                .Select(c => long.Parse(c.ToString()))
                .Select(j => new Battery(new Joltage(j))));
    }
    
    public long GetMaximumJoltage(int batteryCount = 2)
    {
        var batteryArray = Batteries.ToArray();
        List<int> batteryIndexes = new();
        
        
        while(batteryIndexes.Count < batteryCount)
        {
            var batteriesRequired = batteryCount - batteryIndexes.Count;
            var window = batteryArray[(batteryIndexes.LastOrDefault(-1) + 1)..(batteryArray.Length - (batteriesRequired - 1))];

            var maxValueInWindow = window
                .Max(b => b.Joltage.Value);

            var maxValueIndex = batteryIndexes.LastOrDefault(-1) + 1 + window  
                .Select(((battery, i) => new { battery, i }))
                .First(x => x.battery.Joltage.Value == maxValueInWindow).i;

            batteryIndexes.Add(maxValueIndex);
        }

        return batteryIndexes
            .Select((batteryIndex, collectionIndex) =>
                (long)(Batteries.ToArray()[batteryIndex].Joltage.Value * ((Math.Pow(10, batteryCount - ( collectionIndex + 1))))))
            .Sum();
    }

    public override string ToString()
    {
        return string.Join("", Batteries.Select(b => b.Joltage.Value));
    }
}