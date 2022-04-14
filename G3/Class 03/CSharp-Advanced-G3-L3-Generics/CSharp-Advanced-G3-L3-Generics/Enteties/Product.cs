using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Advanced_G3_L3_Generics.Enteties
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"{Title} - {Description}");
        }

        public override string ToString()
        {
            return $"{Title} - {Description}";
        }
    }
}
