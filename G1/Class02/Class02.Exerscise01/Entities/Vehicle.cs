using Class02.Exerscise01.Entities.Interfaces;
using Class02.Exerscise01.Enums;

namespace Class02.Exerscise01.Entities
{
    public abstract class Vehicle : IVehicle
    {
        public int Id { get; set; }
        public string Manifacturer { get; set; }
        public string Name { get; set; }
        public FuelEnum Fuel { get; set; }
        public int TopSpeed { get; set; }

        public abstract void Drive();

        public string GetVehicleInfo()
        {
            return $"Vehicle {Manifacturer} {Name} consumes {Fuel} and has top speed {TopSpeed}";
        }
    }
}
