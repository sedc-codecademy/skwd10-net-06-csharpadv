using Class08.TaxiManager9000.Domain.Enums;

namespace Class08.TaxiManager9000.Domain.Entities
{
    public class Car : BaseEntity
    {
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public DateTime LicensePlateExpieryDate { get; set; }
        public List<Driver> AssignedDrivers { get; set; }

        public Car(string model, string licensePlate, DateTime licensePlateExpieryDate)
        {
            Model = model;
            LicensePlate = licensePlate;
            LicensePlateExpieryDate = licensePlateExpieryDate;
            AssignedDrivers = new List<Driver>();
        }

        public override string Print()
        {
            int assignedPercent = AssignedDrivers.Count == 0 ? 0 : 100 / 3 * AssignedDrivers.Count + 1;
            return $"{Id}){Model} with License Plate {LicensePlate} and utilized {assignedPercent}%";
        }

        public ExpieryStatusEnum IsLicenseExpired()
        {
            if (DateTime.Today >= LicensePlateExpieryDate)
            {
                return ExpieryStatusEnum.Expired;
            }
            else if (DateTime.Today.AddMonths(3) >= LicensePlateExpieryDate)
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
