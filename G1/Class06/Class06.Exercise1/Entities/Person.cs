using Class06.Exercise1.Enums;

namespace Class06.Exercise1.Entities
{
    public class Person : BaseEntity
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public Job Occupation { get; set; }
		public List<Dog> Dogs { get; set; }

		public Person(string firstName, string lastName, int age, Job occupation)
		{
			FirstName = firstName;
			LastName = lastName;
			Age = age;
			Occupation = occupation;
			Dogs = new List<Dog>();
		}

        public override string Info()
        {
			string ownsADog = "does not own a dog";
			if (Dogs.Count > 0)
            {
				ownsADog = $"owns {Dogs.Count} dogs";
            }
			return $"{FirstName} {LastName} age {Age} {ownsADog}";
        }
    }
}
