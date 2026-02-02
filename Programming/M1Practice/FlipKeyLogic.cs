namespace M1Practice
{
    public class FlipKeyLogic
    {
        public static void Main()
        {
            Console.WriteLine("Do not give input less than 6 characters");
            string? input = Console.ReadLine();
            //Console.WriteLine(input);
            string res = FlipKeyMethod(input);
            //Console.WriteLine(res);
            if(res == string.Empty) Console.WriteLine("Invalid Input");
            Console.WriteLine($"Result: {res}");

        }


        public static string FlipKeyMethod(string input)
        {

            // Handlin the Endge CASE FOR EMpty String
            if (input == string.Empty || input.Length < 6)
            {
                return string.Empty;
            }
            //.Any checks that any part of the sequence is present or not in the string
            //if (input.Contains(" ") || input.Any("1234567890".Contains) || input.Any("@#$%&^*()!?".Contains))
        
            if(input.Any(" 1234567890!@#$%^&*(){}[]".Contains))
            {
                return string.Empty;
            }
            string res = input.ToLower();
            List<char> charrlist = res.ToList();
            //chararr[i];

            //removing the ascii val with even...
            ToRemoveEvenAscii(charrlist);
            //Reverse the remainning string

            ToRemoveEvenIndex(charrlist);
            charrlist.Reverse();
            res = new string(charrlist.ToArray());
            return res;


        }

        public static void ToRemoveEvenAscii(List<char> charrlist)
        {
            for (int i = charrlist.Count - 1; i >= 0; i--)
            {
                //stroes the ASCII_VAL
                int asciiVal = (int)charrlist[i];
                if (asciiVal % 2 == 0)
                {
                    charrlist.RemoveAt(i);
                }

            }
        }
        /// <summary>
        /// Converts all characters at even indices in the specified list to uppercase.
        /// </summary>
        /// <remarks>The method modifies the input list in place. The first character in the list is considered to
        /// be at index 0, which is even.</remarks>
        /// <param name="charrlist">The list of characters to modify. Characters at even indices will be converted to their uppercase equivalent.
        /// Cannot be null.</param>
        public static void ToRemoveEvenIndex(List<char> charrlist)
        {
            for (int i = 0; i < charrlist.Count; i++)
            {
                if (i % 2 == 0)
                {
                    charrlist[i] = char.ToUpper(charrlist[i]);
                }
            }
        }
    }
}
