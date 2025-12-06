using FluentAssertions;
using PumpkinSoup.AOC2025.App.Domain.GiftShop.ValueObjects;

namespace PumpkinSoup.AOC2025.UnitTests.App.Domain.GiftShop.ValueObject;

public class Given_A_Product
{
    [Theory]
    [InlineData("11", true)]
    [InlineData("12", false)]
    [InlineData("100", false)]
    public void With_AOC_Example_Then_The_Result_Is_Correct(string id, bool isSilly)
    {
        // Arrange
        var product = new ProductId(id);
        
        // Act
        var result = product.IsSillyPattern();
        
        // Assert
        result.Should().Be(isSilly);
    }
}