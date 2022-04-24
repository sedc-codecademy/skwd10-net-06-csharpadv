namespace CSharpAdvanced_G2_L6_Events
{
    public class Subscriber1
    {
        public void GetMessage(string message)
        {
            Console.WriteLine("Subscriber 1 here!");
            Console.WriteLine("YAY I GOT MY MESSAGE!");
            Console.WriteLine($"THE MESSAGE IS: {message}");
        }
        public string GetMessageFAIL(int num)
        {
            return "This will FAIL!";
        }
    }

    public class Subscriber2
    {
        public void GetMessage(string message)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Subscriber 2 here!");
            Console.WriteLine("I AM NOT IMPRESSED WITH THE MESSAGE!");
            Console.WriteLine($"THE MESSAGE IS: {message}");
        }
    }
}
