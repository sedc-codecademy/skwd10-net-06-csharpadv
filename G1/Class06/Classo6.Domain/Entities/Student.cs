using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classo6.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsPartTime { get; set; }
        public List<Subject> Subjects { get; set; }
        public Student()
        {

        }
        public Student(int id, string first, string last, int age, bool partTime)
        {
            Id = id;
            FirstName = first;
            LastName = last;
            Age = age;
            IsPartTime = partTime;
        }

        public override string Info()
        {
            string studentType = "full-time";
            if (IsPartTime)
            {
                studentType = "part-time";
            }
            int subbjectCount = Subjects == null ? 0 : Subjects.Count;

            return $"Student {FirstName} {LastName} is {studentType} and attend {subbjectCount}";
        }
    }
}
