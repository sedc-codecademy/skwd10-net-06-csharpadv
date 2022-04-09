// See https://aka.ms/new-console-template for more information
using Class02.Exerscise01;
using Class02.Exerscise01.Entities;
using Class02.Exerscise01.Enums;

Console.WriteLine("Hello, World!");


Car car = new Car()
{
    Name = "Astra",
    Manifacturer = "Opel",
    Fuel = FuelEnum.Petrol,
    TopSpeed = 220,
    NumberOfDoors = 5,
    Id = 1
};

CarManagementService carManagementService = new CarManagementService();
Console.WriteLine("Vast cares are the following: ");
foreach (var item in carManagementService.GetAllVeryFastCars())
{
    Console.WriteLine(item.Manifacturer + " " + item.Name);
}
//Console.WriteLine(car.GetVehicleInfo());