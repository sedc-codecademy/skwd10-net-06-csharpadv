namespace Food // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var foodProcessor = new FastFoodProcessor();

            var hamburger = new Hamburger();
            var hotDog = new HotDog();

            PrepareFood(hamburger, foodProcessor);
            PrepareFood(hotDog, foodProcessor);

            Console.WriteLine($"You don't like the food so you switch restaurants");
            Thread.Sleep(2000);

            var gourmetFoodProcessor = new GourmetFoodProcessor();

            PrepareFood(hamburger, gourmetFoodProcessor);
            PrepareFood(hotDog, gourmetFoodProcessor);
        }

        /// <summary>
        /// Method that invokes IFoodProcessor.PrepareFood over the recipe steps
        /// provided by the implementation of the IFood.GetRecipeSteps of the implemented
        /// food. The method itself does NOT care what's the class exactly, it only cares
        /// that the methods provided by the interfaces IFood and IProcessor are implemented.
        /// </summary>
        static void PrepareFood(IFood food, IFoodProcessor processor)
        {
            List<string> recipeSteps = food.GetRecipeSteps();

            processor.PrepareFood(recipeSteps);
        }
    }
}

