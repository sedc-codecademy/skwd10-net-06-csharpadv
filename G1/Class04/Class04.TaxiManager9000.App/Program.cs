// See https://aka.ms/new-console-template for more information
using Class04.TaxiManager9000.Domain.Entities;
using Class04.TaxiManager9000.Domain.Enums;
using Class04.TaxiManager9000.Services.Services;

#region Entity Init
UserService userService = new UserService();
User user1 = new User("admin", "admin", RoleEnum.Administrator);
User user2 = new User("manager", "password", RoleEnum.Manger);
userService.Add(user1);
userService.Add(user2);
#endregion

#region Example how to  use service and the mehtods from that service
Console.WriteLine("All Users in the system");
userService.GetAll().ForEach(x => Console.WriteLine(x.Username + "-" + x.Role.ToString()));

Console.WriteLine("====================================================");
Console.WriteLine("Login user admin");
var user = userService.Login("admin", "admin");
if (user != null)
{
    Console.WriteLine("Login OK.");
}
else
{
    Console.WriteLine("Login failed");
}
Console.WriteLine("====================================================");
Console.WriteLine("Remove user with ID 1");
userService.Remove(1);
Console.WriteLine("====================================================");
Console.WriteLine("All Users in the system");
userService.GetAll().ForEach(x => Console.WriteLine(x.Username + "-" + x.Role.ToString()));

Console.WriteLine("====================================================");
Console.WriteLine("Login user admin");
user = userService.Login("admin", "admin");
if (user != null)
{
    Console.WriteLine("Login OK.");
}
else
{
    Console.WriteLine("Login failed");
}
Console.WriteLine("========================Password change and test============================");
Console.WriteLine("Login user manager with password password");
user = userService.Login("manager", "password");
if (user != null)
{
    Console.WriteLine("Login OK.");
}
else
{
    Console.WriteLine("Login failed");
}

Console.WriteLine("Change password for user manager from password123 to password1");
if (userService.ChangePassword(2, "password123", "password1"))
{
    Console.WriteLine("Password changed.");
}
else
{
    Console.WriteLine("Password change failed");
}

Console.WriteLine("Change password for user manager from password123 to password");
if (userService.ChangePassword(2, "password123", "password"))
{
    Console.WriteLine("Password changed.");
}
else
{
    Console.WriteLine("Password change failed");
}


Console.WriteLine("Change password for user manager from password to password1");
if (userService.ChangePassword(2, "password", "password1"))
{
    Console.WriteLine("Password changed.");
}
else
{
    Console.WriteLine("Password change failed");
}

Console.WriteLine("Login user manager with password password");
user = userService.Login("manager", "password");
if (user != null)
{
    Console.WriteLine("Login OK.");
}
else
{
    Console.WriteLine("Login failed");
}

Console.WriteLine("Login user manager with password password1");
user = userService.Login("manager", "password1");
if (user != null)
{
    Console.WriteLine("Login OK.");
}
else
{
    Console.WriteLine("Login failed");
}
#endregion