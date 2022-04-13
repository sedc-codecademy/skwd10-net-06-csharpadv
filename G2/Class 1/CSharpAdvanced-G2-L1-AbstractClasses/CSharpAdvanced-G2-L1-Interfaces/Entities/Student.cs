using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced_G2_L1_Interfaces.Entities
{
    public class Student : User
    {
        public string ClassName { get; set; }

        public Student(string name, string className) : base(name)
        {
            ClassName = className;
        }
    }
}
