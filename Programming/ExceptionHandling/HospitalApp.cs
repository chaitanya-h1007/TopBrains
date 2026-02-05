namespace ExceptionHandling
{

    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string BloodGroup { get; set; }

        public Patient(int id, string name, int age, string blood)
        {
            PatientId = id;
            Name = name;
            Age = age;
            BloodGroup = blood;
        }
    }

    public class HospitalManager
    {
        public static List<Patient> patients = new List<Patient>();
        static int counter = 1;

        public void AddPatient(string name, int age, string bloodGroup)
        {
            patients.Add(new Patient(counter++, name, age, bloodGroup));
        }
    }

    public class HospitalApp
    {
        public static void Main(string[] args)
        {
            HospitalManager hm = new HospitalManager();
            hm.AddPatient("Arjun", 30, "O+");
            hm.AddPatient("Ravi", 25, "B+");

            foreach (var p in hm.GetPatients())
                Console.WriteLine(p.Name + " - " + p.BloodGroup);
            }
    }

    
}