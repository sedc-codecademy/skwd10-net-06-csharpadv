using System;

namespace SOLID
{
    using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            /*
             * SO(L)ID
             * Liskov Substitution Principle
             * "Objects of a superclass shall be replaceable with objects of its subclasses without breaking the application"
             *
             * This means that all of the classes inheriting from a base class should be able to behave exactly like an instance
             * of the base class; or, all of the base class members (properties/methods) should be invokable by every class inheriting
             * the base one, while not breaking execution of the class
             */

            List<BaseEntity> entities = new List<BaseEntity>
            {
                new Entity1(),
                new Entity2()
            };

            foreach (var entity in entities)
            {
                // if any of Entity1, Entity2 Print() invocation fails, this would break
                // Liskov substitution principle
                entity.Print();
            }

            /*
             * DRY - Don't Repeat Yourself
             *
             * Any implementation that you see being consistently reused in multiple locations,
             * extract it in common method/property/class - don't just copy paste it everywhere.
             * It will be very hard to maintain if you have multiple copies of the same logic in
             * different places in the application.
             */
            decimal number1 = 2;
            decimal number2 = 3;

            decimal average1 = Average(number1, number2);

            Console.WriteLine($"average1: {average1}");

            decimal number3 = 4;
            decimal number4 = 5;

            decimal average2 = Average(number3, number4);

            Console.WriteLine($"average2: {average2}");
        }

        public static decimal Average(decimal operand1, decimal operand2)
        {
            return (operand1 + operand2) / 2;
        }
    }
}
