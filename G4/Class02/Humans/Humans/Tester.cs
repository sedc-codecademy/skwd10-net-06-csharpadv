namespace Humans
{
    /// <summary>
    /// A regular tester is a human (inherit Human), and knows how to test (implement ITester)
    /// </summary>
    internal class Tester : Human, ITester
    {
        /// <summary>
        /// A tester-specific property
        /// </summary>
        public int NumberOfBugsFound { get; }

        /// <summary>
        /// Because there's no default constructor in Human base class, tester constructor should
        /// AT LEAST cover the parameters of the 3-parameter constructor of it's base Human class
        /// </summary>
        public Tester(string fullname, int age, long phone, int numberOfBugsFound) : base(fullname, age, phone)
        {
            NumberOfBugsFound = numberOfBugsFound;
        }

        /// <summary>
        /// Implement abstract method GetInfo from abstract class Human
        /// </summary>
        public override string GetInfo()
        {
            return $"{FullName} ({Age}) - Has found {NumberOfBugsFound} bugs!";
        }

        /// <summary>
        /// Implement ITester and mark it virtual so we could allow modelling testers with higher seniority
        /// </summary>
        public virtual void TestFeature(string feature)
        {
            Console.WriteLine("click click click...");
            Console.WriteLine($"*Try to break feature {feature} intentionally...");
            Console.WriteLine("click click click...");
            Console.WriteLine($"Tests for the {feature} feature are done!");
        }
    }
}
