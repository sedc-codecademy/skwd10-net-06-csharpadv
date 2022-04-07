using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Advanced_G3_L1_EX1.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }

        string Name { get; set; }

        string Username { get; set; }

        string Password { get; set; }

        void PrintUser();
    }
}
