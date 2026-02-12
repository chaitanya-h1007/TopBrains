public class Program2
{
    public static void Main(string[] args)
    {
        string input = "Reverse";
        input.Trim();
        char[] rev = input.ToCharArray();
        int start = 0;
        int end = rev.Length - 1;
        while(start <= end){
            char temp = rev[start];
            rev[start] = rev[end];
            rev[end] = temp;
            start++;
            end--;
        }
        
        Console.WriteLine(new string(rev));
    }
}