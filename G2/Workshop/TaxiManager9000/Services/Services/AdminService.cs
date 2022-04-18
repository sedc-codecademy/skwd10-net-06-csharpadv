using TaxiManager9000.DataAccess;
using TaxiManager9000.DataAccess.Interface;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Shared;

namespace TaxiManager9000.Services.Services
{
    public class AdminService
    {
        private readonly IUserDatabase _database;

        public AdminService()
        {
            _database = DepencyResolver.GetService<IUserDatabase>();
        }

        public void CreateUser(User user)
        {
            // Validations


        }
    }
}
