using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class01.Demo.Entities
{
    public class Manager : Human
    {
        List<string> Subordinates { get; set; }

        public Manager(string name, string lastname, string department, List<string> subordinates) 
            : base(name, lastname, department)
        {
            Subordinates = subordinates;
        }

        public override string GetFullname()
        {
            return Name + " " + Lastname;
        }

        public void GetSubordinates()
        {
            Console.WriteLine($"Subordinates of {GetFullname()} are:");
            foreach (string subordinate in Subordinates)
            {
                Console.WriteLine(subordinate);
            }
        }
    }
}
