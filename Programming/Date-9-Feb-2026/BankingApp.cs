using System.Net.WebSockets;
using System.Runtime.CompilerServices;

public class BankAccount
{
    public int BankId{get; set;}
    public double Balance{get; private set;}

    public BankAccount(int BankId)
    {
        this.BankId = BankId;
        //if not initialised 
        this.Balance = 5000;
        
    }

    public void setBalance(double balance)
    {
        this.Balance = balance;
    }


    public void Deposit(double amount)
    {
        if(amount > 0)
        {
            Balance += amount;
        }
        else
        {
            throw new InvalidOperationException("Amount cannot be negaticve");
        }
    } 
    public void Withdraw(double amount)
    {
        if(Balance >= amount)
        {
            Balance -= amount;
        }
        else
        {
            throw new InvalidOperationException("Insufficent Balance");
        }
    }


    public static void Main(string[] args)
    {
        BankAccount b1 = new BankAccount(1);
        System.Console.WriteLine(b1.Balance);
        b1.Deposit(4000);
        System.Console.WriteLine(b1.Balance);
        b1.Withdraw(3000);

        System.Console.WriteLine(b1.Balance);
    }
    
}