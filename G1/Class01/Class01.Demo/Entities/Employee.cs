using Class01.Demo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class01.Demo.Entities
{
    public class Employee : Human, IEmployee
    {
        int WorkingHours { get; set; }
        public Employee(string name, string lastname, string department, int workingHours) : base(name, lastname, department)
        {
                WorkingHours = workingHours;
        }

        public override string GetFullname()
        {
            throw new NotImplementedException();
        }

        public int getWorkingHours()
        {
            return WorkingHours;
        }
    }
}
