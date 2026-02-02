using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.FileIO;

namespace M1Practice
{
    public class App
{
    public static void Main(string[] args)
    {
        Student stu1 = new Student(101, "chaitanya", 78, 87);
        Student stu2 = new Student(102, "asad", 87, 89);
        Student stu3 = new Student(103, "abhi", 67, 98);
        Student stu4 = new Student(104, "vikas", 65, 78);

        stu1.AddToStudentList(stu1);
        stu2.AddToStudentList(stu2);
        stu3.AddToStudentList(stu3);
        stu4.AddToStudentList(stu4);

        List<Student> rankers = Student.StudentRankersList(Student.StudentList);

        Console.WriteLine("Student Rankers List (Highest Average First):");
        int rank = 1;

        foreach (var student in rankers)
        {
            Console.WriteLine($"Rank: {rank++} ID: {student.StudentID}, Name: {student.StudentName}, Average: {student.MarksAverage}");
            student.SendNotification();  
        }


        Student.ActionDelegate(10,56);
        Student.PredicateExample("Apple");
        Student.FuncExample(15,76);

    }
}

}
    