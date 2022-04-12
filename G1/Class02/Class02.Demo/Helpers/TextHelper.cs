namespace Class02.Demo.Helpers
{
    public static class TextHelper
    {
        public static int ValidationCounter { get; set; }
        public static bool ValidateInteger (string input)
        {
            bool valid = int.TryParse(input, out int result);
            ValidationCounter++;
            return valid;
        }
    }
}
