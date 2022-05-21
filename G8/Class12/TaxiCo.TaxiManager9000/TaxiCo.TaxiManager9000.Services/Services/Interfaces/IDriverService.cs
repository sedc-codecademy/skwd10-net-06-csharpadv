using TaxiManager9000.Domain;

namespace TaxiManager9000.Services
{
    public interface IDriverService : IServiceBase<Driver>
    {
        void AssignDriver(Driver driver, Car car);
        void Unassign(Driver driver);
        bool IsAvailableDriver(Driver car);
    }
}
