namespace Food
{
    /// <summary>
    /// A gourmet food implementation of the IFoodProcessor interface.
    /// The cook operating it is an actual chef, and he prepares food very
    /// carefully - never messes up, but he does it really slowly.
    /// </summary>
    internal class GourmetFoodProcessor: IFoodProcessor
    {
        public void PrepareFood(List<string> recipeSteps)
        {
            Console.WriteLine("Chef prepares food carefully...");

            foreach (var item in recipeSteps)
            {
                Console.WriteLine(item);
                // Fixed length, the chef cooks consistently
                Thread.Sleep(1000);
            }

            Console.WriteLine("Chef says: Bon apetit!");
        }
    }
}
