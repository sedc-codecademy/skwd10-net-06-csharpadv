using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// We use piggybacking to place our Colo
namespace System
{
    public static  class ExtendedConsole
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
        public static void Separator() => Console.WriteLine("---------------------");
    }
}
