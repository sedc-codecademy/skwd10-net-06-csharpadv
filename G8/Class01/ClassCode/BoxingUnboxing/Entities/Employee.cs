using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingUnboxing.Entities
{
    public class Employee
    {
        public string FullName { get; set; }
        public string Company { get; set; }
        public string GetInfo()
        {
            return $"{FullName} work in {Company}";
        }
    }
}
