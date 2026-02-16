using System;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;

public class LinqWithSQL
{
    // Renamed from Main to Run to avoid multiple entry points in the project.
    public static void Run()
    {
        var connectionString = "Data Source=BOT;Initial Catalog=test_db;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True";
        string selectQuery = "SELECT * FROM Employee;";
        DataTable employee = new DataTable();

        using (var connection = new SqlConnection(connectionString))
        using (var command = new SqlCommand(selectQuery, connection))
        using (var adapter = new SqlDataAdapter(command))
        {
            connection.Open();
            adapter.Fill(employee);
            connection.Close();

        }


        var rows = employee.AsEnumerable();

        var employees = rows
            .Where(r => r.Field<string>("Department") == "HR" & r.Field<decimal>("Salary") >= 50000)
            .GroupBy()
            .Select(r => new Employee
            {
                EmployeeID = r.Field<int>("EmployeeID"),
                FirstName = r.Field<string>("FirstName"),
                LastName = r.Field<string>("LastName"),
                Email = r.Field<string>("Email"),
                Department = r.Field<string>("Department"),
                Salary = r.Field<decimal>("Salary"),
                HireDate = r.Field<DateTime>("HireDate")
            })
            .ToList();

        Console.WriteLine("Rows loaded: " + employees.Count);
        employees.ForEach(e => Console.WriteLine($"{e.EmployeeID} | {e.FirstName} | {e.LastName} | {e.Email} | {e.Department} | {e.Salary:0.00} | {e.HireDate:dd-MM-yyyy}"));
    }
}

public class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
    public DateTime HireDate { get; set; }
}