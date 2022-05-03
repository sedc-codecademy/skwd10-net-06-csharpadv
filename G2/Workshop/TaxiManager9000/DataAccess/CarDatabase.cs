using TaxiManager9000.DataAccess.Interface;
using TaxiManager9000.Domain.Entities;

namespace TaxiManager9000.DataAccess
{
    public class CarDatabase : Database<Car>, ICarDatabase
    {
        public CarDatabase() : base()
        {
            Seed();
        }

        private void Seed()
        {
            _items.AddRange(new List<Car>()
            {
                new Car("Ford", "SK200AB", DateTime.UtcNow.AddDays(100)),
                new Car("Mazda", "BT300RU", DateTime.UtcNow.AddDays(30)),
                new Car("KIA", "RE150BG", DateTime.UtcNow.AddDays(-40)),
                new Car("Bugatti", "BE1111BE", DateTime.UtcNow.AddDays(-200)),
            });
        }
    }
}
