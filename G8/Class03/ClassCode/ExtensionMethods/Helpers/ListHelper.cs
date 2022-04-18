using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods.Helpers
{
    public static class ListHelper
    {
        public static void GoThroughString(this List<string> items)
        {
            foreach(string item in items)
            {
                Console.WriteLine(item);
            }
        }

        public static void GoThrough<T>(this List<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }

        public static void GetInfo<T>(this List<T> items)
        {
            T first = items[0];
            Console.WriteLine($"This list has {items.Count} members and is of type {items.GetType().FullName}");
        }

        public static List<T> TestMethod<T>(this List<T> items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
            return items;
        }

    }
}
