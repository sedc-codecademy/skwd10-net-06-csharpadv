using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCalculator
{

    internal class Calculator: ICalculator
    {
        public static int Add(int first, int second) => first + second;
        public static int Divide(int first, int second) => first / second;
        public static int Multiply(int first, int second) => first * second;
        public static int Subtract(int first, int second) => first - second;

        private delegate int CalculatorFunction(int first, int second);

        private Dictionary<Operation, CalculatorFunction> operations = new();

        public Calculator()
        {
            operations.Add(Operation.Add, Add);
            operations.Add(Operation.Subtract, Subtract);
            operations.Add(Operation.Multiply, Multiply);
            operations.Add(Operation.Divide, Divide);
        }

        public void AddOperation(Operation op, Func<int, int, int> function)
        {
            operations.Add(op, new CalculatorFunction(function));
        }

        public int Execute(int first, int second, Operation op)
        {
            var function = operations[op];
            var result = function(first, second);
            return result;
        }

        public Operation Resolve(string symbol)
        {
            return operations.Keys.FirstOrDefault(op => op.Symbol == symbol);
        }
    }
}
