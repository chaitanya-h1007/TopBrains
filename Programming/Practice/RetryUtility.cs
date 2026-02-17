using System;
using System.Reflection.Metadata;

public class Program
{
    private static int _tries = 0;                    // Simulation counter

    public static void Main()
    {
        // A function that fails twice, then succeeds
        int result = ExecuteWithRetry(() =>
        {
            _tries++;
            if (_tries <= 10) throw new InvalidOperationException("Temporary failure");
            return 999;
        }, maxAttempts: 11);

        Console.WriteLine(result);                    // Expected: 999
    }

    // ✅ TODO: Students implement only this function
    public static T ExecuteWithRetry<T>(Func<T> work, int maxAttempts)
    {
        // TODO:
        // 1) Validate inputs
        if(work == null) throw new Exception("Work cannot be null");
        if(maxAttempts < 0) throw new Exception("maxAttempts are negative");
        // 2) Try executing work
        // 3) If exception occurs and attempts remain, retry
        Exception? lastException = null;
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                return work(); // 3️⃣ Return immediately if successful
            }
            catch (Exception ex)
            {
                lastException = ex;

                
                Console.WriteLine($"Attempt {attempt} failed: {ex.Message}");

                if (attempt == maxAttempts)
                    throw;
            }
        }
        // 4) If attempts exhausted, throw last exception
        throw lastException;
    }
}