using TaxiManager9000.Domain;

namespace TaxiManager9000.Services
{
    public interface ICarService : IServiceBase<Car>
    {
        bool IsAvailableCar(Car car);
    }
}
