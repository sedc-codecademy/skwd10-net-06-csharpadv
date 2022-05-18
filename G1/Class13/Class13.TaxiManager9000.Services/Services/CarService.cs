using Class13.TaxiManager9000.Domain.Entities;
using Class13.TaxiManager9000.Domain.Enums;
using Class13.TaxiManager9000.Services.Interfaces;

namespace Class13.TaxiManager9000.Services.Services
{
    public class CarService : BaseService<Car>, ICarService
    {
        public List<Car> GetAvailableCarsInShift(Shift shift)
        {
            List<Car> cars = _db.GetAll().Where(x => x.LicensePlateExpieryDate > DateTime.Now
                && !x.AssignedDrivers.Any(y => y.Shift == shift)).ToList();

            return cars;
        }

        public bool IsAvailableCar(Car car) =>
            car.IsLicenseExpired() == ExpieryStatus.Expired || car.AssignedDrivers.Count == 3 ? false : true;
    }
}
