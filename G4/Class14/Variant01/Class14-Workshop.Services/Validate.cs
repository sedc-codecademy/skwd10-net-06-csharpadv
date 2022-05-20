namespace Class14_Workshop.Services
{
    using System.Linq;

    /// <summary>
    /// Static helper class for validating various types of fields.
    /// </summary>
    public static class Validate
    {
        /// <summary>
        /// Validates whether a string satisfies length requirements.
        /// </summary>
        /// <param name="value">The string to be validated.</param>
        /// <param name="minLength">The minimum length of the string.</param>
        /// <param name="maxLength">The maximum length of the string.</param>
        /// <returns><c>true</c> if string is valid; otherwise <c>false</c>.</returns>
        public static bool StringLength(string value, int minLength, int maxLength = int.MaxValue)
        {
            var trimmedString = value.Trim();

            if (string.IsNullOrWhiteSpace(trimmedString))
                return false;

            if (trimmedString.Length < minLength)
            {
                return false;
            }

            if (trimmedString.Length > maxLength)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates whether a string satisfies numeric character presence requirements.
        /// </summary>
        /// <param name="value">The string to be validated.</param>
        /// <param name="minNumericCharactersCount">The expected count of numeric characters.</param>
        /// <returns><c>true</c> if string is valid; otherwise <c>false</c>.</returns>
        public static bool StringHasNumericCharacters(string value, int minNumericCharactersCount = 1)
        {
            return value.Count(chr => "0123456789".Contains(chr)) >= minNumericCharactersCount;
        }
    }
}