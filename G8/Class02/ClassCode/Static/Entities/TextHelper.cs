using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Static.Entities
{
    // Static helper class that we can use to help us out with some tasks involving text
    // We can call these methods without creating an instance of the class
    public static class TextHelper
    {
        // This value will be the same value from everywhere, no matter from where do we change it
        public static int MessagesGenerated = 0;

        public static void GenerateStatusMessage(OrderStatus status)
        {
            string result = "";
            switch (status)
            {
                case OrderStatus.Processing:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    result = "[Procesing] The order is being processed.";
                    break;
                case OrderStatus.Delivered:
                    Console.ForegroundColor = ConsoleColor.Green;
                    result = "[Delivered] The order is successfully delivered";
                    break;
                case OrderStatus.DeliveryInProgress:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    result = "[In Progress] The delivery is in progress...";
                    break;
                case OrderStatus.CouldNotDeliver:
                    Console.ForegroundColor = ConsoleColor.Red;
                    result = "[Not Delivered] There was a problem with the delivery";
                    break;
                default:
                    break;
            }
            Console.WriteLine(result);
            Console.ResetColor();
            MessagesGenerated++;
        }

        public static string CapitalFirstLetter(string word)
        {
            if(word.Length == 0)
            {
                return "Empty String";
            }
            else if (word.Length == 1)
            {
                return char.ToUpper(word[0]).ToString();
            }
            else
            {
                return char.ToUpper(word[0]) + word.Substring(1);
            }
        }

        public static int ValidateInput(string input)
        {
            int choice = 0;
            bool isMenuChoiseValid = int.TryParse(input, out choice);
            if (!isMenuChoiseValid)
            {
                Console.WriteLine("Wrong input...");
                return -1;
            }
            return choice;
        }
    }
}
