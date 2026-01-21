public class StringFormat
{
    
    public static void Main(string[] args)
    {
        System.Console.WriteLine("Enter the Number of Student: ");
        int numOfStudent = int.Parse(Console.ReadLine());

        string[] stuNameScore = new string[numOfStudent];
        System.Console.WriteLine("Enter the student deails as {Name:Score}");
        for(int i = 0; i < stuNameScore.Length ; i++)
        {
            stuNameScore[i] = Console.ReadLine();
        }
    }
}