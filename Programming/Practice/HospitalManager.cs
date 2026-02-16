public class Patient
  {
      // TODO: Add properties with get/set accessors
      // TODO: Add constructor
      public int Id{get;set;}
      public string Name{get; set;}
      public int Age{get; set;}
      public string Condition{get;set;}
      
      
      public Patient(int id, string name, int age, string condition){
        this.Id = id;
        this.Name = name;
        this.Age = age;
        this.Condition = condition;
      }
  }
  
  // Task 2: Implement HospitalManager class
  public class HospitalManager
  {
      private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
      private Queue<Patient> _appointmentQueue = new Queue<Patient>();
      
      // Add a new patient to the system
      public void RegisterPatient(int id, string name, int age, string condition)
      {
          // TODO: Create patient and add to dictionary
          Patient newPatient = new Patient(id, name, age, condition);
          _patients.Add(newPatient.Id, newPatient);
          
      }
      
      // Add patient to appointment queue
      public void ScheduleAppointment(int patientId)
      {
          // TODO: Find patient and add to queue
          
          foreach(var item in _patients){
            if(item.Key == patientId){
              _appointmentQueue.Enqueue(item.Value);
            }
          }
      }
      
      // Process next appointment (remove from queue)
      public Patient ProcessNextAppointment()
      {
          // TODO: Return and remove next patient from queue
          return _appointmentQueue.Dequeue();
      }
      
      // Find patients with specific condition using LINQ
      public List<Patient> FindPatientsByCondition(string condition)
      {
          // TODO: Use LINQ to filter patients
          List<Patient> list = new List<Patient>();
        
          var filtered = _patients.Values
            .Where(p => p.Condition == condition);
          
          return filtered.ToList();
      }
      
      
      public static void Main(string[] args){
          HospitalManager manager = new HospitalManager();
          manager.RegisterPatient(1, "John Doe", 45, "Hypertension");
          manager.RegisterPatient(2, "Jane Smith", 32, "Diabetes");
          manager.ScheduleAppointment(1);
          manager.ScheduleAppointment(2);
          
          var nextPatient = manager.ProcessNextAppointment();
          Console.WriteLine(nextPatient.Name); // Should output: John Doe
          
          var diabeticPatients = manager.FindPatientsByCondition("Diabetes");
          Console.WriteLine(diabeticPatients.Count); 

      }
  }