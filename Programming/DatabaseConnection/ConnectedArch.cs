using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class ConnectedArch
{
    static void Main(string[] args)
    {
        // Delegate to the LINQ helper to load and print employees
        LinqWithSQL.Run();

    }
}