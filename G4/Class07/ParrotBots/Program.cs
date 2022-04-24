using System;

namespace ParrotBots
{
    using System.Threading;

    /// <summary>
    /// Sample "improvised" implementation variant of publish-subscribe
    /// showing that we are not tied to using separate classes when working with
    /// C# events.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // rude parrot subscribes to be toxic
            MessageSentHandler += RudeParrot;
            // nice parrot subscribes to be pleasant
            MessageSentHandler += NiceParrot;

            // wait for messages indefinitely
            while (true)
            {
                Console.Write("Please enter a message: ");

                var message = Console.ReadLine();

                // send message grabbed from console input
                SendMessage(message);
            }
        }

        /// <summary>
        /// Simple message sent delegate that will define the signature of methods to handle messages being
        /// sent from console's standard (user) input.
        /// </summary>
        /// <param name="message">The message to be sent.</param>
        public delegate void MessageSent(string message);

        /// <summary>
        /// Event that will signal subscribers that a message has been sent.
        /// </summary>
        public static event MessageSent MessageSentHandler;

        /// <summary>
        /// The main method that we will be invoking to "send a message". It waits a bit and checks
        /// whether there are any subscribers - if there are, just trigger the message handlers of
        /// the subscribers.
        /// </summary>
        /// <param name="message">The message to be "sent".</param>
        public static void SendMessage(string message)
        {
            Thread.Sleep(1000);

            if (MessageSentHandler != null)
            {
                MessageSentHandler(message);
            }
        }

        /// <summary>
        /// Implementation of a rude parrot subscriber. It repeats the user message by transforming it
        /// to a "internet-rude" form and adds some rude words at the end.
        /// </summary>
        /// <param name="message">The message the rude parrot has received.</param>
        public static void RudeParrot(string message)
        {
            // set console text color to red
            Console.ForegroundColor = ConsoleColor.Red;
            
            var rudeWordList = new string[] {"Asshole", "Dumbass", "Idiot"};

            Console.WriteLine("Rude parrot is typing...");
            Thread.Sleep(1000);

            var transformedMessage = string.Empty;

            // iterate through all the characters of the sent message
            // change all the characters with an even index to its
            // capitalized form, and change all the characters with
            // an odd index to its lowercase form
            for (int i = 0; i < message.Length; i++)
            {
                var currentChar = message[i];

                if (i % 2 == 0)
                {
                    currentChar = char.ToUpper(currentChar);
                }
                else
                {
                    currentChar = char.ToLower(currentChar);
                }

                transformedMessage += currentChar;
            }

            // print transformed message, and add a random rude word at the end
            Console.WriteLine($"{transformedMessage}; {rudeWordList[new Random().Next(0, rudeWordList.Length - 1)]}!");
        
            // reset console text color
            Console.ResetColor();
        }

        /// <summary>
        /// Implementation of a nice parrot subscriber. Repeats the user message and adds some nice words
        /// at the end as a reply.
        /// </summary>
        /// <param name="message">The user message to be handled by nice parrot.</param>
        public static void NiceParrot(string message)
        {
            // set console text color to green
            Console.ForegroundColor = ConsoleColor.Green;

            var niceWordList = new string[] { "You are lovely", "I like you", "I like your hair" };

            Console.WriteLine("Nice parrot is typing...");
            Thread.Sleep(1000);

            // repeat message and add random nice word at the end
            Console.WriteLine($"{message}; {niceWordList[new Random().Next(0, niceWordList.Length - 1)]}!");

            // reset console text color
            Console.ResetColor();
        }
    }
}
