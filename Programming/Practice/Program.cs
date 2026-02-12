public class Program
{
    public static string ErrorMessage = "";
    public static void Main(string[] args)
    {

        Console.WriteLine("Enter the email:");
        string email = Console.ReadLine();
        
        email = email.ToLower().Trim();

        if (CountOfAt(email) != 1 && CountOfDot(email) != 1)
        {
            Console.WriteLine("Incorrect Email");
            return;
        }

        string[] parts = email.Split('@');

        if (parts.Length != 2)
        {
            Console.WriteLine("Incorrect Email");
            return;
        }

        string username = parts[0];
        string domain = parts[1];

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(domain))
        {
            Console.WriteLine("Incorrect Email");
            return;
        }

        if (!domain.Equals("gmail.com"))
        {
            Console.WriteLine("Incorrect Email");
            return;
        }

        if (!domain.Contains("."))
        {
            Console.WriteLine("Incorrect Email");
            return;
        }

        Console.WriteLine("Correct Email");
    }

    static int CountOfAt(string email)
    {
        int count = 0;
        foreach (char c in email)
        {
            if (c == '@')
                count++;
        }
        return count;
    }

    static int CountOfDot(string email)
    {
        int count = 0;
        foreach (char c in email)
        {
            if (c == '.')
                count++;
        }
        return count;
    }
}