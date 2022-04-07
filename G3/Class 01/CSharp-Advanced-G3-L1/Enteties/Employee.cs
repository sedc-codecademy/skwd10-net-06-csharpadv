using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enteties
{
    public class Employee : Person
    {
        public int WorkHours { get; set; }

        public Employee(int id, string name, string lastName, int workHours) : base(id, name, lastName)
        {
            WorkHours = workHours;
        }

        public override string GetInfo()
        {
            return $"{Name} {LastName} WokrHours: {WorkHours}";
        }
    }
}
