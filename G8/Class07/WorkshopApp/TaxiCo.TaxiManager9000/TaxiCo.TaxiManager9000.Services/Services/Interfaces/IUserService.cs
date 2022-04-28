using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCo.TaxiManager9000.Domain.Models;

namespace TaxiCo.TaxiManager9000.Services.Services.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        User CurrentUser { get; set; }
        void LogIn(string username, string password);
        bool ChangePassword(string oldPassword, string newPassword);
    }
}
