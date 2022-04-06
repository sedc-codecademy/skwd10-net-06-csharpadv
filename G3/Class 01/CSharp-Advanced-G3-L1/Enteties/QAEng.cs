using Enteties.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enteties
{
    public class QAEng : IQAEng
    {
        public void Code()
        {
            Console.WriteLine("Writing automated tests");
        }

        public void TestCode()
        {
            Console.WriteLine("Testing application manualy");
        }
    }
}
