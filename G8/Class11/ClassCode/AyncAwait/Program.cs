//SendMessages();

//SendMessagesAsync("hi");
//Console.WriteLine("Test, testing...");
//WriteMessages();

OurMainMethod();

Console.ReadLine();

async Task OurMainMethod()
{
    await SendMessagesAsync("hi");
    WriteMessages();
}

// synchronous
void SendMessages()
{
    Console.WriteLine("Hello students");
    Thread.Sleep(5000);
    Console.WriteLine("Goobye students");
}

//asynchronous
async Task SendMessagesAsync(string message)
{
    Console.WriteLine("Start");
    await Task.Run(() => // for making sync with async add await here
    {
        Thread.Sleep(3000);
        Console.WriteLine($"Message {message} sent!");
    });
    Console.WriteLine("Stop");
    //Task.Run(() =>
    //{
    //    Thread.Sleep(2000);
    //    Console.WriteLine("something, some string 222");
    //});
    //Task.Run(() =>
    //{
    //    Thread.Sleep(1000);
    //    Console.WriteLine("something, some string");
    //});
}

//synchronous
static void WriteMessages()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("This is message outside of the logic");
    Console.ResetColor();
}
