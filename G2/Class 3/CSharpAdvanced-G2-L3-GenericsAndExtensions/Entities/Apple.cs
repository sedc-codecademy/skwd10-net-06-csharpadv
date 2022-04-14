using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced_G2_L3_GenericsAndExtensions.Entities
{
    internal class Apple : Box<Apple>
    {
        public Apple(int id) : base(id)
        {
        }
    }
}
