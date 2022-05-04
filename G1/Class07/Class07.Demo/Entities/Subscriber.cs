using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class07.Demo.Entities
{
    public class Subscriber
    {
        public void PrintMessage(string message)
        {
            Console.Write("Subscriber1 received message: ");
            Console.WriteLine(message);
        }


        public void PrintMessageInt(int message)
        {
            Console.Write("Subscriber1 received INT message: ");
            Console.WriteLine(message);
        }
    }
}
