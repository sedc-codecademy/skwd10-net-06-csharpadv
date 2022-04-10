namespace TextHelper // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // no comments here, but the naming of variables
            // should document the code. Always try to pick names
            // for classes/properties/methods/variables that make sense
            // in the given context, then additional comments would not
            // be necessary.
            Order validOrder = new Order();
            validOrder.Id = 1;
            validOrder.Title = "Banani";
            validOrder.Description = "Taze se";

            Console.WriteLine(validOrder.Print());
            Console.WriteLine(Order.IsOrderValid(validOrder));

            Order invalidOrder = new Order();
            invalidOrder.Id = 0;
            invalidOrder.Title = string.Empty;

            Console.WriteLine(invalidOrder.Print());
            Console.WriteLine(Order.IsOrderValid(invalidOrder));
        }
    }
}