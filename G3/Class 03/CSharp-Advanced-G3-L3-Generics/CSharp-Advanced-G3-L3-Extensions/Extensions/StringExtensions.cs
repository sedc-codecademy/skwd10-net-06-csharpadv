
namespace System
{
    public static class StringExtensions
    {
        public static string DeleteLastCharacter(this string text)
        {
            return text.Substring(0, text.Length - 1);
        }

        public static string DeleteLastCharacterClassic(string text)
        {
            return text.Substring(0, text.Length - 1);
        }

        public static string AddQuatations(this string textToQuote)
        {
            return @$"""{textToQuote}""";
        }
    }
}
