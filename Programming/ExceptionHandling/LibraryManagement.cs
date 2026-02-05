namespace ExceptionHandling
{
    public class Book
    {
        public string Title{get; set;}
        public string Author{get; set;}
        public string Genre{get; set;}
        public int PublicationYear{get; set;}

        //constructor for Book
        public LibraryManagement(string title, string author, string genre, int year)
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
                
            }



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
            return booksList.size();
        }


    

    }

    public class LibraryManagement
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("this is the Library Program");
        }
    }
}