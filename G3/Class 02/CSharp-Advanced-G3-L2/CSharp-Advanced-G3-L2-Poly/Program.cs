// See https://aka.ms/new-console-template for more information
using CSharp_Advanced_G3_L2_Poly.Enteties;

Console.WriteLine("Hello, World!");

List<Pet> pets = new List<Pet>()
{
    new Cat("meow", 2),
    new Dog("bark", "German Sheppard"),
    new Dog("sparky", "Doga")
};

foreach(Pet pet in pets)
{
    pet.Eat();
}

Dog dog1 = new Dog();
dog1.Eat();
Dog dog2 = new Dog(123);
Dog dog3 = new Dog("Bak");
Dog dog4 = new Dog("DogName", "Koker");

Console.ReadLine();

MethodPoly methodPoly = new MethodPoly();

methodPoly.AddNumbers(3, 7);
methodPoly.AddNumbers(5.3, 4.6);
methodPoly.AddNumbers(1, (double)5);
methodPoly.AddNumbers(6, 4, 5);

