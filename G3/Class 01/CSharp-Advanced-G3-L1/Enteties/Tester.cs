using Enteties.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enteties
{
    public class Tester : ITester
    {
        public void TestCode()
        {
            Console.WriteLine("Testing the code");
        }
    }
}
