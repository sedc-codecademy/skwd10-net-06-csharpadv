using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCo.TaxiManager9000.Domain.Enums;

namespace TaxiCo.TaxiManager9000.Domain.Models
{
    public class Car : BaseEntity
    {
        public Car() {}

        public Car(string model, string licensePlace, DateTime licensePlateExp)
        {
            Model = model;
            LicensePlate = licensePlace;
            LicensePlateExpieryDate = licensePlateExp;
            AsignedDrivers = new List<Driver>();
        }

        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public DateTime LicensePlateExpieryDate { get; set; }
        public List<Driver> AsignedDrivers { get; set; }

        public override string Print()
        {
            int assignedPercent = AsignedDrivers.Count == 0 ? 0 : 100 / 3 * AsignedDrivers.Count + 1;
            return $"{Model} with License Plate {LicensePlate} and utilized {assignedPercent}%";
        }

        public ExpieryStatus IsLicenseExpired()
        {
            if (DateTime.Today >= LicensePlateExpieryDate) return ExpieryStatus.Expired;
            else if (DateTime.Today.AddMonths(3) >= LicensePlateExpieryDate) return ExpieryStatus.Warning;
            else return ExpieryStatus.Valid;
        }
    }
}
