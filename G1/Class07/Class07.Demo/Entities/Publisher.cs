namespace Class07.Demo.Entities
{
    public class Publisher
    {
        public delegate void DataProcessingDelegate(string message);
        public delegate void DataProcessingIntDelegate(int message);
        public event DataProcessingDelegate DataProcessingHandler;
        public event DataProcessingIntDelegate DataProcessingIntHandler;

        public void ProcessData(string message) // business logic
        {
            Console.WriteLine("Processing data...");
            Thread.Sleep(3000); // zavrsuva rabota! mnogu e tesko! 3 sekundi!
            WhenDataIsProcessed(message);
        }

        public void ProcessInt(int number)
        {
            WhenDataIsProcessed(number);
        }

        // It notifies all subscribers of the message that is processed from the ProcessData method
        protected void WhenDataIsProcessed(string message)
        {
            if (DataProcessingHandler != null)
            {
                DataProcessingHandler(message);
            }
        }

        // It notifies all subscribers of the message that is processed from the ProcessInt method
        protected void WhenDataIsProcessed(int message)
        {
            if (DataProcessingIntHandler != null)
            {
                DataProcessingIntHandler(message);
            }
        }
    }
}
