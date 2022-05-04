using Class08.TaxiManager9000.Domain.Entities;
using Class08.TaxiManager9000.Domain.Enums;
using Class08.TaxiManager9000.Services.Interfaces;

namespace Class08.TaxiManager9000.Services.Services
{
    public class CarService : BaseService<Car>, ICarService
    {
        public List<Car> GetAvailableCarsInShift(ShiftEnum shift)
        {
            List<Car> cars = _db.GetAll().Where(x => x.LicensePlateExpieryDate > DateTime.Now 
                && !x.AssignedDrivers.Any(y => y.Shift == shift)).ToList();

            return cars;
        }

        public bool IsAvailableCar(Car car) =>
            car.IsLicenseExpired() == ExpieryStatusEnum.Expired || car.AssignedDrivers.Count == 3 ? false : true;
    }
}
