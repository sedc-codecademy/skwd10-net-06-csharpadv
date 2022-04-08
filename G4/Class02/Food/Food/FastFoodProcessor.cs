namespace Food
{
    /// <summary>
    /// A fast food implementation of the IFoodProcessor interface.
    /// The cook operating it is not great and always in a hurry, and sometimes this works,
    /// but other times he messes up preparation.
    /// </summary>
    internal class FastFoodProcessor : IFoodProcessor
    {
        public void PrepareFood(List<string> recipeSteps)
        {
            Random random = new Random();

            foreach (var item in recipeSteps)
            {
                Console.WriteLine(item);

                // roll d20 dice
                int recipeMessedUp = random.Next(1, 21); // 21 because otherwise 20 won't be included

                switch (recipeMessedUp)
                {
                    // critical failure
                    case 1:
                        Console.WriteLine("Cook messed up - preparation failed!");
                        return;
                    // lucky!
                    case 20:
                        Console.WriteLine("Cook got lucky and finised recipe step faster!");
                        Thread.Sleep(100);
                        break;
                    default:
                        Thread.Sleep(300);
                        break;
                }
            }
        }
    }
}
