using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace M1Practice
{
    public delegate void MyDelegate(string message);
    public class Student
    {
        
        public static List<Student> StudentList = new List<Student>();

        public int StudentID{get; set;}
        public string StudentName{get; set;}
        public int MathsMarks{get; set;}
        public int ScienceMarks{get; set;}
        public double MarksAverage{get; private set;}

        public static void DisplayPassOrFail(string message){
            System.Console.WriteLine(message);
        }


        public Student(int studentID, string studentName, int mathsMarks, int scienceMarks)
        {
            this.StudentID = studentID;
            this.StudentName = studentName;
            this.MathsMarks = mathsMarks;
            this.ScienceMarks = scienceMarks;
            MarksAverage = 0;
        }


        public void AddToStudentList(List<Student> StudentList,Student student)
        {
            student.MarksAverage = GetAverageMarks(student);
            StudentList.Add(student);

        }

        public double GetAverageMarks(Student student)
        {
            double avgMarks = (student.MathsMarks + student.ScienceMarks) / 2.0;
            return avgMarks;
        }

        

        public static List<Student> StudentRankersList(List<Student> studentList)
        {
            return studentList.OrderByDescending(s => s.MarksAverage).ToList();
        }


    }
}