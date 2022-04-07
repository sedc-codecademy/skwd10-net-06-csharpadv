using CharpAdvanced_G2_L1_Interfaces_EX1.Interfaces;

namespace CharpAdvanced_G2_L1_Interfaces_EX1.Entities
{
    public class Teacher : User, ITeacher
    {
        public string Subject { get; set; }

        public Teacher(int id, string name, string username, string password, string subject) : base(id, name, username, password)
        {
            Subject = subject;
        }

        public override void PrintUser()
        {
            base.PrintUser();
            Console.WriteLine($"Subject is {Subject}");
        }

    }
}
