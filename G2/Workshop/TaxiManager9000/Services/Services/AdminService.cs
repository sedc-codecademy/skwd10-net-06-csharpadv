using TaxiManager9000.DataAccess.Interface;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Exceptions;
using TaxiManager9000.Services.Interfaces;
using TaxiManager9000.Shared;

namespace TaxiManager9000.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUserDatabase _database;
        private readonly IAuthService _authService;

        public AdminService()
        {
            _database = DepencyResolver.GetService<IUserDatabase>();
        }

        public void AddUser(string userName, string password, Role role)
        {
            User user = new User(userName, password, role);

            User existingUser = _database.GetByUserName(user.UserName);

            if (existingUser != null)
            {
                throw new AlreadyExistsException($"The user already exists");
            }

            _database.Insert(user);
        }

        public void ChangePassword(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public void TerminateUser(string userName)
        {
            User existingUser = _database.GetByUserName(userName);

            if (existingUser == null)
            {
                throw new NotFoundException($"The user {userName} doesnt exist");
            }

            _database.Remove(existingUser);
        }
    }
}
