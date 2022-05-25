using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class14.Demo1.Practices
{
    internal class Loops
    {
        private List<string> _names = new List<string>() { "Aleksandra", "Petar", "Aleksandar", "Dejan", "Ivona", "Marija" };
        public bool BadNameExist(string name)
        {
            bool exists = false;
            foreach (var item in _names)
            {
                if(item == name)
                {
                    exists = true;
                }
            }
            return exists;
        }

        public bool GoodNameExist(string name)
        {
            bool exists = false;
            foreach (var item in _names)
            {
                if (item == name)
                {
                    //return true;
                    exists = true;
                    break;
                }
            }
            return exists;
        }

        //bad example
        public void PrintNamesWithLengthAsList()
        {
            foreach (var item in _names)
            {
                if (item.Length == _names.Count)
                {
                    Console.WriteLine(item);
                }
            }
        }

        //doog example
        public void PrintNamesWithLengthAsListLength()
        {
            var listLength = _names.Count;
            foreach (var item in _names)
            {
                if (item.Length == listLength)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
