using Class01.AbstractClassesAndIterfaces.Entities.Interfaces;

namespace Class01.AbstractClassesAndIterfaces.Entities
{
	public abstract class Human : IHuman
	{
		public string FullName { get; set; }
		public int Age { get; set; }
		public long Phone { get; set; }
		public abstract string GetInfo();
		public Human(string fullname, int age, long phone)
		{
			FullName = fullname;
			Age = age;
			Phone = phone;
		}
		public void Greet(string name)
		{
			Console.WriteLine($"Hey there {name}! My name is {FullName}!");
		}
	}
}
