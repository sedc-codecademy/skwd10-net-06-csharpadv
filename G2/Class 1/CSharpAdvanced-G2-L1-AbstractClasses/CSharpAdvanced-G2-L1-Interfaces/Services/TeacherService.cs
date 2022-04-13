using CSharpAdvanced_G2_L1_Interfaces.Entities;

namespace CSharpAdvanced_G2_L1_Interfaces.Services
{
    public class TeacherService : IUserService
    {
        public void LogIn(User user)
        {
            Console.WriteLine(user.Name + " Teacher");
            // Add logic for teacher here
        }

        public void PrintInformation(User user)
        {
            Console.WriteLine(user.Name + " is a teacher");
        }
    }
}
