namespace Class14_Workshop.UI
{
    using System;

    /// <summary>
    /// Helper class to allow extended usage of <see cref="Console"/>, while aggregating it
    /// into one class for reuse.
    /// </summary>
    static class ColorWriter
    {
        /// <summary>
        /// Writes text content in console output. No new line will be produced at the end.
        /// </summary>
        /// <param name="content">The text content.</param>
        /// <param name="textColor">The text color.</param>
        public static void Write(string content, TextColor textColor)
        {
            switch (textColor)
            {
                case TextColor.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(content);
                    Console.ResetColor();
                    break;
                case TextColor.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(content);
                    Console.ResetColor();
                    break;
                case TextColor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(content);
                    Console.ResetColor();
                    break;
            }
        }

        /// <summary>
        /// Writes text content in console output. No new line will be produced at the end.
        /// </summary>
        /// <param name="content">The text content.</param>
        /// <param name="textColor">The text color.</param>
        public static void Write(string content, ConsoleColor textColor)
        {
            Console.ForegroundColor = textColor;
            Console.Write(content);
            Console.ResetColor();
        }

        /// <summary>
        /// Writes text content in console output. Produces new line at the end.
        /// </summary>
        /// <param name="content">The text content.</param>
        /// <param name="textColor">The text color.</param>
        public static void WriteLine(string content, TextColor textColor)
        {
            switch (textColor)
            {
                case TextColor.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(content);
                    Console.ResetColor();
                    break;
                case TextColor.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(content);
                    Console.ResetColor();
                    break;
                case TextColor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(content);
                    Console.ResetColor();
                    break;
            }
        }

        /// <summary>
        /// Writes text content in console output. Produces new line at the end.
        /// </summary>
        /// <param name="content">The text content.</param>
        /// <param name="textColor">The text color.</param>
        public static void WriteLine(string content, ConsoleColor textColor)
        {
            Console.ForegroundColor = textColor;
            Console.WriteLine(content);
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Enum to limit possible colors when using <see cref="ColorWriter"/>.
    /// </summary>
    enum TextColor
    {
        Green,
        Yellow,
        Red
    }
}
