using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingStrings
{
    internal record Person (string FirstName, string LastName, string City)
    {
        public override string ToString()
        {
            return $"{FirstName} {LastName} from {City}";
        }
    }
}
