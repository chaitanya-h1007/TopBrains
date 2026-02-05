namespace ExceptionHandling
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string GradeLevel { get; set; }
        public Dictionary<string, double> Subjects { get; set; }

        public Student(int id, string name, string grade)
        {
            StudentId = id;
            Name = name;
            GradeLevel = grade;
            Subjects = new Dictionary<string, double>();
        }
    }

    public class SchoolManager
    {
        public static List<Student> students = new List<Student>();
        static int counter = 1;

        public void AddStudent(string name, string grade)
        {
            students.Add(new Student(counter++, name, grade));
        }

        public void AddGrade(int id, string subject, double grade)
        {
            foreach (var s in students)
                if (s.StudentId == id)
                    s.Subjects[subject] = grade;
        }

        public double CalculateStudentAverage(int id)
        {
            foreach (var s in students)
            {
                if (s.StudentId == id)
                {
                    double sum = 0;
                    foreach (var g in s.Subjects.Values)
                        sum += g;

                    return sum / s.Subjects.Count;
                }
            }
            return 0;
        }
    }

    public class SchoolApp
    {
        public static void Main(string[] args)
        {
            SchoolManager sm = new SchoolManager();

            sm.AddStudent("Rahul", "10th");
            sm.AddGrade(1, "Math", 90);
            sm.AddGrade(1, "Science", 80);

            Console.WriteLine("Average: " + sm.CalculateStudentAverage(1));
        }
    }

    
}