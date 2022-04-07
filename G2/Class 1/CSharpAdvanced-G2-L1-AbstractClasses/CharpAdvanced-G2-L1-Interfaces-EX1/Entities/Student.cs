using CharpAdvanced_G2_L1_Interfaces_EX1.Interfaces;

namespace CharpAdvanced_G2_L1_Interfaces_EX1.Entities
{
    public class Student : User, IStudent
    {
        public List<int> Grades { get; set; }

        public Student(int id, string name, string username, string password, List<int> grades) : base(id, name, username, password)
        {
            Grades = grades;
        }

        public override void PrintUser()
        {
            base.PrintUser();
            Grades.ForEach(Console.WriteLine);
        }
    }
}
