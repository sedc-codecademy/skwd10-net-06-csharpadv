using Class13.TaxiManager9000.Domain.Enums;

namespace Class13.TaxiManager9000.Domain.Entities
{
    public class Driver : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int? CarId { get; set; }

        public Shift Shift { get; set; }
        public string License { get; set; }
        public DateTime LicenseExpieryDate { get; set; }

        public Driver(string firstname, string lastname, Shift shift, int? carId, string license, DateTime licenseExpieryDate)
        {
            Firstname = firstname;
            Lastname = lastname;
            CarId = carId;
            Shift = shift;
            License = license;
            LicenseExpieryDate = licenseExpieryDate;
        }
        public override string Print()
        {
            return $"{Id}){Firstname} {Lastname} Driving in the {Shift} shift.";
        }

        public ExpieryStatus IsLicenseExpired()
        {
            if (DateTime.Today >= LicenseExpieryDate)
            {
                return ExpieryStatus.Expired;
            }
            else if (DateTime.Today.AddMonths(3) >= LicenseExpieryDate)
            {
                return ExpieryStatus.Warning;
            }
            else
            {
                return ExpieryStatus.Valid;
            }
        }
    }
}
