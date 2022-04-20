// See https://aka.ms/new-console-template for more information



SayDelegate sayDelegate = new SayDelegate(WriteToConsole);
SayDelegate sayWithColor = new SayDelegate(WriteWithRedColor);


sayDelegate("Hello world from delegate");
sayWithColor("This text is red");

SaySomething(WriteToConsole, 1);
SaySomething(WriteWithRedColor, 2);

CalulateDelegate addTwoNumbers = AddNumber;
CalulateDelegate subtractNumbers = SubtractNumbers; 

Console.WriteLine($"4+5 = {addTwoNumbers(4, 5)}");
Console.WriteLine($"10 - 3 = {subtractNumbers(10, 3)}");

PerformCalculations(AddNumber, SubtractNumbers, 6, 7);

static void WriteToConsole(string text)
{
    Console.WriteLine(text);
}

static void WriteWithRedColor(string text)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(text);
    Console.ResetColor();
}

static void SaySomething(SayDelegate sayMechanism, int counter)
{
    sayMechanism($"Text from method {counter}");
}

static void PerformCalculations(CalulateDelegate addNumbers, CalulateDelegate subNumbers, int first, int second)
{
    Console.WriteLine($"Addition: of {first} and {second} is {addNumbers(first, second)}");
    Console.WriteLine($"Substruction: of {first} and {second} is {subNumbers(first, second)}");
}

static int AddNumber(int firstNumber1, int secondNumber1)
{
    return firstNumber1 + secondNumber1;
}

static int SubtractNumbers(int firstNumber, int secondNumber)
{
    return firstNumber - secondNumber;
}


delegate void SayDelegate(string text);
delegate int CalulateDelegate(int firstNumber, int secondNumber);
