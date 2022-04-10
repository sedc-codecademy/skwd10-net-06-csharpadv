using Class02.Exerscise01.Entities;
using Class02.Exerscise01.Enums;

namespace Class02.Exerscise01
{
    public static class CarDealershipDB
    {
        public static List<Car> Cars = new List<Car>();

        static CarDealershipDB()
        {
            Cars = new List<Car>()
            {
                new Car(){ Id=1, Manifacturer="Honda", Name="Civic", Fuel=FuelEnum.Diesel, NumberOfDoors=5, TopSpeed=205},
                new Car(){ Id=2, Manifacturer="Fiat", Name="Punto", Fuel=FuelEnum.Petrol, NumberOfDoors=3, TopSpeed=185},
                new Car(){ Id=1, Manifacturer="Lamburgini", Name="Galardo", Fuel=FuelEnum.Petrol, NumberOfDoors=2, TopSpeed=285},
            };
        }
    }
}
