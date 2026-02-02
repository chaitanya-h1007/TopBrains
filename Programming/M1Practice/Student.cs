using System.Collections.Generic;
using System.Dynamic;
using System.IO.Pipelines;
using System.Linq;
using System.Runtime.CompilerServices;

namespace M1Practice
{
    public delegate void MyDelegate();
    public class Student
    {
        public static List<Student> StudentList = new List<Student>();

        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int MathsMarks { get; set; }
        public int ScienceMarks { get; set; }
        public double MarksAverage { get; private set; }

        public event MyDelegate OnNotify;

        public Student(int studentID, string studentName, int mathsMarks, int scienceMarks)
        {
            StudentID = studentID;
            StudentName = studentName;
            MathsMarks = mathsMarks;
            ScienceMarks = scienceMarks;
        }

        public void AddToStudentList(Student student)
        {
            student.MarksAverage = GetAverageMarks(student);
            StudentList.Add(student);
        }

        private double GetAverageMarks(Student student)
        {
            return (student.MathsMarks + student.ScienceMarks) / 2.0;
        }

        public static List<Student> StudentRankersList(List<Student> studentList)
        {
            return studentList.OrderByDescending(s => s.MarksAverage).ToList();
        }

        public void NeedImprovement()
        {
            Console.WriteLine($"{StudentName}: Need Improvement");
        }

        public void GoodStudent()
        {
            Console.WriteLine($"{StudentName}: You have passed");
        }

        public void SendNotification()
        {
            OnNotify = null; 

            if (MarksAverage >= 80)
                OnNotify += GoodStudent;
            else
                OnNotify += NeedImprovement;

            OnNotify?.Invoke();
        }


        /// Action Predicate Function
        /// 
        /// Action does it can take 1- 2 parameters as input and do not return anything
        public  static void ActionDelegate(int a, int b){
            Action<int, int> action = AddNumber;
            action += SubtractNumber;
            action(a,b);
            
        }
        public static void AddNumber(int num1, int num2){
             System.Console.WriteLine($"Sum : {num1 + num2}");
        }


        public static void SubtractNumber(int num1, int num2){
            System.Console.WriteLine($"Diff : {num2 - num1}");
        }




        public static void PredicateExample(string message){
            Predicate<string> predicate = IsApple;
            bool res = predicate(message);

            if(res){
                System.Console.WriteLine("It's Iphone");
            }
        }

        public static bool IsApple(string input){
            if(input == "Apple")
                return true;

            return false;
        }


        public static void FuncExample(int a, int b){
            Func<int, int, int> add = AddNum;
            
            System.Console.WriteLine(add(a, b));
            
        }

        public static int AddNum(int num1, int num2){
            return num1 + num2;
        }

        public static int subtract(int num1 , int num2){
            return num2 - num1;
        }


    }
}