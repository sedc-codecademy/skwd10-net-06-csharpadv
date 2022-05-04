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
    public class CarService : BaseService<Car>, ICarService
    {
        public bool IsAvailable(Car car) =>
            car.IsLicenseExpired() == ExpieryStatus.Expired || car.AsignedDrivers.Count == 3 ? false : true;
    }
}
