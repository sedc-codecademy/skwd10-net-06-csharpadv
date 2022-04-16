using DomainRetro.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRetro.Classes
{
    public class Student : User, IStudent
    {
        public List<int> Grades { get; set; }

        public Student()
        {
            Grades = new List<int>();
        }

        public void PrintGrades()
        {
            Console.WriteLine("Grades:");
            foreach(int grade in Grades)
            {
                Console.WriteLine($"{grade}");
            }
            Console.WriteLine();
        }

        public override void PrintUser()
        {
            Console.WriteLine($"Student: {FirstName} {LastName}, average grade: {Grades.Sum() / (double)Grades.Count} ");
        }
    }
}
