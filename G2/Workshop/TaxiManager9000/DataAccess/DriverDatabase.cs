using TaxiManager9000.DataAccess.Interface;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public class DriverDatabase : FileDatabase<Driver>, IDriverDatabase
    {
        public DriverDatabase() : base()
        {
            Task.Run(async () => await SeedAsync()).Wait();
        }

        public List<Driver> GetAssignedDrivers()
        {
            return GetAll().Where(x => x.Car != null).ToList();
        }

        public List<Driver> GetUnassignedDrivers()
        {
            return GetAll().Where(x => x.Car == null).ToList();
        }

        private async Task SeedAsync()
        {
            Car ford = new Car("Ford", "SK200AB", DateTime.UtcNow.AddDays(100));
            Car mazda = new Car("Mazda", "BT300RU", DateTime.UtcNow.AddDays(30));

            await InsertAsync(new Driver("Test", "DriverOne", Domain.Enums.Shift.Morning, "AB223", DateTime.UtcNow.AddDays(100), ford));
            await InsertAsync(new Driver("Test", "DriverTwo", Domain.Enums.Shift.Afternoon, "AB111", DateTime.UtcNow.AddDays(150), ford));
            await InsertAsync(new Driver("Test", "DriverThree", Domain.Enums.Shift.Evening, "BCA123", DateTime.UtcNow.AddDays(70), ford));
            await InsertAsync(new Driver("Test", "DriverFour", Domain.Enums.Shift.Morning, "AB223", DateTime.UtcNow.AddDays(-40), mazda));
            await InsertAsync(new Driver("Test", "DriverFive", Domain.Enums.Shift.Afternoon, "BB1412", DateTime.UtcNow.AddDays(99), mazda));
        }
    }
}
