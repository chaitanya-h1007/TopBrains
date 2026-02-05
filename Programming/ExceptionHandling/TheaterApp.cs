namespace ExceptionHandling
{
    public class MovieScreening
    {
        public string MovieTitle { get; set; }
        public DateTime ShowTime { get; set; }
        public string ScreenNumber { get; set; }
        public int TotalSeats { get; set; }
        public int BookedSeats { get; set; }
        public double TicketPrice { get; set; }

        public MovieScreening(string title, DateTime time, string screen, int seats, double price)
        {
            MovieTitle = title;
            ShowTime = time;
            ScreenNumber = screen;
            TotalSeats = seats;
            TicketPrice = price;
            BookedSeats = 0;
        }
    }

    public class TheaterManager
    {
        public static List<MovieScreening> screenings = new List<MovieScreening>();

        public void AddScreening(string title, DateTime time, string screen, int seats, double price)
        {
            screenings.Add(new MovieScreening(title, time, screen, seats, price));
        }

        public bool BookTickets(string movieTitle, DateTime showTime, int tickets)
        {
            foreach (var s in screenings)
            {
                if (s.MovieTitle == movieTitle && s.ShowTime == showTime)
                {
                    if (s.TotalSeats - s.BookedSeats >= tickets)
                    {
                        s.BookedSeats += tickets;
                        return true;
                    }
                }
            }
            return false;
        }
    }

    public class TheaterApp
    {
        public static void Main(string[] args)
        {
            TheaterManager tm = new TheaterManager();

            tm.AddScreening("Avengers", DateTime.Now, "S1", 100, 200);
            tm.BookTickets("Avengers", DateTime.Now, 5);

            Console.WriteLine("Booking Done");
        }
    }

}