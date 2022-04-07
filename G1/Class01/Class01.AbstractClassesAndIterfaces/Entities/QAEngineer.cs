using Class01.AbstractClassesAndIterfaces.Entities.Interfaces;

namespace Class01.AbstractClassesAndIterfaces.Entities
{
    // We can inherit from multiple interfaces at a time
    public class QAEngineer : Human, IDeveloper, ITester
	{
		public List<string> TestingFrameworks { get; set; }
		public void Code()
		{
			Console.WriteLine("tak tak tak...");
			Console.WriteLine("Open StackEchange SQA...");
			Console.WriteLine("tak tak tak tak tak...");
		}
		public QAEngineer(string fullname, int age, long phone, List<string> frameworks)
			: base(fullname, age, phone)
		{
			TestingFrameworks = frameworks;
		}
		public override string GetInfo()
		{
			return $"{FullName} ({Age}) - Knows {(TestingFrameworks.Count != 0 ? TestingFrameworks[0] : "unknown")} testing frameworks!";
		}

		public void TestFeature(string feature)
		{
			Console.WriteLine("Run Unit Tests...");
			Console.WriteLine("Run Automated Tests...");
			Console.WriteLine($"Tests for the {feature} feature are done!");
		}
	}
}
