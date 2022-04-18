using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Helpers
{
    public class NonGenericListHelper
    {
        public void GoThroughStrings(List<string> strings)
        {
            foreach (string str in strings)
            {
                Console.WriteLine(str);
            }
        }

        public void GetInfoForStrings(List<string> strings)
        {
            string first = strings[0];
            Console.WriteLine($"This list has {strings.Count} members and is of type {first.GetType()}");
        }

        public void GoThroughInts(List<int> ints)
        {
            foreach(int num in ints)
            {
                Console.WriteLine(num);
            }
        }

        public void GetInfoForInts(List<int> ints)
        {
            int first = ints[0];
            Console.WriteLine($"This list has {ints.Count} members and is of type {first.GetType()}");
        }
    }
}
