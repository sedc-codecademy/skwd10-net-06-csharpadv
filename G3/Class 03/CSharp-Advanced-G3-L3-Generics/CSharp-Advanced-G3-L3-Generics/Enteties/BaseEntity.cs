using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Advanced_G3_L3_Generics.Enteties
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Id: {Id}");
        }
    }
}
