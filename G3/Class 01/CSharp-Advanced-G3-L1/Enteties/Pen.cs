using Enteties.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enteties
{
    public class Pen : IThingsThatCanWriteANote
    {
        public void WriteNote()
        {
            Console.WriteLine("Writing a note with a pen");
        }
    }
}
