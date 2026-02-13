using System;
public class UserInterface
{
    public enum AccountType{
        Basic,
        Premium,
        Buisness
    }
    
    public class InvalidWalletDataException : Exception{
        public InvalidWalletDataException(string message) : base(message){
            
        }
    }
    
    
    public class TransactionRepository<T>{
        public static List<T> TransactionStorage = new List<T>();
        public void AddTransaction(T transaction){
            TransactionStorage.Add(transaction);
        }
        public void ReturnTransaction(){
            foreach(var item in TransactionStorage){
                Console.WriteLine(item);
            }
        }
        
        
        public int CountTransaction(){
            int count = TransactionStorage.Count();
            return count;
        }
    }
    
    public class FraudRiskProcessor{
        public bool ValidateUserDetails(string name, string email, AccountType type,int mobile,double income, double totalamt, int failedCount, List<string> desc){
            
            if(string.IsNullOrEmpty(name))
                throw new InvalidWalletDataException("Invalid name");

            foreach(char c in name)
            {
                if(!char.IsLetter(c) && c != ' ')
                    throw new InvalidWalletDataException("Invalid name");
            }

            if(!Enum.IsDefined(typeof(AccountType), type))
                throw new InvalidWalletDataException("Invalid account type");

            if(!email.Contains("@") || !email.EndsWith(".com")){
                throw new InvalidWalletDataException("email exception");
                
            }
            if(income < 15000) throw new InvalidWalletDataException("Invalid Income");
            if(totalamt < 0) throw  new InvalidWalletDataException("Invalid Total amount");
            if(failedCount < 0) throw new InvalidWalletDataException("Invalid Failed transaction Count");
            if(desc.Count() != 5 || Counttheocc(desc)) throw new InvalidWalletDataException("Invalid Description");
            
            return true;
        }
        public bool Counttheocc(List<string> desc)
        {
            foreach(string item in desc)
            {
                if(item.Length < 5 || string.IsNullOrEmpty(item))
                {
                    throw new InvalidWalletDataException("Invalid Description");

                }
            }

            return true;
        }
        public int CalculateTransactionLimit(double income, double totalamt, AccountType type, int failed){
            double ratio = failed / 10.0;
            
            if(ratio > 0.5 || totalamt > (income * 2)){
                return 20000;
            }else if(ratio < 0.2 && (type == AccountType.Premium || type == AccountType.Buisness)){
                return 100000;
            }else{
                return 50000;
            }
        }
    }
    public static void Main(string[] args)
    {
        try
        {
            string userName = Console.ReadLine();
            string? email = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            //mapping the enum to the input
            AccountType accountType = Enum.Parse<AccountType>(Console.ReadLine());
            double income = double.Parse(Console.ReadLine());
            double totalamt = double.Parse(Console.ReadLine());
            int failedTransaction = int.Parse(Console.ReadLine());
            List<string> lastTransaction = new List<String>();
            for(int i = 0; i < 5; i++){
                lastTransaction.Add(Console.ReadLine());
            }
            FraudRiskProcessor fr = new FraudRiskProcessor();
            fr.ValidateUserDetails(userName, email, accountType,number, income,totalamt, failedTransaction,lastTransaction);
           Console.WriteLine(fr.CalculateTransactionLimit(income, totalamt, accountType,failedTransaction));
            
        }
        catch(InvalidWalletDataException ex){
            Console.WriteLine(ex.Message);
        }
    }
}