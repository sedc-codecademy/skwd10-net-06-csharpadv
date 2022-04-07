using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingUnboxing.Entities
{
    public class Developer : Employee
    {
        public string Project { get; set; }
        public void Code() 
        { 
            Console.WriteLine("Coding ..."); 
        }
    }
}
