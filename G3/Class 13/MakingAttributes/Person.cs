using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingAttributes
{
    // The class person represents the data that describes a person
    [ClassDescription("The class person represents the data that describes a person")]
    internal class Person
    {
        // This is the ID for the person class
        [ProprertyDescription("This is the ID for the person class")]
        public int ID { get; set; }

        // This is the first name for the person class
        [ProprertyDescription("This is the first name for the person class")]
        public string FirstName { get; set; }

        // This is the last name for the person class
        [ProprertyDescription("his is the last name for the person class")]
        public string LastName { get; set; }

    }
}
