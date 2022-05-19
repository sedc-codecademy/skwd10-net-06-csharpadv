using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPractices.GoodPractices
{
    public class Loops
    {
        List<string> strings = new List<string>(){"Gorjan", "Gjporgji", "Martina", "Jovana", "Petre"};

        public void LoopsExamples()
        {
            // Bad example
            // Print all names that are the same lenth of the list
            for(int counter = 0; counter < strings.Count; counter++)
            {
                if(strings[counter].Length == strings.Count)
                {
                    Console.WriteLine(strings[counter]);
                }
            }

            // Good example
            int listLength = strings.Count;
            for(int counter = 0; counter < listLength; counter++)
            {
                if (strings[counter].Length == strings.Count)
                {
                    Console.WriteLine(strings[counter]);
                }
            }
        }
    }
}
