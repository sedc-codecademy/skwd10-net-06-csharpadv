using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCo.TaxiManager9000.Domain.Enums;
using TaxiCo.TaxiManager9000.Domain.Models;
using TaxiCo.TaxiManager9000.Services.Services.Interfaces;

namespace TaxiCo.TaxiManager9000.Services.Services
{
    public class DriverService : BaseService<Driver>, IDriverService
    {
        public void AssignDriver(Driver driver, Car car)
        {
            driver.Car = car;
            _db.Update(driver);
        }

        public bool IsAvailableDriver(Driver driver) =>
            driver.IsLicenseExpired() == ExpieryStatus.Expired ? false : true;

        public void Unassign(Driver driver)
        {
            driver.Car = null;
            _db.Update(driver);
        }
    }
}
