namespace Programming
{
    public class Program
    {
        public static void Main()
        {
            //This handles the user input and get the range values (n,m)
            System.Console.WriteLine("Enter the range: ");
            int n_input = int.Parse(Console.ReadLine());
            int m_input = int.Parse(Console.ReadLine());

            int Count = 0;
            for(int i = n_input; i <= m_input; i++)
            {
                if (IsMagicalNum(i))
                {
                    Count++;
                }
            }

            System.Console.WriteLine(Count);
        }



        //Meta Data about the method 
        [Obsolete("This checks for a number to be Magic Number Or Not")]
        public static bool IsMagicalNum(int num)
        {
            /*
             As the questionstate that 
             num = 22
             sum = 4
             sum ka product = 4 * 4 = 16

             sumOFDigit(num * num) = 22 * 22 = 484
             sum ofDigit = 16;

             sumOfDigit(num) * sumOfDigit(num) = sumOfDigit(num * num);
            */
            int sumOfDigit = SumOfDigit(num);
            int squareOfNum = num * num;
            int sumOfSquareNum = SumOfDigit(squareOfNum);

            //If num -> prime then No Magical Number
            if (!IsPrime(num))
            {
                if(sumOfDigit * sumOfDigit == sumOfSquareNum)
                {
                    return true;
                }   
            }

            return false;
        }


        public static int SumOfDigit(int num)
        {
            int sum = 0;
            while(num > 0)
            {
                sum += num % 10;
                num = num / 10;  
            }
            return sum;
        }

        //This checks for if number is Prime or not
        public static bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false; // 0 and 1 are not prime numbers by definition
            }
            if (number == 2)
            {
                return true; // 2 is the only even prime number
            }
            if (number % 2 == 0)
            {
                return false; // Other even numbers are not prime
            }

            // Check for divisors up to the square root of the number
            int boundary = (int)Math.Floor(Math.Sqrt(number));

            // Only check odd divisors starting from 3, skipping multiples of 2
            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false; // If a divisor is found, it's not prime
                }
            }

            return true; 
        }
    }
}