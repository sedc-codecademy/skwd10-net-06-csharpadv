using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced_G3_L6_Events.Enteties
{
    public class User
    {
        public string Name { get; set; }

        public string LastName { get; set; }
        public int Age { get; set; }

        public string Email { get; set; }

        public User(string name, string lastName, int age, string email)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            Email = email;
        }

        public void ReadPromotion(ProductType productType, string marketName)
        {
            Console.WriteLine($"Hello {Name}, there is a promotion available for {productType} at {marketName}");
        }
    }
}
