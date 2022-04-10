using Class02.Exerscise01.Entities;

namespace Class02.Exerscise01.Services.Interfaces
{
    public interface ICarManagementService
    {
        void PrintAllCars();
        List<Car> GetAllVeryFastCars();
    }
}
