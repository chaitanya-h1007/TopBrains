using System.Reflection.Metadata;

public class NonGenric
{
    

    public static void Main(string[] args)
    {
        string input = "Name";
        char[] chararr = input.ToCharArray();
        // int i = 0;
        // int j = chararr.Length - 1;
        // while(i < j)
        // {
        //     char temp = chararr[i];
        //     chararr[i] = chararr[j];
        //     chararr[j] = temp;
        //     i++;
        //     j--;
            
        // }

        // string res = "";
        // for(int idx = 0; idx < chararr.Length; idx++)
        // {
        //     res += chararr[idx];
    
        // }
        // System.Console.WriteLine(res);
        // // int freq = 1;
        // SortedDictionary<char, int> freq = new SortedDictionary<char, int>();
        // foreach(var item in chararr)
        // {
        //     if (!freq.ContainsKey(item))
        //     {
        //         freq.Add(item, 1);
        //     }else{
        //         freq[item] += 1;
        //     }
        // }
        

        // foreach(var item in freq)
        // {
        //     System.Console.WriteLine($"{item.Key}  {item.Value}");
        // }


        System.Console.WriteLine(FindtheCount("leetcode", "etco"));
    }                                           

    public static int FindtheCount(string word1, string word2)
    {
        
        char[] a = word1.ToCharArray();
        char[] b = word2.ToCharArray();

        Array.Sort(a);  //{c d e e e l t o}
        
        Array.Sort(b);  //{c e t o}

        int i = 0, j = 0;
        int deletions = 0;

        while (i < a.Length && j < b.Length)
        {
            if (a[i] == b[j])
            {
                i++;
                j++;
            }
            else if (a[i] < b[j])
            {
               
                deletions++;
                i++;
            }
            else
            {
                j++;
            }
        }

        deletions += (a.Length - i);

        return deletions;
    }
}



        
