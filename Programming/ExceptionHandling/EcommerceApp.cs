namespace ExceptionHandling
{
    public class Product
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }

        public Product(string code, string name, string cat, double price, int stock)
        {
            ProductCode = code;
            ProductName = name;
            Category = cat;
            Price = price;
            StockQuantity = stock;
        }
    }

    public class InventoryManager
    {
        public static List<Product> products = new List<Product>();
        static int counter = 1;

        public void AddProduct(string name, string category, double price, int stock)
        {
            string code = "P" + counter++;
            products.Add(new Product(code, name, category, price, stock));
        }

        public SortedDictionary<string, List<Product>> GroupProductsByCategory()
        {
            SortedDictionary<string, List<Product>> dict = new SortedDictionary<string, List<Product>>();
            foreach (var p in products)
            {
                if (!dict.ContainsKey(p.Category))
                    dict.Add(p.Category, new List<Product>());

                dict[p.Category].Add(p);
            }
            return dict;
        }

        public bool UpdateStock(string productCode, int qty)
        {
            foreach (var p in products)
            {
                if (p.ProductCode == productCode && p.StockQuantity >= qty)
                {
                    p.StockQuantity -= qty;
                    return true;
                }
            }
            return false;
        }

        public List<Product> GetProductsBelowPrice(double max)
        {
            List<Product> list = new List<Product>();
            foreach (var p in products)
                if (p.Price < max)
                    list.Add(p);

            return list;
        }
    }

    public class EcommerceApp
    {
        public static void Main(string[] args)
        {
            InventoryManager im = new InventoryManager();

            im.AddProduct("Laptop", "Electronics", 55000, 10);
            im.AddProduct("Shirt", "Clothing", 1200, 50);

            var grouped = im.GroupProductsByCategory();

            foreach (var g in grouped)
            {
                Console.WriteLine("Category: " + g.Key);
                foreach (var p in g.Value)
                    Console.WriteLine(p.ProductName);
            }
        }
    }
    


}

