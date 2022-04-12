using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Person : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public long PhoneNumber { get; set; }
        //has no implementation. Must have implementation in the inherited classes. Can not be private !!!
        public abstract string GetInfo();

        public void Greeet(string name)
        {
            Console.WriteLine($"Hello {name}. I am {FirstName} {LastName}");
        }
        public void GoodBye()
        {
            Console.WriteLine($"Coodbye from {FirstName} {LastName}");
        }

        //public Person()
        //{

        //}

        public Person(string firstName, string lastName, int age, long phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;
        }

    }
}
