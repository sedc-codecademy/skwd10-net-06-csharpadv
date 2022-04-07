using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class00.Excercise2.Entities
{
    public static class UsernameAndPasswordDB
    {
        public static List<Student> Students = new List<Student>
        {
            new Student() { Username = "student_1", Password = "student", FirstName = "student_1_FirstName", LastName = "student_1_LastName" },
            new Student() { Username = "student_2", Password = "student", FirstName = "student_2_FirstName", LastName = "student_1_LastName" },
            new Student() { Username = "student_3", Password = "student", FirstName = "student_3_FirstName", LastName = "student_1_LastName" },
            
        };

        public static List<Teacher> Teachers = new List<Teacher>
        {
            new Teacher() { Username = "teacher", Password = "hristijan", FirstName = "Hristijan" ,  LastName ="Taseski" },
        };
    }
}
