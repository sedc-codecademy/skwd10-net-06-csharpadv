namespace Food
{
    /// <summary>
    /// An interface to model a food processor
    /// </summary>
    internal interface IFoodProcessor
    {
        /// <summary>
        /// Method to prepare food by following recipe steps
        /// </summary>
        void PrepareFood(List<string> recipeSteps);
    }
}
