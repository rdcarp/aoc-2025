using FluentAssertions;
using PumpkinSoup.AOC2025.App.Domain.Power.Entities;

namespace PumpkinSoup.AOC2025.UnitTests.App.Domain.Power.Entities.Given_A_Bank;

public class When_MaximumJoltage_Is_Called
{
    [Theory]
    [InlineData("123", 23)]
    [InlineData("113", 13)]
    public void RegressionTest_Then_The_Maximum_Joltage_Is_Calculated(string bankConfiguration, long expected)
    {
        var bank = Bank.FromString(bankConfiguration);

        bank.GetMaximumJoltage().Should().Be(expected);
    }

    [Theory]
    [InlineData("987654321111111", 98)]
    [InlineData("811111111111119", 89)]
    [InlineData("234234234234278", 78)]
    [InlineData("818181911112111", 92)]
    public void Then_The_Maximum_Joltage_Is_Calculated(string bankConfiguration, long expected)
    {
        var bank = Bank.FromString(bankConfiguration);

        bank.GetMaximumJoltage().Should().Be(expected);
    }

    [Theory]
    [InlineData("987654321111111", 987654321111)]
    [InlineData("811111111111119", 811111111119)]
    [InlineData("234234234234278", 434234234278)]
    [InlineData("818181911112111", 888911112111)]
    public void With_Safety_Override_Then_The_Maximum_Joltage_Is_Calculated(string bankConfiguration, long expected)
    {
        var bank = Bank.FromString(bankConfiguration);

        bank.GetMaximumJoltage(12).Should().Be(expected);
    }
}