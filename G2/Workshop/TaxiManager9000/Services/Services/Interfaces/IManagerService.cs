using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Services.Interfaces
{
    public interface IManagerService
    {
        List<Driver> ListAllDrivers();

        List<Driver> ListAssignedDrivers();

        List<Driver> ListUnassignedDrivers();

        List<Car> ListAllAvailableCars(Shift shift);

        Task AssignDriverAsync(int driverId, int carId);

        Task UnAssignDriverAsync(int driverId);
    }
}
