using Class13.TaxiManager9000.Domain.Entities;
using Class13.TaxiManager9000.Domain.Enums;
using Class13.TaxiManager9000.Services.Interfaces;

namespace Class13.TaxiManager9000.Services.Services
{
    public class DriverService : BaseService<Driver>, IDriverService
    {

        public void AssignDriver(Driver driver, Car car)
        {
            driver.CarId = car.Id;
            _db.Update(driver);
        }

        public void Unassign(Driver driver)
        {
            driver.CarId = null;
            _db.Update(driver);
        }

        public List<Driver> GetUnassignedDrivers()
        {
            return _db.GetAll().Where(x => x.CarId == null).ToList();
        }

        public List<Driver> GetAssignedDrivers()
        {
            return _db.GetAll().Where(x => x.CarId != null).ToList();
        }

        public bool IsAvailableDriver(Driver driver) => driver.IsLicenseExpired() == ExpieryStatus.Expired ? false : true;
    }
}
