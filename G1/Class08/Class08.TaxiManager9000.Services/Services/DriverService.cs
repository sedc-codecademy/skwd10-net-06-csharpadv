using Class08.TaxiManager9000.Domain.Entities;
using Class08.TaxiManager9000.Domain.Enums;
using Class08.TaxiManager9000.Services.Interfaces;

namespace Class08.TaxiManager9000.Services.Services
{
    public class DriverService : BaseService<Driver>, IDriverService
    {

        public void AssignDriver(Driver driver, Car car)
        {
            driver.Car = car;
            _db.Update(driver);
        }

        public void Unassign(Driver driver)
        {
            driver.Car = null;
            _db.Update(driver);
        }

        public List<Driver> GetUnassignedDrivers()
        {
            return _db.GetAll().Where(x => x.Car == null).ToList();
        }

        public List<Driver> GetAssignedDrivers()
        {
            return _db.GetAll().Where(x => x.Car != null).ToList();
        }

        public bool IsAvailableDriver(Driver driver) => driver.IsLicenseExpired() == ExpieryStatusEnum.Expired ? false : true;
    }
}
