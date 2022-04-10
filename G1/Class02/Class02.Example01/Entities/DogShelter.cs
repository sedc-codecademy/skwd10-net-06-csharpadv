using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class02.Example01.Entities
{
    public static class DogShelter
    {
        public static List<Dog> Dogs { get; set; }

        static DogShelter()
        {
            Dogs = new List<Dog>();
        }

        public static void PrintAll()
        {
            Console.WriteLine("================== Dogs in shelter ==============");
            foreach(var dog in Dogs)
            {
                Console.WriteLine($"Sog {dog.Name} ({dog.Age}) - {dog.Description}");
            }
        }
    }
}
