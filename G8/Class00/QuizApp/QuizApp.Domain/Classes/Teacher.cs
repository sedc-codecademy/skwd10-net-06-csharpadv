using QuizApp.Domain.Enums;

namespace QuizApp.Domain.Classes
{
    public class Teacher : User
    {
        public Teacher()
        {
            Role = Role.Teacher;
        }
    }
}
