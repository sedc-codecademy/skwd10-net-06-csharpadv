

using Newtonsoft.Json;

namespace CSharpAdvanced_G2_L10_FileDb.Entities
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Car Car { get; set; }

        public Person(string firstName, string lastName, int age, Car car) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Car = car;
        }

        [JsonConstructor]
        public Person(int id, string firstName, string lastName, int age, Car car) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Car = car;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {Age}";
        }
    }
}
