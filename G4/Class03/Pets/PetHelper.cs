namespace Pets
{
    /// <summary>
    /// Helper class to illustrate compile-time polymorphism.
    /// 
    /// All methods here have the same names, but different parameter
    /// types/order, so this is the only way to get multiple methods
    /// with same name in the same class.
    /// </summary>
    internal static class PetHelper
    {
        // Dog + string parameters
        public static void PetStatus(Dog dog, string ownerName)
        {
            Console.WriteLine($"Hey there {ownerName}");

            if (dog.IsGoodBoi)
            {
                Console.WriteLine("This dog is a good boi :)");
            }
            else
            {
                Console.WriteLine("This dog is not really a good boi :(");
            }
        }

        // string + Dog parameters
        public static void PetStatus(string ownerName, Dog dog)
        {
            Console.WriteLine($"Hey there {ownerName}");

            if (dog.IsGoodBoi)
            {
                Console.WriteLine("This dog is a good boi :) very very good boi");
            }
            else
            {
                Console.WriteLine("This dog is not really a good boi :( very very bad boi");
            }
        }

        // Cat + string parameters
        public static void PetStatus(Cat cat, string ownerName)
        {
            Console.WriteLine($"Hey there {ownerName}");

            if (cat.IsLazy)
            {
                Console.WriteLine("This cat is really lazy :(");
            }
            else
            {
                Console.WriteLine("This cat is not really lazy :)");
            }
        }

        // Cat only parameter
        public static void PetStatus(Cat cat)
        {
            Console.WriteLine("Hey, a cat with no owner");

            if (cat.IsLazy)
            {
                Console.WriteLine("This cat is really lazy :( really really lazy");
            }
            else
            {
                Console.WriteLine("This cat is not really lazy :) not lazy indeed");
            }
        }
    }
}
