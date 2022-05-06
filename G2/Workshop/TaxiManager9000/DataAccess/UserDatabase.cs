using TaxiManager9000.DataAccess.Interface;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public class UserDatabase : Database<User>, IUserDatabase
    {
        private readonly List<User> _users;

        public UserDatabase()
        {
            _users = new List<User>();
            Seed();
        }

        public User GetByUserNameAndPassword(string username, string password)
        {
            return _users.FirstOrDefault(user => user.UserName == username &&
                                                 user.Password == password);
        }

        public User GetByUserName(string username)
        {
            return _users.FirstOrDefault(user => user.UserName == username);
        }

        private void Seed()
        {
            _users.AddRange(new List<User>()
            {
                AutoIncrementId(new User("test0", "test1", Domain.Enums.Role.Administrator)),
                AutoIncrementId(new User("test1", "test1", Domain.Enums.Role.Manager)),
                AutoIncrementId(new User("test2", "test1", Domain.Enums.Role.Maintainance)),
                AutoIncrementId(new User("test3", "test1", Domain.Enums.Role.Administrator))
            });
        }
    }
}
