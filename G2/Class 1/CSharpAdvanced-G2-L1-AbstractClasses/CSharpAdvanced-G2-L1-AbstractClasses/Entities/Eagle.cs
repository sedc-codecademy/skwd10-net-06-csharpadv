namespace CSharpAdvanced_G2_L1_AbstractClasses.Entities
{
    public class Eagle : Bird
    {
        public Eagle(string color, int flightSpeed, int height) : base(color, flightSpeed, height)
        {
        }

        public override void Sing()
        {
            Console.WriteLine("Eagle is singing eagle song.");
        }
    }
}
