using System.Collections.Immutable;
using System.Reflection.Metadata;

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
    
    // TODO: Implement method to add product with validation
    public void AddProduct(T product)
    {
        // Rule: Product ID must be unique
        // Rule: Price must be positive
        // Rule: Name cannot be null or empty
        // Add to collection if validation passes
        if (_products.Any(p => p.Id == product.Id))
        {
            throw new Exception("Product with same ID Exists");
        }
        if (product.Price < 0) 
            throw new Exception("Price cannot be negative");
        if (string.IsNullOrEmpty(product.Name))
            throw new Exception("Name cannot be null or empty");

        _products.Add(product);
    }
    
    // TODO: Create method to find products by predicate
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        // Should return filtered products
        return _products.Where(predicate);
    }
    
    // TODO: Calculate total inventory value
    public decimal CalculateTotalValue()
    {
        // Return sum of all product prices
        decimal totalSum = 0;
        foreach(var item in _products)
        {
            totalSum += item.Price;
        }
        return totalSum;
    }
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

// 3. Create a discounted product wrapper
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;
    
    public DiscountedProduct(T product, decimal discountPercentage)
    {
        // TODO: Initialize with validation
        // Discount must be between 0 and 100
        if (discountPercentage < 0 || discountPercentage > 100)
            throw new ArgumentException("Discount must be between 0 and 100");
        this._product = product;
        this._discountPercentage = discountPercentage;
    }
    
    // TODO: Implement calculated price with discount
    public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);

    // TODO: Override ToString to show discount details
    public override string ToString()
    {
        return DiscountedPrice.ToString();
    }
}

// 4. Inventory manager with constraints
public class InventoryManager
{
    // TODO: Create method that accepts any IProduct collection
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        // a) Print all product names and prices
        foreach(var items in products)
        {
            Console.WriteLine($"{items.Name}: {items.Price}");
        }
        // b) Find the most expensive product
        var maximumPrice = products.MaxBy(p => p.Price);
        Console.WriteLine($"Most Expensive: {maximumPrice?.Name} - {maximumPrice?.Price}");
        
        // c) Group products by category
        var groupByCategory = products
            .GroupBy(p => p.Category)
            .Select(g => new { Category = g.Key, Count = g.Count(), TotalPrice = g.Sum(p => p.Price) });
        
        foreach(var group in groupByCategory)
        {
            Console.WriteLine($"{group.Category}: {group.Count} products, Total: {group.TotalPrice}");
        }
        
        // d) Apply 10% discount to Electronics over $500
        var discountedElectronics = products
            .Where(p => p.Category == Category.Electronics && p.Price > 500)
            .Select(p => new { p.Name, OriginalPrice = p.Price, DiscountedPrice = p.Price * 0.9m });
        
