// See https://aka.ms/new-console-template for more information
using Class02.Exerscise01;
using Class02.Exerscise01.Entities;
using Class02.Exerscise01.Enums;

Console.WriteLine("Hello, World!");

CarManagementService carManagementService = new CarManagementService();
Console.WriteLine("=======================================");
Console.WriteLine("All cars in dealership");
carManagementService.PrintAllCars();

Car car = new Car()
{
    Id = 1,
    Name = "Astra",
    Manifacturer = "Opel",
    Fuel = FuelEnum.Petrol,
    TopSpeed = 200,
    NumberOfDoors = 5
};
carManagementService.Add(car);

Console.WriteLine("=======================================");
Console.WriteLine("All cars in dealership after  added new one");
carManagementService.PrintAllCars();

Console.WriteLine("=======================================");
Console.WriteLine("Fast cars are the following: ");
foreach (var item in carManagementService.GetAllVeryFastCars())
{
    Console.WriteLine(item.Manifacturer + " " + item.Name);
}