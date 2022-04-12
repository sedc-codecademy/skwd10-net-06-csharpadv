using Class01.AbstractClassesAndIterfaces.Entities.Interfaces;

namespace Class01.AbstractClassesAndIterfaces.Entities
{
    public class Tester : Human, ITester
	{
		public int BugsFound { get; set; }
		public void TestFeature(string feature)
		{
			Console.WriteLine($"{feature} is being tested...");
			Console.WriteLine("Testing complete!");
		}
		public Tester(string fullname, int age, long phone, int bugs)
			: base(fullname, age, phone)
		{
			BugsFound = bugs;
		}
		public override string GetInfo()
		{
			return $"{FullName} ({Age}) - found {BugsFound} bugs to date!";
		}
	}
}
