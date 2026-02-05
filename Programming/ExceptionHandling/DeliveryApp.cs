namespace ExceptionHandling
{
    
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string CuisineType { get; set; }
        public string Location { get; set; }
        public double DeliveryCharge { get; set; }

        public Restaurant(int id, string n, string c, string l, double d)
        {
            RestaurantId = id;
            Name = n;
            CuisineType = c;
            Location = l;
            DeliveryCharge = d;
        }
    }

    public class DeliveryManager
    {
        public static List<Restaurant> restaurants = new List<Restaurant>();
        static int counter = 1;

        public void AddRestaurant(string name, string cuisine, string location, double charge)
        {
            restaurants.Add(new Restaurant(counter++, name, cuisine, location, charge));
        }

        public Dictionary<string, List<Restaurant>> GroupRestaurantsByCuisine()
        {
            Dictionary<string, List<Restaurant>> dict = new Dictionary<string, List<Restaurant>>();

            foreach (var r in restaurants)
            {
                if (!dict.ContainsKey(r.CuisineType))
                    dict.Add(r.CuisineType, new List<Restaurant>());

                dict[r.CuisineType].Add(r);
            }
            return dict;
        }
    }

    public class DeliveryApp
    {
        public static void Main(string[] args)
        {
            DeliveryManager dm = new DeliveryManager();
            dm.AddRestaurant("Spice Hub", "Indian", "Chennai", 40);
            dm.AddRestaurant("Pizza Town", "Italian", "Chennai", 50);

            var grouped = dm.GroupRestaurantsByCuisine();
            foreach (var g in grouped)
            {
                Console.WriteLine("Cuisine: " + g.Key);
                foreach (var r in g.Value)
                    Console.WriteLine(r.Name);
            }
        }
    }

}