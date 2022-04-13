using CSharpAdvanced_G2_L1_Interfaces.Entities;

namespace CSharpAdvanced_G2_L1_Interfaces.Services
{
    public class StudentService : IUserService
    {
        public void LogIn(User user)
        {
            Console.WriteLine(user.Name + " student");
            // Add logic for student here
        }

        public void PrintInformation(User user)
        {
            Console.WriteLine(user.Name + " Is A Student");
        }
    }
}
