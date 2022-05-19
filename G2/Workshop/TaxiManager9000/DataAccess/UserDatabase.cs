using TaxiManager9000.DataAccess.Interface;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public class UserDatabase : FileDatabase<User>, IUserDatabase
    {
        public UserDatabase()
        {
            Task.Run(async () => await SeedAsync()).Wait();
        }

        public User GetByUserNameAndPassword(string username, string password)
        {
            return Items.FirstOrDefault(user => user.UserName == username &&
                                                 user.Password == password);
        }

        public User GetByUserName(string username)
        {
            return Items.FirstOrDefault(user => user.UserName == username);
        }

        private async Task SeedAsync()
        {
            await InsertAsync(new User("test0", "test1", Domain.Enums.Role.Administrator));
            await InsertAsync(new User("test1", "test1", Domain.Enums.Role.Manager));
            await InsertAsync(new User("test2", "test1", Domain.Enums.Role.Maintainance));
            await InsertAsync(new User("test3", "test1", Domain.Enums.Role.Administrator));
        }
    }
}
