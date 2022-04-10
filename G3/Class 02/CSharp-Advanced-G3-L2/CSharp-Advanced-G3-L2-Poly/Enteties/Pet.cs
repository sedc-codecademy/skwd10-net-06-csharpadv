
namespace CSharp_Advanced_G3_L2_Poly.Enteties
{
    public abstract class Pet
    {
        public string Name { get; set; }

        public Pet(string name)
        {
            Name = name;
        }

        public abstract void Eat();
    }
}
