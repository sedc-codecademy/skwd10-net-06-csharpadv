using CSharp_Advanced_G3_L1_EX1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Advanced_G3_L1_EX1.Enteties
{
    public abstract class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual void PrintUser()
        {
            Console.WriteLine($"{Id} {Name} {Username}");
        }
    }
}
