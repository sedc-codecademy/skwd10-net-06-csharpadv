namespace TextHelper
{
    internal static class TextHelper
    {
        public static int CapitalLetterUses { get; set; }

        static TextHelper()
        {
            CapitalLetterUses = 0;
        }

        public static string CapitalFirstLetter(string word)
        {
            string returnValue;

            if (word.Length == 0)
            {
                return "Empty string";
            }
            else if (word.Length == 1)
            {
                returnValue = word.ToUpper();
            }
            else
            {
                returnValue = char.ToUpper(word[0]) + word.Substring(1);
            }

            CapitalLetterUses++;
            return returnValue;
        }
    }
}
