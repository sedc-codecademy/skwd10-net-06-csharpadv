namespace Class04.TaxiManager9000.Domain.Entities
{
    public class Car : BaseEntity
    {
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public DateTime LicensePlateExpieryDate { get; set; }
        public List<Driver> AssignedDrivers { get; set; }

        public Car(string model, string licensePlate, DateTime licensePlateExpieryDate, List<Driver> assignedDrivers)
        {
            Model = model;
            LicensePlate = licensePlate;
            LicensePlateExpieryDate = licensePlateExpieryDate;
            AssignedDrivers = assignedDrivers;
        }

        public override string Print()
        {
            string drivers = string.Empty;
            foreach(Driver driver in AssignedDrivers)
            {
                drivers += driver.Firstname + " " + driver.Lastname + ",";
            }
            return $"Car {Model} with {LicensePlate} that expire on {LicensePlateExpieryDate.Month}/{LicensePlateExpieryDate.Year} is driven by {drivers}";
        }
    }
}
