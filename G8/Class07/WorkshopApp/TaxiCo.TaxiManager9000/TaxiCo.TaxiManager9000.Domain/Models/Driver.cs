using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCo.TaxiManager9000.Domain.Enums;

namespace TaxiCo.TaxiManager9000.Domain.Models
{
    public class Driver : BaseEntity
    {
        public Driver() { }
        public Driver(string firstName, string lastName, Shift shift, Car car, string license, DateTime licenseExpieryDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Shift = shift;
            Car = car;
            License = license;
            LicenseExpieryDate = licenseExpieryDate;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public Shift Shift { get; set; }
        private Car _car;
        public Car Car 
        {
            get => _car;
            set
            {
                if(value != null && _car == null)
                {
                    value.AsignedDrivers.Add(this);
                } else if(value == null && _car != null)
                {
                    _car.AsignedDrivers.Remove(this);
                }
                _car = value;
            }
        }
        public string License { get; set; }
        public DateTime LicenseExpieryDate { get; set; } 

        public override string Print()
        {
            string model = Car == null ? "/" : Car.Model;
            return $"{FullName} Driving in the {Shift} with {model} a car";
        }

        public ExpieryStatus IsLicenseExpired()
        {
            if (DateTime.Today >= LicenseExpieryDate) return ExpieryStatus.Expired;
            else if (DateTime.Today.AddMonths(3) >= LicenseExpieryDate) return ExpieryStatus.Warning;
            else return ExpieryStatus.Valid;
        }

    }
}
