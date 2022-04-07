namespace CSharpAdvanced_G2_L1_AbstractClasses_EX1.Entities
{
    public abstract class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int WorkingHours { get; set; }

        protected double Salary;

        public Employee(int id, string firstName, string lastName, int workingHours)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            WorkingHours = workingHours;
            Salary = 10000.00;
        }

        public abstract void Work();

        public abstract double GetSalary();

        public virtual string GetInfo()
        {
            return $"{FirstName} {LastName} Working Hours : {WorkingHours}";
        }
    }
}
