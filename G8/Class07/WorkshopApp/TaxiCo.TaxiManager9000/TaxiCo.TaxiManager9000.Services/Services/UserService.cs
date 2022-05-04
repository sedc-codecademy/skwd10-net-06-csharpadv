using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCo.TaxiManager9000.Domain.Models;
using TaxiCo.TaxiManager9000.Services.Services.Interfaces;

namespace TaxiCo.TaxiManager9000.Services.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public User CurrentUser { get; set; }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            User user = _db.GetById(CurrentUser.Id);
            if (user.Password != oldPassword) return false;
            user.Password = newPassword;
            _db.Update(user);
            return true;
        }

        public void LogIn(string username, string password)
        {
            CurrentUser = _db.GetAll().SingleOrDefault(x => x.Username == username.ToLower() && x.Password == password);
            if (CurrentUser == null) throw new Exception("Login failed. Please try again...");
        }
    }
}
