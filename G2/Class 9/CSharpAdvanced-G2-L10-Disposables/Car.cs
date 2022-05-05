using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced_G2_L10_Disposables
{
    public class Car
    {
        public Driver[] Drivers { get; set; }

        public Car(Driver[] drivers)
        {
            Drivers = drivers;
        }


    }
}
