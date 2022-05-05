namespace Class08.TaxiManager9000.Services.Helpers
{
    public static class ConsoleHelper
    {
        public static string GetInput(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }

        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
            Console.ReadLine();
        }

        public static void Separator() => Console.WriteLine("=============================================================");
    }
}
