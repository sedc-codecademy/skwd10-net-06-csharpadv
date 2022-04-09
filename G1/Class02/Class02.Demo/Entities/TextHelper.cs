using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class02.Demo.Entities
{
    public static class TextHelper
    {
        public static int ValidationCounter { get; set; }
        public static bool ValidateInteger (string input)
        {
            bool valid = int.TryParse(input, out int result);
            ValidationCounter++;
            return valid;
        }
    }
}
