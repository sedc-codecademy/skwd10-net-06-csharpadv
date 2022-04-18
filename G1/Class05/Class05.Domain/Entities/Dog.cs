using Class05.Domain.Entities.Interfaces;

namespace Class05.Domain.Entities
{
    public class Dog : Animal, IDog
    {
        public string Breed { get; set; }

        public override string MakeSound()
        {
            return "Av, av";
        }

        public string RunAfterBall()
        {
            return "Sorry, I am jazy dog.";
        }

        public string WakeUpOwner()
        {
            return "Wake up is time for my walk. AV, AV, AV!";
        }
    }
}
