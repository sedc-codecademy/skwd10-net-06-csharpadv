using TaxiManager9000.DataAccess;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Exceptions;
using TaxiManager9000.Services.Interfaces;

namespace TaxiManager9000.Services
{
    public class AuthService : IAuthService
    {
        public User CurrentUser { get; private set; }

        private static UserDatabase _database;

        public AuthService()
        {
            _database = new UserDatabase();
        }

        public void LogIn(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("Username is empty");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Password is empty");
            }

            User currentUser = _database.GetByUserNameAndPassword(username, password);

            if (currentUser == null)
            {
                throw new InvalidCredentialsException("Invalid credentials");
            }

            CurrentUser = currentUser;
        }
    }
}
