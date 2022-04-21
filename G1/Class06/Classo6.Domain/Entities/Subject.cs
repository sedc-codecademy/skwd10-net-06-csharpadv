using Classo6.Domain.enums;

namespace Classo6.Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Title { get; set; }
        public int Modules { get; set; }
        public int StudentsAttending { get; set; }
        public Academy Type { get; set; }

        public Subject(int id, string title, int modules, int students, Academy type)
        {
            Id = id;
            Title = title;
            Modules = modules;
            StudentsAttending = students;
            Type = type;
        }

        public override string Info()
        {
            return $"Subject \"{Title}\" has {Modules} modules and is attended by {StudentsAttending}";
        }
    }
}
