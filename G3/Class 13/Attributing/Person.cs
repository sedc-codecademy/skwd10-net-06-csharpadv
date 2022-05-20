using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributing
{
    internal class Person
    {
        public static int Value { get; set; }   
        public int ID { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string GetFullName(string prefix = null)
        {
            return $"{prefix} {FirstName} {LastName}";
        }
    }
}
