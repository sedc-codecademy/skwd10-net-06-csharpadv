using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Developer : Person, IDeveloper
    {
        public string Project { get; set; }
        public int YearsOfExperiance { get; set; }
        public List<string> ProgrammingLanguages { get; set; }
        public override string GetInfo()
        {
            return $"{FirstName} {LastName} has {YearsOfExperiance} years of experiance and works on {Project}";
        }

        public void Code()
        {
            Console.WriteLine("Coding...");
        }

        public Developer(string firstName, string lastName, int age, long phoneNumber, string project, int experiance) 
            : base(firstName, lastName, age, phoneNumber)
        {
            Project = project;
            YearsOfExperiance = experiance;
            ProgrammingLanguages = new List<string>();
        }
    }
}
