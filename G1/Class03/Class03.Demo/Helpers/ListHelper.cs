namespace Class03.Demo.Helpers
{
    public static class ListHelper
    {
        public static void PrintString(List<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static void GetInfoForStrings(List<string> strings)
        {
            string first = strings[0];
            Console.WriteLine($"This list has {strings.Count} members and is of type {first.GetType().Name}!");

        }

        public static void PrintInt(List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static void GetInfoForInts(List<int> ints)
        {
            int first = ints[0];
            Console.WriteLine($"This list has {ints.Count} members and is of type {first.GetType().Name}!");
        }
    }
}
