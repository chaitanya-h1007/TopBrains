namespace Programming.M1Practice
{
    /// <summary>
    /// Container class for gadget validation utilities.
    /// </summary>
    public class ShopValidator
    {
        /// <summary>
        /// Utility methods to validate gadget ID and warranty period.
        /// </summary>
        public class GadgetValidatorUtil
        {
            /// <summary>
            /// Validate gadget ID format. Expected: uppercase letter followed by 3 digits.
            /// </summary>
            /// <param name="gadgetId">The gadget identifier string.</param>
            /// <returns>True if valid.</returns>
            public bool validateGadgetID(string gadgetId)
            {
                // ensure first character is uppercase
                bool isUpper = gadgetId.Take(1).All(char.IsUpper);
                if (!isUpper)
                {
                    throw new InvalidGadgetException("First Letter must be capital");
                }

                // ensure next three characters are digits
                if (!char.IsDigit(gadgetId[1]) || !char.IsDigit(gadgetId[2]) || !char.IsDigit(gadgetId[3]))
                {
                    throw new InvalidGadgetException("Last three must be digits [0-9]");
                }

                return true;
            }

            /// <summary>
            /// Validate warranty period is within allowed range (6..36 months exclusive boundaries).
            /// </summary>
            /// <param name="period">Warranty period in months.</param>
            /// <returns>True if valid.</returns>
            public bool validateWarrantyPeriod(int period)
            {
                if (period < 6 || period > 36)
                {
                    throw new InvalidGadgetException("Period must be between 6 - 36 months {Exclusive}");
                }

                return true;
            }
        }


        /// <summary>
        /// Custom exception for gadget validation errors.
        /// </summary>
        public class InvalidGadgetException : Exception
        {
            public InvalidGadgetException(string message) : base(message) { }
        }

        /// <summary>
        /// Program entry: read gadget entries and validate each one.
        /// Format: "GadgetID:Name:Period"
        /// </summary>
        public static void Main(string[] args)
        {
            int TestCase;
            System.Console.WriteLine("Enter number of entries");
            TestCase = int.Parse(Console.ReadLine());
            while (TestCase > 0)
            {
                string input = Console.ReadLine();
                string[] Gadget = input.Split(":");
                string GadgetId = Gadget[0];
                string GadgetName = Gadget[1];
                int Period = int.Parse(Gadget[2]);

                GadgetValidatorUtil gt = new GadgetValidatorUtil();
                try
                {
                    // validate gadget id and warranty period
                    gt.validateGadgetID(GadgetId);
                    gt.validateWarrantyPeriod(Period);
                    System.Console.WriteLine("Warranty Accepted, stock Updated");
                }
                catch (InvalidGadgetException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }

                TestCase--;
            }
        }
    }
}