public class Program3
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the size of array");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for(int i = 0; i < n; i++){
            arr[i] = int.Parse(Console.ReadLine());
        }
        
        
        int maxElement = int.MinValue;
        foreach(var item in arr){
            if(item >= maxElement) maxElement = item;
        }
        
        Console.WriteLine(maxElement);
        Console.WriteLine(sumOfAllElements(arr));
    }
    
    static int sumOfAllElements(int[] arr){
        int sum = 0;
        foreach(var num in arr){
            sum += num;
        }
        
        return sum;
    }
    
}