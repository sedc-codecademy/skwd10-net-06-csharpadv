List<string> names = new List<string>()
{
    "Bob", "Jill", "Wayne", "Greg", "John", "Anne"
};
List<string> empty = new List<string>();

#region Func
//Func always has a return value

// Example of a Func with no parameters
// bool -> return value
Func<bool> isNamesEmpty = () => names.Count == 0;
// Exampe of a Func with 1 paramter
// List<string> -> parameter no. 1 / bool -> return type
Func<List<string>, bool> isListEmpty = (x) => x.Count == 0;
// Example of a Func with 2 parameters
// // int -> parameter no. 1 / int -> parameter no. 2 / int -> return type
Func<int, int, int> sum = (x, y) => x + y;
// int1 = parameter, int2 parameter, bool return
Func<int, int, bool> checkLarger = (x, y) =>
{
    if (x > y) return true;
    return false;
};

Console.WriteLine($"isNamesEmpty: {isNamesEmpty()}");
Console.WriteLine($"isListEmpty {isListEmpty(empty)}");
Console.WriteLine($"sum {sum(2, 3)}");
Console.WriteLine($"checkLarger {checkLarger(9, 3)}");
#endregion

#region Action
// Action is always void

// Example of an action without parameters
Action hello = () => Console.WriteLine("Hello there!");
// Example of an action with one parameter ( string )
Action<string> printRed = x =>
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(x);
    Console.ResetColor();
};
// Example of an action with two parameters ( string and ConsoleColor )
Action<string, ConsoleColor> printColor = (x, y) =>
{
    Console.ForegroundColor = y;
    Console.WriteLine(x);
    Console.ResetColor();
};


hello();
printRed("An error occured");
printColor("Oh wait, it's not really an error. Carry on. False alarm", ConsoleColor.Green);
#endregion

#region High Order Function Use
// We can use direct lambda expressions in a high order method in C#
string foundBob = names.Find(x => x == "Bob");
Console.WriteLine(foundBob);

// We can also use Func to pass it in a LINQ method instead of a direct labmda expression
Func<string, bool> IsBob = x => x == "Bob";
//string foundJill = names.FirstOrDefault(x => x == "Bob");
string foundJill = names.FirstOrDefault(IsBob);

Func<string, bool> startsWithJ = x => x.StartsWith("J");
List<string> letterJnames = names.Where(startsWithJ).ToList();

Console.WriteLine(foundJill);

foreach(var name in letterJnames)
{
    Console.WriteLine(name);
}

#endregion

Console.ReadLine();
