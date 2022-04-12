using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Operations : Person, IOperations
    {
        public List<string> Projects { get; set; } = new List<string>();
        public Operations(string firstName, string lastName, int age, long phoneNumber, List<string> projects)
            : base(firstName, lastName, age, phoneNumber)
        {
            Projects = projects;
        }
        public bool CheckInfrastructures(int status)
        {
            Console.WriteLine("Checking infrastructrure...");
            return true;
        }

        public override string GetInfo()
        {
            string projectMessage = "";
            try
            {
                foreach (string project in Projects)
                {
                    projectMessage += $" {project}";
                }
            }
            catch (NullReferenceException e)
            {
                projectMessage = "no projects";
            }
            return $"{FirstName} {LastName} works on \n {projectMessage}";
        }
    }
}
