using System;
using System.Collections.Generic;
using System.Linq;

#region Interfaces & Enums

public interface IPatient
{
    int PatientId { get; }
    string Name { get; }
    DateTime DateOfBirth { get; }
    BloodType BloodType { get; }
}

public enum BloodType { A, B, AB, O }
public enum Condition { Stable, Critical, Recovering }

#endregion

#region Priority Queue

public class PriorityQueue<T> where T : IPatient
{
    private readonly SortedDictionary<int, Queue<T>> _queues = new();

    public void Enqueue(T patient, int priority)
    {
        if (priority < 1 || priority > 5)
            throw new ArgumentException("Priority must be between 1 and 5.");

        if (!_queues.ContainsKey(priority))
            _queues[priority] = new Queue<T>();

        _queues[priority].Enqueue(patient);
    }

    public T Dequeue()
    {
        foreach (var queue in _queues)
        {
            if (queue.Value.Count > 0)
                return queue.Value.Dequeue();
        }

        throw new InvalidOperationException("Queue is empty.");
    }

    public T Peek()
    {
        foreach (var queue in _queues)
        {
            if (queue.Value.Count > 0)
                return queue.Value.Peek();
        }

        throw new InvalidOperationException("Queue is empty.");
    }

    public int GetCountByPriority(int priority)
    {
        return _queues.ContainsKey(priority)
            ? _queues[priority].Count
            : 0;
    }
}

#endregion

#region Medical Record

public class MedicalRecord<T> where T : IPatient
{
    private readonly T _patient;
    private readonly List<string> _diagnoses = new();
    private readonly Dictionary<DateTime, string> _treatments = new();

    public MedicalRecord(T patient)
    {
        _patient = patient;
    }

    public void AddDiagnosis(string diagnosis, DateTime date)
    {
        _diagnoses.Add($"{diagnosis} (Recorded: {date})");
    }

    public void AddTreatment(string treatment, DateTime date)
    {
        _treatments[date] = treatment;
    }

    public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
    {
        return _treatments.OrderBy(t => t.Key);
    }
}

#endregion

#region Patient Types

public class PediatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; } = "";
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public string GuardianName { get; set; } = "";
    public double Weight { get; set; }
}

public class GeriatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; } = "";
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public List<string> ChronicConditions { get; } = new();
    public int MobilityScore { get; set; }
}

#endregion

#region Medication System

public class MedicationSystem<T> where T : IPatient
{
    private readonly Dictionary<T, List<(string medication, DateTime time)>> _medications = new();

    public void PrescribeMedication(
        T patient,
        string medication,
        Func<T, bool> dosageValidator)
    {
        if (!dosageValidator(patient))
            throw new Exception("Invalid dosage for this patient.");

        if (!_medications.ContainsKey(patient))
            _medications[patient] = new List<(string, DateTime)>();

        _medications[patient].Add((medication, DateTime.Now));
    }

    public bool CheckInteractions(T patient, string newMedication)
    {
        if (!_medications.ContainsKey(patient))
            return false;

        return _medications[patient]
            .Any(m => m.medication.Equals(newMedication, StringComparison.OrdinalIgnoreCase));
    }
}

#endregion

#region Program

public class Program
{
    public static void Main()
    {
        Console.WriteLine("===== HOSPITAL WORKFLOW SIMULATION =====\n");

        var pediatric1 = new PediatricPatient
        {
            PatientId = 1,
            Name = "Tom",
            DateOfBirth = new DateTime(2018, 5, 1),
            BloodType = BloodType.A,
            GuardianName = "Mrs. Smith",
            Weight = 18
        };

        var pediatric2 = new PediatricPatient
        {
            PatientId = 2,
            Name = "Lucy",
            DateOfBirth = new DateTime(2016, 3, 10),
            BloodType = BloodType.O,
            GuardianName = "Mr. Brown",
            Weight = 22
        };

        var geriatric1 = new GeriatricPatient
        {
            PatientId = 3,
            Name = "Mr. Johnson",
            DateOfBirth = new DateTime(1945, 7, 20),
            BloodType = BloodType.B,
            MobilityScore = 4
        };

        var geriatric2 = new GeriatricPatient
        {
            PatientId = 4,
            Name = "Mrs. Davis",
            DateOfBirth = new DateTime(1938, 11, 2),
            BloodType = BloodType.AB,
            MobilityScore = 6
        };

        var queue = new PriorityQueue<IPatient>();

        queue.Enqueue(pediatric1, 3);
        queue.Enqueue(geriatric1, 1);
        queue.Enqueue(pediatric2, 4);
        queue.Enqueue(geriatric2, 2);

        var record1 = new MedicalRecord<PediatricPatient>(pediatric1);
        record1.AddDiagnosis("Flu", DateTime.Now);
        record1.AddTreatment("Paracetamol", DateTime.Now);

        var pediatricMedSystem = new MedicationSystem<PediatricPatient>();
        pediatricMedSystem.PrescribeMedication(pediatric1, "Children Syrup", p => p.Weight > 10);

        Console.WriteLine("\nProcessing patients by priority:\n");

        while (true)
        {
            try
            {
                var next = queue.Dequeue();
                Console.WriteLine($"Processing: {next.Name}");
            }
            catch
            {
                break;
            }
        }

        Console.WriteLine("\nTreatment History:");
        foreach (var t in record1.GetTreatmentHistory())
            Console.WriteLine($"{t.Key} - {t.Value}");

        Console.WriteLine("\n===== SIMULATION COMPLETE =====");
    }
}

#endregion
