using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Advanced_G3_L3_Generics.Enteties
{
    public class GenericMethods
    {
        public string MyProperty { get; set; }

        public void PrintObject<TFirst, TSecond>(TFirst objetToPrint, TSecond secondObject)
        {
            Console.WriteLine(objetToPrint);
            Console.WriteLine(typeof(TFirst));
            Console.WriteLine(typeof(TSecond));
            Console.WriteLine(secondObject);
        }
    }
}
