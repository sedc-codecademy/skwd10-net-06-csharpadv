using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingAttributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    internal class ProprertyDescriptionAttribute : ClassDescriptionAttribute
    {
        public ProprertyDescriptionAttribute(string description): base(description) { }
    }
}
