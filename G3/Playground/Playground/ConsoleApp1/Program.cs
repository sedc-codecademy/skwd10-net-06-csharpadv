using ConsoleApp1;

Func<int, int> Compose(Func<int, int> first, Func<int, int> second) 
    => x => first(second(x));


// x => 2x+1

int AddOne(int x) => x + 1;
int Double(int x) => x * 2;

var DvaXPlusEden = Compose(AddOne, Double);

Console.WriteLine(DvaXPlusEden(3));
Console.WriteLine(string.Empty.PadLeft(20, '-'));
//-------------

var fourNumbersList = new List<int> { 1, 2, 3, 4};
var emptyList = new List<int>();
var singleZeroList = new List<int> { 0 };

fourNumbersList.FirstOrDefault(x =>
{
    // will be called four times
    Console.WriteLine($"called with x = {x}");
    return false;
});

fourNumbersList.FirstOrDefault(x =>
{
    // will be called four times
    Console.WriteLine($"called with x = {x}");
    return true;
});


Console.WriteLine(string.Empty.PadLeft(20, '-'));
//-------------

Person weko = new Programmer { 
    FirstName = "Wekoslav", 
    LastName = "Stefanovski",
    Language = "C#"
};
Console.WriteLine(weko);

