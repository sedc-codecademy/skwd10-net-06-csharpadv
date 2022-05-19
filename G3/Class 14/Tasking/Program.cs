// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//var x = 100;
//var random = new Random();
//ThreadPool.SetMaxThreads(100, 100);

//HashSet<int> threadIds = new HashSet<int>();

//for (int i = 0; i < 1000; i++)
//{
//var thread = new Thread(() =>
//{
//    threadIds.Add(Environment.CurrentManagedThreadId);

//    if (random.Next(2) == 0)
//    {
//        x = 101 + i;
//    }
//    Console.WriteLine($"Executing on {Environment.CurrentManagedThreadId}");
//});

//thread.Start();
//thread.Join();

//}

//x = 99;
//Console.WriteLine($"Executing on {Environment.CurrentManagedThreadId} (main)");
//Console.WriteLine(x);

//Console.WriteLine($"A total of {threadIds.Count} threads have been used");

//ThreadPool.GetAvailableThreads(out int threads, out _);
//Console.WriteLine($"Total of {threads} present in the pool");

//Interlocked.Increment(ref x);


//var x = 100;
//var random = new Random();

////HashSet<int> threadIds = new HashSet<int>();
//var tasks = new List<Task<int>>();

//for (int i = 0; i < 1000; i++)
//{
//    var task = Task<int>.Factory.StartNew(() => {
//        Console.WriteLine($"Executing on {Environment.CurrentManagedThreadId}");
//        return Environment.CurrentManagedThreadId;
//    });
//    tasks.Add(task);
//}

//var threadIds = (await Task.WhenAll(tasks)).Distinct();

//Console.WriteLine($"Executing on {Environment.CurrentManagedThreadId} (main)");
//Console.WriteLine(x);

//Console.WriteLine($"A total of {threadIds.Count()} threads have been used");

//ThreadPool.GetAvailableThreads(out int threads, out _);
//Console.WriteLine($"Total of {threads} present in the pool");

CancellationTokenSource cts = new CancellationTokenSource();
var task = Task.Factory.StartNew(async () =>
{
    await Task.Delay(1000);
    Console.WriteLine($"Executing on {Environment.CurrentManagedThreadId}");
}, cts.Token);

cts.Cancel();
Console.WriteLine("Canceled the task");
