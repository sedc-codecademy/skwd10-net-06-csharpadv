using Class03.Exercise01.Entities.Interfaces;

namespace Class03.Exercise01.Entities
{
    public class Cat : Pet, ICat
    {
        public int LeftLives { get; set; }

        public bool Lazy { get; set; }

        public string Breed { get; set; }

        public Cat(int id, string name, string color, int age, int leftLives, bool lazy, string breed) 
            : base(id, name, color, age)
        {
            LeftLives = leftLives;
            Lazy = lazy;
            Breed = breed;
        }

        public override string PetInfo()
        {
            string isLazy = Lazy ? "lazy" : "not lazy";
            return $"{Name} is not a {isLazy} cat.";
        }
    }
}
