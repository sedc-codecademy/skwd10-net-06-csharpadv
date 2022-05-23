namespace GoodPractices
{
    using System;

    class EntityService : IEntityService
    {
        // keep methods as short as possible; if a method goes over
        // 20-30 lines, then consider creating smaller helper methods
        // (either in your class or, if you need something shared, a
        // publicly-accessible helper class) to shorten the number
        // of lines; do proper naming and it should be obvious what
        // the "shortcut" method does
        public void DoSomething()
        {
            PrintWordThis();
            PrintWhiteSpace();
            PrintWordIs();
            PrintWhiteSpace();
            PrintWordAn();
            PrintWhiteSpace();
            PrintWordExample();
            PrintWhiteSpace();
            PrintWordOf();
            PrintWhiteSpace();
            PrintWordAn();
            PrintWhiteSpace();
            PrintWordArtificially();
            PrintWhiteSpace();
            PrintWordLong();
            PrintWhiteSpace();
            PrintWordMethod();
            PrintFullStop();
            PrintNewLine();
        }

        public void MethodWithTooManyParameters(string param1, string param2, string param3, string param4, string param5,
            string param6, string param7, string param8, string param9, string param10, string param11, string param12,
            string param13, string param14, string param15, string param16, string param17, string param18, string param19,
            string param20)
        {
            throw new NotImplementedException();
        }

        private static void PrintNewLine()
        {
            Console.WriteLine();
        }

        private static void PrintFullStop()
        {
            Console.Write(".");
        }

        private static void PrintWordMethod()
        {
            Console.Write("m");
            Console.Write("e");
            Console.Write("t");
            Console.Write("h");
            Console.Write("o");
            Console.Write("d");
        }

        private static void PrintWordLong()
        {
            Console.Write("l");
            Console.Write("o");
            Console.Write("n");
            Console.Write("g");
        }

        private static void PrintWordArtificially()
        {
            Console.Write("a");
            Console.Write("r");
            Console.Write("t");
            Console.Write("i");
            Console.Write("f");
            Console.Write("i");
            Console.Write("c");
            Console.Write("i");
            Console.Write("a");
            Console.Write("l");
            Console.Write("l");
            Console.Write("y");
        }

        private static void PrintWordOf()
        {
            Console.Write("o");
            Console.Write("f");
        }

        private static void PrintWordExample()
        {
            Console.Write("e");
            Console.Write("x");
            Console.Write("a");
            Console.Write("m");
            Console.Write("p");
            Console.Write("l");
            Console.Write("e");
        }

        private static void PrintWordAn()
        {
            Console.Write("a");
            Console.Write("n");
        }

        private static void PrintWordIs()
        {
            Console.Write("i");
            Console.Write("s");
        }

        private static void PrintWhiteSpace()
        {
            Console.Write(" ");
        }

        private static void PrintWordThis()
        {
            Console.Write("T");
            Console.Write("h");
            Console.Write("i");
            Console.Write("s");
        }
    }
}
