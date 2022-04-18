using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.Services.Interfaces
{
    public interface IAuthService 
    {
        User CurrentUser { get; }

        void LogIn(string username, string password);
    }
}
