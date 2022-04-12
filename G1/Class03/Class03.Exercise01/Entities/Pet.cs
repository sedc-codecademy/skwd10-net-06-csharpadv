using Class03.Exercise01.Entities.Interfaces;

namespace Class03.Exercise01.Entities
{
    public abstract class Pet : IPet
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public int Age { get; set; }

        public abstract string PetInfo();

        public Pet(int id, string name, string color, int age)
        {
            Id = id;
            Name = name;
            Color = color;
            Age = age;
        }
    }
}
