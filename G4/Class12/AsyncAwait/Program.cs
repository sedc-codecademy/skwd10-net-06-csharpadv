using System;

namespace AsyncAwait
{
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            // in this case, invoking this method starts work immediately
            // because it uses Task.Run internally
            Task task = SendMessageAsync("Hey there SEDC students!");

            // execute synchronous method while work is being done
            // this won't wait SendMessageAsync to finish
            ShowAd("potato");

            // query the status of the task - should not be complete
            // because we are waiting for 7 seconds inside the method
            Console.WriteLine($"Task status before task.Wait(): {task.Status}");
            
            // force waiting the task to finish
            task.Wait();

            // status should be updated that the task finished
            Console.WriteLine($"Task status after task.Wait(): {task.Status}");
        }

        /// <summary>
        /// A so-called "async" method that has does not return a result. This means
        /// that it needs to return a Task so it can be awaited from the parent method.
        /// It might be tempting to just return void, but this can cause issues.
        /// </summary>
        /// <param name="message">The message we want to send.</param>
        /// <returns>A Task that is a propagation of the task that is started in the
        /// method.</returns>
        public static async Task SendMessageAsync(string message)
        {
            Console.WriteLine("Sending message...");

            // this block is equivalent to the one below that awaits
            // the task created by the Task.Run static method
            //var task = new Task(() =>
            //{
            //    Thread.Sleep(7000);
            //    Console.WriteLine($"The message {message} has been sent");
            //});

            //task.Start();

            //await task;

            // await will force waiting for the task to finish before exiting
            // method. This keyword is only accessible in async method context
            await Task.Run(() =>
            {
                Thread.Sleep(7000);
                Console.WriteLine($"The message {message} has been sent");
            });
        }

        /// <summary>
        /// Synchronous method that will output some messages while the task returned
        /// by the <see cref="SendMessageAsync"/> is running, to illustrate that
        /// execution will not block until we explicitly invoke Wait() over the task.
        /// </summary>
        /// <param name="product">Product name to be printed in the ad.</param>
        public static void ShowAd(string product)
        {
            Console.WriteLine("While you wait, let us show you an ad:");
            Console.Write("Buy the best product in the world ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(product);
            Console.ResetColor();
            Console.Write(" now and get ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("FREE");
            Console.ResetColor();
            Console.Write(" shipping worldwide!");
            Console.WriteLine();
        }
    }
}
