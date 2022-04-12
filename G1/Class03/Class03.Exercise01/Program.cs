// See https://aka.ms/new-console-template for more information
using Class03.Exercise01.Entities;
using Class03.Exercise01.Services;

Console.WriteLine("Hello, World!");

PetStoreService<Cat> catService = new PetStoreService<Cat>();

catService.Add(new Cat(1, "Tom", "Black&White", 8, -100, false, "Common"));
catService.Add(new Cat(2, "Silvester", "silver", 8, 9, true, "Common"));

catService.PrintPets();
catService.BuyPet(1);
catService.PrintPets();