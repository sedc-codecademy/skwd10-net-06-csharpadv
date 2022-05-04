using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Entities
{
    public class Subject : BaseEntity
    {
        public string Title { get; set; }
        public int Modules { get; set; }
        public int StudentAttending { get; set; }
        public Academy Type { get; set; }
        public Subject(int id, string title, int modules, int students, Academy type)
        {
            Id = id;
            Title = title;
            Modules = modules;
            StudentAttending = students;
            Type = type;
        }
        public override string Info()
        {
            return $"{Id}) {Title} of the {Type} Academy - {StudentAttending} attending!";
        }
    }

    public enum Academy
    {
        Programming,
        Design,
        Networks
    }
}
