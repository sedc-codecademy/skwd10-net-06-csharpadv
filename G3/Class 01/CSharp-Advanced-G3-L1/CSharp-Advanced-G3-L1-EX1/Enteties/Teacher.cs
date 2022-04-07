using CSharp_Advanced_G3_L1_EX1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Advanced_G3_L1_EX1.Enteties
{
    public class Teacher : User, ITeacher
    {
        public string Subject { get; set; }

        public override void PrintUser()
        {
            base.PrintUser();
            Console.WriteLine(Subject);
        }
    }
}
