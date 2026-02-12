public class Program5
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of Elements");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];
        for(int i = 0; i < n ;i++){
            arr[i] = int.Parse(Console.ReadLine());
        }
        
        Dictionary<int, int> freq = new Dictionary<int, int>();
        
        foreach(int item in arr){
            if(freq.ContainsKey(item)){
                freq[item] += 1;
            }else{
              freq.Add(item, 1);  
            }
            
        }
        
        
        foreach(var item in freq){
            Console.WriteLine($"key: {item.Key} Value: {item.Value}");
        }
    }
}