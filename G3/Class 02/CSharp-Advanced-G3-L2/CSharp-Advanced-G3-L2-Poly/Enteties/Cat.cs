
namespace CSharp_Advanced_G3_L2_Poly.Enteties
{
    public class Cat : Pet
    {
        public int NumberOfBalls { get; set; }

        public Cat(string name, int numberOfBalls) : base(name)
        {
            NumberOfBalls = numberOfBalls;
        }

        public override void Eat()
        {
            Console.WriteLine("The cat is eating");
        }
    }
}
