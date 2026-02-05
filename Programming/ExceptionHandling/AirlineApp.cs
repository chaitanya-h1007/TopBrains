namespace ExcepionHandling
{

    public class Flight
    {
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public double TicketPrice { get; set; }

        public Flight(string no, string o, string d, int seats, double price)
        {
            FlightNumber = no;
            Origin = o;
            Destination = d;
            TotalSeats = seats;
            AvailableSeats = seats;
            TicketPrice = price;
        }
    }

    public class AirlineManager
    {
        public static List<Flight> flights = new List<Flight>();

        public void AddFlight(string no, string o, string d, int seats, double price)
        {
            flights.Add(new Flight(no, o, d, seats, price));
        }

        public bool BookFlight(string no, int seats)
        {
            foreach (var f in flights)
            {
                if (f.FlightNumber == no && f.AvailableSeats >= seats)
                {
                    f.AvailableSeats -= seats;
                    return true;
                }
            }
            return false;
        }
    }

    public class AirlineApp
    {
        public static void Main(string[] args)
        {
            AirlineManager am = new AirlineManager();
            am.AddFlight("AI101", "Chennai", "Delhi", 100, 4500);

            bool booked = am.BookFlight("AI101", 2);
            Console.WriteLine("Booking Status: " + booked);

            foreach (var f in AirlineManager.flights)
                Console.WriteLine(f.FlightNumber + " Seats Left: " + f.AvailableSeats);
        }
    }

    
}