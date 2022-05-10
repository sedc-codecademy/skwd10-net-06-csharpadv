using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyCalculator
{
    internal class Operation
    {
        public string Value { get; init; }

        public string Symbol { get; set; }

        public Operation() { }

        public Operation(string operationName, string symbol)
        {
            Value = operationName;
            Symbol = symbol;
        }

        public override string ToString()
        {
            return Value;
        }

        public static Operation Add = new("Add", "+");
        public static Operation Subtract = new("Subtract", "-");
        public static Operation Multiply = new("Multiply", "*");
        public static Operation Divide = new("Divide", "/");
        public static Operation Invalid = new("Invalid", string.Empty);

    }
}
