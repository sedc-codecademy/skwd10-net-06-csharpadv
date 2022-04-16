using Class04.TaxiManager9000.Domain.Enums;

namespace Class04.TaxiManager9000.Domain.Entities
{
    public class Driver : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Car Car { get; set; }

        public ShiftEnum Shift { get; set; }
        public string License { get; set; }
        public DateTime LicenseExpieryDate { get; set; }

        public Driver(string firstname, string lastname, Car car, ShiftEnum shift, string license, DateTime licenseExpieryDate)
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
            string drivers = string.Empty;
            
            return $"Driver {Firstname} {Lastname} with license number {License} that expire on {LicenseExpieryDate.Month}/{LicenseExpieryDate.Year} drives car {Car.Model}({Car.Id})";
        }
    }
}
