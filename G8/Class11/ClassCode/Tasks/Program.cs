Task ourFirstTask = new Task(() =>
{
    Thread.Sleep(2000);
    Console.WriteLine("Started working after 2 secs");
});
ourFirstTask.Start();
// return type of the function in the Task is int
Task<int> resultTask = new Task<int>(() =>
{
    Thread.Sleep(2000);
    Console.WriteLine("We are returning the result...");
    return 1;
});
resultTask.Start();
Console.WriteLine(resultTask.Result);

for(int i = 0; i <= 20; i++)
{
    int temp = i;
    Task.Run(() =>
    {
        Thread.Sleep(2000);
        Console.WriteLine($"Task number {temp}");
    });
}

Console.ReadLine();
