using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enteties
{
    public class Admin : Person
    {
        public string Department { get; set; }

        public Admin(int id, string name, string lastName, string department) : base(id, name, lastName)
        {
            Department = department;
        }

        public override string GetInfo()
        {
            return $"{Name} {LastName} is admin to department {Department}";
        }
    }
}
