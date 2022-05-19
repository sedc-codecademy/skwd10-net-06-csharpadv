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

        public AdminService()
        {
            _database = DependencyResolver.GetService<IUserDatabase>();
        }

        public async Task AddUserAsync(string userName, string password, Role role)
        {
            User user = new User(userName, password, role);

            User existingUser = _database.GetByUserName(user.UserName);

            if (existingUser != null)
            {
                throw new AlreadyExistsException($"The user already exists");
            }

            await _database.InsertAsync(user);
        }

        public List<User> ListAllUsers()
        {
            List<User> users = _database.GetAll();

            return users;
        }

        public async Task ChangePasswordAsync(string userName, string password, string newPassword)
        {
            User existingUser = _database.GetByUserNameAndPassword(userName, password);

            if (existingUser == null)
            {
                throw new NotFoundException($"The user {userName} does not exist");
            }

            existingUser.SetPassword(newPassword);

            await _database.UpdateAsync(existingUser);
        }

        public async Task TerminateUserAsync(string userName)
        {
            User existingUser = _database.GetByUserName(userName);

            if (existingUser == null)
            {
                throw new NotFoundException($"The user {userName} doesnt exist");
            }

            await _database.RemoveAsync(existingUser);
        }
    }
}
