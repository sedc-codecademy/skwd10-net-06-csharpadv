// See https://aka.ms/new-console-template for more information
using CSharpAdvanced_G2_L2_StaticClassesAndPolymorphism.Helpers;

Console.WriteLine("Enter 1 for Student Login and 0 For Teacher Login ");

int.TryParse(Console.ReadLine(), out int input);

LogIn(input);













void LogIn(int input)
{
    if (input == MenuOptions.TEACHER_LOGIN)
    {
        Console.WriteLine("Welcome teacher");
    }
    else if (input == MenuOptions.STUDENT_LOGIN)
    {
        Console.WriteLine("Welcome stduent");
    }
}