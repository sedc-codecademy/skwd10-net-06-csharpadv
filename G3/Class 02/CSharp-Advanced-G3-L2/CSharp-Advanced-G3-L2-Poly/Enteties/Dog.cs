using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Advanced_G3_L2_Poly.Enteties
{
    public class Dog : Pet
    {
        public string Breed { get; set; }

        public Dog() : base("Sharko")
        {

        }

        public Dog(string name) : base(name)
        {

        }

        public Dog(int number) : base("1234")
        {
            Console.WriteLine(number);
        }

        public Dog(string name, string breed) : base(name)
        {
            Breed = breed;
        }

        public override void Eat()
        {
            Console.WriteLine($"The dog {Breed} is eating");
        }
    }
}
