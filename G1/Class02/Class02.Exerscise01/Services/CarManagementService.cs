using Class02.Exerscise01.Entities;

namespace Class02.Exerscise01
{
    internal class CarManagementService
    {
        public bool Add(Car car)
        {
            try
            {
                CarDealershipDB.Cars.Add(car);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public void PrintAllCars()
        {
            foreach (var item in CarDealershipDB.Cars)
            {
                Console.WriteLine(item.Manifacturer + " " + item.Name + " " + item.Fuel);
            }
        }

        public List<Car> GetAllVeryFastCars()
        {
            return CarDealershipDB.Cars.Where(car => car.TopSpeed > 200).ToList();
        }
    }
}
