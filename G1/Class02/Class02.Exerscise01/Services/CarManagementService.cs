using Class02.Exerscise01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class02.Exerscise01
{
    internal class CarManagementService
    {
        public void PrintAllCars()
        {
            foreach (var item in CarDealershipDB.Cars)
            {
                Console.WriteLine(item.GetVehicleInfo());
            }
        }

        public List<Car> GetAllVeryFastCars()
        {
            return CarDealershipDB.Cars.Where(car => car.TopSpeed > 200).ToList();
        }
    }
}
