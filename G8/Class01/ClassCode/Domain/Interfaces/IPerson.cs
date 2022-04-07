using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPerson
    {
        //string Nationality { get; set; } // getter, setter, because they are methods
        string GetInfo();
        void Greeet(string name);
        void GoodBye();
    }
}
