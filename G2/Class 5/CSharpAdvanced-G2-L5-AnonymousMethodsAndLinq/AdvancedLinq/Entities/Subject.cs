using AdvancedLinq.Enums;

namespace AdvancedLinq.Entities
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool isPartTime { get; set; }

        public Academy AcademyType { get; set; }

        public Subject(int id, string name, Academy academyType)
        {
            Id = id;
            Name = name;
            AcademyType = academyType;
        }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
