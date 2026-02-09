using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;
using System.Dynamic;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ExceptionHandling.TaskApp
{

    public class Task
    {
        public int TaskId{get; set;}
        public string Title{get; set;}
        public string Description{get; set;}
        public string Priority{get; set;}
        public string Status{get; set;}
        public DateTime DueDate{get; set;}
        public string AssignedTo{get; set;}
        
    }


    public class Project
    {
        public int ProjectId{get; set;}
        public string ProjectName{get; set;}
        public StringInfo ProjectManager{get; set;}
        public DateTime StartDate{get; set;}
        public DateTime EndDate{get; set;}
        public static List<Task> Tasks = new List<Task>();

    }


    public class TaskManager
    {
        
    }

    public class Project
    {
        
    }

    public class TaskApp
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Task App ");
        }
    }
    
}