using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced_G2_L3_GenericsAndExtensions.Entities
{
    public class Box<T>
    {
        public int Id { get; set; }

        public Box(int id)
        {
            Id = id;
        }
    }
}
