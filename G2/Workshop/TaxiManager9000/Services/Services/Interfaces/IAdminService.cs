using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Services.Interfaces
{
    public interface IAdminService
    {
        Task AddUserAsync(string userName, string password, Role role);

        Task TerminateUserAsync(string userName);

        List<User> ListAllUsers();

        Task ChangePasswordAsync(string userName, string password, string newPassword);
    }
}
