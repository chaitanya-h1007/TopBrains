using System;
using System.Collections.Generic;
using System.Linq;

#region Interfaces

public interface IStudent
{
    int StudentId { get; }
    string Name { get; }
    int Semester { get; }
}

public interface ICourse
{
    string CourseCode { get; }
    string Title { get; }
    int MaxCapacity { get; }
    int Credits { get; }
}

#endregion

#region Enrollment System

public class EnrollmentSystem<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private readonly Dictionary<TCourse, List<TStudent>> _enrollments = new();

    public bool EnrollStudent(TStudent student, TCourse course)
    {
        // Prerequisite check (if LabCourse)
        if (course is LabCourse lab)
        {
            if (student.Semester < lab.RequiredSemester)
                return false;
        }

        if (!_enrollments.ContainsKey(course))
        {
            _enrollments[course] = new List<TStudent>();
        }

        var students = _enrollments[course];

        if (students.Count >= course.MaxCapacity)
            return false;

        if (students.Any(s => s.StudentId == student.StudentId))
            return false;

        students.Add(student);
        return true;
    }

    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
    {
        if (_enrollments.TryGetValue(course, out var students))
            return students.AsReadOnly();

        return new List<TStudent>().AsReadOnly();
    }

    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
    {
        return _enrollments
            .Where(e => e.Value.Any(s => s.StudentId == student.StudentId))
            .Select(e => e.Key);
    }

    public int CalculateStudentWorkload(TStudent student)
    {
        return _enrollments
            .Where(e => e.Value.Any(s => s.StudentId == student.StudentId))
            .Sum(e => e.Key.Credits);
    }
}

#endregion

#region Implementations

public class EngineeringStudent : IStudent
{
    public int StudentId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Semester { get; set; }
    public string Specialization { get; set; } = string.Empty;

    public override bool Equals(object? obj)
        => obj is EngineeringStudent s && s.StudentId == StudentId;

    public override int GetHashCode()
        => StudentId.GetHashCode();
}

public class LabCourse : ICourse
{
    public string CourseCode { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int MaxCapacity { get; set; }
    public int Credits { get; set; }
    public string LabEquipment { get; set; } = string.Empty;
    public int RequiredSemester { get; set; }

    public override bool Equals(object? obj)
        => obj is LabCourse c && c.CourseCode == CourseCode;

    public override int GetHashCode()
        => CourseCode.GetHashCode();
}

#endregion

#region GradeBook

public class GradeBook<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private readonly EnrollmentSystem<TStudent, TCourse> _enrollment;
    private readonly Dictionary<(TStudent, TCourse), double> _grades = new();

    public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollment)
    {
        _enrollment = enrollment;
    }

    public void AddGrade(TStudent student, TCourse course, double grade)
    {
        if (grade < 0 || grade > 100)
            throw new ArgumentException("Grade must be between 0 and 100.");

        var enrolled = _enrollment.GetEnrolledStudents(course);

        if (!enrolled.Any(s => s.StudentId == student.StudentId))
            throw new Exception("Student is not enrolled in this course.");

        _grades[(student, course)] = grade;
    }

    public double? CalculateGPA(TStudent student)
    {
        var studentGrades = _grades
            .Where(g => g.Key.Item1.StudentId == student.StudentId)
            .ToList();

        if (!studentGrades.Any())
            return null;

        double totalPoints = 0;
        int totalCredits = 0;

        foreach (var entry in studentGrades)
        {
            var course = entry.Key.Item2;
            totalPoints += entry.Value * course.Credits;
            totalCredits += course.Credits;
        }

        return totalPoints / totalCredits;
    }

    public (TStudent student, double grade)? GetTopStudent(TCourse course)
    {
        var courseGrades = _grades
            .Where(g => g.Key.Item2.Equals(course))
            .OrderByDescending(g => g.Value)
            .ToList();

        if (!courseGrades.Any())
            return null;

        var top = courseGrades.First();
        return (top.Key.Item1, top.Value);
    }
}

#endregion

#region Program

public class Program
{
    public static void Main()
    {
        var enrollmentSystem = new EnrollmentSystem<EngineeringStudent, LabCourse>();
        var gradeBook = new GradeBook<EngineeringStudent, LabCourse>(enrollmentSystem);

        var student1 = new EngineeringStudent { StudentId = 1, Name = "Alice", Semester = 3, Specialization = "CS" };
        var student2 = new EngineeringStudent { StudentId = 2, Name = "Bob", Semester = 2, Specialization = "Mech" };
        var student3 = new EngineeringStudent { StudentId = 3, Name = "Charlie", Semester = 5, Specialization = "EE" };

        var course1 = new LabCourse
        {
            CourseCode = "CS301",
            Title = "Advanced Programming Lab",
            MaxCapacity = 2,
            Credits = 4,
            RequiredSemester = 3
        };

        var course2 = new LabCourse
        {
            CourseCode = "EE501",
            Title = "Embedded Systems Lab",
            MaxCapacity = 1,
            Credits = 3,
            RequiredSemester = 4
        };

        Console.WriteLine("===== ENROLLMENT =====");
        Console.WriteLine(enrollmentSystem.EnrollStudent(student1, course1)); // true
        Console.WriteLine(enrollmentSystem.EnrollStudent(student2, course1)); // false (semester)
        Console.WriteLine(enrollmentSystem.EnrollStudent(student3, course1)); // true
        Console.WriteLine(enrollmentSystem.EnrollStudent(student2, course1)); // false (capacity)
        Console.WriteLine(enrollmentSystem.EnrollStudent(student3, course2)); // true

        Console.WriteLine("\n===== GRADING =====");
        gradeBook.AddGrade(student1, course1, 85);
        gradeBook.AddGrade(student3, course1, 92);
        gradeBook.AddGrade(student3, course2, 88);

        Console.WriteLine($"GPA Alice: {gradeBook.CalculateGPA(student1)}");
        Console.WriteLine($"GPA Charlie: {gradeBook.CalculateGPA(student3)}");

        var top = gradeBook.GetTopStudent(course1);
        if (top != null)
        {
            Console.WriteLine($"Top Student in {course1.Title}: {top.Value.student.Name} - {top.Value.grade}");
        }
    }
}

#endregion
