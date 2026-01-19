public class SwapTwoNum
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the two Numbers{num1,num2}");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());

        SwapUsingRef(ref num1, ref num2);
        System.Console.WriteLine($"After Swap Using Ref num1 : {num1} and  num2 : {num2}");
        SwapUsingOut(num1, num2, out num1, out num2);
        System.Console.WriteLine($"After Swap Using Out num1 : {num1} and  num2 : {num2}");

    }

    // ref update the changes made in the function to the intialised variable
    public static void SwapUsingRef(ref int num1, ref int num2)
    {
        num1 =  num1 + num2;
        num2 = num1 - num2;
        num1 = num1 - num2;
    }

    // As Out do not allow to change the values with out keyword so,
    // We can use the this approach to swap nums.
    public static void SwapUsingOut(int a,int b, out int num1, out int num2)
    {
        
        num1 = b;
        num2 = a;

    }
}