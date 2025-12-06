using FluentAssertions;
using PumpkinSoup.AOC2025.App.Domain.Puzzles.Handlers;

namespace PumpkinSoup.AOC2025.UnitTests.App.Puzzles.Handlers.Given_A_SumSillyPatternProductIds;

public class When_Solve_Is_Called
{
    [Fact]
    public void With_AOC_Example_Then_The_Result_Is_Correct()
    {
        // Arrange
        var command = new SumSillyPatternProductIds();

        // Act
        var result = command.SolveInternal("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,\n1698522-1698528,446443-446449,38593856-38593862,565653-565659,\n824824821-824824827,2121212118-2121212124");
        
        // Assert
        result.Should().Be(1227775554);
    }
}
