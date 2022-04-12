using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingUnboxing.Entities
{
    public class Tester : Employee
    {
        public int NumOfBugs { get; set; }
        public void Test()
        {
            Console.WriteLine("Testing...");
        }
    }
}
