namespace Food
{
    internal class HotDog : IFood
    {
        public List<string> GetRecipeSteps()
        {
            return new List<string>
            {
                "~~~~~~~~~~~~~~~~~~~",
                "Preparing hot dog",
                "~~~~~~~~~~~~~~~~~~~",
                "Cut bread",
                "Put wurst",
                "Put mustard",
                "Put ketchup",
                "~~~~~~~~~~~~~~~~~~~",
                "Done!",
                "~~~~~~~~~~~~~~~~~~~"
            };
        }
    }
}
