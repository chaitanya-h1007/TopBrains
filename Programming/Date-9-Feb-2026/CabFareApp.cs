using System.Diagnostics.Tracing;
using System.Security.Cryptography;

public class Cab
{
    public virtual void CalculateFee(int distanceInKM)
    {
        
    }
}


public class Mini : Cab
{
    public override void CalculateFee(int distanceInKM)
    {
        double fare = distanceInKM * 12;
        System.Console.WriteLine($"Fare For Mini for {distanceInKM} = {fare}");
    }
}

public class Sedan : Cab
{
    public override void CalculateFee(int distanceInKM)
    {
        double fare =  distanceInKM * 15 + 50;
        System.Console.WriteLine($"Fare For Sedan for {distanceInKM} = {fare}");
    }
}


public class SUV : Cab
{
    public override void CalculateFee(int distanceInKM)
    {
        double fare = distanceInKM * 18 + 100;
        System.Console.WriteLine($"Fare For SUV = {fare}");
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine("Select Cab Type:");
        System.Console.WriteLine("1. Mini");
        System.Console.WriteLine("2. Sedan");
        System.Console.WriteLine("3. SUV");
        System.Console.Write("Enter your choice (1/2/3): ");
        string choice = System.Console.ReadLine();

        System.Console.Write("Enter distance in KM: ");
        int km = int.Parse(System.Console.ReadLine());

        Cab cab = null;

        // Runtime Polymorphism - Creating appropriate cab object based on user choice
        switch (choice)
        {
            case "1":
                cab = new Mini();
                break;
            case "2":
                cab = new Sedan();
                break;
            case "3":
                cab = new SUV();
                break;
            default:
                System.Console.WriteLine("Invalid choice!");
                return;
        }

        // Call overridden method using base class reference
        cab.CalculateFee(km);
    }
}