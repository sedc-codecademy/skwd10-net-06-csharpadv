/// <summary>
/// Piggybacking to the System namespace which is where most of the
/// core features of C# are included. This means that we would get
/// access to the extension methods of StringHelper in any context
/// where we are using string (part of System).
/// </summary>
namespace System
{
    /// <summary>
    /// Extension methods must reside in static classes, cannot be
    /// included in non-static classes (you will get an error)
    /// </summary>
    internal static class StringHelper
    {
        public static string Shorten(this string str, int numberOfWords)
        {
            // cannot shorten to less than 1 word
            if (numberOfWords < 1)
            {
                throw new ArgumentException($"{nameof(numberOfWords)} should be greater than 1.");
            }

            // if original string length is 0, no processing is done
            if (str.Length == 0)
            {
                return "";
            }

            // split string into tokens with whitespace as delimiter
            string[] words = str.Split(' ');

            // if the number of words is less than the specified length for shortening
            if (words.Length <= numberOfWords)
            {
                return str;
            }

            // take [numberOfWords] words from the beginning. recall the
            // examples with Skip() in case we want to skip a certain number
            // of words before "taking" the result
            List<string> substring = words.Take(numberOfWords).ToList();

            // join taken words
            string result = string.Join(" ", substring);

            return $"{result}...";
        }

        /// <summary>
        /// Adds quotes to beginning and end of a string
        /// </summary>
        public static string QuoteString(this string text)
        {
            // if we want to add quotes to an interpolated string,
            // we need to "escape" the quotes inside
            return $"\"{text}\"";
        }
    }
}
