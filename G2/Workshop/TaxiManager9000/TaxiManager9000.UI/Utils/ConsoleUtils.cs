namespace TaxiManager9000.UI.Utils
{
    public static class ConsoleUtils
    {
        public static void WriteLineInColor(string text, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
