namespace M1Practice
{
    /*
        Scenario: A library needs a console application to manage books and categorize them by genre.
        Requirements:
        csharp
        // In class Book, implement:
        // - int Id;
        // - string Title
        // - string Author
        // - string Genre
        // - int PublicationYear
        // 

        // In class LibraryUtility:
        public void AddBook(string title, string author, string genre, int year)
        // Adds book with auto-incremented ID

        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        // Groups books by genre alphabetically

        public List<Book> GetBooksByAuthor(string author)
        // Returns all books by specific author

        public int GetTotalBooksCount()
        // Returns total number of books
        Sample Use Cases:
        1.	Add Fiction, Non-Fiction, Mystery books
        2.	Display books grouped by genre
        3.	Search books by specific author
        4.	Show statistics (total books, books per genre)

    
    */
    public class Library
    {
        public static void Main(string[] args)
        {
            
        }
    }


    public class Book
    {
        public int Id{get; private set;}
        public string Title{get; set;}
        public string Genre{get; set;}
        public string Author{get; set;}
    }


    public class LibraryUtility
    {
        
    }
}