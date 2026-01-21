using System.ComponentModel;

public class ArthemeticExpression
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine("Enter the expression as {A operation B} where A,B is numbers and operations as (/ * + -)");
        // "3 * 5"
        string Expression = Console.ReadLine();
        string[] parts = Expression.Split(' ');

        int num1 = int.Parse(parts[0]); // 3
        int num2 = int.Parse(parts[2]); // 5

        string operation = parts[1]; // *


        switch (operation)
        {
            case "+":
                AddNum(num1, num2);
                break;
            case "*":
                MultiplyNum(num1, num2);
                break;
            case "/":
                DivideNum(num1, num2);
                break;
            case "-":
                DiffereceOfNum(num1, num2);
                break;                
        }
    }

}