public class Employee
{
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


        emp1.Display();
        emp2.Display();
        emp3.Display();

        /*
        1 chaitanya chaitanyaharish080@gmail.com 40000
        2 viaks unknown@company.com 30000
        3 abhi abhi@gmail.com 30000
        
        */
    }
}