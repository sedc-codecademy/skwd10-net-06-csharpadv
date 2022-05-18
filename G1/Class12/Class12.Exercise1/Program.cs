using Class12.Exercise1.Services;
using System.Diagnostics;

//example from Microsoft for understanding asynch/await
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/
Console.WriteLine("=================== Prepare Brekfast example ===================");

BreakfastService breakfastService = new BreakfastService();
AsyncBreakfastService breakfastServiceAsync = new AsyncBreakfastService();

void PrepareBreakfast()
{
    //stopwatch to measure the actual time needed for execution of the preparation
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    Console.WriteLine("==========================================================");
    Console.WriteLine(">>>>>>>>>>>>> SYNC PREPARATION OF BREAKFAST<<<<<<<<<<<<<<<");
    Console.WriteLine("==========================================================");

    breakfastService.pourCoffee();
    breakfastService.PreapreEggs(2);
    breakfastService.PreapreMushrooms(150);
    breakfastService.PrepareToast(2);
    breakfastService.pourJuice();

    //stop of the stopwatch and printing the actual time needed to prepare the breakfast
    stopwatch.Stop();
    Console.WriteLine("==========================================================");
    Console.WriteLine($"It took {stopwatch.ElapsedMilliseconds} ms to finish");
    Console.WriteLine("==========================================================");
}


async Task PrepareBreakfastAsync()
{
    //stopwatch to measure the actual time needed for execution of the preparation
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("==========================================================");
    Console.WriteLine(">>>>>>>>>>>> ASYNC PREPARATION OF BREAKFAST<<<<<<<<<<<<<<<");
    Console.WriteLine("==========================================================");

    Console.WriteLine("Coffee preparation");
    Task<bool> coffee = breakfastServiceAsync.pourCoffeeAsync();
    await coffee;
    Console.WriteLine("Coffee served");
    
    Console.WriteLine("==========================================================");
    Console.WriteLine("Breakfast preparation started");

    //start all tasks that can be run in parallel (we start in the same time with preparation of eggs, mushrooms and toasts)
    Task<bool> eggs = breakfastServiceAsync.PreapreEggsAsync(2);
    Task<bool> mushrooms = breakfastServiceAsync.PreapreMushroomsAsync(150);
    Task<bool> toast = breakfastServiceAsync.PrepareToastAsync(2);

    //wait for Mushroom preparation before printing Mushroom ready
    await mushrooms;
    Console.WriteLine("Mushrooms ready");

    //wait for eggs preparation before printing Eggs ready
    await eggs;
    Console.WriteLine("Eggs ready");

    //wait for toast preparation before printing toast ready
    await toast;
    Console.WriteLine("Toast ready");

    //after everything is ready pour juice
    await breakfastServiceAsync.pourJuiceAsync();
    Console.WriteLine("Juice served");

    //stop of the stopwatch and printing the actual time needed to prepare the breakfast
    stopwatch.Stop();
    Console.WriteLine("==========================================================");
    Console.WriteLine($"It took {stopwatch.ElapsedMilliseconds} ms to finish");
    Console.WriteLine("==========================================================");
    Console.ReadLine();
}

//method that executes sync execution of all methods
PrepareBreakfast();

//async method that executes preparation async
await PrepareBreakfastAsync();