        foreach(var item in discountedElectronics)
        {
            Console.WriteLine($"{item.Name}: {item.OriginalPrice} -> {item.DiscountedPrice}");
        }
    }
    
    // TODO: Implement bulk price update with delegate
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster) 
        where T : IProduct
    {
        // Apply priceAdjuster to each product
        // Handle exceptions gracefully
        try
        {
            foreach (var product in products)
            {
                var newPrice = priceAdjuster(product);
                if (newPrice < 0)
                    throw new ArgumentException($"Invalid price for {product.Name}: price cannot be negative.");
                // Update the product price through reflection or property setter if available
                var priceProperty = product.GetType().GetProperty("Price");
                if (priceProperty?.CanWrite == true)
                {
                    priceProperty.SetValue(product, newPrice);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating prices: {ex.Message}");
        }
    }


    public static void Main(string[] args){
        
        // 5. TEST SCENARIO: Your tasks:
        // a) Implement all TODO methods with proper error handling
        // b) Create a sample inventory with at least 5 products
        // c) Demonstrate:
        //    - Adding products with validation
        //    - Finding products by brand (for electronics)
        //    - Applying discounts
        //    - Calculating total value before/after discount
        //    - Handling a mixed collection of different product types

        Console.WriteLine("=== INVENTORY MANAGEMENT SYSTEM ===\n");

        // Create repository for electronic products
        var electronicRepo = new ProductRepository<ElectronicProduct>();

        // Create sample products (at least 5)
        var laptop = new ElectronicProduct { Id = 1, Name = "Dell Laptop", Price = 1200, Brand = "Dell", WarrantyMonths = 24 };
        var phone = new ElectronicProduct { Id = 2, Name = "iPhone 15", Price = 999, Brand = "Apple", WarrantyMonths = 12 };
        var tablet = new ElectronicProduct { Id = 3, Name = "iPad Pro", Price = 1500, Brand = "Apple", WarrantyMonths = 12 };
        var headphones = new ElectronicProduct { Id = 4, Name = "Sony Headphones", Price = 350, Brand = "Sony", WarrantyMonths = 12 };
        var monitor = new ElectronicProduct { Id = 5, Name = "LG Monitor", Price = 450, Brand = "LG", WarrantyMonths = 36 };

        Console.WriteLine("--- Adding Products with Validation ---");
        try
        {
            electronicRepo.AddProduct(laptop);
            Console.WriteLine("✓ Added: Laptop");
            
            electronicRepo.AddProduct(phone);
            Console.WriteLine("✓ Added: iPhone");
            
            electronicRepo.AddProduct(tablet);
            Console.WriteLine("✓ Added: iPad Pro");
            
            electronicRepo.AddProduct(headphones);
            Console.WriteLine("✓ Added: Headphones");
            
            electronicRepo.AddProduct(monitor);
            Console.WriteLine("✓ Added: Monitor");

            // Try adding duplicate ID (should fail)
            var duplicate = new ElectronicProduct { Id = 1, Name = "Duplicate", Price = 100, Brand = "Test", WarrantyMonths = 12 };
            electronicRepo.AddProduct(duplicate);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Error: {ex.Message}\n");
        }

        Console.WriteLine("\n--- Finding Products by Brand (Apple) ---");
        var appleProducts = electronicRepo.FindProducts(p => p.Brand == "Apple");
        foreach (var product in appleProducts)
        {
            Console.WriteLine($"  • {product.Name} - ${product.Price}");
        }

        Console.WriteLine("\n--- Calculated Total Inventory Value ---");
        decimal beforeDiscount = electronicRepo.CalculateTotalValue();
        Console.WriteLine($"Total Value: ${beforeDiscount:F2}");

        Console.WriteLine("\n--- Applying Discounts (Decorator Pattern) ---");
        var discountedLaptop = new DiscountedProduct<ElectronicProduct>(laptop, 15);
        var discountedPhone = new DiscountedProduct<ElectronicProduct>(phone, 10);
        
        Console.WriteLine($"Laptop: ${laptop.Price} -> ${discountedLaptop.DiscountedPrice:F2} (15% off)");
        Console.WriteLine($"iPhone: ${phone.Price} -> ${discountedPhone.DiscountedPrice:F2} (10% off)");

        Console.WriteLine("\n--- Processing Mixed Product Collection ---");
        var inventoryManager = new InventoryManager();
        inventoryManager.ProcessProducts(new[] { laptop, phone, tablet, headphones, monitor });

        Console.WriteLine("\n--- Bulk Price Update with Delegate ---");
        var productsToUpdate = new List<ElectronicProduct> { laptop, phone, tablet };
        
        // Apply 5% price increase
        inventoryManager.UpdatePrices(productsToUpdate, p => p.Price * 1.05m);
        Console.WriteLine("✓ Applied 5% price increase to 3 products");
        Console.WriteLine($"New Laptop Price: ${laptop.Price:F2}");
        Console.WriteLine($"New iPhone Price: ${phone.Price:F2}");

        Console.WriteLine("\n=== END OF DEMONSTRATION ===");
    }
}
