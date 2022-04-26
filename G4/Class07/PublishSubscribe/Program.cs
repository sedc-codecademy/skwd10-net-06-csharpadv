using System;

namespace PublishSubscribe
{
    using System.Threading;

    class Program
    {
        static void Main(string[] args)
        {
            // define textual message
            string fancyMessage = "This is a very fancy message!";

            // instantiate our publish-subscribe components
            Publisher publisher = new Publisher();
            Subscriber1 subscriber1 = new Subscriber1();
            Subscriber2 subscriber2 = new Subscriber2();

            // subscriber1 subscribes to event with Subscriber1.GetMessage method
            publisher.DataProcessedHandler += subscriber1.GetMessage;
            // subscriber2 subscribes to event with Subscriber2.GetMessage method
            publisher.DataProcessedHandler += subscriber2.GetMessage;
            // we assign an additional subscription through an anonymous method
            publisher.DataProcessedHandler += message => Console.WriteLine($"Special handling of message: {message}");

            // process the data passing the message we defined above
            publisher.ProcessData(fancyMessage);

            // wait between data processing
            Thread.Sleep(3000);

            // subscriber2 UNSUBSCRIBES from event with Subscriber2.GetMessage method
            // note the console output to see what this means
            publisher.DataProcessedHandler -= subscriber2.GetMessage;

            // process data again
            publisher.ProcessData("NOVA PORAKA");
        }
    }
}
