using DomainRetro.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRetro.Classes
{
    public class Teacher : User, ITeacher
    {
        public List<string> Subjects { get; set; } = new List<string>();

        public void PrintSubjects()
        {
            Console.WriteLine("Subjects");
            foreach(string subject in Subjects)
            {
                Console.WriteLine(subject);
            }
        }

        public override void PrintUser()
        {
            Console.WriteLine($"Teacher {FirstName} {LastName}, teaches {Subjects.Count} subjects");
            PrintSubjects();
        }
    }
}
