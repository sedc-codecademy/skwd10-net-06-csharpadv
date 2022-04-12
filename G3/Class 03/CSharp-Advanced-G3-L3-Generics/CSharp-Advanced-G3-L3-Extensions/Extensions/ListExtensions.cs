namespace CSharp_Advanced_G3_L3_Extensions.Extensions
{
    public static class ListExtensions
    {
        public static void PrintElements<T>(this List<T> listToPrint)
        {
            foreach(T item in listToPrint)
            {
                Console.WriteLine(item);
            }
        }
    }
}
