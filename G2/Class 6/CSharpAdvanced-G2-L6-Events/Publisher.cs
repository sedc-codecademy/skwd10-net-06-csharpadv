namespace CSharpAdvanced_G2_L6_Events
{
    public class Publisher
    {
        public delegate void DataProcessingDelegate(string message);
        public event DataProcessingDelegate DataProcessingHandler;

        public void ProcessData(string message)
        {
            Console.WriteLine("Processing data...");
            Thread.Sleep(3000);
            WhenDataIsProcessed(message);
        }

        protected void WhenDataIsProcessed(string message)
        {
            if (DataProcessingHandler != null)
            {
                DataProcessingHandler(message);
            }
        }
    }
}
