namespace AdvancedLinq.Helpers
{
    public static class ListHelper
    {
        public static void Print<T>(this List<T> list)
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
