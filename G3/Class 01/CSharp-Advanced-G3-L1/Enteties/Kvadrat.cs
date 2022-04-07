using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enteties
{
    public class Kvadrat : Figura
    {
        public int Strana { get; set; }

        public Kvadrat(int strana)
        {
            Strana = strana;
        }

        public override double PresmetajPlostina()
        {
            return Strana * Strana; 
        }
    }
}
