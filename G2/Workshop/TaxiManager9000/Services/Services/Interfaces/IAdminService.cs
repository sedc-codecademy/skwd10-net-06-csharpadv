using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Services.Interfaces
{
    public interface IAdminService
    {
        void AddUser(string userName, string password, Role role);

        void TerminateUser(string userName);

        List<User> ListAllUsers();

        void ChangePassword(string userName, string password, string newPassword);
    }
}
