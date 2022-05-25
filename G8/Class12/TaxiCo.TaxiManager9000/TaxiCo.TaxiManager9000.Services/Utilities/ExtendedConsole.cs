// We use piggybacking to place our ColorConsole on the same level as Console
namespace System
{
    public static class ExtendedConsole
    {
        public static void WriteLine(string? value, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        public static void Write(string? value, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ResetColor();
        }
        public static string? GetInput(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }

        public static void NoItemsMessage<T>() => Console.WriteLine($"No {typeof(T).Name}s available");

        public static void Separator() => Console.WriteLine("---------------------------");
    }
}
