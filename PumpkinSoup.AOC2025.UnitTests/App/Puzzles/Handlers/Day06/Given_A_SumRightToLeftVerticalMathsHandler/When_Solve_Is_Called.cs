using FluentAssertions;
using PumpkinSoup.AOC2025.App.Domain.Puzzles.Handlers.Day06;

namespace PumpkinSoup.AOC2025.UnitTests.App.Puzzles.Handlers.Day06.Given_A_SumRightToLeftVerticalMathsHandler;

public class When_Solve_Is_Called
{
    [Fact]
    public void With_AOC_Example_Then_The_Result_Is_Correct()
    {
        // Arrange
        var command = new SumRightToLeftVerticalMathsHandler();
        
        // Act
        var result = command.SolveInternal("123 328  51 64 \n 45 64  387 23 \n  6 98  215 314\n*   +   *   +  ");
        
        // Assert
        result.Should().Be(3263827);
    }
}
