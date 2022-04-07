using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TestInterface : IPerson
    {
        public string GetInfo()
        {
            throw new NotImplementedException();
        }

        public void GoodBye()
        {
            throw new NotImplementedException();
        }

        public void Greeet(string name)
        {
            throw new NotImplementedException();
        }
    }
}
