using System.CodeDom.Compiler;
using System.Collections;
using Microsoft.VisualBasic;

public class Program
{
    
    public static void Main(string[] args)
    {
        //Generic Types
        List<int> list = new List<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);
        //Non-Generic Type
        ArrayList arrayList = new ArrayList(); //No need to define the data type in list areation
        arrayList.Add(10);
        arrayList.Add(30);
        arrayList.Add("hello"); // we can add string value to this without any error.
        foreach (var item in arrayList)
        {
            System.Console.WriteLine(item);
            /*
                Output
                10
                30
                hello
            */
        }
    }
}