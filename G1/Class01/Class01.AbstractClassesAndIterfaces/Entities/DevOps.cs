using Class01.AbstractClassesAndIterfaces.Entities.Interfaces;

namespace Class01.AbstractClassesAndIterfaces.Entities
{
    // We can inherit from multiple interfaces at a time
    public class DevOps : Human, IDeveloper, IOperations
	{
		public bool AWSCertified { get; set; }
		public bool AzureCertified { get; set; }
		public bool CheckInfrastructure(int status)
		{
			List<int> okStatuses = new List<int>() { 200, 202, 204 };
			if (okStatuses.Contains(status))
			{
				return true;
			}
			return false;
		}

		public DevOps(string fullname, int age, long phone, bool awsCert, bool azureCert)
			: base(fullname, age, phone)
		{
			AWSCertified = awsCert;
			AzureCertified = azureCert;
		}
		public void Code()
		{
			Console.WriteLine("tak tak tak...");
			Console.WriteLine("Open StackEchange DevOps...");
			Console.WriteLine("tak tak tak tak tak...");
		}

		public override string GetInfo()
		{
			string result = $"{FullName} ({Age}) - Has: ";
			result += AWSCertified ? "AWS Certificate" : "";
			result += AzureCertified ? " Azure Certificate" : "";
			result += AWSCertified || AzureCertified ? "" : "No certificates yet";
			return result;
		}
	}
}
