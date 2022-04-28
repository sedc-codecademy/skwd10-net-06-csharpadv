using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class07.Demo.Entities
{
    public class Subscriber2
    {
        public void PrintMessage(string message)
        {
            Console.Write("Subscriber2 received message: ");
            Console.WriteLine(message);
        }
    }
}
