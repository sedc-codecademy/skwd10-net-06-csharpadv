using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp
{
    internal static class Extensions
    {
        public static IEnumerable<int> GetAllOddNumbers()
        {
            int value = 1;
            while (true)
            {
                yield return value;
                value += 2;
            }
           // return Enumerable.Range(1, int.MaxValue).Where(i => {
           //     Console.WriteLine($"Inside where {i}");
           //     return i % 2 == 1;
           //});
        }

        public static IEnumerable<int> GetAllTriangleNumbers()
        {
            int value = 1;
            int result = 1;
            while (true)
            {
                yield return result;
                value += 1;
                result += value;
            }
        }

        public static IEnumerable<int> GetAllTriangleNumbersUnderThousand()
        {
            int value = 1;
            int result = 1;
            while (true)
            {
                yield return result;
                value += 1;
                result += value;
                if (result > 1000)
                {
                    yield break;
                }
            }
        }

        public static IEnumerable<int> GetSomeNumbers()
        {
            yield return 7;
            yield return 12;
            yield return 42;
        }
    }
}
