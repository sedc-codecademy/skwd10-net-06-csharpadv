namespace Food
{
    internal class Hamburger : IFood
    {
        public List<string> GetRecipeSteps()
        {
            return new List<string>
            {
                "~~~~~~~~~~~~~~~~~~~",
                "Preparing hamburger",
                "~~~~~~~~~~~~~~~~~~~",
                "Put bun",
                "Put patty",
                "Put lettuce",
                "Put tomato",
                "Put sauce",
                "Put bun",
                "~~~~~~~~~~~~~~~~~~~",
                "Done!",
                "~~~~~~~~~~~~~~~~~~~"
            };
        }
    }
}
