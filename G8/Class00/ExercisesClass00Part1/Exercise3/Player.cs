using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class Player
    {
        protected internal string Name { get; set; }
        public int Score { get; set; }
        public UserChoice PlayerChoice { get; set; }
    }
}
