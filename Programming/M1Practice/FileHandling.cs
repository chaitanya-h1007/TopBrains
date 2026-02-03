namespace M1Practice
{
    public class FileHandling
    {
        public static void Main(string[] args)
        {
            //-> I am creating a file path
            string filePath = @"C:\Users\chait\OneDrive\Documents\TopBrains\Programming\M1Practice\data.txt";
            // Using try statement validating filepath and try to read the content of file
            try{

                //Here Using() -> handels the resource cleanup donot need to close the resource by myself
                //Filestream created with access to Read Only, File Mode- Open(to ensure OS open the file in file path)
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                //streamReader setup to read the stream of data from the filestream
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    //Storing the content in string
                    string line;
                    //while streamReader does not return the null
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            //this helps to handles the file not found exception with the message
            /*
                Example : File Error: Could not find file 'C:\Users\chait\OneDrive\Documents\TopBrains\Programming\M1Practice\data1.txt'.
            */
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File Error: {ex.Message}");
            }
            // IF access fails 
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access Error: {ex.Message}");
            }
            // that will act after all the try statemnt and catch statement executes
            finally
            {
                Console.WriteLine("File operation completed.");
            }
        }
    }
    
}