namespace Food
{
    /// <summary>
    /// Interface for modelling food
    /// </summary>
    internal interface IFood
    {
        /// <summary>
        /// Gets recipe steps to prepare food
        /// </summary>
        /// <returns></returns>
        List<string> GetRecipeSteps();
    }
}
