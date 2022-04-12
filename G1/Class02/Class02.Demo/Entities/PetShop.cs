namespace Class02.Demo.Entities
{
    internal static class PetShop
    {
        public static int GetAge(object pet)
        {
            return 0;
        }

        public static int GetAge(object pet, int a)
        {
            return 1;
        }

        public static int GetAge(int a, object pet)
        {
            return 2;
        }
    }
}
