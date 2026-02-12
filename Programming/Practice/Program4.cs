public class Program4
{
    // Online C# Editor for free
    public static void Main(string[] args)
    {
        
        List<int> list = new List<int>();
        list.Add(3);
        list.Add(4);
        list.Add(5);
        list.Add(8);
        list.Add(5);
        
        
        HashSet<int> set = new HashSet<int>();
        for(int i = 0 ; i < list.Count; i++){
            if(set.Contains(list[i])){
                list.RemoveAt(i);
            }
            else{
                set.Add(list[i]);
            }
        }
        
        
        foreach(var item in list){
            Console.WriteLine(item);
        }
    }
}
