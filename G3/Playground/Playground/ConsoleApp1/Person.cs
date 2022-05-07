using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Programmer : Person, ICoffeeDrinker
    {
        public string Language { get; set; }

        public void Drink(IStarbucksable coffee)
        {
            // 
        }
        public override string ToString()
        {
            return $"{FullName} loves {Language}";
        }
    }

    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName { get => $"{FirstName} {LastName}";}

        public override string ToString()
        {
            return FullName;
        }
    }

    public interface ICoffeeDrinker
    {
        void Drink(IStarbucksable coffee);
    }

    public interface IStarbucksable
    {

        int Price { get; set; }
    }
}
