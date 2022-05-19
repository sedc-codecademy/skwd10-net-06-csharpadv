using TaxiManager9000.DataAccess.Interface;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;
using TaxiManager9000.Domain.Exceptions;
using TaxiManager9000.Services.Interfaces;
using TaxiManager9000.Shared;

namespace TaxiManager9000.Services.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IDriverDatabase _driverDatabase;
        private readonly ICarDatabase _carDatabase;

        public ManagerService()
        {
            _driverDatabase = DependencyResolver.GetService<IDriverDatabase>();
            _carDatabase = DependencyResolver.GetService<ICarDatabase>();
        }

        public List<Driver> ListAllDrivers()
        {
            List<Driver> drivers = _driverDatabase.GetAll();

            return drivers;
        }

        public List<Driver> ListUnassignedDrivers()
        {
            List<Driver> unassignedDrivers = _driverDatabase.GetUnassignedDrivers();

            return unassignedDrivers;
        }

        public List<Driver> ListAssignedDrivers()
        {
            List<Driver> assignedDrivers = _driverDatabase.GetAssignedDrivers();

            return assignedDrivers;
        }

        public List<Car> ListAllAvailableCars(Shift shift)
        {
            List<Car> availableCars = _carDatabase.GetAllAvailableCars(shift);

            return availableCars;
        }

        public async Task AssignDriverAsync(int driverId, int carId)
        {
            Driver driver = _driverDatabase.GetById(driverId);

            if (driver == null)
            {
                throw new NotFoundException($"Driver with id {driverId} doesn't exist");
            }

            Car car = _carDatabase.GetById(carId);

            if (car == null)
            {
                throw new NotFoundException($"Car with id {carId} doesn't exist");
            }

            car.AssignDrivers(driver);
            driver.AssingCar(car);

            await _carDatabase.UpdateAsync(car);
            await _driverDatabase.UpdateAsync(driver);
        }

        public async Task UnAssignDriverAsync(int driverId)
        {
            Driver driver = _driverDatabase.GetById(driverId);

            if (driver == null)
            {
                throw new NotFoundException($"Driver with id {driverId} doesn't exist");
            }
            Car car = driver.Car;

            car.UnAssignDriver(driver);
            await _carDatabase.UpdateAsync(car);

            driver.UnAssingnCar();
            await _driverDatabase.UpdateAsync(driver);
        }
    }
}
