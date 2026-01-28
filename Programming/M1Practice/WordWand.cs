using System.Runtime.InteropServices;
namespace Programming.M1Practice{
    /// <summary>
    /// Reads a single-line sentence, then either reverses the order
    /// of words or reverses characters within each word depending
    /// on whether the word count is even or odd.
    /// </summary>
    public class WordWand
    {

        /// <summary>
        /// Program entry: read input, choose transformation, and print result.
        /// </summary>
        public static void Main(string[] args)
        {
            string input = Console.ReadLine(); // e.g. "Hello World New"
            string[] words = input.Split(' '); // split into words

            // If even number of words: reverse word order; else reverse each word's chars
            if (words.Length % 2 == 0)
            {
                System.Console.WriteLine(ReverseTheWords(words));
            }
            else
            {
                System.Console.WriteLine(ReverseCharacters(words));
            }
        }


        /// <summary>
        /// Reverse characters of each element in the input array.
        /// </summary>
        /// <param name="str">Array of words.</param>
        /// <returns>Concatenated string with each word's characters reversed.</returns>
        public static string ReverseCharacters(string[] str)
        {
            string res = "";
            for (int i = 0; i < str.Length; i++)
            {
                string toRev = str[i];
                res += EachCharReverse(toRev) + " "; // reverse and append
            }

            return res;
        }
        /// <summary>
        /// Reverse the characters of a single string.
        /// </summary>
        /// <param name="str">Input word.</param>
        /// <returns>Reversed word.</returns>
        public static string EachCharReverse(string str)
        {
            char[] charArr = str.ToCharArray();
            Array.Reverse(charArr);
            string rev = new string(charArr);
            return rev;
        }

        /// <summary>
        /// Reverse the order of words in the array in-place and join them.
        /// </summary>
        /// <param name="str">Array of words.</param>
        /// <returns>Single string with words in reversed order.</returns>
        public static string ReverseTheWords(string[] str)
        {
            string res = "";
            int start = 0;
            int end = str.Length - 1;

            // Swap words in-place
            while (start < end)
            {
                string temp = str[start];
                str[start] = str[end];
                str[end] = temp;
                start++;
                end--;
            }

            // Join with spaces
            for (int i = 0; i < str.Length; i++)
            {
                res = res + str[i] + " ";
            }

            return res;
        }
    }
}