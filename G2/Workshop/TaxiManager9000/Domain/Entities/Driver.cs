using Newtonsoft.Json;
using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.Domain.Entities
{
    public class Driver : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Shift Shift { get; set; }

        public string License { get; set; }

        public DateTime LicenseExpiryDate { get; set; }

        public Car Car { get; set; }

        public Driver(string firstName, string lastName, Shift shift, string license, 
                      DateTime licenseExpiryDate, Car car) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            Shift = shift;
            License = license;
            LicenseExpiryDate = licenseExpiryDate;
            Car = car;
        }

        [JsonConstructor]
        public Driver(int id, string firstName, string lastName, Shift shift, string license,
              DateTime licenseExpiryDate, Car car) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Shift = shift;
            License = license;
            LicenseExpiryDate = licenseExpiryDate;
            Car = car;
        }


        public void AssingCar(Car car)
        {
            Car = car;
        }

        public void UnAssingnCar()
        {
            Car = null;
        }
    }
}
