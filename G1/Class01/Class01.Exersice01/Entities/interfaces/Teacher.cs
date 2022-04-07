using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class01.Exersice01.Entities.interfaces
{
    internal class Teacher : User, ITeacher
    {
        public List<string> Subjects { get; set; }

        public void PrintSubjects()
        {
            Console.WriteLine($"the reacher {Name} theaches the following subjects:");
            foreach (string subject in Subjects)
            {
                Console.WriteLine(subject);
            }
        }

        public override void PrintUser()
        {
            Console.WriteLine($"The teacher {Name} with username {Username} has teach {Subjects.Count} subjects");
        }
    }
}
