using System;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
class Program
{
    static async Task Main()
    {
        string result = await FetchRecordFromJson();
        System.Console.WriteLine(result);

        string  googleRes = await FetchRecordFromGoogle();
        System.Console.WriteLine(googleRes);
    }


    public static async Task<String> FetchRecordFromJson()
    {

        HttpClient httpClient = new HttpClient();
        HttpResponseMessage responseMessage = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
        System.Console.WriteLine(responseMessage.EnsureSuccessStatusCode());
        
        return await responseMessage.Content.ReadAsStringAsync();
        
    }


    public static async Task<String> FetchRecordFromGoogle()
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage responseMessage = await httpClient.GetAsync("https://ums.lpu.in/");
        responseMessage.EnsureSuccessStatusCode();
        return await responseMessage.Content.ReadAsStringAsync();
    }
    
}