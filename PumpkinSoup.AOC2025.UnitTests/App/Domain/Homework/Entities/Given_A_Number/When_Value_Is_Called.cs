using FluentAssertions;
using PumpkinSoup.AOC2025.App.Domain.Homework.Entities;
using PumpkinSoup.AOC2025.App.Domain.Homework.ValueObjects;

namespace PumpkinSoup.AOC2025.UnitTests.App.Domain.Homework.Entities.Given_A_Number;

public class When_Value_Is_Called
{
    [Fact]
    public void Then_The_Result_Is_Correct()
    {
        // Arrange
        var expectedValue = 123;
        var number = new Number();
        number.PushNextSignificantDigit(new Digit(1));
        number.PushNextSignificantDigit(new Digit(2));
        number.PushNextSignificantDigit(new Digit(3));

        // Act
        var result = number.Value;

        // Assert
        result.Should().Be(expectedValue);
    }
}
