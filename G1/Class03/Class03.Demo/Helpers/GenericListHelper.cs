namespace Class03.Demo.Helpers
{
    public static class GenericListHelper<T>
    {
        public static void Print(List<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static void GetInfo(List<T> items)
        {
            T first = items[0];
            Console.WriteLine($"This list has {items.Count} members and is of type {items.GetType().FullName}!");
        }
    }
}
