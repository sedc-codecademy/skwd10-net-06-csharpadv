using Class05.Domain.Entities.Interfaces;

namespace Class05.Domain.Entities
{
    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string Color { get; set; }

        public abstract string MakeSound();

        public virtual string Sleep()
        {
            return "zzzzzz";
        }
    }
}
