#region Methods
// Synchronous
void SendMessages()
{
    Console.WriteLine("Getting Ready...");
    Thread.Sleep(2000);
    Console.WriteLine("First message arrived!");
    Thread.Sleep(2000);
    Console.WriteLine("Second message arrived!");
    Thread.Sleep(2000);
    Console.WriteLine("Third message arrived!");
    Console.WriteLine("All messages are recieved!");
    Console.ReadLine();
}

// Asynchronous
void SendMessagesWithThreads()
{
    Console.WriteLine("Getting Ready...");
    Thread myThread = new Thread(() => {
        Console.WriteLine("First Message is processing.");
        Thread.Sleep(2000);
        Console.WriteLine("First message arrived!");
    });
    myThread.Start();
    new Thread(() =>
    {
        Console.WriteLine("Second Message is processing.");
        Thread.Sleep(2000);
        Console.WriteLine("Second message arrived!");
    }).Start();
    new Thread(() =>
    {
        Console.WriteLine("Third Message is processing.");
        Thread.Sleep(2000);
        Console.WriteLine("Third message arrived!");
    }).Start();
    Console.WriteLine("All messages are recieved!");
    Console.ReadLine();
}
#endregion

//SendMessages();
SendMessagesWithThreads();