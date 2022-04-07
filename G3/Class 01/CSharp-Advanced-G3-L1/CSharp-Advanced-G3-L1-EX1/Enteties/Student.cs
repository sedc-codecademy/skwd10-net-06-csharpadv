using CSharp_Advanced_G3_L1_EX1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Advanced_G3_L1_EX1.Enteties
{
    public class Student : User, IStudent
    {
        public List<int> Grades { get; set; }

        public override void PrintUser()
        {
            base.PrintUser();
            foreach(int grade in Grades)
            {
                Console.WriteLine(grade);
            }
        }
    }
}
