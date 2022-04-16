// See https://aka.ms/new-console-template for more information
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Exceptions;
using TaxiManager9000.Services;
using TaxiManager9000.Services.Interfaces;
using TaxiManager9000.UI.Utils;

IAuthService authService = new AuthService();

StartApplication(authService);

Console.ReadLine();

void StartApplication(IAuthService authService)
{
    ShowLogin(authService);
    ShowMenu(authService);
}

void ShowMenu(IAuthService authService)
{
    switch (authService.CurrentUser.Role)
    {
        case Role.Administrator:
            ShowAdminMenu(authService);
            break;
        case Role.Maintainance:
            ShowMaintainenceMenu(authService);
            break;
        case Role.Manager:
            ShowManagerMenu(authService);
            break;
        default:
            ConsoleUtils.WriteLineInColor($"Invalid role, {authService.CurrentUser.Role}", ConsoleColor.Red);
            break;
    }
}

void ShowAdminMenu(IAuthService authService)
{
    throw new NotImplementedException();
}

void ShowMaintainenceMenu(IAuthService authService)
{
    throw new NotImplementedException();
}

void ShowManagerMenu(IAuthService authService)
{
    throw new NotImplementedException();
}

void ShowLogin(IAuthService authService)
{
    Console.WriteLine("Enter username");
    string username = Console.ReadLine();

    Console.WriteLine("Enter password");
    string password = Console.ReadLine();

    User currentUser;
    try
    {
        authService.LogIn(username, password);

        ConsoleUtils.WriteLineInColor($"Successful login! Welcome {authService.CurrentUser.Role} {authService.CurrentUser.UserName}",
                                      ConsoleColor.Green);
    }
    catch (InvalidCredentialsException ex)
    {
        ConsoleUtils.WriteLineInColor("Unsuccessful login, try again", ConsoleColor.Red);
    }
}