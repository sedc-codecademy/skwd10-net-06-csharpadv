using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism.Entities
{
    public class Dog : Pet
    {
        public bool IsGoodBoi { get; set; }
        public override void Eat()
        {
            Console.WriteLine("Nom Nom noming on dog food!");
        }
    }
}
