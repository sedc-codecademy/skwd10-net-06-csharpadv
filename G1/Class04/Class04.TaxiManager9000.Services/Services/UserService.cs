using Class04.TaxiManager9000.Domain.Entities;
using Class04.TaxiManager9000.Services.Interfaces;

namespace Class04.TaxiManager9000.Services.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public User? Login(string username, string password)
        {
            var user = Db.GetAll().FirstOrDefault(x => x.Username == username && x.Password == password);
            return user;
        }

        public bool ChangePassword(int id, string oldPassword, string newPassword)
        {
            var user = Db.GetById(id);
            if (user.Password == oldPassword)
            {
                user.Password = newPassword;
                return true;
            }
            else
            {
                Console.WriteLine("Incorect old password inserted");
                return false;
            }
        }
    }
}
