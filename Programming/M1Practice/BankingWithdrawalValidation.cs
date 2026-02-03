namespace M1Practice
{
    
    public class BankAccount
    {

        static void Log(string message)
        {
            Console.WriteLine("[LOG] " + DateTime.Now + " : " + message);
        }
        public static void Main(string[] args)
        {
            int balance = 10000;
            int amount = 0;
            int res = balance;

            try
            {
                Console.WriteLine("Enter withdrawal amount:");

                if (!int.TryParse(Console.ReadLine(), out amount))
                    throw new FormatException("Please enter a valid number.");

                if (amount <= 0)
                    throw new ArgumentException("Withdrawal amount must be greater than zero.");

                if (amount > balance)
                    throw new InvalidOperationException("Insufficient balance.");

                balance -= amount;
                res = balance;

                Console.WriteLine($"Withdrawal successful. Remaining balance: {balance}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Input Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Invalid Amount: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Transaction Failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
            }
            finally
            {
                Log("Transaction Completed");
            }
            

        }
    }
}