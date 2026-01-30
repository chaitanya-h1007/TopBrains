using System.ComponentModel.DataAnnotations;

namespace M1Practice
{

    /// <summary>
    /// Utility methods to validate employee entry details.
    /// </summary>
    public class EntryUtility
    {
        /// <summary>
        /// Validate employee id format. Expected prefix: "GOAIR/" followed by 4 digits.
        /// </summary>
        /// <param name="employeeId">Employee identifier string.</param>
        public void validateEmployeeId(string employeeId)

        {
            // log prefix for debugging
            //System.Console.WriteLine(employeeId.Substring(0,6));
            if (employeeId.Substring(0,6) != "GOAIR/")
            {
                throw new InvalidException("Invalid Entry Details");
            }

            // ensure next four characters are digits
            if (!char.IsDigit(employeeId[6]) || !char.IsDigit(employeeId[7]) || !char.IsDigit(employeeId[8]) || !char.IsDigit(employeeId[9]))
            {
                throw new InvalidException("Invalid Entry Details");
            }
        }

        /// <summary>
        /// Validate duration is within allowed range 1..5.
        /// </summary>
        /// <param name="duration">Number of days/hours (domain-specific).</param>
        public void validateDuration(int duration)
        {
            if (duration < 1 || duration > 5)
            {
                throw new InvalidException("Invalid Entry Details");
            }
        }
    }

    /// <summary>
    /// Custom exception thrown for invalid entries.
    /// </summary>
    public class InvalidException : Exception
    {
        public InvalidException(string message) : base(message)
        {
        }
    }
    /// <summary>
    /// Simple user interface to read entries and validate them.
    /// </summary>
    public class UserInterface
    {
        /// <summary>
        /// Reads T entries from console in format "ID:Type:Duration" and validates each.
        /// </summary>
        public static void Main()
        {
            int T;
            System.Console.WriteLine("Enter number of entries");
            T = int.Parse(Console.ReadLine());
            while (T != 0)
            {
                string input = Console.ReadLine();
                string[] employee = input.Split(":");
                string employeeId = employee[0];
                string employeeType = employee[1];
                int duration = int.Parse(employee[2]);

                EntryUtility et = new EntryUtility();
                try
                {
                    // validate id and duration
                    et.validateEmployeeId(employeeId);
                    et.validateDuration(duration);
                    System.Console.WriteLine("Valid Entry");
                }
                catch (InvalidException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

                T--;
            }
        }
    }
}