// See https://aka.ms/new-console-template for more information
using UserApp;

Console.WriteLine("Hello, World!");

var fe = new ForEachClass();

foreach (var item in fe)
{
    Console.WriteLine(item);
}
Console.WriteLine("------------------");

var tenOdds = Extensions.GetAllOddNumbers().Take(10);

foreach (var odd in tenOdds)
{
    Console.WriteLine(odd);
}

Console.WriteLine("------------------");

//var triangles = Extensions.GetAllTriangleNumbers().TakeWhile(num => num < 1_000);
var triangles = Extensions.GetAllTriangleNumbersUnderThousand();

foreach (var t in triangles)
{
    Console.WriteLine(t);
}

Console.WriteLine("------------------");

var numbers = Extensions.GetSomeNumbers();

foreach (var num in numbers)
{
    Console.WriteLine(num);
}