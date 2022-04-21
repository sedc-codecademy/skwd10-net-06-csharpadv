namespace Class06.Delegates.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExperianceInYears { get; set; }

        public void PromoteEmployee(Employee emp, EmployeeDelegate del)
        {
            del(emp);
        }
    }
}
