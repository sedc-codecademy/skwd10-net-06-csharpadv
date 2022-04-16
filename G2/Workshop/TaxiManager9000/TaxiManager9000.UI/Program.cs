// See https://aka.ms/new-console-template for more information
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Services;
using TaxiManager9000.Domain.Services.Interfaces;
using TaxiManager9000.UI.Utils;

IAuthService authService = new AuthService();

StartApplication(authService);

Console.ReadLine();

void StartApplication(IAuthService authService)
{
    ShowLogin(authService);
}

void ShowLogin(IAuthService authService)
{
    Console.WriteLine("Enter username");
    string username = Console.ReadLine();

    Console.WriteLine("Enter password");
    string password = Console.ReadLine();

    User currentUser = authService.LogIn(username, password);

    ConsoleUtils.WriteLineInColor($"Successful login! Welcome {currentUser.Role} {currentUser.UserName}",
                                  ConsoleColor.Green);
}