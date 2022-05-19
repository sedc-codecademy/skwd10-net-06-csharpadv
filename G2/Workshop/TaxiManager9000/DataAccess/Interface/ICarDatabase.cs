using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.DataAccess.Interface
{
    public interface ICarDatabase : IFileDatabase<Car>
    {
        List<Car> GetAllAvailableCars(Shift shift);
    }
}
