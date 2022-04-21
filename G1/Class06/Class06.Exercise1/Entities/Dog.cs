using Class06.Exercise1.Enums;

namespace Class06.Exercise1.Entities
{
    public class Dog : BaseEntity
    {
		public string Name { get; set; }
		public string Color { get; set; }
		public int Age { get; set; }
		public Race Race { get; set; }

		public Dog(string name, string color, int age, Race race)
		{
			Name = name;
			Color = color;
			Age = age;
			Race = race;
		}

        public override string Info()
        {
			return $"Dog: {Name} age: {Age} breed: {Race}";
        }
    }
}
