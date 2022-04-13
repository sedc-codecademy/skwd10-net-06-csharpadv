using CSharpAdvanced_G2_L1_Interfaces.Entities;

namespace CSharpAdvanced_G2_L1_Interfaces.Services
{
    public interface IUserService
    {
        void LogIn(User user);

        void PrintInformation(User user);
    }
}
