using Enteties.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enteties
{
    public class User : IUser
    {
        public User(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public string GetID()
        {
            return Id.ToString();
        }
    }
}
