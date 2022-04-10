// See https://aka.ms/new-console-template for more information
using Class02.Demo.Entities;
using Class02.Demo.Helpers;

Console.WriteLine("Hello, This is class 02 >> Static and partial classes, polymorphism <<");


Console.WriteLine("=========== Static classes ============");
#region static 

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
#endregion

Console.WriteLine("=======================================");

Console.WriteLine("=========== Partial classes ===========");
#region partial
Car car = new Car();
car.Manifacturer = "toyota";
car.Name = "Aygo";
car.TopSpeed = 160;
car.ServiceInfo();
#endregion


Console.WriteLine("=======================================");

Console.WriteLine(12.12);
#region Polimorphism
Console.WriteLine(PetShop.GetAge(new object()));
Console.WriteLine(PetShop.GetAge(new object(), 1));
Console.WriteLine(PetShop.GetAge(1, new object()));

#endregion

