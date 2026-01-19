namespace Programming
{
    /*
        Return the multiplication table row for a number n from 1..upto.
        Example: n=3, upto=5 -> [3,6,9,12,15]

        Input: n (int), upto (int)
        Output: row (int[])

        Constraints:
        0 <= upto <= 1e5
        -1e4 <= n <= 1e4
    */
    public class MultiplicationTable
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Enter number and Upto: ");
            int n_input = int.Parse(Console.ReadLine());
            int upto = int.Parse(Console.ReadLine());

            int[] res = new int[upto];

            for(int i = 1; i <= upto; i++)
            {
                int idx = i - 1;
                res[idx] = n_input * i;
            }


            for(int i = 0 ; i < res.Length; i++)
            {
                System.Console.Write($"{res[i]} ");
            }    
        }
    }
}