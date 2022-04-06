using Class00.Excercise2.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class00.Excercise2.Entities
{
    public class Teacher:User
    {
        public Role Role { get; set; } = Role.Teacher;
    }
}
