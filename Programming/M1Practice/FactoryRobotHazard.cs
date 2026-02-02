namespace M1Practice{
    public class FactoryRobotHazard
    {
    //custom Exception 
        class RobotSafetyException : Exception
        {
            //Constructor for the custom Exception
            public RobotSafetyException(string message) : base(message){}
        }
        /// <summary>
        /// This method helps to calculate the hazard risk and return it in double
        /// </summary>
        /// <param name="armPrecision"></param>
        /// <param name="workerDensity"></param>
        /// <param name="machineryState"></param>
        /// <returns></returns>
        public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
        {
            //define the result
            double hazardRisk = 0;
            // Validate the arm precision
            if (armPrecision < 0.0 || armPrecision > 1.0)
                throw new RobotSafetyException("Error:  Arm precision must be 0.0-1.0");

            // Validate worker density
            if (workerDensity < 1 || workerDensity > 20)
                throw new RobotSafetyException("Error: Worker density must be 1-20");

            // Determine machine risk factor
            var machineRiskFactor = machineryState switch
            {
                "Worn" => 1.3,
                "Faulty" => 2.0,
                "Critical" => 3.0,
                _ => throw new RobotSafetyException("Error: Unsupported machinery state"),
            };

            //calculate the hazard risk
            hazardRisk = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);
            return hazardRisk;
        }
        //Main MEthod
        public static void Main(string[] args)
        {
             try
            {
                Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
                if (!double.TryParse(Console.ReadLine(), out double armPrecision))
                    throw new Exception("Invalid input for arm precision");

                Console.WriteLine("Enter Worker Density (1 - 20):");
                if (!int.TryParse(Console.ReadLine(), out int workerDensity))
                    throw new Exception("Invalid input for worker density");

                Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
                string machineryState = Console.ReadLine();

                FactoryRobotHazard fr = new FactoryRobotHazard();
                double risk = fr.CalculateHazardRisk(armPrecision, workerDensity, machineryState);

                Console.WriteLine($"Robot Hazard Risk Score: {risk:F2}");
            }
            catch (RobotSafetyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Error: " + ex.Message);
            }
            
        }

    }
}