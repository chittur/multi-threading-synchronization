/******************************************************************************
 * Author      = Ramaswamy Krishnan-Chittur
 *
 * Product     = ThreadingTest
 *
 * Project     = ThreadingTest
 *
 * Description = The main program.
 *****************************************************************************/

namespace ThreadingTest
{
    /// <summary>
    /// The main program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main entry point.
        /// </summary>
        public static void Main()
        {
            int totalWithNoSync = new MultiThreadingWithNoSynchronization().Run();
            int totalWithSync = new MultiThreadingWithSynchronization().Run();

            Console.WriteLine($"Total with no synchronization = {totalWithNoSync}.");
            Console.WriteLine($"Total with synchronization = {totalWithSync}.");
        }
    }
}