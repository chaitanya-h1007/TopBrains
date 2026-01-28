using System.Diagnostics;

namespace Programming.M1Practice
{
    public class NameMatch
    {
        public static void Main(string[] args)
        {
            string MaleName = Console.ReadLine(); // "JOHN"
            string FemaleName = Console.ReadLine(); // "JOHANA"
            if(MaleName == FemaleName)
            {
                System.Console.WriteLine(0);
            }

            char[] maleArr = MaleName.ToCharArray(); //     {'J', 'O', 'H','N'}
            char[] femaleArr = FemaleName.ToCharArray(); // {'J', 'O', 'H','A','N','A'}

            System.Console.WriteLine(CheckCompatibility(maleArr, femaleArr));
  
        }

        public static int CheckCompatibility(char[] maleArr, char[] femaleArr)
        {
            int count = 0;

            if(maleArr.Length == femaleArr.Length)
            {
                return -1;
            }

            
        }
    }
}