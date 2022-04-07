using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enteties
{
    public class Krug : Figura
    {
        public int Radius { get; set; }

        public Krug(int radius)
        {
            Radius = radius;
        }

        public override double PresmetajPlostina()
        {
            return Radius * Radius * 3.14;
        }
    }
}
