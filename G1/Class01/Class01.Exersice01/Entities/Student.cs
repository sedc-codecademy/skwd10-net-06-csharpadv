using Class01.Exersice01.Entities.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class01.Exersice01.Entities
{
    public class Student : User, IStudent
    {
        public List<int> Grades { get; set; }

        public void PrintGrades()
        {
            Console.WriteLine($"The student {Name} have the following grades");
            foreach (var grade in Grades)
            {
                Console.WriteLine(grade);
            }
        }

        public override void PrintUser()
        {
            Console.WriteLine($"The student {Name} with username {Username} has average grade {(double)Grades.Sum()/Grades.Count}");
        }
    }
}
