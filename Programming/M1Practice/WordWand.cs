using System.Runtime.InteropServices;
namespace Programming.M1Practice{
    public class WordWand
    {

        public static void Main(string[] args)
        {
            string input = Console.ReadLine();    // Hello World New
            string[] words = input.Split(" ");

            if(words.Length % 2 == 0)
            {
                System.Console.WriteLine(ReverseTheWords(words));
            }
            else
            {
                System.Console.WriteLine(ReverseCharacters(words));
                // olleH dlroW weN
            }
        }


        public static string ReverseCharacters(string[] str)
        {
            string res ="";
            for(int i = 0; i < str.Length; i++)
            {
                string toRev = str[i];
                res += EachCharReverse(toRev) + " ";
            }

            return res;
            
        }
        public static string EachCharReverse(string str)
        {
            char[] charArr = str.ToCharArray();
            Array.Reverse(charArr);
            string rev = new string(charArr);
            return rev;
        }

        public static string ReverseTheWords(string[] str)
        {
            string res = "";
            int start = 0;
            int end = str.Length - 1;

            while(start < end)
            {
                string temp = str[start];
                str[start] = str[end];
                str[end] = temp;
                start++;
                end--;
            }

            for(int i = 0; i < str.Length; i++)
            {
                res = res + str[i] + " ";
            }


            return res;
        }
    }
}