using Class02.Exerscise01.Entities.Interfaces;

namespace Class02.Exerscise01.Entities
{
    public class Car : Vehicle, ICar
    {
        public int NumberOfDoors { get; set; }
        public override void Drive()
        {
            Console.WriteLine("Car sound \"Brrrrrm\"");
        }

        public int GetNumberOfDors()
        {
            return NumberOfDoors;
        }

        public string GetVehicleInfo()
        {
            return $"Hello, this care is {Manifacturer} {Name} and has {NumberOfDoors} doors.";
        }

        public string GetVehicleInfo(string name)
        {
            return $"Hello {name}, this care is {Manifacturer} {Name} and has {NumberOfDoors} dors.";
        }
    }
}
