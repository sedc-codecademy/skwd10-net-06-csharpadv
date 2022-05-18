using Class13.TaxiManager9000.Domain.Entities;

namespace Class13.TaxiManager9000.Services.Interfaces
{
    public interface IDriverService : IBaseService<Driver>
    {
        void AssignDriver(Driver driver, Car car);
        void Unassign(Driver driver);
        bool IsAvailableDriver(Driver car);

        List<Driver> GetUnassignedDrivers();

        List<Driver> GetAssignedDrivers();

        void Seed(List<Driver> seedDrivers);
    }
}
