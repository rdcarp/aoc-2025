namespace PumpkinSoup.AOC2025.App.Domain.GiftShop.Entities;

public class Database
{
    private readonly List<Product> _products = new();

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public IEnumerable<Product> EnumerateProducts()
    {
        return _products;
    }
}