namespace Pets
{
    internal class Pet
    {
        public string Name { get; set; }
        public virtual void Eat()
        {
            Console.WriteLine("Nom nom nom");
        }
    }

    internal class Dog : Pet
    {
        public bool IsGoodBoi { get; set; }
        public override void Eat()
        {
            Console.WriteLine("Nom nom noming on dog food!");
        }
    }

    internal class Cat : Pet
    {
        public bool IsLazy { get; set; }
        public override void Eat()
        {
            Console.WriteLine("Nom nom noming on cat food!");
        }
    }
}
