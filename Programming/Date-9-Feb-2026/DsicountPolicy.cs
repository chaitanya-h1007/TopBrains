using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Xml;


public abstract class DiscountPolicy
{
    public abstract double GetFinalAmount(double amount);
}

// FestivalDiscount: 10% off if amount >= 5000 else 5%
public class FestivalDiscount : DiscountPolicy
{
    public override double GetFinalAmount(double amount)
    {
        if (amount >= 5000)
        {
            return amount * 0.90; // 10% off
        }
        else
        {
            return amount * 0.95; // 5% off
        }
    }
}

// MemberDiscount: flat 300 off if amount >= 2000 else no discount
public class MemberDiscount : DiscountPolicy
{
    public override double GetFinalAmount(double amount)
    {
        if (amount >= 2000)
        {
            return amount - 300; // Flat 300 off
        }
        else
        {
            return amount; // No discount
        }
    }
}

public class DiscountPolicyApp
{
    public static void Main()
    {
        Console.WriteLine("=== E-Commerce Discount Policy ===\n");

        // Get amount from user
        Console.Write("Enter the amount: ");
        if (!double.TryParse(Console.ReadLine(), out double amount))
        {
            Console.WriteLine("Invalid amount entered.");
            return;
        }

        // Display discount options
        Console.WriteLine("\nSelect Discount Policy:");
        Console.WriteLine("1. Festival Discount (10% off if amount >= 5000, else 5%)");
        Console.WriteLine("2. Member Discount (Flat 300 off if amount >= 2000, else no discount)");
        Console.Write("\nEnter your choice (1 or 2): ");

        string choice = Console.ReadLine();

        DiscountPolicy policy = null;

        if (choice == "1")
        {
            policy = new FestivalDiscount();
            Console.WriteLine("\nApplying Festival Discount...");
        }
        else if (choice == "2")
        {
            policy = new MemberDiscount();
            Console.WriteLine("\nApplying Member Discount...");
        }
        else
        {
            Console.WriteLine("Invalid choice entered.");
            return;
        }

        double finalAmount = policy.GetFinalAmount(amount);

        Console.WriteLine($"Original Amount: {amount:F2}");
        Console.WriteLine($"Final Payable Amount: {finalAmount:F2}");
        Console.WriteLine($"Discount Applied: {(amount - finalAmount):F2}");



        
    }
}