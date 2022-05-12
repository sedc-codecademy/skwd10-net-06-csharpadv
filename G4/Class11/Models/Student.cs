namespace Models
{
    public class Student : BaseEntity
    {
        public override int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsPartTime { get; set; }
    }
    
    // Enums can be deserialized by both
    // their numeric and string representation
    enum TestEnum
    {
        Option1 = 5,
        Option2 = 99
    }
}
