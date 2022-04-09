// See https://aka.ms/new-console-template for more information
using Class02.Example01.Entities;

Console.WriteLine("=========== Static classes ============");
#region static 
Dog dog1 = new Dog() { Name = "Rocky", Age= 2, Description="Golden Retriver"};
Dog dog2 = new Dog() { Name = "Jecky", Age = 2, Description = "Pudle" };
Dog dog3 = new Dog() { Name = "Spike", Age = 2, Description = "Bulldog" };

DogShelter.Dogs.Add(dog1);
DogShelter.Dogs.Add(dog2);
DogShelter.Dogs.Add(dog3);
DogShelter.PrintAll();

DogShelter.Dogs.Remove(dog1);
DogShelter.PrintAll();
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