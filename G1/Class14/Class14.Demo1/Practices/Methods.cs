using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class14.Demo1.Practices
{
    //Bad Example
    public class BadService
    {
        public List<int> numbers = new List<int>();

        public void GetStats()
        {
            Console.WriteLine("Welcome to the app!");
            Console.WriteLine("Enter 5 numbers:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter number:");
                numbers.Add(int.Parse(Console.ReadLine()));
            }
            Console.Write("You entered: ");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Stats:");
            int even = numbers.Where(x => x % 2 == 0).Count();
            Console.WriteLine($"Even numbers: {even}");

            int odd = numbers.Count - even;
            Console.WriteLine($"Odd numbers: {odd}");

            int positive = numbers.Where(x => x >= 0).Count();
            Console.WriteLine($"Positive numbers: {positive}");

            int negative = numbers.Count - positive;
            Console.WriteLine($"Negative numbers: {negative}");

            int sum = numbers.Sum();
            Console.WriteLine($"Sum of numbers: {sum}");
        }
    }

    //Good example
    public class NumberService
    {
        public List<int> InputNumbers(int number)
        {
            List<int> numbers = new List<int>();
            Console.WriteLine("Welcome to the app!");
            Console.WriteLine($"Enter {number} numbers:");
            for (int i = 0; i < number; i++)
            {
                Console.Write("Enter number:");
                numbers.Add(int.Parse(Console.ReadLine()));
            }

            return numbers;
        }

        public void PrintStats(List<int> numbers)
        {
            Console.WriteLine();
            Console.WriteLine("Stats:");
            int even = numbers.Where(x => x % 2 == 0).Count();
            Console.WriteLine($"Even numbers: {even}");

            int odd = numbers.Count - even;
            Console.WriteLine($"Odd numbers: {odd}");

            int positive = numbers.Where(x => x >= 0).Count();
            Console.WriteLine($"Positive numbers: {positive}");

            int negative = numbers.Count - positive;
            Console.WriteLine($"Negative numbers: {negative}");

            int sum = numbers.Sum();
            Console.WriteLine($"Sum of numbers: {sum}");
        }
    }

    public static class HelperService<T>
    {
        public static void PrintList(List<T> list)
        {
            foreach(T item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintListInOneLine(List<T> list)
        {
            foreach (T item in list)
            {
                Console.Write(item + " ");
            }
        }
    }

    public class AppService
    {
        private NumberService _numberService;
        private List<int> _numbers;

        public AppService()
        {
            _numberService = new NumberService();
        }

        public void AppInit()
        {
            //input numbers
            _numbers = _numberService.InputNumbers(5);

            //print data
            Console.WriteLine("You have entered: ");
            HelperService<int>.PrintListInOneLine(_numbers);

            //print stats
            _numberService.PrintStats(_numbers);

        }
    }
}
