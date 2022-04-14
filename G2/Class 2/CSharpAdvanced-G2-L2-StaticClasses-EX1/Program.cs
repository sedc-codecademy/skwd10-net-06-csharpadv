// See https://aka.ms/new-console-template for more information


using CSharpAdvanced_G2_L2_StaticClasses_EX1.Database;
using CSharpAdvanced_G2_L2_StaticClasses_EX1.Entities;
using CSharpAdvanced_G2_L2_StaticClasses_EX1.Helpers;

Console.WriteLine("Hello, World!");

while (true)
{
    Console.WriteLine($"Enter {MenuOptions.PRINT_ALL_USERS} to print all users and enter {MenuOptions.REGISTER_USER} to register");
    string input =  Console.ReadLine();

    if (input == MenuOptions.PRINT_ALL_USERS)
    {
        UserDatabase.USERS.ForEach(Console.WriteLine);
    }
    else if (input == MenuOptions.REGISTER_USER)
    {
        Console.WriteLine("Enter username (cannot be greater than 255 chars)");
        string username = Console.ReadLine();

        if (username.Length > User.USERNAME_MAX_LENGTH)
        {
            throw new IndexOutOfRangeException("Username is too long");
        }

        UserDatabase.USERS.Add(new User(username));
    }
}