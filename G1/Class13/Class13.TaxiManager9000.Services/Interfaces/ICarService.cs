using Class13.TaxiManager9000.Domain.Entities;
using Class13.TaxiManager9000.Domain.Enums;

namespace Class13.TaxiManager9000.Services.Interfaces
{
    public interface ICarService : IBaseService<Car>
    {
        bool IsAvailableCar(Car car);
        void Seed(List<Car> seedCars);
        List<Car> GetAvailableCarsInShift(Shift shift);
    }
}
