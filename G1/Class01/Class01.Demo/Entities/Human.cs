using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class01.Demo.Entities
{
    public abstract class Human
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Department { get; set; }
        public abstract string GetFullname();

        public Human(string name, string lastname, string department)
        {
            Name = name;
            Lastname = lastname;
            Department = department;
        }

        public string GetInfo(string requester)
        {
            return $"Hello {requester}! I am {Name} {Lastname} an I anm from department {Department}";
        }
    }
}
