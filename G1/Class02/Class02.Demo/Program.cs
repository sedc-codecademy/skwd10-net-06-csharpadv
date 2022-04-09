// See https://aka.ms/new-console-template for more information
using Class02.Demo.Entities;

Console.WriteLine("Hello, This is class 02 >> Static and partial classes, polymorphism <<");

Console.WriteLine(Test.TestProblem());
Console.WriteLine("Vnesi broj:");

Console.WriteLine(TextHelper.ValidationCounter);

if (TextHelper.ValidateInteger(Console.ReadLine()))
{
    Console.WriteLine("Vneseniot string e integer!");
}
Console.WriteLine(TextHelper.ValidationCounter);

if (TextHelper.ValidateInteger(Console.ReadLine()))
{
    Console.WriteLine("Vneseniot string e integer!");
}
Console.WriteLine(TextHelper.ValidationCounter);


