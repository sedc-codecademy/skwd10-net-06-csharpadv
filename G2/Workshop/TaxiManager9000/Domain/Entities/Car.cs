namespace TaxiManager9000.Domain.Entities
{
    public class Car : BaseEntity
    {
        public string Model { get; set; } 

        public string LicensePlate { get; set; }

        public DateTime LicensePlateExpiryDate { get; set; }

        public List<Driver> AssignedDrivers { get; set; }

        // A car can be created without drivers being assigned to it
        public Car(string model, string licensePlate, DateTime licensePlateExpiryDate)
        {
            Model = model;
            LicensePlate = licensePlate;
            LicensePlateExpiryDate = licensePlateExpiryDate;
            AssignedDrivers = new List<Driver>();
        }

        public Car(string model, string licensePlate, DateTime licensePlateExpiryDate, List<Driver> assignedDrivers)
        {
            Model = model;
            LicensePlate = licensePlate;
            LicensePlateExpiryDate = licensePlateExpiryDate;
            AssignedDrivers = assignedDrivers;
        }

        public decimal GetShiftPercentageUtilization()
        {
            int anyMorningShiftDrivers = AssignedDrivers.Any(x => x.Shift == Enums.Shift.Morning) ? 1 : 0;
            int anyAfternoonShiftDrivers = AssignedDrivers.Any(x => x.Shift == Enums.Shift.Afternoon) ? 1 : 0;
            int anyEveningShiftDrivers = AssignedDrivers.Any(x => x.Shift == Enums.Shift.Evening) ? 1 : 0;


            return ((anyAfternoonShiftDrivers + anyMorningShiftDrivers + anyEveningShiftDrivers) / 3) * 100m;
        }
    }
}
