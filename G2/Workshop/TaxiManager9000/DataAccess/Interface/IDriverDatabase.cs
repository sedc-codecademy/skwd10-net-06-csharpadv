using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess.Interface
{
    public interface IDriverDatabase : IFileDatabase<Driver>
    {
        List<Driver> GetUnassignedDrivers();

        List<Driver> GetAssignedDrivers();
    }
}
