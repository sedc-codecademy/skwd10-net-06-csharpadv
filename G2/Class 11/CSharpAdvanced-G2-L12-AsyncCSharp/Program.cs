// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

//Stopwatch stopwatch = Stopwatch.StartNew();

//Task<int> task = new Task<int>(() =>
//{
//    Thread.Sleep(10000);

//    return 1;
//});

//Task taskTwo = new Task(() =>
//{
//    Random rnd = new Random();
//    //throw new Exception("Test message"); This exception will get swallowed if we do not wait the task
//    Thread.Sleep(rnd.Next(10000, 11000));
//});

//task.Start();
//try
//{

//    taskTwo.Start();
//    taskTwo.Wait();
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}


////while (!task.IsCompleted)
////{
////    Console.WriteLine("Task is still running");
////}
//Console.WriteLine("Waiting for task");
//task.Wait();

//stopwatch.Stop();
//Console.WriteLine($"Task Finished. Result is {task.Result}. Total execution time {stopwatch.ElapsedMilliseconds} ms; Second task is completed {taskTwo.IsCompleted}. Is Second task failed {taskTwo.IsFaulted}");

Console.WriteLine("Start waiting for async method");

string result = await DoWorkAsync();

Console.WriteLine(result);

async Task<string> DoWorkAsync()
{
   return await Task.Run(() =>
    {
        Thread.Sleep(2000);
        Console.WriteLine("Executing code returned from a method");

        return "Result";
    });
}
