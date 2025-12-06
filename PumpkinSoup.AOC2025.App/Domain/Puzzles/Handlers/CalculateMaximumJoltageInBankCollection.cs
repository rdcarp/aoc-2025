using PumpkinSoup.AOC2025.App.Domain.Power.Entities;

namespace PumpkinSoup.AOC2025.App.Domain.Puzzles.Handlers;

public class CalculateMaximumJoltageInBankCollection : BaseHandler
{
    public override int Day => 3;
    public override int Part => 1;

    public override long SolveInternal(string puzzleInput)
    {
        var banks = puzzleInput.Split('\n').Select(Bank.FromString);
        
        return banks.Sum(b => b.GetMaximumJoltage(2));
    }
}