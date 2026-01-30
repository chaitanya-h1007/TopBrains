using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace M1Practice
{
    public class App
    {
        public static void Main(string[] args)
        {
            List<Student> stuList = new List<Student>();
            Student stu1 = new Student(101, "chaitanya", 78, 87);
            Student stu2 = new Student(102, "asad", 87, 89);
            Student stu3 = new Student(103, "abhi", 67, 98);
            Student stu4 = new Student(104, "vikas", 65, 78);

            stu1.AddToStudentList(stuList, stu1);
            stu2.AddToStudentList(stuList, stu2);
            stu3.AddToStudentList(stuList, stu3);
            stu4.AddToStudentList(stuList, stu4);

            List<Student> rankers = Student.StudentRankersList(stuList);
            MyDelegate del = Student.DisplayPassOrFail;

            Console.WriteLine("Student Rankers List (Highest Average First):");
            int rank = 1;
            foreach (var student in rankers)
            {
                
                Console.WriteLine($"Rank: {rank++} ID: {student.StudentID}, Name: {student.StudentName}, Average: {student.MarksAverage}");
                if (student.MarksAverage >= 80)
                {
                    del("Congratulations! You Passed");
                }
                else
                {
                    del("You need to work Hard Next Time");
                }
                
            }
        }
    }
}
