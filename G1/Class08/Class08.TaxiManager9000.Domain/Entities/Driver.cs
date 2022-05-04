using Class08.TaxiManager9000.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class08.TaxiManager9000.Domain.Entities
{
    public class Driver : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Car? Car { get; set; }

        public ShiftEnum Shift { get; set; }
        public string License { get; set; }
        public DateTime LicenseExpieryDate { get; set; }

        public Driver(string firstname, string lastname, ShiftEnum shift, Car car, string license, DateTime licenseExpieryDate)
        {
            Firstname = firstname;
            Lastname = lastname;
            Car = car;
            Shift = shift;
            License = license;
            LicenseExpieryDate = licenseExpieryDate;
        }
        public override string Print()
        {
            string model = Car == null ? "/" : Car.Model;
            return $"{Id}){Firstname} {Lastname} Driving in the {Shift} shift with a {model} car";
        }

        public ExpieryStatusEnum IsLicenseExpired()
        {
            if (DateTime.Today >= LicenseExpieryDate)
            {
                return ExpieryStatusEnum.Expired;
            }
            else if (DateTime.Today.AddMonths(3) >= LicenseExpieryDate)
            {
                return ExpieryStatusEnum.Warning;
            }
            else
            {
                return ExpieryStatusEnum.Valid;
            }
        }
    }
}
