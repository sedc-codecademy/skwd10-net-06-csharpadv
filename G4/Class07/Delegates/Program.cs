namespace Delegates
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            SayDelegate del = new SayDelegate(SayHello);
            SayDelegate bye = new SayDelegate(SayBye);
            // usage with anonymous method - note that the anonymous method
            // fits the SayDelegate delegate signature, that's why this scenario
            // is possible
            SayDelegate wow = new SayDelegate(x => Console.WriteLine($"Wow {x}!"));

            del("Bob");
            bye("Jill");
            wow("Greg");

            SayWhatever("Bob", SayHello);
            SayWhatever("Jill", SayBye);
            SayWhatever("Greg", x=> Console.WriteLine($"Wow {x}!"));
            SayWhatever("Anne", x =>
            {
                Console.WriteLine($"Stuff with {x}");
                Console.WriteLine($"Other stuff with {x}");
            });

            // add operands
            NumberMaster(2, 5, (num1, num2) => num1 + num2);
            // subtract operands
            NumberMaster(2, 5, (num1, num2) => num1 - num2);
            // ignore operands, just return 0
            NumberMaster(2, 5, (num1, num2) => 0);
            // return the largest operand
            NumberMaster(2, 5, (num1, num2) =>
            {
                if (num1 > num2) return num1;
                else return num2;
            });
        }

        #region SayDelegate

        /// <summary>
        /// Simple delegate without return type with one <see cref="string"/>
        /// parameter. Can be useful for providing different implementation for
        /// printing a string.
        /// </summary>
        /// <param name="something">The string parameter.</param>
        public delegate void SayDelegate(string something); // Equivalent to Action<string>

        /// <summary>
        /// Says hello to a person.
        /// </summary>
        /// <param name="person">The person to say hello to.</param>
        public static void SayHello(string person)
        {
            Console.WriteLine($"Hello {person}");
        }

        /// <summary>
        /// Says bye to a person.
        /// </summary>
        /// <param name="person">The person to say bye to.</param>
        public static void SayBye(string person)
        {
            Console.WriteLine($"Bye {person}");
        }

        /// <summary>
        /// Method that takes a <see cref="SayDelegate"/> parameter that
        /// takes the <paramref name="whatever"/> parameter as an argument.
        /// </summary>
        /// <param name="whatever">Some string that will be sent to <paramref name="sayDel"/>.</param>
        /// <param name="sayDel">The <see cref="SayDelegate"/> delegate taking the <paramref name="whatever"/> parameter.</param>
        public static void SayWhatever(string whatever, SayDelegate sayDel)
        {
            Console.WriteLine("Chatbot says:");
            sayDel(whatever);
        }

        #endregion

        #region NumbersDelegate

        /// <summary>
        /// Delegate that defines a method signature with <see cref="int"/> return type,
        /// and two <see cref="int"/> input parameters. Can be useful for an arithmetic
        /// operations over two operands.
        /// </summary>
        /// <param name="num1">The first number operand.</param>
        /// <param name="num2">The second number operand.</param>
        /// <returns>An integer result, depending on the implementation.</returns>
        public delegate int NumbersDelegate(int num1, int num2); // Equivalent to Func<int, int, int>

        /// <summary>
        /// Method that takes two number operands and <see cref="NumbersDelegate"/> delegate
        /// that takes those operands as parameters.
        /// </summary>
        /// <param name="num1">The first operand.</param>
        /// <param name="num2">The second operand.</param>
        /// <param name="numberDel">The delegate that takes the operands.</param>
        public static void NumberMaster(int num1, int num2, NumbersDelegate numberDel)
        {
            var result = numberDel(num1, num2);

            Console.WriteLine($"The result is: {result}");
        }

        #endregion
    }
}
