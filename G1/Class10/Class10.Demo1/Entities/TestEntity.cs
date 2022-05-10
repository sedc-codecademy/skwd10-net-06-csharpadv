
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class10.Demo1.Entities
{
    public class TestEntity
    {
        public int value { get; set; }

        public TestEntity()
        {
            value = 1;
        }

        ~TestEntity()
        {
            Console.WriteLine("Destructor called.");
        }
    }
}
