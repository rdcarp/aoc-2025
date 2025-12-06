using FluentAssertions;
using PumpkinSoup.AOC2025.App.Domain.Puzzles.Handlers;

namespace PumpkinSoup.AOC2025.UnitTests.App.Puzzles.Handlers.Given_A_SumAllFreshIngredientIdsHandler;

public class When_Solve_Is_Called
{
    [Fact]
    public void With_AOC_Example_Then_The_Result_Is_Correct()
    {
        // Arrange
        var command = new SumAllFreshIngredientIdsHandler();

        // Act
        var result = command.SolveInternal("3-5\r\n10-14\r\n16-20\r\n12-18\r\n\r\n1\r\n5\r\n8\r\n11\r\n17\r\n32\r\n");
    
        // Assert
        result.Should().Be(14);
    }
}

