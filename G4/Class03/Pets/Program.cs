namespace Pets // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog sparky = new Dog();
            Cat meow = new Cat();

            PetHelper.PetStatus(sparky, "Bob");
            PetHelper.PetStatus("Bob", sparky);

            PetHelper.PetStatus(meow, "Jill");
            PetHelper.PetStatus(meow);
        }
    }
}