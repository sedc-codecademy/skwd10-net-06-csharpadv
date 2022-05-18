Console.WriteLine("=========== TASKS ===========");
//standard definition of tasks
Task task = new Task(() =>
{
    Thread.Sleep(4000);
    Console.WriteLine("Task 1, a sleep for 4 seconds!");
});
//must add .Stoart()
task.Start();

Task<int> task2 = new Task<int>(() =>
{
    Thread.Sleep(2000);
    Console.WriteLine("Task 2, a sleep for 2 seconds!");
    return 0;
});
task2.Start();

//Automatically start the task
Task.Run(() =>
{
    Thread.Sleep(3000);
    Console.WriteLine("A sleep for 3 seconds!");
});

//When task return result we get the return result with .Result
Console.WriteLine(task2.Result);

//If we start a lot of thasks in the same time they will fight for alocation of threads in the thread pool
//so even if the sleep time is the same we will never get the execution order to be the same in every execution
for (int i = 1; i<=20; i++)
{
    int temp = i;
    Task.Run(() =>
    {
        Random rnd = new Random();
        int sleepTime = rnd.Next(2000, 4000);
        Thread.Sleep(sleepTime);
        Console.WriteLine($"Task number {temp}-{sleepTime} ms");

    });
}

Console.ReadLine();