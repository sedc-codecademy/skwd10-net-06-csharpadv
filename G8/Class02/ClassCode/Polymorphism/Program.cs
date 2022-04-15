
using Polymorphism;
using Polymorphism.Entities;

PetService service = new PetService();

#region Dynamic Polymorphism Example
// Dynamic poloymorphism ( Class method overriding )
Dog sparky = new Dog() { Name = "Sparkyt", IsGoodBoi = true };
Cat meow = new Cat() { Name = "Meow", IsLazy = false };

// Both call the same method Eat(), but the implementation is different since it is implemented in two different classes
sparky.Eat();
meow.Eat();
Console.ReadLine();
#endregion

#region Polymorphism Example
// Polymorphism 
// All methods have the same name but the signature and the impelemtation is different
service.PetStatus(sparky, "Bob");
service.PetStatus("Bob", sparky);
service.PetStatus(meow, "Jill");
service.PetStatus(meow);
Console.ReadLine();
#endregion


Console.ReadLine();
