using Enteties.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enteties
{
    public class Developer : IDeveloper
    {
        public void Code()
        {
            Console.WriteLine("Devoloping application");
        }
    }
}
