namespace CSharpAdvanced_G2_L10_SerializationDeserialization.Entities
{
    [Serializable]
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }    

        public int Age { get; set; }

        public bool IsActive { get; set; }

        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            IsActive = true;
        }
    }
}
