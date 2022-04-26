namespace PublishSubscribe
{
    using System;
    using System.Threading;

    /// <summary>
    /// Simple implementation of a subscriber.
    /// </summary>
    public class Subscriber1
    {
        /// <summary>
        /// Method that will be used for subscribing to the <see cref="Publisher.DataProcessedHandler"/>.
        /// Note that the signature defined in <see cref="Publisher.DataProcessedDelegate"/> is the same
        /// as this method, otherwise subscription would not be possible.
        /// </summary>
        /// <param name="message">The message received from the publisher.</param>
        public void GetMessage(string message)
        {
            Console.WriteLine("Subscriber 1 here!");
            Console.WriteLine("YAY I GOT MY MESSAGE!");
            Console.WriteLine($"THE MESSAGE IS: {message}");
        }
    }

    /// <summary>
    /// Simple implementation of a subscriber.
    /// </summary>
    public class Subscriber2
    {
        /// <summary>
        /// Method that will be used for subscribing to the <see cref="Publisher.DataProcessedHandler"/>.
        /// Note that the signature defined in <see cref="Publisher.DataProcessedDelegate"/> is the same
        /// as this method, otherwise subscription would not be possible.
        ///
        /// Note that this handler method "waits" (by using <see cref="Thread.Sleep(int)"/>) before executing
        /// the rest of its body. Look at the console output timings to see what this means.
        /// </summary>
        /// <param name="message">The message received from the publisher.</param>
        public void GetMessage(string message)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Subscriber 2 here!");
            Console.WriteLine("I AM NOT IMPRESSED WITH THE MESSAGE!");
            Console.WriteLine($"THE MESSAGE IS: {message}");
        }
    }
}
