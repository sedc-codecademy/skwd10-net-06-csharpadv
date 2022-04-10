using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class02.Example01.Entities
{
    public partial class Car
    {
        public void ServiceInfo()
        {
            Console.WriteLine($"Car {Manifacturer}-{Name} has top speed {TopSpeed}");
        }
    }
}
