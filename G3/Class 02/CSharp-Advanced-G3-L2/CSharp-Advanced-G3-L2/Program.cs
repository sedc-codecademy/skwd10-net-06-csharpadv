// See https://aka.ms/new-console-template for more information

using CSharp_Advanced_G3_L2;
using CSharp_Advanced_G3_L2.Enteties;
using CSharp_Advanced_G3_L2.Utils;

/*Console.WriteLine("Hello, World!");

Console.WriteLine(FirstStaticClass.Counter);

FirstStaticClass.Counter++;

Console.WriteLine(FirstStaticClass.Counter);

Console.WriteLine(FirstStaticClass.AddTwoNumbers(2,3));

Console.WriteLine($"Number of created users: {User.UserCount}");

User user1 = new User(1, "Ivan", "Djikovski");
user1.PrintInfo();
User.PrintUserCount();

User user2 = new User(2, "Petko", "Petkovski");
user2.PrintInfo();
Console.WriteLine($"Number of created users: {User.UserCount}");

User user3 = new User(3, "Stanko", "Stankovski");
user3.PrintInfo();
Console.WriteLine($"Number of created users: {User.UserCount}");

Console.WriteLine(StringUtils.CapitaliseFirstLetter("the sun is shining"));
Console.WriteLine(StringUtils.CapitaliseFirstLetter("Today is Saturday"));
Console.WriteLine(StringUtils.CapitaliseFirstLetter("132342355"));
Console.WriteLine(StringUtils.CapitaliseFirstLetter("t"));
Console.WriteLine(StringUtils.CapitaliseFirstLetter(null));
Console.WriteLine(StringUtils.CapitaliseFirstLetter(""));*/

//int parsedValue = StringUtils.VerifyStrigNumber(Console.ReadLine());

//Console.WriteLine(parsedValue);

foreach(Order order in OrdersFakeDB.Orders)
{
    order.Print();
}

//string def = default(string);
//DateTime dateTime = default(DateTime);
//Console.WriteLine(dateTime);

foreach(User user in OrdersFakeDB.Users)
{
    user.PrintOrders();
}

User petko = OrdersFakeDB.Users.FirstOrDefault(user => user.Name == "Petko");

OrdersFakeDB.AddOrder("New Order", "New order desc", OrderStatus.Processing, petko);

User trajko = OrdersFakeDB.AddUser("Trajko", "Trajkovsi");

OrdersFakeDB.AddOrder("Trajko's order", "Description", OrderStatus.Processing, trajko);



foreach (Order order in OrdersFakeDB.Orders)
{
    order.Print();
}

