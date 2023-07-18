/******************************************************************************
 * Author      = Ramaswamy Krishnan-Chittur
 *
 * Product     = ThreadingTest
 *
 * Project     = ThreadingTest
 *
 * Description = Demonstrates the use of multi-threading with synchronization.
 *****************************************************************************/

namespace ThreadingTest
{
    /// <summary>
    /// Demonstrates the use of multi-threading with synchronization.
    /// </summary>
    internal class MultiThreadingWithSynchronization
    {
        // This is the object that will be used to synchronize access to the shared variable.
        private readonly object syncLock = new ();

        // This is the shared variable that will be incremented by multiple threads.
        private int _totalWithSynchronization = 0;

        /// <summary>
        /// Runs multi-threading with synchronization.
        /// </summary>
        /// <returns>Shared variable after it is manipulated by multiple threads with synchronization</returns>
        public int Run()
        {
            Thread thread1 = new (AddOneMillionWithSynchronization);
            Thread thread2 = new (AddOneMillionWithSynchronization);
            Thread thread3 = new (AddOneMillionWithSynchronization);
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();

            int total;
            lock (syncLock)
            {
                total = _totalWithSynchronization;
            }

            return total;
        }

        /// <summary>
        /// Increments the shared variable by one million with synchronization.
        /// </summary>
        private void AddOneMillionWithSynchronization()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                // Synchronize access to the shared variable.
                // Note: You could use Interlocked.Increment for incrementing the shared integer variable.
                //       See https://learn.microsoft.com/en-us/dotnet/api/system.threading.interlocked.increment?view=net-7.0
                //       However lock is more a generic solution.
                lock (syncLock)
                {
                    _totalWithSynchronization++;
                }
            }
        }
    }
}
