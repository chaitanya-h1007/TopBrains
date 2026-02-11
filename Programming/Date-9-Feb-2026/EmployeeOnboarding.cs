using System.Runtime.InteropServices;

public class Employee
{
    public static List<Employee> emp = new List<Employee>();
    public int Id{get; set;}
    public string Name {get; set;}
    public string Email{get; set;}
    public int Salary{get; set;}

    public Employee(int id, string name, string email, int salary)
    {

        this.Id = id;
        this.Name = name;
        if(salary <= 0)
        {
            this.Salary = 30000;
        }
        else
        {
            this.Salary = salary;
        }

        if (!email.Contains('@'))
        {
            this.Email = "unknown@company.com";
        }
        else
        {
            this.Email = email;
        }
        
    }


    public void Display()
    {
        System.Console.WriteLine($"{Id} {Name} {Email} {Salary}");
    }


    public static void Main(string[] args)
    {
        Employee emp1 = new Employee(1,"chaitanya","chaitanyaharish080@gmail.com", 40000);
        Employee emp2 = new Employee(2, "viaks", "vikasgmail", 0);
        Employee emp3 = new Employee(3, "abhi", "abhi@gmail.com", -1133);


        // emp1.Display();
        // emp2.Display();
        // emp3.Display();

        /*
        1 chaitanya chaitanyaharish080@gmail.com 40000
        2 viaks unknown@company.com 30000
        3 abhi abhi@gmail.com 30000
        
        */



        Type type = typeof(Employee); //Compile Type
        Type runtimeType = emp1.GetType();
        System.Console.WriteLine(type);
        System.Console.WriteLine(runtimeType);
        System.Console.WriteLine(type.Name == runtimeType.Name);

        //All the methods including the public
        var methods = type.GetMethods();
        foreach (var item in methods)
        {
            System.Console.WriteLine(item);
        }

        var properties = type.GetProperties();
        System.Console.WriteLine("Properties \n");
        foreach (var item in properties)
        {
            System.Console.WriteLine(item);
        }
        System.Console.WriteLine("---------");
        foreach(var item in type.GetField("static",))
        {
            System.Console.WriteLine(item);
        }

        

       
    }
}