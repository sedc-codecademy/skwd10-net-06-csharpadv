using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Flags]
    internal enum StarbucksOptions
    {
        None = 0,
        Decaf = 1,
        Vanilla = 2,
        ExtraShot = 4,
        SkimMilk = 8,
    }
}
