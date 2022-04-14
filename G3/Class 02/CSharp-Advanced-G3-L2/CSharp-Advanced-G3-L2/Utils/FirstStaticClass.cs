using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Advanced_G3_L2.Utils
{
    public static class FirstStaticClass
    {
        public static int Counter;

        static FirstStaticClass()
        {
            Counter = 1;
        }

        public static int AddTwoNumbers(int firstNumber, int secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}
