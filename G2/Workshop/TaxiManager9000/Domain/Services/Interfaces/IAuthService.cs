using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.Domain.Services.Interfaces
{
    public interface IAuthService
    {
        User LogIn(string username, string password);
    }
}
