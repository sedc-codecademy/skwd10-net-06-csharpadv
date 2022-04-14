namespace Calss02.Polymorphism.Entities
{
    public class Pet
	{
		public string Name { get; set; }
		public virtual void Eat()
		{
			Console.WriteLine("Nom nom nom");
		}
	}
}
