namespace CSharpAdvanced_G2_L1_AbstractClasses_Interfaces.Entities
{
    public abstract class Bird
    {
        public string Color { get; set; }

        public int FlightSpeed { get; set; } 

        public int Height { get; set; }

        public Bird(string color, int flightSpeed, int height)
        {
            Color = color;
            FlightSpeed = flightSpeed;
            Height = height;
        }

        public abstract void Sing();
    }
}
