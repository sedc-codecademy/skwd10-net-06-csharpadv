using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.Services.Interfaces
{
    public interface IMaintainanceService
    {
        List<Car> ListAllCars();
    }
}
