// See https://aka.ms/new-console-template for more information

using Domain;
using Domain.Interfaces;

static void HappyBirthday(IPerson person)
{
    Console.WriteLine($"This is {person.GetInfo()}");
    Console.WriteLine("Happy birthday to you");
}

//Person person = new Person("Angel", "Mitrov", 20, 123456); - ERROR - abstract class, can not instantiate

Developer developer = new Developer("Filip", "Runtev", 29, 987656, "Ecommerce", 5);
DevOps devOps = new DevOps("Gorjan", "Tozi", 20, 675987, true, false);
Operations operationsManager = new Operations("Jovana", "Vladeva", 20, 67868967, new List<string> { "BetProject", "DentalSystem" });
QAEngineer qAEngineer = new QAEngineer("Martina", "Vujovska", 20, 6896564, null);

Console.WriteLine("Dev:");
Console.WriteLine(developer.GetInfo());
Console.WriteLine("Ops:");
Console.WriteLine(operationsManager.GetInfo());

Console.WriteLine("Dev:");
//from Person
developer.GoodBye();
//from IDeveloper
developer.Code();

Console.WriteLine("DevOps");
//from IDeveloper
devOps.Code();
//from IOperations
Console.WriteLine(devOps.CheckInfrastructures(200));

HappyBirthday(developer);
HappyBirthday(qAEngineer);


Console.ReadLine();
