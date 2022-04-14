using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced_G2_L2_StaticClassesAndPolymorphism.Entities
{
    public class User
    {
        public static int USERNAME_MAX_LENGTH = 225;

        public string Name { get; set; }

        public User(string name)
        {
            Name = name;
        }
    }
}
