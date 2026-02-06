namespace FoodDelivery.Entity{

    public class Driver
    {
        public string DriverId { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }

        public double Rating { get; set; }
        public decimal CostPerKm { get; set; }

        public Location CurrentLocation { get; set; }
    }

}