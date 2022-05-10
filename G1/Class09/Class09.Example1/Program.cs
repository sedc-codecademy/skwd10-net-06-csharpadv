using Class09.Example1.Entities;
using Class09.Example1.Services;

Console.WriteLine("Logging example");
LoggerService loggerService = new LoggerService();
List<User> users = new List<User>()
{
    new User(){Username = "Bob20", Password = "123456", Age = 20, Id = 4 },
    new User(){Username = "JillCool", Password = "coolcat", Age = 34, Id = 12 },
    new User(){Username = "Gregonator", Password = "astalavista", Age = 44, Id = 76 }
};

void Login(string username, string password)
{
    User loggedUser = users.FirstOrDefault(x => x.Username == username && x.Password == password);
    if (loggedUser == null) throw new InvalidLoginException(username);
    Console.WriteLine($"User {loggedUser.Username} is logged in!");

}

try
{
    //Console.Write("Username: ");
    //string username = Console.ReadLine();
    //Console.Write("Password: ");
    //string password = Console.ReadLine();
    //Login(username, password);

    string value = string.Empty;
    User user = new User();
    try
    {
        Console.Write("Id: ");
        value = Console.ReadLine();
        user.Id = int.Parse(value);
    }
    catch(Exception)
    {
        throw new InvalidUserPropertyException("Id", value, "riki");
    }
    Console.Write("Username: ");
    user.Username = Console.ReadLine();
    Console.Write("Password: ");
    user.Password = Console.ReadLine();
    Console.Write("Age: ");
    int age = int.Parse(Console.ReadLine());    
    user.Age = age;

}
catch (InvalidUserPropertyException ex)
{
    loggerService.Log(ex.Message, $"Property: {ex.BrokenProperty} with value {ex.PropertyValue}\n\r" + ex.StackTrace, ex.Username);
}
catch (InvalidLoginException ex)
{
    loggerService.Log(ex.Message, ex.StackTrace, ex.Username);
    Console.WriteLine("Custom error ocurred.");
}
catch (Exception ex)
{
    loggerService.LogError();
    loggerService.Log(ex.Message, ex.StackTrace, "Riki");
    Console.WriteLine("Error ocurred.");
}