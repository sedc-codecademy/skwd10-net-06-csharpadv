namespace CSharpAdvanced_G2_L1_AbstractClasses_EX1.Entities
{
    public class Developer : Employee // Developer EXTENDS/INHERITS FROM Employee
    {
        public string CurrentProjectName { get; set; }

        public Developer(int id, string firstName, string lastName, int workingHours,
                         string currentProjectName) : base(id, firstName, lastName, workingHours)
        {
            CurrentProjectName = currentProjectName;
        }

        public override double GetSalary()
        {
            return Salary * WorkingHours;
        }

        public override void Work()
        {
            Console.WriteLine($"{FirstName} {LastName} is writing code in {CurrentProjectName}");
        }
    }
}
