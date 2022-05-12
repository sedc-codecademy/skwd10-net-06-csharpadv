#region Methods
// Synchronous
void SendMessage()
{
    Console.WriteLine("Getting Ready...");
    Thread.Sleep(2000);
    Console.WriteLine("First message arrived!");
    Thread.Sleep(2000);
    Console.WriteLine("Second message arrived!");
    Thread.Sleep(2000);
    Console.WriteLine("Third message arrived!");
    Console.WriteLine("All messages are recaived");
    Console.ReadLine();
}
// Asynchtonous
void SendMessagesWithThreads()
{
    Console.WriteLine("Getting Ready...");
    Thread myThread = new Thread(() =>
    {
        Thread.Sleep(2000);
        Console.WriteLine("First message arrived!");
    });
    myThread.Start();  
    new Thread(() =>
    {
        Thread.Sleep(2000);
        Console.WriteLine("Second message arrived!");
    }).Start();
    new Thread(() =>
    {
        Thread.Sleep(1000);
        Console.WriteLine("Third message arrived!");
    }).Start();
    Console.WriteLine("All messages are recaived");
    Console.ReadLine();
}

#endregion

//SendMessage();
SendMessagesWithThreads();
