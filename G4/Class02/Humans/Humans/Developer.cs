namespace Humans
{
    /// <summary>
    /// A developer is a human (inherit Human), and he knows how to code (implement IDeveloper)
    /// </summary>
    internal class Developer : Human, IDeveloper
    {
        /// <summary>
        /// A developer-specific property
        /// </summary>
        public List<string> ProgrammingLanguages { get; set; } = new List<string>();

        /// <summary>
        /// A developer-specific property
        /// </summary>
        public int YearsExperience { get; set; }

        /// <summary>
        /// Implementing IDeveloper
        /// </summary>
        public void Code()
        {
            Console.WriteLine("tak tak tak...");
            Console.WriteLine("*Opens Stack Overflow...");
            Console.WriteLine("tak tak tak tak tak...");
        }

        /// <summary>
        /// Because there's no default constructor in Human base class, developer constructor should
        /// AT LEAST cover the parameters of the 3-parameter constructor of it's base Human class
        /// </summary>
        public Developer(string fullname, int age, long phone, List<string> languages, int experience)
          : base(fullname, age, phone)
        {
            ProgrammingLanguages = languages;
            YearsExperience = experience;
        }

        /// <summary>
        /// Implement abstract method GetInfo from abstract class Human
        /// </summary>
        public override string GetInfo()
        {
            return $"{FullName} ({Age}) - {YearsExperience} years of experience!";
        }
    }
}
