using System;

namespace Tasks
{
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Tasks
             * -----
             * Tasks' usage can be very similar to Threads, but they
             * are not the same - while threads are a low-level construct
             * that allows some degree of control over how our code would
             * be distributed over the CPU cores of our computer's processor,
             * a Task is a higher-level concept that is not responsible for
             * distributing execution over the CPU, but rather it's a wrapper
             * over piece of code that will execute in the future - whether
             * that code would be executed asynchronously or not is up to the
             * so-called thread pool that manages these tasks. This simplifies
             * optimization of our code in a way that we don't explicitly
             * manage the threads on OS level but rather we define the work
             * we want done in a task, and C# makes sure that it will be executed
             * as fast as possible - we don't care if that means running the
             * code asynchronously/in parallel or not.
             */

            // define simple task that doesn't return a result after execution
            Task myTask = new Task(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Running after 2000ms");
            });

            // run it
            myTask.Start();

            // define task that calculates sum of numbers and returns it
            // note the generic <int> parameter - that defines what kind
            // of result we expect from this future work
            Task<int> valueTask = new Task<int>(() =>
            {
                int sum = 0;

                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(1000);
                    sum = sum + i;
                }

                return sum;
            });

            valueTask.Start();

            Thread.Sleep(5000);

            Console.WriteLine("Soon we will get the task result");

            Console.WriteLine("Execution of next line in code will print the task result");

            // all of the lines between value.Start and the one below
            // (that asks for the task result) will execute while the
            // task is running - requesting the task result will block
            // execution until the task finishes
            Console.WriteLine($"The sum is: {valueTask.Result}");

            Console.ReadLine();
        }
    }
}
