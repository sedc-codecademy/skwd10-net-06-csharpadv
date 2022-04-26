namespace PublishSubscribe
{
    using System;
    using System.Threading;

    /// <summary>
    /// Publisher implementation. In a publish-subscribe based system,
    /// publishers, or producers, are the sources of signals that something
    /// happened in the system, most often in the form of a notification message.
    /// When a message is produced after a certain event, it notifies all
    /// the subscribers about this, and subscribers can choose what they
    /// will do with that information.
    ///
    /// In this case, our publisher is some feature or component in the system
    /// that does some long-running work. The intention with this implementation
    /// is to signal the subscribers that the long-running process has completed
    /// so the subscribers can react.
    /// </summary>
    public class Publisher
    {
        /// <summary>
        /// To define the publisher logic, we need to define an <c>event</c> for
        /// when the processing is finished.
        /// To use the <c>event</c> keyword, first we need to define the type
        /// of delegate (i.e. the signature of methods) that will be able to handle
        /// our notification messages. This in our case will be the <see cref="Publisher.DataProcessedHandler"/>,
        /// signalling that the data processing in the producer has completed. 
        /// </summary>
        /// <param name="message">The message that will be handled by subscribers after data processing is complete.
        /// This forces all subscribers to subscribe with methods with this exact signature.</param>
        public delegate void DataProcessedDelegate(string message);

        /// <summary>
        /// An event that takes subscriptions of methods with signature defined
        /// <see cref="DataProcessedDelegate"/>. This will be invoked after data
        /// processing is complete in the <see cref="WhenDataIsProcessed"/> method.
        /// </summary>
        public event DataProcessedDelegate DataProcessedHandler;

        /// <summary>
        /// The main method that will simulate long-running data processing, and
        /// after that's complete, will fire the <see cref="DataProcessedHandler"/>
        /// to notify the subscribers.
        /// </summary>
        /// <param name="message">The message that the event/handler will be invoked with after data processing is complete.</param>
        public void ProcessData(string message)
        {
            Console.WriteLine("Processing data...");
            Thread.Sleep(3000);
            WhenDataIsProcessed(message);
        }

        /// <summary>
        /// Helper method that checks if there are any subscribers before invoking/firing the event.
        /// (<see cref="DataProcessedHandler"/> == <c>null</c> only if there are no subscribers at the
        /// moment of checking => it will be fired ONLY if there's at least one subscribers, i.e.
        /// <see cref="DataProcessedHandler"/> != null). Wrapping this in a separate method is optional.
        /// </summary>
        /// <param name="message">The message that will be sent to the subscribers.</param>
        protected void WhenDataIsProcessed(string message)
        {
            if (DataProcessedHandler != null)
            {
                DataProcessedHandler(message);
            }
        }
    }
}
