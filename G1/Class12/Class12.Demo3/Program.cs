Console.WriteLine("=========== ASYNC/AWAIT ===========");

void SendMessage(string message)
{
    Console.WriteLine("Sending message...");
    Thread.Sleep(2000);
    Console.WriteLine($"The message \"{message}\" was sent.");
}

async Task SendMessageAsync(string message)
{
    Console.WriteLine("Sending message...");
    await Task.Run(() =>
    {
        Thread.Sleep(2000);
        Console.WriteLine($"The message \"{message}\" was sent.");
    });
}

async Task MainThread()
{
    await SendMessageAsync("Some message from main thread");
    ShowAd("Pepsi");
    Console.ReadLine();
}

void ShowAd(string product)
{
    Console.WriteLine("While you wait let us show you an ad:");
    Console.Write("Buy the best product in the world ");
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.Write(product);
    Console.ResetColor();
    Console.Write(" now and get ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("FREE");
    Console.ResetColor();
    Console.WriteLine(" shipping worldwide!");
}

Console.WriteLine(">>>>>>>>>> SYNC SENDING MESSAGE <<<<<<<<<<<<<<");
SendMessage("Sync message example");
Console.WriteLine("==========================================================");
Console.WriteLine();

Console.WriteLine("=============================================================");
Console.WriteLine(">>>>>>>>>> ASYNC SENDING MESSAGE WITH ASYNC/AWAIT <<<<<<<<<<<");
Console.WriteLine("=============================================================");
Console.WriteLine("Calling async method and after that call another code that can execute, " +
    "and just before displaying the final status call await to wait for the async method to finish");
//we dont have await before SendMessageAsync so it will execute in the background
Task task = SendMessageAsync("some message");
Console.WriteLine(task.Status);
ShowAd("Razor");
//after the add is displayed it will wait for SendMessageAsync to finish before printing the status
await task;
Console.WriteLine(task.Status);
Console.WriteLine("=============================================================");
Console.WriteLine();
Console.WriteLine("=============================================================");
Console.WriteLine("Calling async method and in it there is another async method that has await so " +
    "then the method is called because there is no await in front of it it will be executed and the " +
    "next lines of code will be executed. So if the program is terminated/finished we might not see the output from the MainThread method.");
//if we add await in front of MainThrad it will wait the MainThread method to finish before printing the next line
MainThread();
Console.WriteLine("Because in the MainThread method the SendMessageAsync async method has awaint will wait for this method to finish, it will run same as sunc (will display first the message with wait and after that the add)");
//thes read line is added to stop the application to wait for the code in MainThread is finished
//If we hit enter key before the data is displayed it will not be displayed in the console
Console.ReadLine();