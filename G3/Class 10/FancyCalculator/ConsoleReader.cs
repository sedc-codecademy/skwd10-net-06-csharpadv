using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCalculator
{
    public class ConsoleReader
    {
        public int ReadInteger()
        {
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int result))
            {
                throw new ApplicationException($"{input} is not a valid integer");
            }

            return result;
        }

        internal Operation ReadOperation(ICalculator calculator)
        {
            var input = Console.ReadLine().Trim();

            var operation = calculator.Resolve(input);

            if (operation == null)
            {
                return Operation.Invalid;
            }

            return operation;
        }
    }

}
