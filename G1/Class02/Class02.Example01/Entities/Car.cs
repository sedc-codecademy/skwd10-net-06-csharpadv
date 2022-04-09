using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class02.Example01.Entities
{
    public partial class Car
    {
        public int Id { get; set; }

        public string Manifacturer { get; set; }

        public string Name { get; set; }

        public int TopSpeed { get; set; }

        public void Drive()
        {
            Console.WriteLine("Brrrrrrrrrrm");
        }
    }
}
