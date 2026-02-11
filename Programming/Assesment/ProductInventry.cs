using System;
using System.Collections.Generic;
using System.Linq;

public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}

public enum Category { Electronics, Clothing, Books, Groceries }

// 1. Create a generic repository for products
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();

    // Implement method to add product with validation
    public void AddProduct(T product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        if (_products.Any(p => p.Id == product.Id))
            throw new InvalidOperationException("Id must be unique");
        if (product.Price < 0)
            throw new InvalidOperationException("Price cannot be negative");
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new InvalidOperationException("Name cannot be null or empty");

        _products.Add(product);
    }

    // Create method to find products by predicate
    public IEnumerable<T> FindProducts(Func<T, bool> predicate) //Predicate check for the condition passed with the FindProducts
                                                                // Example : p => p is ElectronicProduct as e && e.Brand = "sony";
    {
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));
        return _products.Where(predicate);
    }

    // Calculate total inventory value
    public decimal CalculateTotalValue()
    {
        return _products.Sum(p => p.Price);
    }

    public IEnumerable<T> GetAll() => _products;
}

// 2. Specialized electronic product
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

// Simple general product for non-electronics
public class SimpleProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
}

// 3. Create a discounted product wrapper
public class DiscountedProduct<T> : IProduct where T : IProduct
{
    private readonly T _product;
    private readonly decimal _discountPercentage;

    public DiscountedProduct(T product, decimal discountPercentage)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        if (discountPercentage < 0 || discountPercentage > 100)
            throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount must be between 0 and 100");

        _product = product;
        _discountPercentage = discountPercentage;
    }

    public int Id => _product.Id;
    public string Name => $"{_product.Name} (Discounted {_discountPercentage}%)";
    public decimal Price => DiscountedPrice;
    public Category Category => _product.Category;

    public decimal DiscountedPrice => Math.Round(_product.Price * (1 - _discountPercentage / 100m), 2);

    public override string ToString()
    {
        return $"{_product.Name}: Original {_product.Price:C}, Discounted {Price:C} ({_discountPercentage}% off)";
    }
}

// 4. Inventory manager with constraints
public class InventoryManager
{
    // Create method that accepts any IProduct collection
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        if (products == null) throw new ArgumentNullException(nameof(products));

        Console.WriteLine("Products:");
        foreach (var p in products)
        {
            Console.WriteLine($" - {p.Name}: {p.Price:C}");
        }

        var mostExpensive = products.OrderByDescending(p => p.Price).FirstOrDefault();
        if (mostExpensive != null)
            Console.WriteLine($"Most expensive: {mostExpensive.Name} at {mostExpensive.Price:C}");

        var groups = products.GroupBy(p => p.Category);
        Console.WriteLine("By category:");
        foreach (var g in groups)
        {
            Console.WriteLine($" - {g.Key}: {g.Count()} items");
        }

        Console.WriteLine("Discounted Electronics (10% if > $500):");
        foreach (var e in products.OfType<ElectronicProduct>().Where(x => x.Price > 500))
        {
            var dp = new DiscountedProduct<ElectronicProduct>(e, 10);
            Console.WriteLine($" - {dp}");
        }
    }

    // Implement bulk price update with delegate
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
        where T : IProduct
    {
        if (products == null) throw new ArgumentNullException(nameof(products));
        if (priceAdjuster == null) throw new ArgumentNullException(nameof(priceAdjuster));

        foreach (var p in products.ToList())
        {
            try
            {
                var newPrice = priceAdjuster(p);
                var prop = p.GetType().GetProperty("Price");
                if (prop != null && prop.CanWrite)
                {
                    prop.SetValue(p, newPrice);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to update price for {p.Name}: {ex.Message}");
            }
        }
    }
}

// 5. TEST SCENARIO: implement and demonstrate
public class Program
{
    public static void Main(string[] args)
    {
        var products = new List<IProduct>
        {
            new ElectronicProduct { Id = 1, Name = "Sony TV", Price = 1200m, Brand = "Sony", WarrantyMonths = 24 },
            new ElectronicProduct { Id = 2, Name = "Sony Headphones", Price = 150m, Brand = "Sony", WarrantyMonths = 12 },
            new SimpleProduct { Id = 3, Name = "T-Shirt", Price = 25m, Category = Category.Clothing },
            new SimpleProduct { Id = 4, Name = "C# Book", Price = 45m, Category = Category.Books },
            new SimpleProduct { Id = 5, Name = "Apples", Price = 3.5m, Category = Category.Groceries }
        };

        var repo = new ProductRepository<IProduct>();
        foreach (var p in products)
            repo.AddProduct(p);

        Console.WriteLine($"Total inventory value: {repo.CalculateTotalValue()}");

        // Attempt to add duplicate
        try
        {
            repo.AddProduct(new SimpleProduct { Id = 1, Name = "Duplicate", Price = 1m, Category = Category.Groceries });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Expected error adding duplicate: {ex.Message}");
        }

        // Find products by brand
        var sony = repo.FindProducts(p => p is ElectronicProduct e && e.Brand == "Sony");
        Console.WriteLine("Sony products:");
        foreach (var s in sony)
            Console.WriteLine($" - {s.Name} at {s.Price}");

        // Apply discounts and show total before/after
        var totalBefore = repo.CalculateTotalValue();
        var discountedList = repo.GetAll().Select(p => (p is ElectronicProduct ep && ep.Price > 500)
            ? (IProduct)new DiscountedProduct<ElectronicProduct>(ep, 10)
            : p).ToList();

        var totalAfter = discountedList.Sum(p => p.Price);
        Console.WriteLine($"Total before discounts: {totalBefore}");
        Console.WriteLine($"Total after discounts: {totalAfter}");

        // Inventory manager demo
        var manager = new InventoryManager();
        manager.ProcessProducts(repo.GetAll());

        // Bulk price update example: increase books price by $5
        var repoList = repo.GetAll().ToList();
        manager.UpdatePrices(repoList, p => p.Category == Category.Books ? p.Price + 5 : p.Price);

        Console.WriteLine($"Total after bulk update: {repoList.Sum(p => p.Price)}");
    }
}
