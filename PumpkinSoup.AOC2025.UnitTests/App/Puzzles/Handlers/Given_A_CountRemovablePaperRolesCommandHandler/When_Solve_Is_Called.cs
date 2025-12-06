using FluentAssertions;
using PumpkinSoup.AOC2025.App.Domain.Puzzles.Handlers;

namespace PumpkinSoup.AOC2025.UnitTests.App.Puzzles.Handlers.Given_A_CountRemovablePaperRolesCommandHandler;

public class When_Solve_Is_Called
{
    [Fact]
    public void With_AOC_Example_Then_The_Result_Is_Correct()
    {
        // Arrange
        var command = new CountRemovablePaperRollsCommandHandler();

        // Act
        var result = command.SolveInternal("..@@.@@@@.\n@@@.@.@.@@\n@@@@@.@.@@\n@.@@@@..@.\n@@.@@@@.@@\n.@@@@@@@.@\n.@.@.@.@@@\n@.@@@.@@@@\n.@@@@@@@@.\n@.@.@@@.@.");
        
        // Assert
        result.Should().Be(43);
    }
}

