namespace AdvancedLinq.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Subject> Subjects { get; set; }

        public Student(int id, string firstName, string lastName, List<Subject> subjects)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Subjects = subjects;
        }

        public override string ToString()
        {
            return $"{Id} - {FirstName} - {LastName}";
        }
    }
}
