namespace Class02.Demo.Entities
{
    public partial class Car
    {
        public int Id { get; set; }

        public string Manifacturer { get; set; }

        public string Name { get; set; }

        public int TopSpeed { get; set; }

        public void Drive()
        {
            Console.WriteLine("Brrrrrrrrrrm");
        }
    }
}
