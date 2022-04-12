namespace Humans // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Will not compile and show error (Human is an abstract class)
            //Human person = new Human();
            // Will compile since it just inherits from the abstract
            Developer dev = new Developer("Bob Bobsky", 44, 38970070070, new List<string>() { "JavaScript", "C#", "HTML", "CSS" }, 6);
            Tester tester = new Tester("Jill Wayne", 32, 38971071071, 560);
            QAEngineer qaEngineer = new QAEngineer("Clark Parker", 40, 3872198321, 2836, new List<string> { "Selenium", "Protractor" });

            HappyBirthday(dev); // Will call GetInfo() implementation from Developer
            HappyBirthday(tester); // Will call GetInfo() implementation from Tester
            HappyBirthday(qaEngineer);
        }

        // IHuman makes sure that the GetInfo() method will be implemented
        // Anyone who implements IHuman in their chain can be accepted here
        public static void HappyBirthday(IHuman person)
        {
            Console.WriteLine($"This is {person.GetInfo()}!");
            Console.WriteLine("They say:");
            person.Greet("everyone");
            Console.WriteLine("Happy birthday! We are glad that you are part of this company!");
        }
    }
}