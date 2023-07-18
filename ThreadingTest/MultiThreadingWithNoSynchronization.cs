/******************************************************************************
 * Author      = Ramaswamy Krishnan-Chittur
 *
 * Product     = ThreadingTest
 *
 * Project     = ThreadingTest
 *
 * Description = Demonstrates the use of multi-threading without synchronization.
 *****************************************************************************/

namespace ThreadingTest
{
    /// <summary>
    /// Demonstrates the use of multi-threading without synchronization.
    /// </summary>
    internal class MultiThreadingWithNoSynchronization
    {
        // This is the shared variable that will be incremented by multiple threads.
        private int _totalWithNoSynchronization = 0;

        /// <summary>
        /// Runs multi-threading without synchronization.
        /// </summary>
        /// <returns>Shared variable after it is manipulated by multiple threads without synchronization</returns>
        public int Run()
        {
            Thread thread1 = new (AddOneMillionWithNoSynchronization);
            Thread thread2 = new (AddOneMillionWithNoSynchronization);
            Thread thread3 = new (AddOneMillionWithNoSynchronization);
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();
            return _totalWithNoSynchronization;
        }

        /// <summary>
        /// Increments the shared variable by one million without synchronization.
        /// </summary>
        private void AddOneMillionWithNoSynchronization()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                _totalWithNoSynchronization++;
            }
        }
    }
}
