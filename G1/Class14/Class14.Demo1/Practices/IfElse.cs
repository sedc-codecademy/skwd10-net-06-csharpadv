using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class14.Demo1.Practices
{
    internal class IfElse
    {
        private bool _check = false;

        //bad example
        public void TestCheck()
        {
            if (_check == true)
            {
                Console.WriteLine("It is correct");
            }
        }


        //good example
        public void TestCheckGood()
        {
            //it is already bool no need to check it
            if (_check)
            {
                Console.WriteLine("It is correct");
            }
        }

        public void IsElseExample(int num1, int num2)
        {
            //bad example
            //check if 2 numbers are the same
            if(num1 <= 100 && num2 <=100)
            {
                if (num1 % 2 == 0 && num2 %2 == 0)
                {
                    if(num1 == num2)
                    {
                        Console.WriteLine("They are the same!");
                    }
                }
            }

            //good example
            if(num1 > 100 || num2 > 100) return;
            if(num1 % 2 != 0 || num2 % 2 != 0) return;
            if (num1 != num2) return;

            Console.WriteLine("They are the same!");
        }
    }
}
