namespace Humans
{
    /// <summary>
    /// A QA engineer is primarily a tester (inherit Tester), but can do some coding (implement IDeveloper)
    /// 
    /// There's no elegant way to do inheritance from two classes (Developer and Tester) in case we want to
    /// take the IDeveloper.Code() method from Developer class and not do separate implementation. Besides, even if we manage
    /// to do it, the inheritance hierarchy will grow a lot (which we don't want to complicate our lives),
    /// so we inherit tester and implement IDeveloper with a separate implementation for the IDeveloper.Code() method.
    /// 
    /// How you would mix and match inheriting base classes and implementing interfaces usually boils down to
    /// common-sense, the business requirements, and deciding what is the least complex way to do it - no hard rules.
    /// </summary>
    internal class QAEngineer : Tester, IDeveloper
    {
        /// <summary>
        /// A QA engineer-specific property
        /// </summary>
        public List<string> TestingFrameworks { get; set; }

        /// <summary>
        /// Implementing IDeveloper
        /// </summary>
        public void Code()
        {
            Console.WriteLine("tak tak tak...");
            Console.WriteLine("Open StackEchange SQA...");
            Console.WriteLine("tak tak tak tak tak...");
        }

        /// <summary>
        /// Because there's no default constructor in Tester base class, QA engineer constructor should
        /// AT LEAST cover the parameters of the 4-parameter constructor of it's base Tester class
        /// </summary>
        public QAEngineer(string fullname, int age, long phone, int numberOfBugsFound, List<string> frameworks)
          : base(fullname, age, phone, numberOfBugsFound)
        {
            TestingFrameworks = frameworks;
        }

        /// <summary>
        /// This is already implemented in Tester base class - if we don't override it, invoking QAEngineer.GetInfo()
        /// will behave the same as Tester class.
        /// </summary>
        public override string GetInfo()
        {
            return $"{FullName} ({Age}) - Knows {(TestingFrameworks.Count != 0 ? TestingFrameworks[0] : "unknown")} testing frameworks, and has found {NumberOfBugsFound} bugs!";
        }

        /// <summary>
        /// This is already implemented in Tester base class - if we don't override it, invoking QAEngineer.TestFeature()
        /// will behave the same as Tester class.
        /// </summary>
        public override void TestFeature(string feature)
        {
            Console.WriteLine("Run Unit Tests...");
            Console.WriteLine("Run Automated Tests...");
            Console.WriteLine($"Tests for the {feature} feature are done!");
        }
    }
}
