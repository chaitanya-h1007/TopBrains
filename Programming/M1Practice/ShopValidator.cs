namespace Programming.M1Practice
{
    public class ShopValidator
    {
        public class GadgetValidatorUtil
        {
            public bool validateGadgetID(string gadgetId)
            {
                bool isUpper = gadgetId.Take(1).All(char.IsUpper);
                if(!isUpper)
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

            public bool validateWarrantyPeriod(int period)
            {
                if(period < 6 || period > 36)
                {
                    throw new InvalidGadgetException("Period must be between 6 - 36 months {Exclusive}");
                }
                return true;
            }
        }


        public class InvalidGadgetException : Exception
        {
            public InvalidGadgetException(string message) : base(message){}
        }

        public static void Main(string[] args)
        {
            int TestCase;
            System.Console.WriteLine("Enter number of entries");
            TestCase = int.Parse(Console.ReadLine());
            while(TestCase > 0)
            {
                string input = Console.ReadLine();
                string[] Gadget = input.Split(":");
                string GadgetId = Gadget[0];
                string GadgetName = Gadget[1];
                int Period = int.Parse(Gadget[2]);
                GadgetValidatorUtil gt = new GadgetValidatorUtil();
                try
                {
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