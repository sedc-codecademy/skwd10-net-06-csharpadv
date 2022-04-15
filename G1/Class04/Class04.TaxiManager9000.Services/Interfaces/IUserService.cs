using Class04.TaxiManager9000.Domain.Entities;

namespace Class04.TaxiManager9000.Services.Interfaces
{
    public interface IUserService
    {
        User? Login(string username, string password);
        bool ChangePassword(int id, string oldPassword, string newPassword);
    }
}
