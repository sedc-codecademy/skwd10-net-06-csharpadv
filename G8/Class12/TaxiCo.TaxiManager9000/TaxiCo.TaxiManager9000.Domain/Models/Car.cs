namespace TaxiManager9000.Domain
{
    public class Car : BaseEntity
    {
        public Car() { }
        public Car(string model, string licensePlate, DateTime experyDate)
        {
            Model = model;
            LicensePlate = licensePlate;
            LicensePlateExpieryDate = experyDate;
            DriversAssigned = new List<Driver>();
        }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public DateTime LicensePlateExpieryDate { get; set; }
        public List<Driver> DriversAssigned { get; set; }

        public override string Print()
        {
            int assignedPercent = DriversAssigned.Count == 0 ? 0 : 100 / 3 * DriversAssigned.Count + 1;
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
