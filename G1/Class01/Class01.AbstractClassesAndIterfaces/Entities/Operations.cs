using Class01.AbstractClassesAndIterfaces.Entities.Interfaces;

namespace Class01.AbstractClassesAndIterfaces.Entities
{
    public class Operations : Human, IOperations
	{
		public List<string> Projects { get; set; } = new List<string>();
		public bool CheckInfrastructure(int status)
		{
			// Some arbitrary logic to simulate checking something
			if (status.ToString().StartsWith("4"))
			{
				return false;
			}
			return true;

		}
		public Operations(string fullname, int age, long phone, List<string> projects)
			: base(fullname, age, phone)
		{
			Projects = projects;
		}
		public override string GetInfo()
		{
			return $"{FullName} ({Age}) - Currently working on {Projects.Count} projects!";
		}
	}
}
