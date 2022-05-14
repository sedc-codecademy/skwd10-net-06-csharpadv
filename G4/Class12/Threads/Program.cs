using System;

namespace Threads
{
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Threads
             * -------
             * Threads are the smallest unit of work a computer
             * can distribute over a single processor core. It's a low-level
             * concept in any operating system (Windows or Linux based). Threads are
             * fully managed by the processor and operating system of the
             * computer, and we don't have control over the order of execution
             * of threads if our application is multi-threaded. To achieve this
             * control of execution there exist various synchronization methods
             * that can signal when some thread has finished, and also ways to
             * lock access to shared values when some thread is currently accessing
             * them. These are advanced topics not covered by this lecture.
             *
             * The benefits of threads is that we can, if done right, separate our code
             * execution in parts (units of work) and leverage the ability
             * of modern processors to execute code in parallel. But don't just
             * go and use threads - not every code can be parallelized, and doing
             * it with threads is the hardest way to do it right.
             */

            SendMessages();

            SendMessagesWithThreads();

            PrintIntegers(20);

            PrintIntegersWithThreads(20);
        }

        /// <summary>
        /// Method that simulates synchronous messaging.
        /// Note that printed output is always sequential -
        /// the order of the Console.WriteLine invocations
        /// is preserved. Issue with this is that the time that
        /// it will take to execute the method will be the sum
        /// of the times that Thread.Sleep is invoked, which means
        /// no parallelism happens. This can mean that, in modern
        /// computers that are capable of parallel execution, here we are
        /// not leveraging the ability to execute code asynchronously.
        /// </summary>
        public static void SendMessages()
        {
            Console.WriteLine("Getting ready...");
            Thread.Sleep(2000);
            Console.WriteLine("First message received!");
            Thread.Sleep(2000);
            Console.WriteLine("Second message received!");
            Thread.Sleep(2000);
            Console.WriteLine("Third message received!");
            Console.WriteLine("All messages are received!");
        }

        /// <summary>
        /// Method that simulates asynchronous messaging. Each application
        /// (including this one) has its own process, and each process has
        /// at least one thread active, also known as main thread - it's usually
        /// the thread that the UI changes are rendered on as well.
        ///
        /// Since this method uses threads, we can say that it is using some
        /// form of asynchronous execution - we can see this by measuring the
        /// execution time of this method compared to <see cref="SendMessages"/>
        /// method.
        ///
        /// The expected output of this method would usually be having the
        /// messages printed in the main thread (parts of code that do not have
        /// dedicated threads) come up before the messages printed from the threads,
        /// and the order of messages can vary from run to run. This strongly points
        /// to parallel/asynchronous messaging because we don't
        /// control when would each thread get so-called "processor-time" - order
        /// of execution of each thread is strictly controlled by the computer's
        /// processor and operating system, and C# is only allowing this low-level
        /// features to be accessed by programmers.
        ///
        /// Asynchronous programming is extremely difficult in this form and requires
        /// more threading knowledge to be able to make threads behave consistently
        /// over time, but in turn, it gives the most flexibility to the ones that will
        /// master them.
        /// </summary>
        public static void SendMessagesWithThreads()
        {
            Console.WriteLine("Getting ready...");

            Thread thread1 = new Thread(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("First message received!");
            });
            thread1.Start();

            Thread thread2 = new Thread(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Second message received!");
            });
            thread2.Start();

            Thread thread3 = new Thread(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Third message received!");
            });
            thread3.Start();

            Console.WriteLine("All messages are received!");
        }

        /// <summary>
        /// Synchronous implementation of a method that prints integers.
        /// Numbers are printed in the same order they are iterated, and
        /// results are consistent every time we execute this method.
        /// </summary>
        /// <param name="maxValue">The max integer value that will be printed.</param>
        private static void PrintIntegers(int maxValue = 20)
        {
            for (int i = 1; i <= maxValue; i++)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// An asynchronous implementation of <see cref="PrintIntegers"/> method.
        /// Output is not consistent between different executions again, because
        /// threads are managed by the CPU and OS. Note the Thread.Sleep between
        /// each print - this is needed to introduce artificial latency to make
        /// the thread management more obviously "juggle" between the two threads -
        /// otherwise, the print operation of a small number of ints finishes so
        /// fast that we are not able to see the parallelism of the threads.
        /// </summary>
        /// <param name="maxValue">The max integer value that will be printed.</param>
        private static void PrintIntegersWithThreads(int maxValue = 20)
        {
            Thread thread1 = new Thread(() =>
            {
                for (int i = 1; i <= maxValue / 2; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(i);
                }
            });

            Thread thread2 = new Thread(() =>
            {
                for (int i = maxValue / 2 + 1; i <= maxValue; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(i);
                }
            });

            thread1.Start();
            thread2.Start();
        }
    }
}
