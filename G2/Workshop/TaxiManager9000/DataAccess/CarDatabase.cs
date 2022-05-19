using TaxiManager9000.DataAccess.Interface;
using TaxiManager9000.Domain.Entities;
using TaxiManager9000.Domain.Enums;

namespace TaxiManager9000.DataAccess
{
    public class CarDatabase : FileDatabase<Car>, ICarDatabase
    {
        public CarDatabase() : base()
        {
            Task.Run(async () => await SeedAsync()).Wait();
        }

        public List<Car> GetAllAvailableCars(Shift shift)
        {
            return GetAll().Where(x => !x.AssignedDrivers.Any(y => y.Shift == shift) && x.LicensePlateExpiryDate > DateTime.Now).ToList();
        }

        private async Task SeedAsync()
        {
            Car ford = new Car("Ford", "SK200AB", DateTime.UtcNow.AddDays(100));
            Car mazda = new Car("Mazda", "BT300RU", DateTime.UtcNow.AddDays(30));
            Car kia = new Car("KIA", "RE150BG", DateTime.UtcNow.AddDays(-40));
            Car bugatti = new Car("Bugatti", "BE1111BE", DateTime.UtcNow.AddDays(-200));

            Driver fordDriverOne = new Driver("Test", "DriverOne", Domain.Enums.Shift.Morning, "AB223", DateTime.UtcNow.AddDays(100), ford);
            Driver fordDriverTwo = new Driver("Test", "DriverTwo", Domain.Enums.Shift.Afternoon, "AB111", DateTime.UtcNow.AddDays(150), ford);
            Driver fordDriverThree = new Driver("Test", "DriverThree", Domain.Enums.Shift.Evening, "BCA123", DateTime.UtcNow.AddDays(70), ford);

            Driver mazdaDriverOne = new Driver("Test", "DriverFour", Domain.Enums.Shift.Morning, "AB223", DateTime.UtcNow.AddDays(-40), mazda);
            Driver mazdaDriverTwo = new Driver("Test", "DriverFive", Domain.Enums.Shift.Afternoon, "BB1412", DateTime.UtcNow.AddDays(99), mazda);

            ford.AssignDrivers(fordDriverOne, fordDriverTwo, fordDriverThree);
            mazda.AssignDrivers(mazdaDriverOne, mazdaDriverTwo);

            await InsertAsync(ford);
            await InsertAsync(mazda);
            await InsertAsync(kia);
            await InsertAsync(bugatti);
        }
    }
}
