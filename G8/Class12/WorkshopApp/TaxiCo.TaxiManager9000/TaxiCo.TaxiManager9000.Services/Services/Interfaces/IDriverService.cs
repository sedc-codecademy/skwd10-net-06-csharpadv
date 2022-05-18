using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCo.TaxiManager9000.Domain.Models;

namespace TaxiCo.TaxiManager9000.Services.Services.Interfaces
{
    public interface IDriverService : IBaseService<Driver>
    {
        void AssignDriver(Driver driver, Car car);
        void Unassign(Driver driver);
        bool IsAvailableDriver(Driver driver);
    }
}
