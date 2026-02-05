namespace ExceptionHandling{

    public class Account
    {
        public string AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public string AccountType { get; set; }
        public double Balance { get; set; }

        public Account(string no, string holder, string type, double bal)
        {
            AccountNumber = no;
            AccountHolder = holder;
            AccountType = type;
            Balance = bal;
        }
    }

    public class BankManager
    {
        public static List<Account> accounts = new List<Account>();
        static int counter = 1;

        public void CreateAccount(string holder, string type, double initial)
        {
            accounts.Add(new Account("A" + counter++, holder, type, initial));
        }

        public bool Deposit(string accNo, double amount)
        {
            foreach (var a in accounts)
            {
                if (a.AccountNumber == accNo)
                {
                    a.Balance += amount;
                    return true;
                }
            }
            return false;
        }
    }

    public class BankApp
    {
        public static void Main(string[] args)
        {
            BankManager bm = new BankManager();
            bm.CreateAccount("Ravi", "Savings", 5000);
            bm.Deposit("A1", 2000);

            foreach (var a in BankManager.accounts)
                Console.WriteLine(a.AccountHolder + " Balance: " + a.Balance);
        }
    }

    
}