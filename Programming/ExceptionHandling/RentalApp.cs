namespace ExceptionHandling
{
    public class RentalCar
    {
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string CarType { get; set; }
        public bool IsAvailable { get; set; }
        public double DailyRate { get; set; }

        public RentalCar(string license, string make, string model, string type, double rate)
        {
            LicensePlate = license;
            Make = make;
            Model = model;
            CarType = type;
            DailyRate = rate;
            IsAvailable = true;
        }
    }

    public class RentalManager
    {
        public static List<RentalCar> cars = new List<RentalCar>();

        public void AddCar(string license, string make, string model, string type, double rate)
        {
            cars.Add(new RentalCar(license, make, model, type, rate));
        }
    }

    public class RentalApp
    {
        public static void Main(string[] args)
        {
            RentalManager rm = new RentalManager();
            rm.AddCar("TN01AB1234", "Toyota", "Innova", "SUV", 3000);

            var grouped = rm.GroupCarsByType();
            foreach (var g in grouped)
            {
                Console.WriteLine("Type: " + g.Key);
                foreach (var c in g.Value)
                    Console.WriteLine(c.Make + " " + c.Model);
            }
        }
    }

    
}