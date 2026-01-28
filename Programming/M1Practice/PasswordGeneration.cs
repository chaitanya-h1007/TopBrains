using System.Runtime.InteropServices;
using System.Linq;

namespace Programming.M1Practice
{
    // Simple utility to validate a specially-formatted username
    // and generate a password from it.
    public class PasswordGeneration
    {
        // Program entry: read username, validate, and print password.
        public static void Main(string[] args)
        {
            string UserName = Console.ReadLine();
            try
            {
                validateInput(UserName);
                System.Console.WriteLine("User Valid");
                System.Console.WriteLine(GeneratePassword(UserName));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        // Validate the username format:
        // - exactly 8 chars
        // - positions 0-3 are uppercase letters
        // - position 4 is '@'
        // - positions 5-7 are digits between 101 and 115 inclusive
        public static void validateInput(string userName)
        {
            if (userName.Length != 8)
            {
                throw new Exception("Length must be of 8");
            }

            if (userName[4] != '@')
            {
                throw new Exception("User name Must Contain @");
            }

            bool isUpper = userName.Take(4).All(char.IsUpper);
            if (!isUpper)
            {
                throw new Exception("First 4 must be a uppercase");
            }

            if (!char.IsDigit(userName[5]) || !char.IsDigit(userName[6]) || !char.IsDigit(userName[7]))
                throw new Exception("Last three must be digits");

            int lastThree = int.Parse(userName.Substring(5, 3));
            if (lastThree < 101 || lastThree > 115)
                throw new Exception("Last three digits must be between 101 and 115 inclusive");
        }


        // Build password from username:
        // Format: "TECH_" + sum(ascii of first4 lowercase) + last two digits (positions 6-7)
        public static string GeneratePassword(string username)
        {
            string password = "TECH_";
            string firstFour = username.Substring(0, 4);
            int sumOfAscii = FindSumOfAsciiVal(firstFour);
            password += sumOfAscii.ToString();
            string lastTwo = username.Substring(6, 2);
            password += lastTwo;
            return password;
        }

        // Sum ASCII values of a 4-character string (in lowercase).
        public static int FindSumOfAsciiVal(string str)
        {
            int sum = 0;
            str = str.ToLower();
            sum += (int)str[0] + (int)str[1] + (int)str[2] + (int)str[3];
            return sum;
        }
    }


}