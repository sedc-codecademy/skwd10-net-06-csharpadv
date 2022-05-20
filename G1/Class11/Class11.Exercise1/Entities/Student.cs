namespace Class11.Exercise1.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Student()
        {

        }

        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public override string Info()
        {
            return $"{Id}) {FirstName} {LastName}, {Age} years old.";
        }
    }
}
