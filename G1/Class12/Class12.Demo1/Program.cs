using System.Diagnostics;

Console.WriteLine("=========== THREADS ===========");

void SendMessages()
{
    //stopwatch to measure the actual time needed for execution of the preparation
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    Console.WriteLine("Prepare for Message sending");
    Thread.Sleep(2000);
    Console.WriteLine("Message 1 sent!");
    Thread.Sleep(2000);
    Console.WriteLine("Message 2 sent!");
    Thread.Sleep(2000);
    Console.WriteLine("Message 3 sent!");
    Console.WriteLine("All Messages are sent");

    //stop of the stopwatch and printing the actual time needed for execution
    stopwatch.Stop();
    Console.WriteLine(stopwatch.ElapsedMilliseconds + " ms");
}

void SendMessagesWithThread()
{
    //stopwatch to measure the actual time needed for execution
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    Console.WriteLine("Prepare for Message sending");
    Thread first = new Thread(() =>
    {
        Thread.Sleep(7000);
        Console.WriteLine("Message 1 sent!");
    });
    first.Start();
    Thread second = new Thread(() =>
    {
        Thread.Sleep(3000);
        Console.WriteLine("Message 2 sent!");
    });
    second.Start();
    Thread thread3 = new Thread(() =>
    {
        Thread.Sleep(1000);
        Console.WriteLine("Message 3 sent!");
    });
    thread3.Start();
    Console.WriteLine("All Messages are sent");

    //the stopwatch will not detect any time because the sleep times are not in current thread so does not wait for anything
    stopwatch.Stop();
    Console.WriteLine(stopwatch.ElapsedMilliseconds + " ms");
}

Console.WriteLine("==========================================================");
Console.WriteLine("Sync execution");
SendMessages();
Console.WriteLine("==========================================================");
Console.WriteLine();
Console.WriteLine("==========================================================");
Console.WriteLine("Asunc execution with thread");
SendMessagesWithThread();
Console.WriteLine("==========================================================");
    Console.ReadLine();