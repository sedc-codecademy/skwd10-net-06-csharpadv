using System;

namespace GoodPractices
{
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var intArray = Enumerable.Range(1, 10).ToArray();

            // if you need to access a fixed value inside a loop, optimize
            // the implementation by extracting the initialization logic
            // outside of the loop
            int maxValue = 5;

            // use foreach for looping whenever possible; sometimes a regular
            // for is needed though, especially if you need to modify the list
            // during iteration (check the Update methods in our Repository
            // implementations)
            foreach (var i in intArray)
            {
                // this is redundant assignment of a fixed value for each loop
                // minValue = 5;
                if (i < maxValue)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    // prevent iterating further after all of the required numbers
                    // have been printed
                    break;
                }
            }

            for (int i = 0; i < intArray.Length; i++)
            {
                for (int j = intArray.Length; j > 0; j++) // continue with k, l, m, or go with ii, iii etc
                {
                    Console.WriteLine($"{i} {j}");
                }
            }

            bool condition = false;

            // explicit comparison to bool value is redundant, use ! when expecting false
            if (condition == true)
                // careful with one-liner if - you might waste a lot of time debugging;
                // for safety, always use explicit code blocks ({} - squigly brackets)
                Console.WriteLine("Hello");
        }

        public static void DoSomething(string paramOne, string paramTwo)
        {
            string variableOne = $"{paramOne} {paramTwo}";

            Console.WriteLine(variableOne);
        }

        public static string ReturnString(bool condition)
        {
            if (condition)
            {
                return "condition is true";
            }

            return "condition is false";
        }

        // invert ifs if it makes implementation shorter/cleaner/less nesting
        public static int ReturnInt(bool condition)
        {
            //if (condition)
            //{
            //    int sum = 0;
            //    sum = sum + 1;
            //    sum = sum + 2;
            //    return sum;
            //}

            //return 0;

            if (!condition) return 0;
            
            int sum = 0;
            sum = sum + 1;
            sum = sum + 2;
            return sum;
        }

        public enum StupidEnum
        {
            Value1,
            Value2,
            Value3
        }

        // in cases where it would require too many if statements,
        // consider using switch
        public static void UseStupidEnum(StupidEnum enumValue)
        {
            switch (enumValue)
            {
                case StupidEnum.Value1:
                    Console.WriteLine("Value1");
                    break;
                case StupidEnum.Value2:
                    Console.WriteLine("Value2");
                    break;
                default:
                    Console.WriteLine("Value3");
                    break;
            }
        }
    }
}
