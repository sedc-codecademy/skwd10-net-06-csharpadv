namespace Class02.Demo.Entities
{
    public partial class Car
    {
        public void ServiceInfo()
        {
            Console.WriteLine($"Car {Manifacturer}-{Name} has top speed {TopSpeed}");
        }
    }
}
