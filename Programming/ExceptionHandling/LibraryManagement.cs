namespace ExceptionHandling
{
    public class Book
    {
        public string Title{get; set;}
        public string Author{get; set;}
        public string Genre{get; set;}
        public int PublicationYear{get; set;}

        //constructor for Book
        public Book(string title, string author, string genre, int year)
        {
            this.Title = title;
            this.Author = author;
            this.Genre = genre;
            this.PublicationYear = year;
        }
    }
    public class LibraryUtility
    {
        //Local storage to add the books as Object
        public static List<Book> booksList = new List<Book>();
        /// <summary>
        /// This methods creates a new Book Object and add that to the List booksList
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="genre"></param>
        /// <param name="year"></param>
        public void AddBook(string title, string author, string genre, int year)
        {
            booksList.Add(new Book(title, author, genre, year));
            System.Console.WriteLine("Book Added Successfully");
        }

        // Groups books by genre alphabetically
        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            SortedDictionary<string, List<Book>> resDictionary = new SortedDictionary<string, List<Book>>();

            foreach (var item in booksList)
            {

                if (!resDictionary.ContainsKey(item.Genre)) //if key not present add a key with new list.
                {

                    resDictionary.Add(item.Genre, new List<Book>());  
                }
                resDictionary[item.Genre].Add(item);
                
            }
            return resDictionary;
        }

        // Returns all books by specific author
        public List<Book> GetBooksByAuthor(string author)
        {
            List<Book> listByAuthor = new List<Book>();

            foreach (var item in booksList)
            {
                if(item.Author == author)
                {
                    listByAuthor.Add(item);
                }

            }
            return listByAuthor;
        }

        // Returns total number of books
        public int GetTotalBookcount()
        {
            return booksList.Count();
        }
    }

    public class LibraryManagement
    {
        public static void Main(string[] args)
        {
            LibraryUtility lb = new LibraryUtility();
            lb.AddBook("Algorithims to Live by", "Jake", "Non-fiction", 2019);
            lb.AddBook("Harry Potter", "JK Rowlling", "Fiction", 1998);
            lb.AddBook("The Indian Saga", "R.K Krishnan", "Novel", 2007);

            Console.WriteLine("Books Grouped By Genre:");
            var grouped = lb.GroupBooksByGenre();
            foreach (var g in grouped)
            {
                Console.WriteLine("Genre: " + g.Key);
                foreach (var b in g.Value)
                    Console.WriteLine("  " + b.Title + " by " + b.Author);
            }

            // Search by Author
            Console.WriteLine("\nBooks by JK Rowlling:");
            var authorBooks = lb.GetBooksByAuthor("JK Rowlling");
            foreach (var b in authorBooks)
                Console.WriteLine(b.Title);

            // Total Count
            Console.WriteLine("\nTotal Books: " + lb.GetTotalBookcount());



        }
    }
}