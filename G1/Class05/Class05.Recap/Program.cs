// See https://aka.ms/new-console-template for more information
using Class05.Domain.Entities;
using Class05.Domain.Entities.Interfaces;
using Class05.Services;

Console.WriteLine("Hello, World!");
#region Classes and inheritance
Dog dog = new Dog()
{
    Name = "Rocky"
};
Rabit rabit = new Rabit();
Console.WriteLine("\"" + dog.MakeSound() + "\"");
Console.WriteLine(rabit.MakeSound());
Console.WriteLine(rabit.Sleep());

#endregion

#region Abstract classes and interfaces
Animal animal = new Dog();
Console.WriteLine(animal.MakeSound());
#endregion

#region Static and partial classes

Console.WriteLine(StringHelper.Quotate(dog.Sleep()));
Console.WriteLine(StringHelper.requestCount);
DogService dogService = new DogService();
Console.WriteLine(dogService.GroomDog(dog));
Console.WriteLine(StringHelper.requestCount);
#endregion

#region Generics and extension methods
//Console.WriteLine(NameHelper<Dog>.GetName(dog));

string text = "the dog juped over the lazy fox!";
int broj = 0;

text.Capitalize(" test 2");

Console.WriteLine(Capitalize(text));


static string Capitalize(string text)
{
    string result = string.Empty;
    var words = text.Split(" ");
    foreach(var word in words)
    {
        result += " " + word[0].ToString().ToUpper() + word.Substring(1,word.Length-1);
    }

    return result;
}

#endregion