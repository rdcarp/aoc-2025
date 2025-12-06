using FluentAssertions;
using PumpkinSoup.AOC2025.App.Domain.Puzzles.Handlers;

namespace PumpkinSoup.AOC2025.UnitTests.App.Puzzles.Handlers.Given_A_CalculateMaximumJoltageInBankCollectionWithSafetyOverride;

public class When_Solve_Is_Called
{
    [Fact]
    public void With_AOC_Example_Then_The_Result_Is_Correct()
    {
        // Arrange
        var command = new CalculateMaximumJoltageInBankCollectionWithSafetyOverride();
        
        // Act
        var result = command.SolveInternal("987654321111111\n811111111111119\n234234234234278\n818181911112111");
        
        // Assert
        result.Should().Be(3121910778619);
    }
}