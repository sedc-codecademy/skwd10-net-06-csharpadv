using Class01.Exersice01.Entities.interfaces;

namespace Class01.Exersice01.Entities
{
    internal class Teacher : User, ITeacher
    {
        public List<string> Subjects { get; set; }

        public void PrintSubjects()
        {
            Console.WriteLine($"The teacher {Name} teaches the following subjects:");
            foreach (var subject in Subjects)
            {
                Console.WriteLine(subject);
            }
        }

        public override void PrintUser()
        {
            Console.WriteLine($"The teacher {Name} with username {Username} teaches in total {Subjects.Count} subjects");
        }
    }
}
