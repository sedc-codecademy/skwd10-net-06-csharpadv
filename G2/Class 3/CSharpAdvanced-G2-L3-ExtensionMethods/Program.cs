// See https://aka.ms/new-console-template for more information
using CSharpAdvanced_G2_L3_ExtensionMethods.Utils;

Console.WriteLine("Hello, World!");

string value = " ";

if (value.IsEmpty())
{
    Console.WriteLine("String is empty");
}
else
{
    Console.WriteLine($"String value is {value}");
}

int numberOne = 10;
int numberTwo = 5;

if (numberOne.IsBiggerThan(numberTwo))
{
    Console.WriteLine($"{numberOne} is Bigger than {numberTwo}");
}
else
{
    Console.WriteLine($"{numberTwo} is Bigger than {numberOne}");
}

decimal decimalNumber = 100.124124m;

Console.WriteLine(decimalNumber.RoundNumber());