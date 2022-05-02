using TaxiManager9000.DataAccess.Interface;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Services.Interfaces;
using TaxiManager9000.Shared;

namespace TaxiManager9000.Services.Services
{
    public class MaintainanceService : IMaintainanceService
    {
        private readonly ICarDatabase _carDatabase;

        public MaintainanceService()
        {
            _carDatabase = DependencyResolver.GetService<ICarDatabase>();
        }

        public List<Car> ListAllCars()
        {
            List<Car> cars = _carDatabase.GetAll();

            return cars;
        }
    }
}
