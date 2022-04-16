using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Services.Interfaces;

namespace TaxiManager9000.Domain.Services
{
    public class AuthService : IAuthService
    {
        public User LogIn(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username is empty");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Password is empty");
            }

            User user = new User(1, username, password, Role.Administrator);

            return user;
        }
    }
}
