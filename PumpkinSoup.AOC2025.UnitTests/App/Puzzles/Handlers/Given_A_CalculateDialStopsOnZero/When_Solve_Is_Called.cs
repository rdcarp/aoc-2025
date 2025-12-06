using FluentAssertions;
using PumpkinSoup.AOC2025.App.Domain.Puzzles.Handlers;

namespace PumpkinSoup.AOC2025.UnitTests.App.Puzzles.Handlers.Given_A_CalculateDialStopsOnZero;

public class When_Solve_Is_Called
{
    [Fact]
    public void With_AOC_Example_Then_The_Result_Is_Correct()
    {
        // Arrange
        var command = new CalculateDialStopsOnZero();
        
        // Act
        var result = command.SolveInternal("L68\nL30\nR48\nL5\nR60\nL55\nL1\nL99\nR14\nL82\n");
        
        // Assert
        result.Should().Be(3);
    }
}