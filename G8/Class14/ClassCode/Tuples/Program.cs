// Ways of creating tuples
Tuple<string, string, int> tempPerson01 = Tuple.Create("Bob", "Bobsky", 33);
Tuple<string, string, int> tempPerson02 = new Tuple<string, string, int>("John", "Snow", 19);

Console.WriteLine($"Welcome {tempPerson01.Item1} {tempPerson01.Item2} - Age {tempPerson01.Item3}");
Console.WriteLine("Enter number:");
int num01 = int.Parse(Console.ReadLine());
Console.WriteLine("Enter number:");
byte num02 = byte.Parse(Console.ReadLine());

// Using tuple as an argument
Console.WriteLine($"{Sum(new Tuple<int, byte>(num01, num02))}");

int Sum(Tuple<int, byte> numbers)
{
    return (int)numbers.Item1 + numbers.Item2;
}
