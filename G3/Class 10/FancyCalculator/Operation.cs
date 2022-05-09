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

        public Operation() { }

        public Operation(string operationName)
        {
            Value = operationName;
        }

        public override string ToString()
        {
            return Value;
        }

        public static Operation Add = new("Add");
        public static Operation Subtract = new("Subtract");
        public static Operation Multiply = new("Multiply");
        public static Operation Divide = new("Divide");
    }
}
